using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterUnderGround : MonoBehaviour
{

    [SerializeField]
    // public GameObject cathedral_door;
    public Camera camera;
    public Camera camera_under;
    public GameObject player;
    public GameObject player_under;
    // Transform target;  // 위치 정보

    public void OnMouseDown() {
        player.SetActive(false);
        camera.enabled = false;
        player_under.SetActive(true);
        camera_under.enabled = true;

        Debug.Log("click door");
    }
}
