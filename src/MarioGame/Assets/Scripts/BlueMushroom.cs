using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMushroom : MonoBehaviour, ConsumableInterface
{
    public Texture t;
	public void consumedBy(GameObject player){
		// give player jump boost
		player.GetComponent<PlayerController>().upSpeed  +=  10;
		StartCoroutine(removeEffect(player));
	}

	IEnumerator  removeEffect(GameObject player){
		yield  return  new  WaitForSeconds(5.0f);
		player.GetComponent<PlayerController>().upSpeed  -=  10;
	}
}
