using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed;

    float horizontal;
    float vertical;
    public Vector3 moveDirection;

    public Transform gunPos;
    public GameObject projectile;

    public float _timeSinceFired;
    public float fireRate;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontal, vertical, 0);
        transform.position += moveDirection * speed * Time.deltaTime;

        if(horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        _timeSinceFired -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space) && _timeSinceFired < 0)
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        GameObject go = Instantiate(projectile, gunPos.position, gunPos.rotation);
        _timeSinceFired = fireRate;
        go.GetComponent<Projectile>().myShooter = transform;
    }
}
