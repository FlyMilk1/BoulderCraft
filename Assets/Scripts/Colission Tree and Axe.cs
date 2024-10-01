using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NavMeshPlus.Components;

public class ColissionTreeandAxe : MonoBehaviour
{
    
    public NavMeshModifier nm;
    public int TreeHealthMax = 125 ;
    float TreeHealth;
    Weapon WeaponScript;
    public GameObject Leaves;
    public bool  IsAvailable = true;
    public float Cooldown = 0.85f;
    float OverallDmg;
    // Start is called before the first frame update
    void Start()
    {   
        nm = gameObject.GetComponentInChildren<NavMeshModifier>();
        
        TreeHealth = TreeHealthMax;
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if(TreeHealth <= 0.7 * TreeHealthMax){
            Destroy(Leaves);
        }
        if(TreeHealth<=0){
            TreeHealth=0;
            
            Destroy(gameObject);
        }

    }
     
    void OnTriggerEnter2D(Collider2D Detection){
        if( IsAvailable == true){
            if(Detection.gameObject.tag == "Axe"){
             Debug.Log("Entered collision with " + Detection.gameObject.name);
             WeaponScript = Detection.gameObject.GetComponentInParent<Weapon>();
             OverallDmg = WeaponScript.BaseDamage;
            foreach(var Item in WeaponScript.BonusDamageList){
                if(Item.Name_of_Object == "Tree")
                    {
                        OverallDmg = WeaponScript.BaseDamage + WeaponScript.BaseDamage * (Item.Percentage / 100);
                    }
            }
             TreeHealth-=OverallDmg;
             Debug.Log(TreeHealth);
        }
         StartCoroutine(StartCooldown());
        }
    }
    public IEnumerator StartCooldown()
       {
        IsAvailable = false;

        yield return new WaitForSeconds(Cooldown);

        IsAvailable = true;
    }
}
