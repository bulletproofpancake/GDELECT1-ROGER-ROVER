using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject FoodPanel;
    public GameObject ShopPanel;

    [SerializeField] private Image hungerDisplay;
    [SerializeField] private Image happinessDisplay;

    private void Update()
    {
        hungerDisplay.fillAmount = (float)gameManager.Instance.pet.Hunger/100f;
        happinessDisplay.fillAmount = (float)gameManager.Instance.pet.Happiness/100f;

        ColorChanger();
    }
    void ColorChanger()
    {
        Color hungerColor = Color.Lerp(Color.red, Color.green, (gameManager.Instance.pet.Hunger / 100f));
        hungerDisplay.color = hungerColor;

        Color hapinessColor = Color.Lerp(Color.red, Color.green, (gameManager.Instance.pet.Happiness / 100f));
        happinessDisplay.color = hapinessColor;
    }

    public void openFoodPanel()
    {
        AudioManager.Instance.Play("buttonOpen");
        FoodPanel.SetActive(true);
    }
    public void closeFoodPanel()
    {
        AudioManager.Instance.Play("buttonClose");
        FoodPanel.SetActive(false);
    }
    public void openShopPanel()
    {
        AudioManager.Instance.Play("buttonOpen");
        ShopPanel.SetActive(true);
    }
    public void closeShopPanel()
    {
        AudioManager.Instance.Play("buttonClose");
        ShopPanel.SetActive(false);
    }


}
