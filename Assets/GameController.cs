﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {
    public Transform player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void Lose()
    {
       if (PlayerController.life < 0) 
        {
            SceneManager.LoadScene("MainMenu");
        }
        
         
    }
}
