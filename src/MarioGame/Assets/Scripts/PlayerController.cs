using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float speed;
    public float upSpeed;
    public float maxSpeed = 10;

    private Rigidbody2D marioBody;
    private SpriteRenderer marioSprite;
    private Animator marioAnimator;
    private AudioSource marioAudioSource;

    public Transform enemyLocation;
    // public Text scoreText;
    // private int score = 0;
    // private bool countScoreState = false;

    private bool onGroundState = true;
    private bool faceRightState = true;

    void Start()
    {
        // Set to be 30 FPS
	    Application.targetFrameRate =  30;
	    marioBody = GetComponent<Rigidbody2D>();
        marioSprite = GetComponent<SpriteRenderer>();
        marioAnimator = GetComponent<Animator>();
        marioAudioSource = GetComponent<AudioSource>();

        GameManager.OnPlayerDeath += PlayerDiesSequence;
    }

    void FixedUpdate()
    {
      if (Input.GetKeyUp("a") || Input.GetKeyUp("d"))
      {
          // stop
          marioBody.velocity = Vector2.zero;

      }
    
      // dynamic rigidbody
      float moveHorizontal = Input.GetAxis("Horizontal");
      if (Mathf.Abs(moveHorizontal) > 0)
      {
          Vector2 movement = new Vector2(moveHorizontal, 0);
          if (marioBody.velocity.magnitude < maxSpeed) 
          {
              marioBody.AddForce(movement * speed);
          }
      }

      if (Input.GetKeyDown("space") && onGroundState) 
      {
          marioBody.AddForce(Vector2.up * upSpeed, ForceMode2D.Impulse);
          onGroundState = false;
          marioAnimator.SetBool("onGround", onGroundState);
          // countScoreState = true;
      }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground")) 
        {
            onGroundState = true;
            marioAnimator.SetBool("onGround", onGroundState);
            // countScoreState = false;
            // scoreText.text = "SCORE: " + score.ToString();
        }

        if (col.gameObject.CompareTag("Obstacles")) // && Mathf.Abs(marioBody.velocity.y) < 0.01f
        {
            onGroundState = true;
            marioAnimator.SetBool("onGround", onGroundState);
        }
    }

    void  PlayerDiesSequence() {
        // Mario dies
        Debug.Log("Mario dies");
        // do whatever you want here, animate etc
        // ...
    }

    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.gameObject.CompareTag("Enemy"))
    //     {
    //         Debug.Log("You collided with a Goomba!");
    //         SceneManager.LoadScene("SampleScene");
    //     }
    // }

    void PlayJumpSound() 
    {
        marioAudioSource.PlayOneShot(marioAudioSource.clip);
    }

    // Update is called once per frame
    void Update()
    {
        marioAnimator.SetFloat("xSpeed", Mathf.Abs(marioBody.velocity.x));

        if (Input.GetKeyDown("a") && faceRightState) 
        {
            faceRightState = false;
            marioSprite.flipX = true;

            // check speed to skid
            if (Mathf.Abs(marioBody.velocity.x) > 0.5)
            {
                marioAnimator.SetTrigger("onSkid");
                // Debug.Log("skid left");
            }
        }

        if (Input.GetKeyDown("d") && !faceRightState) 
        {
            faceRightState = true;
            marioSprite.flipX = false;

            // check speed to skid
            if (Mathf.Abs(marioBody.velocity.x) > 0.5)
            {
                marioAnimator.SetTrigger("onSkid");
                // Debug.Log("skid right");
            }

        }

        // if (!onGroundState && countScoreState) 
        // {
        //     if(Mathf.Abs(transform.position.x - enemyLocation.position.x) < 0.8f)
        //     {
        //         countScoreState = false;
        //         score++;
        //         Debug.Log(score);
        //     }
        // }


    }
}
