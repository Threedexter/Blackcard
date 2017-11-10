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

    public int landsToPlace = 0;
    public Feel feel = Feel.Grassland;

    // Use this for initialization
    void Start()
    {
        moveSteps = maxMoveSteps;
        Vector2 startPos = Fieldmanager.instance.lands.PickRandom().Key;
        StartPosition = new Vector3(startPos.x, startPos.y, -1);
        instance = this;
        PlayerInstance = Instantiate(PlayerPrefab, StartPosition, PlayerPrefab.transform.rotation);
        player = new Player(PlayerInstance);
        Cardmanager.Instance.DrawCards(player, 5);
    }

    public void ActivateCard(Card card)
    {
        playedCards++;
    }

    public void EndTurn()
    {
        playedCards = 0;
        moveSteps = maxMoveSteps;
        Cardmanager.Instance.DrawCards(player);
        Cardmanager.Instance.CheckEndTurnCards(player);
    }

    public void PlayerMoved(Land land)
    {
        moveSteps -= land.feel.movement_cost;
    }

    public void PlaceLand(Vector2 planePosition)
    {
        if (landsToPlace > 0 && Fieldmanager.instance.HasLandNear(planePosition))
        {
            Fieldmanager.instance.SpawnPlane(planePosition, feel);
            landsToPlace--;
        }
    }

    public void AddLandsToPlace(int amount)
    {
        landsToPlace += amount;
    }
}
