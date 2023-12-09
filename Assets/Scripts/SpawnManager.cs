
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    private Vector3 whereischaracter;
    [SerializeField] private Transform _maincharacter;
    public GameObject prefab; 
    private bool hasPassedDoor = false; 
    private int x;
    private int y;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorObject")) 
        {
            hasPassedDoor = true;
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
        for (var i = 1; i < 2; i++)
        {
            var position = _maincharacter.position;
            float newZ = position.z +(i*-2.0f);
            Instantiate(prefab, new Vector3(position.x, position.y, newZ), Quaternion.identity);
        }
    } 

    
}
