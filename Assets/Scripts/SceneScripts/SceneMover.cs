using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMover : MonoBehaviour
{
    public RectTransform rectTrans;
    public int moveDist = 1500;
    bool moving = false;
    float timeSinceStart;
    float timeForTransition = 0.5f;

    Vector3 startPos;
    Vector3 goalPos;

    bool backEnabled;

    [SerializeField]
    private Vector3 defaultPos;

    private Vector3 currentPos;


    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        rectTrans.localPosition = defaultPos;
        currentPos = defaultPos;
    }

    public void MoveToLeft()
    {
        moving = true;
        timeSinceStart = 0;
        startPos = currentPos;
        goalPos = new Vector3(startPos[0] - 1500, startPos[1], 0);
    }

    public void MoveToRight()
    {
        if(currentPos[0]  < defaultPos[0] && backEnabled)
        {
            moving = true;
            timeSinceStart = 0;
            startPos = currentPos;
            goalPos = new Vector3(startPos[0] + 1500, startPos[1], 0);
        }
    }

    public void TeleToPosition(float x)
    {
        currentPos = new Vector3(x, currentPos[1], 0);
        rectTrans.localPosition = currentPos;
    }

    public void disableBackButton()
    {
        backEnabled = false;
    }

    public void TeleToDefault()
    {
        currentPos = defaultPos;
        rectTrans.localPosition = defaultPos;
        backEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            timeSinceStart += Time.deltaTime;

            if (timeSinceStart >= timeForTransition)
            {
                rectTrans.localPosition = goalPos;
                moving = false;
                currentPos = goalPos;
                return;
            }

            rectTrans.localPosition = Vector3.Lerp(startPos, goalPos, timeSinceStart / timeForTransition);
            
        }

    }
}
