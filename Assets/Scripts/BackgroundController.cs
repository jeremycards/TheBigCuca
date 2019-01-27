using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    private GameObject player;

    void LateUpdate()
    {
        if (!player)
        {
            player = GameObject.Find("playerPossum(Clone)");
        }
        
    }
}
