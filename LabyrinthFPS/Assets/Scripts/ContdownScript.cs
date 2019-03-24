using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContdownScript : MonoBehaviour
{
    [SerializeField]
    private int startCountdown = 60;

    [SerializeField]
    UnityEngine.UI.Text TxtCountdown;
    // peut etre importé plus propremment avec:
    //      using UnityEngine.UI (en haut)
    //      Text TxtCountdown

    private void Awake()
    {
        //TxtCountdown = GameObject.Find("TxtTimer"); // on récupère le timer affiché
    }

    void Start()
    {
        StartCoroutine(Pause());
        TxtCountdown.text = "Time left : " + startCountdown;

    }

    IEnumerator Pause()
    {
        while (startCountdown>0)
        {
            yield return new WaitForSeconds(1f);
            startCountdown--;
            TxtCountdown.text = "Time left : " + startCountdown;
        }

        //Fin du cpt a rebours , on lance la methode GameOver du joueur.
        GameObject.Find("Player").GetComponent<PlayerController>().GameOver();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
