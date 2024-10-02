using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarSelect : MonoBehaviour
{
    public List<GameObject> HotBarSlots;
    public GameObject SelectImage;
    public GameObject Mount;
    // Start is called before the first frame update
    void Start()
    {
        //UpdateHotbar(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            UpdateHotbar(0);
        }
        if (Input.GetKeyDown("2"))
        {
            UpdateHotbar(1);
        }
        if (Input.GetKeyDown("3"))
        {
            UpdateHotbar(2);
        }
        if (Input.GetKeyDown("4"))
        {
            UpdateHotbar(3);
        }
        if (Input.GetKeyDown("5"))
        {
            UpdateHotbar(4);
        }
    }
    void UpdateHotbar(int slot)
    {
        int Slot = slot;
        Item item = GameObject.Find("Item ("+slot.ToString()+")").GetComponent<Item>();
        
        SelectImage.transform.position = HotBarSlots[slot].transform.position;
        if(Mount.transform.childCount != 0)
        {
            Destroy(Mount.transform.GetChild(0).gameObject);
        }
            
        
        
        GameObject go = Instantiate(item.gi.Prefab, Mount.transform);
        go.transform.position = Mount.transform.position;
        //go.transform.rotation = Mount.transform.rotation;
    }
}
