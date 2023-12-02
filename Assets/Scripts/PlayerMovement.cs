using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float jump_;

    [SerializeField] private Joystick _joystick;

    [SerializeField] private float _forwardSpeed;
    [SerializeField] private float _leftrightSpeed;
    [SerializeField] private Vector2 _minMaxX;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minMaxX.x, _minMaxX.y), transform.position.y, transform.position.z);
        rb.velocity=new Vector3(_joystick.Horizontal*_leftrightSpeed* Time.deltaTime, jump_,_forwardSpeed*Time.deltaTime);
    }

    public void jump()
    {
        jump_=5;
    }
}
