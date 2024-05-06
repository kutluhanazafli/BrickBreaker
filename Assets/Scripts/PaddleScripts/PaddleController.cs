using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    
    [SerializeField]
    float speed;

    [SerializeField]
    float leftTarget, rightTarget;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameOver)
        {
            return;
        }


        //Start Moving
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * h * Time.deltaTime * speed);

        // if(transform.position.x < leftTarget){
        //     transform.position = new Vector2(leftTarget, transform.position.y);
        // }

        //  if(transform.position.x > rightTarget){
        //     transform.position = new Vector2(rightTarget, transform.position.y);
        // }

        // Sınırlandırma Yapıldı
        Vector2 temp = transform.position;
        temp.x =  Mathf.Clamp(temp.x, leftTarget, rightTarget);
        transform.position = temp;

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="liveUpBall")
        {
            gameManager.UpdateLives(1);
            Destroy(other.gameObject);
        }


        if(other.gameObject.tag=="scoreUpBall")
        {
            gameManager.UpdateScore(30);
            Destroy(other.gameObject);
        }
    }

}
