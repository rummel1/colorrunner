using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    private Vector3 whereischaracter;
    [SerializeField] private Transform _maincharacter;
    public GameObject prefab; // Spawn edilecek karakterin prefab'ı
    private bool hasPassedDoor = false; // Kapının içinden geçildiğini kontrol etmek için bir bayrak
    private int x;
    private int y;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorObject")) // Eğer kapı içine girdiyse
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
            // Kapının içinden geçildiyse ve her güncellemede yeni bir karakter spawn et
            SpawnCharacter();
            hasPassedDoor = false; // Bayrağı sıfırla
        }
    }

    void SpawnCharacter()
    {
        while(x<500)
        {
            while (x<1)
            {
                x++;
            }
            GameObject newObject = Instantiate(prefab);
            float newZ = _maincharacter.position.z;
            newObject.transform.position = new Vector3(newObject.transform.position.x, newObject.transform.position.y,newZ*(-1*x));

            x++;
            break;
        }
    } 

    
}
