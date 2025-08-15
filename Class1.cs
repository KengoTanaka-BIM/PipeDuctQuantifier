using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using ClosedXML.Excel;
using System;
using System.Linq;

namespace PipeDuctQuantifier
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            // 簡易 TaskDialog で OK/Cancel
            TaskDialog td = new TaskDialog("Pipe/Duct 集計")
            {
                MainInstruction = "配管・ダクトの集計を実行しますか？",
                CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel
            };

            if (td.Show() != TaskDialogResult.Ok)
                return Result.Cancelled;

            // Pipe 集計
            var pipes = new FilteredElementCollector(doc)
                .OfClass(typeof(Pipe))
                .Cast<Pipe>()
                .Where(p => p.Location != null)
                .ToList();

            // Duct 集計
            var ducts = new FilteredElementCollector(doc)
                .OfClass(typeof(Duct))
                .Cast<Duct>()
                .Where(d => d.Location != null)
                .ToList();

            // Excel 出力
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = System.IO.Path.Combine(desktop, "PipeDuctSummary.xlsx");

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("集計");

                ws.Cell(1, 1).Value = "種類";
                ws.Cell(1, 2).Value = "ElementId";
                ws.Cell(1, 3).Value = "名称";
                ws.Cell(1, 4).Value = "長さ (m)";
                ws.Cell(1, 5).Value = "材質";
                ws.Cell(1, 6).Value = "系統名";

                int row = 2;

                foreach (var p in pipes)
                {
                    ws.Cell(row, 1).Value = "Pipe";
                    ws.Cell(row, 2).Value = p.Id.ToString();
                    ws.Cell(row, 3).Value = p.Name;
                    ws.Cell(row, 4).Value = Math.Round(GetLength(p), 2);
                    ws.Cell(row, 5).Value = GetParameterValue(p, BuiltInParameter.RBS_PIPE_MATERIAL_PARAM);
                    ws.Cell(row, 6).Value = GetParameterValue(p, BuiltInParameter.RBS_SYSTEM_NAME_PARAM);
                    row++;
                }

                foreach (var d in ducts)
                {
                    ws.Cell(row, 1).Value = "Duct";
                    ws.Cell(row, 2).Value = d.Id.ToString();
                    ws.Cell(row, 3).Value = d.Name;
                    ws.Cell(row, 4).Value = Math.Round(GetLength(d), 2);
                    // RBS_DUCT_MATERIAL_PARAM がないので Material パラメータを直接取得
                    ws.Cell(row, 5).Value = d.LookupParameter("Material")?.AsString() ?? "";
                    ws.Cell(row, 6).Value = GetParameterValue(d, BuiltInParameter.RBS_SYSTEM_NAME_PARAM);
                    row++;
                }

                wb.SaveAs(filePath);
            }

            TaskDialog.Show("完了", $"集計結果をExcelに出力しました:\n{filePath}");
            return Result.Succeeded;
        }

        private double GetLength(Element e)
        {
            var loc = e.Location as LocationCurve;
            if (loc != null)
            {
                return UnitUtils.ConvertFromInternalUnits(loc.Curve.Length, UnitTypeId.Meters);
            }
            return 0;
        }

        private string GetParameterValue(Element e, BuiltInParameter param)
        {
            var p = e.get_Parameter(param);
            return p != null ? p.AsString() ?? "" : "";
        }
    }
}
