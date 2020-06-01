using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using uOSC;
using System;

public class PortChange : MonoBehaviour
{
    public InputField inputField;
    int PortNumber = 39541;
    public Text text;

    public void SetPortNumber()
    {
        inputField = inputField.GetComponent<InputField>();
        PortNumber = Int32.Parse(inputField.text);
        //text = text.GetComponent<Text>();
        //Debug.Log("現在値：" + inputField.text);
        GameObject.Find("PortText").GetComponent<Text>().text = "送信ポート番号：" + inputField.text;
        this.GetComponent<uOscClient>().port = PortNumber;
        this.GetComponent<uOscClient>().OnDisable();
        this.GetComponent<SampleBonesSend>();
        //this.GetComponent<uOscClient>().OnEnable();
        //this.targetText.text = "送信ポート番号：" + PortNumber;
    }
}