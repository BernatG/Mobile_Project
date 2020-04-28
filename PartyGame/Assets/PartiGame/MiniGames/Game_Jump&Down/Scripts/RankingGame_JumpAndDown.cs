using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;


public class RankingGame_JumpAndDown : MonoBehaviour
{
    int winerOne = 0;
    int winerTwo = 0;
    int winerThree = 0;
    int winerFour = 0;

    bool player1ok;
    bool player2ok;
    bool player3ok;
    bool player4ok;

    public PlayerController_JumpAndDown player1;
    public PlayerController_JumpAndDown player2;
    public PlayerController_JumpAndDown player3;
    public PlayerController_JumpAndDown player4;
    
    public Image NumberRankingPlayer1;
    public Image NumberRankingPlayer2;
    public Image NumberRankingPlayer3;
    public Image NumberRankingPlayer4;

    public Sprite first;
    public Sprite second;
    public Sprite third;
    public Sprite fourth;

    public GameObject canvasRanking;

    private Stone stone;

    private void Start()
    {
        stone = (Stone)FindObjectOfType(typeof(Stone));

        canvasRanking.SetActive(false);
        player1ok = false;
        player2ok = false;
        player3ok = false;
        player4ok = false;
    }

    private void Update()
    {

        if(player1.kill && player1ok == false)
        {
            if (winerFour != 0)
            {
                if (winerThree != 0)
                {
                    if (winerTwo != 0)
                    {
                        winerOne = 1;
                        stone.stepsPlayer1 = 4;
                        Debug.Log("Winer 1: " + winerOne);
                        player1ok = true;
                        canvasRanking.SetActive(true);
                        Ranking(winerOne, first);
                        Ranking(winerTwo, second);
                        Ranking(winerThree, third);
                        Ranking(winerFour, fourth);
                    }
                    else
                    {
                        winerTwo = 1;
                        stone.stepsPlayer1 = 3;
                        Debug.Log("Winer 2: " + winerTwo);
                        player1ok = true;
                    }
                }
                else
                {
                    stone.stepsPlayer1 = 2;
                    winerThree = 1;
                    Debug.Log("Winer 3: " + winerThree);
                    player1ok = true;
                }
            }
            else
            {
                stone.stepsPlayer1 = 1;
                winerFour = 1;
                Debug.Log("Winer 4: " + winerFour);
                player1ok = true;
            }
        }
        else if (player2.kill && player2ok == false)
        {
            if (winerFour != 0)
            {
                if (winerThree != 0)
                {
                    if (winerTwo != 0)
                    {
                        winerOne = 2;
                        stone.stepsPlayer2 = 4;
                        Debug.Log("Winer 1: " + winerOne);
                        player2ok = true;
                        canvasRanking.SetActive(true);
                        Ranking(winerOne, first);
                        Ranking(winerTwo, second);
                        Ranking(winerThree, third);
                        Ranking(winerFour, fourth);                    
                    }
                    else
                    {
                        winerTwo = 2;
                        stone.stepsPlayer2 = 3;
                        Debug.Log("Winer 2: " + winerTwo);
                        player2ok = true;
                    }
                }
                else
                {
                    winerThree = 2;
                    stone.stepsPlayer2 = 2;
                    Debug.Log("Winer 3: " + winerThree);
                    player2ok = true;
                }
            }
            else
            {
                winerFour = 2;
                stone.stepsPlayer2 = 1;
                Debug.Log("Winer 4: " + winerFour);
                player2ok = true;
            }
        }
        else if (player3.kill && player3ok == false)
        {
            if (winerFour != 0)
            {
                if (winerThree != 0)
                {
                    if (winerTwo != 0)
                    {
                        winerOne = 3;
                        stone.stepsPlayer3 = 4;
                        Debug.Log("Winer 1: " + winerOne);
                        canvasRanking.SetActive(true);
                        Ranking(winerOne, first);
                        Ranking(winerTwo, second);
                        Ranking(winerThree, third);
                        Ranking(winerFour, fourth);
                        player3ok = true;
                    }
                    else
                    {
                        winerTwo = 3;
                        stone.stepsPlayer3 = 3;
                        Debug.Log("Winer 2: " + winerTwo);
                        player3ok = true;
                    }
                }
                else
                {
                    winerThree = 3;
                    stone.stepsPlayer3 = 2;
                    Debug.Log("Winer 3: " + winerThree);
                    player3ok = true;
                }
            }
            else
            {
                winerFour = 3;
                stone.stepsPlayer3 = 1;
                Debug.Log("Winer 4: " + winerFour);
                player3ok = true;
            }
        }
        else if (player4.kill && player4ok == false)
        {
            if (winerFour != 0)
            {
                if (winerThree != 0)
                {
                    if (winerTwo != 0)
                    {
                        winerOne = 4;
                        stone.stepsPlayer4 = 4;
                        Debug.Log("Winer 1: " + winerOne);
                        player1ok = true;
                        canvasRanking.SetActive(true);
                        Ranking(winerOne, first);
                        Ranking(winerTwo, second);
                        Ranking(winerThree, third);
                        Ranking(winerFour, fourth);
                    }
                    else
                    {
                        winerTwo = 4;
                        stone.stepsPlayer4 = 3;
                        Debug.Log("Winer 2: " + winerTwo);
                        player4ok = true;
                    }
                }
                else
                {
                    winerThree = 4;
                    stone.stepsPlayer4 = 2;
                    Debug.Log("Winer 3: " + winerThree);
                    player4ok = true;
                }
            }
            else
            {
                winerFour = 4;
                stone.stepsPlayer4 = 1;
                Debug.Log("Winer 4: " + winerFour);
                player4ok = true;
            }
        }
    }

    void Ranking (int numberWin, Sprite spriteNumberWin)
    {
        switch (numberWin)
        {
            case 1:
                NumberRankingPlayer1.sprite = spriteNumberWin;
                Debug.Log("Player 1 movimentos: " + stone.stepsPlayer1);
                break;
            case 2:
                NumberRankingPlayer2.sprite = spriteNumberWin;
                Debug.Log("Player 2 movimentos: " + stone.stepsPlayer2);
                break;
            case 3:
                NumberRankingPlayer3.sprite = spriteNumberWin;
                Debug.Log("Player 3 movimentos: " + stone.stepsPlayer3);
                break;
            case 4:
                NumberRankingPlayer4.sprite = spriteNumberWin;
                Debug.Log("Player 4 movimentos: " + stone.stepsPlayer4);
                break;
        }

        SceneManager.LoadScene("SceneTablero");
    }
}
