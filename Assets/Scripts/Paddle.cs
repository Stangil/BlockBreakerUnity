using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMin = 1f;
    [SerializeField] float xMax = 15f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMousePosInUnits = Mathf.Clamp((Input.mousePosition.x / Screen.width * screenWidthInUnits),xMin, xMax);
        Vector2 paddlePosition = new Vector2(xMousePosInUnits, transform.position.y);
        transform.position = paddlePosition;
    }
}
