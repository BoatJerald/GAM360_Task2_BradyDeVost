using UnityEngine;

public class Button : MonoBehaviour
{
    public void clickButton()
    {
        GameManager.Instance.addScore();
    }

    public void buyPower()
    {
        GameManager.Instance.shopPower();
    }

    public void buyAuto()
    {
        GameManager.Instance.shopAuto();
    }

    public void buyPrestige()
    {
        GameManager.Instance.shopPrestiege();
    }

    public void letsGo()
    {
        GameManager.Instance.startGame();
    }

    public void pressQuit()
    {
        GameManager.Instance.quitGame();
    }

    public void goAgain()
    {
        GameManager.Instance.restart();
    }
}
