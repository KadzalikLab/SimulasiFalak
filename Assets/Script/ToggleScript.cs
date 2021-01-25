using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleScript : MonoBehaviour
{

    public GameObject []Object;
    // Start is called before the first frame update
    public void Toggle(bool value)
    {

         for (int i = 0; i < Object.Length; i++)
        {
            Object[i].SetActive( value ) ;
        }
        
    }


}
