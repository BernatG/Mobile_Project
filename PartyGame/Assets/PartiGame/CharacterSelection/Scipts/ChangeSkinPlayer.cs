using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeSkinPlayer : MonoBehaviour
{

    public List<GameObject> personajes;
    int intPersonaje;
    public GameObject personajeVisual;
    public string nickName;
    public bool ready;

    public Image imageReady;

    // Start is called before the first frame update
    void Start()
    {       
        intPersonaje = 0;
        Destroy(personajeVisual);
        personajeVisual = Instantiate(personajes[intPersonaje], transform);
        ready = false;
    }

    public void ButtonInput(string input)
    {
        if (!ready)
        {
            Debug.Log("Mensage recivido:" + input);
            switch (input)
            {
                case "up":
                    intPersonaje++;
                    break;
                case "down":
                    intPersonaje--;
                    break;
                case "ready":
                    ready = true;
                    break;
            }
        }

    }

    private void FixedUpdate()
    {
        if (personajes.Count <= intPersonaje) intPersonaje = 0;
        if (-1 >= intPersonaje) intPersonaje = personajes.Count - 1;

        if (ready) imageReady.color = Color.green;

        Destroy(personajeVisual);
        personajeVisual = Instantiate(personajes[intPersonaje], transform);

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        intPersonaje++;
    //        if (personajes.Count <= intPersonaje) intPersonaje = 0;

    //        Destroy(personajeVisual);
    //        personajeVisual = Instantiate(personajes[intPersonaje], transform);
    //    }

    //    if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        intPersonaje--;
    //        if (-1 >= intPersonaje) intPersonaje = personajes.Count - 1;

    //        Destroy(personajeVisual);
    //        personajeVisual = Instantiate(personajes[intPersonaje], transform);

    //    }
    //}
}
