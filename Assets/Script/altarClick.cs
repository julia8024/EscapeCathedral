using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altarClick : MonoBehaviour
{
    public GameObject altar_ui;
    public GameObject altarBook_ui;
    public GameObject player;
    public Camera camera;

    public void OnMouseDown() {
        if (QuestAltar.AltarResult == false && ObjectClicker.uiIsActived == false) {
            Debug.Log("click altar");
            altar_ui.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            camera.GetComponent<MouseLook>().enabled = false;
            ObjectClicker.uiIsActived = true;
        } else if (altar_ui.activeSelf == true) {
            Debug.Log("already active");
        } else {
            Debug.Log("Success altar quest");
        }
    }
}
