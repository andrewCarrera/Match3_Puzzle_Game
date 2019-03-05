/* 
(c) Kaminari Games, LLC [2019]
https://www.kaminari.io [Disbanded]
Author: Andy Carrera
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script has to be attached to any game piece
// that is going to appear on the grid, regardless of type
public class GamePiece : MonoBehaviour
{
    /*
       ___________
      |           |
      |    ***    |
      | VARIABLES |
      |    ***    |
      |___________|

    */

    private int x;
    private int y;

    public int X
    {
        get { return x; }
        set
        {
            if (IsMovable())
            {
                x = value;
            }
        }
    }

    public int Y
    {
        get { return y; }
        set
        {
            if (IsMovable())
            {
                y = value;
            }
        }
    }

    private Grid.PieceType type;

    public Grid.PieceType Type
    {
        get { return type; }
    }

    private Grid grid;

    public Grid GridRef
    {
        get { return grid; }
    }

    private MovablePiece movableComponent;

    public MovablePiece MovableComponent
    {
        get { return movableComponent; }
    }

    private ColorPiece colorComponent;

    public ColorPiece ColorComponent
    {
        get { return colorComponent; }
    }

    private ClearablePiece clearableComponent;

    public ClearablePiece ClearableComponent
    {
        get { return clearableComponent; }
    }

    /*
       ___________
      |           |
      |    ***    |
      | FUNCTIONS |
      |    ***    |
      |___________|

    */

    // Utility functions, all names self-explanatory
    void Awake()
    {
        movableComponent = GetComponent<MovablePiece>();
        colorComponent = GetComponent<ColorPiece>();
        clearableComponent = GetComponent<ClearablePiece>();
    }

    public void Init(int _x, int _y, Grid _grid, Grid.PieceType _type)
    {
        x = _x;
        y = _y;
        grid = _grid;
        type = _type;
    }

    void OnMouseEnter()
    {
        grid.EnterPiece(this);
    }

    void OnMouseDown()
    {
        grid.PressPiece(this);
    }

    void OnMouseUp()
    {
        grid.ReleasePiece();
    }

    public bool IsMovable()
    {
        return movableComponent != null;
    }

    public bool IsColored()
    {
        return colorComponent != null;
    }

    public bool IsClearable()
    {
        return clearableComponent != null;
    }
}
