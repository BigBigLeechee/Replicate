using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

	private int mMaxFallDownCount = 3; //怪物可以掉下去的最大次数
    private int mFallDownCount = 0;  //已经掉下去的次数
    public Transform playerTransform;
    public float speed = 2f;
    
    private Animator mAnimator;
    public float maxLockDistance = 10f; //玩家与怪物的最大距离
    // Use this for initialization
    void Start () {
        mAnimator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Vector2.Distance(playerTransform.position,this.transform.position) < maxLockDistance){
            MoveToPlayer();
        }
	}

	/**
	向玩家移动
	 */
	private void MoveToPlayer(){
        this.transform.position = Vector2.MoveTowards(this.transform.position,
						playerTransform.position,
                        speed * Time.deltaTime);

        MakeItNeverFallDown();
    }


	/**
	使得敌人不会掉下去
	 */
	private void MakeItNeverFallDown(){

		if(this.transform.position.y <= Const.CAMERA_BOTTOM_Y &&
							 mFallDownCount < mMaxFallDownCount){

            this.transform.position = new Vector2(this.transform.position.x, Const.CAMERA_TOP_Y);
            mFallDownCount++;

        }

        FallDown();
    }

	/**
	怪物掉下去
	 */
	private void FallDown(){
		if(this.transform.position.y < Const.CAMERA_BOTTOM_Y){                      
            mAnimator.SetBool("Disappear", true);
            Destroy(this.gameObject);
        }
	}

}
