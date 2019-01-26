using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour {

    public GameObject player;


	void Start ()
    {
        Instantiate(player, gameObject.transform.position, gameObject.transform.rotation);
	}
	
}
