using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBonus : MonoBehaviour
{

    GameObject timer;


    private void Start()
    {
        timer = GameObject.Find("CountdownTimer");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer.GetComponent<Countdown>().UpdateTime(4);
            Destroy(gameObject);
        }
    }
}
