using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public PoopBar toleranceBar;

    public Image poopImage;
    public Sprite[] emojiIcon;

    public Image paperImage;

    public GameObject gameOverPanel;

    public GameObject bossWarning;

    public GameObject janitorWarning;

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
        bossWarning.SetActive(false);
        janitorWarning.SetActive(false);
        //toleranceBar.SetMaxHealth(GameManager.Instance.InitialPoopCountdown);
        Invoke("SetMaxHealth", 0.1f);
        InvokeRepeating("ToleranceCountdown", 0.2f, 1.0f);
        poopImage.sprite = emojiIcon[0];
    }

    public void SetMaxHealth()
    {
        toleranceBar.SetMaxHealth(GameManager.Instance.InitialPoopCountdown);
    }

    public float HealthPercentage()
    {
        return ((float)GameManager.Instance.PoopCountdown / GameManager.Instance.InitialPoopCountdown) * 100;
    }

    public void ToleranceCountdown()
    {
        toleranceBar.SetHealth(GameManager.Instance.PoopCountdown);

        float actualHealth = HealthPercentage();

        if (actualHealth <= 75 && actualHealth > 50 )
        {
            poopImage.sprite = emojiIcon[1];
        }
        else if (actualHealth <= 50 && actualHealth > 25)
        {
            poopImage.sprite = emojiIcon[2];
        }
        else if (actualHealth <= 25 && actualHealth > 0)
        {
            poopImage.sprite = emojiIcon[3];
        }
        else if (actualHealth < 1.1f)
        {
            poopImage.sprite = emojiIcon[4];
        }

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
