using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SwimmerHandler : MonoBehaviour
{
    [SerializeField] NavMeshAgent swimmerAgent;
    [SerializeField] Transform swimmerGoal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        swimmerAgent.SetDestination(swimmerGoal.transform.position);
    }
}
