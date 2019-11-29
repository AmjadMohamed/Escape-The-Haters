using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroySound : MonoBehaviour
{
   // public AudioClip DestroySound;
    public Transform player;
    public GameObject BoxDestroyParticles;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag =="Player")
        {
           // AudioSource.PlayClipAtPoint(DestroySound, player.transform.position);

            Destroy(gameObject);
            Instantiate(BoxDestroyParticles, transform.position, Quaternion.identity);
        }
    }
}
