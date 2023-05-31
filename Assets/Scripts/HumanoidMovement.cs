using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class HumanoidMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent humanAgent;
    [SerializeField] Transform humanGoal;
    [SerializeField] Transform humanCoin;
    [SerializeField] private Animator animator;
    [SerializeField]bool coinCollected = false;
    public enum StateMachine
    {
        Idle,
        Move,
        Coin
    }
    public StateMachine state = StateMachine.Move;
    // Start is called before the first frame update
    void Start()
    {
        NextState();
    }

    // Update is called once per frame
    void Update()
    {
        if (humanAgent.velocity.magnitude > 0.1f)
        {
            animator.SetBool("WhyAreYouRunning", true);

        }
        else
        {
            animator.SetBool("WhyAreYouRunning", false);

        }
        //humanAgent.SetDestination(humanGoal.transform.position);

        //animator.SetBool("WhyAreYouRunning", !humanAgent.pathPending);


        //if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) <= 2f)
        //{
        //    animator.SetBool("WhyAreYouRunning", false);
        //}
    }

    public void NextState()
    {
        switch (state)
        {
            case StateMachine.Idle:
                StartCoroutine(IdleState());
                break;
            case StateMachine.Move:
                StartCoroutine(MoveState());

                break;
            case StateMachine.Coin:
                StartCoroutine(CoinState());
                break;

        }
    }

    private IEnumerator IdleState()
    {
        while(state == StateMachine.Idle)
        {

            //if (humanAgent.pathStatus == NavMeshPathStatus.PathComplete)
            //{
                
            //}
            


            if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) > Vector3.Distance(humanAgent.transform.position, humanCoin.transform.position))
            {
                state = StateMachine.Coin;

            }
            if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) < Vector3.Distance(humanAgent.transform.position, humanCoin.transform.position))
            {
                state = StateMachine.Move;

            }

            yield return null;  

        }
        NextState();

    }
    private IEnumerator MoveState()
    {
        while (state == StateMachine.Move)
        {

            humanAgent.SetDestination(humanGoal.transform.position);

            //animator.SetBool("WhyAreYouRunning", false);


            if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) > Vector3.Distance(humanAgent.transform.position, humanCoin.transform.position))
            {
                state = StateMachine.Coin;

            }
            if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) <= 2f)
            {
                state = StateMachine.Idle;
            }

            yield return null;

        }
        NextState();

    }

    private IEnumerator CoinState()
    {
        while (state == StateMachine.Coin)
        {
            if (humanCoin != null)
            {
                humanAgent.SetDestination(humanCoin.transform.position);

            }

            //animator.SetBool("WhyAreYouRunning", !humanAgent.pathPending);

            //animator.SetBool("WhyAreYouRunning", false);
            if (Vector3.Distance(humanAgent.transform.position, humanCoin.transform.position) <= 1f)
            {
                Destroy(humanCoin.gameObject);
                coinCollected = true;
                state = StateMachine.Move;

            }

            //if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) < Vector3.Distance(humanAgent.transform.position, humanCoin.transform.position))
            //{

            //}
            if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) <= 2f)
            {
                state = StateMachine.Idle;
            }

            yield return null;

        }
        NextState();

    }

}
