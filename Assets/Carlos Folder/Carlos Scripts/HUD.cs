using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public PoopBar toleranceBar;

    public Image paperImage;

    public GameObject gameOverPanel;

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
        gameOverPanel.SetActive(false);
        toleranceBar.SetMaxHealth(GameManager.Instance.InitialPoopCountdown);
        InvokeRepeating("ToleranceCountdown", 0, 1.0f);

    }

    public void ToleranceCountdown()
    {
        toleranceBar.SetHealth(GameManager.Instance.PoopCountdown);

        if (GameManager.Instance.PoopCountdown < 1)
        {
            gameOverPanel.SetActive(true);
            CancelInvoke();
        }
    }

    public void ActivePaperIcon()
    {
        paperImage.gameObject.SetActive(true);
    }
}
