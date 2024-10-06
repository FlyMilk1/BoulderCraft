using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NavMeshPlus.Components;

public class ResourceMine : MonoBehaviour
{
    
    public NavMeshModifier nm;
    public int HealthMax = 125 ;
    float Health;
    Weapon WeaponScript;
    public GameObject Leaves;
    public bool  IsAvailable = true;
    public float Cooldown = 0.85f;
    float OverallDmg;
    public string ResourceVulnerability = "Tree";
    
    public ItemDropParms[] ItemDrops;
    public GameObject ItemDropPrefab;

    
    // Start is called before the first frame update
    void Start()
    {   
        nm = gameObject.GetComponentInChildren<NavMeshModifier>();
        
        Health = HealthMax;
        
    }
    [System.Serializable]
    public struct ItemDropParms
    {
        public Sprite ItemSprite;
        public string ItemNameWithGI;
        public int MinCount, MaxCount;

    }
    // Update is called once per frame
    void Update()
    {
        
        if(Health <= 0.7 * HealthMax){
            Destroy(Leaves);
        }
        if(Health<=0){
            Health=0;
            
            
            foreach(var item in ItemDrops)
            {
                int r = Random.Range(item.MinCount, item.MaxCount+1);
                for(int i = 0; i<r; i++)
                {
                    GameObject CurItemDrop = Instantiate(ItemDropPrefab, transform.position, transform.rotation);
                    CurItemDrop.GetComponent<ItemDrop>().ItemNameWithGI = item.ItemNameWithGI;
                    CurItemDrop.GetComponent<SpriteRenderer>().sprite = item.ItemSprite;
                }
                
            }
            Destroy(gameObject);
        }

    }
     
    void OnTriggerEnter2D(Collider2D Detection){
        if( IsAvailable == true){
            if(Detection.gameObject.tag == "Axe"){
             //Debug.Log("Entered collision with " + Detection.gameObject.name);
             WeaponScript = Detection.gameObject.GetComponentInParent<Weapon>();
             OverallDmg = WeaponScript.BaseDamage;
            foreach(var Item in WeaponScript.BonusDamageList){
                if(Item.Name_of_Object == ResourceVulnerability)
                    {
                        OverallDmg = WeaponScript.BaseDamage + WeaponScript.BaseDamage * (Item.Percentage / 100);
                    }
            }
             Health-=OverallDmg;
             Debug.Log(Health);
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
