using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] UIManager uiManager;
    [SerializeField] SoundManager soundManager;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip gameOverMusic;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.clip = deathSFX;
            audioSource.Play();
            soundManager.ChangeBGM(gameOverMusic);
            uiManager.ShowGameOverScreen();
            uiManager.ShowRetryBtn();
            Destroy(other.gameObject);
        }
    }
}
