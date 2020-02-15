using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorDeEnemigos : MonoBehaviour
{

    public GameObject enemigo_original;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DecideSiEnemigo();
    }

    private void DecideSiEnemigo()
    {
        float random = Random.Range(0.0f, 100.0f);
        if (random < 1.0f)
        {
            GameObject.Instantiate(enemigo_original, transform.position, transform.rotation);
        }
    }
}
