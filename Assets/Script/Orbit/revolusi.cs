using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class revolusi : MonoBehaviour {
public RectTransform Pasak;
  private float nilaiRevolusi;
      public Text txt;
      private double tanggalPercepat;
      public double kecepatan;
      public Transform RotasiBumi;
  

	void Start () {  	   
		
	}
	
	// Update is called once per frame
void Update(){

           Double tanggal,bulan,tahun,jam,menit,detik;
           //jam=DateTime.Now.ToString("HH:mm:ss tt");

            tanggal=Convert.ToDouble(DateTime.Now.ToString("dd"));
            bulan=Convert.ToDouble(DateTime.Now.ToString("MM"));
            tahun=Convert.ToDouble(DateTime.Now.ToString("yyyy"));

            jam=Convert.ToDouble(DateTime.Now.ToString("HH"));
            menit=Convert.ToDouble(DateTime.Now.ToString("mm"));
            detik=Convert.ToDouble(DateTime.Now.ToString("ss"));
            
            double jd=Konversi.TanggalKeJulianDay(tahun,bulan,tanggal,jam,menit,detik);
            double bujur_m,lintang_m,jarakBm_M;

            bujur_m=hisabEp.Meeus(jd)[1];
			      lintang_m=hisabEp.Meeus(jd)[2];
		      	jarakBm_M=hisabEp.Meeus(jd)[8];

	         nilaiRevolusi=(float)bujur_m;
             Pasak.localEulerAngles=new Vector3(0,nilaiRevolusi,0);

               var today = System.DateTime.Now;
               int degBujur=Konversi.DesimalKeDerajat(bujur_m)[1];
               int degMen=Konversi.DesimalKeDerajat(bujur_m)[2];
               int degDet=Konversi.DesimalKeDerajat(bujur_m)[3];
               string dms=degBujur.ToString("D2")+"\u00B0 "+ degMen.ToString("D2") +"\u2032  "+ degDet.ToString("D2") +"\u2033  ";
                 
         txt.text = "Ecliptic Longitude: " +dms +" | " +  today.ToString("yyyy-MM-dd    HH : mm : ss,ff");
            
      }



}
