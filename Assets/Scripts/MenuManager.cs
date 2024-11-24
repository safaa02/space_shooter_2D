using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nomScene;
    [SerializeField] private GameObject menu;
    [SerializeField] private Text texteResultat;

    // Compteur des ennemis
    private int totalEnnemis;
    private int ennemisRestants;


    void Start()
    {
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
            resultatPlayer(true);
            ouvrirMenu();
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
        }
        else
        {
            texteResultat.text = "Défaite";
        }
    }

    public void OuvrirScene()
    {
        SceneManager.LoadScene(nomScene);
    }

}
