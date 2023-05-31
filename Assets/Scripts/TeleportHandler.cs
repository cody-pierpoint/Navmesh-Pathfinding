using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TeleportHandler : MonoBehaviour
{
    [SerializeField] NavMeshAgent teleportAgent;
    [SerializeField] Transform teleportGoal;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform teleportCoin;
    [SerializeField] private bool coinCollected;
    public enum States
    {
        Idle,
        Move,
        Coin
    }
    public States _state = States.Move;

    // Start is called before the first frame update
    void Start()
    {
        NextState();
    }

    // Update is called once per frame
    void Update()
    {
        //if (teleportAgent.velocity.magnitude > 0.1f)
        //{
        //    animator.SetBool("IsCrawling", true);

        //}
        //else
        //{
        //    animator.SetBool("IsCrawling", false);

        //}
        teleportAgent.SetDestination(teleportGoal.transform.position);

        animator.SetBool("IsCrawling", !teleportAgent.pathPending);

        if (Vector3.Distance(teleportAgent.transform.position, teleportGoal.transform.position) <= 2f)
        {
            animator.SetBool("IsCrawling", false);
        }
    }
    public void NextState()
    {
        switch (_state)
        {
            case States.Idle:
                StartCoroutine(IdleState());
                break;
            case States.Move:
                StartCoroutine(MoveState());

                break;
            case States.Coin:
                StartCoroutine(CoinState());
                break;

        }
    }

    private IEnumerator IdleState()
    {
        while (_state == States.Idle)
        {

            //if (humanAgent.pathStatus == NavMeshPathStatus.PathComplete)
            //{

            //}



            if (Vector3.Distance(teleportAgent.transform.position, teleportGoal.transform.position) > Vector3.Distance(teleportAgent.transform.position, teleportCoin.transform.position))
            {
                _state = States.Coin;

            }
            if (Vector3.Distance(teleportAgent.transform.position, teleportGoal.transform.position) < Vector3.Distance(teleportAgent.transform.position, teleportCoin.transform.position))
            {
                _state = States.Move;
                    
            }

            yield return null;

        }
        NextState();

    }
    private IEnumerator MoveState()
    {
        while (_state == States.Move)
        {

            teleportAgent.SetDestination(teleportGoal.transform.position);

            //animator.SetBool("WhyAreYouRunning", false);


            if (Vector3.Distance(teleportAgent.transform.position, teleportGoal.transform.position) > Vector3.Distance(teleportAgent.transform.position, teleportCoin.transform.position))
            {
                _state = States.Coin;

            }
            if (Vector3.Distance(teleportAgent.transform.position, teleportGoal.transform.position) <= 2f)
            {
                _state = States.Idle;
            }

            yield return null;

        }
        NextState();

    }

    private IEnumerator CoinState()
    {
        while (_state == States.Coin)
        {
            if (teleportCoin != null)
            {
                teleportAgent.SetDestination(teleportCoin.transform.position);

            }

            //animator.SetBool("WhyAreYouRunning", !humanAgent.pathPending);

            //animator.SetBool("WhyAreYouRunning", false);
            if (Vector3.Distance(teleportAgent.transform.position, teleportCoin.transform.position) <= 1f)
            {
                Destroy(teleportCoin.gameObject);
                coinCollected = true;
                _state = States.Move;

            }

            //if (Vector3.Distance(humanAgent.transform.position, humanGoal.transform.position) < Vector3.Distance(humanAgent.transform.position, humanCoin.transform.position))
            //{

            //}
            if (Vector3.Distance(teleportAgent.transform.position, teleportGoal.transform.position) <= 2f)
            {
                _state = States.Idle;
            }

            yield return null;

        }
        NextState();

    }
}

