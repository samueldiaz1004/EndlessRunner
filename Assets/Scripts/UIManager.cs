using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text collected;
    [SerializeField] private GameObject retryBtn;
    [SerializeField] private GameObject gameOverScreen;

    public void UpdateCollected(int amount)
    {
        collected.text = "Score: " + amount;
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void ShowRetryBtn()
    {
        retryBtn.SetActive(true);
    }
}
