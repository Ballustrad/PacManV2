using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    public GameManager gameManager;
    public int points = 100; // nombre de points gagn�s en collectant le fruit
    public GameObject pacman; // r�f�rence au joueur (Pac-Man)

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == pacman)
        {
            // augmenter le score du joueur
            gameManager.SetScore(gameManager.score + points);

            // d�sactiver le fruit (le retirer de l'�cran)
            gameObject.SetActive(false);
        }
    }
}
