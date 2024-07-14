using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour
{

    AutoMovimiento playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<AutoMovimiento>();
    }


    private void Update()
    {

    }
}