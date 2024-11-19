using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViePlayer : MonoBehaviour
{
    [SerializeField] private float viePlayer = 100f;
    [SerializeField] private float degatEnnemi = 25f;
   
    void Start() {  }

    void Update() { }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi") || collision.gameObject.CompareTag("ProjectileEnnemi"))
        {
            viePlayer = viePlayer - degatEnnemi;
            Debug.Log("La vie du player est à " + viePlayer);

            if(viePlayer <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Le player est détruit !");

                //Recommence la partie
                SceneManager.LoadScene("SceneMain");
            }
        }
    }
}
