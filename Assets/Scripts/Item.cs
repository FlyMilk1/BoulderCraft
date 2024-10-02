using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;


public class Item : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    
    public Image ImageOBJ;
    public Image SlotImage;
    public TextMeshProUGUI ItemCount;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI Name;
    public Image SelectionSlot;
    public Sprite SelectionDefault;
    public Sprite SelectionSelected;
    bool Selected = false;
    public bool isEmpty = true;
    public int freeslots;
    public GameItem gi;
    public GameObject cursorfollow;
    public bool isHotBarLinked = false;
    public Image HotbarLinked;

    
    // Start is called before the first frame update
    private void Start()
    {
        SlotImage.color = new Color(SlotImage.color.r, SlotImage.color.g, SlotImage.color.b, 0);
        ImageOBJ.color = new Color(ImageOBJ.color.r, ImageOBJ.color.g, ImageOBJ.color.b, 0);
    }
    public void AddItem(int count)
    {
        if(gi != null)
        {
            
            SlotImage.color = new Color(SlotImage.color.r, SlotImage.color.g, SlotImage.color.b, 1);
            
            SlotImage.sprite = gi.SpiteIcon;
            PotentialUpdateHotbar(1);
            if (isEmpty)
            {
                freeslots = gi.StackSize;
                isEmpty = false;
            }
             freeslots -= count;
            ItemCount.text = (gi.StackSize - freeslots).ToString();
            if (gi.StackSize - freeslots <= 1)
            {
                ItemCount.text = string.Empty;
            }
        }
        
    }
    public void Clear()
    {
        gi = null;
        ImageOBJ.sprite = null;
        SlotImage.sprite = null;
        Text.text = null;
        Name.text = null;
        isEmpty = true;
        ImageOBJ.color = new Color(ImageOBJ.color.r, ImageOBJ.color.g, ImageOBJ.color.b, 0);
        SlotImage.color = new Color(SlotImage.color.r, SlotImage.color.g, SlotImage.color.b, 0);
        ItemCount.text = string.Empty;
        PotentialUpdateHotbar(0);

    }
    public void Select()
    {
        Selected = !Selected;
        if (Selected == true)
        {
            if (gi != null)
            {
                Text.text = gi.ItemInfo;
                Name.text = gi.ItemName;
                ImageOBJ.sprite = gi.SpiteIcon;
            }
            SelectionSlot.sprite = SelectionSelected;
            if (isEmpty == false)
            {
                ImageOBJ.color = new Color(ImageOBJ.color.r, ImageOBJ.color.g, ImageOBJ.color.b, 1);
            }
            
        }
        else
        {
            SelectionSlot.sprite = SelectionDefault;
            ImageOBJ.sprite = null;
            Text.text = null;
            Name.text = null;
            ImageOBJ.color = new Color(ImageOBJ.color.r, ImageOBJ.color.g, ImageOBJ.color.b, 0);
        }
        
    }
    void PotentialUpdateHotbar(int Transparent)
    {
        if (HotbarLinked)
        {
            HotbarLinked.sprite = SlotImage.sprite;
            HotbarLinked.color = new Color(HotbarLinked.color.r, HotbarLinked.color.g, HotbarLinked.color.b, Transparent);
        }
            
    }
    bool Drag = false;
    public void OnPointerDown(PointerEventData ped)
    {
        if (Input.GetMouseButtonDown(1))
        {
            cursorfollow.GetComponent<FollowCursor>().Downed(this);
            Debug.Log("PointerDown" + gameObject.name);
            Drag = true;
        }
        
    }
    public void OnPointerUp(PointerEventData ped)
    {
       
            if (Drag)
            {
                Debug.Log("PointerUpped" + gameObject.name);
                cursorfollow.GetComponent<FollowCursor>().Upped(this);
            }
        
        
    }
    public void UpdateIcon(GameItem githis, Item newItem)
    {
        gi = githis;
        if (SlotImage != null)
        {
            Debug.Log("works");
        }
        if (gi != null)
        {
            Debug.Log("works2");
        }
        Debug.Log(gameObject.name + newItem.gameObject.name);
        newItem.SlotImage.sprite = gi.SpiteIcon;
        newItem.SlotImage.color = new Color(SlotImage.color.r, SlotImage.color.g, SlotImage.color.b, 1);
    }
    void Update()
    {
        if (Mathf.Abs(cursorfollow.transform.position.x - gameObject.transform.position.x)<=63 && Mathf.Abs(cursorfollow.transform.position.y - gameObject.transform.position.y) <= 63)
        {
            cursorfollow.GetComponent<FollowCursor>().Hovered = this;
        }
    }



}
