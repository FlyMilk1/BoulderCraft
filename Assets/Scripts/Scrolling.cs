using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public int scrollN = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollN < 4 && scrollN > 0)
        {
            scrollN += (int)Input.GetAxis("Mouse ScrollWheel");
        }
        else if(scrollN > 0)
        {
            Debug.Log((int)Input.GetAxis("Mouse ScrollWheel"));
            if ((int)Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                scrollN = 0;
            }
            else
            {
                scrollN += (int)Input.GetAxis("Mouse ScrollWheel");
            }
        }
        else
        {
            Debug.Log((int)Input.GetAxis("Mouse ScrollWheel"));
            if ((int)Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                scrollN = 4;
            }
            else
            {
                scrollN += (int)Input.GetAxis("Mouse ScrollWheel");
            }
        }
        
        
    }
}
