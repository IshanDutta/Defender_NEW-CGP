using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lander_NEW : MonoBehaviour
{

    public enum LanderState { patrol, attemptToPickUp, pickUp}
    public LanderState landerState;
    public LayerMask hostageLayers;
    private Lander_Movement landerMovement;
    public GameObject myHostage;
    public GameObject carryObj;
    public float checkRate;
    float lastChecked;
    public GameObject mutant;

    // Start is called before the first frame update
    void Start()
    {
        landerMovement = GetComponent<Lander_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (landerState == LanderState.patrol)
        {
            lastChecked -= Time.deltaTime;

            if (lastChecked < 0)
            {
                CheckForHostage();
            }
        }else if(landerState == LanderState.attemptToPickUp)
        {
            transform.Translate(Vector2.down * landerMovement.speed * Time.deltaTime);

            if(myHostage == null)
            {
                landerState = LanderState.patrol;
            }
        }else if(landerState == LanderState.pickUp)
        {
            transform.Translate(Vector2.up * landerMovement.speed * Time.deltaTime);

            if (myHostage == null)
            {
                landerState = LanderState.patrol;
            }

           
        }
    }

    void CheckForHostage()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1000, hostageLayers);
        if (hit.transform != null)
        {
            print(hit.transform.name);
            if (hit.transform.GetComponent<Hostage>())
            {
                if (hit.transform.GetComponent<Hostage>().myChaser == null)
                {

                    lastChecked = checkRate;
                    int n = Random.Range(0, 2);

                    if (n != 0)
                    {
                        hit.transform.GetComponent<Hostage>().myChaser = gameObject;
                        landerState = LanderState.attemptToPickUp;
                        myHostage = hit.transform.gameObject;
                    }


                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(landerState == LanderState.attemptToPickUp && myHostage != null)
        {
            if(collision.gameObject == myHostage)
            {
                PickUp();

            }
        }

        if(collision.gameObject.layer == 8)
        {
            if(landerState == LanderState.pickUp)
            {
                Mutate();
            }
        }

        if (collision.TryGetComponent<PlayerDies>(out var target))
        {
            target.KillPlayer(); 
        }
    }

    void Mutate()
    {
        Instantiate(mutant, transform.position, transform.rotation);
        mutant.transform.rotation = Quaternion.Euler(Vector3.zero);
        Destroy(gameObject);
    }

    void PickUp()
    {
        landerState = LanderState.pickUp;
        GetComponent<Enemy_Shoot>().enabled = false;
        myHostage.transform.position = carryObj.transform.position;
        myHostage.transform.rotation = carryObj.transform.rotation;
        myHostage.transform.parent = carryObj.transform;
    }

    public void DropHostage()
    {
        myHostage.transform.parent = null;
    }
}
