using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed;
    BoxCollider2D Box;
    float GroundWidht;
    float obstacleWith;
    void Start()
    {
        if (gameObject.CompareTag("Ground"))
        {
            Box = GetComponent<BoxCollider2D>();
            GroundWidht = Box.size.x;
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            obstacleWith = GameObject.FindGameObjectWithTag("Column").GetComponent<BoxCollider2D>().size.x;
        }
      

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GameOver)
        {
            transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
        }
        

        if (gameObject.CompareTag("Ground"))
        {
            // fixed update de calıstırdıysaydık deltatimea gerek yoktu;
            if (transform.position.x <= -GroundWidht)
            {
                transform.position = new Vector2(transform.position.x + 2 * GroundWidht, transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Obstacle"))
        {
            if (transform.position.x<GameManager.ButtonLeft.x-obstacleWith)
            {
                Destroy(gameObject);
            }
            
        }
       
    }
}
