using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameController : MonoBehaviour
{
    private Slider timerBar;

    public static int lives = 5;

    private float timerBarValue = 1f;
    private float timerBarStartTime = 1f;

    [SerializeField] private float timeBarSpeed = 0.05f;
    [SerializeField] private float finishTimeBarSpeed = 0.5f;

    public static bool isPlaying = false;
    public static bool isLevelCleared;
    private bool ballsExistInScene = true;

    [SerializeField] private TextMeshProUGUI timeUpText;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI levelClearText;
    [SerializeField] private TextMeshProUGUI pausedText;
    [SerializeField] private TextMeshProUGUI scoreText;
    //[SerializeField] private TextMeshProUGUI comboText;

    [SerializeField] private Button unpauseBtn;
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button restartBtn;
    //[SerializeField] private Button nextLevelBtn;


    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private GameObject ball;
    
    public GameObject life1, life2, life3, life4, life5;

    [SerializeField] private Rigidbody2D playerBody;

    public AudioSource src;
    public AudioClip levelClear, gameOver;

    

    //public static Animator anim;

    private void Awake()
    {
        timerBar = GameObject.Find("TimerBar").GetComponent<Slider>();

        timerBar.value = timerBarValue;

        Time.timeScale = 1f;

        /*life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        life4.gameObject.SetActive(true);
        life5.gameObject.SetActive(true);*/


        isPlaying = true;
        isLevelCleared = false;
    }
    void Start()
    {
 
    }

    private void Update()
    {
        scoreText.text = "Score: " + ChainCollision.ballScore.ToString();

       

        switch (lives)
        {
            case 5:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(true);
                break;
            case 4:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(false);

               // Restart();

                break;
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                break;
            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                break;
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                isPlaying = false;
                break;
        }

    }

    private void FixedUpdate()
    {

        ball = GameObject.FindWithTag("Ball");

        if (ball == null)
        {
            ballsExistInScene = false;
        }

        /*if (BallManager.activeBalls.Count == 0)
        {
            ballsExistInScene = false;
        }*/

        if (isPlaying)
        {
            Timer();
        }
        else
        {
            GameOver();
        }

        if (timerBarStartTime >= timerBar.minValue && !ballsExistInScene)
        {
           // src.PlayOneShot(levelClear);
            StartCoroutine(LevelCleared());
        }
        
 

    }

    public void Timer()
    {
        if (timerBarStartTime <= timerBar.minValue && ballsExistInScene)
        {
            src.PlayOneShot(gameOver);

            lives--;

            gameOverPanel.gameObject.SetActive(true);

            gameOverText.gameObject.SetActive(false);
            timeUpText.gameObject.SetActive(true);
            pausedText.gameObject.SetActive(false);

            unpauseBtn.gameObject.SetActive(false);
            pauseBtn.gameObject.SetActive(false);
            restartBtn.gameObject.SetActive(true);

            Time.timeScale = 0f;
        }
        else
        {
            timerBarStartTime -= Time.deltaTime * timeBarSpeed;
            timerBar.value = timerBarStartTime;
        }
        
    }

    public void GameOver()
    {
        src.PlayOneShot(gameOver);

        gameOverPanel.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(true);
        timeUpText.gameObject.SetActive(false);
        pausedText.gameObject.SetActive(false);

        unpauseBtn.gameObject.SetActive(false);
        pauseBtn.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);

        Time.timeScale = 0f;
    }


    public static void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackBtn()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Pause()
    {
        Time.timeScale = 0f;

        gameOverPanel.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(false);
        timeUpText.gameObject.SetActive(false);
        pausedText.gameObject.SetActive(true);

        unpauseBtn.gameObject.SetActive(true);
        pauseBtn.gameObject.SetActive(false);

    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        gameOverPanel.gameObject.SetActive(false);

        pauseBtn.gameObject.SetActive(true);
    }

    IEnumerator LevelCleared()
    {
        

        src.PlayOneShot(levelClear);

        levelClearText.gameObject.SetActive(true);

        pauseBtn.gameObject.SetActive(false);

        playerBody.gameObject.SetActive(false);

        yield return new WaitForSecondsRealtime(1.5f);

        

        

        isLevelCleared = true;

        


        /*float finishTime = timerBar.value;

        if (finishTime >= timerBar.minValue)
        {
            finishTime -= (Time.deltaTime * finishTimeBarSpeed);
            timerBar.value = finishTime;
        }*/

        //trying to wind up remaining time and add it as score 
        //so it has a timer receding in quickly animation and it's also adding the rest of the remaining time as score 

        while (timerBar.value > timerBar.minValue)
        {
            float finishTime = timerBar.value;

            finishTime -= Time.deltaTime * finishTimeBarSpeed;

            timerBar.value = Mathf.Max(finishTime, timerBar.minValue);

            yield return null;
        }

        //yield return new WaitForSecondsRealtime(2f);

    }

   /* void LevelCleared()
    {

        src.PlayOneShot(levelClear);

        levelClearText.gameObject.SetActive(true);
        nextLevelBtn.gameObject.SetActive(true);
    }*/

   
}
