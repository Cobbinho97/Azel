using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    //After pressing the start game button, the next active scene will be loaded
    public void StartofGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // If quit game button is pressed, game is quited
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
}