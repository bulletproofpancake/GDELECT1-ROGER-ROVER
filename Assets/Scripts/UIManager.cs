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
        // hungerDisplay.text = $"Hunger: {gameManager.Instance.pet.Hunger}";
        // happinessDisplay.text = $"Happiness: {gameManager.Instance.pet.Happiness}";
        hungerDisplay.fillAmount = (float)gameManager.Instance.pet.Hunger/100f;
        happinessDisplay.fillAmount = (float)gameManager.Instance.pet.Happiness/100f;
    }

    public void openFoodPanel()
    {
        FoodPanel.SetActive(true);
    }
    public void closeFoodPanel()
    {
        FoodPanel.SetActive(false);
    }
    public void openShopPanel()
    {
        ShopPanel.SetActive(true);
    }
    public void closeShopPanel()
    {
        ShopPanel.SetActive(false);
    }
}
