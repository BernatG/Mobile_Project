using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkinPlayer : MonoBehaviour
{
    public List<GameObject> personajes;
    int intPersonaje;
    private GameObject personajeVisual;
    // Start is called before the first frame update
    void Start()
    {       
        intPersonaje = 0;
        Destroy(personajeVisual);
        personajeVisual = Instantiate(personajes[intPersonaje], transform);

    }

    public void ButtonInput(string input)
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
        }

    }

    private void FixedUpdate()
    {
        if (personajes.Count <= intPersonaje) intPersonaje = 0;
        if (-1 >= intPersonaje) intPersonaje = personajes.Count - 1;

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
