using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareBlock : MonoBehaviour
{
     float speed = 0.5f;
    public Vector2 direction;
    BoxCollider2D blockCollider;
    private void Start()
    {
        blockCollider = gameObject.GetComponent<BoxCollider2D>();
        speed = Random.Range(0.3f, 0.7f);
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

       
        if (collision.gameObject.CompareTag("CoverBlock"))
        {
            
            speed = -speed;
            
        }
    }

   
}
