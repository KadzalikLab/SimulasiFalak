 using UnityEngine;
 using UnityEngine.UI;
 using UnityEngine.EventSystems;

 

public class SliderInclination : MonoBehaviour,IPointerUpHandler 
{


    Slider slider;
    public Text textArahInclination;
    public RectTransform MoonOrbitLine;// base untuk diputar sesuai inklinasi
    public Transform PasakBulan;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();// pasang script ini ke game object yang mempunyai komponen slider
        MoonOrbitLine.localEulerAngles=new Vector3(5.14f,0f,0f);
    }

    public void yAxisSlider(float value){//ini diakses oleh arahslider
                
        MoonOrbitLine.localEulerAngles=new Vector3(MoonOrbitLine.localEulerAngles.x,-value,MoonOrbitLine.localEulerAngles.z);
        textArahInclination.text =value+"\u00B0 "; 
     }

    public void OnPointerUp(PointerEventData eventData)
    {   
    PasakBulan.localEulerAngles=new Vector3(PasakBulan.localEulerAngles.x,slider.value,PasakBulan.localEulerAngles.z); //12.19099221f dapat dari 360/29.53
    GameObject.Find("Slider UmurBulan").GetComponent<OrbitBulan>().slider.value = 0;
    //GameObject orbitBumi =  GameObject.Find("bumi");
    //float orbitBumi =  GameObject.Find("bumi").GetComponent<SimpleKeplerOrbits>().TimeScale;
    }
}