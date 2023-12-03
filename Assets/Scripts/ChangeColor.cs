using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private Color originalCharacterColor;
    private Color currentCharacterColor;
    
    private bool colorChanged = false;

    private void Start()
    {
        originalCharacterColor = GetComponent<Renderer>().material.color;
        currentCharacterColor = originalCharacterColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ColorObject"))
        {
            if (!colorChanged)
            {
                Color newColor = other.GetComponent<MeshRenderer>().material.color;
                ChangeCharacterColor(newColor);
                colorChanged = true;
            }
        }
    }

    private void ChangeCharacterColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;
        currentCharacterColor = newColor;
    }
    
    private void Update()
    {
        if (colorChanged)
        {
            colorChanged = false;
        }
    }
}