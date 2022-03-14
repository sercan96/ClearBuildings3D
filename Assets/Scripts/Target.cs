using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
[SerializeField] private int maxHealth =3; // maxHealth inspector'de bir kez değiştirilecek.
private int currentHealth;
public int GetHealth
{
    get
    {
        return currentHealth;
    }
    set
    {
        currentHealth = value; 
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

}

void Start()
{
    currentHealth = maxHealth; // Bunu yapmamızın sebebi maxHealth değerini sabit tutmak
}
 private void OnTriggerEnter(Collider other) // 3.Yol
 {
     if(other.gameObject.GetComponent<bulletMovement>() && !gameObject.CompareTag("Player"))
     {
        Destroy(other.gameObject);
        currentHealth--;
        if(currentHealth <= 0)
        {
            Die();
        }
     }
 }
 void Die()
 {
     Destroy(gameObject);
 }

}
