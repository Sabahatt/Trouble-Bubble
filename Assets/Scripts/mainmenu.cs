using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    private void Start()
    {
        GameController.isLevelCleared = false;
    }
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
        GameController.lives = 5;
        ChainCollision.ballScore = 0;
        
    }

    public void QuitBtn()
    {
        Application.Quit();
    }
}
