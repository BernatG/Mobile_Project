using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NDream.AirConsole;

public class LogicStartGame : MonoBehaviour
{
    public Player player1;
    public Player player2;
    public Player player3;
    public Player player4;

    public Image imagePlayer1;
    public Image imagePlayer2;
    public Image imagePlayer3;
    public Image imagePlayer4;

    public GameObject stone; 
    // Start is called before the first frame update
    void Start()
    {
        stone.SetActive(false);
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
                AirConsole.instance.Message(deviceID, "tablero");
            }
            gameObject.SetActive(false);
            stone.SetActive(true);
        }
    }
}
