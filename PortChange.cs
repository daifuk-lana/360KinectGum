using UnityEngine;
using UnityEngine.UI;
using uOSC;
using System;
using System.Reflection;
using EasyDeviceDiscoveryProtocolClient;

public class PortChange : MonoBehaviour
{
    public InputField inputField;
    public InputField inputFieldReceive;
    //string AddressNumber = "127.0.0.1";
    int PortNumber = 39540;
    int PortNumberReceive = 39539;
    public Text text;
    uOscClient uOscClient;
    SampleBonesSend BoneSend;
    uOscServer uOscServer;
    SampleBonesReceive BoneReceive;
    Responder EDDPPort;
    Text PortText;
    Text PortTextReceive;

    void Start()
    {
        uOscClient = this.GetComponent<uOSC.uOscClient>();
        BoneSend = this.GetComponent<SampleBonesSend>();
        uOscServer = this.GetComponent<uOSC.uOscServer>();
        BoneReceive = this.GetComponent<SampleBonesReceive>();
        EDDPPort = this.GetComponent<Responder>();
        PortText = GameObject.Find("PortText").GetComponent<Text>();
        PortTextReceive = GameObject.Find("PortTextReceive").GetComponent<Text>();
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
        inputFieldReceive = GameObject.Find("InputFieldReceive").GetComponent<InputField>();
        if (PlayerPrefs.GetInt("PortNumber") != 0) {
            PortNumber = PlayerPrefs.GetInt("PortNumber");
            PortText.text = "送信ポート番号：" + PortNumber.ToString();
            inputField.text = PortNumber.ToString();
            ChangePortNumber(0);
        }
        if (PlayerPrefs.GetInt("PortNumberReceive") != 0)
        {
            PortNumberReceive = PlayerPrefs.GetInt("PortNumberReceive");
            PortTextReceive.text = "送信ポート番号：" + PortNumberReceive.ToString();
            inputFieldReceive.text = PortNumberReceive.ToString();
            ChangePortNumber(1);
        }
    }
    void Update()
    {
        //EDDP機能を使用する場合のポート自動設定
        if (EDDPPort.requestServicePort != 0)
        {
            if (EDDPPort.requestServicePort != PortNumber)
            {
                PortNumber = EDDPPort.requestServicePort;
                PortText.text = "送信ポート番号：" + PortNumber.ToString();
                ChangePortNumber(0);
            }
        };
    }
    public void SetPortNumber()
    {
        //入力フォームよりデータ取得、int型に変換、表示
        //inputField = GameObject.Find("InputField").GetComponent<InputField>();
        PortNumber = Int32.Parse(inputField.text);
        PlayerPrefs.SetInt("PortNumber", PortNumber);
        PortText.text = "送信ポート番号：" + inputField.text;
        ChangePortNumber(0);
    }
    public void ReceivePortNumber()
    {
        //入力フォームよりデータ取得、int型に変換、表示
        //inputFieldReceive = GameObject.Find("InputFieldReceive").GetComponent<InputField>();
        PortNumberReceive = Int32.Parse(inputFieldReceive.text);
        PlayerPrefs.SetInt("PortNumberReceive", PortNumberReceive);
        PortTextReceive.text = "送信ポート番号：" + inputFieldReceive.text;
        ChangePortNumber(1);
    }
    public void ChangePortNumber(int i)
    {
        //uOSC Clientにポート番号を入力、再起動
        if (i == 0)
        {
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
        else
        {
            BoneReceive.enabled = false;
            uOscServer.enabled = false;
            var type = typeof(uOSC.uOscServer);
            //var addressfield = type.GetField("address", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
            //addressfield.SetValue(uOscClient, AddressNumber);
            var portfield = type.GetField("port", BindingFlags.SetField | BindingFlags.NonPublic | BindingFlags.Instance);
            portfield.SetValue(uOscServer, PortNumberReceive);
            BoneReceive.enabled = true;
            uOscServer.enabled = true;
            //this.GetComponent<uOscClient>().OnEnable();
            //this.targetText.text = "送信ポート番号：" + PortNumber;
        }
    }
}