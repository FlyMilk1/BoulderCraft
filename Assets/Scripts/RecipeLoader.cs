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
   
    public Inventory Inventory;
    CraftingRecipe[] CraftingRecipes;
    // Start is called before the first frame update
    void Start()
    {
        RecipeBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath + "/GameItemsFolder/craftingrecipes");
        CraftingRecipes = RecipeBundle.LoadAllAssets<CraftingRecipe>();
        Debug.Log("Loaded "+ CraftingRecipes.Length.ToString()+" recipes");
        for (int i = 0; i < CraftingRecipes.Length; i++)
        {
            
            GameItem gi = Inventory.GetGameItem(CraftingRecipes[i].Results[0].Item);
            
            
            
            GameObject CR = Instantiate(CraftButton, CraftSort.transform);
           // Debug.Log(CR.transform.childCount);
            CR.GetComponentInChildren<TextMeshProUGUI>().text = gi.ItemName;
            CR.transform.Find("Image").GetComponent<Image>().sprite = gi.SpiteIcon;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
