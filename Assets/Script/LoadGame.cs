using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public Transform player;
    public Transform camera;
    public GameObject Title;
    bool isClicked = false;

    void Start() {
        player.GetComponent<PlayerMovement>().enabled = false;
        camera.GetComponent<MouseLook>().enabled = false;
    }

    void Update()
    {
        if (isClicked)
        {
            camera.position = Vector3.Lerp(camera.position, player.position, 0.1f);
        }
    }
    public void SetClick()
    {
        isClicked = true;
        camera.rotation = Quaternion.Euler(0, 0, 0);
        Title.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        camera.GetComponent<MouseLook>().enabled = true;
    }


    public void GameExit()
    {
        Debug.Log("exit");
        Application.Quit();
    }
}
