using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalTextPoint;
    [SerializeField] TextMeshProUGUI message;
    int BestCore;
    public void DisplayMenuUI()
    {
        int CurrentScore = GameManager.Instance.gamePlayController.getCurrentScore();
        finalTextPoint.text = CurrentScore.ToString();
        if (!PlayerPrefs.HasKey(Data.BestScore))
        {
            message.text = "New Best!";
            PlayerPrefs.SetInt("BestScore", CurrentScore);
        }
        else
        {
            BestCore = PlayerPrefs.GetInt(Data.BestScore);
            if (CurrentScore > BestCore)
            {
                message.text = "New Best!";
                PlayerPrefs.SetInt("BestScore", CurrentScore);
            }
            else
            {
                message.text = "Great Job!";
            }
        }
    }

    public void ClickStartPlayGameAgain()
    {
        GameManager.Instance.TurnOfCurrentPhase();
        GameManager.Instance.StartPhasePlayGame();
    }
}
