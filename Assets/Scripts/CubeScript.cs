using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public Transform cube;
    public RectTransform rectTransform;
    Vector2 größe;
    Vector3 cubePosition;
    // Start is called before the first frame update
    void Start()
    {
        größe.x = rectTransform.rect.width;
        größe.y = rectTransform.rect.height;
    }

    // Update is called once per frame
    void Update()
    {
         größe.x = rectTransform.rect.width;
        größe.y = rectTransform.rect.height;
        cubePosition.x = größe.x/11.5f;
        cubePosition.y = 0f;
        cubePosition.z = 0f;
        cube.transform.position = cubePosition;
       
        
    }
}
