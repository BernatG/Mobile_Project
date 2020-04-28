using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class RankingGame : MonoBehaviour
{
    List<Player_Platformer> players = new List<Player_Platformer>();
    int[] points = new int[4];

    public Player_Platformer player1;
    public Player_Platformer player2;
    public Player_Platformer player3;
    public Player_Platformer player4;

    public Image NumberRankingPlayer1;
    public Image NumberRankingPlayer2;
    public Image NumberRankingPlayer3;
    public Image NumberRankingPlayer4;

    private int pointsPlayer1 = 0;    
    private int pointsPlayer2 = 0;    
    private int pointsPlayer3 = 0;    
    private int pointsPlayer4 = 0;    

    public Sprite first;
    public Sprite second;
    public Sprite third;
    public Sprite fourth;

    private Stone stone;


    // Start is called before the first frame update
    void Start()
    {
        stone = (Stone)FindObjectOfType(typeof(Stone));

        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);

        for(int i = 0; i < players.Count; i++)
        {
            points[i] = players[i].points;
        }

        Array.Sort(points);
        Array.Reverse(points);

        for (int i = 0; i < players.Count; i++)
        {
            switch (i)
            {
                case 0:
                    if (points[i] == player1.points && pointsPlayer1 == 0)
                    {
                        NumberRankingPlayer1.sprite = first;
                        pointsPlayer1 = points[i];
                        Debug.Log("Primer ganador: Jugador 1");
                        stone.stepsPlayer1 = 4;
                    }
                    else if (points[i] == player2.points && pointsPlayer2 == 0)
                    {
                        NumberRankingPlayer2.sprite = first;
                        pointsPlayer2 = points[i];
                        Debug.Log("Primer ganador: Jugador 2");
                        stone.stepsPlayer2 = 4;
                    }
                    else if (points[i] == player3.points && pointsPlayer3 == 0)
                    {
                        NumberRankingPlayer3.sprite = first;
                        pointsPlayer3 = points[i];
                        Debug.Log("Primer ganador: Jugador 3");
                        stone.stepsPlayer3 = 4;
                    }
                    else if (points[i] == player4.points && pointsPlayer4 == 0)
                    {
                        NumberRankingPlayer4.sprite = first;
                        pointsPlayer4 = points[i];
                        Debug.Log("Primer ganador: Jugador 4");
                        stone.stepsPlayer4 = 4;
                    }
                    break;
                case 1:
                    if (points[i] == player1.points && pointsPlayer1 == 0)
                    {
                        NumberRankingPlayer1.sprite = second;
                        pointsPlayer1 = points[i];
                        Debug.Log("Segundo ganador: Jugador 1");
                        stone.stepsPlayer1 = 3;
                    }
                    else if (points[i] == player2.points && pointsPlayer2 == 0)
                    {
                        NumberRankingPlayer2.sprite = second;
                        pointsPlayer2 = points[i];
                        Debug.Log("Segundo ganador: Jugador 2");
                        stone.stepsPlayer2 = 3;
                    }
                    else if (points[i] == player3.points && pointsPlayer3 == 0)
                    {
                        NumberRankingPlayer3.sprite = second;
                        pointsPlayer3 = points[i];
                        Debug.Log("Segundo ganador: Jugador 3");
                        stone.stepsPlayer3 = 3;
                    }
                    else if (points[i] == player4.points && pointsPlayer4 == 0)
                    {
                        NumberRankingPlayer4.sprite = second;
                        pointsPlayer4 = points[i];
                        Debug.Log("Segundo ganador: Jugador 4");
                        stone.stepsPlayer4 = 3;
                    }
                    break;
                case 2:
                    if (points[i] == player1.points && pointsPlayer1 == 0)
                    {
                        NumberRankingPlayer1.sprite = third;
                        pointsPlayer1 = points[i];
                        Debug.Log("Tercer ganador: Jugador 1");
                        stone.stepsPlayer1 = 2;
                    }
                    else if (points[i] == player2.points && pointsPlayer2 == 0)
                    {
                        NumberRankingPlayer2.sprite = third;
                        pointsPlayer2 = points[i];
                        Debug.Log("Tercer ganador: Jugador 2");
                        stone.stepsPlayer2 = 2;
                    }
                    else if (points[i] == player3.points && pointsPlayer3 == 0)
                    {
                        NumberRankingPlayer3.sprite = third;
                        pointsPlayer3 = points[i];
                        Debug.Log("Tercer ganador: Jugador 3");
                        stone.stepsPlayer3 = 2;
                    }
                    else if (points[i] == player4.points && pointsPlayer4 == 0)
                    {
                        NumberRankingPlayer4.sprite = third;
                        pointsPlayer4 = points[i];
                        Debug.Log("Tercer ganador: Jugador 4");
                        stone.stepsPlayer4 = 2;
                    }
                    break;
                case 3:
                    if (points[i] == player1.points && pointsPlayer1 == 0)
                    {
                        NumberRankingPlayer1.sprite = fourth;
                        pointsPlayer1 = points[i];
                        Debug.Log("Quarto ganador: Jugador 1");
                        stone.stepsPlayer1 = 1;

                        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
                        foreach (int deviceID in connectedDevices)
                        {
                            AirConsole.instance.Message(deviceID, "tablero");
                        }

                        SceneManager.LoadScene("SceneTablero");
                    }
                    else if (points[i] == player2.points && pointsPlayer2 == 0)
                    {
                        NumberRankingPlayer2.sprite = fourth;
                        pointsPlayer2 = points[i];
                        Debug.Log("Quarto ganador: Jugador 2");
                        stone.stepsPlayer2 = 1;

                        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
                        foreach (int deviceID in connectedDevices)
                        {
                            AirConsole.instance.Message(deviceID, "tablero");
                        }

                        SceneManager.LoadScene("SceneTablero");
                    }
                    else if (points[i] == player3.points && pointsPlayer3 == 0)
                    {
                        NumberRankingPlayer3.sprite = fourth;
                        pointsPlayer3 = points[i];
                        Debug.Log("Quarto ganador: Jugador 3");
                        stone.stepsPlayer3 = 1;

                        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
                        foreach (int deviceID in connectedDevices)
                        {
                            AirConsole.instance.Message(deviceID, "tablero");
                        }

                        SceneManager.LoadScene("SceneTablero");
                    }
                    else if (points[i] == player4.points && pointsPlayer4 == 0)
                    {
                        NumberRankingPlayer4.sprite = fourth;
                        pointsPlayer4 = points[i];
                        Debug.Log("Quarto ganador: Jugador 4");
                        stone.stepsPlayer4 = 1;

                        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
                        foreach (int deviceID in connectedDevices)
                        {
                            AirConsole.instance.Message(deviceID, "tablero");
                        }

                        SceneManager.LoadScene("SceneTablero");
                    }
                    break;
            }
        }
    }
    
}
