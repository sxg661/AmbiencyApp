using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController2 : MonoBehaviour
{
    [SerializeField]
    private GameObject startScene;

    [SerializeField]
    private GameObject venueScene;

    [SerializeField]
    private GameObject sliderScene;

    [SerializeField]
    private GameObject resultsScene;

    private List<SceneMover> scenes;
   

    // Start is called before the first frame update
    void Start()
    {
        scenes = new List<SceneMover>();
        scenes.Add(startScene.GetComponent<SceneMover>());
        scenes.Add(venueScene.GetComponent<SceneMover>());
        scenes.Add(sliderScene.GetComponent<SceneMover>());
        scenes.Add(resultsScene.GetComponent<SceneMover>());
    }

    public void moveAllLeft()
    {
        foreach(SceneMover scene in scenes){
            scene.MoveToLeft();
        }
    }

    public void moveAllRight()
    {
        foreach(SceneMover scene in scenes)
        {
            scene.MoveToRight();
        }
    }
}
