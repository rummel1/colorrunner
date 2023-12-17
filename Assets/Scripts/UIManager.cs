using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class UIManager : MonoBehaviour
{
    public static int collectObject=1;
    [SerializeField] private GameObject _restartPanel;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _clone;

    [SerializeField] private GameObject _level01;
    [SerializeField] private GameObject _level02;
    
    public EndPoint endPoint;
    

    [SerializeField] private TextMeshProUGUI _CounterTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextLevel()
    {
        endPoint._ch9.gameObject.SetActive(true);
        endPoint._player.GetComponent<BoxCollider>().enabled = true;
        endPoint._endPlayer.GetComponent<SkinnedMeshRenderer>().enabled = false;
        endPoint._endPlayer.GetComponent<PlayerLateMovement>().enabled = true;
        endPoint._endPlayer.GetComponent<PlayerNextMovement>().enabled = false;
        endPoint._nextLevelPanel.SetActive(false);
        endPoint._ch9.transform.position=new Vector3(0, 0.5f, -1.82f);
        endPoint._endPlayer.transform.position=new Vector3(0, 0.5f, -1.82f);
        endPoint._player.transform.position=new Vector3(0, 0.5f, -1.82f);
        _level01.SetActive(false);
        _level02.SetActive(true);
        _level02.transform.position = new Vector3(-37, -25, 274);
        collectObject = 1;
    }
    public void Restart()
    {
        
        Time.timeScale = 1;
        _restartPanel.SetActive(false);
        collectObject = 1;
        _player.transform.position = new Vector3(0, 0.5f, -1.82f);
        _clone.transform.position = new Vector3(0, 0.5f, -1.82f);

    }

    // Update is called once per frame
    void Update()
    {
        _CounterTxt.text = collectObject.ToString();
        if (collectObject == 0)
        {
            _restartPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
