using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour {

    private Button returnButton;
    // Use this for initialization
    void Start () {
        returnButton = GetComponentInChildren<Button>();

        returnButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });
    }
}
