using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            //Destroy(this.transform.parent.gameObject);
            GameObject.Find("DoorSystem").GetComponent<Door>().CanOpen = true;
            GetComponent<AudioSource>().Play(); // demarage du son
            GetComponent<CapsuleCollider>().enabled = false; // plus de collision, on aurait
            //pu mettre un triger ça aurait été plus propre 0:)

            //on enlève le mesh
            Destroy(GameObject.Find("pPlane3"));

            //on del le gameobject de la clé
            Destroy(this.gameObject, 3f);
        }
    }
}
