using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;
public class VenderMgr : MonoBehaviour
{
    private Player player;
    [SerializeField] int cellsPerRow = 8;
    [SerializeField] int cellsPerColum = 3;
    [SerializeField] Sprite noBundle;
    Vector2 currentPos = Vector2.zero;
    GridCell[] cells;
    GridCell selectedCell;
    [SerializeField] ScriptableStaticClass info;
    [SerializeField] SelectedGridMGR selectedGridMGR;

    void Awake()
    {
        
        player = ReInput.players.GetPlayer(0);
        cells = GetComponentsInChildren<GridCell>();
        foreach (GridCell item in cells) {
            item.Selected = false;
        }
        for (int i = 0; i < cells.Length; i++) {
            if(i < info.collectedBundles.Count)
                cells[i].ConnectedBundle = info.collectedBundles[i];

        }
        cells[0].Selected = true;
        selectedCell = cells[0];

    }
    private void Update() {
        Vector2 oldPos = currentPos;
        if (player.GetButtonDown("Dpad Right")) {
            currentPos += Vector2.right;
            CorrectPos(currentPos);
        }
        if (player.GetButtonDown("Dpad Left")) {
            currentPos -= Vector2.right;
            CorrectPos(currentPos);
        }
        if (player.GetButtonDown("Dpad Up")) {
            currentPos -= Vector2.up;
            CorrectPos(currentPos);
        }
        if (player.GetButtonDown("Dpad Down")) {
            currentPos += Vector2.up;
            CorrectPos(currentPos);
        }
        if(currentPos != oldPos) {
            selectedCell = FindConnectedCell();
            foreach (GridCell item in cells) {
                item.Selected = false;
            }
            selectedCell.Selected = true;
        }
        if (selectedCell.ConnectedBundle && player.GetButtonDown("Select") && !selectedCell.Chosen) {
            selectedCell.Chosen = true;
            selectedGridMGR.PassMod(selectedCell.ConnectedBundle);
        }
    }
    public void CorrectPos(Vector2 pos) {
        if (pos.x < 0) currentPos.x = cellsPerRow - 1;
        if (pos.x > cellsPerRow - 1) currentPos.x = 0;
        if (pos.y < 0) currentPos.y = cellsPerColum - 1;
        if (pos.y > cellsPerColum - 1) currentPos.y = 0;
    }
    public GridCell FindConnectedCell() {
        return cells[(int)currentPos.x + (int)currentPos.y * cellsPerRow];
    }
    public void ReactivateBundle(Bundle bundle) {
        foreach (GridCell item in cells) {
            if(item.ConnectedBundle == bundle) {
                item.Chosen = false;
            }
        }
    }
}
