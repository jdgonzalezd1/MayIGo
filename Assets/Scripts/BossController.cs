using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private int timeTaken;
    [SerializeField] private HUD hud;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        hud = FindAnyObjectByType<HUD>();
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.modifyCount(timeTaken);
            hud.bossWarning.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hud.bossWarning.SetActive(true);
        }
    }
}
