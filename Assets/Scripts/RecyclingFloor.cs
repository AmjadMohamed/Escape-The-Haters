using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingFloor : MonoBehaviour
{

    public GameObject[] floor;
    float distance = 0;
    public float platformLength;


    void Start()
    {
        for (int i = 0; i < floor.Length; i++)
        {
            if (i == 0)
            {
                Instantiate(floor[i], new Vector2(i * platformLength, -7.66f), Quaternion.identity);
                distance += platformLength;
            }
            else
            {
                Instantiate(floor[Random.Range(1 , floor.Length)], new Vector2(i * platformLength, Random.Range(-2.2f, 3f)), Quaternion.identity);
                distance += platformLength;
            }
        }
    }
    public void FloorRecycle(GameObject floor)
    {
            floor.transform.position = new Vector2(distance , Random.Range(-2.2f , 4f));
            distance += platformLength;
    }

}
