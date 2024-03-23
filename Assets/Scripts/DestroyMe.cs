using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    public bool IsOnScreen;
    public int bombCount;
    public GameObject PlayerShip;
    public PlayerShip _PlayerShip;
    
    public void DestroyEffect()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    public void Start()
    {
        PlayerShip = GameObject.Find("Player");
        PlayerShip.GetComponent<PlayerShip>();
    }

    public void Update()
    {
        bombCount = PlayerShip.bombcount;
        //three conditions must be met
        if (Input.GetKeyDown(KeyCode.E))
        {
            if ((bombCount > 3) && (IsOnScreen = true))
            {
                DestroyEffect();
            }
        }
    }
}
