using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{


    public float[] PBs = new float[5];
    // Start is called before the first frame update
    public void Start()
    {
        //on rebranche le continue sur le lvl 1
        //PlayerPrefs.SetInt("levelToContinue", 1);


        PBs[1] = PlayerPrefs.GetFloat("Lvl1");
        PBs[2] = PlayerPrefs.GetFloat("Lvl2");
        PBs[3] = PlayerPrefs.GetFloat("Lvl3");
        PBs[4] = PlayerPrefs.GetFloat("Lvl4");

        if (PBs[1] != 0 || PBs[2] != 0 || PBs[3] != 0 || PBs[4] != 0)
        {
            GetComponent<Text>().text = "Lvl 1 : " + PBs[1]
                                    + "\nLvl 2 : " + PBs[2]
                                    + "\nLvl 3 : " + PBs[3]
                                    + "\nLvl 4 : " + PBs[4]
                                    ;

            if (PBs[1] != 0 && PBs[2] != 0 && PBs[3] != 0 && PBs[4] != 0)
            {
                float totalTime = 0;
                for(int id = 1; id < 5; id++)
                {
                    totalTime += PBs[id];
                }
                GetComponent<Text>().text += "\nPB : " + totalTime;
            }

        }
        else
        {
            GetComponent<Text>().text = "No records to show now.";
        }
    }

    public void Refresh()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
