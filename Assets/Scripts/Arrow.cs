using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
 //   public static Arrow instance;

    public static bool isFired;

    public Transform player;

    [SerializeField] private float speed = 3f;
    

 /*   private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }*/
    void Start()
    {
        isFired = false;
    }

    void Update()
    {

        if (isFired)
        {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
        }
        else
        {
            transform.position = player.position;
            transform.localScale = new Vector3(1f, 0f, 1f);
        }
    }
}
