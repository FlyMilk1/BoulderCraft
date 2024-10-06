using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static Inventory;
using System.Linq;


public class RecipeLoader : MonoBehaviour
{
    AssetBundle RecipeBundle;
    public GameObject CraftButton;
    public GameObject CraftSort;
    public GameObject CraftReqs;
    public GameObject CraftDesc;
    public Button CButton;

    public Inventory Inventory;
    CraftingRecipe[] CraftingRecipes;
    int CurrentIndex;
    // Start is called before the first frame update
    public void Start()
    {
        RecipeBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/GameItemsFolder/craftingrecipes");
        CraftingRecipes = RecipeBundle.LoadAllAssets<CraftingRecipe>();
        Debug.Log("Loaded " + CraftingRecipes.Length.ToString() + " recipes");
        for (int i = 0; i < CraftingRecipes.Length; i++)
        {

            GameItem gi = Inventory.GetGameItem(CraftingRecipes[i].Results[0].Item);



            GameObject CR = Instantiate(CraftButton, CraftSort.transform);
            // Debug.Log(CR.transform.childCount);
            CR.name = CR.name +"/"+ i.ToString();
            CR.GetComponentInChildren<TextMeshProUGUI>().text = gi.ItemName;
            CR.transform.Find("Image").GetComponent<Image>().sprite = gi.SpiteIcon;
            CR.transform.Find("Image").GetComponent<Image>().preserveAspect = true;


        }
    }
    public void ShowRecipe(int index)
    {
        CurrentIndex = index;
       foreach(Transform child in CraftReqs.transform)
        {
            Destroy(child.gameObject);
        }
        for(int i = 0; i < CraftingRecipes[index].Required.Length; i++)
        {
            GameObject Desc = Instantiate(CraftDesc, CraftReqs.transform);
            GameItem GI = Inventory.GetGameItem(CraftingRecipes[index].Required[i].Item);
            Desc.GetComponentInChildren<TextMeshProUGUI>().text = GI.ItemName + " " + CraftingRecipes[index].Required[i].Count.ToString();
            Desc.GetComponentInChildren<Image>().sprite = GI.SpiteIcon;
        }
        UseResourses(true);
        
    }
    public void UseResourses(bool IsCheck)
    {
        bool[] CheckBoolList = new bool[CraftingRecipes[CurrentIndex].Required.Length];
        for(int i = 0; i < CraftingRecipes[CurrentIndex].Required.Length; i++)
        {
            CheckBoolList[i] = false;
        }
        for(int i = 0; i<CraftingRecipes[CurrentIndex].Required.Length; i++)
        {
            int Left = CraftingRecipes[CurrentIndex].Required[i].Count;
            GIAndCount[] gis = Inventory.Search(CraftingRecipes[CurrentIndex].Required[i].Item);
            for (int j = 0; j < gis.Length-1; j++)
            {
                if (gis[j+1].Count < gis[j].Count)
                {
                    GIAndCount tmp = gis[j+1];
                    gis[j+1] = gis[j];
                    gis[j] = tmp;
                }
            }
            Debug.Log("Sorted GI List"+gis.Length.ToString());
            
            for (int  j = 0; j < gis.Length; j++)
            {

                Item item = GameObject.Find("Item" + " (" + gis[j].Slot + ")").GetComponent<Item>();
                Debug.Log("Found Item: " + "Item" + " (" + gis[j].Slot + ")");
                
                int sum = 0;
                for (int k = 0; k < gis.Length; k++) {
                    sum += gis[k].Count;
                    
                }
                Debug.Log(sum + "sum");
                if (sum >= Left)
                {
                    CheckBoolList[i] = true;
                }
                if (sum >= Left && IsCheck==false)
                {
                    

                    Debug.Log(Left + " Left");
                        if ((gis[j].GI.StackSize - item.freeslots) > Left)
                        {
                            item.freeslots += Left;
                            Left = 0;
                            item.ItemCount.text = (gis[j].GI.StackSize - item.freeslots).ToString();
                            Debug.Log("BiggerCalc");
                            
                        }
                        if ((gis[j].GI.StackSize - item.freeslots) < Left)
                        {
                            Left -= (gis[j].GI.StackSize - item.freeslots);

                            item.Clear();
                            //item.ItemCount.text = (gis[j].GI.StackSize - item.freeslots).ToString();
                            Debug.Log("SmallerCalc");


                        }
                        if ((gis[j].GI.StackSize - item.freeslots) == Left)
                        {
                            Left -= (gis[j].GI.StackSize - item.freeslots);

                            item.Clear();
                            //item.ItemCount.text = (gis[j].GI.StackSize - item.freeslots).ToString();
                            Debug.Log("EqualCalc");
                            


                        }
                    
                        
                }
                

                
            }


        }
        
        bool AndCheck = true;
        foreach (bool Check in CheckBoolList)
        {
            if (Check==false)
            {
                AndCheck = false;
            }
        }
        if(AndCheck)
        {
            CButton.interactable = true;
        }
        else
        {
            CButton.interactable = false;
        }
        if (IsCheck == false)
        {
            for (int y = 0; y < CraftingRecipes[CurrentIndex].Results.Length; y++)
            {
                Inventory.FindFreeSlots(CraftingRecipes[CurrentIndex].Results[y].Count, CraftingRecipes[CurrentIndex].Results[y].Item);

            }
            UseResourses(true);
        }




    }
   
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
