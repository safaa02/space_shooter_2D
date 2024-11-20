using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VieEnnemi : MonoBehaviour
{
    [SerializeField] private float vieEnnemi = 100f;
    [SerializeField] private float degatPlayer = 50f;
    
    void Start(){   }

    void Update(){  }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ProjectilePlayer"))
        {
            Destroy(collision.gameObject);

            vieEnnemi = vieEnnemi - degatPlayer;
            Debug.Log("La vie de l'ennemi est à " + vieEnnemi);

            if (vieEnnemi <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("L'ennemi est détruit !");
            }
        }
    }

}
