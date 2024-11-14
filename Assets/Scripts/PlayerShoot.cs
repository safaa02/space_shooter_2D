using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject missile;


    void Update()
    {        
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(missile, transform.position, Quaternion.identity);
        }        
    }


}
