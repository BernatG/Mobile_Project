using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
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
    SpawnPointManager pointsSpawn;

    public bool movingLeft = false;
    public bool movingRight = false;


    // Use this for initialization
    void Start()
    {

    }

    public void Movimiento1()
    {
        

        
    }

    

    protected virtual void Update()
    {
        Movimiento1();
        textScore.text = "Score: " + score;
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
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

    public void EndGame()
    {
        if (score == 7 && pointsSpawn.numSpawnObjects == 25)
        {
            Debug.Log("Se acabo!!!");
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
        //float mH = Input.GetAxisRaw("Horizontal");
        //float mV = Input.GetAxisRaw("Vertical");




    }


}
