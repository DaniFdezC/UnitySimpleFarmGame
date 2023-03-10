using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{
    public PlantItem selectPlant;
    public bool isPlanting = false;
    public int money = 100;
    public Text moneyText;

    public Color buyColor = Color.green;
    public Color cancelColor = Color.red;


    void Start()
    {
        moneyText.text = "$" + money;
    }


    public void SelectPlant(PlantItem newPlant) {

        if (selectPlant == newPlant) {

            selectPlant.btnImage.color = buyColor;
            selectPlant.btnText.text = "Buy";

            selectPlant = null;
            isPlanting = false;

        } else {

            if (selectPlant != null) {
                selectPlant.btnImage.color = buyColor;
                selectPlant.btnText.text = "Buy";
            }

            selectPlant = newPlant;
            selectPlant.btnImage.color = cancelColor;
            selectPlant.btnText.text = "Cancel";
            isPlanting = true;

        }
    }

    public void Transaction(int value) {
        money += value;
        moneyText.text = "$" + money;
    }
}
