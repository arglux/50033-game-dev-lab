using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private BoxCollider2D coinCollision;
    private SpriteRenderer coinSprite;
    private AudioSource coinAudio;
    // Start is called before the first frame update

    void Start()
    {
        coinCollision = GetComponent<BoxCollider2D>();
        coinSprite = GetComponent<SpriteRenderer>();
        coinAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            coinAudio.PlayOneShot(coinAudio.clip);
            coinCollision.enabled = false;
            coinSprite.enabled = false;
            CentralManager.centralManagerInstance.increaseScore();
            Destroy(gameObject, coinAudio.clip.length);
        }
        
    }
}
