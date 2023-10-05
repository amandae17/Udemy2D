using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projetil : MonoBehaviour {

    void Start()
    {

    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D objetoTocado)
    {
        if (objetoTocado.gameObject.tag == "Inimigo")
        {
            print("Acertou");
            Destroy(objetoTocado.gameObject);
        }

    }   
}
