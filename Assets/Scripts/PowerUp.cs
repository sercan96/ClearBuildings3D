using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Health Setting")]
    public bool healthPowerUp =false;
     [Header("Ammo Setting")]
    public bool ammoPowerUp =false;   
   [SerializeField] int  healthAmount = 1;
   [SerializeField] int  ammoAmount = 5;
   Attack attack;
   Target target;
   private int turnspeed =5;
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
        transform.Rotate(turnspeed,0,0);
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
}
