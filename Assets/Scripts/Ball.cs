using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector2 startForce;

    public Rigidbody2D rb;

    public GameObject nextBall;
    void Start()
    {
       // BallManager.AddBall(gameObject);

        rb.AddForce(startForce, ForceMode2D.Impulse);

    }

    void Update()
    {
      
    }

    public void SplitBall()
    {
        if (nextBall != null)
        {
           GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
           GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

            ball1.GetComponent<Ball>().startForce = new Vector2(2f, 5f);
            ball2.GetComponent<Ball>().startForce = new Vector2(-2f, 5f);

        }

        //BallManager.RemoveBall(gameObject);
        Destroy(gameObject);
        
    }
}
