using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BetField : MonoBehaviour
{
    [SerializeField] public int _currentBet;
    private TextMeshPro _text;
    private IBetsAndScores _iScores;
    private void OnValidate()
    {
        _text = transform.Find("Text").GetComponent<TextMeshPro>();
    }
    private void Start()
    {
        _currentBet = 0;
        _text.text = "";
        _iScores = BetsAndScores.Instance;
        _iScores.AllBetsBackToZero.AddListener(BetsToZero);
    }
    private void BetsToZero()
    {
        _currentBet = 0;
        ShowCurrentBet();
    }
    private void ShowCurrentBet()
    {
        _text.text = _currentBet.ToString();
        if (_currentBet == 0) _text.text = "";
    }
    private void OnMouseDown()
    {
        switch (ButtonsManager.Instance._choosedButton)
        {
            case ChoosedButton.Delete:
                _iScores.IncreaseMoney(_currentBet);
                _currentBet = 0;
                ShowCurrentBet();
                break;

            case ChoosedButton.Bet1:
                if (_iScores.Money - _iScores.Button1BetValue >= 0)
                {
                    _currentBet = _currentBet + _iScores.Button1BetValue;
                    _iScores.DecreseMoney(_iScores.Button1BetValue);
                    ShowCurrentBet();
                }
                else Debug.LogWarning("Need more Money )");
                break;
            case ChoosedButton.Bet2:
                if (_iScores.Money - _iScores.Button2BetValue >= 0)
                {
                    _currentBet = _currentBet + _iScores.Button2BetValue;
                    _iScores.DecreseMoney(_iScores.Button2BetValue);
                    ShowCurrentBet();
                }
                else Debug.LogWarning("Need more Money )");
                break;
            case ChoosedButton.Bet3:
                if (_iScores.Money - _iScores.Button3BetValue >= 0)
                {
                    _currentBet = _currentBet + _iScores.Button3BetValue;
                    _iScores.DecreseMoney(_iScores.Button3BetValue);
                    ShowCurrentBet();
                }
                else Debug.LogWarning("Need more Money )");
                break;
            case ChoosedButton.Bet4:
                if (_iScores.Money - _iScores.Button4BetValue >= 0)
                {
                    _currentBet = _currentBet + _iScores.Button4BetValue;
                    _iScores.DecreseMoney(_iScores.Button4BetValue);
                    ShowCurrentBet();
                }
                else Debug.LogWarning("Need more Money )");
                break;
        }

    }
}
