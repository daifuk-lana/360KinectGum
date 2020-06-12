using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.UIElements;
using Slider = UnityEngine.UI.Slider;

public class getKinectValue : MonoBehaviour
{
    Slider KinectSlider;

    private void Start()
    {
        KinectSlider = GetComponent<Slider>();

        float maxKinectFilter = 9f;
        float nowKinectFilter = 5f;

        KinectSlider.value = nowKinectFilter;
        KinectSlider.maxValue = maxKinectFilter;
    }

    void Update()
    {
        
    }
    public void Method()
    {
        Debug.Log("testÅF" + KinectSlider.value);
        GameObject.Find("VRM").GetComponent<AvatarController>().smoothFactor = KinectSlider.value;
        Debug.Log("åªç›ílÅF" + KinectSlider.value);
    }
}