using UnityEngine;

[DefaultExecutionOrder(-1)]
public class MenuManager : MonoBehaviour
{

    public GameObject Canvas;
    KinectManager KinectManager;
    // Use this for initialization
    void Start()
    {
        KinectManager = this.GetComponent<KinectManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            //KinectManagerにEscでプログラムを落とす機能が入ってるので一瞬止める
            KinectManager.enabled = false;
            //メニュー非表示
            Canvas.SetActive(false);
            //KinectManager再起動
            KinectManager.enabled = true;
        }

        if (Input.GetKey(KeyCode.Backspace))
        {
            //メニュー表示
            Canvas.SetActive(true);
        }

    }
}