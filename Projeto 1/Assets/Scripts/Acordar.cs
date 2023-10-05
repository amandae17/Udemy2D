using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acordar : MonoBehaviour
{
    private Animator playerAnime;
    private SpriteRenderer sr;
    public GameObject alvo;
    public float vel = 3f;
    public float distmin = 4f;

    void Start()
    {
        playerAnime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Seguir()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        if (Vector3.Distance(transform.position, alvo.transform.position) < distmin)
        {
            transform.LookAt(alvo.transform.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            transform.Translate(new Vector3(vel * Time.deltaTime, 0, 0));

            if (horizontalMoviment > 0)
            {
                playerAnime.SetBool("Ataque", true);
                sr.flipX = false;
            }
            else if (horizontalMoviment < 0)
            {
                playerAnime.SetBool("Ataque", true);
                sr.flipX = true;
            }
            else
            {
                playerAnime.SetBool("Ataque", false);
            }
        }
    }
    void Update()
    {
        Seguir();
    }
}