using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButtonHandler : MonoBehaviour {

    [SerializeField]
    private InputField userNameInputField, passwordInputField;

    public void OnClick_LoginButton() {
        Debug.Log("Logging in...");

        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName(userNameInputField.text)
            .SetPassword(passwordInputField.text)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Player Authenticated... \n Display Name: " + response.DisplayName);
                }
                else {
                    Debug.Log("Error Authenticating Player...  \n" + response.Errors.JSON.ToString());
                }
            });

       
    }

}
