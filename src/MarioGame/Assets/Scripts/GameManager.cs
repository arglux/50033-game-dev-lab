using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public delegate void gameEvent();
    public static event gameEvent OnPlayerDeath;
    public static event gameEvent OnCoinCollected;

    private AudioMixerSnapshot snapshot; 
    public AudioMixer mixer;
    private AudioSource gameOverAudioSource;

    public Text score;
	private int playerScore = 0;
	
	public void increaseScore() 
    {
		playerScore += 1;
		score.text = "SCORE: " + playerScore.ToString();
        OnCoinCollected();
	}

    public void damagePlayer()
    {
	    OnPlayerDeath();
        snapshot = mixer.FindSnapshot("Game Over");
        // then transition
        snapshot.TransitionTo(.01f);
        gameOverAudioSource.PlayOneShot(gameOverAudioSource.clip);
        
    }   

    // Start is called before the first frame update
    void Start()
    {
        gameOverAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
