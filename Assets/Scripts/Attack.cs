using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePos;
    [SerializeField] float rateOfFire;
    [SerializeField] int ammoCount =5;

    //PowerUp pu; 

    void Start()
    {
        // pu = GetComponent<PowerUp>(); // bu scriptin bağlı olduğu objeyle işlem yap.
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
            Debug.Log("difference : " + difference);
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
