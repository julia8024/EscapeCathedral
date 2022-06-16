using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestAltar : MonoBehaviour
{
    
    private bool Correct = false;
    public static bool AltarResult = false;

    private int[] answer = new int[4] { 1, 3, 2, 0};
    private int[] input = new int[4] {-1, -1, -1, -1};
    private string[] str = new string[4] {"♠", "♥", "♦", "♣"};
    int n = 0;


    public GameObject player;
    public Camera camera;

    public GameObject altar_closed;
    public GameObject[] altar_open = new GameObject[2];
    public TextMeshProUGUI Result;
    public Button[] btns = new Button[4];
    public AudioSource unlock;

    void Start()
    {
        for (int i = 0; i < 4; i++) {
            int index = i;
            btns[index].onClick.AddListener(() => this.TaskOnClick(index));
        }
    }

    private void TaskOnClick(int index) {
        Debug.Log("입력 : " + index, btns[index]);
        
        if (n > 4) {
            return;
        }
        if (n == 0) {
            Result.text = "";
        }
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
            CloseAltar();
            AltarResult = true;
            setAssets();
        }
        else
            Result.text = "Fail";
        
        n = 0;
        for (int i = 0; i < 4; i++) {
            input[i] = -1;
        }
    }

    public void PrintReset() {
        Debug.Log("Reset Button Click");
        Result.text = "Reset";
        n = 0;
        for (int i = 0; i < 4; i++) {
            input[i] = -1;
        }
    }

    public void CloseAltar() {
        Debug.Log("close altar ui");
        GameObject.Find("altar_ui").SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        camera.GetComponent<MouseLook>().enabled = true;
        ObjectClicker.uiIsActived = false;
    }

    public void setAssets() {
        altar_closed.SetActive(false);
        for (int i = 0; i < 2; i++) {
            altar_open[i].SetActive(true);
        }
        unlock.Play();
        GameObject.Find("altar").GetComponent<BoxCollider>().enabled = false;
    }
}
