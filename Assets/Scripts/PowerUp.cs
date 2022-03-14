using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
   [SerializeField] int  healthAmount = 5;
   private int turnspeed =5;
    void Start()
    {
        
    } 
    void Update()
    {
        transform.Rotate(turnspeed,0,0);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Target>().GetHealth = other.GetComponent<Target>().GetHealth + healthAmount; //GetHealth + healthAmount = value;
        }
        Destroy(gameObject);
    }
}
