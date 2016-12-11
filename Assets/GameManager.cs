using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text Score0Text;
    public Text Score1Text;
    public GameObject GameOver;

    public Button Restart;
    public Button Quit;

    public static bool IsGameOver;

    public static int Score0;
    public static int Score1;
    private const int ScoreLimit = 10;

	void Update ()
	{
	    Score0Text.text = Score0.ToString();
	    Score1Text.text = Score1.ToString();
	    if (Score0 >= ScoreLimit || Score1 >= ScoreLimit)
	    {
	        IsGameOver = true;
            GameOver.SetActive(true);
	    }
	}

    public void ResetGame()
    {
        Score0 = 0;
        Score1 = 0;
        IsGameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
