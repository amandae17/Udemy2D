using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        print(this.name);
        print(this.transform);
        print(this.transform.position);
        print(this.transform.rotation.eulerAngles.z);
        print(this.tag);

        Vector3 ImagePosition = this.transform.position;
        if (ImagePosition.x > ImagePosition.y)
        {
            Debug.Log("X é maior." + ImagePosition.x +" e "+ ImagePosition.y);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
