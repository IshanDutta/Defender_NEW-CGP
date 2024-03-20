using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDies : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    public Transform backGround;
    public InteractableForRespawn[] moveables;


    private void Start()
    {
        backGround = GameObject.Find("Background").transform;

    }
    public void KillPlayer()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //disable image and move script so player essentially "dies"
        //cant use set active or else player dies script wont work 
        GetComponent<Renderer>().enabled = false;
        GetComponent<PlayerShip>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        //a lil delay before respawn

        //if(lives => 0) { }
        StartCoroutine(RespawnDelay());
        StartCoroutine(DyingDelay());
    }
    IEnumerator DyingDelay()
    {
        yield return new WaitForSeconds(3f);
        GetComponent<Collider2D>().enabled = true;
    }
    IEnumerator RespawnDelay()
    {

        yield return new WaitForSeconds(3f);
        MoveEverythingOnRespawn();
        // This line will be executed after 3 seconds passed
        GetComponent<Renderer>().enabled = true;
        GetComponent<PlayerShip>().enabled = true;
        //reset pos
        gameObject.transform.position = new Vector3 (0, 0, 0);
        StartCoroutine(UnParent());
        StartCoroutine(DyingDelay());
    }

    IEnumerator UnParent()
    {
        yield return new WaitForSeconds(0.5f);
        moveables = GameObject.FindObjectsOfType<InteractableForRespawn>();
        foreach (InteractableForRespawn child in moveables)
        {
            if (child != null)
            {
                child.transform.parent = null;
            }
        }
    }

    void MoveEverythingOnRespawn()
    {
        moveables = GameObject.FindObjectsOfType<InteractableForRespawn>();
        foreach (InteractableForRespawn child in moveables)
        {
            child.transform.parent = backGround;
        }
    }


}
