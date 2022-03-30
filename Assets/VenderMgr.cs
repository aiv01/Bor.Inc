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
    Vector2 currentPos = Vector2.zero;
    GridCell[] cells;
    GridCell selectedCell;
    void Awake()
    {
        player = ReInput.players.GetPlayer(0);
        Debug.Log("Test");
        cells = GetComponentsInChildren<GridCell>();
        cells[0].Selected = true;
        selectedCell = cells[0];
        //List<Image> clist = new List<Image>();
        //for (int i = 0; i < c.Length; i++) {
        //    clist.Add(c[i].GetComponent<Image>());
        //}
        //cells = clist.ToArray();
        //cells[0].color = selectedColor;

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
}
