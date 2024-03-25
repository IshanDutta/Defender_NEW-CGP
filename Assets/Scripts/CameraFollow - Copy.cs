using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class CameraFollow : MonoBehaviour
{

    public float followSpeed = 2f;
    public Transform target;
    public float xOffset = 1f;
    public bool doLerp;
    private void Start()
    {
        doLerp = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (doLerp)
        {

            if (Input.GetKeyDown(KeyCode.R))
            {
                //restarts level 
                string currentSceneName = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentSceneName);
            }
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
        else
        {
            Vector3 newpos = new Vector3(target.position.x + xOffset, 1f, -20f);
            transform.position = new Vector3(newpos.x, 0, newpos.z);
        }
    }
    public void TeleportCam()
    {
        Vector3 newpos = new Vector3(target.position.x + xOffset, 1f, -20f);
        transform.position = new Vector3(newpos.x, 0, newpos.z);
    }
}