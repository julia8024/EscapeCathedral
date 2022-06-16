using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holySpaceClick : MonoBehaviour
{
    public GameObject flowerOrange;
    public Camera camera;
    public AudioSource pourwater;

    void Start() {
        flowerOrange.GetComponent<CapsuleCollider>().enabled = false;
        flowerOrange.GetComponent<Destroyable>().enabled = false;
    }

    public void OnMouseDown() {
        if (ObjectClicker.slotSelected == 6 && flowerOrange.activeSelf == false) {
            camera.GetComponent<ObjectClicker>().setSlotStatus(5, false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            flowerOrange.SetActive(true);
            // gameObject.SetActive(false);
            flowerOrange.GetComponent<CapsuleCollider>().enabled = true;
            flowerOrange.GetComponent<Destroyable>().enabled = true;
            pourwater.Play();
        }
    }
}
