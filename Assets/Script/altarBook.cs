using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altarBook : MonoBehaviour
{
    public GameObject altarBook_ui;
    public GameObject altar_ui;
    public GameObject player;
    public Camera camera;

    public void OnMouseDown() {
        if (ObjectClicker.uiIsActived == false) {
            Debug.Log("click altar book");
            altarBook_ui.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            camera.GetComponent<MouseLook>().enabled = false;
            ObjectClicker.uiIsActived = true;
        }
    }

    public void CloseAltarBook() {
        Debug.Log("close altar Book ui");
        altarBook_ui.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        camera.GetComponent<MouseLook>().enabled = true;
        ObjectClicker.uiIsActived = false;
    }
}
