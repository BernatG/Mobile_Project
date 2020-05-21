using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeSkinPlayer : MonoBehaviour
{

    public List<GameObject> personajes;
    int intPersonaje;
    public GameObject personajeVisual;
    public string nickName;
    public bool ready;

    public Image imageReady;

    private Vector3 scaleChange;
    private Transform personaje;

    // Start is called before the first frame update
    void Start()
    {       
        intPersonaje = 0;
        scaleChange = new Vector3(1.243f, 1.243f, 1.243f);
        Destroy(personajeVisual);

        personajeVisual = Instantiate(personajes[intPersonaje], transform);
        personajeVisual.transform.localScale = scaleChange;
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

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (ready) imageReady.color = Color.green;
        }
        else
        {
            ready = false;
        }

        Destroy(personajeVisual);
        personajeVisual = Instantiate(personajes[intPersonaje], transform);

        personajeVisual.transform.localScale = scaleChange;        
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
