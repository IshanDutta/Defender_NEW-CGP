using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnScreen : MonoBehaviour
{
    public bool publicIsOnScreen;
    public List<Transform> onScreenEnemies = new List<Transform>();
    public DestroyMe _DestroyMe;
    public PlayerShip player;

    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<DestroyMe>(out var target) && !other.GetComponent<Projectile>())
        {
            //add enemy to list of enemies 
            onScreenEnemies.Add(other.transform);
            target.IsOnScreen = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<DestroyMe>(out var target) && !other.GetComponent<Projectile>())
        {
            onScreenEnemies.Remove(other.transform);
            target.IsOnScreen = false;
        }

    }

    public void ActivateBomb()
    {
        for (int i = 0; i < onScreenEnemies.Count; i++)
        {
            print("hi");
            onScreenEnemies[i].GetComponent<DestroyMe>().DestroyEffect();
            i -= 1;
        }
    }
    public void Test()
    {
        Debug.Log("test for onscreen");
    }
}
