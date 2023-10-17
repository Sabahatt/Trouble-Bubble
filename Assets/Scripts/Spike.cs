using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spike : MonoBehaviour
{
    public static bool isCombo;

    [SerializeField] Animator anim;
    [SerializeField] private TextMeshProUGUI comboText;

    public AudioSource src;
    void Start()
    {
        isCombo = false;
    }

    void Update()
    {
   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            /* ballCount++;

             if (ballCount == 2)
             {
                  isCombo = true;
                 Destroy(collision.gameObject);
                 anim.SetBool("Combo", true);
                StartCoroutine(DestroyAfterComboAnim());

             }
             if (ballCount < 2)
             {
                 isCombo = false;
                 Destroy(collision.gameObject);
             }*/
            //isCombo = true;
            ChainCollision.ballScore += 100;
            src.Play();
            Destroy(collision.gameObject);
            comboText.gameObject.SetActive(true);
            anim.SetBool("Combo", true);
            StartCoroutine(ResetComboState());
        }
    }

    /*    private void OnTriggerExit2D(Collider2D collision)
        {
            ballCount = 0;
        }*/

    IEnumerator ResetComboState()
    {
        yield return new WaitForSeconds(2f);
        isCombo = false;
        anim.SetBool("Combo", false);
        comboText.gameObject.SetActive(false);
    }
}
