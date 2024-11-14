using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DeplacementVaisseau : MonoBehaviour
{
    //[SerializeField] private float vitesseDeplacement;
    [SerializeField] private float vitesseRotation = 150f;
    [SerializeField] private float vitessePosition = 5f;

    
    void Start(){   }


    void Update()
    {
        // D�placer le Game Objet personnage 

        //Position
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 positionMouvement = new Vector3(0, verticalInput, 0) * vitessePosition * Time.deltaTime;
        transform.Translate(positionMouvement);

        //Rotation
        float horizontalInput = Input.GetAxis("Horizontal");
        float rotation = horizontalInput * vitesseRotation * Time.deltaTime;        
        transform.Rotate(0, 0, -rotation);

        //Message Log
        Debug.Log("D�placement du vaisseau !!");
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ennemi"))
        {
            Debug.Log("Une collision !!!!!");
            Destroy(collision.gameObject);
        }
    }
}
