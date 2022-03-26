using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private int maxHealth; // maxHealth inspector'de bir kez değiştirilecek.
    private int _currentHealth;
    public int GetHealth
    {
        get => _currentHealth;
        set
        {
        _currentHealth = value; 
        if(_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }
        } 
    }
 //public GameObject particle;
[SerializeField]
private GameObject playerDeadParticle;

void Start()
{
    _currentHealth = maxHealth; // Başlangıçta can değerimizi belirledik. Değiştirilebilme durumuna karşın.
    // Bunu yapmamizin sebebi maxHealth değerini inspectorde player ve enemy objesini ayrı değer girdik.
    // player maxHealth = 10, enemy maxHealth = 3;
    // Start'ta yazmamızın sebebi bu obje oluştuğu anda Start edileceği için maxHealth değerini alacak.
    _audioSource = GetComponent<AudioSource>();
}
 private void OnTriggerEnter(Collider other) // 3.Yol
 {
     if(other.gameObject.GetComponent<bulletMovement>())
     {
        // Destroy(other.gameObject);
        _currentHealth--;
        GameObject go =Instantiate(playerDeadParticle,transform.position,Quaternion.identity);
        Destroy(go,0.5f);
        _audioSource.PlayOneShot(_audioClip);
        if(_currentHealth <= 0)
        {
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
