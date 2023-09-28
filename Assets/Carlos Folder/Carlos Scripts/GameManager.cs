using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int PoopCountdown { get { return poopCountdown;} }
    public int InitialPoopCountdown { get { return initialPoopCountdown; } }

    [SerializeField] private int poopCountdown;
    [SerializeField] private int initialPoopCountdown;
    public bool isPaperTaken = false;
    public int initialValue = 30;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1.0f;

        poopCountdown = initialValue;
        initialPoopCountdown = initialValue;
        isPaperTaken = false;
        InvokeRepeating("PoopTolerance", 0, 1.0f);
    }

    public void PoopTolerance()
    {
        poopCountdown--;

        if(poopCountdown < 1)
        {
            Debug.Log("Demasiado tarde. Te has cagado!");
            Time.timeScale = 0.0f;
            CancelInvoke();
        }
    }

    public void PaperTake()
    {
        if(!isPaperTaken)
        {
            isPaperTaken = true;
            HUD.Instance.ActivePaperIcon();
        }
    }
}
