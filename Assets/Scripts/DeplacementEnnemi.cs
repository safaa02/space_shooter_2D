using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEnnemi : MonoBehaviour
{
    [SerializeField] private Vector2 pointA;    
    [SerializeField] private Vector2 pointB;
    [SerializeField] private float vitesse;

    void Start()
    {
        
    }
    
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, pointA, vitesse * Time.deltaTime);
        transform.position = Vector2.MoveTowards(pointB, pointA, vitesse * Time.deltaTime);
    }
}
