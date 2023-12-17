
using System;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    private Vector3 whereischaracter;
    [SerializeField] private Transform _maincharacter;
    public GameObject prefab; 
    private bool hasPassedDoor = false; 
    private int x;
    private int y;


    private void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorObject")) 
        {
            hasPassedDoor = true;
            UIManager.collectObject += 10;
            
        }


        if (other.CompareTag("Collect"))
        {
            for (var i = 1; i < 2; i++)
            {
                Destroy(other.gameObject);
                var position = _maincharacter.position;
                float newZ = position.z +(i*-2.0f);
                Instantiate(prefab, new Vector3(position.x, position.y, newZ), Quaternion.identity);
                UIManager.collectObject += 1;
                
            
            }
        }
        
        
    }

    void Update()
    {
        _haspasserdoor();
    }

    private void _haspasserdoor()
    {
        if (hasPassedDoor)
        {
            SpawnCharacter();
            hasPassedDoor = false; 
        }
    }

    void SpawnCharacter()
    {
        for (var i = 1; i < 6; i++)
        {
            var position = _maincharacter.position;
            float newZ = position.z +(i*-2.0f);
            Instantiate(prefab, new Vector3(position.x, position.y, newZ), Quaternion.identity);
            
        }
    } 

    
}
