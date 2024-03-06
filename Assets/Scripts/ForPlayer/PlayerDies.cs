using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDies : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    public void KillPlayer()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //disable image and move script so player essentially "dies"
        //cant use set active or else player dies script wont work 
        GetComponent<Renderer>().enabled = false;
        GetComponent<PlayerShip>().enabled = false;

        //a lil delay before respawn

        //if(lives => 0) { }
        StartCoroutine(RespawnDelay());
    }
    IEnumerator RespawnDelay()
    {
        yield return new WaitForSeconds(3f);

        // This line will be executed after 3 seconds passed
        GetComponent<Renderer>().enabled = true;
        GetComponent<PlayerShip>().enabled = true;
        //reset pos
        gameObject.transform.position = new Vector3 (0, 0, 0);
    }

}
