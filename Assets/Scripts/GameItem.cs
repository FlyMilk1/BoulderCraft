using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "GameItem", menuName = "ScriptableObjects/GameItemScriptableObj", order = 1)]
public class GameItem : ScriptableObject
{
    public GameObject Prefab;
    public Sprite SpiteIcon;
    public string ItemInfo;
    public string ItemName;
    public int StackSize;
   
}
