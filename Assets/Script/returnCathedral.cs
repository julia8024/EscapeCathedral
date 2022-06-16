using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnCathedral : MonoBehaviour
{
    [SerializeField]
    // public GameObject underground_door;
    public Camera camera;
    public Camera camera_under;
    public GameObject player;
    public GameObject player_under;

    public void OnMouseDown() {
        player_under.SetActive(false);
        camera_under.enabled = false;
        player.SetActive(true);
        camera.enabled = true;

        Debug.Log("return cathedral");
    }
}
