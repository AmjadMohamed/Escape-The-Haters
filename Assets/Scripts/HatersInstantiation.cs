using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatersInstantiation : MonoBehaviour
{
    public GameObject[] haters;
   // Rigidbody2D rb;


    void Start()
    {
        InvokeRepeating("instantiation", 3f, 5f);
       // rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        //Destroy(Egg, 4f);
        
      

    }

    void instantiation()
    {
      
       // Vector3 position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y , this.gameObject.transform.position.z);

        Instantiate(haters[Random.Range(1, haters.Length)], this.gameObject.transform.position, Quaternion.identity);
        Instantiate(haters[Random.Range(1, haters.Length)], this.gameObject.transform.position, Quaternion.identity);
        Instantiate(haters[Random.Range(1, haters.Length)], this.gameObject.transform.position, Quaternion.identity);

    }
}
