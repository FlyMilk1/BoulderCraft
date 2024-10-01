using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorToggle : MonoBehaviour
{
    public GameObject[] InfoObjs;
    public GameObject[] ArmObjs;
    public Image SelectionSlot;
    public Sprite SelectionDefault;
    public Sprite SelectionSelected;
    bool Selected = false;
    public void Select()
    {
        Selected = !Selected;
        if (Selected == true)
        {
            SelectionSlot.sprite = SelectionSelected;
            foreach (GameObject go in ArmObjs)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in InfoObjs)
            {
                go.SetActive(false);
            }
           
        }
        else
        {
            SelectionSlot.sprite = SelectionDefault;
            foreach (GameObject go in ArmObjs)
            {
                go.SetActive(false);
            }
            foreach (GameObject go in InfoObjs)
            {
                go.SetActive(true);
            }
        }
    }
}
