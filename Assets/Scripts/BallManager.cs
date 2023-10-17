using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager : MonoBehaviour
{
    public static List<GameObject> activeBalls = new List<GameObject>();
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public static void AddBall(GameObject ball)
    {
        activeBalls.Add(ball);
    }

    public static void RemoveBall(GameObject ball)
    {
        activeBalls.Remove(ball);
    }
}
