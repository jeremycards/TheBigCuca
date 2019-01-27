using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuhoSpawnerScript : MonoBehaviour {

    public float TimeToSpawn=5;
    public float actualtime;
    public GameObject prefab;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (actualtime > TimeToSpawn)
        {


            GameObject fox = Instantiate(prefab, GameObject.FindGameObjectWithTag("Player").transform.position - (new Vector3(20, -3, 0)), Quaternion.identity);
            actualtime = 0;
        }
        else {
            actualtime += Time.deltaTime;
        }
		
	}
}
