using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{
    public PlayerNextMovement playerNextMovement;
    public GameObject _endPlayer;
    public GameObject _player;
    public GameObject _ch9;
    
    public GameObject _nextLevelPanel;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clone"))
        {
            Destroy(other.gameObject);
            _player.GetComponent<BoxCollider>().enabled = false;
            playerNextMovement._minMaxXEnd.y = 33.26f;
            playerNextMovement._minMaxXEnd.x = -33.26f;
            _endPlayer.GetComponent<SkinnedMeshRenderer>().enabled = true;
            _endPlayer.GetComponent<PlayerLateMovement>().enabled = false;
            _endPlayer.GetComponent<PlayerNextMovement>().enabled = true;
            _nextLevelPanel.SetActive(true);
            _ch9.gameObject.SetActive(false);
            
            


        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
