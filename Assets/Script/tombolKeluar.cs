using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tombolKeluar : MonoBehaviour {

 public void KeluarAplikasi() {
     Application.Quit();
	 Debug.Log("Game is exiting");
 }
}
