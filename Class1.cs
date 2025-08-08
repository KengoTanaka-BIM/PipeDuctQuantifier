using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Linq.Expressions;

namespace PipeDuctQuantifier
{
    [Transaction(TransactionMode.Manual)]
    public class Command:IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            //配管とダクトをそれぞれ集計
            double totalPipeLength = GetTotalLength<Pipe>(doc);
            double totalDuctLength = GetTotalLength<Duct>(doc);

            //結果をcsvに書き込む
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "PipeDuctSummary.csv");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pipe,{UnitUtils.ConvertFromInternalUnits(totalPipeLength, UnitTypeId.Meters):F2}");
            sb.AppendLine($"Duct,{UnitUtils.ConvertFromInternalUnits(totalDuctLength, UnitTypeId.Meters):F2}");

            File.WriteAllText(filePath, sb.ToString());

            TaskDialog.Show("積算結果", $"配管・ダクトの長さがcsvとして保存されました:\n{filePath}");
            return Result.Succeeded;


        }
        private double GetTotalLength<T>(Document doc) where T : Element
        {
            // 対象の要素をフィルタリング
            var elements = new FilteredElementCollector(doc)
                .OfClass(typeof(T))
                .Cast<T>()
                .Where(e => e.Location != null)
                .ToList();

            double totalLength = 0;

            foreach (var element in elements)
            {
                // ジオメトリを取得
                LocationCurve locationCurve = element.Location as LocationCurve;
                if (locationCurve != null)
                {
                    // LocationCurve の長さを取得
                    totalLength += locationCurve.Curve.Length;
                }
            }

            return totalLength;

        }
    }
}