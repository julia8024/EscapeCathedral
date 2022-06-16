using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectClicker : MonoBehaviour
{
    [SerializeField]
    private GameObject Inven;
    private static bool[] isSlot = new bool[6] {false, false, false, false, false, false};
    public GameObject[] ItemSlot = new GameObject[6];
    public static int slotSelected = 0;  // nothing selected
    public GameObject holyWaterobj;
    public GameObject bellobj;
    public static bool uiIsActived = false;
    public AudioSource itemfound;
    public AudioSource itemSelect_sound;
    
    // private string[] invenItems = new string[] {"SlotMatches", "SlotFlowerPurple", "SlotFlowerOrange", "SlotFlowerYellow", "SlotflowerPink", "SlotHolyWater"};
    // private string[] invenItems = new string[] {"img_match", "img_flowerpurple", "img_flowerorange", "img_floweryellow", "img_flowerpink", "img_holywater"};
    private string[] colliderName = new string[] {"matchBox", "flowerPurple", "flowerOrange", "flowerYellow", "flowerPink", "HolyWater"};

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);

            if (didHit)
            {
                if (rhInfo.collider.name == "case_ingredients" && QuestMakeHolyWater.HwResult == false && uiIsActived == false) {
                    holyWaterobj.GetComponent<QuestMakeHolyWater>().OpenCamera();
                    itemSelect_sound.Play();
                }
                if (rhInfo.collider.name == "case_bells" && QuestBell.BellResult == false && uiIsActived == false) {
                    bellobj.GetComponent<QuestBell>().OpenCamera();
                    itemSelect_sound.Play();
                }
                Debug.Log(rhInfo.collider.name + " - " + rhInfo.point);
                Destroyable destScript = rhInfo.collider.GetComponent<Destroyable>();
                if (destScript)
                {
                    Inven.SetActive(true);
                    destScript.Remove();
                    for (int i = 0; i < 6; i++) {
                        if (rhInfo.collider.name == colliderName[i]) {
                            ItemSlot[i].GetComponent<Image>().enabled = true;
                            isSlot[i] = true;
                            Debug.Log(colliderName[i] + " - add to inventory");
                            itemfound.Play();
                        }
                    }

                   // // Color color = ItemSlot.GetComponent<Image>().color;
                   // // color.a = 255;
                   // // ItemSlot.GetComponent<Image>().color = color;
                    // ItemSlot.SetActive(true);
                }
            }
            else
            {
                Debug.Log("clicked on empty space");
            }
        }

        // // for (int i = 0; i < 9; i++) {
        // //     if (isSlot[i] == false) {
        // //         ItemSlot = GameObject.Find(invenItems[i]).transform.GetChild(1).gameObject;
        // //         Color color = ItemSlot.GetComponent<Image>().color;
        // //         color.a = 0;
        // //         ItemSlot.GetComponent<Image>().color = color;
        // //         Debug.Log((i+1) + "번째 아이템 사용");
        // //     }
        // // }

        if (Input.anyKey == true && Inven.activeSelf == true) {

            for (int i = 0; i < 6; i++) {
                if (Input.GetKeyDown((i+1).ToString()) && isSlot[i] == true) {
                    Debug.Log((i+1) + "번째 인벤토리 선택된 상태");
                    slotSelected = i+1;
                    ItemSlot[i].GetComponent<Outline>().enabled = true;
                    itemSelect_sound.Play();
                    for (int j = 0; j < 6; j++) {
                        if (slotSelected == j+1) {
                            Debug.Log((j+1) + " 번째 선택됨");
                        } else {
                            ItemSlot[j].GetComponent<Outline>().enabled = false;
                        }
                    }
                }
            }
            // if (Input.GetKeyDown("1") && isSlot[0] == true) {
            //     // match 아이템
            //     Debug.Log("1번째 인벤토리 선택된 상태");

            //     // ItemSlot = GameObject.Find("SlotMatches").transform.GetChild(1).gameObject;
            //     // efcolor = ItemSlot.GetComponent<Outline>().effectColor;
            //     // efcolor.a = 255;
            //     // ItemSlot.GetComponent<Outline>().effectColor = efcolor;

            //     slotSelected = 1;
            // }
            // else if (Input.GetKeyDown("2") && isSlot[1] == true) {
            //     // flowerPurple 아이템
            //     Debug.Log("2번째 인벤토리 선택된 상태");
            //     slotSelected = 2;
            // } else if (Input.GetKeyDown("3") && isSlot[2] == true) {
            //     // flowerOrange 아이템
            //     Debug.Log("3번째 인벤토리 선택된 상태");
            //     slotSelected = 3;
            // } else if (Input.GetKeyDown("4") && isSlot[3] == true) {
            //     // flowerYellow 아이템
            //     Debug.Log("4번째 인벤토리 선택된 상태");
            //     slotSelected = 4;
            // } else if (Input.GetKeyDown("5") && isSlot[4] == true) {
            //     // flowerPink 아이템
            //     Debug.Log("5번째 인벤토리 선택된 상태");
            //     slotSelected = 5;
            // } else if (Input.GetKeyDown("6") && isSlot[5] == true) {
            //     // holyWater 아이템
            //     Debug.Log("6번째 인벤토리 선택된 상태");
            //     slotSelected = 6;
            // }
        }


    }

    public void setSlotStatus (int index, bool result) {
        if (index < 6 && index >= 0) {
            isSlot[index] = result;
            ItemSlot[index].GetComponent<Image>().enabled = false;
            isSlot[index] = false;
        }
    }



}
