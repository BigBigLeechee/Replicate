using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour {


    private Text mGameEndText;
    // Use this for initialization
    void Start () {
        mGameEndText = GameObject.Find("EndText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        ShowText();
    }

	/**
	展示相应的Text
	 */
	private void ShowText(){
		if(!GameController.Instance.IsGameOver()){
            mGameEndText.text = "You Win";
        }else{
            mGameEndText.text = "Game Over";
        }
	}
}
