# 360KinectGum

VMCProtocolを使用し、Xbox360版KinectとVRMファイルを結ぶバンジーガムのようなプログラムです。
Unity上で動作します。

# DEMO
 
<blockquote class="twitter-tweet"><p lang="ja" dir="ltr">Kinect v1で動く脱法ばもきゃ作りました。<a href="https://twitter.com/hashtag/EVMC4U?src=hash&amp;ref_src=twsrc%5Etfw">#EVMC4U</a> で動くことを確認しました。 <a href="https://twitter.com/hashtag/VMCProtocol?src=hash&amp;ref_src=twsrc%5Etfw">#VMCProtocol</a> <a href="https://t.co/772GaBBaOr">pic.twitter.com/772GaBBaOr</a></p>&mdash; 大福らな🧷ぱふぇらむ公式Vライバー (@daifuk_lana) <a href="https://twitter.com/daifuk_lana/status/1264927841935716353?ref_src=twsrc%5Etfw">May 25, 2020</a></blockquote>
 
# Features

どこのご家庭の押し入れにも眠っているXbox360版Kinectを活用して、ブイチューバーの真似事が出来るようになります。
 
# Requirement
 
**[Unity](https://unity3d.com/jp/get-unity/download)**
Unity上で動かします。私はバージョン2018.4.10f1を使用しています。

**[Kinect for Windows SDK v1.8](https://www.microsoft.com/en-us/download/details.aspx?id=40278)**
SDK v1.8がXbox360版Kinectに対応しています。

**[Kinect with MS-SDK](https://assetstore.unity.com/packages/tools/kinect-with-ms-sdk-7747?locale=ja-JP)**
Xbox360版KinectをUnity上で使用するための便利なアセットです。

**[VMCProtocol](https://sh-akira.github.io/VirtualMotionCaptureProtocol/)**
OSCで姿勢情報を送受信出来る便利なプロトコルです。こちらを使用してEVMC4Uに動きを反映させます。
[UniVRM](https://github.com/vrm-c/UniVRM)、[uOSC](https://github.com/hecomi/uOSC)の導入も必要となります。
説明は後述します。

# Installation

Unity、Kinect for Windows SDK v1.8を導入の上、
Unityで新規プロジェクトを作成し、AssetStoreより
Kinect with MS-SDKをインポートしてください。

続いて、上記VMCProtocolのページを参照の上、
UniVRM、uOSCも使用出来る状態にしておいてください。
また、サンプルスクリプトのSampleBonesSend.csも
インポートしておいてください。

また、本GitHubより「VMCPKinectGum.cs」もインポートしてください。

次に、空のGameObjectを作成し、以下のスクリプトをアタッチしてください。
GameObjectの名前を「Script」にしておくと本プログラムの修正の必要がありません。

Asset/KinectScript/KinectManager.cs
Asset/uOSC/Script/uOscClient.cs
SampleBonesSend.cs
VMCPKinectGum.cs

最後に、読み込ませたいVRMファイルを「default.vrm」とリネームし、
「C:\VRM」を作成し、そこに保存してください。

# Usage
 
実行すればVRMが非同期処理で読み込まれ、Kinectで操作可能になります。
VMCProtocolを通じ、EVMC4Uなどのアプリケーションに反映されます。
なお、u OSC ClientのPort番号を転送先のアプリケーションの受け側Port番号に合わせて下さい。
 
# Note
 
Xbox360版Kinectは終売となっておりサポートもありませんので、私としてはこれからの購入はおすすめしません。
従って本プログラムも基本的には私の趣味の範囲でカスタマイズされていくこととなりますので、ご承知おき下さい。
 
# Author
 
* 大福らな
* pachelam.com
* @daifuk_lana
 
# License
 
"360KinectGum" is under [MIT license](https://en.wikipedia.org/wiki/MIT_License).
 