/* 
(c) Kaminari Games, LLC [2019]
https://www.kaminari.io [Disbanded]
Author: Andy Carrera
*/

using System.Collections;
using UnityEngine;

// This class provides clearing functionality and allows
// objects to be destoryed, followed by a clearing animation.
public class ClearablePiece : MonoBehaviour
{

    public AnimationClip clearAnimation;

    private bool isBeingCleared = false;

    public bool IsBeingCleared
    {
        get { return isBeingCleared; }
    }

    protected GamePiece piece;

    void Awake()
    {
        piece = GetComponent<GamePiece>();
    }

    public void Clear()
    {
        isBeingCleared = true;
        StartCoroutine(ClearCoroutine());
    }

    // Plays the clearing animation and then destory object in scene
    private IEnumerator ClearCoroutine()
    {
        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play(clearAnimation.name);

            yield return new WaitForSeconds(clearAnimation.length);

            Destroy(gameObject);
        }
    }
}
