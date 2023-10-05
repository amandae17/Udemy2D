using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	 public void LoadScene (string cena) {
        SceneManager.LoadScene(cena);
    }

    public void Start()
    {
        
    }
}
