using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxSpawnerScript : MonoBehaviour {

    public Transform StartPatrolPoint;
    public Transform EndPatrolPoint;
    public GameObject prefab;
    // Use this for initialization
    void Start () {
        GameObject fox = Instantiate(prefab, StartPatrolPoint.position, Quaternion.identity);
        fox.GetComponent<FoxController>().SetPatrolPoints(StartPatrolPoint, EndPatrolPoint);
    }
	
	// Update is called once per frame
	void Update () {

       
		
	}
}
