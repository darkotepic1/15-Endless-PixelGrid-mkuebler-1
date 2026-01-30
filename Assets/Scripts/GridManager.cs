using UnityEngine;

public class GridManager : MonoBehaviour
{
    private bool[] inputLineData = new bool[7];

    private bool[,] gridData = new bool[10, 7];

    void Start()
    {
        
    }

    // ... (Datenmodell Code von vorher)

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {   
        if (Input.GetKeyDown(KeyCode.W)) ToggleInputPixel(0);          // Q6
        if (Input.GetKeyDown(KeyCode.A)) ToggleInputPixel(1);          // Q5
        if (Input.GetKeyDown(KeyCode.UpArrow)) ToggleInputPixel(2);    // Q4
        if (Input.GetKeyDown(KeyCode.LeftArrow)) ToggleInputPixel(3);  // Q3
        if (Input.GetKeyDown(KeyCode.DownArrow)) ToggleInputPixel(4);  // Q2
        if (Input.GetKeyDown(KeyCode.RightArrow)) ToggleInputPixel(5); // Q1
        if (Input.GetKeyDown(KeyCode.S)) ToggleInputPixel(6);          // Q0
    }

    private void ToggleInputPixel(int index)
    {
        if (index >= 0 && index < inputLineData.Length)
        {
            inputLineData[index] = !inputLineData[index];
    }
    }
}
