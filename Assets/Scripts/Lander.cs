using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Lander : MonoBehaviour
{
    public bool isMovingRight;
    public int decidingNumber;
    public float moveSpeed;
    public float descendingSpeed;
    public bool shouldMoveDown;
    public Transform player;
    public GameObject projectilePrefab;
    public float fireRate;
    public bool canShoot;
    public float targetRange;
    public float _timeSinceFired;
    public LayerMask hostageCheck;
    public bool hasHostage;
    public bool collectedHostage;

    // Start is called before the first frame update
    void Start()
    {
        decidingNumber = Random.RandomRange(1, 3);

        if(decidingNumber == 1)
        {
            isMovingRight = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else 
        {
            isMovingRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHostage && !collectedHostage)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }

        float distToTarg = Vector2.Distance(transform.position, player.position);

        _timeSinceFired -= Time.deltaTime;

        if (distToTarg < targetRange)
        {
            canShoot = true;

        }

        if (canShoot && _timeSinceFired < 0)
        {
            Shoot();
        }

        if (shouldMoveDown)
        {
            transform.Translate(Vector3.down * descendingSpeed * Time.deltaTime);
        }

        if (!collectedHostage && !hasHostage)
        {
            CheckForHostage();
        }

        if (hasHostage && !collectedHostage)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime); 
        }

        if (collectedHostage)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        }
    }

    void CheckForHostage()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1000, hostageCheck);
        if (hit)
        {
            if (!hit.transform.GetComponent<Hostage>().hasChaser)
            {
                hit.transform.GetComponent<Hostage>().hasChaser = true;
                hasHostage = true;
            }
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hi");
        if(collision.gameObject.layer == 6)
        {
            shouldMoveDown = false;
        }

        if(collision.gameObject.layer == 7)
        {
            hasHostage = false;
            collectedHostage = true;
            collision.transform.parent = transform;
        }
    }

    void Shoot()
    {
        _timeSinceFired = fireRate;
        GameObject go = Instantiate(projectilePrefab, transform.position, transform.rotation);
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        go.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        go.transform.Rotate(Random.Range(-10, 10), Random.Range(-10, 10), 0);
        go.transform.localScale = new Vector3(2, 2, 2);
        go.GetComponent<Projectile>().myShooter = transform;
    }
}
