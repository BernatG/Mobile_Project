using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSwiming : MonoBehaviour
{
    int contador;

    Clock clock;

    private float thrust = 0.0f;

    private Rigidbody rb;

    private bool swiming;

    int clicks = 0;

    public bool go = false;

    public int rankngPlayer = 0;
 
    
    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        rb = GetComponent<Rigidbody>();
        clock = new Clock();        
    }

    public void ButtonInput(string input)
    {

        switch (input)
        {
            case "swiming":
                swiming = true;
                clicks += 1;
                Debug.Log(clicks);
                break;

            case "swiming-up":
                swiming = false;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (go)
        {
            if (swiming)
            {
                contador++;
                thrust += 0.002f;
            }
            else
            {
                if (clock.getTime() >= 0.05f)
                {
                    if (thrust >= 0)
                    {
                        thrust -= 0.001f;
                    }
                    clock.reset();
                }

            }
            rb.MovePosition(rb.position + new Vector3(-thrust, 0, 0));
        }
    }

}

