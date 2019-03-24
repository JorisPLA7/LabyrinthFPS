using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall2Script : MonoBehaviour
{
    [SerializeField]
    float speed = 4f;

    [SerializeField]
    public Transform target;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerController>().GameOver();

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
    }
}
