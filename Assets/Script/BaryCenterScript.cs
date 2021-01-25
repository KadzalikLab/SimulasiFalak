using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class BaryCenterScript : MonoBehaviour
{

//komponen mode interaktif
  public Toggle interaktifToggle;
  public GameObject interaktifCanvas;

  public GameObject bulan;
  public GameObject bumi;
  public GameObject titikBary;
  public RectTransform pasakBumi;
  int kecepatan;
  int temp;
  public Text nilaiKecepatan;
  public Text nilaiVelocity;
  public GameObject moonVelocity;

  public GameObject btPlay;
  public GameObject btPause;


//komponen mode kalkulasi
  public Toggle kalkulasiToggle;
  public GameObject kalkulasiCanvas;

  public GameObject bulan2;
  public GameObject bumi2;
  public RectTransform pasakBumi2;
  public RectTransform pasakBulan2;
  public GameObject titikBary2;
  
  public InputField dariTahun;
  public InputField sampaiTahun;
  public Text textData;
  public Text nilaiKecepatan2;
  bool animasikanKalkulasi;

  double jarakBulan,barycenter,thetaBulan,betaBulan;
  double EarthMass, MoonMass;
  int kecepatan2;
  Vector3 posisiAwal;

  double tahun,tahunSampai;

  double juliandayMulai,juliandaySampai,juliandayTemp;
  string data;

    // Start is called before the first frame update
    void Start()
    { 
    kecepatan =(int)  GameObject.Find("Bulan").GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().TimeScale;
    nilaiKecepatan.text=kecepatan.ToString("D2");
    nilaiKecepatan2.text="1";
    btPlay.SetActive( false ) ;
    btPause.SetActive( true ) ;

    EarthMass = 5.98*System.Math.Pow(10,24);
    MoonMass = 7.35*System.Math.Pow(10,22);
    posisiAwal = bulan2.transform.localPosition;
    dariTahun.text = "2020";
    sampaiTahun.text = "2030";
    
    juliandayTemp = 0;
    kecepatan2 = 1;
        
    }

    // Update is called once per frame
    void Update()
    {

      Vector2 bulanV2;
      Vector2 titikBaryV2;
      Vector2 sudutBulanV2;
      float angle;
      //defaultnya mode interaktif akan otomatis aktif sejak awal
      if (interaktifToggle.isOn){
       bulanV2=bulan.transform.position;
       titikBaryV2=titikBary.transform.position;
       sudutBulanV2= bulanV2-titikBaryV2;
       angle=(Mathf.Atan2(sudutBulanV2.y,sudutBulanV2.x)*Mathf.Rad2Deg);
      if (angle<0)angle+=360;
      pasakBumi.localEulerAngles=new Vector3(0,0,angle);

      if(interaktifCanvas.activeSelf == false);
      interaktifCanvas.SetActive( true ) ;
      if(kalkulasiCanvas.activeSelf == true);
      kalkulasiCanvas.SetActive( false ) ;

        //if(gameObject.ActiveSelf == true) // chech sebuah gameobject aktif / tidak

      }else
      {

      bulanV2=bulan2.transform.position;
      titikBaryV2=titikBary2.transform.position;
      sudutBulanV2= bulanV2-titikBaryV2;
      angle=(Mathf.Atan2(sudutBulanV2.y,sudutBulanV2.x)*Mathf.Rad2Deg);
      if (angle<0)angle+=360;
      pasakBumi2.localEulerAngles=new Vector3(0,0,angle);
      
      if(interaktifCanvas.activeSelf == true)
      interaktifCanvas.SetActive( false ) ;
      if(kalkulasiCanvas.activeSelf == false)
      kalkulasiCanvas.SetActive( true ) ; 
      }
     
    }



    public void PlayModeKalkulasi(){

      animasikanKalkulasi = true;

      tahun = double.Parse(dariTahun.text);
      tahunSampai = double.Parse(sampaiTahun.text);
      juliandaySampai = Konversi.TanggalKeJulianDay(tahunSampai,1,1,0,0,0);
        
      if (juliandayTemp ==0) {juliandayMulai = Konversi.TanggalKeJulianDay(tahun,1,1,0,0,0);
      GameObject.Find("GarisOrbitBulan").GetComponent<TrailRenderer>().enabled=false;
      GameObject.Find("GarisOrbitBaryTrail").GetComponent<TrailRenderer>().enabled=false;
      StartCoroutine(setUpTrail());}
      else juliandayMulai = juliandayTemp;

      StartCoroutine(BaryAnimation());
      
    }
    IEnumerator setUpTrail(){
      yield return new WaitForSeconds (0.5f);
      GameObject.Find("GarisOrbitBulan").GetComponent<TrailRenderer>().enabled=true;
      GameObject.Find("GarisOrbitBaryTrail").GetComponent<TrailRenderer>().enabled=true;}


    IEnumerator BaryAnimation(){


        while(animasikanKalkulasi){
                 
        yield return new WaitForSeconds (0.001f);//koding akan berhenti sejenak selama 0.05 detik lalu deksekusi lagi berulang, sampai langkahke mencapai 40
        juliandayMulai+=(0.041666666)*kecepatan2;

        juliandayTemp = juliandayMulai;
        
        int tahunHasil=Konversi.JulianDayKeTanggal(juliandayMulai)[3];
        int bulanHasil=Konversi.JulianDayKeTanggal(juliandayMulai)[2];
        int tanggalHasil=Konversi.JulianDayKeTanggal(juliandayMulai)[1];
        int jamHasil=Konversi.JulianDayKeTanggal(juliandayMulai)[4];
                
        thetaBulan= hisabEp.Meeus(juliandayMulai)[9];
        betaBulan= hisabEp.Meeus(juliandayMulai)[10];
        jarakBulan= hisabEp.Meeus(juliandayMulai)[17];
        barycenter =  (MoonMass*jarakBulan)/(EarthMass+MoonMass);

        data =tanggalHasil.ToString("D2")+" - "+bulanHasil.ToString("D2")+" - "+tahunHasil.ToString() +" | "+jamHasil.ToString("D2")+" UTC \n\nEcl Long: "+(float)thetaBulan+"\u00B0"+"\nEcl Lat: "+(float)betaBulan+"\u00B0"+"\nBumi ke Bulan : "+(int)jarakBulan+" Km"+"\nBumi ke Barycenter : "+(float) barycenter+" Km";;
        textData.text = data;
        pasakBulan2.localEulerAngles=new Vector3(0,(float)betaBulan,(float)thetaBulan);
        bulan2.transform.localPosition=new Vector3(120+(float)(jarakBulan/10000),bulan2.transform.localPosition.y,bulan2.transform.localPosition.z);
        bumi2.transform.localPosition=new Vector3(-8.7f+((float)-(barycenter/1000)),bumi2.transform.localPosition.y,bumi2.transform.localPosition.z);
        if (juliandayMulai>=juliandaySampai||interaktifToggle.isOn)animasikanKalkulasi=false;
   
      }
    }

    public void stopModeKalkulasi(){
      animasikanKalkulasi=false;
    }

    public void resetModeKalkulasi(){
      animasikanKalkulasi=false;
      StartCoroutine(resetJuliandayValue());
      
    }

      IEnumerator resetJuliandayValue(){
      yield return new WaitForSeconds (0.5f);
      juliandayTemp = 0;
       textData.text = "Tanggal";
      GameObject.Find("GarisOrbitBulan").GetComponent<TrailRenderer>().Clear();
      GameObject.Find("GarisOrbitBaryTrail").GetComponent<TrailRenderer>().Clear();}
     



    public void sliderKecepatan(float value){//diakses oleh slider yang bernilai antara 1 - 2000
      kecepatan=(int)value;
      GameObject.Find("Bulan").GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().TimeScale=kecepatan;
      nilaiKecepatan.text=kecepatan.ToString("D2");
    }

    public void sliderVelocity(float value){//diakses oleh slider yang bernilai antara 0.2 - 0.4
    bulan.transform.localPosition=new Vector3(-20f,36f,bulan.transform.localPosition.z);//posisi awal object bulan, supaya keplerScriptnya tidak berubah
    moonVelocity.transform.localPosition=new Vector3(-20,value,moonVelocity.transform.localPosition.z);
    nilaiVelocity.text=(value%=1).ToString();

    }

      public void sliderKecepatanKalkulasi(float value){//diakses oleh slider yang bernilai antara 1 - 2000
      kecepatan2=(int)value;
      nilaiKecepatan2.text=kecepatan2.ToString("D2");
    }


    public void pauseAnimasi(){//diakses oleh button pause
    btPlay.SetActive( true ) ;
    btPause.SetActive( false ) ;
    temp=kecepatan;
    kecepatan = 0;
    setUpValue();
    }

    public void playAnimasi(){
   
    btPlay.SetActive( false ) ;
    btPause.SetActive( true ) ;
    kecepatan = temp;
    setUpValue();

    }

    void setUpValue(){//method yang selalu dipanggil saat melakukan perubahan pada kecepatan waktu keplerScript
      GameObject.Find("Bulan").GetComponent<SimpleKeplerOrbits.KeplerOrbitMover>().TimeScale=kecepatan;
      nilaiKecepatan.text=kecepatan.ToString("D2");

    }


}
