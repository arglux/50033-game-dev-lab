using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    public void StartButtonClicked()
    {
        // Debug.Log("Starting Game!");
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name != "Score" &&
                eachChild.name != "PowerUps" 
            )
            {
                // Debug.Log("Child found. Name: " + eachChild.name);
                // disable all ui's children except score
                eachChild.gameObject.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
