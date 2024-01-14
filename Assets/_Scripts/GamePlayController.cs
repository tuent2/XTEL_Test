using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayController : MonoBehaviour
{
    
    [Header("Logic")]
    int currentScore;
    int currentRetangleBlock = 0;
    [SerializeField] GameObject RetangeleBlock0;
    [SerializeField] GameObject RetangeleBlock1;
    [SerializeField] ParticleSystem DeathParticleSystem;
    [SerializeField] PlayerController Player;
    
    [Header("UI")]
    [SerializeField] TextMeshProUGUI CurrentScore;
    void Awake()
    {
        
    }


    private void Start()
    {
        StartPlayGame();
    }


    public int getCurrentScore()
    {
        return currentScore;
    }

    public void setCurrentScore()
    {
        currentScore++;
        CurrentScore.text = currentScore.ToString();
        Mathf.Clamp(currentScore, 0, int.MaxValue);
        
    }

    public void resetScore()
    {
        currentScore = 0;
    }

    public void StartPlayGame()
    {
       
        resetScore();
        currentRetangleBlock = 0;
        RetangeleBlock0.SetActive(true);
        RetangeleBlock1.SetActive(false);
        CurrentScore.text = currentScore.ToString();
        Player.gameObject.SetActive(true);
        Player.gameObject.transform.position = new Vector2(0, -1);
        Player.SetPreparePlay();
    }

    public void CollideRetangleBlock()
    {
        if (currentRetangleBlock == 0)
        {
            currentRetangleBlock = 1;
            RetangeleBlock0.SetActive(false);
            RetangeleBlock1.SetActive(true);
        }
        else if (currentRetangleBlock == 1)
        {
            currentRetangleBlock = 0;
            RetangeleBlock0.SetActive(true);
            RetangeleBlock1.SetActive(false);
        }
    }

    public void CollideSquareBlock()
    {
        Player.gameObject.SetActive(false);
        DeathParticleSystem.transform.position = Player.transform.position;
        DeathParticleSystem.Play();
        StartCoroutine(WaithToComeHomeScreen());
    }

    IEnumerator WaithToComeHomeScreen()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.TurnOfCurrentPhase();
        GameManager.Instance.StartPhaseMenu();
    }
}
