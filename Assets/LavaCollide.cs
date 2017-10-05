using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCollide : MonoBehaviour {
    public GameObject player;
    PlayerController pc;
    // Use this for initialization

    void Start () {

        pc = GameObject.Find("Player").GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
     


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
       PlayerController player = collision.GetComponent<PlayerController>();
        print("Hello");
        if (player != null)
        {
            print("yes");
            GameController.Lose();
        }*/
    }
}
