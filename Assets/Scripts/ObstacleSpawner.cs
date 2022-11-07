using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Obstacle;
    public float MaxTime = 3.5f;
    float timer;
    public float MaxY, MinY;
    float randomY;
    void Start()
    {
       // InstantiateObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GameOver&& GameManager.GameStarted)
        {
            timer += Time.deltaTime;
            if (timer >= MaxTime)
            {
                randomY = Random.Range(MinY, MaxY);
                InstantiateObject();
                timer = 0;
            }
        }
      
        
    }
    public void InstantiateObject()
    {
        GameObject newObstacle = Instantiate(Obstacle);
        newObstacle.transform.position = new Vector2(transform.position.x,randomY);
    }
}
