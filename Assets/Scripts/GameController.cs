using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject gameOver;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("leveltest");
    }

    //public void GameOver()
    //{
    //    gameOver.SetActive(true);
    //}

    //public void RestartGame(string level)
    //{
    //    SceneManager.LoadScene(level);
    //}
}
