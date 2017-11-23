using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Equals("Player")){
            GameController.Instance.GameOver();
        }
    }
    
	private void OnTriggerEnter2D(Collider2D other) {
		 if(other.gameObject.tag.Equals("Player")){
            GameController.Instance.GameOver();
        }
    }
}
