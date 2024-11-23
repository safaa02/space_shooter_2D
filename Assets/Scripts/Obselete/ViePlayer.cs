using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViePlayer : MonoBehaviour
{
    [SerializeField] private float viePlayer = 100f;
    [SerializeField] private float degatEnnemi = 25f;

    [SerializeField] private string sceneCharger;
   
    void Start(){  }

    void Update(){ }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi") || collision.gameObject.CompareTag("ProjectileEnnemi"))
        {
            if(collision.gameObject.CompareTag("ProjectileEnnemi"))
            { 
                Destroy(collision.gameObject);
            }

            viePlayer = viePlayer - degatEnnemi;
            Debug.Log("La vie du player est � " + viePlayer);

            if(viePlayer <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Le player est d�truit !");

                //Recommence la partie
                SceneManager.LoadScene(sceneCharger);
            }
        }
    }

}