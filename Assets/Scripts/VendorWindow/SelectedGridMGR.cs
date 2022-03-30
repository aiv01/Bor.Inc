using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class SelectedGridMGR : MonoBehaviour {
    private Player player;
    Image[] cells;
    [SerializeField] Color selectedColor;
    [SerializeField] Color notSelectedColor;
    Image selectedCell;

    void Awake() {

        GridCell[] c = GetComponentsInChildren<GridCell>(); //TODO chiedi un modo migliore
        List<Image> clist = new List<Image>();
        for (int i = 0; i < c.Length; i++) {
            clist.Add(c[i].GetComponent<Image>());
        }
        cells = clist.ToArray();
        cells[0].color = selectedColor;
        selectedCell = cells[0];
        player = ReInput.players.GetPlayer(0);

    }
}
