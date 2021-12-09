using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour, IScreen
{

    [SerializeField] private List<Button> _content;

    public void PlayUIClickSound()
    {
        SoundManager.instance?.PlayEffect("ui_click");
    }

    public void Activate()
    {
        foreach (var item in _content)
        {
            item.interactable = true;
        }
    }

    public void Deactivate()
    {
        foreach (var item in _content)
        {
            item.interactable = false;
        }

        Debug.Log("Saliendo del menu");
    }

    public string Free()
    {
        this.gameObject.SetActive(false);
        return "MainMenu";
    }

    #region PARA_ACHURAR
    public void PlayNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayIndexedScene(int idx)
    {
        SceneManager.LoadScene(idx);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion
}
