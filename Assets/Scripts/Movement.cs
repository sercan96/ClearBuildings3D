using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float speed =5;
    void Start()
    {
         rb = GetComponent<Rigidbody>(); // Yeni bir rigidbody oluşturduk new leme işlemi
    }

    
    void Update()
    {
        TakeInput();
    }
    void TakeInput()  
    {
        //transform.Translate(Vector3.forward);
        // transform.Translate(transform.forward);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(rb.velocity.x,(speed * 100) * Time.deltaTime,0f);    
            Debug.Log("Jump");
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector3((-speed *100) * Time.deltaTime,rb.velocity.y,0f);
            Debug.Log("Left");
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector3(0f,rb.velocity.y,(speed *100) * Time.deltaTime);
            Debug.Log("Right");
        }
    }
}
