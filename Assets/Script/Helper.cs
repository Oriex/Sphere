using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Helper : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _target;
    private GameObject _player;
    public Animator _animator;
    public float Distanse;
    public float minDist;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _target = _player.transform;
    }

    private void Update()
    {
        Distanse = Vector3.Distance(transform.position, _target.position);

        if (Distanse <= minDist)
        {
            transform.LookAt(_target);
            _agent.speed = 0;
            _animator.SetFloat("Blend", 0);
        }
        else
        {
            
            _agent.SetDestination(_target.position);
            _agent.speed = 280;
            _animator.SetFloat("Blend", 1);
        }
        
    }
}
