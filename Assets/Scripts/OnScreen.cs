using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreen : MonoBehaviour
{
    public bool publicIsOnScreen;
    public List<GameObject> onScreenEnemies = new List<GameObject>();
    private DestroyMe _DestroyEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            foreach (var x in onScreenEnemies)
            {
                Debug.Log("this lander is on screen: " + x.ToString());
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DestroyMe>(out var target))
        {
            publicIsOnScreen = true;

            //add enemy to list of enemies 
            onScreenEnemies.Add(other.gameObject);
            
            /*target.DestroyEffect();
            Destroy(gameObject);*/
        }
        else
        {
            publicIsOnScreen = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<DestroyMe>(out var target))
        {
            onScreenEnemies.Remove(other.gameObject);
        }

    }
    public void DestroyObjectsinList()
    {
        Debug.Log("attempted to destroy objects in list");
        foreach(GameObject enemy in onScreenEnemies)
        {
            _DestroyEffect = enemy.GetComponent<DestroyMe>();
            _DestroyEffect.DestroyEffect();
        }
    }
}
