using UnityEngine;
using UnityEngine.UI;

public class RaDecScript : MonoBehaviour
{

    public GameObject bumi;
    public RectTransform star;
    public LineRenderer lineRendererDec;
    public GameObject lineDec;
    public Text txtDec;

    public LineRenderer lineRendererRa;
    public Text txtRa;
  

    // Start is called before the first frame update
    void Start()
    { bumi.transform.localEulerAngles=new Vector3(0,198f,-23f);
    
    lineRendererDec.SetVertexCount (90 + 1);
    lineRendererDec.useWorldSpace = false;
    rotateLineDec(0);

    lineRendererRa.SetVertexCount (90 + 1);
    lineRendererRa.useWorldSpace = false;
    rotateLineRa(0);
        
    }
  

    // Update is called once per frame
    void Update()
    {
 
    }

    public void xAxisToogle(bool value){//Ra
        GameObject.Find("Bumi").GetComponent<RotateWithDrag>().xRotation = value;

    }

    public void yAxisToogle(bool value){//Dec
        GameObject.Find("Bumi").GetComponent<RotateWithDrag>().yRotation = value;
        
    }

    public void resetRot(){
        bumi.transform.localEulerAngles=new Vector3(0,198f,-23);

    }

    public void rotateStarRA(float value){
    int Deg=Konversi.DesimalKeDerajat(value)[1];
    int Men=Konversi.DesimalKeDerajat(value)[2];
    string dms=Deg.ToString("D2")+"\u00B0"+ Men.ToString("D2") +"\u2032"; // "D2" adalah string formatter agar angka dibawah 10 didepanya tetap ada nol : 09 bukan 9
    txtRa.text=dms;

    star.transform.localEulerAngles=new Vector3(star.transform.localEulerAngles.x,-value,star.transform.localEulerAngles.z);
    lineDec.transform.localEulerAngles=new Vector3(lineDec.transform.localEulerAngles.x,(-value-90),lineDec.transform.localEulerAngles.z);
    rotateLineRa(value);
    }
    
    public void rotateStarDEC(float value){
    int Deg=Konversi.DesimalKeDerajat(value)[1];
    int Men=Konversi.DesimalKeDerajat(value)[2];
    string dms=Deg.ToString("D2")+"\u00B0"+ Men.ToString("D2") +"\u2032"; // "D2" adalah string formatter agar angka dibawah 10 didepanya tetap ada nol : 09 bukan 9
    txtDec.text=dms;

    star.transform.localEulerAngles=new Vector3(-value,star.transform.localEulerAngles.y,star.transform.localEulerAngles.z); 
    rotateLineDec(value);
    }

    void rotateLineDec(float value){
    float x;
    float y;
    float z = 0f;
    float segmentsDec = 90;//semakin banyak garisnya semakin halus 

    float angle = 90f;//dimulai dari titik mana pointya?

    for (int i = 0; i < (segmentsDec + 1); i++)
    {
        x = Mathf.Sin (Mathf.Deg2Rad * angle) * 1.2f;
        y = Mathf.Cos (Mathf.Deg2Rad * angle) * 1.2f;

        lineRendererDec.SetPosition (i,new Vector3(x,y,z) );

        angle -= (value / segmentsDec);
    }

    }

    void rotateLineRa(float value){
    float x;
    float y;
    float z = 0f;
    float segmentsRa = 90;

    float angle = 90;

    for (int i = 0; i < (segmentsRa + 1); i++)
    {
        x = Mathf.Sin (Mathf.Deg2Rad * angle) * 1.2f;
        y = Mathf.Cos (Mathf.Deg2Rad * angle) * 1.2f;

        lineRendererRa.SetPosition (i,new Vector3(x,z,y) );

        angle -= (value /segmentsRa);
    }

    }
}
