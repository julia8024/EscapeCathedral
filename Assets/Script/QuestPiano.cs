using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestPiano : MonoBehaviour
{
    private bool Correct = false;
    public static bool PianoResult = false;
    public TextMeshProUGUI Result;
    public Button[] Note = new Button[12];
    private int[] answer = new int[4] { 4, 7, 1, 2 };
    private int[] input = new int[4] { -1, -1, -1, -1 };
    private string[] str = new string[12] {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
    int n=0;

    public GameObject[] piano_closed = new GameObject[2];
    public GameObject[] piano_open = new GameObject[3];



    public GameObject player;
    public Camera camera;

    private void Start()
    {
        // obj = GameObject.Find("piano_ui");
        for (int i = 0; i < 12; i++)
        {
            int index = i;
            Note[index].interactable = true;
            Note[index].onClick.AddListener(() => this.TaskOnClick(index));
        }
    }

    private void TaskOnClick(int index)
    {
        Debug.Log("입력 : " + index, Note[index]);
        if (n > 4)
            return;
        if(n == 0)
            Result.text = "";
        input[n++] = index;
        Result.text += str[index] + " ";
    }

    public void PrintFinish()
    {
        Debug.Log("Finish Button Click");
        Correct = true;
        for(int i=0; i < 4; i++)
        {
            if(answer[i] != input[i]) Correct = false;
        }
        if(Correct) {
            // 문제 풀기 성공
            Result.text = "Success";
            // GameObject.Find("piano_ui").SetActive(false);
            ClosePiano();
            PianoResult = true;
            setAssets();
        }
        else    // 문제 풀기 실패
            Result.text = "Fail";
        n = 0;
        for (int i = 0; i < 4; i++)
            input[i] = -1;
    }
    public void PrintReset()
    {
        Debug.Log("Reset Button Click");
        Result.text = "Reset";
        n = 0;
        for (int i = 0; i < 4; i++)
            input[i] = -1;
    }

    public void ClosePiano() {
        Debug.Log("close piano ui");
        GameObject.Find("piano_ui").SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
        camera.GetComponent<MouseLook>().enabled = true;
        ObjectClicker.uiIsActived = false;
    }

    public void setAssets() {
        
        for (int i = 0; i < 2; i++) {
            piano_closed[i].SetActive(false);
        }
        for (int i = 0; i < 3; i++) {
            piano_open[i].SetActive(true);
        }
        Debug.Log("피아노 뚜껑 열림");
    }
}
