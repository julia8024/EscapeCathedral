using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick_bell : MonoBehaviour
{
    public GameObject bells_gameobj;
    public AudioSource bellSound;
    public Transform thisBell;
    public int index;

    public void OnMouseDown() {
        bells_gameobj.GetComponent<QuestBell>().TaskOnClick(index);
        thisBell.Translate(new Vector3(0, 0.3f, 0));
        bellSound.Play();
        Invoke("TranslateReset", (float)0.3);
    }
    public void TranslateReset() {
        thisBell.Translate(new Vector3(0, -0.3f, 0));
    }
}
