using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject firePos;
    void Start()
    {
        
    }

    
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if(Input.GetMouseButtonDown(0))  
        {

            float difference = 180 - transform.eulerAngles.y;
            if(difference >= 90) // Merminin ne tarafa bakacağını belirledik.
            {   
                GameObject bulletprefabRotate = Instantiate(bulletPrefab,firePos.gameObject.transform.position,
                Quaternion.Euler(0f,0f,-90f));   
            }
            else
            {                    
                Instantiate(bulletPrefab,firePos.gameObject.transform.position,Quaternion.Euler(0f,0f,90f));   
            }           
        }     
    }
}
