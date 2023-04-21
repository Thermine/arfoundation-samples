using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Concurrent;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    #region Singleton:Shope
    public static Shop Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    [System.Serializable] public class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased = false;
    }

    
    public List<ShopItem> ShopItemsList;

    [SerializeField]
    private Transform _shopScrollView;

    

    [SerializeField]
    private Animator _noCoinsAnim;

    [SerializeField]
    private GameObject ShopPanel;

    Button _buyButton;

    [SerializeField]
    private GameObject _itemTemplate;

    private GameObject _empty;


    public void Start()
    {
        int len = ShopItemsList.Count;
        for (int i=0; i<len; i++)
        {
            _empty = Instantiate(_itemTemplate, _shopScrollView);
            _empty.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemsList[i].Image;
            _empty.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = ShopItemsList[i].Price.ToString();
            _buyButton = _empty.transform.GetChild(2).GetComponent<Button>();
            if (ShopItemsList[i].IsPurchased)
            {
                DisableBuyButton();
            }
            _buyButton.AddEventListener(i, OnShopItemButtonClicked);
        }

    }
    void OnShopItemButtonClicked(int itemIndex)
    {
        if (Game.Instance.HasEnoughCoins(ShopItemsList[itemIndex].Price))
        {
            Game.Instance.UseCoins(ShopItemsList[itemIndex].Price);
            ShopItemsList[itemIndex].IsPurchased = true;


            _buyButton = _shopScrollView.GetChild(itemIndex).GetChild(2).GetComponent<Button>();
            DisableBuyButton();


            Game.Instance.UpdateAllCoinsUIText();
            Profile.Instance.AddAvatar(ShopItemsList[itemIndex].Image);
        }
        else
        {
            _noCoinsAnim.SetTrigger("NoCoins");
        }
    }

    public void DisableBuyButton()
    {
        _buyButton.interactable = false;
        _buyButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Bought";
    }

    public void OpenShope()
    {
        ShopPanel.SetActive(true);
    }

    public void ClouseShope()
    {
        ShopPanel.SetActive(false);
    }

}


