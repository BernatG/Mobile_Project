using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public PlayerSwiming player1;
    public PlayerSwiming player2;
    public PlayerSwiming player3;
    public PlayerSwiming player4;

    public int ranking = 1;

    public GameObject canvasRankingGame;
    public GameObject timeGame;

    private void Update()
    {
        if(ranking >= 5)
        {
            canvasRankingGame.SetActive(true);
            timeGame.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player1")
        {
            if (player1.rankngPlayer == 0)
            {
                player1.rankngPlayer = ranking;
                player1.go = false;
                ranking++;
            }
        }
        else if (other.gameObject.name == "Player2")
        {
            if (player2.rankngPlayer == 0)
            {
                player2.rankngPlayer = ranking;
                player2.go = false;
                ranking++;
            }
        }
        else if (other.gameObject.name == "Player3")
        {
            if (player3.rankngPlayer == 0)
            {
                player3.rankngPlayer = ranking;
                player3.go = false;
                ranking++;
            }
        }
        else if (other.gameObject.name == "Player4")
        {
            if (player4.rankngPlayer == 0)
            {
                player4.rankngPlayer = ranking;
                player4.go = false;
                ranking++;
            }
        }
    }
}
