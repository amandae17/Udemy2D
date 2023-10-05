using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{

    public Transform player;
    public float minX, maxX, minY, maxY;
    public float timeLerp;

    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + new Vector3(0, 0, -10);


        newPosition = Vector3.Lerp(transform.position, newPosition, timeLerp);
        transform.position = newPosition;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
    }
}
