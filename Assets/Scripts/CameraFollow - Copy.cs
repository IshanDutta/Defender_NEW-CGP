using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float followSpeed = 2f;
    public Transform target;
    public float xOffset = 1f;
    public bool doLerp = true;
    public float hyperspaceLerp = 0.1f; 

    // Update is called once per frame
    void Update()
    {
        if(doLerp == true)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow) && xOffset < 0)
            {
                xOffset = xOffset * -1;
            }

            else if (Input.GetKeyDown(KeyCode.D) && xOffset < 0)
            {
                xOffset = xOffset * -1;
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow) && xOffset > 0)
            {
                xOffset = xOffset * -1;
            }

            else if (Input.GetKeyDown(KeyCode.A) && xOffset > 0)
            {
                xOffset = xOffset * -1;
            }
            Vector3 newpos = new Vector3(target.position.x + xOffset, 1f, -20f);
            transform.position = Vector3.Slerp(transform.position, new Vector3(newpos.x, 0, newpos.z), followSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            //go instantly there, no transition 
            doLerp = false;
            Vector3 afterhyperspace = new Vector3(target.position.x, target.position.y, target.position.z);
            //transform.position = Vector3.Slerp(transform.position, afterhyperspace, hyperspaceLerp * Time.deltaTime);
            doLerp = true;
        }
    }
}