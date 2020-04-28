using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    bool movable;

    public float ballSpeed;
    public GameObject Sphere;
    public Vector3 scale;

    void Start()
    {
        scale = Sphere.transform.localScale;
    }

    void Update()
    {

        Move();

    }
  
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Campo"))
        {
            movable = true;
        }
        else { movable = false; };

      
    }

    void Move()
    {
        if(movable == true)
        {
            float xSpeed = Input.GetAxis("Horizontal");
            float ySpeed = Input.GetAxis("Vertical");


            Rigidbody body = GetComponent<Rigidbody>();
            body.AddTorque(new Vector3(xSpeed, 0, ySpeed) * ballSpeed * Time.deltaTime * 2);


        }
    }
    
}
