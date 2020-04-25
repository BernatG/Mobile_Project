using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_JumpAndDown : MonoBehaviour
{
    Clock clock;
    private Rigidbody rb;
    private BoxCollider bc;
    private Animator animatorPlayer; 
    bool cubeIsOnGround;
    public bool kill;    

    bool movingUp;
    bool movingDown;

    public int points;

    void Start()
    {
        clock = new Clock();
        bc = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>(); 
        points = 0;
        kill = false;
    }
    public void ButtonInput(string input)
    {
        switch (input)
        {
            case "up":
                movingUp = true;
                break;
            case "down":
                movingDown = true;
                break;
            case "up-up":
                movingUp = false;
                break;
            case "down-up":
                movingDown = false;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (kill == false)
        {
            animatorPlayer.SetBool("movingUp", movingUp);
            animatorPlayer.SetBool("movingDown", movingDown);

            if (movingUp && !movingDown && cubeIsOnGround)
            {
                clock.reset();
                animatorPlayer.Play("jump");
                rb.AddForce(new Vector3(0, 5f, 0), ForceMode.Impulse);
                bc.center = new Vector3(-0.0706118f, 0.7996932f, 0.0243601f);
                bc.size = new Vector3(0.5379544f, 0.7933384f, 0.7090649f);
                cubeIsOnGround = false;
            }
            else if (movingDown && !movingUp)
            {
                bc.center = new Vector3(-0.0706118f, 0.2388006f, 0.02436011f);
                bc.size = new Vector3(0.5379544f, 0.4776005f, 0.7090649f);

                rb.AddForce(new Vector3(0, -2.5f, 0), ForceMode.Impulse);
            }
            else if(clock.getTime() >= 1f)
            {
                bc.center = new Vector3(-0.0706118f, 0.5294402f, 0.02436014f);
                bc.size = new Vector3(0.5379544f, 1.05888f, 0.7090649f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            cubeIsOnGround = true;
        }

        if (collision.gameObject.tag == "extension")
        {
            rb.AddForce(transform.position * -3);
            rb.freezeRotation = false;
        }

        //if(collision.gameObject.name == "CylinderTop" || collision.gameObject.name == "CylinderDown")
        //{

        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "water")
        {
            Debug.Log("Colision water");
            kill = true;

        }
    }
}
