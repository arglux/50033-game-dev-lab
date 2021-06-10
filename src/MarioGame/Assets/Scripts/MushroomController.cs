using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public float speed;
    public float upImpulse;
    // public GameObject playerObject;

    private Rigidbody2D mushroomBody;
    private float currentDirection;
    private bool onGroundState = false;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D marioBody = GameObject.Find("Mario").GetComponent<Rigidbody2D>();
        Debug.Log(marioBody.velocity.x);
        currentDirection = Mathf.Sign(marioBody.velocity.x + 0.2f); // either -1 or 1
        Application.targetFrameRate =  30;
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
            currentDirection = 0;    
        }
        if (col.gameObject.CompareTag("Wall"))
        {
            currentDirection = currentDirection * -1;    
        }
    }
    void  OnBecameInvisible()
    {
	    Destroy(gameObject);
    }
}
