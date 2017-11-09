using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fieldmanager : MonoBehaviour
{

    public GameObject plane;

    private List<Land> lands = new List<Land>();

	// Use this for initialization
	void Awake ()
    {
        // todo : turn this into plane.Spawn( with parameters about land )
        SpawnPlane(new Vector2(0, 0));
        SpawnPlane(new Vector2(1, 0));
        SpawnPlane(new Vector2(0, 1));
        SpawnPlane(new Vector2(1, 1));
    }

    private void SpawnPlane(Vector2 location)
    {
        Instantiate(plane, new Vector3(location.x, location.y, 0), plane.transform.rotation);
        // todo : add land to list
    }
}
