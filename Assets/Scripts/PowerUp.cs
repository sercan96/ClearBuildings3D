using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Setting")]
    public bool healthPowerUp =false;
    [SerializeField] int  healthAmount = 1;
    [Header("Ammo Setting")]
    public bool ammoPowerUp =false;   

   [SerializeField] int  ammoAmount = 5;
   Attack attack;
   Target target;
   private int turnspeed =2;
    void Start()
    {
        attack =GameObject.Find("Player").GetComponent<Attack>();
        target = GameObject.Find("Player").GetComponent<Target>();
        HealthandAmmoPowerUp();
    } 
    void HealthandAmmoPowerUp()
    {
        if(healthPowerUp && ammoPowerUp)
        {
            healthPowerUp = false;
            ammoPowerUp =false;
        }
        else if(healthPowerUp)
        {
            ammoPowerUp = false;
        }
        else if(ammoPowerUp)
        {
            healthPowerUp = false;
        }
    }
    void Update()
    {
        if(healthPowerUp)
        {
            Rotate(transform.up * turnspeed);
        }
        else
        {
           Rotate(transform.right * turnspeed);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(healthPowerUp)
        {
            if(target)  // other.gameObject.CompareTag("Player"), Player objesinin target scripti ile işlem yapacaz.
            {
                target.GetHealth += healthAmount;
                // other.GetComponent<Target>().GetHealth = other.GetComponent<Target>().GetHealth + healthAmount; //GetHealth + healthAmount = value;
            }
            Destroy(gameObject);    
        }
        else if(ammoPowerUp)
        {
            if(attack)   // other.gameObject.CompareTag("Player"), çarptığı obje "Player" se;
            {
                attack.ammoCount += ammoAmount;
            }
            Destroy(gameObject);
        }
    }
    void Rotate(Vector3 rotate) // Vector3.right =(1,0,0);
    {
        transform.Rotate(rotate.x,rotate.y,rotate.z);   
    } 
}
