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
    public GameObject gameUI;
    public GameObject startMenu;
    public GameObject endScreen;

    private void Awake()
    {
        Time.timeScale = 0f;
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

    public void startGame()
    {
        if (startMenu) startMenu.SetActive(false);
        if (gameUI) gameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void restart()
    {
        score = 0;
        clickPower = 1;
        powerUpgrade = 0;
        clickUpgrade = 0;
        upgradeTime = 1f;
        powerCost = 50;
        autoCost = 100;
        scoreText.text = "Score: " + score;
        upgradeText.text = "Upgrade: " + powerCost;
        autoText.text = "Auto: " + autoCost;
        upgradeAmount.text = "Upgrades: " + (powerUpgrade + clickUpgrade);
        prestigeText.text = "Prestige! Upgrades: " + ((clickPower * 2) - 1);
        if (gameUI) gameUI.SetActive(true);
        if (endScreen) endScreen.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void winGame()
    {
        if (gameUI) gameUI.SetActive(false);
        if (endScreen) endScreen.SetActive(true);
        Time.timeScale = 0f;
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

            if (powerCost == 12800)
            {
                upgradeText.text = "Max Upgrades";
            }
            else
            {
                upgradeText.text = "Upgrade: " + powerCost;
            }

            upgradeAmount.text = "Upgrades: " + (powerUpgrade + clickUpgrade);
            scoreText.text = "Score: " + score;
        }
    }

    public void shopAuto()
    {
        if (score >= autoCost)
        {
            score = score - autoCost;
            clickUpgrade++;
            if (upgradeTime <= .25f)
            {
                upgradeTime = .1f;
            }
            else
            {
                upgradeTime = upgradeTime - 0.125f;
            }

            autoCost = autoCost * 2;

            if (autoCost == 12800)
            {
                autoText.text = "Max Upgrades";
            }
            else
            {
                autoText.text = "Auto: " + autoCost;
            }
            upgradeAmount.text = "Upgrades: " + (powerUpgrade + clickUpgrade);
            scoreText.text = "Score: " + score;
        }
    }

    public void shopPrestiege()
    {
        if (clickUpgrade + powerUpgrade >= (clickPower * 2) - 1)
        {
            if (clickPower == 8)
            {
                winGame();
            }

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

        if (clickTimer >= clickTime)
            {
                addScore();
                clickTimer -= upgradeTime;
            }
    }
}
