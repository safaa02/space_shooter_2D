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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitterJeu();
        }
    }

    public void DecrementerEnnemi()
    {
        ennemisRestants--;

        // Si tous les ennemis ont été détruits
        if (ennemisRestants <= 0)
        {
            //Ouvre le Menu
            ResultatPlayer(true);
        }
    }

    public void OuvrirMenu()
    {
        menu.SetActive(true);
    }

    public void ResultatPlayer(bool resultat)
    {
        if (resultat)
        {
            texteResultat.text = "Gagné";
            OuvrirMenu();
            EnPause();
        }
        else
        {
            texteResultat.text = "Défaite";
            OuvrirMenu();
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

    public void QuitterJeu()
    {
        Application.Quit();
        Debug.Log("Quitter jeu");
    }
}
