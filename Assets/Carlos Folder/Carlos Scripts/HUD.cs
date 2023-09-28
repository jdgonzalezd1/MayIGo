using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image countdownBar;
    public Image paperImage;

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

    void Start()
    {
        paperImage.gameObject.SetActive(false);
    }

    
    void Update()
    {
        countdownBar.fillAmount = (float)GameManager.Instance.PoopCountdown / GameManager.Instance.InitialPoopCountdown;
        
    }

    public void ActivePaperIcon()
    {
        paperImage.gameObject.SetActive(true);
    }
}
