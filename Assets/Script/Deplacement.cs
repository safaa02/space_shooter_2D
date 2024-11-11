using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{

    public float vitesseCoeff = 5f; 


    void Start(){   }


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
        /*
        //
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * vitesseCoeff * Time.deltaTime);
            Debug.Log("Droite !");
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * vitesseCoeff * Time.deltaTime);
            Debug.Log("Gauche !");
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * vitesseCoeff * Time.deltaTime);
            Debug.Log("Haut !");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * vitesseCoeff * Time.deltaTime);
            Debug.Log("Bas !");
        }
            */

        //*** Faire bouger son personnage 

        //
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical"), 0) * Time.deltaTime * vitesseCoeff);


    }
}

