using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionsBar : MonoBehaviour
{
    public static ConditionsBar instance;

    public enum BarType { hunger, cleanness, happiness } // list of bar conditions that we can switch
    public BarType barType;                              // makes this list visible in inspector

    [Header("UI objects")]
    [Tooltip("Bar that you need to control")] public Slider ConditionBar; // UI slider for bar

    [Space(5f)]

    [Header("Variables")]
    [Tooltip("The value of bar"), Range(0f, 100f)] public float BarValue; // bar value, operator variable

    private float maxValue = 100f; // max value of bar, using to fill bar when start game

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        BarValue = maxValue; // when start game condition bar will take adjusted value
    }

    public void Update()
    {
        if(BarValue > 0)
        {
            BarControl(barType);
            ConditionBar.value = BarValue;
        }
        else if(BarValue <= 0)
        {
            PetCondition.instance.PetDeath();
        }
    }


    public void BarControl(BarType barType)
    {
        ConditionBar.value = BarValue;
        if (barType == BarType.hunger) // hunger state
        {
            BarValue -= 1f*Time.deltaTime; // 0.1
        }
        else if(barType == BarType.cleanness) // cleanness state
        {
            BarValue -= 1f*Time.deltaTime; // 0.2
        }
        else if(barType == BarType.happiness) // happiness state
        {
            BarValue -= 1f* Time.deltaTime; // 0.25
        }
        ConditionBar.value = BarValue;
    }

    public void ChangeBarValue()
    {
        BarValue += 1f;
    }

    public void ChangeCleannessBar()
    {
        BarValue += 25f;
    }
    public void ChangeHappinessBar()
    {
        BarValue += 30f;
    }
    public void ChangeHungerBar()
    {
        BarValue += 15f;
    }
}
