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

    public GameManager gameManager;

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

        gameManager = FindAnyObjectByType<GameManager>();

        paperImage.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
        bossWarning.SetActive(false);
        janitorWarning.SetActive(false);

        //toleranceBar.SetMaxHealth(GameManager.Instance.InitialPoopCountdown);
        Invoke("SetMaxHealth", 0.1f);
        InvokeRepeating("ToleranceCountdown", 0.2f, 1.0f);
        poopImage.sprite = emojiIcon[0];
    }

    void Start()
    {
        
    }

    public void SetMaxHealth()
    {        
        toleranceBar.SetMaxHealth(gameManager.InitialPoopCountdown);        
    }

    public float HealthPercentage()
    {
        return ((float)gameManager.PoopCountdown / gameManager.InitialPoopCountdown) * 100;
    }

    public void ToleranceCountdown()
    {
        toleranceBar.SetHealth(gameManager.PoopCountdown);        

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
        
        if (gameManager.PoopCountdown < 1)
        {            
            gameOverPanel.SetActive(true);
            CancelInvoke("ToleranceCountdown");
        }
        
    }

    public void ActivePaperIcon()
    {
        paperImage.gameObject.SetActive(true);
    }
}
