using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFlag : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Player")){
            GameController.Instance.GameWin();
        }
	}
}
