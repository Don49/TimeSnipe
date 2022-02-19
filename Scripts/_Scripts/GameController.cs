using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float currentScore;
    float countDown;
    float totalElapsedTime;

    float finalScore;
    float finalTime;

    public Text countDownText;
    public Text timerText;
    public Text enemyRemaing;


    public FirstPersonController fps;
    public GameOverControl gameOverCon;
    public GameOverControl gameWinCon;

    bool gameOver;

    public static bool isPaused;

    //public float[] highScores;
    List<float> highScores = new List<float>();

    GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        gameOver = false;
        currentScore = 0f;
        countDown = 60f;
        totalElapsedTime = 0f;
        isPaused = false;
        fps.GetComponent<FirstPersonController>().cameraCanMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("enemy");
      // Debug.Log("Current enemy : " + enemies.Length.ToString());
        enemyRemaing.text = enemies.Length.ToString() + " Enemies Remaining";
        //display num all the time here

        if (gameOver == false)
        {
                countDown -= Time.deltaTime;
                totalElapsedTime += Time.deltaTime;

          
            countDownText.text = countDown.ToString("F0") + "s Remain";
            timerText.text = totalElapsedTime.ToString("F0") + "s Have Passed";

                
            if(enemies.Length == 0)
            {
                gameOver = true;
                GameWin();
            }

              //   Debug.Log("countdown time : " + countDown);

           /* if(totalElapsedTime > 5 )
            {
                foreach(GameObject enemy in enemies)
                {
                    //  GameObject marker = enemy.find
                    //  GameObject child1 = enemy.transform.GetChild(0).gameObject;

                    //To find `child2` which is the second index(1)
                    //  GameObject child2 = enemy.transform.GetChild(1).gameObject;
                   enemy.transform.GetChild(2).gameObject.SetActive = true ;
                    //To find `child3` which is the third index(2)
                    int child3 = enemy.transform.childCount;
                        //.GetChild(2).gameObject;

                 //   Debug.Log("1 = " + child1.name);
                 //   Debug.Log("2 = " + child2.name);
                    Debug.Log("3 = " + child3);
                  
                    
                }
            }*/

             if (countDown < 0)
             {
                countDownText.text = "0s";
                gameOver = true;
                GameOver();
                
              }
          
         }

    }

    public void GameOver()
    {
        // canvas and bause game. menu to retry or go main menu

        // Remove control and pause


        isPaused = true;

        finalScore = currentScore;

        finalTime = totalElapsedTime;


        appendHighScores(finalTime);

        Cursor.lockState = CursorLockMode.None;

        fps.GetComponent<FirstPersonController>().cameraCanMove = false;

        gameOverCon.Setup(finalTime);

        Time.timeScale = 0f;
        //Debug.Log("finals are " + finalTime);


    }

    public void appendHighScores(float newScore)
    {
        highScores.Add(newScore);

    }

    public void DisplayHighScoreOrder()
    {

    }

    public void GameWin()
    {
        isPaused = true;
        finalTime = totalElapsedTime;
        appendHighScores(finalTime);
        fps.GetComponent<FirstPersonController>().cameraCanMove = false;
        Cursor.lockState = CursorLockMode.None;
        gameWinCon.Setup(finalTime);
        Time.timeScale = 0f;

    }

    public void AddScore(float num)
    {
        currentScore += num;
        Debug.Log("Current score : " + currentScore);
    }

    public void AddTime(float num)
    {
        countDown += num;
    }


}
