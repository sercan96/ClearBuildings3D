using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform[] movePoint;
    private bool canMoveRight = false;
    private float speed =5;

    void Update()
    {
        CheckMoveRight();
        MoveTowards();
    }
    void MoveTowards() // Başlangıç yerinden gideceği yere kadarki yolu belirleriz.
    {
        if(!canMoveRight)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f,180f,0f),speed * Time.deltaTime); 
            LookAtTarget(movePoint[0].position); // rotasyonu sağladık.
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f,0f,0f),speed * Time.deltaTime);
            LookAtTarget(movePoint[1].position);
        }

    }
    void CheckMoveRight()
    {
        // Kendi pozisyonum ile belirlediğim objenin pozisyonu arasındaki fark 0.1f değerden az ise;
        if(Vector3.Distance(transform.position,movePoint[0].position) <= 0.1f)
        {
            canMoveRight = true;
            print("Move Right");
        }
        else if(Vector3.Distance(transform.position,movePoint[1].position) <= 0.1f)
        {
            canMoveRight = false;
            print("Move Left");
            
        }
    }
    void LookAtTarget(Vector3 movePoint)
    {
        transform.position = Vector3.MoveTowards(transform.position,movePoint,speed * Time.deltaTime);
    }
}
