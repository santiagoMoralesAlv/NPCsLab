using System;
using System.Collections;
using UnityEngine;

public class SwipeDetections : MonoBehaviour
{
    [SerializeField]
    private float minimumDistance = .2f;
    [SerializeField]
    private float maximumTime = 1f;
    [SerializeField, Range(0f, 1f)]
    private float directionThreshold = .9f;
    [SerializeField]
    private GameObject trail;

    private CharacterMov characterMov;

    private Vector2 startPosition;
    private float startTime;
    private Vector2 endPosition;
    private float endTime;
    private Coroutine coroutine;

    public static Action ESwipeUp, ESwipeDown, ESwipeLeft, ESwipeRight;

    private void Awake()
    {
        characterMov = CharacterMov.Instance;
    }
    private void OnEnable()
    {
        characterMov.OnStartTouch += SwipeStart;
        characterMov.OnEndTouch += SwipeEnd;

    }
    private void OnDisable()
    {
        characterMov.OnStartTouch -= SwipeStart;
        characterMov.OnEndTouch -= SwipeEnd;

    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
       // trail.SetActive(true);
       // trail.transform.position = position;
       // coroutine = StartCoroutine(Trail());
    }
    
    private void SwipeEnd(Vector2 position, float time)
    {
        //trail.SetActive(false);
        //StopCoroutine(coroutine);
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }
    private void DetectSwipe()
    {
        if(Vector3.Distance(startPosition, endPosition)>= minimumDistance &&
            (endTime - startTime) <= maximumTime)
        {
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            (ESwipeUp)?.Invoke();

        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            (ESwipeDown)?.Invoke();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            (ESwipeLeft)?.Invoke();
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            (ESwipeRight)?.Invoke();
        }
    }

}
