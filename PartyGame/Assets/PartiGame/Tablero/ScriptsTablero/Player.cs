using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int routePosition = -1;
    public bool ready = false;

    public void ButtonInput(string input)
    {
        Debug.Log("Mensage recivido:" + input);
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

