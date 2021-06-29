using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralManager : MonoBehaviour
{
    // add reference to PowerupManager
    public GameObject powerupManagerObject;
    private PowerUpManager powerUpManager;

	public GameObject gameManagerObject;
	private GameManager gameManager;

	public static CentralManager centralManagerInstance;

    void  Awake() 
    {
		centralManagerInstance = this;
	}
    
    // Start is called before the first frame update
    void Start()
    {
        powerUpManager = powerupManagerObject.GetComponent<PowerUpManager>();
        gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void damagePlayer() 
    {
	    gameManager.damagePlayer();
    }

    public void increaseScore()
    {
        gameManager.increaseScore();
    }

    public void consumePowerup(KeyCode k, GameObject g) {
        powerUpManager.consumePowerup(k,g);
    }

    public void addPowerup(Texture t, int i, ConsumableInterface c) {
        powerUpManager.addPowerup(t, i, c);
    }
}
