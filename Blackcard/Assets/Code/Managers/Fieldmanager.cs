using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fieldmanager : MonoBehaviour
{
    public static Fieldmanager instance;

    public Land plane;
    public GameObject wall;

    private Dictionary<Vector2, Land> lands = new Dictionary<Vector2, Land>();


	// Use this for initialization
	void Awake ()
    {
        instance = this;
        SpawnPlane(new Vector2(0, 0), Feel.Start);
        SpawnPlane(new Vector2(1, 0), Feel.Start);
        SpawnPlane(new Vector2(0, 1), Feel.Start);
        SpawnPlane(new Vector2(1, 1), Feel.Start);
    }

    public void SpawnPlane(Vector2 location, Feel feel)
    {
        Land x = Instantiate(plane, new Vector3(location.x, location.y, 0), plane.transform.rotation) as Land;
        x.Spawn(location, feel);
        lands.Add(location, x);
    }

    public bool IsFree(Vector2 location)
    {
        return lands.ContainsKey(location);
    }
}
