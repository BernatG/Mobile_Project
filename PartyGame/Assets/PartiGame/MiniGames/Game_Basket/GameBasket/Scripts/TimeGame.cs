using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class TimeGame : MonoBehaviour
{
    Clock clock;
    private float time;
    private int minutos;
    private int segundos;
    bool startGame;

    public AudioSource musicAmbient;
    public GameObject startGameGo;
    public TextMeshProUGUI textStartGame;
    public AudioClip clipCountDown;
    public AudioSource audioCountDown;

    //public GameObject timeGameGo;
    public TextMeshProUGUI textTimeGame;

    public GameObject CanvasRankingGame;
    public GameObject initalGame;

    // Start is called before the first frame update
    void Start()
    {
        clock = new Clock();
        startGame = true;        

        time = 5;       
        textStartGame.text = time.ToString();
        startGameGo.SetActive(true);



        CanvasRankingGame.SetActive(false);
        //timeGameGo.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if (time == 4)
        {
            audioCountDown.Play();
        }
        if (startGame)
        {
            musicAmbient.Play();
            if (clock.getTime() >= 1f)
            {
                time -= 1;
                textStartGame.text = time.ToString();
                if (time == 0)
                {
                    startGame = false;
                    startGameGo.SetActive(false);
                    initalGame.SetActive(true);
                    //timeGameGo.SetActive(true);
                }
                clock.reset();
            }                       
        }
        else
        {            
            
            if (minutos == 1)
            {               
                initalGame.SetActive(false);
                CanvasRankingGame.SetActive(true);
                musicAmbient.Stop();

            }
            else
            {
                segundos = (int)clock.getTime() % 60;
                minutos = (int)clock.getTime() / 60;


                textTimeGame.text = minutos.ToString("") + ":" + segundos.ToString("00");
            }

        }

    }
}
