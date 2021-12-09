using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IScreen
{
    private static GameManager _instance;
    public static GameManager Instance { get => _instance; }


    public SoundLibrary GameSounds;
    public int TotalPoints { get; private set;}

    void Awake()
    {
        if (!_instance)
            _instance = this;
    }
    private void Start()
    {
        EventManager.SubscribeToEvent(Constants.ON_GET_POINTS, SumToTotalPoints);
        EventManager.SubscribeToEvent(Constants.EVENT_DEFEAT, DisplayDefeatScreen);
        EventManager.SubscribeToEvent(Constants.EVENT_WIN, DisplayWinScreen);

        ScreenManager.Instance.Push(this);
    }

    private void SumToTotalPoints(params object[] vs)
    {
        this.TotalPoints += (int)vs[0];
    }
    private void DisplayDefeatScreen(params object[] vs)
    {
        ScreenManager.Instance.Push("Defeat_Screen");
    }
    private void DisplayWinScreen(params object[] vs)
    {
        ScreenManager.Instance.Push("Win_Screen");
    }

    public void Activate()
    {
        Time.timeScale = 1;

        Debug.Log("Level starting");
    }

    public void Deactivate()
    {
        Debug.Log("Level lost focus");
    }

    public string Free()
    {
        Time.timeScale = 0;
        return "Level unloaded";
    }
}
