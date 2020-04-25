using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Route currentRoute;

    public List<Player> players = new List<Player>();

    public SmoothFollowCSharp mCFollowPlayer;

    int roundPlayer = -1;

    public int steps;

    bool isMoving;

    private void Update()
    {

        if(/*Input.GetKeyDown(KeyCode.Space) &&*/ !isMoving)
        {
            roundPlayer++;            
            if (roundPlayer == 4) roundPlayer = 0;
            mCFollowPlayer.target = players[roundPlayer].transform;

            steps = Random.Range(1, 7);
            Debug.Log("Dice Rolled " + steps);

            if(players[roundPlayer].routePosition+steps < currentRoute.childNodeList.Count)
            {
                Debug.Log(players[roundPlayer].routePosition);
                StartCoroutine(Move());

            }           
            else
            {
                Debug.Log("Rolled Number is to high");
            }      
            
        }
    }

    IEnumerator Move()
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
            

            yield return new WaitForSeconds(0.1f);
            steps--;
            players[roundPlayer].routePosition++;
        }

        isMoving = false;
    }

    bool MoveToRotateNode(Quaternion rota)
    {
        return rota != (players[roundPlayer].transform.rotation = Quaternion.Lerp(players[roundPlayer].transform.rotation, rota, 10f * Time.deltaTime));
    }

    bool MoveToNextNode(Vector3 goal)
    {

        
        return goal != (players[roundPlayer].transform.position = Vector3.MoveTowards(players[roundPlayer].transform.position, goal, 10f * Time.deltaTime));       

    }
}
