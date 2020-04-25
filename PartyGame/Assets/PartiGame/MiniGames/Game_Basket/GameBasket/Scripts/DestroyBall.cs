using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour
{

    Clock clock;
    private bool suelo;

    // Start is called before the first frame update
    void Start()
    {
        clock = new Clock();
        suelo = false;
    }

    void Update()
    {
        
        if (clock.getTime() > 5f && suelo)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Pista")
        {
            suelo = true;
        }
    }
}
