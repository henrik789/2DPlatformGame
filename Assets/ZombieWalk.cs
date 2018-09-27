using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{

    public float speed = 5.0f;
    public GameObject PointsPrefab;
    Transform patrolPoints;
    int randomPoint;
    float timeStillAwake;
    int isSleepingHash = Animator.StringToHash("isSleeping");
    Transform playerTransform;
    int distanceHash = Animator.StringToHash("playerDistance");
    int inSightHash = Animator.StringToHash("playerInSight");


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        if (patrolPoints == null)
        {
            patrolPoints = Instantiate(PointsPrefab).transform;
        }

        randomPoint = Random.Range(0, patrolPoints.childCount);
        timeStillAwake = Random.Range(2.0f, 5.0f);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        timeStillAwake -= Time.deltaTime;

        if (timeStillAwake <= 0)
        {
            animator.SetBool(isSleepingHash, true);
        }

        Vector2 current = animator.transform.position;
        Vector2 target = patrolPoints.GetChild(randomPoint).position;

        if (Vector2.Distance(current, target) > 0.2f)
        {
            animator.transform.position = Vector2.MoveTowards(current, target, speed * Time.deltaTime);
        }
        else
        {
            randomPoint = Random.Range(0, patrolPoints.childCount);
        }

        animator.SetFloat(distanceHash, Vector2.Distance(animator.transform.position, playerTransform.position));

        RaycastHit2D hit = Physics2D.Linecast(animator.transform.position, playerTransform.position);
        if (hit.collider.tag == "Player")
        {
            animator.SetBool(inSightHash, true);
        }
        else
        {
            animator.SetBool(inSightHash, false);
        }



    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}