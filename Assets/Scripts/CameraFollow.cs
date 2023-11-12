using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
     public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public float xOffset = 15f;
    public float speed = 5f;

    public Transform target;

    // Update is called once per frame
    void Start()
    {
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
    void Update()
    {
        //Vector3 newPos = new Vector3(transform.position.x + speed, target.position.y + yOffset, -10f);
        //transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}