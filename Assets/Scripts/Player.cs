using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //Deplacement
    [SerializeField] private float vitesseRotation = 150f;
    [SerializeField] private float vitessePosition = 5f;

    //Projectile lancement
    [SerializeField] private GameObject prefabProjectile;
    [SerializeField] private GameObject positionLancementProjectile;
    [SerializeField] private float forceProjectile = 1000f;
    [SerializeField] private float tempsDeVie = 2f;

    //Vie
    [SerializeField] private float pointsDeVie= 100f;
    [SerializeField] private float degatParEnnemi = 25f;
    
    // ------- TO DO -------
    [SerializeField] private string sceneCharge;
    

    void Start()
    {

    }

    void Update()
    {
        deplacement();
        lancerProjectile();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        gestionVie(collision);
    }


    private void deplacement()
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

    private void lancerProjectile()
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

    private void gestionVie(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi") || collision.gameObject.CompareTag("ProjectileEnnemi"))
        {
            if (collision.gameObject.CompareTag("ProjectileEnnemi"))
            {
                Destroy(collision.gameObject);
            }

            pointsDeVie= pointsDeVie- degatParEnnemi;
            Debug.Log("La vie du player est à " + pointsDeVie);

            if (pointsDeVie<= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Le player est détruit !");

                // ------- TO DO -------
                //Recommence la partie
                //SceneManager.LoadScene(sceneCharger);
                gestionScene();
            }
        }
    }

    // ------- TO DO -------
    private void gestionScene()
    {
        SceneManager.LoadScene(sceneCharge);
    }

}
