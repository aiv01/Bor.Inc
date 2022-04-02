using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using UnityEngine.EventSystems;

public class ChangePage : MonoBehaviour, IPointerClickHandler {
    private Player player;

    [SerializeField] string input;
    [SerializeField] int changeAmount;
    [SerializeField] VenderMgr venderMgr;
    private void Awake() {
        player = ReInput.players.GetPlayer(0);
    }
    void Update()
    {
        if (player.GetButtonDown(input)) Change();
    }
    public void OnPointerClick(PointerEventData eventData) {
        Change();
    }
    private void Change() {
        venderMgr.ChangePage(venderMgr.currentPage + changeAmount);
    }
}
