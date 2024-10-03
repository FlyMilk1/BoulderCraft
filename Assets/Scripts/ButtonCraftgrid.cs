using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCraftgrid : MonoBehaviour
{
    public void Press()
    {
        string[] Seperated = name.Split("/");
        int index = int.Parse(Seperated[1]);
        RecipeLoader rl = GameObject.Find("Crafting").GetComponent<RecipeLoader>();
        rl.ShowRecipe(index);
    }
}
