using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelSwitchHandler : MonoBehaviour {

    [SerializeField]
    private GameObject registerPanel, loginPanel;

    [SerializeField]
    private Text registerLoginSwitchButtonText;

    private bool registerPanelActive = true;

    public void OnClick_RegisterLoginSwitch() {
        if (registerPanelActive)
        {
            // Debug.Log("Inside if"); 
            registerPanel.SetActive(false);
            loginPanel.SetActive(true);
            registerPanelActive = false;
            registerLoginSwitchButtonText.text = "Go to Register Page";
        }
        else {
            // Debug.Log("Inside else");
            registerPanel.SetActive(true);
            loginPanel.SetActive(false);
            registerPanelActive = true;
            registerLoginSwitchButtonText.text = "Go to Login Page";
        }
    }

}


/*
 * Keep care of above and below things basically in the canvas heirarchy or sometimes the button
 * won't work :(
 */ 