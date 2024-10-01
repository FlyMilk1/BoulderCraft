using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Slider HealthSlider;
    int Health;
    public int MaxHealth = 100;
    public bool IsAvailable = true;
    public float Cooldown = 0.85f;
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
            Destroy(HealthSlider.gameObject);
            Destroy(gameObject);
        }
    }
}
