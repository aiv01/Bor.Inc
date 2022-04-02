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
    [SerializeField] Text descriptionText;
    [SerializeField] Image leftArrow, rightArrow;
    [HideInInspector] public int currentPage;
    Vector2 currentPos = Vector2.zero;
    GridCell[] cells;
    GridCell selectedCell;
    public GridCell SelectedCell {
        get { return selectedCell; }
        set {
            foreach (GridCell item in cells) {
                item.Selected = false;
            }
            value.Selected = true;
            selectedCell = value;
            descriptionText.text = selectedCell.ConnectedBundle ? selectedCell.ConnectedBundle.description : "";
        }
    }
    [SerializeField] ScriptableStaticClass info;
    [SerializeField] SelectedGridMGR selectedGridMGR;

    void Start()
    {
        
        player = ReInput.players.GetPlayer(0);
        cells = GetComponentsInChildren<GridCell>();
        ChangePage(0);
        
        
        

    }
    public void ChangePage(int pageN) {
        for (int i = 0; i < cells.Length; i++) {
            cells[i].ConnectedBundle = null;
            cells[i].Chosen = false;
        }
        for (int i = cells.Length * pageN; i < info.collectedBundles.Count && i < cells.Length * (pageN +1) ; i++) {
            cells[i - cells.Length * pageN].ConnectedBundle = info.collectedBundles[i];
        }
        foreach (Bundle item in selectedGridMGR.GetBundles()) {
            if (item) {
                for (int i = 0; i < cells.Length; i++) {
                    if (cells[i].ConnectedBundle == item) {
                        cells[i].Chosen = true;
                        break;
                    }
                }
            }
        }
        currentPage = pageN;
        SelectedCell = cells[0];
        currentPos = Vector2.zero;
        leftArrow.gameObject.SetActive(pageN > 0);
        rightArrow.gameObject.SetActive(pageN < info.collectedBundles.Count / cells.Length);
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
            SelectedCell = FindConnectedCell();
            //foreach (GridCell item in cells) {
            //    item.Selected = false;
            //}
            //SelectedCell.Selected = true;
        }
        if (SelectedCell.ConnectedBundle && player.GetButtonDown("Select")) {
            OnChoose();
        }
    }
    public void OnChoose() {
        if (!SelectedCell.Chosen) {
            SelectedCell.Chosen = true;
            selectedGridMGR.PassMod(SelectedCell.ConnectedBundle);
        } else if (SelectedCell.ConnectedBundle == selectedGridMGR.SelectedCell.ConnectedBundle) {
            SelectedCell.Chosen = false;
            selectedGridMGR.PassMod(null);
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
