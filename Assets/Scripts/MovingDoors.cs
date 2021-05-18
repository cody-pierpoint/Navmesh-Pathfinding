using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MovingDoors : MonoBehaviour
{
    [SerializeField] GameObject[] movingDoors;
    [SerializeField] float moveDistance = 4f;
    private bool moveBack = false;
    private Transform startingPoint;
    private Transform endingPos;
    private int distance;

    // Start is called before the first frame update
    void Start()
    {
        startingPoint.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.GetComponent<NavMeshObstacle>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject doors in movingDoors)
        {
            if(!moveBack)
            {
                //endingPos.transform.position = transform.position;

                transform.Translate(transform.right * (Mathf.PingPong(movingDoors[movingDoors.Length].transform.position, moveDistance)));
            }
            
        }
    }
}
