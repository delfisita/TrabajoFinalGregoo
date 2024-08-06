using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Uimanager : MonoBehaviour
{
    public TextMeshProUGUI speedIncreaseText; // Referencia al texto de UI
    private float displayTime = 2f; // Tiempo que el mensaje estará visible
    private float timer;

    private void Start()
    {
        speedIncreaseText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (speedIncreaseText.gameObject.activeSelf)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                speedIncreaseText.gameObject.SetActive(false);
            }
        }
    }

    public void ShowSpeedIncreaseMessage(float amount)
    {
        speedIncreaseText.text = "Speed increased by " + amount;
        speedIncreaseText.gameObject.SetActive(true);
        timer = displayTime;
    }
}
