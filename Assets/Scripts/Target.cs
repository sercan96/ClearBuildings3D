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
 //public GameObject particle;
[SerializeField]
private GameObject playerDeadParticle;

void Start()
{
    currentHealth = maxHealth; 
    // Bunu yapmamızın sebebi maxHealth değerini bu obje için sabit kılıyoruz. 
    // İlerde başka bir obje GetHealth ile değerini değiştirirse bu değişkenin değerini tutmuş oluyoruz.
}
 private void OnTriggerEnter(Collider other) // 3.Yol
 {
     if(other.gameObject.GetComponent<bulletMovement>())
     {
        // Destroy(other.gameObject);
        currentHealth--;
        GameObject go =Instantiate(playerDeadParticle,transform.position,Quaternion.identity);
        Destroy(go,0.5f);
        if(currentHealth <= 0)
        {
            // particle.SetActive(false); 
    
            Die();
        }
     }
 }
 void Die()
 {
    // particle.transform.position = transform.position;
    // particle.SetActive(true); 
    GameObject go =Instantiate(playerDeadParticle,transform.position,Quaternion.identity);
    Destroy(go,0.5f);
    Destroy(gameObject);
 }

}
