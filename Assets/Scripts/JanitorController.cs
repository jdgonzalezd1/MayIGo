using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanitorController : MonoBehaviour
{
    [SerializeField] private HUD hud;
    void Start()
    {
        hud = FindAnyObjectByType<HUD>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hud.janitorWarning.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hud.janitorWarning.SetActive(false);
        }
    }
}
