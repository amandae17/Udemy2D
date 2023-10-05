using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Animator playerAnime;
    private Rigidbody2D rbPlayer;
    public float speed;
    private SpriteRenderer sr;
    public float JumpForce;
    private bool inFloor = true;
    public bool doubleJump;
    public int coins;
    public Text pontos;
    int qtdpontos = 0;

	// Use this for initialization
	void Start () {
        playerAnime = GetComponent<Animator>();
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
            playerAnime.SetBool("Walk", true);
            sr.flipX = false;
        }
        if (horizontalMoviment < 0)
        {
            playerAnime.SetBool("Walk", true);
            sr.flipX = true;
        }
        else
        {
            playerAnime.SetBool("Walk", false);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (inFloor)
            {
                playerAnime.SetBool("Jump", true);
                rbPlayer.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                inFloor = false;
                doubleJump = true;
            }

            else if (!inFloor && doubleJump)
            {
                playerAnime.SetBool("Jump", true);
                rbPlayer.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                inFloor = false;
                doubleJump = false;
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            playerAnime.SetBool("Jump", false);
            inFloor = true;
            doubleJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            coins++;
            qtdpontos = 100 + (qtdpontos*2);
            this.pontos.text = qtdpontos.ToString();
        }
    }
}
