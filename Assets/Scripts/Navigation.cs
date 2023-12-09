using UnityEngine.AI;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    private GameObject _player;
    private NavMeshAgent _agent;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       _player = GameObject.Find("Player");
        _agent.destination = _player.transform.position;
    }
}
