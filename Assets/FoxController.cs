using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour {

    public Animator animator;
    public float atackRange;
    public int damage;
    public float lastAtackTime;
    public float atackDelay;
    // Use this for initialization
    void Start () {

        animator = GetComponentInParent<Animator>();
        
    }

    // Update is called once per frame
    void Update () {



		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
