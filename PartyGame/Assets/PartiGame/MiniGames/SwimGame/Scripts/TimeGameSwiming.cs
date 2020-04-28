using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeGameSwiming : MonoBehaviour
{
    Clock clock;
    private float time;
    private int segundos;
    bool startGame;

    public GameObject startGameGo;
    public TextMeshProUGUI textStartGame;

    public TextMeshProUGUI textTimeGame;

    public GameObject CanvasRankingGame;

    public PlayerSwiming player1;
    public PlayerSwiming player2;
    public PlayerSwiming player3;
    public PlayerSwiming player4;

    public GameObject timerPanel;

    // Start is called before the first frame update
    void Start()
    {
        clock = new Clock();
        startGame = true;

        time = 5;
        textStartGame.text = time.ToString();
        startGameGo.SetActive(true);
        timerPanel.SetActive(true);

        CanvasRankingGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (startGame)
        {
            if (clock.getTime() >= 1f)
            {
                time -= 1;
                textStartGame.text = time.ToString();
                if (time == 0)
                {
                    startGame = false;
                    player1.go = true;
                    player2.go = true;
                    player3.go = true;
                    player4.go = true;
                    time = 30;
                    startGameGo.SetActive(false);
                    timerPanel.SetActive(true);
                }
                clock.reset();
            }
        }
        else
        {
            if (clock.getTime() >= 1f)
            {
                time -= 1;
                textTimeGame.text = time.ToString();
                if (time == 0)
                {
                    player1.go = false;
                    player2.go = false;
                    player3.go = false;
                    player4.go = false;
                    CanvasRankingGame.SetActive(true);   
                    timerPanel.SetActive(false);
                }
                clock.reset();
            }
            
        }

    }
}
