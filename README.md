# PipeDuctQuantifier

**PipeDuctQuantifier** は、RevitのBIMモデルから配管やダクトの数量を自動で抽出するツールです。これを使うことで、設計の段階で数量を素早く計算でき、効率的にプロジェクトを進めることができます。

## 主な機能

- 配管やダクトの数量を自動で計算
- 結果をCSVやExcelにエクスポート可能
- 特定の条件で計算をカスタマイズできる

## インストール方法

1. GitHubからリポジトリをダウンロードします。以下のコマンドを実行して、リポジトリをPCに保存します。

   ```bash
   git clone https://github.com/KengoTanaka-BIM/PipeDuctQuantifier.git
```
   
必要なソフトウェアやツールをインストール

このプロジェクトでは、Revit APIにアクセスするための開発ツールが必要です。

C#や.NET Framework、Revit APIを使用するため、Visual Studioなどの開発環境が必要です。
インストール手順は別途提供された資料に従ってください。

クローンしたフォルダをビルド
クローンしたリポジトリをビルドして、Revitのアドインとして使用できるように設定します。

Visual Studioを開き、プロジェクトを開いてビルドを行います。

## 使い方
Revitを開く
Revitを起動します。

PipeDuctQuantifierのアドインを読み込む
Revitで、PipeDuctQuantifierのアドインを読み込みます。

モデルの配管やダクトを選択
数量を抽出したい配管やダクトを選択します。

数量を計算し、結果をCSVまたはExcelで保存
数量計算が完了したら、結果をCSVまたはExcel形式で保存できます。

## ライセンス
このプロジェクトは、MITライセンス に基づいて公開されています。
