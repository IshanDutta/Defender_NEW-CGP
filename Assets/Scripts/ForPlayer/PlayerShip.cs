using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public float speed;
    float horizontal;
    float vertical;
    public float interia;
    public Vector3 moveDirection;
    public float lerpedHorizontal;
    public Gun _gun;

    public int bombcount = 3;
    public GameObject onScreenEmpty;

    private int odds;

    private void Start()
    {
        onScreenEmpty = GameObject.Find("OnScreenEmpty");
        onScreenCollider = onScreenEmpty.GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        lerpedHorizontal = Mathf.Lerp(lerpedHorizontal, horizontal, interia * Time.deltaTime);
        moveDirection = new Vector3(lerpedHorizontal, vertical, 0);
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
        if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("Hyperspace");
            odds = Random.Range(1, 4);
            if(odds == 1)
            {
                //Player.GetComponent<OnScreen>().PlayerDies;
            }
            else if (odds > 1)
            {
                transform.position = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-1.0f, 3.0f), 0);
            }

        }
        if (Input.GetKeyDown(KeyCode.E) && bombcount > 0)
        {
            Debug.Log("Bomb");
        }
        else
        {
            Debug.Log("no bombs left");
            return;
        }
    }

}
