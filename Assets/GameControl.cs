using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
     public GameObject timeIsUp, youWin, yourScore, restartButton;
     public TextMeshProUGUI text;

     public static bool GameIsPaused = false;

     public GameObject pauseMenuUI;

     

     // Start is called before the first frame update
     void Start()
    {
          Time.timeScale = 1;
     }

    // Update is called once per frame
    void Update()
    {
        if(TimeManager.timeLeft <= 0)
          {
               Time.timeScale = 0;
               timeIsUp.gameObject.SetActive(true);
               restartButton.gameObject.SetActive(true);
          }
        if (playerctrl.maxCitizen == 0)
          {
               
              Time.timeScale = 0;
              youWin.gameObject.SetActive(true);
              yourScore.gameObject.SetActive(true);
              text.text = "" + TimeManager.text.text;
              restartButton.gameObject.SetActive(true);

          }

        if (Input.GetKeyDown(KeyCode.Escape))
          {
               if (GameIsPaused)
               {
                    Resume();
               }
               else
               {
                    Pause();
               }
          }
    }

     public void restartScene()
     {
          timeIsUp.gameObject.SetActive(false);
          restartButton.gameObject.SetActive(false);
          Time.timeScale = 1f;
          TimeManager.timeLeft = 600f;
          SceneManager.LoadScene("SampleScene");

     }

    public void Resume()
     {
          pauseMenuUI.SetActive(false);
          Time.timeScale = 1f;
          GameIsPaused = false;
     }

     //Display PauseMenu

     public void Pause()
     {
          pauseMenuUI.SetActive(true);
          Time.timeScale = 0f;
          GameIsPaused = true;
     }

}
