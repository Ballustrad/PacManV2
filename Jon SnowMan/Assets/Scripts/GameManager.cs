using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public Pacman pacman;
    public Transform pellets;
    public int nbTotal = 240;

    public Text gameOverText;
    public Text WinText;
    public Text scoreText;
    public Text livesText;
    public CameraShake cameraShake;

    public int ghostMultiplier { get; private set; } = 1;
    public int score { get; private set; }
    public int lives { get; private set; }

    public GameObject AudioManager;
    [SerializeField] private AudioSource JB_Hard;
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource pelletEattt;
    [SerializeField] private AudioSource powerPellet;
    [SerializeField] private AudioSource pcDeath;
    [SerializeField] private AudioSource ghostDeath
        ;
    internal static object instance;

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (lives <= 0 && Input.anyKeyDown) {
            NewGame();
        }
        if (nbTotal == 0 ) 
        {
            Win();
        } 
        if (PauseMenu.GameISPaused)
        {
            StopCoroutine(cameraShake.Shake(8f, .040f));
        }
    }

    private void NewGame()
    {
        BGM.Play();
        SetScore(0);
        SetLives(3);
        NewRound();
    }

    private void NewRound()
    {   
        BGM.Play();
        gameOverText.enabled = false;
        WinText.enabled = false;

        foreach (Transform pellet in pellets) {
            pellet.gameObject.SetActive(true);
        }

        ResetState();
    }

    private void ResetState()
    {
        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].ResetState();
        }

        pacman.ResetState();
    }

    private void GameOver()
    {   
        StopCoroutine(cameraShake.Shake(8f, .040f));
        gameOverText.enabled = true;

        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].gameObject.SetActive(false);
        }

        pacman.gameObject.SetActive(false);
    }

        private void Win()
    {
        StopCoroutine(cameraShake.Shake(8f, .040f));
        WinText.enabled = true;
        BGM.Stop();
        JB_Hard.Stop();
    }

    private void SetLives(int lives)
    {
        this.lives = lives;
        livesText.text = "x" + lives.ToString();
    }

    public void SetScore(int score)
    {
        this.score = score;
        scoreText.text = score.ToString().PadLeft(2, '0');
    }

    public void PacmanEaten()
    {
        pcDeath.Play();
        pacman.DeathSequence();

        SetLives(lives - 1);
        Debug.Log("mort");

        if (lives > 0) {
            Invoke(nameof(ResetState), 3f);
        } else {
            GameOver();
        }
    }

    public void GhostEaten(Ghost ghost)
    {
        ghostDeath.Play();
        int points = ghost.points * ghostMultiplier;
        SetScore(score + points);

        ghostMultiplier++;
    }

    public void PelletEaten(Pellet pellet)
    {
        pelletEattt.Play();
        pellet.gameObject.SetActive(false);

        SetScore(score + pellet.points);

        if (!HasRemainingPellets())
        {
            pacman.gameObject.SetActive(false);
            Invoke(nameof(NewRound), 3f);
            Win();
        }
    }
    IEnumerator PowerMusic()
    {   
        BGM.Pause();
        JB_Hard.Play();
        yield return new WaitForSeconds(8f);
        JB_Hard.Stop();
        BGM.UnPause();
    }
    public void PowerPelletEaten(PowerPellet pellet)
    {
        powerPellet.Play();
        StartCoroutine(cameraShake.Shake(8f, .040f));
        StartCoroutine(PowerMusic());
        for (int i = 0; i < ghosts.Length; i++) {
            ghosts[i].frightened.Enable(pellet.duration);
        }

        PelletEaten(pellet);
        CancelInvoke(nameof(ResetGhostMultiplier));
        Invoke(nameof(ResetGhostMultiplier), pellet.duration);
    }

    private bool HasRemainingPellets()
    {
        foreach (Transform pellet in pellets)
        {
            if (pellet.gameObject.activeSelf) {
                return true;
            }
        }

        return false;
    }

    private void ResetGhostMultiplier()
    {
        ghostMultiplier = 1;
    }

}
