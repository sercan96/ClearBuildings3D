using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    // Addforce ile hareket
    // Velocity ile hareket
    // transform.Translate ile hareket
    // transform.position ile hareket
    Rigidbody rb;
    [SerializeField] int speed;
    void Start()
    {
        rb =GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        MovementWithTranslate();
        //MovementWithVelocity();
        //MovementWithAddForce();
        //MovementPosition();
    }
    void MovementWithTranslate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed); // transform globale bakar.
    }
    void MovementWithVelocity()
    {
        rb.velocity = transform.up * Time.deltaTime * speed; // transform locale bakar
    }
    void MovementWithAddForce()
    {
        rb.AddForce(transform.up * Time.deltaTime * speed,ForceMode.VelocityChange);
    }
    void MovementPosition()
    {
        transform.position += transform.up * Time.deltaTime * speed; // local y açısı
    }

}
