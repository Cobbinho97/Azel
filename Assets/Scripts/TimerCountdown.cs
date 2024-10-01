using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;

    public int secondsLeft = 30;

    public bool takingAway = false;

    public GameObject gameOverScreen;

    public FirstPersonMovement player;

    public float waitAfterGameOver;

    public string mainMenu;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "Time Left 00:" + secondsLeft;

        player = FindObjectOfType<FirstPersonMovement>();
    }

    void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

        if (secondsLeft <= 0)
        {
            gameOverScreen.SetActive(true);
            player.gameObject.SetActive(false);
        }

        if (gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }

        if (waitAfterGameOver < 0)
        {
            Application.LoadLevel(mainMenu);
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "Time Left 00:0" + secondsLeft;
        }
        else
        {
            textDisplay.GetComponent<Text>().text = "Time Left 00:" + secondsLeft;
        }
        takingAway = false;
    }
}
