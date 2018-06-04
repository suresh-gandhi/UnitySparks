using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks.Core;

public class SubmitDataButtonHandler : MonoBehaviour {

    [SerializeField]
    private InputField positionXInputField, positionYInputField;

    [SerializeField]
    private Text posServerData;

    public void OnClick_SubmitDataButton() {
        Debug.Log("Submitting position data to the server...");
        new GameSparks.Api.Requests.LogEventRequest().
            SetEventKey("SAVE_PLAYER")
            .SetEventAttribute("POSX", int.Parse(positionXInputField.text))
            .SetEventAttribute("POSY", int.Parse(positionYInputField.text))
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Position data successfully saved to the server");
                    RetreiveSavedPosData();
                }
                else {
                    Debug.Log("Error saving the position data");
                }
            });
    }

    private void RetreiveSavedPosData() {
        Debug.Log("Retreiving the saved position data of the player...");
        new GameSparks.Api.Requests.LogEventRequest().SetEventKey("LOAD_PLAYER")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Successfully retreived the player position data");
                    GSData gsData = response.ScriptData.GetGSData("playerPosData");
                    posServerData.text = gsData.GetString("playerPosX") + ", " + gsData.GetString("playerPosY");
                    // Debug.Log(gsData.GetString("playerPosX") + ", " + gsData.GetString("playerPosY"));
                    // Debug.Log(gsData.GetString("playerPosX") == null);
                    // Debug.Log(gsData.GetNumber("playerPos"));
                    // var tObject = new object();
                    // gsData.BaseData.TryGetValue("playerPosX", out tObject);
                    // Debug.Log(tObject);
                }
                else {
                    Debug.Log("Error loading the player data");
                }
            });
    }

}
