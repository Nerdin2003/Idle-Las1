using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text EnergyText;
    public Text EnergyIncomeText;
    
    [SerializeField]
    private int energy;
    [SerializeField]
    private int cursors;
  
    private void Start()
    {
        energy = PlayerPrefs.GetInt("Energy", 0);
        cursors = PlayerPrefs.GetInt("Cursors", 0);

        DateTime lastSaveTime = Utils.GetDateTime("LastSaveTime", DateTime.UtcNow);
        TimeSpan timePassed = DateTime.UtcNow - lastSaveTime;
        int secondsPassed = (int)timePassed.TotalSeconds;
        secondsPassed = Mathf.Clamp(secondsPassed, 0, 7 * 24 * 60 * 60);
        energy += secondsPassed * cursors; //тут рахує добуванян офлайн 

        UpdateText();

        InvokeRepeating(nameof(PayIncome), 1f, 1f);
    }

    public void CookieClicked()
    {
        energy++;

        SaveData();
        UpdateText();
    }

    public void BuyCursor()
    {
        if (energy < 10) return;

        energy -=10;
        cursors +=1;

        SaveData();
        UpdateText(); 
    }

    private void PayIncome()
    {
        energy += cursors;

        SaveData();
        UpdateText();
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("Energy", energy);
        PlayerPrefs.SetInt("Cursors", cursors);

        Utils.SetDateTime("LastSaveTime", DateTime.UtcNow);
    }

    private void UpdateText()
    {
        EnergyText.text = $"{energy} energy";
        EnergyIncomeText.text =$"+{cursors} energy/second";
    }

    
    public static void SetDateTime(string key, DateTime value)
    {
        string convertedToString = value.ToString("u", CultureInfo.InvariantCulture);
        PlayerPrefs.SetString(key, convertedToString);
    }

    public static DateTime GetDateTime(string key, DateTime defaultValue)
    {
        if (PlayerPrefs.HasKey(key))
        {
            string stored = PlayerPrefs.GetString(key);
            DateTime result = DateTime.ParseExact(stored, "u", CultureInfo.InvariantCulture);
            return result;
        }
        else 
        {
            return defaultValue;
        }
    }
}
