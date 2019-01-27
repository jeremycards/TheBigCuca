using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buho : MonoBehaviour {
    public Animator animator;
    public float speed = 10;
    public Transform playerPos;
    public bool oneatack;
    // Use this for initialization
    void Start () {
        animator = GetComponentInParent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        
        animator.transform.Translate(Vector2.right * speed * Time.deltaTime);
        float distanceToPlayer = Vector2.Distance(this.transform.position, playerPos.position);
        if (distanceToPlayer < 4 && !oneatack)
        {

            oneatack = true;
                animator.SetTrigger("Atack");

            playerPos.SendMessage("TakeDamage");

        }
    }
}
