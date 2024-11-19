using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeplacementPlayer : MonoBehaviour
{
    [SerializeField] private float vitesseRotation = 150f;
    [SerializeField] private float vitessePosition = 5f;
    
    void Start(){   }

    void Update()
    {
        deplacerVaisseau();
    }

    private void deplacerVaisseau()
    {
        // Déplacer le Game Objet personnage 

        //Position
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 positionMouvement = new Vector3(0, verticalInput, 0) * vitessePosition * Time.deltaTime;
        this.transform.Translate(positionMouvement);

        //Rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotation = horizontalInput * vitesseRotation * Time.deltaTime;
        this.transform.Rotate(0, 0, -rotation);

        //Message Log
        //Debug.Log("Déplacement du vaisseau !!");
    }

}
