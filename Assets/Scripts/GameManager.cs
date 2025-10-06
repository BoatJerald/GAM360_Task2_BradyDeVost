using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Clicker Stats")]
    public int score = 0;
    public int clickPower = 1;
    public int clickUpgrade = 0;
    public int powerUpgrade = 0;
    public int powerCost = 50;
    public int autoCost = 100;
    public float clickTime = 1f;
    public float upgradeTime = 1f;
    float clickTimer;

    [Header("UI References")]
    public TMP_Text scoreText;
    public TMP_Text upgradeText;
    public TMP_Text autoText;
    public TMP_Text prestigeText;
    public TMP_Text upgradeAmount;

    private void Awake()
    {
        // Singleton pattern implementation
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManagers
        }
    }

    public void addScore()
    {
        score += clickPower + powerUpgrade * 2;
        scoreText.text = "Score: " + score;
    }

    public void shopPower()
    {
        if (score >= powerCost)
        {
            score = score - powerCost;
            powerUpgrade++;
            powerCost = powerCost * 2;
            upgradeText.text = "Upgrade: " + powerCost;
            upgradeAmount.text = "Upgrades: " + (powerUpgrade + clickUpgrade);
        }
    }

    public void shopAuto()
    {
        if (score >= autoCost)
        {
            score = score - autoCost;
            clickUpgrade++;
            upgradeTime = upgradeTime - 0.1f;
            autoCost = autoCost * 2;
            autoText.text = "Auto: " + autoCost;
            upgradeAmount.text = "Upgrades: " + (powerUpgrade + clickUpgrade);
        }
    }

    public void shopPrestiege()
    {
        if (clickUpgrade + powerUpgrade >= (clickPower * 2)- 1)
        {
            score = 0;
            powerUpgrade = 0;
            clickUpgrade = 0;
            upgradeTime = 1f;
            clickPower = clickPower * 2;
            prestigeText.text = "Prestige! Upgrades: " + ((clickPower * 2) - 1);
            powerCost = 50;
            autoCost = 100;
            autoText.text = "Auto: " + autoCost;
            upgradeText.text = "Upgrade: " + powerCost;
            scoreText.text = "Score: " + score;
            upgradeAmount.text = "Upgrades: " + (powerUpgrade + clickUpgrade);
        }
    }
    public void Update()
    {
        clickTimer += Time.deltaTime;

        if (clickTimer >= clickTime )
            {
                addScore();
                clickTimer -= upgradeTime;
            }
    }
}
