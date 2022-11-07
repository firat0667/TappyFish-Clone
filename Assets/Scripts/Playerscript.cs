using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerscript : MonoBehaviour
{
    // Start is called before the first frame update
    #region Public
    private Rigidbody2D _rb2D;
    [Header("Angles")]
    public int Angle;
    public int MaxAngle;
    public int MinAngle;
    public Score Score;
    public GameManager Manager;
    public Sprite fishDied;
    public ObstacleSpawner spawner;
    public AudioSource swim;
    public AudioSource hit;
    public AudioSource Point;

    #endregion
    #region Private
    [SerializeField]
    private float _speed;
    bool _touchGround;
    SpriteRenderer sp;
    Animator animator;
    #endregion
    void Start()
    {
      
        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.gravityScale = 0;
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.GameOver)
        {
            FishSwim();
        }
        
        
     
    }
    private void FixedUpdate()
    {
        FishRotation();
        // daha smoth olur ;
    }
    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            swim.Play();
            if (!GameManager.GameStarted)
            {
                _rb2D.gravityScale = 1f;
                _rb2D.velocity = Vector2.zero;
                _rb2D.velocity = new Vector2(_rb2D.velocity.x, _speed);
                spawner.InstantiateObject();
                Manager.GameHasStarted();
            }
            _rb2D.velocity = Vector2.zero;
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _speed);
        }
    }
    void FishRotation()
    {
        if (_rb2D.velocity.y > 0)
        {
            if (Angle <= MaxAngle)
            {
                Angle = Angle + 4;
                // yukarı giderken basını kaldırcak
            }
        }
        else if (_rb2D.velocity.y < -1.2f)
        {
            if (Angle > MinAngle)
            {
                Angle = Angle - 2;
                // assağıya inerken kafasını indircek
            }
        }
        if (!_touchGround)
        {
            transform.rotation = Quaternion.Euler(0, 0, Angle);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Arasından geçti");
            Score.Scored();
            Point.Play();
        }
        else if (collision.gameObject.CompareTag("Column") && !GameManager.GameOver)
        {
            //gameover;
            Manager.GameOverClass();
            FishDieEffect();
           // GameOver();
        }
    }
    public void FishDieEffect()
    {
        hit.Play();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("touch  ground");
            // _touchGround = true;
            GameOver();
            
            if (!GameManager.GameOver)
            {
                Manager.GameOverClass();
                FishDieEffect();
            }
            else
            {
                //gameover(fish)
               
            }
        }
       
   }
    void GameOver()
    {
        _touchGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        sp.sprite = fishDied;
        animator.enabled = false;

    }
}
