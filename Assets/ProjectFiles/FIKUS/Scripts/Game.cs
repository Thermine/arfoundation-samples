using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    #region Singleton:Game
    public static Game Instance;

    public void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion
    public int _coins;

    [SerializeField]
    private TextMeshProUGUI[] _allCoinsUIText;

    public void Start()
    {
        UpdateAllCoinsUIText();
    }

    public void UseCoins(int amount)
    {
        _coins -= amount;
    }

    public bool HasEnoughCoins(int amount)
    {
        return (_coins >= amount);
    }

    public void UpdateAllCoinsUIText()
    {
        for (int i = 0; i<_allCoinsUIText.Length; i++)
        {
            _allCoinsUIText[i].text = _coins.ToString();
        }
    }


}
