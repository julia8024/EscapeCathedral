using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestFlowers : MonoBehaviour
{
    public GameObject thisFlower;
    public GameObject thisLight;
    public GameObject bridge;
    public Camera camera;
    public int thisSlot;
    public static int flowerResult = 0;
    public AudioSource bridge_sound;

    public void OnMouseDown() {
        // for (int i = 0; i < 4; i++) {
        //     if (ObjectClicker.slotSelected == i+2 && flowers[i].activeSelf == false) {
        //         flowers[i].SetActive(true);
        //         lights[i].SetActive(true);
        //         // ObjectClicker.setSlotStatus(i+1, false);
        //         camera.GetComponent<ObjectClicker>().setSlotStatus(i+1, false);
        //         break;
        //     }
        // }
        if (ObjectClicker.slotSelected == thisSlot && thisFlower.activeSelf == false) {
            thisFlower.SetActive(true);
            thisLight.SetActive(true);
            camera.GetComponent<ObjectClicker>().setSlotStatus(thisSlot-1, false);
            flowerResult++;
            Debug.Log("flowerResult = " + flowerResult);
        }
    }

    void Update() {
        if (flowerResult == 4) {
            Debug.Log("Escape Success");
            bridge_sound.Play();
            bridge.SetActive(true);
            flowerResult++;
        }
    }
}
