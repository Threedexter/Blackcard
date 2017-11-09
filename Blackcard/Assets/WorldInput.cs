using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 planePosition = new Vector2(Mathf.Round(mouseLoc.x), Mathf.Round(mouseLoc.y));
            if(Fieldmanager.instance.HasLandNear(planePosition)) Fieldmanager.instance.SpawnPlane(planePosition, Feel.RandomFeel());
        }
	}
}
