using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePos;
    [SerializeField] float rateOfFire;
    [SerializeField] public int maxAmmo =30;
    private int ammoCount = 30;
    public int GetAmmo { get{return ammoCount;} set{ammoCount = value; if(ammoCount > maxAmmo) ammoCount = maxAmmo;  }}
    // private Rigidbody rb; // Başka bir objenin Rigidbody si ile işlem yap.
    // private Rigidbody rb2;  // Bu scripte bağlı olan objenin Rigidbody si ile işlem yap.
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private bool isEnemy = false;

    void Start()
    {
        
    }   
    void Update()
    {
        FireRange();
        Player();

    }
    public void FireRange()
    {
         rateOfFire -=Time.deltaTime;
    }
    void Player()
    {
        if(isPlayer)
        {
            if(Input.GetMouseButtonDown(0)) 
            {
                Fire(0.2f);
            }
        }
    }
    public void Enemy(float timeFire)
    {
       if(isEnemy)
       {
           Fire(timeFire);
       }
    }
    void Fire(float timeofFire)
    {                  
        float difference = 180 - transform.eulerAngles.y;
        // Debug.Log("difference : " + difference);
        if(rateOfFire <=0 && ammoCount >0)
        {
            if(Mathf.Abs(difference) >= 90) // Merminin ne tarafa bakacağını belirledik.
            {              
                Debug.Log("sol");   
                Instantiate(bulletPrefab,firePos.gameObject.transform.position,Quaternion.Euler(0f,0f,-90f));    // sağ (90 dan büyük)      
            }
            else
            {            
                Debug.Log("sağ");   
                Instantiate(bulletPrefab,firePos.gameObject.transform.position,Quaternion.Euler(0f,0f,90f));   // sol (90 dan küçük)
            }   
            rateOfFire = timeofFire; 
            ammoCount --;                                 
        }
                  
    }
}
