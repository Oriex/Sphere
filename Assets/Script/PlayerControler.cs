using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float _speed;
    private Vector3 moveDir;
    private Rigidbody rb;
    public Animator animator;
    public GameObject Scin;

    [SerializeField] private FixedJoystick _joystick;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        moveDir = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical).normalized;
       // moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        moveDir = Vector3.ClampMagnitude(moveDir, 1);

        animator.SetFloat("moveSpeed", Vector3.ClampMagnitude(moveDir, 1).magnitude);
        if (moveDir.magnitude > Mathf.Abs(0.05f)) 
        {
            Scin.transform.rotation = Quaternion.Lerp(Scin.transform.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * 20f).normalized;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.TransformDirection(moveDir) * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            _speed = 10;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag =="Finish")
        {
            _speed = 40;
        }
    }
}
