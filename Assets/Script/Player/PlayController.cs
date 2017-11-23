using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayController : MonoBehaviour {

	private static float JUMP_LIMIT = 0.4f;  //跳跃的音量限制
	private static float MOVE_LIMIT = 0.1f; //移动的音量限制

    public float jumpCDTimer = 2f;      //跳跃的CD
    private float jumpTimer = 0f;

    public float moveFroce = 30f;        //移动的力
    public float jumpFroce = 500f;       //跳跃的力

    public float maxMoveSpeed = 5f;    //最大的移动速度
	private Animator mPlayerAnimator;   //控制玩家动画的控制器

    private Rigidbody2D mRigidbody;
    // Use this for initialization
    void Start () {
		mRigidbody = GetComponent<Rigidbody2D>();
        mPlayerAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
        //获取音量
        float volume = MicrophoneInput.Instance.getVolume();

        jumpTimer += Time.deltaTime;

        if(volume > JUMP_LIMIT && jumpTimer > jumpCDTimer){
			//TODO: Jump
			PlayerJump(volume);
            jumpTimer = 0f;
        }
		if(volume > MOVE_LIMIT){
			//TODO: Move
			PlayerMove(volume);
		}

	}


	/**
	玩家移动的方法
	 */
	private void PlayerMove(float percent){

        mRigidbody.AddForce(Vector2.right * moveFroce * percent, ForceMode2D.Force);

        if(mRigidbody.velocity.x > maxMoveSpeed){
			mRigidbody.velocity = new Vector2(maxMoveSpeed , mRigidbody.velocity.y);
		}

        mPlayerAnimator.SetTrigger("Move");
    }

	/**
	玩家跳跃的方法
	 */
	private void PlayerJump(float percent){
        mRigidbody.AddForce(Vector2.up * jumpFroce * percent, ForceMode2D.Force);

        mPlayerAnimator.SetTrigger("Jump");
    }


}
