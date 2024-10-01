using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;
using UnityEngine.AI;
using System;

public class Weapon : MonoBehaviour
{

    public List<Animation> Animations;
    public float BaseDamage;
    public List<BonusDamage> BonusDamageList;
    Inventory InvScript;
    int curAnim = 0;
    public bool IsAvailable = true;
    public float Cooldown = 0.85f;
    // Start is called before the first frame update

    [Serializable]
    public class BonusDamage
    {
        public string Name_of_Object;
        public float Percentage;
    }
    // Update is called once per frame
    void Start()
    {
        InvScript = GameObject.Find("PlayerCanvas").GetComponent<Inventory>();
    }
    void Update()
    {
        if (IsAvailable == true)
        {
            if (Input.GetButtonDown("Fire1") && InvScript.isOpen == false)
            {
                Animations[curAnim].Play();
                
                if (curAnim < Animations.Count - 1)
                {
                    curAnim++;
                }
                else
                {
                    curAnim = 0;
                }
                StartCoroutine(StartCooldown());
            }
            

        }
    }
    public IEnumerator StartCooldown()
    {
        IsAvailable = false;

        yield return new WaitForSeconds(Cooldown);

        IsAvailable = true;
    }


}

