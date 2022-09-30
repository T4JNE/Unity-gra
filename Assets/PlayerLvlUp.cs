using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLvlUp : MonoBehaviour
{
    public Text PointsText;
    public Text FirerateCostTxt;
    public Text MagCapCostTxt;
    public Text DamageCostTxt;

    int FirerateCost;
    int MagCapCost;
    int DamageCost;
    int HealCost;

    Weapon playerGun;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        var playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<Player>();
        playerGun = playerObj.GetComponent<Weapon>();

        PointsText.text = "Available points: 0";

        FirerateCost = 5;
        FirerateCostTxt.text = FirerateCost.ToString();

        MagCapCost = 5;
        MagCapCostTxt.text = MagCapCost.ToString();

        DamageCost = 5;
        DamageCostTxt.text = DamageCost.ToString();

        HealCost = 20;
    }

    private void Update()
    {
        PointsChanged();
    }

    void PointsChanged()
    {
        PointsText.text = "Available points: " + Player.Points;
    }

    public void FirerateClick()
    {
        if (FirerateCost > Player.Points)
            return;


        Player.Points -= FirerateCost;
        playerGun.FireRate += 1.2f;
        FirerateCost += 3;
        FirerateCostTxt.text = FirerateCost.ToString();
    }

    public void MagCapClick()
    {
        if (MagCapCost > Player.Points)
            return;

        Player.Points -= MagCapCost;
        playerGun.AmmoCount += 3;
        MagCapCost += 3;
        MagCapCostTxt.text = MagCapCost.ToString();
    }

    public void DamageClick()
    {
        if (DamageCost > Player.Points)
            return;

        Player.Points -= DamageCost;
        playerGun.Damage += 3;
        DamageCost += 3;
        DamageCostTxt.text = DamageCost.ToString();
    }

    public void HealClick()
    {
        if (HealCost > Player.Points)
            return;

        Player.Points -= HealCost;
        player.Health += 25;

    }


}
