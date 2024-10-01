using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavMeshPlus.Components;
public class ResourseGeneration : MonoBehaviour
{
    public GameObject TreePrefab;
    public int XMapSize;
    public int YMapSize;
    int Ax;
    int Ay;
    public int SpawnRate;
    public NavMeshSurface ns;
    public bool IsBaked = false;

    void Start()
    {
       
        for (int i = 0; i <= SpawnRate; i++){
             System.Random r = new System.Random();
        Ax = r.Next(0, XMapSize);
        if (YMapSize < 0){
            Ay = r.Next(YMapSize, 0);
        }
        else{
            Ay = r.Next(1, YMapSize);
        }
                
            Instantiate(TreePrefab, new Vector2(Ax, Ay), Quaternion.identity);
        }
        ns = GameObject.Find("Navigation").GetComponent<NavMeshSurface>();
        ns.BuildNavMesh();
        IsBaked = true;
        
    }

    void Update()
    {
        
    }
}
