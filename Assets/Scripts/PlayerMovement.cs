using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float movespeed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movey = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(movex, movey).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2 (moveDirection.x*movespeed, moveDirection.y*movespeed);
    }
}
