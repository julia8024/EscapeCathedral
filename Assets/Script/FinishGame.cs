using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public GameObject player;
    public Camera camera;
    public GameObject ending;
    public Transform camera_t;
    public Transform target;
    bool isClicked = false;

    void Update()
    {
        if (isClicked)
        {
            camera_t.position = Vector3.Lerp(camera_t.position, target.position, 0.01f);
        }
    }
    // public void SetClick()
    // {
    //     isClicked = true;
    //     Camera.rotation = Quaternion.Euler(30, 0, 0);
    //     Button.SetActive(false);
    // }
    public void OnMouseDown() {
        isClicked = true;
        camera_t.rotation = Quaternion.Euler(0, 90, 0);
        player.GetComponent<PlayerMovement>().enabled = false;
        camera.GetComponent<MouseLook>().enabled = false;
        Invoke("SetEnding", 1);
    }

    public void SetEnding() {
        ending.SetActive(true);
    }
    public void GameExit() {
        Debug.Log("exit");
        Application.Quit();
    }
}
