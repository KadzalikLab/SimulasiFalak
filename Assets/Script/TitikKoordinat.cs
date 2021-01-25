using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitikKoordinat : MonoBehaviour
{
    public Transform TitikKoor;
    public Transform TitikLineLintang;// sebuah titik  yang bergerak hanya pada garis lintang
    public Transform TitikLineBujur;// sebuah titik yang bergerak hanya pada garis bujur
    public Text textNilaiL;
    public Text textNilaiB;

    public InputField degL;
    public InputField minL;
    public InputField secL;

    public InputField degB;
    public InputField minB;
    public InputField secB;


    // Update is called once per frame
    void Update()
    {

        float PosisiLintang=TitikKoor.localPosition.x;
        float PosisiBujur=TitikKoor.localPosition.y;

        TitikLineLintang.localPosition=new Vector3(PosisiLintang,0,-1);
        TitikLineBujur.localPosition=new Vector3(0,PosisiBujur,-1);

        float nilaiLintang =(PosisiBujur/1350)*90; // 1350 dapat dari tinggi texture peta bumi. 90 adalah nilai maksimal lintang
        if (nilaiLintang>90)nilaiLintang=-nilaiLintang%90;
        else if(nilaiLintang<-90)nilaiLintang=Mathf.Abs(nilaiLintang%90);
        
        float nilaiBujur =(PosisiLintang/2700)*180;//2700 dapat dari lebar texture peta bumi. 180 adalah nilai maksimal bujur


        int derajatL = Konversi.DesimalKeDerajat(nilaiLintang)[1];
        int menitL = Konversi.DesimalKeDerajat(nilaiLintang)[2];
        int detikL = Konversi.DesimalKeDerajat(nilaiLintang)[3];

        int derajatB = Konversi.DesimalKeDerajat(nilaiBujur)[1];
        int menitB = Konversi.DesimalKeDerajat(nilaiBujur)[2];
        int detikB = Konversi.DesimalKeDerajat(nilaiBujur)[3];


        string nilaiL="Lintang: "+derajatL.ToString("D2")+"\u00B0 "+ menitL.ToString("D2") +"\u2032 "+detikL.ToString("D2")+"\u2033";
        textNilaiL.text=nilaiL;

        string nilaiB="Bujur: "+derajatB.ToString("D2")+"\u00B0 "+ menitB.ToString("D2") +"\u2032 "+detikB.ToString("D2")+"\u2033";
        textNilaiB.text=nilaiB;


        
    }

    public void AmbilNilai(){
        // cek null atau tidak
    if (degL.text=="")degL.text="0";
    if (minL.text=="")minL.text="0";
    if (secL.text=="")secL.text="0";
        
    if (degB.text=="")degB.text="0";
    if (minB.text=="")minB.text="0";
    if (secB.text=="")secB.text="0";
        
    float nilaiInputL=(float)Konversi.DerajatKeDesimal(double.Parse(degL.text),double.Parse(minL.text),double.Parse(secL.text));   
    float nilaiInputB=(float)Konversi.DerajatKeDesimal(double.Parse(degB.text),double.Parse(minB.text),double.Parse(secB.text));
   
       
    float posisiX=(nilaiInputL/180)*2700;
    float posisiY=(nilaiInputB/90)*1350;

    TitikKoor.transform.localPosition=new Vector3(posisiY,posisiX,-1);

    }
}
