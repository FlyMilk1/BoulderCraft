using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Commands : MonoBehaviour
{
    public TMP_InputField comtext;
    string comtexts;
    public GameObject CommandObj;
    public Inventory inv;
    bool isEntering;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.Find("PlayerCanvas").GetComponent<Inventory>();
        CommandObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("/"))
        {
            CommandObj.SetActive(true);
            comtext.text = "/";
            isEntering = true;
            inv.isEnteringACommand = true;

           
            comtext.ActivateInputField();
            comtext.Select();
            StartCoroutine(MoveTextEnd_NextFrame());


        }
        if (Input.GetButtonDown("Submit") && isEntering)
        {
            if (comtext.text.StartsWith("/give")){
                Debug.Log("Detected a give");
                string NameItem;
                int ItemCount;
                string CurDig = string.Empty;
                comtexts = comtext.text;
                for (int i=0; i < comtexts.Length; i++)
                {
                    if (System.Char.IsDigit(comtexts[i]))
                    {
                        CurDig += comtexts[i];
                    }
                        
                }
                int.TryParse(CurDig, out ItemCount);
                comtexts = comtexts.Remove(comtexts.Length - (CurDig.Length+1));
                NameItem = comtexts.Substring(6) + "GI";
                Debug.Log(NameItem);
                Debug.Log(ItemCount);
                inv.FindFreeSlots(ItemCount, NameItem);
                comtext.text = string.Empty;
                isEntering = false;
                inv.isEnteringACommand = false;
                CommandObj.SetActive(false);



            }
        }
    }
    IEnumerator MoveTextEnd_NextFrame()
    {
        yield return 0;
        comtext.MoveTextEnd(false);
    }
}
