using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.CompilerServices;

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
    public struct GIAndCount
    {
        public int Count;
        public GameItem GI;
        public int Slot;
    }
    public GIAndCount[] Search(string Name)
    {
        List<Item> FoundItems = new List<Item>();
        List<GIAndCount> WantedItems = new List<GIAndCount>();
        for(int i=0; i < SortGO.transform.childCount; i++)
        {
            FoundItems.Add(GameObject.Find("Item" + " (" + i + ")").GetComponent<Item>());
        }
        foreach (Item item in FoundItems)
        {
            if(item.gi != null)
            {
                if(item.gi.name == Name)
                {
                    GIAndCount gic;
                    gic.Count = item.gi.StackSize - item.freeslots;
                    gic.GI = item.gi;
                    gic.Slot = FoundItems.IndexOf(item);
                    WantedItems.Add(gic);
                    Debug.Log("added to list gic");
                }
            }
        }
        return WantedItems.ToArray();
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
