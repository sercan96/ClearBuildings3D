using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float distance;
    int[] ast;
    void Start()
    {
       for (int i = 0; i < 10; i++)
       {
           ast[i] = i;
       }
    }

    
    void Update()
    {
      transform.Rotate(0f,0,1f * speed * Time.deltaTime);  

      RaycastHit hit ; // Çarpılacak obje(hit)
      Physics.Raycast(transform.position,transform.TransformDirection(Vector3.right),out hit,Mathf.Infinity);
      if(hit.collider != null)
      {
          Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.right) * hit.distance,Color.red);
          Debug.Log("Çarptı");
          Destroy(hit.transform.gameObject);
          Debug.Log("Hit posiion : " + hit.point);

          hit.transform.GetComponent<Rigidbody>().isKinematic = true;
      }
      else
      {
           Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.right) *1000 ,Color.green);
           Debug.Log("Çarpmadı");
      }
    }
}
