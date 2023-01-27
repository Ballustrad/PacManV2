using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject fruits; // tableau des fruits à spawner
    public float spawnInterval = 10f; // intervalle de temps entre chaque spawn (en secondes)
    private float spawnTimer = 0f; // compteur pour le prochain spawn

    void Update()
    {
        spawnTimer += Time.deltaTime; // incrémenter le compteur de spawn

        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f; // réinitialiser le compteur

            

            // choisir une position aléatoire sur l'écran
            Vector2 randomPosition = new Vector2(Random.Range(-9f, 9f), Random.Range(-5f, 5f));

            // instancier le fruit à la position choisie
            Instantiate(fruits, randomPosition, Quaternion.identity);
        }
    }
}
