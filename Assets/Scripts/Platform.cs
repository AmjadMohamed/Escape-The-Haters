using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private RecyclingFloor recycle;
  //  public GameObject player;
    

    private void OnEnable()
    {
        recycle = GameObject.FindObjectOfType<RecyclingFloor>();
    }

    private void OnBecameInvisible()
    {
            recycle.FloorRecycle(this.gameObject); 
    }

  /*  void update()
    {
        if(player.transform.position.z > this.gameObject.transform.position.z)
        {
            recycle.FloorRecycle(this.gameObject);
        }
    }*/
    
   
}
