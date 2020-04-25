using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidades : MonoBehaviour
{
    public Move move1;
    public Move2 move2;
    public int usos = 1;
    private bool isBoosted;
    static float tiempo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && usos >= 1)
        {
            tiempo = 0.3f;
            move1.speed = 0f;
            isBoosted = true;
            usos--;
        }

        if (Input.GetKeyDown(KeyCode.P) && usos >= 1)
        {
            tiempo = 3f;
            move1.speed = 0f;
            isBoosted = true;
            usos--;
        }
    }
}
