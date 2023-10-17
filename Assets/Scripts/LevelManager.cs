using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
    }

    void Update()
    {
        LoadNextLevel();

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            Time.timeScale = 1f;
        }
        /*if (SceneManager.GetActiveScene().buildIndex == 4 && GameController.isLevelCleared)
        {
            SceneManager.LoadScene(5);
        }*/
    }

    public void LoadNextLevel()
    {
        if (GameController.isLevelCleared)
        {
            int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;

            if (nextLevelIndex <= SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextLevelIndex);
                GameController.isLevelCleared = false;
            }
/*
            if(nextLevelIndex == 4)
            {
                SceneManager.LoadScene(5);
            }*/

            
        }

    }

    

}
