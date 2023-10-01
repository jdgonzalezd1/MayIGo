using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int PoopCountdown { get { return poopCountdown; } }
    public int InitialPoopCountdown { get { return initialPoopCountdown; } }

    [SerializeField] private int poopCountdown;
    [SerializeField] private int initialPoopCountdown;
    [SerializeField] private GameObject gameOver;
    public bool isPaperTaken = false;
    public int initialValue;
    //public PoopBar toleranceBar;
    
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

        //DontDestroyOnLoad(gameObject);

        Time.timeScale = 1.0f;
        setPoopCountdown(initialValue);
        initialPoopCountdown = initialValue;
        isPaperTaken = false;
        //toleranceBar.SetMaxHealth(initialPoopCountdown);
        InvokeRepeating("PoopTolerance", 0, 1.0f);
        Debug.Log(poopCountdown);
    }
    
    private void Start()
    {
        
    }

    public void PoopTolerance()
    {
        poopCountdown--;
        //toleranceBar.SetHealth(poopCountdown);

        if(poopCountdown < 1)
        {
            Debug.Log("Demasiado tarde. Te has cagado!");
            gameOver.SetActive(true);
            Time.timeScale = 0.0f;
            CancelInvoke("PoopTolerance");
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

    public void modifyCount(int time)
    {
        this.poopCountdown -= time;
    }

    public void setPoopCountdown(int initialValue)
    {
        this.poopCountdown = initialValue;
    }

    public int getPoopCountdown()
    {
        return this.poopCountdown;
    }
}
