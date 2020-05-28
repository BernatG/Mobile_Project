using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using NDream.AirConsole;
using TMPro;

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

    public int minijuego = 0;

    LevelLoader levelLoader;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        for (int i = 0; i < players.Count; i++ )
        {
            if (i == 0)
            {
                animatorPlayer[i] = GameObject.Find("Player1").GetComponentInChildren<Animator>();
            }
            if (i == 1)
            {
                animatorPlayer[i] = GameObject.Find("Player2").GetComponentInChildren<Animator>();
            }
            if (i == 2)
            {
                animatorPlayer[i] = GameObject.Find("Player3").GetComponentInChildren<Animator>();
            }
            if (i == 3)
            {
                animatorPlayer[i] = GameObject.Find("Player4").GetComponentInChildren<Animator>();
            }
        }

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
                if (roundPlayer >= 4) roundPlayer = 0;
               
                //mCFollowPlayer.target = players[roundPlayer].transform;

                if (roundPlayer == 0)
                {
                    if (stepsPlayer1 != 0)
                    {
                        mCFollowPlayer.target = players[roundPlayer].transform;

                        if (players[roundPlayer].routePosition + stepsPlayer1 < currentRoute.childNodeList.Count)
                        {
                            
                            animatorPlayer[roundPlayer].SetBool("run", true);
                            StartCoroutine(Move(stepsPlayer1));

                        }
                        else
                        {
                            StartCoroutine(Move(0));
                        }
                        stepsPlayer1 = 0;
                    }
                }
                else if (roundPlayer == 1)
                {
                    if (stepsPlayer2 != 0)
                    {

                        mCFollowPlayer.target = players[roundPlayer].transform;
                        if (players[roundPlayer].routePosition + stepsPlayer2 < currentRoute.childNodeList.Count)
                        {
                            animatorPlayer[roundPlayer].SetBool("run", true);
                            StartCoroutine(Move(stepsPlayer2));

                        }
                        else
                        {
                            StartCoroutine(Move(0));
                        }
                        stepsPlayer2 = 0;
                    }
                }
                else if (roundPlayer == 2)
                {
                    if (stepsPlayer3 != 0)
                    {

                        mCFollowPlayer.target = players[roundPlayer].transform;
                        if (players[roundPlayer].routePosition + stepsPlayer3 < currentRoute.childNodeList.Count)
                        {
                            animatorPlayer[roundPlayer].SetBool("run", true);
                            StartCoroutine(Move(stepsPlayer3));

                        }
                        else
                        {
                            StartCoroutine(Move(0));
                        }
                        stepsPlayer3 = 0;
                    }
                }
                else if (roundPlayer == 3)
                {
                    if (stepsPlayer4 != 0)
                    {

                        mCFollowPlayer.target = players[roundPlayer].transform;
                        if (players[roundPlayer].routePosition + stepsPlayer4 < currentRoute.childNodeList.Count)
                        {
                            animatorPlayer[roundPlayer].SetBool("run", true);
                            StartCoroutine(Move(stepsPlayer4));                         

                        }
                        else
                        {
                            StartCoroutine(Move(0));
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
            Debug.Log("hoolllaaaa");
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


        if (players[roundPlayer].routePosition == 3|| players[roundPlayer].routePosition == 5 || players[roundPlayer].routePosition == 11)
        {
            yield return new WaitForSeconds(1.5f);

            steps = 1;
            while (steps > 0)
            {
                Vector3 nextPosRetroceder = currentRoute.childNodeList[players[roundPlayer].routePosition - 1].position;
                Vector3 targetDirectionRetroceder = currentRoute.childNodeList[players[roundPlayer].routePosition - 1].position - players[roundPlayer].transform.position;
                Quaternion rotationRetroceder = Quaternion.LookRotation(targetDirectionRetroceder);

                //while (MoveToRotateNode(rotationRetroceder)) { yield return null; } 
                players[roundPlayer].transform.LookAt(nextPosRetroceder);
                while (MoveToNextNode(nextPosRetroceder)) { yield return null; }

                nextPosRetroceder = currentRoute.childNodeList[players[roundPlayer].routePosition + 1].position;
                players[roundPlayer].transform.LookAt(nextPosRetroceder);

                steps--;
                players[roundPlayer].routePosition--;
            }
        }

        if(players[roundPlayer].routePosition == 1 || players[roundPlayer].routePosition == 8)
        {
            yield return new WaitForSeconds(1.5f);

            steps = 1;
            while (steps > 0)
            {
                Vector3 nextPos = currentRoute.childNodeList[players[roundPlayer].routePosition + 1].position;

                Vector3 targetDirection = currentRoute.childNodeList[players[roundPlayer].routePosition + 1].position - players[roundPlayer].transform.position;
                Quaternion rotation = Quaternion.LookRotation(targetDirection);


                while (MoveToRotateNode(rotation)) { yield return null; }
                while (MoveToNextNode(nextPos)) { yield return null; }


                steps--;
                players[roundPlayer].routePosition++;
            }
        }

        if (players[roundPlayer].routePosition == 12)       
        {
            Vector3 nextPosRetroceder = currentRoute.childNodeList[players[roundPlayer].routePosition - 1].position;

            players[roundPlayer].transform.LookAt(nextPosRetroceder);

            TextMeshProUGUI textWiner = GameObject.Find("TextWin").GetComponent<TextMeshProUGUI>();

            string playerWin = "Player" + (roundPlayer + 1) + "Skin";
            ChangeSkinPlayer namePlayer = GameObject.Find(playerWin).GetComponent<ChangeSkinPlayer>();
            textWiner.text = "The Winer is " + namePlayer.nickName;

            yield return new WaitForSeconds(5f);

            foreach (GameObject go in GameObject.FindGameObjectsWithTag("dontdestroy"))
            {
                Destroy(go);
            }

            List<int> connectedDevicesJumpAndDown = AirConsole.instance.GetControllerDeviceIds();
            foreach (int deviceID in connectedDevicesJumpAndDown)
            {
                AirConsole.instance.Message(deviceID, "changeSkin");
            }

            SceneManager.LoadScene(0);
        }

        animatorPlayer[roundPlayer].SetBool("run", false);
        yield return new WaitForSeconds(1.5f);
        isMoving = false;

        if (roundPlayer == 3)
        {
            StartCoroutine(RandomMiniGame());
        }
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }

    IEnumerator RandomMiniGame()
    {
        waitSecond = true;
        yield return new WaitForSeconds(1);
        waitSecond = false;

        //int random = Random.Range(0, 3);
        //int random = 1;
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        if (minijuego >= 3) minijuego = 0;

        switch (minijuego)
        {
            case 0:
                List<int> connectedDevicesSwiming = AirConsole.instance.GetControllerDeviceIds();
                foreach (int deviceID in connectedDevicesSwiming)
                {
                    AirConsole.instance.Message(deviceID, "tableroReady");
                }
                SceneManager.LoadScene(3);
                break;
            case 1:
                List<int> connectedDevicesJumpAndDown = AirConsole.instance.GetControllerDeviceIds();
                foreach (int deviceID in connectedDevicesJumpAndDown)
                {
                    AirConsole.instance.Message(deviceID, "tableroReady");
                }
                SceneManager.LoadScene(4);
                break;
            case 2:
                List<int> connectedDevicesBasket = AirConsole.instance.GetControllerDeviceIds();
                foreach (int deviceID in connectedDevicesBasket)
                {
                    AirConsole.instance.Message(deviceID, "tableroReady");
                }
                SceneManager.LoadScene(5);
                break;
        }

        minijuego++;
    }

    bool MoveToRotateNode(Quaternion rota)
    {
        return rota != (players[roundPlayer].transform.rotation = Quaternion.Lerp(players[roundPlayer].transform.rotation, rota, 30f * Time.deltaTime));
    }

    bool MoveToNextNode(Vector3 goal)
    {        
        return goal != (players[roundPlayer].transform.position = Vector3.MoveTowards(players[roundPlayer].transform.position, goal, 10f * Time.deltaTime));       
    }

}
