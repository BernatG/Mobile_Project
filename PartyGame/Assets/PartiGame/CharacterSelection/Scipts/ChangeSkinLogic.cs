using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class ChangeSkinLogic : MonoBehaviour {

	private GameObject player1;
	private GameObject player2;
	private GameObject player3;
	private GameObject player4;

	public Dictionary<int, ChangeSkinPlayer> players = new Dictionary<int, ChangeSkinPlayer> ();
    int idPlayer = 0;

	void Awake () {

        DontDestroyOnLoad(this.gameObject);
        
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        
		AirConsole.instance.onMessage += OnMessage;		
		AirConsole.instance.onReady += OnReady;		
		AirConsole.instance.onConnect += OnConnect;
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
            players.Add(deviceID, player1.GetComponent<ChangeSkinPlayer>());
        }
        else if(idPlayer == 2)
        {
            player2.SetActive(true);
            players.Add(deviceID, player2.GetComponent<ChangeSkinPlayer>());

        }
        else if (idPlayer == 3)
        {
            player3.SetActive(true);
            players.Add(deviceID, player3.GetComponent<ChangeSkinPlayer>());

        }
        else if (idPlayer == 4)
        {
            player4.SetActive(true);
            players.Add(deviceID, player4.GetComponent<ChangeSkinPlayer>());
        }

    }

	void OnMessage (int from, JToken data){
		Debug.Log ("message: " + data);

		//When I get a message, I check if it's from any of the devices stored in my device Id dictionary
		if (players.ContainsKey (from) && data["action"] != null) {
            //I forward the command to the relevant player script, assigned by device ID
            players[from].ButtonInput(data["action"].ToString());
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
