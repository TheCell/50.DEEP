using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalShipStatus : MonoBehaviour
{
    [SerializeField] private ShipMaxValues shipMaxValues;
    [SerializeField] private Text shipHPText;
    [SerializeField] private Text shipPowerText;
    [SerializeField] private Text shipRepairMaterialsText;
    [SerializeField] private Text shipWaterText;

    private int shipHP;
    private int currentScore;
    private float tickTime = 1f; // 1 tick each second. 0.5 means 2 ticks per second
    private float lastTickTime;

    private void Start()
    {
        shipHP = shipMaxValues.maxShipHP;
        lastTickTime = Time.time;
    }

    private void Update()
    {
        if (lastTickTime + tickTime < Time.time)
        {
            UpdateValues();
            UpdateHighscore();
            lastTickTime = Time.time;
            //Debug.Log("Current shipHP: " + shipHP);
            CheckLoseCondition();
        }
    }

    private void CheckLoseCondition()
    {
        if (shipHP < 1)
        {
            Debug.Log("You lost :( your Highscore is " + currentScore);
            LoseScreen.highscore = currentScore;
            SceneManager.LoadScene(1);
        }
    }

    private void UpdateValues()
    {
        int damageFromRepairables = GetShipDamageFromRepairableObjects();

        shipHP -= damageFromRepairables;
        UpdateShipUI();
    }

    private void UpdateHighscore()
    {
        if (shipHP > 0)
        {
            currentScore++;
        }
    }

    private int GetShipDamageFromRepairableObjects()
    {
        int allDamage = 0;
        ObjectRepairLogic[] allRepairables = FindObjectsOfType<ObjectRepairLogic>();
        //Debug.Log("found " + allRepairables .Length + " repairable Objects");
        for (int i = 0; i < allRepairables.Length; i++)
        {
            if (allRepairables[i].DoesDamage())
            {
                allDamage++;
            }
        }

        return allDamage;
    }

    private void UpdateShipUI()
    {
        if (shipHPText != null)
        {
            shipHPText.text = "ShipHP: " + shipHP;
        }
        if (shipPowerText != null)
        {
            shipPowerText.text = "Ship Power: " + DrillController.dr.Antrieb;
        }
        if (shipRepairMaterialsText != null)
        {
            shipRepairMaterialsText.text = "Ship Materials: " + DrillController.dr.Baumaterial;
        }
        if (shipWaterText != null)
        {
            shipWaterText.text = "Ship Water: " + DrillController.dr.Wasser;
        }
    }
}
