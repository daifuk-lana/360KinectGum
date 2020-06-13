using UnityEngine;
using UnityEngine.UI;
using uOSC;
using System;
using System.Reflection;
using EasyDeviceDiscoveryProtocolClient;

public class PortChange : MonoBehaviour
{
    public InputField inputField;
    //string AddressNumber = "127.0.0.1";
    int PortNumber = 39540;
    public Text text;
    uOscClient uOscClient;
    SampleBonesSend BoneSend;
    Responder EDDPPort;
    Text PortText;

    void Start()
    {
        uOscClient = this.GetComponent<uOSC.uOscClient>();
        BoneSend = this.GetComponent<SampleBonesSend>();
        EDDPPort = this.GetComponent<Responder>();
        PortText = GameObject.Find("PortText").GetComponent<Text>();
        inputField = inputField.GetComponent<InputField>();
        if (PlayerPrefs.GetInt("PortNumber") != 0) {
            PortNumber = PlayerPrefs.GetInt("PortNumber");
            PortText.text = "送信ポート番号：" + PortNumber.ToString();
            inputField.text = PortNumber.ToString();
            ChangePortNumber();
        }
    }
    void Update()
    {
        if (EDDPPort.requestServicePort != 0)
        {
            if (EDDPPort.requestServicePort != PortNumber)
            {
                PortNumber = EDDPPort.requestServicePort;
                PortText.text = "送信ポート番号：" + PortNumber.ToString();
                ChangePortNumber();
            }
        };
    }
    public void SetPortNumber()
    {
        //入力フォームよりデータ取得、int型に変換、表示
        inputField = inputField.GetComponent<InputField>();
        PortNumber = Int32.Parse(inputField.text);
        PlayerPrefs.SetInt("PortNumber", PortNumber);
        PortText.text = "送信ポート番号：" + inputField.text;
        ChangePortNumber();
    }
    public void ChangePortNumber()
    {
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