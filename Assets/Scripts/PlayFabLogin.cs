using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour 
{ 
    public void Start() 
    {
        // Tarkistetaan ettei TitleID ole tyhj� eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lis�� oma TitleID,jonka l�yd�t PlayFab pilven Game Managerista
            PlayFabSettings.TitleId = "8140"; 
        }
        // T�ss� luodaan API-kutsu (GET)
        var request = new LoginWithCustomIDRequest{ CustomId = 
            "GettingStartedGuide", CreateAccount = true };
        // T�ss� suoritetaan API-kutsu pilvess� olevalla palvelimelle
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, 
            OnLoginFailure);
    }
    
    // T�m� metodi suoritetaan jos Loggaus onnistuu
    private void OnLoginSuccess(LoginResultresult)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    // T�m� metodi suoritetaan jos loggaus ep�onnistuu
    private void OnLoginFailure(PlayFabErrorerror)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}