using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PhaseGame
{
    Menu,
    PlayGame
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GamePlayController gamePlayController;
    public MenuController menuController;

    PhaseGame phaseGame;


    void Awake()
    {
        if (Instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        phaseGame = PhaseGame.PlayGame;
    }

    

    public void StartPhaseMenu()
    {
        phaseGame = PhaseGame.Menu;
        menuController.gameObject.SetActive(true);
        menuController.DisplayMenuUI();
    }

    public void StartPhasePlayGame()
    {
        phaseGame = PhaseGame.PlayGame;
        gamePlayController.gameObject.SetActive(true);
        gamePlayController.StartPlayGame();
    }

    public void TurnOfCurrentPhase()
    {
        switch (phaseGame)
        {
            case PhaseGame.Menu:
                menuController.gameObject.SetActive(false);
                break;
            case PhaseGame.PlayGame:
                gamePlayController.gameObject.SetActive(false);
                break;
        }
    }

}
