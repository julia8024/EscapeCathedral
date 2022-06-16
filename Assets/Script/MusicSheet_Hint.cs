using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSheet_Hint : MonoBehaviour
{
    public GameObject musicsheet_ui;
    public GameObject piano_ui;
    public GameObject player;
    public Camera camera;

    public void OnMouseDown() {
        if (ObjectClicker.uiIsActived == false) {
            Debug.Log("click Music Sheet");
            musicsheet_ui.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            camera.GetComponent<MouseLook>().enabled = false;
            ObjectClicker.uiIsActived = true;
        }
    }

    public void CloseMusicSheet() {
        Debug.Log("close musicsheet ui");
        musicsheet_ui.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        camera.GetComponent<MouseLook>().enabled = true;
        ObjectClicker.uiIsActived = false;
    }
}
