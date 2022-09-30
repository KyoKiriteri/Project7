using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour 
{ 
    public void Start() 
    {
        // Tarkistetaan ettei TitleID ole tyhjä eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lisää oma TitleID,jonka löydät PlayFab pilven Game Managerista
            PlayFabSettings.TitleId = "8140"; 
        }
        // Tässä luodaan API-kutsu (GET)
        var request = new LoginWithCustomIDRequest{ CustomId = 
            "GettingStartedGuide", CreateAccount = true };
        // Tässä suoritetaan API-kutsu pilvessä olevalla palvelimelle
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, 
            OnLoginFailure);
    }
    
    // Tämä metodi suoritetaan jos Loggaus onnistuu
    private void OnLoginSuccess(LoginResultresult)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    // Tämä metodi suoritetaan jos loggaus epäonnistuu
    private void OnLoginFailure(PlayFabErrorerror)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}