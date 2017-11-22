using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag.Equals("Player")){
            GameController.Instance.GameOver();

            Destroy(this.gameObject);
        }
	}
}
