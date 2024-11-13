using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public float vitesse = 5f;

    void Start() { }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            Debug.Log("Une collision !!!!!");
            Destroy(collision.gameObject);
        }
    }

    void Update()
    {
        // Déplacer le Game Objet personnage 
        float mouvementHorizontal = Input.GetAxis("Horizontal");
        float mouvementVertical = Input.GetAxis("Vertical");     


        transform.Translate(new Vector3(mouvementHorizontal, mouvementVertical, 0) * vitesse * Time.deltaTime);
        Debug.Log("Déplacement du vaisseau !!");

        /*
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * vitesse * Time.deltaTime);
            Debug.Log("Droite !");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * vitesse * Time.deltaTime);
            Debug.Log("Gauche !");
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * vitesse * Time.deltaTime);
            Debug.Log("Haut !");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * vitesse * Time.deltaTime);
            Debug.Log("Bas !");
        }
        */
    }
}

