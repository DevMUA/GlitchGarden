using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender = null;
   

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(GetSquareClicked());
     
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        newY += 0.2f;
        return new Vector2(newX, newY);

    }

    private void SpawnDefender(Vector2 coordinates)
    {
        Defender newDefender = Instantiate(defender, coordinates, Quaternion.identity) as Defender;
    }

    private void AttemptToPlaceDefenderAt(Vector2 grisPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(grisPos);
            StarDisplay.SpendStars(defenderCost);
        }
    }
}
