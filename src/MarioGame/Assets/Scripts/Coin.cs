using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private  BoxCollider2D coinCollision;
    private  SpriteRenderer coinSprite;
    // Start is called before the first frame update
    void Start()
    {
        coinCollision = GetComponent<BoxCollider2D>();
        coinSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            coinCollision.enabled = false;
            coinSprite.enabled = false;
            Destroy(gameObject);
        }
        
    }
}
