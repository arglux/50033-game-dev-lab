using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PowerUpIndex
{
    GREENMUSHROOM = 0,
    BLUEMUSHROOM = 1
}
public class PowerUpManagerEV : MonoBehaviour
{
    // reference of all player stats affected
    public IntVariable marioJumpSpeed;
    public IntVariable marioMaxSpeed;
    public PowerUpInventory powerUpInventory;
    public List<GameObject> powerUpIcons;
    private AudioSource powerUpAudio;

    void Start()
    {
        powerUpAudio = GetComponent<AudioSource>();
        if (!powerUpInventory.gameStarted)
        {
            powerUpInventory.gameStarted = true;
            powerUpInventory.Setup(powerUpIcons.Count);
            resetPowerUp();
        }
        else
        {
            // re-render the contents of the powerup from the previous time
            for (int i = 0; i < powerUpInventory.Items.Count; i++)
            {
                PowerUp p = powerUpInventory.Get(i);
                if (p != null)
                {
                    AddPowerUpUI(i, p.powerUpTexture);
                }
            }
        }
    }

    public void resetPowerUp()
    {
        for (int i = 0; i < powerUpIcons.Count; i++)
        {
            powerUpInventory.Remove(i);
            powerUpIcons[i].SetActive(false);
        }
    }

    void AddPowerUpUI(int index, Texture t)
    {
        powerUpIcons[index].GetComponent<RawImage>().texture = t;
        powerUpIcons[index].SetActive(true);
    }

    public void AddPowerUp(PowerUp p)
    {
        powerUpInventory.Add(p, (int) p.index);
        AddPowerUpUI((int)p.index, p.powerUpTexture);
    }

    public void OnApplicationQuit()
    {
        resetPowerUp();
    }

    public void AttemptConsumePowerUp(KeyCode key) {
        if (key == KeyCode.Z && powerUpInventory.Get(0) != null) { // consume if exist in inventoy
            Debug.Log("Z pressed");
            CastEffect(0);
        }
        if (key == KeyCode.X && powerUpInventory.Get(1) != null) {
            Debug.Log("X pressed");
            CastEffect(1);
        }
    }

	public void CastEffect(int index){
        Debug.Log("casting");
		PowerUp p = powerUpInventory.Get(index);
        powerUpAudio.PlayOneShot(powerUpAudio.clip);
        if (index == 0) {
            Debug.Log(marioMaxSpeed);
            marioMaxSpeed.ApplyChange(p.absoluteSpeedBooster);
            StartCoroutine(RemoveEffect(p));
            Debug.Log(marioMaxSpeed);
        }
        if (index == 1) {
            Debug.Log(marioJumpSpeed);
            marioJumpSpeed.ApplyChange(p.absoluteJumpBooster);
            StartCoroutine(RemoveEffect(p));
            Debug.Log(marioJumpSpeed);
        }

        powerUpInventory.Remove(index);
        powerUpIcons[index].SetActive(false);
	}

	IEnumerator RemoveEffect(PowerUp p){
		yield return new WaitForSeconds(p.duration);
		marioMaxSpeed.ApplyChange(-p.absoluteSpeedBooster);
        marioJumpSpeed.ApplyChange(-p.absoluteJumpBooster);
        Debug.Log("uncasting");
	}

 }