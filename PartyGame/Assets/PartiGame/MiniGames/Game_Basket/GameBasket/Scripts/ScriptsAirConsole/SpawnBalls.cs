using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public GameObject ballBasket;
    public GameObject ballBomb;

    Clock clock;

    [SerializeField]
    private float spawnBallTime= 1f;

    // Start is called before the first frame update
    void Start()
    {
        clock = new Clock();
    }

    // Update is called once per frame
    void Update()
    {
        if (clock.getTime() > spawnBallTime)
        {
            int randomBall = Random.Range(0, 100);
            int randomPosX = Random.Range(-12, 12);
            int randomPosZ = Random.Range(-9, 9);           

            if (randomBall < 89)
            {
                //insProj = Instantiate(ballBasket, transform.position, transform.rotation);
                GameObject insProj = Instantiate(ballBasket, transform.position, transform.rotation); ;
                insProj.transform.localPosition = new Vector3(randomPosX, 18, randomPosZ);

            }
            else if (randomBall > 90)
            {
                //insProj = Instantiate(ballBomb, transform.position, transform.rotation);
                GameObject insProj = Instantiate(ballBomb, transform.position, transform.rotation);
                insProj.transform.localPosition = new Vector3(randomPosX, 18, randomPosZ);
            }
            
            clock.reset();
        }
    }
}
