using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    [Header("UI References")]
    public List<Image> gridImages;

    public List <Image> inputImages;

    private bool[] inputLineData = new bool[7];

    private bool[,] gridData = new bool[10, 7];

    void Start()
    {
        RenderGrid();
        RenderInputLine();
    }

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
        if (Input.GetKeyDown(KeyCode.D)) SubmitLine();
    }

    private void ToggleInputPixel(int index)
    {
        if (index >= 0 && index < inputLineData.Length)
        {
            inputLineData[index] = !inputLineData[index];
        }

        RenderInputLine();
    }

    private void SubmitLine()
    {
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                gridData[row, col] = gridData[row + 1, col];
            }
        }

        for (int col = 0; col < 7; col++)
        {
            gridData[9, col] = inputLineData[col];
        }

        for (int col = 0; col < 7; col++)
        {
            inputLineData[col] = false;
        }

        RenderGrid();
        RenderInputLine();
    }

    private void RenderGrid()
    {
        for (int row = 0; row < 10; row++)
        {
            for (int col = 0; col < 7; col++)
            {
                int listIndex = row * 7 + col;
                if (listIndex < gridImages.Count)
                {
                    gridImages[listIndex].color = gridData[row, col] ? Color.white : Color.black;
                }
            }
        }
    }

    private void RenderInputLine()
    {
        for (int i = 0; i < 7; i++)
        {
            if (i < inputImages.Count)
            {
                inputImages[i].color = inputLineData[i] ? Color.white : Color.black;
            }
        }
    }
}
