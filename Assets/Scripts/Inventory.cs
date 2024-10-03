using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public class Inventory : MonoBehaviour
{
    public GameObject InventoryObj;
    public bool isOpen = false;
    public bool isEnteringACommand = false;
    public AssetBundle gabi;
    Item curItem;
    public GameObject SortGO;
    void Start()
    {
        gabi = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/GameItemsFolder/gameitems");
    }
    void Update()
    {
        if (isOpen && isEnteringACommand == false)
        {
            InventoryObj.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            InventoryObj.transform.localScale = new Vector3(0, 0, 0);
        }

        
        
        if (Input.GetButtonDown("OpenCloseInventory") && isOpen == false)
        {
            isOpen = true;
        }
        else if ((Input.GetButtonDown("OpenCloseInventory") || Input.GetButtonDown("Cancel")) && isOpen == true)
        {
            isOpen = false;
        }
    }
    public GameItem GetGameItem(string Name)
    {
        GameItem gi = gabi.LoadAsset<GameItem>(Name);
        return gi;
    }
    public void Search()
    {
        List<Item> FoundItems;
        for(int i=0; i < SortGO.transform.childCount; i++)
        {
            FoundItems.Append<Item>(GameObject.Find("Item" + " (" + i + ")").GetComponent<Item>());
        }
    }
    public void FindFreeSlots(int count, string ItemName, int i = 0)
    {
        for(; i < SortGO.transform.childCount; i++)
        {           
            curItem = GameObject.Find("Item" + " (" + i + ")").GetComponent<Item>();
            if (curItem.freeslots > 0 || curItem.isEmpty)
            {   
                if(curItem.isEmpty == false)
                {

                    if(curItem.gi.ItemName.Replace(" ", string.Empty) == ItemName.Remove(ItemName.Length - 2))
                    {
                        curItem.gi = (GameItem)gabi.LoadAsset(ItemName);                       
                    }
                    else
                    {
                        continue;                        
                    }
                }
                else
                {
                    curItem.gi = (GameItem)gabi.LoadAsset(ItemName);
                }
                
                
                if (count > curItem.freeslots && curItem.isEmpty == false)
                {                     
                    count -= curItem.freeslots;
                    curItem.AddItem(curItem.freeslots);
                    continue;
                }
                else
                {                                       
                    if (count > curItem.gi.StackSize)
                    {
                        count -= curItem.gi.StackSize;
                        curItem.AddItem(curItem.gi.StackSize); 
                        continue;
                    }
                    else
                    {             
                        curItem.AddItem(count);
                        break;
                    }
                    
                }
                
            }
        }
    }
}
