using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points = 10;
    public float speedIncrease = 10f; 
    private Uimanager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<Uimanager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Proyectil"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
            GameManager.Instance.AddScore(points); 

            
           wheelController1 player = FindObjectOfType<wheelController1>();
            if (player != null)
            {
                player.IncreaseSpeed(speedIncrease);

                
                if (uiManager != null)
                {
                    uiManager.ShowSpeedIncreaseMessage(speedIncrease);
                }

               
                if (AudioManager.Instance != null)
                {
                    AudioManager.Instance.PlayPointSound();
                }
            }
        }
    }
}
