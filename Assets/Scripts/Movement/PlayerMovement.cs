using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    
    public LineRenderer lineRenderer;

    [SerializeField] private Joystick _joystick;

    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _leftrightSpeed;
    [SerializeField] private Vector2 _minMaxX;
    
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        lineRenderer.positionCount = 0;
    }

    
    void Update()
    {
        _gravity();
        _movement();
    }

    private void _movement()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minMaxX.x, _minMaxX.y), transform.position.y, transform.position.z);
        rb.velocity=new Vector3(_joystick.Horizontal*_leftrightSpeed* Time.deltaTime, rb.velocity.y,_forwardSpeed*Time.deltaTime);
        Vector3 currentPosition = transform.position;
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
    }
    

    private void _gravity()
    {
        if (!Physics.Raycast(transform.position, Vector3.down, 1))
        {
            Physics.gravity=new Vector3(0, -100, 0);
        }
        else
        {
            Physics.gravity=new Vector3(0, -9.81f, 0);

        }
    }
}
