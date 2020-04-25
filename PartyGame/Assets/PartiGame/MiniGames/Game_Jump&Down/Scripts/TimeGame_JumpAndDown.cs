using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeGame_JumpAndDown : MonoBehaviour
{
    Clock clock;
    private float time;
    bool startGame;

    public GameObject startGameGo;
    public TextMeshProUGUI textStartGame;
    public CylinderController cylinderController;

    // Start is called before the first frame update
    void Start()
    {
        clock = new Clock();
        startGame = true;
        startGameGo.SetActive(true);
        time = 15;
        textStartGame.text = time.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(startGame)
        {
            if (clock.getTime() >= 1f)
            {
                time -= 1;
                textStartGame.text = time.ToString();
                if (time == 0)
                {
                    startGame = false;
                    startGameGo.SetActive(false);
                    cylinderController.rotation = 1;
                    cylinderController.rotationAddition = 0.1f;

                }
                clock.reset();
            }
        }
        
    }
}
