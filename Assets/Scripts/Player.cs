using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed;

    private float movementInput;

    [SerializeField] Animator anim;

    private bool isAlive;
    private bool isMoving;

    public AudioSource src;
    public AudioClip dead, shoot;
    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isAlive = true;
        isMoving = false;
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(movementInput * speed, rb.velocity.y);
        //anim.SetBool("Move", false);
        if (isMoving)
        {
            anim.SetBool("Move", true);
        }
        if (Mathf.Abs(movementInput) == 0)
        {
            isMoving = false;
            anim.SetBool("Move", false);
        }
       

    }

    void OnMove(InputValue value)
    {
        movementInput = value.Get<float>();
        isMoving = true;
        //anim.SetBool("Move", true);

    }

    void OnShoot()
    {
        src.PlayOneShot(shoot);
        Arrow.isFired = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ball")
        {
            //GameController.isPlaying = true;
            GameController.lives--;
            Time.timeScale = 0f;
            isAlive = false;
            src.PlayOneShot(dead);
            if (!isAlive)
            {
                anim.SetBool("Dead", true);
                StartCoroutine(RestartAfterDeathAnim());

                Debug.Log("after  coroutine");

                

            }
            
        }
    }

    IEnumerator RestartAfterDeathAnim()
    {
        Debug.Log("before waitforseconds");

        yield return new WaitForSecondsRealtime(1.5f);
        //anim.GetCurrentAnimatorClipInfo(0).Length

        Debug.Log("after  waitforseconds");

       // Time.timeScale = 1f;

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //  Time.timeScale = 1f;
        GameController.Restart();



    }
}
