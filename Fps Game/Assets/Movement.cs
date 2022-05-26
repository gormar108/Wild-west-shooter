using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 1000f;
    [SerializeField] float jump = 200f;
    

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    Rigidbody rb;
    
    bool isGrounded;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
       CubeMove();
       Sprint(); 
    }
    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2250f;
        }
        else
        {
            speed = 2000f;
        }
    }
    void CubeMove(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody> ().AddForce (Vector3.up * jump);
        }

        

        if(Input.GetKey(KeyCode.W))
        {
            rb.AddRelativeForce(Vector3.forward * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeForce(Vector3.left * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddRelativeForce(Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddRelativeForce(Vector3.back * speed * Time.deltaTime);
        }
    }
    
}
