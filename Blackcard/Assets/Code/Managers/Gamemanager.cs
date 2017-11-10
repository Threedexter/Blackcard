using Assets.Code.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{

    public static Gamemanager instance;

    public static GameObject PlayerInstance;
    public Player player;
    public GameObject PlayerPrefab;
    Vector3 StartPosition;

    private const int maxPlayedCards = 2;
    private const int maxMoveSteps = 4;

    private int playedCards;
    public int moveSteps;

    // Use this for initialization
    void Start()
    {
        moveSteps = maxMoveSteps;
        Vector2 startPos = Fieldmanager.instance.lands.PickRandom().Key;
        StartPosition = new Vector3(startPos.x, startPos.y);
        instance = this;
        PlayerInstance = Instantiate(PlayerPrefab, StartPosition, Quaternion.identity);
        player = new Player(PlayerInstance);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateCard(Card card)
    {
        playedCards++;
    }

    public void EndTurn()
    {
        playedCards = 0;
        moveSteps = maxMoveSteps;
    }

    public void PlayerMoved(Land land)
    {
        moveSteps -= land.feel.movement_cost;
    }
}
