using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    //Deplacement
    [SerializeField] private float vitesseRot;
    [SerializeField] private float vitessePos;

    //Vie
    [SerializeField] private float vie;
    [SerializeField] private float degatEnnemi;

    // ------- TO DO -------
    [SerializeField] private string sceneCharger;

    //Projectile lancement
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float forceProjectile = 1000f;
    [SerializeField] private float tempsDeVie = 2f;

    [SerializeField] private GameObject projectilePos;

    void Start()
    {
        vitesseRot = 150f;
        vitessePos = 5f;

        vie = 100f;
        degatEnnemi = 25f;
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
        Vector3 positionMouvement = new Vector3(0, verticalInput, 0) * vitessePos * Time.deltaTime;
        this.transform.Translate(positionMouvement);

        //Rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotation = horizontalInput * vitesseRot * Time.deltaTime;
        this.transform.Rotate(0, 0, -rotation);
    }

    private void gestionVie(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi") || collision.gameObject.CompareTag("ProjectileEnnemi"))
        {
            if (collision.gameObject.CompareTag("ProjectileEnnemi"))
            {
                Destroy(collision.gameObject);
            }

            vie = vie - degatEnnemi;
            Debug.Log("La vie du player est à " + vie);

            if (vie <= 0)
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
        SceneManager.LoadScene(sceneCharger);
    }

    private void lancerProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Instanciation du projectile
            GameObject projectile = Instantiate(projectilePrefab, projectilePos.transform.position, Quaternion.identity) as GameObject;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(projectilePos.transform.up * forceProjectile);
            }
            else
            {
                Debug.LogError("Le Rigidbody2D est manquant sur le projectile !");
            }

            //Détruire le projectile après 2 secondes
            Destroy(projectile, tempsDeVie);
        }
    }

}
