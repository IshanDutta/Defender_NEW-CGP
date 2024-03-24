using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableForRespawn : MonoBehaviour
{
    public bool notLander;
    public float timer;
    BackgroundScroller background;

    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("Background").GetComponent<BackgroundScroller>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;


    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (notLander && transform.parent == null)
        {
            if (timer < 0)
            {
                if (collision.transform == background.leftBorder.transform)
                {
                    
                    transform.position = new Vector3(background.rightBorder.position.x, transform.position.y, transform.position.z);
                    timer = 0.1f;
                }
                else if (collision.transform == background.rightBorder.transform)
                {
                    transform.position = new Vector3(background.leftBorder.position.x, transform.position.y, transform.position.z);
                    timer = 0.1f;
                }
            }
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (notLander && transform.parent == null)
        {
            if (timer < 0)
            {
                if (collision.transform == background.leftBorder.transform)
                {

                    transform.position = new Vector3(background.rightBorder.position.x, transform.position.y, transform.position.z);
                    timer = 1f;
                }
                else if (collision.transform == background.rightBorder.transform)
                {
                    transform.position = new Vector3(background.leftBorder.position.x, transform.position.y, transform.position.z);
                    timer = 1f;
                }
            }
        }
    }

}
