using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiToggle : MonoBehaviour
{
    public GameObject UI;
   public void OnMouseDown()
    {
        UI.SetActive(!UI.activeSelf);
        
    }
    private void Update()
    {
        if(UI.activeSelf)
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                UI.SetActive(false);
                
            }
        }
    }
}
