using UnityEngine;
using UnityEngine.SceneManagement;

public class tombolKembali : MonoBehaviour {

 public void MenuUtama() {
		SceneManager.LoadScene("MenuAwal");
				    if (Input.GetKey(KeyCode.Escape))
    {
    SceneManager.LoadScene("MenuAwal");
    }
 }
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKey(KeyCode.Escape))
    {SceneManager.LoadScene("MenuAwal");}
		
	}
}
