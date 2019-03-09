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

    public int transFromStart = 0;

    Vector3 startPos;
    Vector3 goalPos;

    [SerializeField]
    private Vector3 defaultPos;


    private void Start()
    {
        rectTrans = GetComponent<RectTransform>();
        rectTrans.localPosition = defaultPos;
    }

    public void MoveToLeft()
    {
        moving = true;
        timeSinceStart = 0;
        startPos = rectTrans.localPosition;
        goalPos = new Vector3(startPos[0] - 1500, startPos[1], 0);
        transFromStart += 1;
    }

    public void MoveToRight()
    {
        if(transFromStart > 0)
        {
            moving = true;
            timeSinceStart = 0;
            startPos = rectTrans.localPosition;
            goalPos = new Vector3(startPos[0] + 1500, startPos[1], 0);
            transFromStart -= 1;
        }
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
                return;
            }

            rectTrans.localPosition = Vector3.Lerp(startPos, goalPos, timeSinceStart / timeForTransition);
            
        }

    }
}
