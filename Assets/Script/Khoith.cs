using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kodingan ini merender/membut benang antara 2 point
//script ini bisa ditempelkan pada gameobject manapun

public class Khoith : MonoBehaviour
{
    private LineRenderer lr;// game object yang terdapat script LineRenderer didalamnya
    public Transform[] points;//akan menggambar garis di antara minimal 2 game object kosong
    // Start is called before the first frame update
    void Start()
    {
        lr= GetComponent<LineRenderer>();
       
        
    }
     public void SetUpLine(Transform[]points){
        lr.positionCount=points.Length;
        this.points=points;
    }

    // Update is called once per frames
    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i,points[i].position);
        }
        
    }
}
