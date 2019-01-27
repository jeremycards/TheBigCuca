using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CicleDayController : MonoBehaviour
{
    private Material mat;
    private Color lerpedColor;
    private Color col;
    //private TimeManager timeManager;

    private void Start()
    {
        //timeManager = GameObject.Find("Timer").GetComponent<TimeManager>();
        mat = GetComponent<MeshRenderer>().material;
        lerpedColor = mat.color;
        //col = new Color(255f, 165f, 0f);
    }

    void Update()
    {
        lerpedColor = Color.Lerp(lerpedColor, Color.yellow, 0.01f * Time.deltaTime);
        mat.color = lerpedColor;
    }
}
