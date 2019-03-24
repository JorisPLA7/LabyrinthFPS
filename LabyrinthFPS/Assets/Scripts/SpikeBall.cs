using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }



    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            player.GetComponent<PlayerController>().GameOver();

        }
    }
}
