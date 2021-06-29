using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public float speed;
    public float upImpulse;
    // public GameObject playerObject;

    private Rigidbody2D mushroomBody;
    private BoxCollider2D mushroomCollider;
    private SpriteRenderer mushroomSprite;
    private float currentDirection;
    private bool onGroundState = false;
    private AudioSource mushroomAudio;
    private bool collected = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D marioBody = GameObject.Find("Mario").GetComponent<Rigidbody2D>();
        // Debug.Log(marioBody.velocity.x);
        currentDirection = Mathf.Sign(marioBody.velocity.x + 0.2f); // either -1 or 1 -> determines direction of launch for mushroom
        Application.targetFrameRate = 30;

        mushroomSprite = GetComponent<SpriteRenderer>();
        mushroomCollider = GetComponent<BoxCollider2D>();
        mushroomAudio = GetComponent<AudioSource>();
	    mushroomBody = GetComponent<Rigidbody2D>();
        mushroomBody.AddForce(new Vector2(2.2f, 2.2f) * upImpulse * currentDirection, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (onGroundState) 
        {
            mushroomBody.velocity = new Vector2(currentDirection * speed, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") | col.gameObject.CompareTag("Obstacles")) 
        {  
            // Debug.Log("Mushroom Moving");
            onGroundState = true;    
        }
        if (col.gameObject.CompareTag("Player"))
        {
            collected = true;
            mushroomAudio.PlayOneShot(mushroomAudio.clip);
            currentDirection = 0;
            mushroomCollider.enabled = false;
            mushroomSprite.enabled = false;
        }
        if (col.gameObject.CompareTag("Wall"))
        {
            currentDirection = currentDirection * -1;    
        }
    }
    void  OnBecameInvisible()
    {
        if (collected) {
            Debug.Log("collected.");
            Destroy(gameObject, mushroomAudio.clip.length);
        } else {
            Destroy(gameObject);
        }
    }
}
