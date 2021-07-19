using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject FoodPanel;
    public GameObject ShopPanel;

    [SerializeField] private Text hungerDisplay;
    [SerializeField] private Text happinessDisplay;

    private void Update()
    {
        hungerDisplay.text = $"Hunger: {gameManager.Instance.pet.Hunger}";
        happinessDisplay.text = $"Happiness: {gameManager.Instance.pet.Happiness}";
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
