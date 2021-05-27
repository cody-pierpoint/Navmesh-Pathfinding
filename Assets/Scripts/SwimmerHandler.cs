using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class SwimmerHandler : MonoBehaviour
{
    [SerializeField] NavMeshAgent swimmerAgent;
    [SerializeField] Transform swimmerGoal;
    public ThirdPersonCharacter character;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        swimmerAgent.SetDestination(swimmerGoal.transform.position);


        animator.SetBool("IsWalking", !swimmerAgent.pathPending);
       // animator.SetFloat("Forward", swimmerAgent.pathPending ? 0 : 1);


        //if (swimmerAgent.remainingDistance > swimmerAgent.stoppingDistance)
        //{
        //    character.Move(swimmerAgent.desiredVelocity, false, false);

        //}
        //else
        //    character.Move(Vector3.zero, false, false);
    }
}
