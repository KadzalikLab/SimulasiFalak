using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OrbitBulan : MonoBehaviour
{
   public Slider slider;
   public Slider sliderArahInklinasi;
   public Transform PasakBulan;
   public Text TextHari;
   private float sudutRotasi = 0;


   public GameObject btPlay;
   public GameObject btPause;

   public GameObject bulan;
   public GameObject ekliptik;

   public Text textLintangBulan;

   public float posMax;
   public float deltaY;//nilai 29.53 (periode satu bulan) bila dijadikan satu rotasi penuh.

    public bool play;
    // Start is called before the first frame update
    void Start()
    {
      slider = GetComponent<Slider>();
      btPlay.SetActive( true ) ;
      btPause.SetActive( false ) ;
      posMax = bulan.transform.position.y-ekliptik.transform.position.y;
      deltaY = 360/29.53f;
     
        
    }
     public void Update(){

      Vector2 posBulan=bulan.transform.position;
      Vector2 posEkliptik=ekliptik.transform.position;
      float lintangBulan = (posBulan.y-posEkliptik.y )*(5.14f/posMax);// 21.48... adalah hasil dari 5.14 dibagi jarak antara posbulan dikurang posekliptik

      int derajat = Konversi.DesimalKeDerajat(lintangBulan)[1];
      int menit = Konversi.DesimalKeDerajat(lintangBulan)[2];
      textLintangBulan.text="Lintang Ekliptika Bulan: \n"+derajat.ToString("D2")+"\u00B0"+ menit.ToString("D2") +"\u2032  ";   
      	
   if (Input.GetKey(KeyCode.Escape))
    {SceneManager.LoadScene("MenuAwal");}
      
        }



     public void resetPos(){

      slider.value = 0;
     }

      public void UmurBulan (float value)
     {
      PasakBulan.localEulerAngles=new Vector3(PasakBulan.localEulerAngles.x,-(value*deltaY)+sliderArahInklinasi.value,PasakBulan.localEulerAngles.z); //12.19099221f dapat dari 360/29.53
      int hari = DesimalKeHari(value)[1];
      int jam = DesimalKeHari(value)[2];
      int menit = DesimalKeHari(value)[3];
      TextHari.text =hari.ToString()+" Hari "+jam.ToString()+" Jam "+menit.ToString()+" Menit";

     }

      public  static int [] DesimalKeHari (double desimal){
        
      int yaum=(int)desimal;
      double jam=System.Math.Abs((desimal%1)*24);
      double menit=System.Math.Round((jam%1)*60);

      return new int[]{0,yaum,(int)jam,(int)menit};
      }


    public void playAnimasi(){
    play = true;
    btPlay.SetActive( false ) ;
    btPause.SetActive( true ) ;
    sudutRotasi=(slider.value*deltaY)-sliderArahInklinasi.value;
    StartCoroutine(Orbit());
    slider.interactable = false;
    sliderArahInklinasi.interactable = false;}


      public IEnumerator Orbit ()
        {float nilaiSlider = (slider.value*deltaY);
        
        while(play){


        yield return new WaitForSeconds (0.03f);//koding akan berhenti sejenak selama 0.03 detik lalu deksekusi lagi berulang, sampai langkahke mencapai 40
        sudutRotasi+=0.4f;
         PasakBulan.localEulerAngles=new Vector3(PasakBulan.localEulerAngles.x,-sudutRotasi,PasakBulan.localEulerAngles.z); //12.19099221f dapat dari 360/29.53
        nilaiSlider+=0.4f;
        slider.value =(nilaiSlider/deltaY)%29.53f;
                       
      }
    }

   public void stopAnimasi(){
   play = false;
   sliderArahInklinasi.interactable = true;
   slider.interactable = true;
   btPlay.SetActive( true ) ;
   btPause.SetActive( false ) ;
   }
}
