using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpHeight = 300;
    public float babyCount;
    public bool hasBabies = true;
    public bool vulnerable = true;
    public bool canJump = false;
    public GameObject babyPickup;
    public Transform babyspawnPoint;
    public Animator animator;
    public Rigidbody2D rg2;


    private void Start()
    {
        animator = GetComponentInParent<Animator>();

        rg2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //movimiento basico de derecha a izquierda, solo si no sos ivulnerable después de un hit.

        if (vulnerable == true)
        {

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {

                transform.Translate(speed * Time.deltaTime, 0f, 0f);
                transform.eulerAngles = new Vector3(0,0,0);
                animator.SetBool("isRunning",true);

            }else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0f, 0f);
                transform.eulerAngles = new Vector3(0, -180, 0);
                animator.SetBool("isRunning", true);
            }else {

                animator.SetBool("isRunning", false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && canJump == true)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
                canJump = false;
                animator.SetTrigger("StartJump");
            }
            animator.SetFloat("JumpVelocity", rg2.velocity.y);
        }
        //Si tenes bebes, el bool hasBabies es true.
        if (babyCount > 0)
        {
            hasBabies = true;
        }

        else
        {
            hasBabies = false;
        }

        // failsafe para que no se pase de 5 bebes.
        if (babyCount > 5)
        {
            babyCount = 5;
        }
    }

    IEnumerator gotHit()
    {
        //Si te lastiman, la corutina espera para hacerte vulnerable de nuevo y devolver el color.
        yield return new WaitForSeconds(1f);
        vulnerable = true;
        Color temp = GetComponent<SpriteRenderer>().color;
        temp.a = 1f;
        GetComponent<SpriteRenderer>().color = temp;       
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        //Si se hace contacto con el piso y se aprieta espacio, salta.
        if ((collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Tree") && Input.GetKeyDown(KeyCode.Space) && vulnerable == true)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpHeight * Time.deltaTime), ForceMode2D.Impulse);
        }
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            canJump = true;
        } 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("wewerewr" + collision.gameObject.tag);
        //si se recolecta un bebe, el bool de hasBabies es verdadero
        if (collision.gameObject.tag == "Baby")
        {
            print("recolecto bebe");
            babyCount += 1;
        }

        if (collision.gameObject.tag == "Goal")
        {

            (collision.gameObject.GetComponent<Victory>()).goalReach();
        }

        //si se colisiona con un enemigo y hay bebes, el babyCount baja, si no hay bebes, moris
        //la colision te empuja hacia atras, te vuelve ivulnerable 3 segundos y transparente.
        //Se lanzan los bebes que tenia encima.
        if (collision.gameObject.tag == "Enemy" && hasBabies == true && vulnerable == true)
        {
            for (int i = 0; i < babyCount; i++)
            {
                GameObject lostBaby = Instantiate(babyPickup, babyspawnPoint.position, babyspawnPoint.rotation);
                lostBaby.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-20, 20), 10), ForceMode2D.Impulse);
                Destroy(lostBaby, 5f);
            }

            print("pierdo bebe");
            babyCount = 0;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 4), ForceMode2D.Impulse);
            vulnerable = false;
            Color temp = GetComponent<SpriteRenderer>().color;
            temp.a = 0.5f;
            GetComponent<SpriteRenderer>().color = temp;
            StartCoroutine(gotHit());
        }

        else if (collision.gameObject.tag == "Enemy" && hasBabies == false && vulnerable == true)
        {
            Destroy(gameObject);
            GameManager.Instance.defeated = true;
        }
    }      
    }



