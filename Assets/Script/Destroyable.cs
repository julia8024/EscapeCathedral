using System.Collections;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public void Remove()
    {
        Debug.Log("Destroyable function Remove() is called on " + name);
        Destroy(gameObject);
    }
}
