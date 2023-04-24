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

    // kostil zone

    [Tooltip("Evolution Forms")]
    [SerializeField] private GameObject evo1;
    [SerializeField] private GameObject evo2;
    [SerializeField] private GameObject evo3g;
    [SerializeField] private GameObject evo3b;
    [SerializeField] private GameObject evo3r;

    //end
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
        if(_LVL == 5)
        {
            evo2.SetActive(true);
            evo1.SetActive(false);
            evo3r.SetActive(false);
            evo3g.SetActive(false);
            evo3b.SetActive(false);
        }
        else if (_LVL == 10)
        {
            evo2.SetActive(false);
            evo1.SetActive(false);
            evo3r.SetActive(true);
            evo3g.SetActive(false);
            evo3b.SetActive(false);
        }
        else if (_LVL == 15)
        {
            evo2.SetActive(false);
            evo1.SetActive(false);
            evo3r.SetActive(false);
            evo3g.SetActive(true);
            evo3b.SetActive(false);
        }
        else if (_LVL == 20)
        {
            evo2.SetActive(false);
            evo1.SetActive(false);
            evo3r.SetActive(false);
            evo3g.SetActive(false);
            evo3b.SetActive(true);
        }
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
        _score += 100;
        _sliderXP.value += 0.1f;
        UpdateScore();

    }

    public void RestartLevel()
    {
        _sliderXP.value = 0;
        _goingLevel = true;
    }

    
}
