using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterburnerScript : MonoBehaviour
{
    [SerializeField]
    int levelToLoad;
    int activeID;
    [SerializeField]
    bool loadNextScene;

    private string[] timeVar = new string[5] { "tourbilol", "Lvl1", "Lvl2", "Lvl3", "Lvl4" };

    public bool IsPB(float score)
    {
        float localPB = PlayerPrefs.GetFloat(timeVar[activeID]);
        if (localPB == 0 || score < localPB)
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        
        activeID = SceneManager.GetActiveScene().buildIndex;

        if (loadNextScene)
        {
            levelToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetInt("levelToContinue", levelToLoad);
            Debug.Log("levelToLoad : " + PlayerPrefs.GetInt("levelToContinue"));

            if(IsPB(Time.timeSinceLevelLoad))
            {
                PlayerPrefs.SetFloat(timeVar[activeID], Time.timeSinceLevelLoad);
            }

            //Debug.Log("temps  = " + Time.timeSinceLevelLoad);

            //La scene doit être chargée apres les autres opérations dans le doute 0:)
            SceneManager.LoadScene(levelToLoad);
        }
    }
}
