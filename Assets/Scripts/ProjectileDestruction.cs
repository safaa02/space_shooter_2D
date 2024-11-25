using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestruction : MonoBehaviour
{
    void Start(){ }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestructionSurMur(collision);
    }


    private void DestructionSurMur(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Mur"))
        {
            Destroy(this.gameObject);
        }
    }


}
