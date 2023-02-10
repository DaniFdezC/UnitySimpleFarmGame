using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotManager : MonoBehaviour
{
    bool isPlanted = false;

    SpriteRenderer plant;
    BoxCollider2D plantCollider;

    int plantStage = 0;
    float timer;

    public Color availableColor = Color.green;
    public Color unavailableColor = Color.red;

    SpriteRenderer plot;

    public PlantObject selectedPlant;
    FarmManager farmM;

    // Start is called before the first frame update
    void Start()
    {
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();

        plantCollider = transform.GetChild(0).GetComponent<BoxCollider2D>();

        farmM = transform.parent.GetComponent<FarmManager>(); //the farm manager is set on the parent

        plot = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlanted) {
            timer -= Time.deltaTime;

            if (timer < 0 && plantStage < selectedPlant.plantStages.Length-1) {
                timer = selectedPlant.timeBetweenStages;
                plantStage++;
                UpdatePlant();
            }
        }
    }

    private void OnMouseDown() {

        if (isPlanted) {
            if (plantStage == selectedPlant.plantStages.Length- 1 && !farmM.isPlanting) {
                Harvest();
            }
            
        } else if (farmM.isPlanting && farmM.selectPlant.plant.buyPrice <= farmM.money){
            Plant(farmM.selectPlant.plant);
        }
    }

    private void OnMouseOver() {
        if (farmM.isPlanting) {
            if (isPlanted || farmM.selectPlant.plant.buyPrice > farmM.money) {
                plot.color = unavailableColor;
            } else {
                plot.color = availableColor;
            }
        }
    }

    private void OnMouseExit() {
        plot.color = Color.white;
    }

    void Harvest() {
        isPlanted = false;
        plant.gameObject.SetActive(false);

        farmM.Transaction(selectedPlant.sellPrice);
    }

    void Plant(PlantObject newPlant) {
        selectedPlant = newPlant;

        isPlanted = true;

        farmM.Transaction(-selectedPlant.buyPrice);

        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timeBetweenStages;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant() {
        plant.sprite = selectedPlant.plantStages[plantStage];

        plantCollider.size = plant.sprite.bounds.size;

        plantCollider.offset = new Vector2(0, plant.bounds.size.y/2);
    }
}
