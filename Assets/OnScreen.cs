using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreen : MonoBehaviour
{
    public bool publicIsOnScreen;
    public List<GameObject> onScreenEnemies = new List<GameObject>();
    public DestroyMe _DestroyMe;

    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        
    }
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
            //add enemy to list of enemies 
            onScreenEnemies.Add(other.gameObject);
            target.IsOnScreen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<DestroyMe>(out var target))
        {
            onScreenEnemies.Remove(other.gameObject);
            target.IsOnScreen = false;
        }

    }
    public void DestroyObjectsinList()
    {
        Debug.Log("attempted to destroy objects in list");
        foreach(GameObject enemy in onScreenEnemies)
        {
            _DestroyMe = enemy.GetComponent<DestroyMe>();
            _DestroyMe.DestroyEffect();
        }
    }
    public void Test()
    {
        Debug.Log("test for onscreen");
    }
}
