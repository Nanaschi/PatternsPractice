using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class TextSystem : MonoBehaviour
{
    private HeroBuilder _heroBuilder;
    [SerializeField] private HeroModel _heroModel;
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _heroBuilder = new HeroBuilder(_heroModel, _textMeshProUGUI);
    }

    private void Start()
    {
        GenerateText();
    }

    private void GenerateText()
    {
        _heroBuilder.PrintName().PrintLevel().PrintEvileness().PrintName();
    }
}

[Serializable]
public class HeroModel
{
    public string Name;
    public int Level;
    public bool IsEvil;
}

public class HeroBuilder
{
    private HeroModel _heroModel = new HeroModel();
    private StringBuilder _stringBuilder = new StringBuilder();
    private List<string> _text = new List<string>();
    private TextMeshProUGUI _textMeshProUGUI;

    public HeroBuilder(HeroModel heroModel, TextMeshProUGUI textMeshProUGUI)
    {
        _textMeshProUGUI = textMeshProUGUI;
        _heroModel = heroModel;
    }


    public HeroBuilder PrintName()
    {
        string nameText = "The glorious name of the hero is ";
        _textMeshProUGUI.text = _stringBuilder.Append(nameText).Append(_heroModel.Name).Append(". ")
            .ToString();
        return this;
    }

    public HeroBuilder PrintLevel()
    {
        string initialText = "The level of the hero is ";
        _textMeshProUGUI.text = _stringBuilder.Append(initialText).Append(_heroModel.Level)
            .Append(". ").ToString();
        return this;
    }

    public HeroBuilder PrintEvileness()
    {
        string initialText = "It is ";
        string endingText = " that this hero is Evil. ";
        _textMeshProUGUI.text = _stringBuilder.Append(initialText).Append(_heroModel.IsEvil)
            .Append(endingText).ToString();
        return this;
    }
}