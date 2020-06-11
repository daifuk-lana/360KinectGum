using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using uOSC;
using System;
using System.Reflection;

public class PortChange : MonoBehaviour
{
    public InputField inputField;
    //string AddressNumber = "127.0.0.1";
    int PortNumber = 39540;
    public Text text;
    uOscClient uOscClient;
    SampleBonesSend BoneSend;

    void Start()
    {
        uOscClient = this.GetComponent<uOSC.uOscClient>();
        BoneSend = this.GetComponent<SampleBonesSend>();
    }
    public void SetPortNumber()
    {
        //入力フォームよりデータ取得、int型に変換、表示
        inputField = inputField.GetComponent<InputField>();
        PortNumber = Int32.Parse(inputField.text);
        GameObject.Find("PortText").GetComponent<Text>().text = "送信ポート番号：" + inputField.text;

        //uOSC Clientにポート番号を入力、再起動
        BoneSend.enabled = false;
        uOscClient.enabled = false;
        var type = typeof(uOSC.uOscClient);
        //var addressfield = type.GetField("address", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
        //addressfield.SetValue(uOscClient, AddressNumber);
        var portfield = type.GetField("port", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
        portfield.SetValue(uOscClient, PortNumber);
        uOscClient.enabled = true;
        BoneSend.enabled = true;

        //this.GetComponent<uOscClient>().OnEnable();
        //this.targetText.text = "送信ポート番号：" + PortNumber;
    }
}