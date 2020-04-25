using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class changeScenes : MonoBehaviour
{
    public GameObject presentador;
    public GameObject presentador2;
    public Button tapToPlay;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        particle.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        presentador.SetActive(true);        
        presentador2.SetActive(true);        

        if (tapToPlay.isActiveAndEnabled)
        {
            presentador.SetActive(false);
            presentador2.SetActive(false);
            particle.Play();
        }   
    }

    public void closeGame()
    {
        Application.Quit();
    }

    public void game()
    {
        SceneManager.LoadScene(1);
    }
}
