using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMushroom : MonoBehaviour, ConsumableInterface
{
    public Texture t;
	public void consumedBy(GameObject player){
		// give player jump boost
		player.GetComponent<PlayerController>().speed *= 2;
		StartCoroutine(removeEffect(player));
	}

	IEnumerator removeEffect(GameObject player){
		yield return new WaitForSeconds(10.0f);
		player.GetComponent<PlayerController>().speed /= 2;
	}

	void  OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("Player")){
			// update UI
			CentralManager.centralManagerInstance.addPowerup(t, 1, this);
		}
	}
	
}
