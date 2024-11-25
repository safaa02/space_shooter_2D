using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header(" --- Menu UI ---")]
    //
    [SerializeField] private GameObject menu;
    [SerializeField] private Text texteResultat;

    [Header(" --- Scene ---")]
    //
    [SerializeField] private string nomScene;

    [Header(" --- Ennemis ---")]
    // Compteur des ennemis
    private int totalEnnemis;
    private int ennemisRestants;

    [Header(" --- Vie ---")]
    //
    [SerializeField] public Image[] coeurs;


    void Start()
    {
        ReprendreLeJeu();

        menu.SetActive(false);

        // Trouve les ennemis et compte-les
        totalEnnemis = GameObject.FindGameObjectsWithTag("Ennemi").Length;
        ennemisRestants = totalEnnemis;
    }

    public void DecrementerEnnemi()
    {
        ennemisRestants--;

        // Si tous les ennemis ont été détruits
        if (ennemisRestants <= 0)
        {
            //Ouvre le Menu
            resultatPlayer(true);
        }
    }

    public void ouvrirMenu()
    {
        menu.SetActive(true);
    }

    public void resultatPlayer(bool resultat)
    {
        if (resultat)
        {
            texteResultat.text = "Gagné";
            ouvrirMenu();
            EnPause();
        }
        else
        {
            texteResultat.text = "Défaite";
            ouvrirMenu();
            EnPause();
        }
    }

    public void OuvrirScene()
    {
        SceneManager.LoadScene(nomScene);
    }

    public void AffichageVie(float pointsVie)
    {
        if (pointsVie <= 75)
        {
            coeurs[0].gameObject.SetActive(false);
        }
        if (pointsVie <= 50)
        {
            coeurs[1].gameObject.SetActive(false);
        }
        if (pointsVie <= 25)
        {
            coeurs[2].gameObject.SetActive(false);
        }
        if (pointsVie <= 0)
        {
            coeurs[3].gameObject.SetActive(false);
        }
    }

    private void EnPause()
    {
        // Pause le jeu 
        Time.timeScale = 0;
    }

    public void ReprendreLeJeu()
    {
        // Reprend le jeu
        Time.timeScale = 1;
    }


}
