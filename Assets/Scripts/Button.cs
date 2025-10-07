using UnityEngine;

public class Button : MonoBehaviour
{
    public AudioClip blip;
    public AudioClip yippie;

    public void clickButton()
    {
        GameManager.Instance.addScore();
    }

    public void buyPower()
    {
        GameManager.Instance.shopPower();
        AudioManager.Instance.Play(blip);
    }

    public void buyAuto()
    {
        GameManager.Instance.shopAuto();
        AudioManager.Instance.Play(blip);
    }

    public void buyPrestige()
    {
        GameManager.Instance.shopPrestiege();
        AudioManager.Instance.Play(yippie);
    }

    public void letsGo()
    {
        GameManager.Instance.startGame();
        AudioManager.Instance.Play(yippie);
    }

    public void pressQuit()
    {
        GameManager.Instance.quitGame();
        AudioManager.Instance.Play(blip);
    }

    public void goAgain()
    {
        GameManager.Instance.restart();
        AudioManager.Instance.Play(blip);
    }
}
