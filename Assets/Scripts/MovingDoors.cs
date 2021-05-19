using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class MovingDoors : MonoBehaviour
{
    [SerializeField] GameObject movingDoors;
    [SerializeField] float moveDistance = 4f;
    private bool moveBack = false;
    [SerializeField]private Transform startingPoint;
    [SerializeField]private Transform endingPos;
    private int distance;
    [SerializeField] private float speed;
    private float velocity;


    // Start is called before the first frame update
    void Start()
    {
        //startingPoint.transform.position =  new Vector3(transform.position.x, transform.position.y, transform.position.z);
        gameObject.GetComponent<NavMeshObstacle>();
        //  endingPos.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4f);
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, endingPos.transform.position, ref , moveDistance, speed); ;
        //if(Mathf.Abs(transform.position.z - endingPos.transform.position.z) < 0.25)
        //{
        //    endingPos = endingPos == startingPoint ? endingPos : startingPoint;
        //}
        //transform.Translate(-transform.right * speed * Time.deltaTime);
        //if ()
        //{
        //    transform.Translate(transform.right * speed * Time.deltaTime);
        //}
        //else
        //{
        //   transform.Translate(-transform.right * speed * Time.deltaTime);
        //}
        //if (!moveBack && transform.position == endingPos.transform.position)
        //{
           
        //    moveBack = false;
        //}
        //else
        //{
        //    transform.Translate(Vector3.MoveTowards(transform.position, endingPos.transform.position, 0f) * speed * Time.deltaTime);
        //    moveBack = true;
        //}
    }
}
