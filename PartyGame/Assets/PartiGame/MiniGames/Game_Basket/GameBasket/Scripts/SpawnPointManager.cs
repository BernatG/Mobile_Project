using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnPointManager : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameObject spawnPrefabLessPoints;
    public SpawnPoint[] spawnPoints;
    public SpawnPoint[] spawnPointsLess;
    public Move move1;
    public Move2 move2;
    private int spawnPos;
    public float spawnTime;
    public bool spawnIsActive;
    public int numSpawnObjects;
    public Text TextLose;
    public Text TextReload;
    public Text TextMenu;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    void Awake()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        spawnPointsLess = FindObjectsOfType<SpawnPoint>();
    }

    public void StartSpawning()
    {
        spawnIsActive = true;
        StartCoroutine(spawnObject());
        StartCoroutine(spawnObjectBad());
    }

    IEnumerator spawnObject()
    {
        yield return new WaitForSeconds(spawnTime);
        numSpawnObjects--;
        if (numSpawnObjects <= 0)
        {
            spawnIsActive = false;
        }
        if (spawnIsActive)
        {
            spawnPos = Random.Range(0, spawnPoints.Length - 1);
            //Debug.Log("Pelota");
            
            Instantiate(spawnPrefab, spawnPoints[spawnPos].transform.position + new Vector3(Random.Range(0,1.5f), Random.Range(0, 1.5f), Random.Range(0, 1.5f)), Quaternion.identity);            
            StartCoroutine(spawnObject());
        }
    }

    IEnumerator spawnObjectBad()
    {
        yield return new WaitForSeconds(spawnTime);
        numSpawnObjects--;
        if (numSpawnObjects <= 0)
        {
            spawnIsActive = false;
        }
        if (spawnIsActive)
        {
            spawnPos = Random.Range(0, spawnPointsLess.Length - 1);
            //Debug.Log("Pelota");
            Instantiate(spawnPrefabLessPoints, spawnPointsLess[spawnPos].transform.position, Quaternion.identity);
            StartCoroutine(spawnObjectBad());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numSpawnObjects <= 0)
        {
            spawnIsActive = false;
            TextLose.text = "All Players Lose";
            TextReload.text = "Press R to play again";
            TextMenu.text = "Press Esc to go to the Menu";

            move1.speed = 0;
            move2.speed = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    
}
