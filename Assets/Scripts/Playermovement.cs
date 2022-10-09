using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpSpace = 5f;
    [SerializeField] LayerMask ground;
    [SerializeField] Transform groundCheck;
    [SerializeField] AudioSource jumSound;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float xValue = Input.GetAxis("Horizontal")*speed;
        float zValue = Input.GetAxis("Vertical")*speed;
        rb.velocity = new Vector3(xValue, rb.velocity.y, zValue);
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpSpace, rb.velocity.y);
        jumSound.Play();
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
    bool isGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
