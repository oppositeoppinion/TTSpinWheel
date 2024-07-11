using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0168 // variable declared but not used.
#pragma warning disable 0219 // variable assigned but not used.
#pragma warning disable 0414 // private field assigned but not used.


public class ButtonsManager : MonoBehaviour
{
    public static ButtonsManager Instance;
    public ChoosedButton _choosedButton { get; private set; }

    [SerializeField] private Button _buttonDelete;
    [SerializeField] private Button _buttonBet1;
    [SerializeField] private Button _buttonBet2;
    [SerializeField] private Button _buttonBet3;
    [SerializeField] private Button _buttonBet4;
    [SerializeField] private GameObject _buttonShower;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }
    private void Start()
    {
        _choosedButton = ChoosedButton.Delete;
        _buttonDelete.onClick.AddListener(() => ButtonDeleteClicked());
        _buttonBet1.onClick.AddListener(() => ButtonBet1Clicked());
        _buttonBet2.onClick.AddListener(() => ButtonBet2Clicked());
        _buttonBet3.onClick.AddListener(() => ButtonBet3Clicked());
        _buttonBet4.onClick.AddListener(() => ButtonBet4Clicked());
    }
    private void ButtonDeleteClicked()
    {
        _choosedButton = ChoosedButton.Delete;
        _buttonShower.transform.position = _buttonDelete.transform.position;
    }
    private void ButtonBet1Clicked()
    {
        _choosedButton = ChoosedButton.Bet1;
        _buttonShower.transform.position = _buttonBet1.transform.position;
    }
    private void ButtonBet2Clicked()
    {
        _choosedButton = ChoosedButton.Bet2;
        _buttonShower.transform.position = _buttonBet2.transform.position;
    }
    private void ButtonBet3Clicked()
    {
        _choosedButton = ChoosedButton.Bet3;
        _buttonShower.transform.position = _buttonBet3.transform.position;
    }
    private void ButtonBet4Clicked()
    {
        _choosedButton = ChoosedButton.Bet4;
        _buttonShower.transform.position = _buttonBet4.transform.position;
    }

}
public enum ChoosedButton
{
    Delete, Bet1, Bet2, Bet3, Bet4
}
