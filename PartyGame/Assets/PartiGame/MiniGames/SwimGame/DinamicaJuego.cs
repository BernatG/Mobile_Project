using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinamicaJuego : MonoBehaviour
{
    int contadorP1;
    int contadorP2;
    int contadorP3;
    int contadorP4;

    Clock clock;

    public Text scoreP1;
    public Text scoreP2;
    public Text scoreP3;
    public Text scoreP4;
    public Text textWin;

    public float thrust1 = 0.0f;
    public float thrust2 = 0.0f;
    public float thrust3 = 0.0f;
    public float thrust4 = 0.0f;
 
    public Rigidbody p1;   
    public Rigidbody p2;   
    public Rigidbody p3;   
    public Rigidbody p4;   
    
    // Start is called before the first frame update
    void Start()
    {
        contadorP1 = 0;
        contadorP2 = 0;
        contadorP3 = 0;
        contadorP4 = 0;
        clock = new Clock();        
    }

    // Update is called once per frame
    //bool MoveToNextNode(Vector3 goal)
    //{
    //    return goal != (p1.transform.position = Vector3.MoveTowards(p1.transform.position, goal, thrust * Time.deltaTime)); 
    //}

    void P1()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            contadorP1++;
            thrust1 += 0.03f;
        }
        else
        {
            if (clock.getTime() >= 0.05f)
            {
                if (thrust1 >= 0)
                {
                    thrust1 -= 0.01f;
                }
                clock.reset();
            }

        }
        p1.MovePosition(p1.position + new Vector3(-thrust1, 0, 0));
    }

    void P2()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            contadorP2++;
            thrust2 += 0.03f;
        }
        else
        {
            if (clock.getTime() >= 0.05f)
            {
                if (thrust2 >= 0)
                {
                    thrust2 -= 0.01f;
                }
                clock.reset();
            }

        }
        p2.MovePosition(p2.position + new Vector3(-thrust2, 0, 0));
    }

    void P3()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            contadorP3++;
            thrust3 += 0.03f;
        }
        else
        {
            if (clock.getTime() >= 0.05f)
            {
                if (thrust3 >= 0)
                {
                    thrust3 -= 0.01f;
                }
                clock.reset();
            }

        }
        p3.MovePosition(p3.position + new Vector3(-thrust3, 0, 0));
    }

    void P4()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            contadorP4++;
            thrust4 += 0.03f;
        }
        else
        {
            if (clock.getTime() >= 0.05f)
            {
                if (thrust4 >= 0)
                {
                    thrust4 -= 0.01f;
                }
                clock.reset();
            }

        }
        p4.MovePosition(p4.position + new Vector3(-thrust4, 0, 0));
    }

    void Update()
    {
        P1();
        P2();
        P3();
        P4();                      

        if (contadorP1 == 10)
        {
            //.text = contadorP1.ToString("Congrats P1");
        }
        else if (contadorP2 <= 10 || contadorP3 <= 10 || contadorP4 <= 10)
        {

        }
        if (contadorP2 == 10)
        {
           // textWin.text = contadorP2.ToString("Congrats P2");
        }
        else if (contadorP1 <= 10 || contadorP3 <= 10 || contadorP4 <= 10)
        {

        }
        if (contadorP3 == 10)
        {
           // textWin.text = contadorP3.ToString("Congrats P3");
        }
        else if (contadorP1 <= 10 || contadorP2 <= 10 || contadorP4 <= 10)
        {

        }
        if (contadorP4 == 10)
        {
          //  textWin.text = contadorP4.ToString("Congrats P4");
        }
        else if (contadorP1 <= 10 || contadorP3 <= 10 || contadorP2 <= 10)
        {

        }
    }
}

