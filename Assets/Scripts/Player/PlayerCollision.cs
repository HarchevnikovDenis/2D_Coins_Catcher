using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    private void GameOver()
    {
        PlayerStats.Instance.ShowGameOverPanel();
    }
}
