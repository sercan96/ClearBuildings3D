using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePos;
    [SerializeField] float rateOfFire;
    public int ammoCount =5;
    // private Rigidbody rb; // Başka bir objenin Rigidbody si ile işlem yap.
    // private Rigidbody rb2;  // Bu scripte bağlı olan objenin Rigidbody si ile işlem yap.

    void Start()
    {
        // rb = GameObject.Find("Enemy").GetComponent<Rigidbody>(); // İnstance almak gibi.
        // rb.mass =15;
        // rb2 = GetComponent<Rigidbody>();
        // rb2.mass = 5;
        
    }   
    void Update()
    {
        rateOfFire -=Time.deltaTime;
        Fire();
    }
    void Fire()
    {
        if(Input.GetMouseButtonDown(0))  
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
                rateOfFire = 0.2f; 
                ammoCount --;                    
            }
        }
               
    }
}
