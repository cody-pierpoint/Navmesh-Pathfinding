using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TeleportHandler : MonoBehaviour
{
    [SerializeField] NavMeshAgent teleportAgent;
    [SerializeField] Transform teleportGoal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        teleportAgent.SetDestination(teleportGoal.transform.position);
    }
}
