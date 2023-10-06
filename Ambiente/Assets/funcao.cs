using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class funcao : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Script1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Script2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Script3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Script4();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Script5();
        }
    }
    void Script1()
    {
        for (int i = 0; i < 10; i++)
        {
            print(Random.Range(0, 100));
        }
    }

    void Script2()
    {
        string[] nomes = { "Papai Noel", "Garoto fantasia", "Gato meow", "Cachorro Au", "Boneco de neve", "Dino" };

        foreach (string nome in nomes)
        {
            Debug.Log(nome);
        }
    }

    void Script3()
    {
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
    void Script4()
    {
        print(this.name);
        print(this.transform);
        print(this.transform.position);
        print(this.transform.rotation.eulerAngles.z);
        print(this.tag);

        Vector3 ImagePosition = this.transform.position;
        if (ImagePosition.x > ImagePosition.y)
        {
            Debug.Log("X é maior." + ImagePosition.x + " e " + ImagePosition.y);
        }
    }
    void Script5()
    {
        print(this.name);
        print(this.transform);
        print(this.transform.position);
        print(this.transform.rotation.eulerAngles.z);
        print(this.tag);

        Vector3 ImagePosition = this.transform.position;
        float soma = ImagePosition.x + ImagePosition.y;
        Debug.Log("Soma X e Y = " + soma);
    }
}
