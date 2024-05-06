using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickBreakableController : MonoBehaviour
{
    [SerializeField]
    private Sprite brokenImage;

    int count;

    [SerializeField]
    GameObject brickBreakableEffect;


    GameManager gameManager;

    [SerializeField]
    GameObject scoreUpPrefab;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }

    private void Start()
    {

        count = 0;
        
    }


    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ball")
        {
            count++;
            
            if(count == 1)
            {
                GetComponent<SpriteRenderer>().sprite = brokenImage;

                gameManager.UpdateScore(5);

            }else if(count==2)
            {
                Instantiate(brickBreakableEffect, transform.position, transform.rotation);

                gameManager.UpdateScore(10);


                int randomChance = Random.Range(1, 101);
            
                if(randomChance > 60)
                {
                    Instantiate(scoreUpPrefab, transform.position, transform.rotation);
                }


                Destroy(gameObject);
            }
        }
    }


}


