using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move2 : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 2;
    public float speedJoystick = 5f;
    public Vector3 movimiento;
    public Vector3 JoystickMove;
    private bool enter = true;
    public int score = 0;
    public Text textScore;
    public ParticleSystem points;
    public float movementSpeed = 5.0f;
    public float rotationSpeed = 200.0f;

    public bool movingLeft = false;
    public bool movingRight = false;


    // Use this for initialization
    void Start()
    {

    }   

    public void Movimiento2()
    {

    }

    protected virtual void Update()
    {
        Movimiento2();
        textScore.text = "Score: " + score;
        float x = Input.GetAxis("Horizontal2");
        float y = Input.GetAxis("Vertical2");
        rb.velocity = new Vector3(x * speed, rb.velocity.y, y * speed);

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag.Equals("BallPoints"))
        {
            Debug.Log("Enter");
            score++;
            points.Play();
            Debug.Log("Score: " + score);
            textScore.text = "Score: " + score;
            Destroy(other.gameObject);
        }
        else
        {
            points.Stop();
        }

        if (other.tag.Equals("BadPoints"))
        {
            Debug.Log("Enter");
            score--;
            points.Play();
            Debug.Log("Score: " + score);
            textScore.text = "Score: " + score;
            Destroy(other.gameObject);
        }

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag.Equals("BallPoints"))
    //    {
    //        Debug.Log("Enter");
    //    }
    //}






    // Update is called once per frame
    void FixedUpdate()
    {
        //float mH = Input.GetAxisRaw("Horizontal2");
        //float mV = Input.GetAxisRaw("Vertical2");

        //rb.velocity = new Vector3(mH * speed, rb.velocity.y, mV * speed);



    }


}
