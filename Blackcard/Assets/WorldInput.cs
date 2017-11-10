using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInput : MonoBehaviour
{

    public GameObject HighlightTile;
    private GameObject currentHighlight;
    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        if (HighlightTile != null)
        {
            currentHighlight = Instantiate(HighlightTile, Vector3.zero, HighlightTile.transform.rotation) as GameObject;
            currentHighlight.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 planePosition = GetMouseLocationAsPlanePosition();

            if (!Fieldmanager.instance.IsFree(planePosition))
            {
                Land tomoveto = null;

                Fieldmanager.instance.lands.TryGetValue(planePosition, out tomoveto);

                if (tomoveto != null)
                {
                    Gamemanager.instance.player.MovePlayer(tomoveto);
                }
            }
            else
            {
                Gamemanager.instance.PlaceLand(planePosition);
            }
        }

        if (currentHighlight != null)
            Highlight();
    }

    public void Highlight()
    {
        Vector2 currentMousePos = GetMouseLocationAsPlanePosition();
        if (Fieldmanager.instance.HasLandNear(currentMousePos) && Gamemanager.instance.landsToPlace > 0)
        {
            currentHighlight.transform.position = new Vector3(currentMousePos.x, currentMousePos.y, 0);
            currentHighlight.SetActive(true);
        }
        else
        {
            currentHighlight.SetActive(false);
        }
    }

    public Vector2 GetMouseLocationAsPlanePosition()
    {
        Vector3 mouseLoc = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(Mathf.Round(mouseLoc.x), Mathf.Round(mouseLoc.y));
    }
}
