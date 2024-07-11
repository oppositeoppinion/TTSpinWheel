using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public interface IBetsAndScores
{
    public UnityEvent AllBetsBackToZero { get; }
    int Button1BetValue { get; }
    int Button2BetValue { get; }
    int Button3BetValue { get; }
    int Button4BetValue { get; }
    int Money { get; }
    public void IncreaseMoney(int value);
    public void DecreseMoney(int value);
    public void CalculateSpinningResult(string circleName);
}

public class BetsAndScores : MonoBehaviour, IBetsAndScores
{
    public static BetsAndScores Instance;
    public UnityEvent AllBetsBackToZero { get; } = new UnityEvent();
    [field: SerializeField] public int Money { get; private set; }
    [field: SerializeField] public int Button1BetValue { get; private set; }
    [field: SerializeField] public int Button2BetValue { get; private set; }
    [field: SerializeField] public int Button3BetValue { get; private set; }
    [field: SerializeField] public int Button4BetValue { get; private set; }

    [SerializeField] BetField Yellow;
    [SerializeField] BetField Orange;
    [SerializeField] BetField Pink;
    [SerializeField] BetField Violet;
    [SerializeField] BetField Blue;
    [SerializeField] TextMeshProUGUI MoneyText;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
    private void Start()
    {
        Money = 10000;
        UpdateMoneyText();
    }
    public void IncreaseMoney(int value)
    {
        Money += value;
        UpdateMoneyText();
    }
    public void DecreseMoney(int value)
    {
        Money -= value;
        UpdateMoneyText();
    }
    public void CalculateSpinningResult(string circleName)
    {
        //print(circleName);
        print($"money before spin {Money}");
        int yourPrize = 0;
        if (circleName == "BetYellow")
        {
            print("Yellow wins");
            if (Yellow._currentBet != 0)
            {
                Money += Yellow._currentBet;
                yourPrize += Yellow._currentBet;
            }
        }
        else if (circleName == "BetBlue")
        {
            print("Blue wins");
            if (Blue._currentBet != 0)
            {
                Money += Blue._currentBet;
                yourPrize += Blue._currentBet;
            }
        }
        else if (circleName == "BetViolet")
        {
            print("Violet wins");
            if (Violet._currentBet != 0)
            {
                Money += Violet._currentBet;
                yourPrize += Violet._currentBet;
            }
        }
        else if (circleName == "BetPink")
        {
            print("Pink wins");
            if (Pink._currentBet != 0)
            {
                Money += Pink._currentBet;
                yourPrize += Pink._currentBet;
            }
        }
        else if (circleName == "BetOrange")
        {
            print("Orange wins");
            if (Orange._currentBet != 0)
            {
                Money += Orange._currentBet;
                yourPrize += Orange._currentBet;
            }
        }
        else Debug.LogWarning("some error with winnin circle detection");
        print($"money after spin {Money}");
        print($"your prize is {yourPrize}");
        UpdateMoneyText();
        AllBetsBackToZero.Invoke();
    }
    private void UpdateMoneyText()
    {
        MoneyText.text = $"Your Money: {Money.ToString()}";
    }
}
