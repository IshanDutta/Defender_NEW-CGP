using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lander_Movement : MonoBehaviour
{
    private float latestDirectionChangeTime;
    public float directionChangeTime = 3f;
    public float speed = 2f;
    private Vector2 movementDirection;
    public int horizontalMovement;
    public float distanceToTarg;
    public Transform ground;
    public float maxDistanceToGround;
    public bool tooFarDown;
    Lander_NEW lander;
    public BackgroundScroller backGround;
    PlayerShip player;

    void Start()
    {
        distanceToTarg = transform.position.y - ground.position.y;
        backGround = GameObject.Find("Background").GetComponent<BackgroundScroller>();
        player = GameObject.Find("Player").GetComponent<PlayerShip>();
        ground =backGround.transform.Find("Ground");
        latestDirectionChangeTime = 0f;
        lander = GetComponent<Lander_NEW>();
        calcuateNewMovementVector();

        if(horizontalMovement > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalMovement < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy

      
            if (movementDirection.y == 0)
            {


                if (distanceToTarg > maxDistanceToGround && !tooFarDown)
                {
                    movementDirection = new Vector2(horizontalMovement, -1).normalized;
                }
                else
                {
                    if (!tooFarDown)
                    {
                        movementDirection = new Vector2(horizontalMovement, Random.Range(-1.0f, 1.0f)).normalized;
                    }
                    else
                    {
                        movementDirection = new Vector2(horizontalMovement, 1).normalized;
                    }
                }
            }
            else
            {
                movementDirection = new Vector2(horizontalMovement, 0).normalized;
            }

            directionChangeTime = Random.Range(3, 7);
        
    }

    void Update()
    {
        if (lander.landerState == Lander_NEW.LanderState.patrol)
        {
            //if the changeTime was reached, calculate a new movement vector
            if (Time.time - latestDirectionChangeTime > directionChangeTime)
            {
                latestDirectionChangeTime = Time.time;
                calcuateNewMovementVector();
            }

            distanceToTarg = transform.position.y - ground.position.y;
            //move enemy: 
            transform.position = new Vector2(transform.position.x + (movementDirection.x * speed * Time.deltaTime), transform.position.y + (movementDirection.y * Time.deltaTime));
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            tooFarDown = true;
            calcuateNewMovementVector();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            tooFarDown = true;
            calcuateNewMovementVector();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            tooFarDown = false;
        }
    }
}
