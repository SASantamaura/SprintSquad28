using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManagerScript : MonoBehaviour {

    public float timer;

    public float timerTimeLeftInSeconds;
    float timeleft;
    public GameObject timerTextBox;

    public GameObject[] pickupPrefabs = new GameObject[6];

    public GameObject[] pickupUIElements = new GameObject[6];

    public GameObject[] pickupSpawnPoints = new GameObject[12];
    bool gameover;

    void Awake () {

        for (int i = 0; i < pickupPrefabs.Length; i++)
        {           
            int mySpawnPoint = UnityEngine.Random.Range(0, 11);
            while (pickupSpawnPoints[mySpawnPoint] == null)
            {
                mySpawnPoint = UnityEngine.Random.Range(0, 11);
            }
            GameObject pickup = Instantiate(pickupPrefabs[i], pickupSpawnPoints[mySpawnPoint].transform.position, Quaternion.identity) as GameObject;//instantiate the pickups
            pickup.GetComponent<PickupScript>().ReceiveUIElement(pickupUIElements[i]);
            Array.Clear(pickupSpawnPoints, mySpawnPoint, 1);
        }

        gameover = false;
    }

    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        timeleft = timerTimeLeftInSeconds - timer;
        string minutes = Mathf.Floor((timeleft) / 60).ToString("00");
        string seconds = Mathf.Floor(((timeleft) % 60)).ToString("00");
        timerTextBox.GetComponent<Text>().text = minutes + ":" + seconds;
    }

    void Update()
    {
        if(!gameover)
        {
            UpdateTimer();
        }
        
        if(timeleft <= 0)
        {
            LoseGame();
        }
    }
    public void WinGame()
    {
        gameover = true;
        timerTextBox.GetComponent<Text>().text = "YOU WIN!";
    }

    public void LoseGame()
    {
        gameover = true;
        timerTextBox.GetComponent<Text>().text = "BACK TO WORK";
        Debug.Log("loser");
    }

}
