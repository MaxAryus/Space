using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CamaraManager : MonoBehaviour
{
    public float horizontalResolution = 1920;
    // Start is called before the first frame update
    void OnGUI()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = horizontalResolution / currentAspect / 200;
    }
}
