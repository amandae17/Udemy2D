using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D rbPlayer;
    public float speed;
    private SpriteRenderer sr;
    public float JumpForce;
    private bool inFloor = true;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
	}
    private void FixedUpdate()
    {
        MovePlayer();
    }
    // Update is called once per frame
    void Update () {
        Jump();
	}

    void MovePlayer()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMoviment);
        //transform.position += new Vector3(horizontalMoviment * Time.deltaTime * speed,0,0);
        rbPlayer.velocity = new Vector2(horizontalMoviment * speed, rbPlayer.velocity.y);

        if (horizontalMoviment > 0)
        {
            sr.flipX = false;
        }
        if (horizontalMoviment < 0)
        {
            sr.flipX = true;
        }

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && inFloor)
        {
            rbPlayer.AddForce(new Vector2(0, JumpForce),ForceMode2D.Impulse);
            inFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            inFloor = true;
        }
        if (collision.gameObject.tag == "Tesouro")
        {
            Debug.Log("Você ganhou!");

        }
    }
}
