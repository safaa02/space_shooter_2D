using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirEnnemi : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float forceProjectile = 1000f;

    void Start()
    {
        StartCoroutine(CoroutTir());
    }

    void Update()
    {
        //tirerProjectile();
    }

    IEnumerator CoroutTir()
    {
        while (true)
        {
            //Debug.Log("Un projectile");
            yield return new WaitForSeconds(3f);


            // Positionner le projectile un peu plus bas que l'objet, décaler de 0.5 unité vers le bas
            
            //Vector2 positionProjectile = this.transform.position + transform.down * 0.5f;
            //Vector2 positionProjectile = (Vector2)this.transform.position + Vector2.down * 0.5f;
            Vector3 positionProjectile = this.transform.position + Vector3.down * 0.5f;


            //Instantiale du projectile

            //GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity) as GameObject;
            GameObject projectile = Instantiate(projectilePrefab, positionProjectile, Quaternion.identity) as GameObject;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                //rb.AddForce(this.transform.up * forceProjectile);
                rb.AddForce(-this.transform.up * forceProjectile);

                //rb.AddForce(Vector2.down * forceProjectile);
            }
            else
            {
                Debug.LogError("Le Rigidbody2D est manquant sur le projectile !");
            }

            //Détruire le projectile après 2 secondes
            Destroy(projectile, 2f);
        }
    }

}
