using Assets.Code.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager instance;

    public static GameObject PlayerInstance;
    public Player player;
    public GameObject PlayerPrefab;
    public Button endTurnButton;
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
        StartPosition = new Vector3(startPos.x, startPos.y);
        instance = this;
        PlayerInstance = Instantiate(PlayerPrefab, StartPosition, Quaternion.identity);
        player = new Player(PlayerInstance);
        Cardmanager.Instance.DrawCards(player, 5);
        endTurnButton.GetComponent<Image>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivateCard(Card card)
    {
        if (playedCards >= maxPlayedCards) return;
        if (card.ActivateEffect())
        {
            player.hand.cards.Remove(card);
        }
        else if (card.feel != null && Gamemanager.instance.landsToPlace <= 0)
        {
            Gamemanager.instance.landsToPlace = card.lands;
            Gamemanager.instance.feel = card.feel;
            Gamemanager.instance.CheckEndTurn();
            player.hand.cards.Remove(card);
        }

        playedCards++;
        CheckEndTurn();
    }

    public void EndTurn()
    {
        if (landsToPlace <= 0)
        {
            playedCards = 0;
            moveSteps = maxMoveSteps;
            Cardmanager.Instance.DrawCards(player);
            Cardmanager.Instance.CheckEndTurnCards(player);
        }
    }

    public void PlayerMoved(Land land)
    {
        moveSteps -= land.feel.movement_cost;
        CheckEndTurn();
    }

    public void PlaceLand(Vector2 planePosition)
    {
        if (landsToPlace > 0 && Fieldmanager.instance.HasLandNear(planePosition))
        {
            Fieldmanager.instance.SpawnPlane(planePosition, feel);
            landsToPlace--;
            CheckEndTurn();
        }
    }

    public void AddLandsToPlace(int amount)
    {
        landsToPlace += amount;
    }

    public void CheckEndTurn()
    {
        if (landsToPlace <= 0) endTurnButton.GetComponent<Image>().color = Color.yellow;
        if (landsToPlace > 0) endTurnButton.GetComponent<Image>().color = Color.red;
        if (playedCards >= maxPlayedCards && landsToPlace <= 0 && !player.CanMove(moveSteps)) endTurnButton.GetComponent<Image>().color = Color.green;
    }
}

