using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class RankingGameSwiming : MonoBehaviour
{
    public PlayerSwiming player1;
    public PlayerSwiming player2;
    public PlayerSwiming player3;
    public PlayerSwiming player4;

    public Image NumberRankingPlayer1;
    public Image NumberRankingPlayer2;
    public Image NumberRankingPlayer3;
    public Image NumberRankingPlayer4;

    public Sprite first;
    public Sprite second;
    public Sprite third;
    public Sprite fourth;

    private Stone stone;

    public Meta meta;


    // Start is called before the first frame update
    void Start()
    {
        stone = (Stone)FindObjectOfType(typeof(Stone));


        switch (player1.rankngPlayer)
        {
            case 0:
                switch (meta.ranking)
                {
                    case 1:
                        NumberRankingPlayer1.sprite = first;
                        stone.stepsPlayer1 = 4;
                        meta.ranking++;
                        break;
                    case 2:
                        NumberRankingPlayer1.sprite = second;
                        stone.stepsPlayer1 = 3;
                        meta.ranking++;
                        break;
                    case 3:
                        NumberRankingPlayer1.sprite = third;
                        stone.stepsPlayer1 = 2;
                        meta.ranking++;
                        break;
                    case 4:
                        NumberRankingPlayer1.sprite = fourth;
                        stone.stepsPlayer1 = 1;
                        meta.ranking++;
                        break;
                }
                break;
            case 1:
                NumberRankingPlayer1.sprite = first;
                stone.stepsPlayer1 = 4;
                break;
            case 2:
                NumberRankingPlayer1.sprite = second;
                stone.stepsPlayer1 = 3;
                break;
            case 3:
                NumberRankingPlayer1.sprite = third;
                stone.stepsPlayer1 = 2;
                break;
            case 4:
                NumberRankingPlayer1.sprite = fourth;
                stone.stepsPlayer1 = 1;
                break;
        }

        switch (player2.rankngPlayer)
        {
            case 0:
                switch (meta.ranking)
                {
                    case 1:
                        NumberRankingPlayer2.sprite = first;
                        stone.stepsPlayer2 = 4;
                        meta.ranking++;
                        break;
                    case 2:
                        NumberRankingPlayer2.sprite = second;
                        stone.stepsPlayer2 = 3;
                        meta.ranking++;
                        break;
                    case 3:
                        NumberRankingPlayer2.sprite = third;
                        stone.stepsPlayer2 = 2;
                        meta.ranking++;
                        break;
                    case 4:
                        NumberRankingPlayer2.sprite = fourth;
                        stone.stepsPlayer2 = 1;
                        meta.ranking++;
                        break;
                }
                break;
            case 1:
                NumberRankingPlayer2.sprite = first;
                stone.stepsPlayer2 = 4;
                break;
            case 2:
                NumberRankingPlayer2.sprite = second;
                stone.stepsPlayer2 = 3;
                break;
            case 3:
                NumberRankingPlayer2.sprite = third;
                stone.stepsPlayer2 = 2;
                break;
            case 4:
                NumberRankingPlayer2.sprite = fourth;
                stone.stepsPlayer2 = 1;
                break;
        }

        switch (player3.rankngPlayer)
        {
            case 0:
                switch (meta.ranking)
                {
                    case 1:
                        NumberRankingPlayer3.sprite = first;
                        stone.stepsPlayer3 = 4;
                        meta.ranking++;
                        break;
                    case 2:
                        NumberRankingPlayer3.sprite = second;
                        stone.stepsPlayer3 = 3;
                        meta.ranking++;
                        break;
                    case 3:
                        NumberRankingPlayer3.sprite = third;
                        stone.stepsPlayer3 = 2;
                        meta.ranking++;
                        break;
                    case 4:
                        NumberRankingPlayer3.sprite = fourth;
                        stone.stepsPlayer3 = 1;
                        meta.ranking++;
                        break;
                }
                break;
            case 1:
                NumberRankingPlayer3.sprite = first;
                stone.stepsPlayer3 = 4;
                break;
            case 2:
                NumberRankingPlayer3.sprite = second;
                stone.stepsPlayer3 = 3;
                break;
            case 3:
                NumberRankingPlayer3.sprite = third;
                stone.stepsPlayer3 = 2;
                break;
            case 4:
                NumberRankingPlayer3.sprite = fourth;
                stone.stepsPlayer3 = 1;
                break;
        }

        switch (player4.rankngPlayer)
        {
            case 0:
                switch (meta.ranking)
                {
                    case 1:
                        NumberRankingPlayer4.sprite = first;
                        stone.stepsPlayer4 = 4;
                        meta.ranking++;
                        break;
                    case 2:
                        NumberRankingPlayer4.sprite = second;
                        stone.stepsPlayer4 = 3;
                        meta.ranking++;
                        break;
                    case 3:
                        NumberRankingPlayer4.sprite = third;
                        stone.stepsPlayer4 = 2;
                        meta.ranking++;
                        break;
                    case 4:
                        NumberRankingPlayer4.sprite = fourth;
                        stone.stepsPlayer4 = 1;
                        meta.ranking++;
                        break;
                }
                break;
            case 1:
                NumberRankingPlayer4.sprite = first;
                stone.stepsPlayer4 = 4;
                break;
            case 2:
                NumberRankingPlayer4.sprite = second;
                stone.stepsPlayer4 = 3;
                break;
            case 3:
                NumberRankingPlayer4.sprite = third;
                stone.stepsPlayer4 = 2;
                break;
            case 4:
                NumberRankingPlayer4.sprite = fourth;
                stone.stepsPlayer4 = 1;
                
                break;
        }
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(5);

        List<int> connectedDevicesJumpAndDown = AirConsole.instance.GetControllerDeviceIds();
        foreach (int deviceID in connectedDevicesJumpAndDown)
        {
            AirConsole.instance.Message(deviceID, "tablero");
        }

        SceneManager.LoadScene("SceneTablero");
    }
}
