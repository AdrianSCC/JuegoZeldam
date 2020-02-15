using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public GameObject ataque_original;
    public GameObject ataque_posicion;
    private bool saltando;
    private bool atacando;
    private int vidas;
    private int monedas;
    // Start is called before the first frame update
    void Start()
    {
        saltando = false;
        atacando = false;
        vidas = 80;
        monedas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.2f,0.0f));
        }
        else
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.2f, 0.0f));
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (saltando == false)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 300.0f));
                saltando = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (atacando == false)
            {
                GameObject.Instantiate(ataque_original, ataque_posicion.transform.position,
                ataque_posicion.transform.rotation);
                atacando = true;
                Invoke("TerminarDeAtacar", 0.5f);
            }
            
        }
    }

    private void TerminarDeAtacar()
    {
        atacando = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Suelo"))
        {
            saltando = false;
        }

        if (collision.gameObject.tag.Equals("Enemigo"))
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.5f);
            vidas--;
            Debug.Log("Vidas: "+ vidas);
            if (vidas <= 0)
            {
                Debug.Log("El jugador a muerto");
                gameObject.SetActive(false);

                int recordUltimo = PlayerPrefs.GetInt("Monedas");
                if (PlayerPrefs.HasKey("Monedas") == false)
                {
                    //no hay record guardado
                    PlayerPrefs.SetInt("Monedas", monedas);
                    Debug.Log("NUEVO RECORD!" + monedas);
                }
                else
                {
                    //si hay record guardado
                    if (recordUltimo < monedas)
                    {
                        //Nuevo record
                        PlayerPrefs.SetInt("Monedas", monedas);
                        Debug.Log("NUEVO RECORD!"+ monedas);
                    }
                }

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Moneda"))
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.5f);
            monedas++;
            Debug.Log("Monedas: " + monedas);
        }
    }

}
