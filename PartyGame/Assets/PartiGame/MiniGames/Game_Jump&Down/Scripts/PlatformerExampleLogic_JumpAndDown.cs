using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class PlatformerExampleLogic_JumpAndDown : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

    public GameObject timeGame;

	public Dictionary<int, PlayerController_JumpAndDown> players = new Dictionary<int, PlayerController_JumpAndDown> ();
    int idPlayer = 0;

    void Awake () {
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        timeGame.SetActive(false);
		AirConsole.instance.onMessage += OnMessage;		
		AirConsole.instance.onReady += OnReady;		
		AirConsole.instance.onConnect += OnConnect;

        List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();

        player1.SetActive(true);
        players.Add(connectedDevices[0], player1.GetComponent<PlayerController_JumpAndDown>());
        
        player2.SetActive(true);
        players.Add(connectedDevices[1], player2.GetComponent<PlayerController_JumpAndDown>());

        player3.SetActive(true);
        players.Add(connectedDevices[2], player3.GetComponent<PlayerController_JumpAndDown>());

        player4.SetActive(true);
        players.Add(connectedDevices[3], player4.GetComponent<PlayerController_JumpAndDown>());
        timeGame.SetActive(true);
                
    }

	void OnReady(string code){
		//Since people might be coming to the game from the AirConsole store once the game is live, 
		//I have to check for already connected devices here and cannot rely only on the OnConnect event 
		List<int> connectedDevices = AirConsole.instance.GetControllerDeviceIds();
		foreach (int deviceID in connectedDevices) {
			AddNewPlayer (deviceID);
		}
	}

	void OnConnect (int device){
        if (idPlayer < 4)
        {
            AddNewPlayer(device);
        }
	}

    private void AddNewPlayer(int deviceID)
    {

        if (players.ContainsKey(deviceID))
        {
            return;
        }

        idPlayer += 1;

        if (idPlayer == 1)
        {
            player1.SetActive(true);
            players.Add(deviceID, player1.GetComponent<PlayerController_JumpAndDown>());
        }
        else if(idPlayer == 2)
        {
            player2.SetActive(true);
            players.Add(deviceID, player2.GetComponent<PlayerController_JumpAndDown>());

        }
        else if (idPlayer == 3)
        {
            player3.SetActive(true);
            players.Add(deviceID, player3.GetComponent<PlayerController_JumpAndDown>());

        }
        else if (idPlayer == 4)
        {
            player4.SetActive(true);
            players.Add(deviceID, player4.GetComponent<PlayerController_JumpAndDown>());
            timeGame.SetActive(true);
        }

    }

	void OnMessage (int from, JToken data){
		Debug.Log ("message: " + data);

		//When I get a message, I check if it's from any of the devices stored in my device Id dictionary
		if (players.ContainsKey (from) && data["action"] != null) {
			//I forward the command to the relevant player script, assigned by device ID
			players [from].ButtonInput (data["action"].ToString());
		}
	}

	void OnDestroy () {
		if (AirConsole.instance != null) {
			AirConsole.instance.onMessage -= OnMessage;		
			AirConsole.instance.onReady -= OnReady;		
			AirConsole.instance.onConnect -= OnConnect;		
		}
	}
}
