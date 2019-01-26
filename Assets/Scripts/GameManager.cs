using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public bool defeated = false;

    IEnumerator failure()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Defeat");
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }


    }

    private void Update()
    {
        if (defeated == true)
        {
            StartCoroutine(failure());
        }
    }

    
}
