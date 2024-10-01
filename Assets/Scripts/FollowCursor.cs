using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class FollowCursor : MonoBehaviour
{
    Image cursorimg;
    Item currentItem;
    Inventory inv;
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (collision.gameObject.name.Contains("Item"))
            {
                currentItem = collision.gameObject.GetComponent<Item>();
                if (currentItem.isEmpty == false)
                {
                    cursorimg.sprite = currentItem.gi.SpiteIcon;

                }

                Debug.Log(gameObject.name);
            }

        }
        Debug.Log("ap");
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("aa");
            if (collision.gameObject.name.Contains("Item"))
            {
                Debug.Log("o");
                if (currentItem.gameObject != collision.gameObject && collision.gameObject.GetComponent<Item>().isEmpty == false)
                {
                    collision.gameObject.GetComponent<Item>().gi = currentItem.gi;
                    currentItem.gi = null;

                }
            }
        }

    }


    // Update is called once per frame
    void Start()
    {
        cursorimg = gameObject.GetComponentInChildren<Image>();
        inv = GameObject.Find("PlayerCanvas").GetComponent<Inventory>();

    }
    private void Update()
    {
        gameObject.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 5.13f);
    }
    public void Downed(Item item)
    {
        currentItem = item;
        if (currentItem.isEmpty == false)
        {
            cursorimg.sprite = currentItem.gi.SpiteIcon;
            cursorimg.color = new Color(cursorimg.color.r, cursorimg.color.g, cursorimg.color.b, 1);


        }

        Debug.Log(gameObject.name);
    }
    public Item Hovered;
    public void Upped(Item item)
    {
        
        
        Debug.Log(Hovered.gameObject.name +" <--This One");
        Debug.Log(currentItem.gameObject.name + " <--NOT This One");
        if (currentItem.gi != null)
        {
            Debug.Log("works3");
        }
        int ItemN;
        string CurItemN = string.Empty;
        
        for (int i = 0; i < Hovered.gameObject.name.Length; i++)
        {
            if (System.Char.IsDigit(Hovered.gameObject.name[i]))
            {
                CurItemN += Hovered.gameObject.name[i];
            }

        }
        
        int.TryParse(CurItemN, out ItemN);
        
        item.gi.ItemName = item.gi.ItemName.Replace(" ", string.Empty);
        
       
        inv.FindFreeSlots(currentItem.gi.StackSize - currentItem.freeslots, item.gi.ItemName + "GI", ItemN);

        //item.UpdateIcon(currentItem.gi, item);
        currentItem.Clear();
        cursorimg.color = new Color(cursorimg.color.r, cursorimg.color.g, cursorimg.color.b, 0);

    }
    
}
