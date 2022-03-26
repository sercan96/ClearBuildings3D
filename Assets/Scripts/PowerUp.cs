using System;
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
   [Header("Scale Settings")]
   [SerializeField]private float period = 2f;
   [SerializeField] float scaleFactor;
   [SerializeField] Vector3 scaleVector;
   private int turnspeed =2;
   private Vector3 startScale;
   private AudioSource _audioSource;
   private AudioClip _audioClip;
    void Start()
    {
        startScale = transform.localScale; // powerUp büyüklüğünü tutacak.

        attack =GameObject.Find("Player").GetComponent<Attack>();
        target = GameObject.Find("Player").GetComponent<Target>();
        _audioSource = GetComponent<AudioSource>();
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
           Rotate(new Vector3(1f,1f,1f) * turnspeed);
        }
        SinusWave();
    }

    private void SinusWave() // Objenin boyutunu büyütüp küçültme işlemi(sinus dalgası ile)
    {
        if(period <= 0f)
        {
            period = 0.1f;
        }
        float cycles = Time.timeSinceLevelLoad /period;
        const float piX2 = Mathf.PI * 2;
        float sinusWave = Mathf.Sin(cycles * piX2);
        scaleFactor = sinusWave / 2 + 0.5f;
        Vector3 offset = scaleFactor * scaleVector;
        transform.localScale = startScale + offset;
    }

    void OnTriggerEnter(Collider other)
    {
        if(!other.gameObject.CompareTag(("Player")))
        {
            return;
        }
        _audioSource.Play();
        if(healthPowerUp)
        {
            if(other.gameObject.CompareTag("Player"))  // other.gameObject.CompareTag("Player"), Player objesinin target scripti ile işlem yapacaz.
            {
                target.GetHealth += healthAmount;
                Destroy(gameObject);
                // other.GetComponent<Target>().GetHealth = other.GetComponent<Target>().GetHealth + healthAmount; //GetHealth + healthAmount = value;
            }
                
        }
        else if(ammoPowerUp)
        {
            if(other.gameObject.CompareTag("Player"))   // other.gameObject.CompareTag("Player"), çarptığı obje "Player" se;
            {
                attack.GetAmmo += ammoAmount;
                 Destroy(gameObject);
            }
           
        }
    }
    void Rotate(Vector3 rotate) // Vector3.right =(1,0,0);
    {
        transform.Rotate(rotate.x,rotate.y,rotate.z);   
    } 

}
