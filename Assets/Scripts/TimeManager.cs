using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {

    public Text timeText;
    public float initialTime = 60f;
    private float elapsedTime = 0f;


	// Use this for initialization
	void Awake ()
    {
        elapsedTime = initialTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateTime();	
	}

    private void UpdateTime()
    {
        elapsedTime -= Time.deltaTime;
        UpdateTextTime();
    }

    private void UpdateTextTime()
    {
        float tempTime = Mathf.Floor(elapsedTime);
        if (tempTime < 0)
            tempTime = 0;
        timeText.text = tempTime.ToString();
    }
}
