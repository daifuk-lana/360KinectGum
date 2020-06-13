# 🎮360KinectGum
![top](https://user-images.githubusercontent.com/59566441/83269906-b778c100-a202-11ea-8fbe-2d1e53ddecb9.png)  
Kinect v1（XBox360版及びWindows版）で動作するVRMモデル向けモーションキャプチャーツールです。  
VMCProtocolを使用し、[EVMC4U](https://github.com/gpsnmeajp/EasyVirtualMotionCaptureForUnity)等の対応アプリケーションへモーションデータを送信します。  
Kinect v1とVMCProtocolを結ぶバンジーガムのようなプログラムです。
# 🎬デモ
![シーケンス 01_2](https://user-images.githubusercontent.com/59566441/83273551-94044500-a207-11ea-876b-226337056e39.gif)
# 🎙ご説明
どこのご家庭の押し入れにも眠っているKinect v1を活用して、ブイチューバーの真似事が出来るようになります。  
[EVMC4U](https://github.com/gpsnmeajp/EasyVirtualMotionCaptureForUnity)や、[Oredayo](https://github.com/gpsnmeajp/Oredayo)にも簡単にモーションデータを送ることが出来ます。  

Kinect v1はPCで使用する場合、Xbox360版が個人利用、Windows版が商用利用可能となっております。  
各自Kinect v1の利用規約等をご確認の上、用途に合わせてご使用ください。  

なお、Kinect v1は販売終了しているため購入する場合は中古のみとなり、故障のリスクがあります。  
現行品と比較すると測定距離や解像度、精度の点で劣りますので、購入は推奨しません。  
本プログラムについても、私の趣味の範囲で作成しておりますのでご了承ください。  
 # 💻動作環境
 **[Unity](https://unity3d.com/jp/get-unity/download)**  
Unity上で動かします。私はバージョン2018.4.10f1を使用しています。  

**[Kinect for Windows SDK v1.8](https://www.microsoft.com/en-us/download/details.aspx?id=40278)**  
SDK v1.8がKinect v1に対応しています。  

**[Kinect with MS-SDK](https://assetstore.unity.com/packages/tools/kinect-with-ms-sdk-7747?locale=ja-JP)**  
Kinect v1をUnity上で使用するための便利なアセットです。  

**[VMCProtocol](https://sh-akira.github.io/VirtualMotionCaptureProtocol/)**  
OSCで姿勢情報を送受信出来る便利なプロトコルです。こちらを使用してEVMC4Uに動きを反映させます。  
[UniVRM](https://github.com/vrm-c/UniVRM)、[uOSC](https://github.com/hecomi/uOSC)の導入も必要となります。  

# ⬇導入
Unity、Kinect for Windows SDK v1.8を導入の上、Unityで新規プロジェクトを作成し、AssetStoreよりKinect with MS-SDKをインポートしてください。  

続いて、上記VMCProtocolのページを参照の上、UniVRM、uOSCも使用出来る状態にしておいてください。  
また、サンプルスクリプトのSampleBonesSend.csもインポートしておいてください。  

本GitHubより「VMCPKinectGum.cs」もインポートしてください。  

次に、空のGameObjectを作成し、以下のスクリプトをアタッチしてください。  
GameObjectの名前を「Script」にしておくと本プログラムの修正の必要がありません。  

* Asset/KinectScript/KinectManager.cs
* Asset/uOSC/Script/uOscClient.cs
* SampleBonesSend.cs
* VMCPKinectGum.cs

最後に、読み込ませたいVRMファイルを「default.vrm」とリネームし、「C:\VRM」を作成し、そこに保存してください。  

これで動作するはずですので、実行するとVRMが非同期処理で読み込まれ、Kinectで操作可能になります。  
VMCProtocolを通じ、EVMC4Uなどのアプリケーションに反映されます。  
u OSC ClientのPort番号を転送先のアプリケーションの受け側Port番号に合わせて下さい。  

# ❗おまけ
私がビルドしたものをbooth、releasesにそれぞれ置いています。  
背景の色は変えられませんが、カメラの画角やモーションフィルタは変更可能です。  
また、送信Port番号の変更も可能です。デフォルトは39540です。設定値は保存されます。  
リップシンク、まばたき、EDDPによる自動ポート設定(実質Oredayo4V専用)も実装しています。  
VRMファイルはC:\VRMにdefault.vrmで保存してください。  

**[booth](https://daifuklana.booth.pm/items/2109279)**  
**[release](https://github.com/daifuk-lana/360KinectGum/releases)**  

# 👽作者  
 
* [大福らな](https://www.youtube.com/channel/UCtg9i4TxyddG5QV5CYZETiQ)
* [pachelam.com](https://pachelam.com/)
* [@daifuk_lana](https://twitter.com/daifuk_lana)
 
# License
 
"360KinectGum" is under [MIT license](https://en.wikipedia.org/wiki/MIT_License).
 