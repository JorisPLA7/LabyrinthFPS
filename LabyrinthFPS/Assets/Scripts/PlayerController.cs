using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f, curSpeed = 4f;

    [SerializeField]
    private float rSpeed = 100f;

    [SerializeField]
    GameObject ImGameOver;
    Transform cameraTransform;

    private Vector3 rotation = Vector3.zero; 
    private Vector3 deplacement= Vector3.zero; // (0,0,0)

    private Input horizontalTrans, verticalTrans;
    private int gameMode;

    private void Start()
    {
        //Debug.Log("deplacement : " + Vector3.left);
        //Debug.Log("levelToLoad : (start)" + PlayerPrefs.GetInt("levelToContinue"));
        cameraTransform = GameObject.Find("Main Camera").transform;
        gameMode = PlayerPrefs.GetInt("gamemode", 0); //0 si inconnu
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameMode == 0) FixedUpdateGM0();
        else FixedUpdateGM1();
    }
    
    IEnumerator DelayedGOver()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver()
    {
        ImGameOver.SetActive(true);
        //rq : GameObjetc.Find(...).SetActive IMPOSSIBLE car les objets inactifs ne peuvent être trouvés

        StartCoroutine(DelayedGOver());
    }

    //GAMEMODE 0 -----------------------------
    void FixedUpdateGM0()
    {
        deplacement = Vector3.Normalize(Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.JoystickButton5))
        {
            curSpeed = speed * 1.8f;
        }
        else
        {
            curSpeed = speed;
        }

        //apply changes


        //Vector3.Normalize()
        //transform.Translate(Vector3.right * curSpeed * deplacement.x * Time.fixedDeltaTime);
        transform.Translate(Vector3.forward * curSpeed * deplacement.z * Time.fixedDeltaTime);

        //
        transform.Rotate(Vector3.up * rSpeed * Input.GetAxis("Mouse X") * Time.fixedDeltaTime);
        //cameraTransform.Rotate(Vector3.right * rSpeed * Input.GetAxis("Mouse Y") * Time.fixedDeltaTime);

        //transform.Rotate(Vector3.up * rSpeed * Input.GetAxis("JoyDroitH") * Time.fixedDeltaTime);

        //reset values to 0
        deplacement = Vector3.zero;
        rotation = Vector3.zero;
    }

    //GAMEMODE 1 -----------------------------------
    void FixedUpdateGM1()
    {
        deplacement = Vector3.Normalize(Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.JoystickButton5))
        {
            curSpeed = speed * 1.8f;
        }
        else
        {
            curSpeed = speed;
        }

        //apply changes


        //Vector3.Normalize()
        transform.Translate(Vector3.right * curSpeed * deplacement.x * Time.fixedDeltaTime);
        transform.Translate(Vector3.forward * curSpeed * deplacement.z * Time.fixedDeltaTime);

        //
        transform.Rotate(Vector3.up * rSpeed * Input.GetAxis("Mouse X") * Time.fixedDeltaTime);
        cameraTransform.Rotate(Vector3.right * rSpeed * Input.GetAxis("Mouse Y") * Time.fixedDeltaTime);

        //transform.Rotate(Vector3.up * rSpeed * Input.GetAxis("JoyDroitH") * Time.fixedDeltaTime);

        //reset values to 0
        deplacement = Vector3.zero;
        rotation = Vector3.zero;
    }
}
