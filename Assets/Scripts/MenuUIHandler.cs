using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{


    public InputField playerNameField;
    public Text BestScoreText; 


    private void Start()
    {
        playerNameField.text = PlayerManager.Instance.playerName.ToString();
        BestScoreText.text = "Best Score : " +  PlayerManager.Instance.previousBestPlayerName + " : " + PlayerManager.Instance.playerBestScore.ToString();
    }
    public void StartNew()
    {
        PlayerManager.Instance.SavePlayerName();
        SceneManager.LoadScene(1);
    }


    public void QuitGame()
    {
        PlayerManager.Instance.SavePlayerName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }




    public void OnNameChange()
    {
        print("Name Changed");
        PlayerManager.Instance.playerName = playerNameField.text;
    }

}
