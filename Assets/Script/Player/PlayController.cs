using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour {

	private static float JUMP_LIMIT = 0.4f;  //跳跃的音量限制
	private static float MOVE_LIMIT = 0.1f; //移动的音量限制


	public float maxMoveSpeed = 5f;    //最大的移动速度
	public Animator playerAnimator;   //控制玩家动画的控制器
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//获取音量
		float volume = MicrophoneInput.Instance.getVolume();

		if(volume > JUMP_LIMIT){
			//TODO: Jump
			PlayerJump();
		}

		if(volume > MOVE_LIMIT){
			//TODO: Move
			PlayerMove();
		}

	}


	/**
	玩家移动的方法
	 */
	private void PlayerMove(){

		Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
			if(rigidbody.velocity.x > maxMoveSpeed){
				rigidbody.velocity = new Vector2(maxMoveSpeed , rigidbody.velocity.y);
			}
	}

	/**
	玩家跳跃的方法
	 */
	private void PlayerJump(){

		
	}

}
