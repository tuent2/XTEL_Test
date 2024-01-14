using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f;
    [SerializeField] private Transform rotateAround;
    private bool isReadyPlay = false;

    private void OnEnable()
    {
        rotationSpeed = 0f;
    }

    
    [System.Obsolete]
    void Update()
    {
        transform.RotateAround(rotateAround.position,Vector3.forward, rotationSpeed * Time.deltaTime);
    }
    public void SetPreparePlay()
    {
        isReadyPlay = false;
    }

    public void ChangeSpeedOfPlayer()
    {
        if (isReadyPlay == false)
        {
            isReadyPlay = true;
            rotationSpeed = 90f;
        }
        else
        {
            rotationSpeed = -rotationSpeed;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("RetangleBlock"))
        {
            
            GameManager.Instance.gamePlayController.setCurrentScore();
            GameManager.Instance.gamePlayController.CollideRetangleBlock();
        }
        if (collision.gameObject.CompareTag("SquareBlock"))
        {

            GameManager.Instance.gamePlayController.CollideSquareBlock();


        }
    }
}
