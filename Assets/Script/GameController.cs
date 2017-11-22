using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {


    public GameObject gameOverUI;
    private static GameController mInstance;
    private bool isGameOver = false;

    public static GameController Instance{
		get{
            return mInstance;
        }
	}

	private void Awake() {
        mInstance = this;
    }


	/**
	游戏结束
	 */
	public void GameOver(){
        isGameOver = true;
        OnGameOver();
    }

    public void GameWin(){
        isGameOver = false;
        OnGameWin();       
    }

	public bool IsGameOver(){
        return isGameOver;
    }

	/**
	当游戏结束的时候
	 */
    private void OnGameOver(){
        gameOverUI.SetActive(true);
    }

    /**
    当游戏胜利时
     */
    private void OnGameWin(){
        gameOverUI.SetActive(true);
    }
}
