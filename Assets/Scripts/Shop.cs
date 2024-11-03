using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Baker")]
    public TextMeshProUGUI priceText;
    public int price = 10;
    public TextMeshProUGUI countText;
    public int count = 0;

    private Clicker clicker;
    private void Start()
    {
        clicker = FindObjectOfType<Clicker>();
    }
    public void BuyBaker()
    {
        if (clicker.clicks >= price)
        {
            clicker.clicks -= price;
            UiManager.instance.UpdateClicks(clicker.clicks);

            count++;
            countText.text = count.ToString();

            price = (int)(price * 1.1f);
            priceText.text = $"Price: {price}";

            clicker.bpc += 1;
        }
    }
}