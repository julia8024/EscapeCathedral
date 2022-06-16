using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pianoClick : MonoBehaviour
{
    public GameObject piano_ui;
    public GameObject musicsheet_ui;
    public GameObject player;
    public Camera camera;

    public void OnMouseDown() {
        if (QuestPiano.PianoResult == false && ObjectClicker.uiIsActived == false) {
            Debug.Log("click piano");
            piano_ui.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            camera.GetComponent<MouseLook>().enabled = false;
            ObjectClicker.uiIsActived = true;
        } else if (piano_ui.activeSelf == true) {
            Debug.Log("piano ui is already active");
        } else {
            Debug.Log("Success piano quest");
        }
    }
}

