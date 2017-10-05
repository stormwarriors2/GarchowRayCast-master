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
      // OnTriggerEnter2D(player);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       PlayerController player = collision.GetComponent<PlayerController>();
        print("Hello");
        if (player != null)
        {
            print("fuckkk");
            GameController.Lose();
        }
      //  if (player.x == this.x && player.transform.y )
    }
}
