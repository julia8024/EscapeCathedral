using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestMakeHolyWater : MonoBehaviour
{

    private bool Correct = false;
    public TextMeshProUGUI Result;
    public GameObject[] ingredients = new GameObject[12];
    private int[] answer = new int[4] { 3, 6, 1, 10 };
    private int[] input = new int[4] {-1, -1, -1, -1};
    int n = 0;

    public GameObject JarEmpty;
    public GameObject HolyWater;
    public Camera camera;
    public Camera thisCamera;
    public GameObject player;
    public GameObject Case_ingredients;
    public GameObject holywater_ui;
    public AudioSource clickSound;

    public static bool HwResult = false;

    public void TaskOnClick(int index) {
        Debug.Log("클릭 : " + index, ingredients[index]);
        clickSound.Play();
        if (n > 4) {
            return;
        }
        if (n == 0) {
            Result.text = "";
        }
        input[n++] = index;
        Result.text += "*" + " ";
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
            JarEmpty.SetActive(false);
            HolyWater.SetActive(true);
            HwResult = true;
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
        Case_ingredients.GetComponent<BoxCollider>().enabled = false;
        Case_ingredients.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = false;
        holywater_ui.SetActive(true);
    }

    public void CloseCamera() {
        Debug.Log("close");
        camera.GetComponent<ObjectClicker>().enabled = true;
        camera.enabled = true;
        thisCamera.enabled = false;
        Case_ingredients.GetComponent<BoxCollider>().enabled = true;
        Case_ingredients.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        holywater_ui.SetActive(false);
        ObjectClicker.uiIsActived = false;
    }
}
