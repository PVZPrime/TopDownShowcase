using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10f;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {//check for horizantal and vertical input 
        //move player based on that input 
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        //velocity is a Vector2 varibale, storing 2 flotes, x and y
        GetComponent<Rigidbody2D>().velocity = new Vector2(xInput, yInput) * moveSpeed;
    }
}
