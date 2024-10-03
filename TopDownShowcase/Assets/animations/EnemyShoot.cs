using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;

    [SerializeField]
    float bulletSpeed = 10.0f;

    [SerializeField]
    float bulletLifetime = 2.0f;
    float timer = 0;
    [SerializeField]
    float shootDelay = 0.5f;

    GameObject player;
    
    [SerializeField]
    float shootDistance = 5f;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // if player gets within certain distance
        Vector3 ShootDir = player.transform.position - transform.position;

        if (ShootDir.magnitude < shootDistance && timer > shootDelay)
        {
            // shoot twards the player
            //spawn the bullet
            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);
            ShootDir.Normalize();
            bullet.GetComponent<Rigidbody2D>().velocity = ShootDir * bulletSpeed;
            // delay the next bullet
            timer = 0;
            Destroy(bullet, bulletLifetime);

        }
    }
}
