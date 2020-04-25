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

    public Text scoreP1;
    public Text scoreP2;
    public Text scoreP3;
    public Text scoreP4;
    public Text textWin;

    // Start is called before the first frame update
    void Start()
    {
        contadorP1 = 0;
        contadorP2 = 0;
        contadorP3 = 0;
        contadorP4 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            contadorP1++;
            scoreP1.text = contadorP1.ToString();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            contadorP2++;
            scoreP2.text = contadorP2.ToString();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            contadorP3++;
            scoreP3.text = contadorP3.ToString();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            contadorP4++;
            scoreP4.text = contadorP4.ToString();
        }

        if (contadorP1 == 10)
        {
            textWin.text = contadorP1.ToString("Congrats P1");
        }
        else if (contadorP2 <= 10 || contadorP3 <= 10 || contadorP4 <= 10)
        {

        }
        if (contadorP2 == 10)
        {
            textWin.text = contadorP2.ToString("Congrats P2");
        }
        else if (contadorP1 <= 10 || contadorP3 <= 10 || contadorP4 <= 10)
        {

        }
        if (contadorP3 == 10)
        {
            textWin.text = contadorP3.ToString("Congrats P3");
        }
        else if (contadorP1 <= 10 || contadorP2 <= 10 || contadorP4 <= 10)
        {

        }
        if (contadorP4 == 10)
        {
            textWin.text = contadorP4.ToString("Congrats P4");
        }
        else if (contadorP1 <= 10 || contadorP3 <= 10 || contadorP2 <= 10)
        {

        }
    }
}
