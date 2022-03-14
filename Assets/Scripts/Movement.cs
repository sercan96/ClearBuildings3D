using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float speed ;
    [SerializeField] float jumpPower = 13f;
    [SerializeField] float turnspeed = 15;
     
    // [SerializeField] List<Transform> ground = new List<Transform>();
    [SerializeField] Transform[] rayStartPoints;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Yeni bir rigidbody oluşturduk new leme işlemi
    }
    public void GetInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // Vector2 direction = new Vector2(horizontal * moveSpeed * Time.deltaTime, vertical *moveSpeed * Time.deltaTime);
    }
    void Update()
    {
        // GetInput();     
        TakeInput();
        //print(OnGroundCheck());
    }
    public void Move(Vector2 direction)
    {
        rb.velocity = new Vector3(direction.x, rb.velocity.y, direction.y);
    }
    public void TakeInput()  
    {
        //transform.Translate(Vector3.forward);
        // transform.Translate(transform.forward);
        if(Input.GetKeyDown(KeyCode.Space) && OnGroundCheck())
        {
            rb.velocity = new Vector3(rb.velocity.x,Mathf.Clamp((jumpPower * 100) * Time.deltaTime,0f,15f),0f);    
        }
        else if(Input.GetKey(KeyCode.A))
        {
            // transform.Rotate(0f,-180f,0f); Her A ya basılı tuttuğumuzda y eksenine -180 ekleyecek. bu yüzden rotation kullandık eşitleme ile.
            // transform.rotation = Quaternion.Euler(0f,-180f,0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f,-180f,0f),turnspeed * Time.deltaTime);
             rb.velocity = new Vector3(Mathf.Clamp((-speed *100) * Time.deltaTime,-15f,0f),rb.velocity.y,0f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            // transform.rotation = Quaternion.Euler(0f,0f,0f);
            // Yumuşak bir dönüş için Quaternion.Lerp komutu kullanılır.
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f,0f,0f),turnspeed * Time.deltaTime);
            rb.velocity = new Vector3(Mathf.Clamp((speed *100) * Time.deltaTime,0f,15f),rb.velocity.y,0f);
        }
        else
        {
            rb.velocity = new Vector3(0f,rb.velocity.y,0f);
        }
    }
    private bool OnGroundCheck()
    {
        bool hit = false; 
        for (int i = 0; i < rayStartPoints.Length; i++)
        {
            hit= Physics.Raycast(rayStartPoints[i].position,Vector3.down,0.25f);
            Debug.DrawRay(rayStartPoints[i].position, -rayStartPoints[i].transform.up,Color.red);
        }
        if(hit)
        {
            return true; // zemin ile temas halinde olduğu için true döner
        }
        else
        {
            return false;
        }
    }
}
