using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanoidMovement : MonoBehaviour
{
    [SerializeField] NavMeshAgent humanAgent;
    [SerializeField] Transform humanGoal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        humanAgent.SetDestination(humanGoal.transform.position);
    }
}
