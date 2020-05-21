using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int routePosition = -1;
    public bool ready = false;
    private ChangeSkinPlayer skin;

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

    public void ButtonInput(string input)
    {
        switch (input)
        {
            case "start":
                ready = true;
                break;
        }

    }

    private void FixedUpdate()
    {

    }
}

