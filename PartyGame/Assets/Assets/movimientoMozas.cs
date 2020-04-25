using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoMozas : MonoBehaviour
{
    public int speed = 1;
    public Rigidbody rbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rbPlayer.MovePosition(rbPlayer.position + new )

        rbPlayer.MovePosition(new Vector3(transform.position.x, transform.position.y, transform.position.z - 10 * Time.deltaTime));

        //rbPlayer.velocity = Vector3.zero * 10;

        //rbPlayer.gameObject.transform.position.



    }
}
