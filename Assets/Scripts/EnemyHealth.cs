using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ResourceMine;

public class EnemyHealth : MonoBehaviour
{
    public Slider HealthSlider;
    int Health;
    public int MaxHealth = 100;
    public bool IsAvailable = true;
    public float Cooldown = 0.85f;
    public ItemDropParms[] ItemDrops;
    public GameObject ItemDropPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    void OnTriggerEnter2D(Collider2D Detection)
    {
        if (IsAvailable == true)
        {
            if (Detection.gameObject.tag == "Axe")
            {
                Debug.Log("Entered collision with " + Detection.gameObject.name);
                DamageEnemy(15);
                
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
    // Update is called once per frame
    public void DamageEnemy(int damage)
    {
        Health -= damage;
        HealthSlider.value = Health;
        if (Health <= 0)
        {
            foreach (var item in ItemDrops)
            {
                int r = Random.Range(item.MinCount, item.MaxCount + 1);
                for (int i = 0; i < r; i++)
                {
                    GameObject CurItemDrop = Instantiate(ItemDropPrefab, transform.position, transform.rotation);
                    CurItemDrop.GetComponent<ItemDrop>().ItemNameWithGI = item.ItemNameWithGI;
                    CurItemDrop.GetComponent<SpriteRenderer>().sprite = item.ItemSprite;
                }

            }
            Destroy(HealthSlider.gameObject);
            Destroy(gameObject);
        }
    }
}
