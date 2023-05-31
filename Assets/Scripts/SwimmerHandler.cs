using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class SwimmerHandler : MonoBehaviour
{
    [SerializeField] NavMeshAgent swimmerAgent;
    [SerializeField] Transform swimmerGoal;
    //public ThirdPersonCharacter character;
    [SerializeField] private Animator animator;
    [SerializeField] Transform swimmerCoin;
    [SerializeField] bool coinCollected = false;
    // Start is called before the first frame update
    public enum state
    {
        Idle,
        Move,
        Coin
    }
    public state _states = state.Move; 
    void Start()
    {
        NextState();
    }

    // Update is called once per frame
    void Update()
    {
        //if (swimmerAgent.velocity.magnitude > 0.1f)
        //{
        //    animator.SetBool("IsWalking", true);

        //}
        //else
        //{
        //    animator.SetBool("IsWalking", false);

        //}
        swimmerAgent.SetDestination(swimmerGoal.transform.position);


        animator.SetBool("IsWalking", !swimmerAgent.pathPending);

        if (Vector3.Distance(swimmerAgent.transform.position, swimmerGoal.transform.position) <= 2f)
        {
            animator.SetBool("IsWalking", false);
        }
    }
    public void NextState()
    {
        switch (_states)
        {
            case state.Idle:
                StartCoroutine(IdleState());
                break;
            case state.Move:
                StartCoroutine(MoveState());
                break;
            case state.Coin:
                StartCoroutine(CoinState());
                break;

        }
    }

    private IEnumerator IdleState()
    {
        while (_states == state.Idle)
        {

            //if (humanAgent.pathStatus == NavMeshPathStatus.PathComplete)
            //{

            //}



            if (Vector3.Distance(swimmerAgent.transform.position, swimmerGoal.transform.position) > Vector3.Distance(swimmerAgent.transform.position, swimmerCoin.transform.position))
            {
                _states = state.Coin;

            }
            if (Vector3.Distance(swimmerAgent.transform.position, swimmerGoal.transform.position) < Vector3.Distance(swimmerAgent.transform.position, swimmerCoin.transform.position))
            {
                _states = state.Move;

            }

            yield return null;

        }
        NextState();

    }
    private IEnumerator MoveState()
    {
        while (_states == state.Move)
        {

            swimmerAgent.SetDestination(swimmerGoal.transform.position);

            //animator.SetBool("WhyAreYouRunning", false);


            if (Vector3.Distance(swimmerAgent.transform.position, swimmerGoal.transform.position) > Vector3.Distance(swimmerAgent.transform.position, swimmerCoin.transform.position))
            {
                _states = state.Coin;

            }
            if (Vector3.Distance(swimmerAgent.transform.position, swimmerGoal.transform.position) <= 2f)
            {
                _states = state.Idle;
            }

            yield return null;

        }
        NextState();

    }

    private IEnumerator CoinState()
    {
        while (_states == state.Coin)
        {
            if (!coinCollected)
            {
                swimmerAgent.SetDestination(swimmerCoin.transform.position);

            }

            //animator.SetBool("WhyAreYouRunning", !humanAgent.pathPending);

            //animator.SetBool("WhyAreYouRunning", false);
            if (Vector3.Distance(swimmerAgent.transform.position, swimmerCoin.transform.position) <= 1f)
            {
                Destroy(swimmerCoin.gameObject);
                coinCollected = true;
                _states = state.Move;

            }

            //if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) < Vector3.Distance(humanAgent.transform.position, humanCoin.transform.position))
            //{

            //}
            if (Vector3.Distance(swimmerAgent.transform.position, swimmerGoal.transform.position) <= 2f)
            {
                _states = state.Idle;
            }

            yield return null;

        }
        NextState();

    }
    // animator.SetFloat("Forward", swimmerAgent.pathPending ? 0 : 1);


    //if (swimmerAgent.remainingDistance > swimmerAgent.stoppingDistance)
    //{
    //    character.Move(swimmerAgent.desiredVelocity, false, false);

    //}
    //else
    //    character.Move(Vector3.zero, false, false);
}

