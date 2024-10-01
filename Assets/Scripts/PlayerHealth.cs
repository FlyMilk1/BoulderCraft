using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider HealthSlider;
    int Health;
    public int MaxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    public void Damage(int damage)
    {
        Health-=damage;
        HealthSlider.value = Health;
    }
}
