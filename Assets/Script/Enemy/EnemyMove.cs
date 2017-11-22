using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    private static float Y_TOP = 5.5f;
    private static float Y_BOTTOM = -3.5f;

	private int mMaxFallDownCount = 3; //怪物可以掉下去的最大次数
    private int mFallDownCount = 0;  //已经掉下去的次数
    public Transform playerTransform;
    public float speed = 2f;
    
    private Animator mAnimator;
    public float maxLockDistance = 8f; //玩家与怪物的最大距离
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

		if(this.transform.position.y <= Y_BOTTOM &&
							 mFallDownCount < mMaxFallDownCount){

            this.transform.position = new Vector2(this.transform.position.x, Y_TOP);
            mFallDownCount++;

        }

        FallDown();
    }

	/**
	怪物掉下去
	 */
	private void FallDown(){
		if(this.transform.position.y < Y_BOTTOM){
            Destroy(this.gameObject);
        }
	}


	private void OnDestroy() {
        mAnimator.SetBool("Disappear", true);
    }
}
