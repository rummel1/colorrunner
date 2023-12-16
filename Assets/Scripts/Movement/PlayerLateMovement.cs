using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerLateMovement : MonoBehaviour
{
    public Transform target;
    public LineRenderer followerLineRenderer;
    public float forwardSpeed = 5f;
    public float lateralSpeed = 5f;

    void Start()
    {
        followerLineRenderer.positionCount = 0;
    }

    void FixedUpdate()
    {
       
        followerLineRenderer.positionCount = 0;

       
        if (target != null)
        {
            
            Vector3 currentPosition = transform.position;
            followerLineRenderer.positionCount++;
            followerLineRenderer.SetPosition(followerLineRenderer.positionCount - 1, currentPosition);

          
            float step = forwardSpeed * Time.deltaTime; 
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            
            float horizontalStep = lateralSpeed * Time.deltaTime;
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * (horizontalInput * horizontalStep), Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            UIManager.collectObject -= 1;
        }
    }
}