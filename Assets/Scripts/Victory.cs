using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{

    IEnumerator goalReach()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Victory");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("player gana");
            StartCoroutine(goalReach());
        }
    }

}
