using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using VRM;

public class VMCPKinectGum : MonoBehaviour
{
    void Start()
    {
        LoadModel("C:\\VRM\\default.vrm"); //VRMファイルの保存場所の指定
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
        //VRMオブジェクトへの動的アタッチ
        GameObject.Find("VRM").AddComponent<AvatarController>();
        GameObject.Find("Script").GetComponent<KinectManager>().ResetAvatarControllers(); //GameObject.Find("hogehoge")をKinectManagerをアタッチしたGameObjectに変更
        //BoneSendへのVRMオブジェクト代入
        GameObject.Find("Script").GetComponent<SampleBonesSend>().Model = GameObject.Find("VRM"); //GameObject.Find("hogehoge")をSampleBonesSendをアタッチしたGameObjectに変更
    }
}