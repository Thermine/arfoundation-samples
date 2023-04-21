using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    #region Singleton:Profile
    public static Profile Instance;

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

    public class Avatar
    {
        public Sprite _image;
    }

    public List<Avatar> avatarList;

    [SerializeField]
    private GameObject _avatarUITemplate;

    [SerializeField]
    private Transform _avatartScrollView;

    [SerializeField]
    private Color ActiveAvatar;

    [SerializeField]
    private Color DefaultAvatar;

    [SerializeField]
    private Image CurrentAvatar;

    GameObject _empty;
    int newelectedIndex, previousSelectedIndex;

    public void Start()
    {
        GetAvailableAvatars();
        newelectedIndex = previousSelectedIndex = 0;
    }

    public void GetAvailableAvatars()
    {
        for(int i = 0; i < Shop.Instance.ShopItemsList.Count; i++)
        {
            if (Shop.Instance.ShopItemsList[i].IsPurchased)
            {
                AddAvatar(Shop.Instance.ShopItemsList[i].Image);
            }
        }

        SelectAvatar(newelectedIndex);
    }

    public void AddAvatar(Sprite img)
    {
        if (avatarList == null)
            avatarList = new List<Avatar>();
        Avatar av = new Avatar() { _image = img };
        avatarList.Add(av);

        _empty = Instantiate(_avatarUITemplate, _avatartScrollView);
        _empty.transform.GetChild(0).GetComponent<Image>().sprite = av._image;

        _empty.transform.GetComponent<Button>().AddEventListener(avatarList.Count-1, OnAvatarClick);
    }

    public void OnAvatarClick(int AvatarIndex)
    {
        SelectAvatar(AvatarIndex);
    }

    public void SelectAvatar(int avatarIndex)
    {
        previousSelectedIndex = newelectedIndex;
        newelectedIndex = avatarIndex;
        _avatartScrollView.GetChild(previousSelectedIndex).GetComponent<Image>().color = DefaultAvatar;
        _avatartScrollView.GetChild(newelectedIndex).GetComponent<Image>().color = ActiveAvatar;

        CurrentAvatar.sprite = avatarList[newelectedIndex]._image;
    }
}
