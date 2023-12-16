using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static int collectObject=1;

    [SerializeField] private TextMeshProUGUI _CounterTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _CounterTxt.text = collectObject.ToString();
    }
}
