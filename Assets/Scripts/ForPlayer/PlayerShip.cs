using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    float horizontal;
    float vertical;
    public Vector3 moveDirection;

    public Gun _gun;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, vertical, 0);
        transform.position += moveDirection * speed * Time.deltaTime;

        if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("pressed fire!");
            _gun.FireGun();
        }

    }
}
