using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [Tooltip("TextScore")]
    [SerializeField]
    private TextMeshProUGUI _textScore;

    [Tooltip("TextLvl")]
    [SerializeField]
    private TextMeshProUGUI _textLVL;

    [Tooltip("Slider")]
    [SerializeField]
    private Slider _sliderXP;

    private float _score;
    private int _LVL;

    private bool _goingLevel = true;


    public void UpdateScore()
    {
        _textScore.text = "XP " + _score;
        UpdateLevel();
    }

    public void UpdateLVL()
    {
        AddLVL();
        _textLVL.text = "LVL " + _LVL;
        
    }

    public void AddLVL()
    {
        _LVL += 1;
    }

    public void UpdateLevel()
    {
        if (_score % 100 == 0)
        {
            _goingLevel = false;
            UpdateLVL();
            RestartLevel();
        }
    }
 
    public void AddScore()
    {
        if (!_goingLevel) return;
        _score += 10;
        _sliderXP.value += 0.1f;
        UpdateScore();

    }

    public void RestartLevel()
    {
        _sliderXP.value = 0;
        _goingLevel = true;
    }

    
}
