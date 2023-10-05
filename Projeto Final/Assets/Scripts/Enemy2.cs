using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {
    public GameObject inimigo;
    public float vel = 5;
    void Start()
    {
        InvokeRepeating("CriarInimigo", 1, vel);
    }
    void CriarInimigo()
    {
        GameObject copiaPrefab = (GameObject)Instantiate(inimigo);
        Vector2 posGameVazio = this.transform.position;
        copiaPrefab.transform.position = posGameVazio;
        Destroy(copiaPrefab, 4.5f);
    }
}