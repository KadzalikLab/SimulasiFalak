using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
public GameObject panel; // drop the panel in the editor

public void onAdvancedClicked()
{
   panel.SetActive(!panel.activeSelf); // make it active/inactive with one click
}

}
