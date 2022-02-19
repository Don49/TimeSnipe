using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Text pointsText;


    public void Setup(float scoreTime)
    {
        gameObject.SetActive(true);
        pointsText.text = scoreTime.ToString("F2") + "s";
    }

    public void retryButton()
    {
        Debug.Log("im clicked i swear");
        Time.timeScale = 1f;

        GameController.isPaused = false;
 
        Application.LoadLevel(1);
    }

    public void menuButton()
    {
        GameController.isPaused = false;
        Time.timeScale = 1f;
        Application.LoadLevel(0);
    }

    public void exit()
    {
        Application.Quit();
    }

}
