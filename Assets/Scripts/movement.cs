using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
        public Vector2 speed = new Vector2(50, 50);
    Inventory InvScript;


    void Start()
    {
        InvScript = GameObject.Find("PlayerCanvas").GetComponent<Inventory>();
    }
    // Update is called once per frame
    void Update()
    {
        if (InvScript.isOpen == false)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(speed.x * inputX, speed.y * inputY, 0);

            movement *= Time.deltaTime;

            transform.Translate(movement);
        }
        
    }

}
