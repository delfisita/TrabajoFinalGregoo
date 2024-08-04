using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Obstacle : MonoBehaviour
{

   wheelController1 playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindObjectOfType<wheelController1>();
    }


    private void Update()
    {

    }
}