using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
public class HumanoidMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent humanAgent;
    [SerializeField] Transform humanGoal;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        humanAgent.SetDestination(humanGoal.transform.position);

        animator.SetBool("WhyAreYouRunning", !humanAgent.pathPending);
    }


}
