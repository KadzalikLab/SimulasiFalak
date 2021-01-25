using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class ScriptManager : MonoBehaviour
{
   
    public Toggle lambat;
    public Toggle cepat;

    public Toggle jam24;
    public Toggle jam240;

    public Transform pasakRevolusi;
    public Transform bumi;
    public Transform bayanganBumi;

    private float panjangHari =0; // panjang sudut sesuai dengan panjang hari yang dipilih. 24 jam = 1 hari. 240 jam 10 hari
    private float selisihSudut =0f; // selisih sudut antara revolusi sekarang dan sudut yang akan dituju
   
    private float sudutRotasi =0;
    private float sudutRotasiSid =0;
    private float rotasiPenuh =0;
    private int sudutPasak = 0;
    bool revolusiBool = false; // set revolusi object bumi

    bool revolusiSidBool = false; 
    private float panjangHariSid = 0f;

    public Button DisableButton1;
    public Button DisableButton2;
    public Button DisableButton3;

    private int klikanKe = 0;
    public Text text;

    public GameObject touchMask;
                     


    // Update is called once per frame
    void Update()
    { 
    //tombol kembali
    if (Input.GetKeyDown(KeyCode.Escape)) 
   {
       touchMask.SetActive( false ) ;
        //GameObject.Find("TouchMask").GetComponent<TouchScript.Gestures.TransformGestures>().enabled=false;
       SceneManager.LoadScene("MenuAwal");}
   

    }

    public void resetPos(){

        rotasiPenuh=0;
 
        selisihSudut=0;
        sudutRotasi = 0f;
        panjangHari=0;
        sudutRotasiSid = 0;
        klikanKe = 0;

        pasakRevolusi.localEulerAngles  = new Vector3(0f, 0f, selisihSudut);
        bumi.localEulerAngles  = new Vector3(0f, 0f, sudutRotasi);
        bayanganBumi.position = new Vector3(bumi.position.x,bumi.position.y,bumi.position.z+5f);
        bayanganBumi.rotation=bumi.rotation;
        text.text ="Sudut ke Tengah Hari :\n" +sudutRotasi+"\u00B0";

    }

    public void satuSolarday(){

        revolusiBool = true ; 
       
        sudutRotasi = 0f;
        rotasiPenuh=360;

         StartCoroutine(Revolusi());// menjalankan revolusi 
    
    }


     IEnumerator Revolusi ()// fungsi ini diakses oleh clickbutton
         {
             float langkahke = 0;//step atau frame, satu kali rotasi bumi adalah 30 frame
             bayanganBumi.rotation=bumi.rotation;
             bayanganBumi.position = new Vector3(bumi.position.x,bumi.position.y,bumi.position.z+5f);
            
             while(revolusiBool){
                 
                  yield return new WaitForSeconds (0.05f);//koding akan berhenti sejenak selama 0.05 detik lalu deksekusi lagi berulang, sampai langkahke mencapai 40
                 
                lambat.interactable = false; 
                cepat.interactable = false; 
                jam24.interactable = false; 
                jam240.interactable = false; 

                 if (lambat.isOn) 
                 {

                 if (jam24.isOn){
                 selisihSudut +=0.025f;// dapat dari: 1(hari) dibagi 40(frame)

                 langkahke +=1f;
                 sudutRotasi +=rotasiPenuh/40f;

                 }
                 else if (jam240.isOn){
                 selisihSudut +=0.25f;//10 (hari) dibagi 40;

                 langkahke +=1f;
                 sudutRotasi +=rotasiPenuh/40f;

                }

                 } 
                 
                 else if (cepat.isOn)
                 {

                 if (jam24.isOn){
                 selisihSudut +=0.1f;

                 langkahke +=4f;
                 sudutRotasi +=rotasiPenuh/10f;

                 }
                 else if (jam240.isOn){
                 selisihSudut +=1f;

                 langkahke +=4f;
                 sudutRotasi +=rotasiPenuh/10f;

                }  
                    }   

                DisableButton1.interactable = false; // set beberapa tombol menjadi gak aktif
                DisableButton2.interactable = false;
                DisableButton3.interactable = false;
                 
                 if (langkahke==40f) {
                     
                revolusiBool = false;
                DisableButton1.interactable = true;
                DisableButton2.interactable = true;
                DisableButton3.interactable = true;

                lambat.interactable = true; 
                cepat.interactable = true; 

                jam24.interactable = true; 
                jam240.interactable = true;    
                }

                pasakRevolusi.localEulerAngles  = new Vector3(0f, 0f, selisihSudut);
                bumi.localEulerAngles  = new Vector3(0f, 0f, sudutRotasi);

                text.text ="Sudut ke Tengah Hari : " +sudutRotasi+"\u00B0";
               
             }
         }

  public void satuSiderealday(){// fungsi ini diakses oleh clickbutton

        revolusiSidBool = true ;
        klikanKe +=1;
         
        if (jam24.isOn){
          
            panjangHari+=(float)0.982958333;// dapat dari: 360-(23d 56m 4.09s * 15)
            if (panjangHari>=360)panjangHari%=360;
            rotasiPenuh=360-(panjangHari);}

        else if (jam240.isOn){
            panjangHari+=(float)0.982958333*10;
        if (panjangHari>=360)panjangHari%=360;
        rotasiPenuh=360-(panjangHari);}

         StartCoroutine(RevolusiSideris());
    }

     IEnumerator RevolusiSideris ()
         { 

           float langkahke = 0;
          
            bayanganBumi.position = new Vector3(bumi.position.x,bumi.position.y,bumi.position.z+5f);
            sudutRotasiSid =0;
            float rotPenuhSid = rotasiPenuh;

            if (klikanKe>1 ){sudutRotasiSid =rotasiPenuh-360;
            rotPenuhSid =(rotasiPenuh+panjangHari);}

            bayanganBumi.rotation=bumi.rotation;
  
        while (revolusiSidBool)
        {
                yield return new WaitForSeconds (0.05f);
                lambat.interactable = false; 
                cepat.interactable = false; 
                jam24.interactable = false; 
                jam240.interactable = false; 
           
                 if (lambat.isOn) 
                 {
                    if (jam24.isOn){

                    selisihSudut +=0.024573958f;// ini semakin besar semakin cepat revolusinya
                    langkahke +=1f;
                    sudutRotasiSid +=rotPenuhSid/40f;
        
                     }
                      else if (jam240.isOn){

                    selisihSudut +=0.2465f;
                    langkahke +=1f;
                    sudutRotasiSid +=rotPenuhSid/40f;
           
                    }
                 } 
                 
                 else if (cepat.isOn)
                 { 
                   
                    if (jam24.isOn){

                    selisihSudut +=0.098295833f;
                    langkahke +=4;
                    sudutRotasiSid +=rotPenuhSid/10f;
        
                     }
                      else if (jam240.isOn){

                    selisihSudut +=0.986f;
                    langkahke +=4;
                    sudutRotasiSid +=rotPenuhSid/10f;
                    }
                 } 

                
                DisableButton1.interactable = false; // set beberapa tombol menjadi gak aktif
                DisableButton2.interactable = false;
                DisableButton3.interactable = false;
                 
                 if (langkahke==40f) {
                    
            
                revolusiSidBool = false;

                DisableButton1.interactable = true;
                DisableButton2.interactable = true;
                DisableButton3.interactable = true;
                
                lambat.interactable = true; 
                cepat.interactable = true; 

                jam24.interactable = true; 
                jam240.interactable = true; 
               
                }

            bumi.localEulerAngles  = new Vector3(0f, 0f, sudutRotasiSid);
            pasakRevolusi.localEulerAngles  = new Vector3(0f, 0f, selisihSudut%360);
                          
            int Deg=Konversi.DesimalKeDerajat(sudutRotasiSid)[1];
            int Men=Konversi.DesimalKeDerajat(sudutRotasiSid)[2];
            int Det=Konversi.DesimalKeDerajat(sudutRotasiSid)[3];
            string dms="Sudut ke Tengah Hari:\n"+Deg.ToString("D2")+"\u00B0"+ Men.ToString("D2") +"\u2032"+ Det.ToString("D2") +"\u2033"; // "D2" adalah string formatter agar angka dibawah 10 didepanya tetap ada nol : 09 bukan 9
         
            text.text =dms;        
        }
    }
}
