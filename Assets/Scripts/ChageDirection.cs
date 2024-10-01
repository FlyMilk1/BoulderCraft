using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") == 0){
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -90);
      }  
      else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") == 0){
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 90);
      }  
      else if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0){
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 0);
      }  
      else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0){
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 180);
      }  
      else if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0){
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -45);
      }  
      else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0){
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 45);
      }  
      else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") > 0){
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, -135);
      }  
      else if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0){
        gameObject.transform.eulerAngles = new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, 135);
      }  
      
    }
}
