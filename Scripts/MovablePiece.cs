/* 
(c) Kaminari Games, LLC [2019]
https://www.kaminari.io [Disbanded]
Author: Andy Carrera
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class provides functionality for all pieces that can be moved around
// Doesn't touch any unmovable objects/barriers
public class MovablePiece : MonoBehaviour
{

    private GamePiece piece;
    private IEnumerator moveCoroutine;

    void Awake()
    {
        piece = GetComponent<GamePiece>();
    }

    public void Move(int newX, int newY, float time)
    {
        if (moveCoroutine != null)
        {
            StopCoroutine(moveCoroutine);
        }

        moveCoroutine = MoveCoroutine(newX, newY, time);
        StartCoroutine(moveCoroutine);
    }

    public IEnumerator MoveCoroutine(int newX, int newY, float time)
    {
        piece.X = newX;
        piece.Y = newY;

        Vector3 startPos = transform.position;
        Vector3 endPos = piece.GridRef.GetWorldPosition(newX, newY);

        for (float t = 0; t <= 1 * time; t += Time.deltaTime)
        {
            piece.transform.position = Vector3.Lerp(startPos, endPos, t / time);
            yield return 0;
        }

        piece.transform.position = piece.GridRef.GetWorldPosition(newX, newY);
    }
}
