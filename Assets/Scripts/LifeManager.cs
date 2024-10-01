using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int startingLives;

    private int lifeCounter;

    private Text lifeText;

    public GameObject gameOverScreen;

    public FirstPersonMovement player;

    public string mainMenu;

    public float waitAfterGameOver;

    void Start()
    {
        lifeText = GetComponent<Text>();

        lifeCounter = startingLives;

        player = FindObjectOfType<FirstPersonMovement>();
    }

    void Update()
    {
        if(lifeCounter < 0)
        {
            gameOverScreen.SetActive(true);
        }
        lifeText.text = "x " + lifeCounter;

        if(gameOverScreen.activeSelf)
        {
            waitAfterGameOver -= Time.deltaTime;
        }

        if(waitAfterGameOver < 0)
        {
            Application.LoadLevel(mainMenu);
        }
    }

    public void TakeLife()
    {
        lifeCounter--;
    }
}
