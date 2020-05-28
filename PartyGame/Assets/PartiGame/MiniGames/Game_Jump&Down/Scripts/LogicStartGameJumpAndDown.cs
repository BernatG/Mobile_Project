using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NDream.AirConsole;

public class LogicStartGameJumpAndDown : MonoBehaviour
{
    public PlayerController_JumpAndDown player1;
    public PlayerController_JumpAndDown player2;
    public PlayerController_JumpAndDown player3;
    public PlayerController_JumpAndDown player4;

    public Image imagePlayer1;
    public Image imagePlayer2;
    public Image imagePlayer3;
    public Image imagePlayer4;

    public TextMeshProUGUI textNamePlayer1;
    public TextMeshProUGUI textNamePlayer2;
    public TextMeshProUGUI textNamePlayer3;
    public TextMeshProUGUI textNamePlayer4;

    public GameObject timeGame;
    public GameObject canvasRedy;
    public GameObject canvasTime;

    private ChangeSkinPlayer namePlayer1;
    private ChangeSkinPlayer namePlayer2;
    private ChangeSkinPlayer namePlayer3;
    private ChangeSkinPlayer namePlayer4;

    // Start is called before the first frame update
    void Start()
    {
        timeGame.SetActive(false);
        canvasRedy.SetActive(true);
        canvasTime.SetActive(false);

        namePlayer1 = GameObject.Find("Player1Skin").GetComponent<ChangeSkinPlayer>();
        textNamePlayer1.text = namePlayer1.nickName;

        namePlayer2 = GameObject.Find("Player2Skin").GetComponent<ChangeSkinPlayer>();
        textNamePlayer2.text = namePlayer2.nickName;

        namePlayer3 = GameObject.Find("Player3Skin").GetComponent<ChangeSkinPlayer>();
        textNamePlayer3.text = namePlayer3.nickName;

        namePlayer4 = GameObject.Find("Player4Skin").GetComponent<ChangeSkinPlayer>();
        textNamePlayer4.text = namePlayer4.nickName;
    }

    // Update is called once per frame
    void Update()
    {
        if (player1.ready)
        {
            imagePlayer1.color = Color.green;
        }

        if (player2.ready)
        {
            imagePlayer2.color = Color.green;
        }

        if (player3.ready)
        {
            imagePlayer3.color = Color.green;
        }

        if (player4.ready)
        {
            imagePlayer4.color = Color.green;
        }

        if (player1.ready && player2.ready && player3.ready && player4.ready)
        {
            List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
            foreach (int deviceID in connectedDevices)
            {
                AirConsole.instance.Message(deviceID, "jumpAndDown");
            }

            timeGame.SetActive(true);
            canvasRedy.SetActive(false);
            canvasTime.SetActive(true);
            Destroy(gameObject);
        }
    }
}
