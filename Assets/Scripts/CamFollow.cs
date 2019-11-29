using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform FollowTarget;
    public float CamSpeed;

    public float minX;
    public float minY;
    public float maxX;
    public float maxY;



    void FixedUpdate()
    {
        var NewPos = Vector2.Lerp(this.gameObject.transform.position, FollowTarget.transform.position, Time.deltaTime * CamSpeed);
        var vec3 = new Vector3(NewPos.x, NewPos.y, -10);
        var clampX = Mathf.Clamp(vec3.x, minX, maxX);
        var ClampY = Mathf.Clamp(vec3.y, minY, maxY);

        this.gameObject.transform.position = new Vector3(clampX, ClampY, -10);
    }
}
