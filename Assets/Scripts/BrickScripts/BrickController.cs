using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrickController : MonoBehaviour
{

    [SerializeField]
    GameObject brickEffect;

    GameManager gameManager;

    [SerializeField]
    GameObject liveUpPrefab;

    private void Awake()
    {
        gameManager = Object.FindObjectOfType<GameManager>();
    }
   
    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ball")
        {
            Instantiate(brickEffect, transform.position, transform.rotation);

            gameManager.UpdateScore(5);

            int randomChance = Random.Range(1, 101);
            
            if(randomChance > 60)
            {
                Instantiate(liveUpPrefab, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }

}
