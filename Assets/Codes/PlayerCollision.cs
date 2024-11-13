using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    public void Start()
    {
        GameManager.Instance.onPlay.AddListener(ActivatePlayer);
    }

    public void ActivatePlayer()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.transform.tag == "Obstacle")
        {
            gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }
    }

}
