using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInstantiation : MonoBehaviour
{
    public GameObject MyObject;
    // Rigidbody2D rb;

    public float TimeBetweenInstantiation;


    void Start()
    {
        InvokeRepeating("instantiation", 0f, TimeBetweenInstantiation);
       // rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        //Destroy(Egg, 4f);
        
      

    }

    void instantiation()
    {
      
       // Vector3 position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y , this.gameObject.transform.position.z);

        Instantiate(MyObject, this.gameObject.transform.position, Quaternion.identity);

    }
}
