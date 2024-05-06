using System.Collections;
using System.Collections.Generic;
using UnityEditor.Media;
using UnityEditor.SearchService;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    private Rigidbody2D rb;

    [SerializeField]
    float speed = 500f;

    [SerializeField]
    bool inPlay;

    [SerializeField]
    Transform ballStartPos;

    GameManager gameManager;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        gameManager = Object.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver)
        {
            return;
        }


        if(!inPlay)
        {
            transform.position = ballStartPos.position;

        }

        if(Input.GetButtonDown("Jump") && !inPlay)
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Bottom")
        {
            rb.velocity = Vector2.zero;

            gameManager.UpdateLives(-1);

            inPlay = false;
        }
    }
}
