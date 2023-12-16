using System;
using UnityEngine;

public class MarketingSystem : MonoBehaviour
{
    private int expectedValue = 10;
    private int totalValue = 0;
    private bool _buying = false;
    private bool _isModelUpdated = false;
    [SerializeField] private Material _originalcolor;

    private void Update()
    {
        if (UIManager.collectObject >= expectedValue)
        {
            _buying = true;
        }
        else if (UIManager.collectObject !>= expectedValue)
        {
            _buying = false;
        }
        if (_isModelUpdated)
        {
            _buying = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        // Eğer bu nesnenin içine bir şey girerse
        if (_buying)
        {

            IncreaseValue(1);
            UIManager.collectObject -= 1;
            
        }
        
        
        
    }

    private void IncreaseValue(int amount)
    {
        totalValue += amount;
        Debug.Log("Total Value: " + totalValue);

        if (totalValue >= expectedValue)
        {
            UpdateModel();
        }
    }

    private void UpdateModel()
    {
        Debug.Log("Model updated! Receive and process new values from the model.");
        GetComponent<Renderer>().material = _originalcolor;
     _isModelUpdated = true;
        // Burada gerçek bir makine öğrenimi modeliyle iletişim kurma kodu olmalıdır.
        // Modelden dönen sonuçlara göre oyun içi mekanikleri güncelleyebilirsiniz.
    }
}