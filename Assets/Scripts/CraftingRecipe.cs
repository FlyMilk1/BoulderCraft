using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "CraftingRecipe", menuName = "ScriptableObjects/CraftingRecipeScriptableObj", order = 2)]
public class CraftingRecipe : ScriptableObject
{
    [System.Serializable]
    public struct Requirement
    {
        public GameItem Item;
        public int Count;
    }
    public struct Result
    {
        public GameItem Item;
        public int Count;
    }

    public Requirement[] Required;
    public Result[] Results;
}
