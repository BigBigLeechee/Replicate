using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class ReplayGame : MonoBehaviour {

    public Button retryButton;
    // Use this for initialization
    void Start () {
        retryButton.onClick.AddListener(() =>
        {
            EditorSceneManager.LoadScene("MainScene");
        });
    }
	
}
