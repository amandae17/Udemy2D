using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Names : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ArrayList nomes = new ArrayList();
        nomes.Add("Papai Noel");
        nomes.Add("Garoto fantasia");
        nomes.Add("Gato meow");
        nomes.Add("Cachorro Au");
        nomes.Add("Boneco de neve");
        nomes.Add("Dino");

        foreach (string nome in nomes)
        {
            Debug.Log(nome);
        }
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
