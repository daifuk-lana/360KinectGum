using AniLipSync.VRM;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRM;

public class VMCPKinectGum : MonoBehaviour
{
    Toggle toggleLip;
    Toggle toggleBlink;
    GameObject model;
    AnimMorphTarget LipSync;
    Blinker blinker;
    void Start()
    {
        LoadModel("C:\\VRM\\default.vrm"); //VRMファイルの保存場所の指定
        toggleLip = GameObject.Find("LipSync").GetComponent<Toggle>();
        toggleBlink = GameObject.Find("BlinkStart").GetComponent<Toggle>();
        LipSync = GameObject.Find("AniLipSync-VRM").GetComponent<AnimMorphTarget>();
    }
    public async Task LoadModel(string path)
    {
        if (!File.Exists(path))
        {
            Debug.LogError("file not found path = " + path);
            return;
        }
        //VRMファイルの読み込み
        var bytes = File.ReadAllBytes(path);
        var context = new VRMImporterContext();
        context.ParseGlb(bytes);
        var meta = context.ReadMeta(false);
        await context.LoadAsyncTask();
        //VRMファイルの表示
        context.ShowMeshes();
        context.EnableUpdateWhenOffscreen();
        context.ShowMeshes();
        model = GameObject.Find("VRM");

        //VRMオブジェクトへの動的アタッチ
        model.AddComponent<AvatarController>();
        this.GetComponent<KinectManager>().ResetAvatarControllers(); //thisをKinectManagerをアタッチしたGameObjectに変更
        //BoneSendへのVRMオブジェクト代入
        this.GetComponent<SampleBonesSend>().Model = GameObject.Find("VRM"); //thisをSampleBonesSendをアタッチしたGameObjectに変更
        //Blinker追加
        var lookAt = model.GetComponent<VRMLookAtHead>();
        if (lookAt != null)
        {
            model.AddComponent<Blinker>();
            blinker = model.GetComponent<Blinker>();
        }
            
        //AniLipSync-VRMへのVRMオブジェクト代入
        LipSync.blendShapeProxy = model.GetComponent<VRMBlendShapeProxy>(); //thisをSampleBonesSendをアタッチしたGameObjectに変更
    }
    public void LipSyncStart()
    {
        if (toggleLip.isOn == true)
        {
            LipSync.blendShapeProxy = model.GetComponent<VRMBlendShapeProxy>(); //thisをSampleBonesSendをアタッチしたGameObjectに変更
        }
        //AniLipSync-VRMへのVRMオブジェクト代入
        else
        {
            LipSync.blendShapeProxy = null; //thisをSampleBonesSendをアタッチしたGameObjectに変更
        };
    }
    public void BlinkStart()
    {
        if (blinker != null)
        {
            if (toggleBlink.isOn == true)
            {
                blinker.enabled = true;
            }
            //AniLipSync-VRMへのVRMオブジェクト代入
            else
            {
                blinker.enabled = false;
            };
        }

    }
}