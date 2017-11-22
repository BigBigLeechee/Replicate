using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFroce : MonoBehaviour {

    public float minDistance = 5f;  // 玩家和镜头的最小距离
    public Transform playerTransform;//玩家的位置
    public float speed = 3f; //镜头移动的速度

	
	// Update is called once per frame
	void Update () {

		if(Vector2.Distance(this.transform.position,playerTransform.position) < minDistance){
            MoveToPosition();
        }
	}

	/**
	使得镜头移动到相应的地方
	 */
	private void MoveToPosition(){
        //获取将要去到的地点
        Vector3 target = this.transform.position;
        target.x += minDistance;

		//移动到将要去到的地点
        this.transform.position =
        	 Vector3.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
    }
}
