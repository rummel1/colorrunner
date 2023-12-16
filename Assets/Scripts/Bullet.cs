using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private float _speed;

    public void SetTarget(Transform target)
    {
        this._target = target;
    } 
    void Update()
    {
        if (_target)
        {
            Vector3 dir = _target.position - transform.position;
            transform.forward = dir;
            transform.Translate(transform.forward * (Time.deltaTime * _speed),Space.World);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
