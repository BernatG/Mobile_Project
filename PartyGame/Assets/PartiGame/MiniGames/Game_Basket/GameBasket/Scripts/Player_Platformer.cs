using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;


public class Player_Platformer : MonoBehaviour {

	private Rigidbody rigidBody;
    public GameObject particleEffect;
    public GameObject negativeEffect;


    bool movingLeft;
	bool movingRight;
    bool movingUp;
    bool movingDown;

    private float playerSpeed = 0.3f;
	private float jumpForce = 350f;

    // public ParticleSystem particleBomb;
    public AudioClip punto;
    public AudioClip fail;
    AudioSource effectSounds;
    public TextMeshProUGUI textPoints;
    public int points;

    public Animator animator_boy;

    private void Start (){
        points = 0;
        rigidBody = GetComponent<Rigidbody> ();
        effectSounds = GetComponent<AudioSource>();
    }

	public void ButtonInput (string input){

        switch (input)
        {
            case "right":
                movingRight = true;
                break;
            case "left":
                movingLeft = true;
                break;
            case "up":
                movingUp = true;
                break;
            case "down":
                movingDown = true;
                break;

            case "right-up":
                movingRight = false;
                break;
            case "left-up":
                movingLeft = false;
                break;
            case "up-up":
                movingUp = false;
                break;
            case "down-up":
                movingDown = false;
                break;

            case "jump":
                rigidBody.AddForce(transform.up * jumpForce);
                break;
        }
	}

	private void FixedUpdate(){

        animator_boy.SetBool("correr", movingUp);
        animator_boy.SetBool("correr", movingDown);
        animator_boy.SetBool("left", movingLeft);
        animator_boy.SetBool("right", movingRight);

        if (movingLeft && !movingRight && !movingUp && !movingDown)
        {
            rigidBody.MovePosition(rigidBody.position + new Vector3(-playerSpeed, 0, 0));
        }
        else if (movingRight && !movingLeft && !movingUp && !movingDown)
        {
            rigidBody.MovePosition(rigidBody.position + new Vector3(playerSpeed, 0, 0));
        }
        else if (movingUp && !movingRight && !movingLeft && !movingDown)
        {
            rigidBody.MovePosition(rigidBody.position + new Vector3(0, 0, playerSpeed));
        }
        else if (movingDown && !movingRight && !movingLeft && !movingUp)
        {
            rigidBody.MovePosition(rigidBody.position + new Vector3(0, 0, -playerSpeed));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            effectSounds.clip = punto;
            effectSounds.Play();
            points += 100;
            Instantiate(particleEffect, transform);

            textPoints.text = points.ToString();
            Destroy(collision.gameObject);
           
        }
        if (collision.gameObject.tag == "bomb")
        {
            effectSounds.clip = fail;
            effectSounds.Play();
            if (points >= 100) points -= 100;    
            textPoints.text = points.ToString();
            Destroy(collision.gameObject);
            //particleBomb.Play();
        }
    }
}
