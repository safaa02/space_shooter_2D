using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEnnemi : MonoBehaviour
{
    [SerializeField] private GameObject pointA;
    [SerializeField] private GameObject pointB;
    [SerializeField] private float vitesse = 2;

    private Vector3 target;

    void Start()
    {
        target = pointA.transform.position;
    }
    
    void Update()
    {
        deplacerEnnemi();
    }

    private void deplacerEnnemi()
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

}
