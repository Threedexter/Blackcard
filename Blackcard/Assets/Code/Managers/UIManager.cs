using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    public Text life;
    public Text magical_might;
    public Text physical_might;
    public Text stock;
    public Text movement;

    public GameObject EnemyDetails;
    public Text enemyMM;
    public Text enemyPM;

    private Player p;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (p == null)
        {
            p = Gamemanager.instance.player;
        }
        life.text = "Life: " + p.life;
        magical_might.text = "Magical Might: " + p.magicalMight;
        physical_might.text = "Physical Might: " + p.physicalMight;
        stock.text = "Food: " + p.food;
        movement.text = "Movement: " + Gamemanager.instance.moveSteps;
    }

    public void HideEnemyRisks()
    {
        EnemyDetails.SetActive(false);
    }

    public void SetEnemyRisks(Enemy.WinRatio mm, Enemy.WinRatio pm)
    {
        enemyMM.text = mm.ToString().Replace("_"," ");
        enemyPM.text = pm.ToString().Replace("_", " ");
        EnemyDetails.SetActive(true);
    }
}
