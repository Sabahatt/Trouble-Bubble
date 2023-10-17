using UnityEngine;

public class ChainCollision : MonoBehaviour
{
    public static int ballScore = 0;
    public AudioSource src;
    //public AudioClip ballHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Arrow.isFired = false;

        if (collision.tag == "Ball")
        {
            src.Play();
            collision.GetComponent<Ball>().SplitBall();
            ballScore += 10;
        }
    }
}
