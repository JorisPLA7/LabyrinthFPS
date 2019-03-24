using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool CanOpen = false;

    private bool isClosed = true; 

    [SerializeField]
    AudioClip soundOpen, soundDenied;

    [SerializeField]
    private Color  defColor, grantedColor, deniedColor;

    [SerializeField]
    Animator doorAnimator;

    [SerializeField]
    GameObject exitpoint;

    private AudioSource myAudSource;
    private Light doorDEL;

    private void Awake()
    {
        myAudSource = GetComponent<AudioSource>();
        //exitpoint.SetActive(false);
        //desactivé pcq deja false par defaut
        doorDEL = GameObject.Find("DoorLED").GetComponent<Light>();
    }

    IEnumerator Blink()
    {
        doorDEL.color = deniedColor;
        yield return new WaitForSeconds(.1f);
        doorDEL.color = defColor;
        yield return new WaitForSeconds(.1f);
        doorDEL.color = deniedColor;
        yield return new WaitForSeconds(.1f);
        doorDEL.color = defColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name + " est devant la porte.");

        if (isClosed)
        {
            if (other.tag == "Player" && CanOpen)
            {
                isClosed = false;
                doorAnimator.enabled = true;
                exitpoint.SetActive(true);
                doorDEL.color = grantedColor;

                myAudSource.PlayOneShot(soundOpen);
                //myAudSource.clip = soundOpen;
                //myAudSource.Play();
            }
            else
            {
                myAudSource.clip = soundDenied;
                myAudSource.Play();
                StartCoroutine(Blink());
               
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
