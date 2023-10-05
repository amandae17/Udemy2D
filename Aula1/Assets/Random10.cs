using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random10 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            print(Random.Range(0, 100));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
