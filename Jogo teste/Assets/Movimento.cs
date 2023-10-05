using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 14, 0);
        }
	}
}
