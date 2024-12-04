using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [Header(" --- Deplacement Player ---")]
    //
    [SerializeField] private float vitesseRotation = 150f;
    [SerializeField] private float vitessePosition = 5f;

    [Header(" --- Projectile lancement ---")]
    //
    [SerializeField] private GameObject prefabProjectile;
    [SerializeField] private GameObject positionLancementProjectile;
    [SerializeField] private float forceProjectile = 1000f;
    [SerializeField] private float tempsDeVie = 2f;

    [Header(" --- Vie Player ---")]
    //
    [SerializeField] private float pointsDeVie= 100f;
    [SerializeField] private float degatParEnnemi = 25f;

    [Header(" --- Gestion du Menu ---")]
    //
    [SerializeField] private MenuManager menuManager;



    void Update()
    {
        Deplacement();
        LancerProjectile();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GestionVie(collision);
    }


    private void Deplacement()
    {
        //Position
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 positionMouvement = new Vector3(0, verticalInput, 0) * vitessePosition * Time.deltaTime;
        this.transform.Translate(positionMouvement);

        //Rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotation = horizontalInput * vitesseRotation * Time.deltaTime;
        this.transform.Rotate(0, 0, -rotation);
    }

    private void LancerProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Instanciation du projectile
            GameObject projectile = Instantiate(prefabProjectile, positionLancementProjectile.transform.position, Quaternion.identity) as GameObject;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(positionLancementProjectile.transform.up * forceProjectile);
            }
            else
            {
                Debug.LogError("Le Rigidbody2D est manquant sur le projectile !");
            }

            //Détruire le projectile après 2 secondes
            Destroy(projectile, tempsDeVie);
        }
    }

    private void GestionVie(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi") || collision.gameObject.CompareTag("ProjectileEnnemi"))
        {
            if (collision.gameObject.CompareTag("ProjectileEnnemi"))
            {
                Destroy(collision.gameObject);
            }

            //Calcul vie
            pointsDeVie= pointsDeVie- degatParEnnemi;

            //Retire l'affichage d'une vie
            menuManager.AffichageVie(pointsDeVie);

            if (pointsDeVie<= 0)
            {
                Destroy(this.gameObject);
                //Debug.Log("Le player est détruit !");

                //Ouvre le Menu
                menuManager.ResultatPlayer(false);
            }
        }
    }


}
