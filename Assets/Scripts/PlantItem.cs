using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public Text nameTxt;
    public Text priceTxt;
    public Image icon;

    public Image btnImage;
    public Text btnText;

    FarmManager farmM;

    // Start is called before the first frame update
    void Start()
    {
        farmM = FindObjectOfType<FarmManager>(); // there is only 1 farm Manager so it wouldnt be a problem

        InitializeUI();
        
    }

    public void BuyPlant() {
        farmM.SelectPlant(this);
    }

    void InitializeUI() {
        nameTxt.text = plant.name;
        priceTxt.text = "$" + plant.buyPrice;
        icon.sprite = plant.icon;
    }

}
