# PipeDuctQuantifier(Revit2026)

**PipeDuctQuantifier** は、RevitのBIMモデルから配管やダクトの長さを自動で抽出するツールです。これを使うことで、設計の段階で数量を素早く計算でき、効率的にプロジェクトを進めることができます。

## 主な機能

- 配管やダクトの長さ(m)を自動で計算
- 結果をCSVにエクスポート可能
- 抽出する情報をカスタマイズできる

## インストール方法

1. GitHubからリポジトリをダウンロードします。以下のコマンドを実行して、リポジトリをPCに保存します。

   ```bash
   git clone https://github.com/KengoTanaka-BIM/PipeDuctQuantifier.git
　
   
2. 必要なソフトウェアやツールをインストール
   このプロジェクトでは、Revit APIにアクセスするための開発ツールが必要です。
   C#や.NET Framework、Revit APIを使用するため、Visual Studioなどの開発環境が必要です。
   インストール手順は別途提供された資料に従ってください。

3. クローンしたフォルダをビルド
   クローンしたリポジトリをビルドして、Revitのアドインとして使用できるように設定します。
   Visual Studioを開き、プロジェクトを開いてビルドを行います。

## 使い方
　1. Revitを開く
   　Revitを起動します。

　2. PipeDuctQuantifierのアドインを読み込む
 　  Revitで、PipeDuctQuantifierのアドインを読み込みます。
 
　3. 配管やダクトの数量を抽出する
  　 モデル内の配管やダクトを選択し、数量の抽出を実行します。

　4. 結果をエクスポート
 　  計算結果をCSV形式でエクスポートできます。

## ライセンス
このプロジェクトは、MITライセンス に基づいて公開されています。
