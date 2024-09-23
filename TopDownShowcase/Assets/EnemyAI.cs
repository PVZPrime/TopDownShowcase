using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    [SerializeField]
    float chaseSpeed = -5.0f;
    [SerializeField]
    float chaseTriggerDistance = 10f;
    [SerializeField]
    bool goHome = true;
    Vector3 homePosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        homePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //the chase direction is destination - enemy starting position
        Vector3 PlayerPosition = player.transform.position;
        Vector3 ChaseDir = PlayerPosition - transform.position;
        Vector3 homeDir = homePosition - transform.position;
        if (ChaseDir.magnitude < chaseTriggerDistance)
        {
            //Move twards the player 
            ChaseDir.Normalize();
            GetComponent<Rigidbody2D>().velocity = ChaseDir * chaseSpeed;
        }
        else if (goHome)
        {
            if (homeDir.magnitude < 0.1f)
            {
                transform.position = homePosition;
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
            else
            {
                homeDir.Normalize();
                GetComponent<Rigidbody2D>().velocity = homeDir * chaseSpeed;
            }
        }
        else
        {
            //if the player is NOT close, stop moving 
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;


        }
    }
}
