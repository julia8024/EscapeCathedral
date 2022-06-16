using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class antientDoc : MonoBehaviour
{
    public GameObject antientDoc_ui;
    public GameObject player;
    public Camera camera;

    public void OnMouseDown() {
        if (ObjectClicker.uiIsActived == false) {
            Debug.Log("click antient document");
            antientDoc_ui.SetActive(true);
            player.GetComponent<PlayerMovement>().enabled = false;
            camera.GetComponent<MouseLook>().enabled = false;
            ObjectClicker.uiIsActived = true;
        }
    }

    public void CloseAntientDoc() {
        Debug.Log("close antient Doc ui");
        antientDoc_ui.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        camera.GetComponent<MouseLook>().enabled = true;
        ObjectClicker.uiIsActived = false;
    }
}
