using UnityEngine;
using UnityEngine.Events;

public class ChangeColor : MonoBehaviour
{
    private Color originalCharacterColor;
    private Color currentCharacterColor;
    
    private bool colorChanged = false;

    [SerializeField] GameObject clone;
    [SerializeField] GameObject clone1;
    private void Start()
    {
        originalCharacterColor = GetComponent<Renderer>().material.color;
        currentCharacterColor = originalCharacterColor;
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorObject"))
        {
            if (!colorChanged)
            {
                Color newColor = other.GetComponent<Renderer>().material.color;
                ChangeCharacterColor(newColor);
                ChangeCloneColor(newColor);
                
                colorChanged = true;
            }
        }
    }
    
    private void ChangeCharacterColor(Color newColor)
    {
        GetComponent<Renderer>().material.color = newColor;
        currentCharacterColor = newColor;

    }
    private void ChangeCloneColor(Color newColor)
    {
        clone.GetComponent<Renderer>().material.color = newColor;
        clone1.GetComponent<Renderer>().material.color = newColor;

    }
    

    private void Update()
    {
        
        if (colorChanged)
        {
            colorChanged = false;
        }
    }
    
}