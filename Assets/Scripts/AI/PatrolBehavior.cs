using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PatrolBehavior : StateMachineBehaviour {


    public float speed;
    private bool movingRigth=true;
    public Transform groundDetection;
    public float DetectionDistance;
    public Transform playerPos;
    public float AtackDistance;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        groundDetection = FindGameObjectInChildWithTag(animator.gameObject,"GrounDetection").transform;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        animator.transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (Vector2.Distance(animator.transform.position, playerPos.position) < AtackDistance)
        {


            animator.SetTrigger("Atack");

        }
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, DetectionDistance);
        if (groundInfo.collider == false) {
            if (movingRigth == true)
            {

                animator.transform.eulerAngles = new Vector3(0, -180, 0);
                movingRigth = false;

            }
            else {

                animator.transform.eulerAngles = new Vector3(0, 0, 0);
                movingRigth = true;

            }

        }
        RaycastHit2D wallInfo = Physics2D.Raycast(groundDetection.position, Vector2.right, 1);
        if (wallInfo.collider != false)
        {
            if (wallInfo.collider.tag=="Floor")
            {

                if (movingRigth == true)
                {

                    animator.transform.eulerAngles = new Vector3(0, -180, 0);
                    movingRigth = false;

                }
                else
                {

                    animator.transform.eulerAngles = new Vector3(0, 0, 0);
                    movingRigth = true;

                }
            }
           

        }


    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    public static GameObject FindGameObjectInChildWithTag(GameObject parent, string tag)
    {
        Transform t = parent.transform;

        for (int i = 0; i < t.childCount; i++)
        {
            if (t.GetChild(i).gameObject.tag == tag)
            {
                return t.GetChild(i).gameObject;
            }

        }

        return null;
    }
   
    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
