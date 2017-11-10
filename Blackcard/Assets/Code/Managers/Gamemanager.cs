using Assets.Code.Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour {

    public static Gamemanager instance;

    public static GameObject PlayerInstance;
    public Player player;
    public GameObject PlayerPrefab;
    Vector3 StartPosition;

	// Use this for initialization
	void Start ()
    {
        player = new Player();
        Vector2 startPos = Fieldmanager.instance.lands.PickRandom().Key;
        StartPosition = new Vector3(startPos.x, startPos.y);
        instance = this;
        PlayerInstance = Instantiate(PlayerPrefab,StartPosition,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
