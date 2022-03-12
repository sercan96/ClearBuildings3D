using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePos;
    [SerializeField] float rateOfFire;
    [SerializeField] int ammoCount =5;

    void Start()
    {
        
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
            if(rateOfFire <=0 && ammoCount >0)
            {
                if(difference >= 90) // Merminin ne tarafa bakacağını belirledik.
                {                 
                    GameObject bulletprefabRotate = Instantiate(bulletPrefab,firePos.gameObject.transform.position,
                    Quaternion.Euler(0f,0f,-90f));            
                }
                else
                {                    
                    Instantiate(bulletPrefab,firePos.gameObject.transform.position,Quaternion.Euler(0f,0f,90f));   
                }   
                rateOfFire = 0.2f; 
                ammoCount --;                    
            }
        }
               
    }
}
