using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeRecogibles : MonoBehaviour
{
    public GameObject moneda_original;
    public float probabilidadDeAparicion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        DecideSiEnemigo();
    }

    private void DecideSiEnemigo()
    {
        float random = Random.Range(0.0f, 100.0f);
        if (random < probabilidadDeAparicion)
        {
            GameObject.Instantiate(moneda_original, transform.position, transform.rotation);
        }
    }
}
