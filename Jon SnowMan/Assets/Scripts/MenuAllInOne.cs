using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAllInOne : MonoBehaviour
{
    public GameObject Menu;
    public GameObject MainMenu;
    public GameObject MenuOptions;
    public GameObject MenuCredits;
    public GameObject MenuCommands;
    [SerializeField] private AudioSource Click;

    public void MoveToScene(int sceneID)
    {
        Click.Play();
        SceneManager.LoadScene(sceneID);

    }
    public void Quit()
    {
        Click.Play();
        Application.Quit();
    }
    public void ButtonClicked(string _String)
    {
        Click.Play();
        if (_String == "Credits Button")
        {
            MainMenu.SetActive(false);
            MenuCredits.SetActive(true);
        }
        if (_String == "Return From Credits Button")
        {
            MainMenu.SetActive(true);
            MenuCredits.SetActive(false);
        }



    }
}
