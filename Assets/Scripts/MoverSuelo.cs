﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverSuelo : MonoBehaviour
{
    
    public float tamSuelo;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //Simplemente es una comprobacion
        Vector3 distancia = mainCamera.transform.position - transform.position;
        if (tamSuelo <= distancia.magnitude)
        {
            transform.position = new Vector3(mainCamera.transform.position.x, transform.position.y, transform.position.z);
        }
    }
}
