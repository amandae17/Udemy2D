using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Animator playerAnime;
    private Rigidbody2D rbPlayer;
    public float speed;
    private SpriteRenderer sr;
    public float JumpForce;
    private bool inFloor = true;
    public Transform objTransf;
    public GameObject tiro;
    public Rigidbody2D objeto;
    public float i = 5.0f;
    public float veltiro = 1f;
    public AudioSource som;
    public AudioSource som1;
    private GameController gcPlayer;

    public int bonus;


    // Use this for initialization
    void Start () {
        gcPlayer = GameController.gc;
        bonus = gcPlayer.bonus; // = bonus;
        playerAnime = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
        objTransf = gameObject.GetComponent<Transform>();
        this.objeto = gameObject.GetComponent<Rigidbody2D>();
        this.objeto.freezeRotation = true;
    }

    void MovimentoH()
    {
        float xn = this.i * Input.GetAxis("Horizontal");
        float y = objeto.velocity.y;
        this.objeto.velocity = new Vector2(xn, y);
    }

    void Disparar()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //tiro
        {
            float xp = transform.position.x;
            float yp = transform.position.y;
            GameObject copiatiro = (GameObject)Instantiate(tiro, new Vector3(xp + 1.0f, yp, 0), Quaternion.identity);
            som.Play();
            copiatiro.GetComponent<Rigidbody2D>().velocity = new Vector2(veltiro * Time.deltaTime, yp);
            Destroy(copiatiro, 0.5f);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }
    // Update is called once per frame
    void Update () {
        Jump();
        MovimentoH();
        Disparar();
    }


    void MovePlayer()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        rbPlayer.velocity = new Vector2(horizontalMoviment * speed, rbPlayer.velocity.y);

        if (horizontalMoviment > 0)
        {
            playerAnime.SetBool("Walk", true);
            sr.flipX = false;
        }
        else if (horizontalMoviment < 0)
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
        if (Input.GetButtonDown("Jump") || Input.GetMouseButton(1)) //mouse e espaço
        {
            if (inFloor)
            {
                playerAnime.SetBool("Walk", false);
                rbPlayer.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
                inFloor = false;
            }

        }
    }

    public void UpdateBonus()
    {
        gcPlayer.SetBonus(bonus);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            playerAnime.SetBool("Walk", true);
            inFloor = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pedra" ) // Bonus: Aumenta velocidade e animação de ataque
        {
            playerAnime.SetBool("Attack", true);
            Destroy(collision.gameObject);
            speed = speed * 2;
            som1.Play();
        }

        else if (collision.gameObject.tag == "Esqueleto") //Bonus: Aumenta tamanho
        {
            Destroy(collision.gameObject);
            Vector2 tam = objTransf.localScale;
            tam.x = tam.x * 2;
            tam.y = tam.y * 2;
            som1.Play();
            objTransf.localScale = tam;
        }

        else if (collision.gameObject.tag == "Caixa") //Bonus: Aumenta forca do pulo
        {
            Destroy(collision.gameObject);
            JumpForce = 6;
            som1.Play();
        }

        else if (collision.gameObject.tag == "GramaS") //Punicao: diminui tamanho e forca do pulo
        {
            Destroy(collision.gameObject);
            Vector2 tam = this.objTransf.localScale;
            tam.x = tam.x / 2;
            tam.y = tam.y / 2;
            objTransf.localScale = tam;
            JumpForce = 3;
            som1.Play();
        }

        else if (collision.gameObject.tag == "GramaV") //Punicao: Diminui velocidade
        {
            playerAnime.SetBool("Attack", false);
            Destroy(collision.gameObject);
            speed = speed / 2;
            som1.Play();
        }
        else if (collision.gameObject.tag == "Pontos") //Pontuacao
        {
            Destroy(collision.gameObject);
            som1.Play();
            bonus = bonus + 100;
            //gcPlayer.bonus = bonus;//+= 100;
            gcPlayer.pontosUI.text = gcPlayer.bonus.ToString();
            UpdateBonus();

        }

        else if (collision.gameObject.tag == "Cactus")//Animacao final
        {
            playerAnime.SetBool("Dead", true);
            speed = 1;
            som1.Play();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Tree")//Revive Personagem
        {
            playerAnime.SetBool("Dead", false);
            playerAnime.SetBool("Walk", true);
            speed = 5;
            som1.Play();
            Destroy(collision.gameObject);
        }

        else if (collision.gameObject.tag == "Level2") //Muda para nivel 2
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Fase 2");
        }

        else if (collision.gameObject.tag == "Level3") //Muda para nivel 3
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Fase 3");
        }

        else if (collision.gameObject.tag == "Level1") //Muda para nivel 1
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Fase 1");
        }

        else if (collision.gameObject.tag == "Menu") //Muda para menu
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Menu");
        }
    }

}