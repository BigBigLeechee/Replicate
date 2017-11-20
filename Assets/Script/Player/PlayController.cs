using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour {

	private static float JUMP_LIMIT = 0.4f;  //跳跃的音量限制
	private static float MOVE_LIMIT = 0.1f; //移动的音量限制

    public float moveFroce = 5f;
    public float jumpFroce = 50f;

    public float maxMoveSpeed = 5f;    //最大的移动速度
	public Animator playerAnimator;   //控制玩家动画的控制器

    private Rigidbody2D mRigidbody;
    // Use this for initialization
    void Start () {
		mRigidbody = GetComponent<Rigidbody2D>();
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

        mRigidbody.AddForce(Vector2.right * moveFroce, ForceMode2D.Impulse);

        if(mRigidbody.velocity.x > maxMoveSpeed){
			mRigidbody.velocity = new Vector2(maxMoveSpeed , mRigidbody.velocity.y);
		}

        playerAnimator.SetInteger("Move", 1);
    }

	/**
	玩家跳跃的方法
	 */
	private void PlayerJump(){
        mRigidbody.AddForce(Vector2.up * jumpFroce, ForceMode2D.Impulse);

        playerAnimator.SetInteger("Jump", 0);
    }

}
