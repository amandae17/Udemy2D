using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NamesList : MonoBehaviour {

	// Use this for initialization
	void Start () {

        string [] nomes= { "Papai Noel", "Garoto fantasia", "Gato meow", "Cachorro Au", "Boneco de neve", "Dino" };

        foreach (string nome in nomes)
        {
            Debug.Log(nome);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
