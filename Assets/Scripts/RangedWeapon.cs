using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedWeapon : MonoBehaviour
{
    public bool IsAvailable = true;
    public float Cooldown = 1f;
    Inventory InvScript;
    public GameObject Projectile;
    public float Force;
    // Start is called before the first frame update
    void Start()
    {
        InvScript = GameObject.Find("PlayerCanvas").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAvailable)
        {
            if(Input.GetButtonDown("Fire1") && InvScript.isOpen == false)
            {
                GameObject Proj = Instantiate(Projectile, transform.position, transform.rotation);
                Proj.GetComponent<Rigidbody2D>().AddRelativeForce(transform.forward * Force);
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
