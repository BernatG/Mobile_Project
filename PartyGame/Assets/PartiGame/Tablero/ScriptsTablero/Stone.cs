using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NDream.AirConsole;

public class Stone : MonoBehaviour
{
    public Route currentRoute;

    public List<Player> players = new List<Player>();
    public List<Animator> animatorPlayer = new List<Animator>();

    public SmoothFollowCSharp mCFollowPlayer;

    int roundPlayer = -1;
    int round = 0;

    public int stepsPlayer1;
    public int stepsPlayer2;
    public int stepsPlayer3;
    public int stepsPlayer4;

    bool isMoving;

    private bool waitSecond = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {

        if(/*Input.GetKeyDown(KeyCode.Space) &&*/ !isMoving)
        {
            if(round == 0)
            {
                StartCoroutine(RandomMiniGame());
                round++;
            }
            else if (SceneManager.GetActiveScene().name == "SceneTablero" && !waitSecond)
            {
                roundPlayer++;
                Debug.Log("Le toca moverse al jugador: " + roundPlayer);
                if (roundPlayer >= 4) roundPlayer = -1;
               
                mCFollowPlayer.target = players[roundPlayer].transform;

                if (roundPlayer == 0)
                {
                    if (stepsPlayer1 != 0)
                    {
                        if (players[roundPlayer].routePosition + stepsPlayer1 < currentRoute.childNodeList.Count)
                        {
                            animatorPlayer[roundPlayer].SetBool("run", true);
                            StartCoroutine(Move(stepsPlayer1));

                        }
                        else
                        {
                            Debug.Log("Rolled Number is to high");
                        }
                        stepsPlayer1 = 0;
                    }
                }
                else if (roundPlayer == 1)
                {
                    if (stepsPlayer2 != 0)
                    {
                        if (players[roundPlayer].routePosition + stepsPlayer2 < currentRoute.childNodeList.Count)
                        {
                            animatorPlayer[roundPlayer].SetBool("run", true);
                            StartCoroutine(Move(stepsPlayer2));

                        }
                        else
                        {
                            Debug.Log("Rolled Number is to high");
                        }
                        stepsPlayer2 = 0;
                    }
                }
                else if (roundPlayer == 2)
                {
                    if (stepsPlayer3 != 0)
                    {
                        if (players[roundPlayer].routePosition + stepsPlayer3 < currentRoute.childNodeList.Count)
                        {
                            animatorPlayer[roundPlayer].SetBool("run", true);
                            StartCoroutine(Move(stepsPlayer3));

                        }
                        else
                        {
                            Debug.Log("Rolled Number is to high");
                        }
                        stepsPlayer3 = 0;
                    }
                }
                else if (roundPlayer == 3)
                {
                    if (stepsPlayer4 != 0)
                    {
                        if (players[roundPlayer].routePosition + stepsPlayer4 < currentRoute.childNodeList.Count)
                        {
                            animatorPlayer[roundPlayer].SetBool("run", true);
                            StartCoroutine(Move(stepsPlayer4));                         

                        }
                        else
                        {
                            Debug.Log("Rolled Number is to high");
                        }
                        stepsPlayer4 = 0;                        
                    }
                }
            }


        }
    }

    IEnumerator Move( int steps)
    {
        if(isMoving)
        {

            yield break;
        }
        isMoving = true;

        while(steps>0)
        {
            Vector3 nextPos = currentRoute.childNodeList[players[roundPlayer].routePosition + 1].position;

            Vector3 targetDirection =  currentRoute.childNodeList[players[roundPlayer].routePosition + 1].position - players[roundPlayer].transform.position;
            Quaternion rotation = Quaternion.LookRotation(targetDirection);

            
            while (MoveToRotateNode(rotation)) { yield return null; }
            while (MoveToNextNode(nextPos)) { yield return null; }
            

            //yield return new WaitForSeconds(0.1f);
            steps--;
            players[roundPlayer].routePosition++;
        }

        animatorPlayer[roundPlayer].SetBool("run", false);
        isMoving = false;
        if(roundPlayer == 3)
        {
            StartCoroutine(RandomMiniGame());
        }
    }

    IEnumerator RandomMiniGame()
    {
        waitSecond = true;
        yield return new WaitForSeconds(1);
        waitSecond = false;

        int ranom = Random.RandomRange(0, 1);
        switch (ranom)
        {
            case 0:
                List<int> connectedDevicesJumpAndDown = AirConsole.instance.GetControllerDeviceIds();
                foreach (int deviceID in connectedDevicesJumpAndDown)
                {
                    AirConsole.instance.Message(deviceID, "jumpAndDown");
                }
                SceneManager.LoadScene("SceneJumpAndDown");
                break;
            case 1:
                List<int> connectedDevicesBasket = AirConsole.instance.GetControllerDeviceIds();
                foreach (int deviceID in connectedDevicesBasket)
                {
                    AirConsole.instance.Message(deviceID, "gameBasket");
                }
                SceneManager.LoadScene("SceneBasket");
                break;
        }
    }

    bool MoveToRotateNode(Quaternion rota)
    {
        return rota != (players[roundPlayer].transform.rotation = Quaternion.Lerp(players[roundPlayer].transform.rotation, rota, 10f * Time.deltaTime));
    }

    bool MoveToNextNode(Vector3 goal)
    {

        
        return goal != (players[roundPlayer].transform.position = Vector3.MoveTowards(players[roundPlayer].transform.position, goal, 10f * Time.deltaTime));       

    }

    //void RandomMiniGame()
    //{
    //    int ranom = Random.RandomRange(0, 1);
    //    switch (ranom)
    //    {
    //        case 0:
    //            List<int> connectedDevicesJumpAndDown = AirConsole.instance.GetControllerDeviceIds();
    //            foreach (int deviceID in connectedDevicesJumpAndDown)
    //            {
    //                AirConsole.instance.Message(deviceID, "jumpAndDown");
    //            }
    //            SceneManager.LoadScene("SceneJumpAndDown");
    //            break;
    //        case 1:
    //            List<int> connectedDevicesBasket = AirConsole.instance.GetControllerDeviceIds();
    //            foreach (int deviceID in connectedDevicesBasket)
    //            {
    //                AirConsole.instance.Message(deviceID, "gameBasket");
    //            }
    //            SceneManager.LoadScene("SceneBasket");
    //            break;
    //    }
    //}
}
