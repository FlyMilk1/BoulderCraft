using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RecipeLoader : MonoBehaviour
{
    AssetBundle RecipeBundle;
    public GameObject CraftButton;
    public GameObject CraftSort;
    public GameObject CraftReqs;
    public GameObject CraftDesc;

    public Inventory Inventory;
    CraftingRecipe[] CraftingRecipes;
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
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
