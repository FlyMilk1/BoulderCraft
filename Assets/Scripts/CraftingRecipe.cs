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
        public string Item;
        public int Count;
    }
    [System.Serializable]
    public struct Result
    {
        public string Item;
        public int Count;
    }

    public Requirement[] Required;
    public Result[] Results;
}
