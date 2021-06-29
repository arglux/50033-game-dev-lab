using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrick : MonoBehaviour
{
    public GameObject debris;
    public GameObject coin;
    public Vector3 coinOffset;
    private bool broken = false;
    private AudioSource breakBrickAudio;
    // Start is called before the first frame update
    void Start()
    {
        breakBrickAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && !broken)
        {
            broken = true;
            breakBrickAudio.PlayOneShot(breakBrickAudio.clip);
            
            // assume we have 5 debris per box
            for (int x = 0; x<5; x++)
            {
                Instantiate(debris, transform.position, Quaternion.identity);
                
            }
            Instantiate(coin, transform.position + coinOffset, Quaternion.identity);
            gameObject.transform.parent.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.parent.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<EdgeCollider2D>().enabled  =  false;
        }
    }
}
