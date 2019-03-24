using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    Dropdown dropGameMode;

    [SerializeField]
    int gameMode;

    private void Start()
    {
        gameMode = PlayerPrefs.GetInt("gamemode",0); //0 si inconnu
        dropGameMode.value = gameMode;
    }

    public void ResetScores()
    {
        PlayerPrefs.SetInt("Lvl1", 0); //0 si inconnu
        PlayerPrefs.SetInt("Lvl2", 0); //0 si inconnu
        PlayerPrefs.SetInt("Lvl3", 0); //0 si inconnu
        PlayerPrefs.SetInt("Lvl4", 0); //0 si inconnu
        GameObject.Find("TxtScores").SetActive(false);

    }

    public void ChangeGameMode(int value)
    {
        PlayerPrefs.SetInt("gamemode", value); //0 si inconnu
    }

    public void QuitGame()
    {

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif 
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Continue()
    {
        int levelToContinue = PlayerPrefs.GetInt("levelToContinue");
        Debug.Log("levelToContinue : " + levelToContinue);
        //si n'existe pas PlayerPref retourne 0;

        if(levelToContinue != 0)
        {
            SceneManager.LoadScene(levelToContinue);
        }
        else
        {
            PlayGame();
            // <=> scene 1
        }
    }
}
