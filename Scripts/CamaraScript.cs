using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject Personaje;

    void Update()
    {
        Vector3 posicion = transform.position;
        posicion = Personaje.transform.position.x;
        transform.position = posicion;
    }
}
