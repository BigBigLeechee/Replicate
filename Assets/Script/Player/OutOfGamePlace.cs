using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfGamePlace : MonoBehaviour {

    private float maxDistanceToCamera = 5f;

	// Update is called once per frame
	void Update () {
		if(IsOutOfGamePlace()){
            GameController.Instance.GameOver();
        }
	}


	private bool IsOutOfGamePlace(){
		if(this.transform.position.y > Const.CAMERA_TOP_Y + maxDistanceToCamera){
            return true;
        }

        return false;
    }
}
