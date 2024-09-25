using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    float health = 10;

    [SerializeField]
    string leverToLoad = "lose";

    [SerializeField]
    string GameEnd = "win";
    float maxHP;
    [SerializeField]
    Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = health;
        healthBar.fillAmount = health / maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //IF we hit an enemy, reduce player hp
        if (collision.gameObject.tag == "Enemy")
        {
            healthBar.fillAmount = health / maxHP;
            health -= 1;
            // add consequences
            // If health gets too low, reload the current level
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
        if (collision.gameObject.tag == "coin")
        {
            SceneManager.LoadScene(GameEnd);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {

            health -= 2;
            healthBar.fillAmount = health / maxHP;
            if (health <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene(levelToLoad);
            }
        }
    }

    private float GetHealth()
    {
        return health;
    }



    //IF we run into healer, add restore HP to the player 
    

}
