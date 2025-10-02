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

    [Header("UI References")]
    public TMP_Text scoreText;
    public TMP_Text upgradeText;
    public TMP_Text autoText;

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
        score += (clickPower + powerUpgrade) * 2;
        scoreText.text = "Score: " + score;
    }
     public void shopPower()
    {
        if (score >= powerCost)
        {
            score = score - powerCost;
            powerUpgrade++;
            powerCost = powerCost * (clickUpgrade + powerUpgrade);
            upgradeText.text = "Upgrade: " + powerCost;
        }
    }

    public void shopAuto()
    {
        if (score >= autoCost)
        {
            score = score - autoCost;
            clickUpgrade++;
            autoCost = autoCost * (clickUpgrade + powerUpgrade);
            autoText.text = "Auto: " + autoCost;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
