using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetInput : MonoBehaviour
{
    public InputField nilaiDerajat;
    public InputField nilaiMenit;


    public GameObject Syakul;
   

    public void AmbilNilai(){


    float nilaiInput=(float)Konversi.DerajatKeDesimal(double.Parse(nilaiDerajat.text),double.Parse(nilaiMenit.text),0);
      

       

float nilaiX=(Mathf.Sin(nilaiInput*Mathf.Deg2Rad));
float nilaiy=(Mathf.Cos(nilaiInput*Mathf.Deg2Rad));

float posisiX=27.1674f-(nilaiX*80);
float posisiY=27.2406f-(nilaiy*80);
Syakul.transform.localPosition=new Vector3(posisiX,posisiY,0);


    }


}
