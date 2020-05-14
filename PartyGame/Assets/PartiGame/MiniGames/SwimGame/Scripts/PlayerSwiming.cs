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
    private bool okPresButton;

    public int rankngPlayer = 0;

    private ChangeSkinPlayer skin;

    public Animator animatorPlayer;

    private void Awake()
    {
        if (gameObject.name == "Player1")
        {
            skin = GameObject.Find("Player1Skin").GetComponent<ChangeSkinPlayer>();
            Instantiate(skin.personajeVisual, transform);
        }
        else if (gameObject.name == "Player2")
        {
            skin = GameObject.Find("Player2Skin").GetComponent<ChangeSkinPlayer>();
            Instantiate(skin.personajeVisual, transform);
        }
        else if (gameObject.name == "Player3")
        {
            skin = GameObject.Find("Player3Skin").GetComponent<ChangeSkinPlayer>();
            Instantiate(skin.personajeVisual, transform);
        }
        else if (gameObject.name == "Player4")
        {
            skin = GameObject.Find("Player4Skin").GetComponent<ChangeSkinPlayer>();
            Instantiate(skin.personajeVisual, transform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        rb = GetComponent<Rigidbody>();
        clock = new Clock();
        okPresButton = true;
        animatorPlayer = gameObject.GetComponentInChildren<Animator>();
        animatorPlayer.SetBool("swiming", true);
    }

    public void ButtonInput(string input)
    {

        switch (input)
        {
            case "swiming":
                swiming = true;
                clicks += 1;
                break;

            case "swiming-up":
                swiming = false;
                okPresButton = true;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (go)
        {
            if (swiming)
            {
                if (okPresButton)
                {
                    contador++;
                    thrust += 0.007f;
                    Debug.Log(thrust);
                    okPresButton = false;
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
            if(transform.position.x <= 45)
            {
                rb.MovePosition(rb.position + new Vector3(-thrust, 0, 0));
            }
        }
    }

}

