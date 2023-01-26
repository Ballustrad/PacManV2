using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource Click;

    public void PlayGame ()
    {
        Click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    public void Credit ()
    {
        Click.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        
    }
    public void Menu ()
    {   
        Click.Play();
        SceneManager.LoadScene(0);
        
    }
    public void QuitGame ()
    {
        Click.Play();
        Debug.Log("Quit");  
        Application.Quit();
    }
}
