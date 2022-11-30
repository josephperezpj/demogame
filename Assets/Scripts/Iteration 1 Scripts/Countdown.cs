using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    public float startingTime;

    [SerializeField] Text countdownText;
    [SerializeField] GameObject restartButton;
    [SerializeField] GameObject player;
    PlayerMovement playerMovement;


    void Start()
    {
        player = GameObject.Find("Player");
        currentTime = startingTime;
        restartButton.SetActive(false);
        playerMovement = player.GetComponent<PlayerMovement>();
    }


    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
            playerMovement.canMove = false;
            restartButton.SetActive(true);
        }

    }


    public void UpdateTime(float amount)
    {
        currentTime += amount;

    }

}

