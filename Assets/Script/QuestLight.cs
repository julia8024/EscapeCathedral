using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLight : MonoBehaviour
{
    public GameObject chandelier_none;
    public GameObject chandelier_active;
    public GameObject cathedral_door;
    public Camera camera;
    public AudioSource unlock;
    
    public void OnMouseDown() {
        // Debug.Log("click chandelier");

        if (ObjectClicker.slotSelected == 1 && chandelier_none.activeSelf == true) {
            chandelier_none.SetActive(false);
            chandelier_active.SetActive(true);
            chandelier_none.GetComponent<QuestLight>().enabled = false;
            // ObjectClicker.setSlotStatus(0, false);

            camera.GetComponent<ObjectClicker>().setSlotStatus(0, false);
            Debug.Log("chandelier_success");

            cathedral_door.SetActive(true);
            unlock.Play();
            Debug.Log("open_door");
        }
    }
}
