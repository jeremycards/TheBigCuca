using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxController : MonoBehaviour {

    public Animator animator;
    public float speed=10;
    public float atackRange;
    public int damage;
    public float lastAtackTime;
    public float atackDelay;
    public Transform StartPatrolPoint;
    public Transform EndPatrolPoint;

    public Transform playerPos;



    public bool PlayerInSigth;




    // Use this for initialization
    void Start () {

        animator = GetComponentInParent<Animator>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

    }

    public void SetPatrolPoints(Transform startPatrolPoint, Transform endPatrolPoint) {

        StartPatrolPoint = startPatrolPoint;
        EndPatrolPoint = endPatrolPoint;

    }

    // Update is called once per frame
    void Update () {



        if (!PlayerInSigth)
        {

            animator.transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x > EndPatrolPoint.position.x)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);

            }
            else if (transform.position.x < StartPatrolPoint.position.x)
            {


                transform.eulerAngles = new Vector3(0, 0, 0);

            }


        }
        else {

           


        }
        float distanceToPlayer = Vector2.Distance(this.transform.position, playerPos.position);
        if (distanceToPlayer < atackRange)
        {
           
            if (Time.time > lastAtackTime + atackDelay)
            {

                animator.SetTrigger("Atack");

            }

        }

    }

    public void Atack()
    {
        float distanceToPlayer = Vector2.Distance(this.transform.position, playerPos.position);
        if (distanceToPlayer < atackRange)
        {
            playerPos.SendMessage("TakeDamage");
            lastAtackTime = Time.time;
        }

        PlayerInSigth = false;
    }
}
