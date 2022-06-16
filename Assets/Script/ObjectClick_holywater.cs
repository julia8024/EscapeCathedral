using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClick_holywater : MonoBehaviour
{
    public GameObject holywater_gameobj;
    public Transform thisObj;
    public int index;

    public void OnMouseDown() {
        holywater_gameobj.GetComponent<QuestMakeHolyWater>().TaskOnClick(index);
        thisObj.Translate(new Vector3(0, 0.3f, 0));
        Invoke("TranslateReset", (float)0.3);
    }

    public void TranslateReset() {
        thisObj.Translate(new Vector3(0, -0.3f, 0));
    }
}
