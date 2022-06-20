using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip coinSFX;
    [SerializeField] private UIManager uiManager;
    private int collectedAmount = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable"))
        {
            audioSource.clip = coinSFX;
            audioSource.Play();
            collectedAmount++;
            uiManager.UpdateCollected(collectedAmount);
            Destroy(other.gameObject);
        }
    }
}
