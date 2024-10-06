using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public string ItemNameWithGI;
    public float MovePower = 100;
    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Random.insideUnitCircle * MovePower);
    }
    
   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            GameObject.Find("PlayerCanvas").GetComponent<Inventory>().FindFreeSlots(1, ItemNameWithGI);
            Destroy(gameObject);
        }
    }
}
