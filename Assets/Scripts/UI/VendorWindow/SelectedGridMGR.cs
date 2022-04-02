using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class SelectedGridMGR : MonoBehaviour {
    private Player player;
    GridCell[] cells;
    [SerializeField] int nSelectedMods = 3;
    [SerializeField] VenderMgr venderMgr;
    GridCell selectedCell;
    int index = 0;
    public GridCell SelectedCell {
        get { return selectedCell; }
        set {
            foreach (GridCell item in cells) {
                item.Selected = false;
            }
            value.Selected = true;
            selectedCell = value;
        }
    }


    void Awake() {

        player = ReInput.players.GetPlayer(0);
        cells = GetComponentsInChildren<GridCell>();
        foreach (GridCell item in cells) {
            item.Selected = false;
        }
        cells[0].Selected = true;
        selectedCell = cells[0];

    }
    private void Update() {
        int oldIndex = index;
        if (player.GetButtonDown("RT")) {
            index++;
            CorrectPos();
        }
        if (player.GetButtonDown("LT")) {
            index--;
            CorrectPos();
        }
        if (index != oldIndex) {
            selectedCell = cells[index];
            foreach (GridCell item in cells) {
                item.Selected = false;
            }
            selectedCell.Selected = true;
        }
    }
    public void CorrectPos() {
        if (index < 0) index = nSelectedMods - 1;
        if (index > nSelectedMods - 1) index = 0;
    }
    public void PassMod(Bundle bundle) {
        if (!bundle) {
            selectedCell.ConnectedBundle = bundle;
        } else if(!selectedCell.ConnectedBundle)
            selectedCell.ConnectedBundle = bundle;
        else {
            venderMgr.ReactivateBundle(selectedCell.ConnectedBundle);
            selectedCell.ConnectedBundle = bundle;
        }
    }
    public Bundle[] GetBundles() {
        return new Bundle[] { cells[0].ConnectedBundle, cells[1].ConnectedBundle, cells[2].ConnectedBundle };
    }
}
