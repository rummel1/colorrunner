using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _attackRadius;
    [SerializeField] private Bullet _bulletPrefab;

    private Collider[] _enemies;
    private CapsuleCollider currentEnemy = null;
    void Start()
    {
        InvokeRepeating(nameof(ScanArea),0,_fireRate);
    }

    // Update is called once per frame
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position,_attackRadius);
    }

    private void ScanArea()
    {
        float distance = 1000;
        _enemies = Physics.OverlapSphere(transform.position, _attackRadius);
        foreach (Collider enemy in _enemies)
        {
            if (enemy.gameObject.TryGetComponent(out CapsuleCollider enemyScript))
            {
                float dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (dist<=distance)
                {
                    currentEnemy = enemyScript;
                    distance = dist;
                }
            }
        }

        if (currentEnemy)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, quaternion.identity);
            bullet.SetTarget(currentEnemy.transform);
        }
    }

    private void Update()
    {
        if (currentEnemy)
        {
            Vector3 dir = currentEnemy.transform.position - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.LookRotation(dir);
        }
    }
}
