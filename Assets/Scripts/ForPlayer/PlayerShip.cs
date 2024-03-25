using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public Vector3 potentialmovepos;
    public float yval;
    public float maxvertical;

    public GameObject Player;
    public Rigidbody2D rb;
    public float speed;
    public float horizontal;
    float vertical;
    public float interia;
    public Vector3 moveDirection;
    public float lerpedHorizontal;
    public Gun _gun;
    public PlayerDies _playerDies;

    public GameObject[] bombs;
    public int bombcount = 0;
    public int i = 0;
    public GameObject onScreenEmpty;
    public OnScreen _OnScreen;
    //private bool localIsOnScreen;

    private int odds;

    private void Start()
    {
        onScreenEmpty = GameObject.Find("Main Camera");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        lerpedHorizontal = Mathf.Lerp(lerpedHorizontal, horizontal, interia * Time.deltaTime);
        moveDirection = new Vector3(lerpedHorizontal, vertical, 0);
        
        potentialmovepos = transform.position + moveDirection * speed * Time.deltaTime;
        yval = potentialmovepos.y;
        yval = Mathf.Clamp(yval, -4.5f, 3f);
        transform.position = new Vector3(potentialmovepos.x, yval, potentialmovepos.z);

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
            onScreenEmpty.GetComponent<CameraFollow>().doLerp = false;

            Debug.Log("Hyperspace");
            odds = Random.Range(1, 4);
            if(odds == 1)
            {
                _playerDies = GetComponent<PlayerDies>();
                _playerDies.KillPlayer();
            }
            else if (odds > 1)
            {
                transform.position = new Vector3(Random.Range(-30.0f, 30.0f), Random.Range(-1.0f, 3.0f), 0);

                onScreenEmpty.GetComponent<CameraFollow>().TeleportCam();
            }
            onScreenEmpty.GetComponent<CameraFollow>().doLerp = true;

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(i != 3)
            {

                Debug.Log("pressed E for Bomb");

                _OnScreen = onScreenEmpty.GetComponent<OnScreen>();
                _OnScreen.DestroyObjectsinList();

                Destroy(bombs[i]);
                i++;               
            }
        }
        
    }

}
