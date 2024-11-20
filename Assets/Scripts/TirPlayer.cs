using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirPlayer : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float forceProjectile = 1000f;

    void Start(){ }

    void Update()
    {
        tirerProjectile();
    }

    void FixedUpdate(){ }

    private void tirerProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Instanciation du projectile
            GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity) as GameObject;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(this.transform.up * forceProjectile);
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

