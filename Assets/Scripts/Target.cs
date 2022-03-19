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
public GameObject particle;

void Start()
{
    currentHealth = maxHealth; // Bunu yapmamızın sebebi maxHealth değerini sabit tutmak
}
 private void OnTriggerEnter(Collider other) // 3.Yol
 {
     if(other.gameObject.GetComponent<bulletMovement>())
     {
        Destroy(other.gameObject);
        currentHealth--;
        if(currentHealth <= 0)
        {
            particle.SetActive(false); 
            Die();
        }
     }
 }
 void Die()
 {
    particle.transform.position = transform.position;
    particle.SetActive(true); 
    Destroy(gameObject);
 }

}
