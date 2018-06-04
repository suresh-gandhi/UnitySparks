using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterButtonHandler : MonoBehaviour {

    [SerializeField]
    private InputField displayNameInputField, userNameInputField, passwordInputField;

    public void OnClick_RegisterButton(){
        Debug.Log("Registering Player...");
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayNameInputField.text)
            .SetUserName(userNameInputField.text)
            .SetPassword(passwordInputField.text)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Player Registered \n User Name: " + response.DisplayName);
                }
                else
                {
                    Debug.Log("Error Registering Player... \n " + response.Errors.JSON.ToString());
                }   
            });
    }

}

/*
 * Keep care of OnDestroy things as well! Important reminder and consideration..
 * Keep care of coding the edge cases here! 
 */ 
