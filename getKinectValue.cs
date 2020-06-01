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

        KinectSlider.maxValue = maxKinectFilter;
        KinectSlider.value = nowKinectFilter;
    }

    void Update()
    {
        
    }
    public void Method()
    {
        GameObject.Find("VRM").GetComponent<AvatarController>().smoothFactor = KinectSlider.value;
        Debug.Log("åªç›ílÅF" + KinectSlider.value);
    }
}