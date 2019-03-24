using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePointReturn : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    SpikeBall2Script spikeBall2Script;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision point parcours.");
        if (other.tag == "Ball")
        {
            other.GetComponent<SpikeBall2Script>().target = target;

        }
    }
        //private void OnTriggerEnter(Collider other)
        //{
        //    Debug.Log("Collision point parcours.");
        //    if (true)
        //    {
        //        spikeBall2Script.target = target;
        //        //other.GetComponent<SpikeBall2Script>().target = target;
        //    }
        //}
}
