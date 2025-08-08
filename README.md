---

# PipeDuctQuantifier(Revit2026)

 BIMモデルから配管やダクトの長さを自動で抽出するアドイン  
- 配管やダクトの長さ(m)を自動で計算 
- 結果をCSVでエクスポート
- 抽出する情報のカスタマイズ可

---

##  機能概要

| 内容       | 詳細                                   |
|------------|--------------------------------------|
| 対象カテゴリ | `DuctCurves`（ダクト）`PipeCurves`（ダクト）※今後拡張予定       |
| 比較項目   | ジオメトリより長さを取得（※変更可能） |
| 出力方法   | 結果をCSVで表示          |
| 読み込み対象 | モデル全体     |

---

##  抽出例（表示イメージ）

[PipeDuctSummary.csv]が出力される
Pipe: 28.2
Duct: 28.1




---

##  インストール方法

1. このリポジトリをクローンまたはダウンロード  
2. `PipeDuctQuantifier.dll` を Revitの Addins フォルダに配置  
3. 以下のような `.addin` ファイルを作成して読み込む：

```xml
<?xml version="1.0" encoding="utf-8" standalone="no"?>
<RevitAddIns>
  <AddIn Type="Command">
    <Name>PipeDuctQuantifier</Name>
    <Assembly>C:\test\PipeDuctQuantifier\PipeDuctQuantifier\bin\Debug\PipeDuctQuantifier.dll</Assembly>
    <AddInId>ABC12345-6789-0DEF-1234-56789ABCDEF0</AddInId>
    <FullClassName>PipeDuctQuantifier.Command</FullClassName>
    <VendorId>MyCompany</VendorId>
    <VendorDescription>KengoTanaka</VendorDescription>
  </AddIn>
</RevitAddIns>
```

---

 将来の構想（TODO）

・配管とダクト以外の要素も対象にする

・モデル比較機能

・GUIの追加

・CSVエクスポートにフィルター機能

・エクスポート先の選択

・長さの集計結果をグラフ化

・結果のPDFエクスポート

---

 作者

田中 健悟

 BIMエンジニア。Revitアドイン開発を独学で習得。

 Qiitaにて記事公開。
 https://qiita.com/KengoTanaka-BIM/items/4678d144b4deba564bfc

---

 ライセンス & お問い合わせ

ライセンス：MIT（※自由に使ってOK）

質問・案件相談は Issues または GitHub Profile からどうぞ

---


