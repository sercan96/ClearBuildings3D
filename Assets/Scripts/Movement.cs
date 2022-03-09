using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float speed =5f;
    [SerializeField]
    float jumpPower = 13f;
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
            rb.velocity = new Vector3(rb.velocity.x,Mathf.Clamp((jumpPower * 100) * Time.deltaTime,0f,15f),0f);    
            Debug.Log("Jump");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            // transform.Rotate(0f,-180f,0f); Her A ya basılı tuttuğumuzda y eksenine -180 ekleyecek. bu yüzden rotation kullandık eşitleme ile.
            transform.rotation = Quaternion.Euler(0f,-180f,0f);
            rb.velocity = new Vector3(Mathf.Clamp((-speed *100) * Time.deltaTime,-15f,0f),rb.velocity.y,0f);
            Debug.Log("Left");
        }
        else if(Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f,0f,0f);
            rb.velocity = new Vector3(Mathf.Clamp((speed *100) * Time.deltaTime,0f,15f),rb.velocity.y,0f);
            Debug.Log("Right");
        }
        else
        {
            rb.velocity = new Vector3(0f,rb.velocity.y,0f);
        }
    }
}
