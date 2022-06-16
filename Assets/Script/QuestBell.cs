using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestBell : MonoBehaviour
{
    private bool Correct = false;
    public TextMeshProUGUI Result;
    public GameObject[] bells = new GameObject[3];
    private int[] answer = new int[4] { 1, 2, 0, 2 };
    private int[] input = new int[4] { -1, -1, -1, -1 };
    private string[] str = new string[3] {"R", "G", "B"};
    int n = 0;

    public Camera camera;
    public Camera thisCamera;
    public GameObject player;
    public GameObject Case_bells;
    public GameObject bell_ui;
    public GameObject flowerYellow;

    public static bool BellResult = false;

    public void TaskOnClick(int index) {
        if (n > 4) return;
        if (n==0) Result.text = "";

        input[n++] = index;
        Result.text += str[index] + " ";
    }

    public void PrintFinish() {
        Debug.Log("Finish Button Click");
        Correct = true;
        for (int i = 0; i < 4; i++) {
            if (answer[i] != input[i]) Correct = false;
        }
        if (Correct) {
            Result.text = "Success";
            CloseCamera();
            flowerYellow.SetActive(true);
            BellResult = true;
        } else {
            Result.text = "Fail";
        }
        n = 0;
        for (int i = 0; i < 4; i++) {
            input[i] = -1;
        }
    }

    public void PrintReset() {
        Debug.Log("Reset");
        Result.text = "Reset";
        n = 0;
        for (int i = 0; i < 4; i++) {
            input[i] = -1;
        }
    }

    public void OpenCamera() {
        camera.GetComponent<ObjectClicker>().enabled = false;
        camera.enabled = false;
        thisCamera.enabled = true;
        Case_bells.GetComponent<BoxCollider>().enabled = false;
        Case_bells.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = false;
        bell_ui.SetActive(true);
    }

    public void CloseCamera() {
        Debug.Log("close");
        camera.GetComponent<ObjectClicker>().enabled = true;
        camera.enabled = true;
        thisCamera.enabled = false;
        Case_bells.GetComponent<BoxCollider>().enabled = true;
        Case_bells.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        bell_ui.SetActive(false);
        ObjectClicker.uiIsActived = false;
    }
}
