using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    [Header(" --- Deplacement Ennemi ---")]
    //
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float vitesse = 2;

    [Header(" --- Projectile lancement ---")]
    //
    [SerializeField] private GameObject prefabProjectile;
    [SerializeField] private GameObject positionLancementProjectile;
    [SerializeField] private float forceProjectile = 1000f;
    [SerializeField] private float tempsDeVie = 2f;
    private Vector3 target;

    [Header(" --- Vie Ennemi ---")]
    //
    [SerializeField] private float vieEnnemi = 100f;
    [SerializeField] private float degatPlayer = 50f;
    //
    [SerializeField] public GameObject[] coeurs;

    [Header(" --- Gestion du Menu ---")]
    //
    [SerializeField] private MenuManager menuManager;

    void Start()
    {
        target = pointA.transform.position;
        StartCoroutine(CoroutTir());
    }

    void Update()
    {
        DeplacerEnnemi();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GestionVie(collision);
    }

                                  
    private void DeplacerEnnemi()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target, vitesse * Time.deltaTime);

        if (Vector2.Distance(this.transform.position, target) < 0.01f)
        {
            if (target == pointA.transform.position)
            {
                target = pointB.transform.position;
            }
            else
            {
                target = pointA.transform.position;
            }
        }
    }

    IEnumerator CoroutTir()
    {
        while (true)
        {
            //Tir toutes les 3 secondes
            yield return new WaitForSeconds(3f);

            //Instanciation du projectile
            GameObject projectile = Instantiate(prefabProjectile, positionLancementProjectile.transform.position, Quaternion.identity) as GameObject;

            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.AddForce(-positionLancementProjectile.transform.up * forceProjectile);
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
        if (collision.gameObject.CompareTag("ProjectilePlayer"))
        {
            Destroy(collision.gameObject);

            vieEnnemi = vieEnnemi - degatPlayer;
            Debug.Log("La vie de l'ennemi est à " + vieEnnemi);

            //Coeur de l'ennemi
            AffichageVie(vieEnnemi);

            if (vieEnnemi <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("L'ennemi est détruit !");

                // Décrémenter le nombre d'ennemis restants pour ouvrir le menu quand il n'y en a plus
                menuManager.DecrementerEnnemi();

                // Détruire le parent de l'ennemi (ce qui détruit aussi pointA et pointB qui sont des enfants du parent)
                Destroy(transform.parent.gameObject);
            }
        }
    }

    public void AffichageVie(float pointsVie)
    {
        if (pointsVie <= 50)
        {
            coeurs[0].gameObject.SetActive(false);
        }
        if (pointsVie <= 0)
        {
            coeurs[1].gameObject.SetActive(false);
        }
    }
}