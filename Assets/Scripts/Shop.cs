using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Baker")]
    public TextMeshProUGUI priceText;
    public int price = 10;
    public TextMeshProUGUI countText;
    public int count = 0;
    public int cpb = 1; //clicks per baker
    public float bakerSpeed = 2f;

    private Clicker clicker;
    private void Start()
    {
        clicker = FindObjectOfType<Clicker>();
        InvokeRepeating("Cook", 0, bakerSpeed);

        //var clicks = PlayerPrefs.GetInt("Clicks", 0);
        //var cooks = PlayerPrefs.GetInt("Bakers", 0);
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

            //clicker.bpc += 1;

        }
    }
    public void SaveProgress()
    {
        PlayerPrefs.SetInt("Clicks", clicker.clicks);
        PlayerPrefs.SetInt("Bakers", count);
        PlayerPrefs.Save();
    }
    void Cook()
    {
        clicker.clickVFX.Emit(cpb * count);
        clicker.clicks += cpb * count;
        UiManager.instance.UpdateClicks(clicker.clicks);
    }
}