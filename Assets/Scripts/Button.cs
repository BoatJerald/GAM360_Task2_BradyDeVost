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
}
