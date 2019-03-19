using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{


    [SerializeField]
    private GameObject startScene;

    [SerializeField]
    private GameObject venueScene;

    [SerializeField]
    private GameObject sliderScene;

    [SerializeField]
    private GameObject resultsScene;

    [SerializeField]
    private GameObject back;

    private List<SceneMover> scenes;
    private Button backButton;

    bool quickSearch = false;

    public int sceneNum = 0;

   

    // Start is called before the first frame update
    void Start()
    {
        scenes = new List<SceneMover>();
        scenes.Add(startScene.GetComponent<SceneMover>());
        scenes.Add(venueScene.GetComponent<SceneMover>());
        scenes.Add(sliderScene.GetComponent<SceneMover>());
        scenes.Add(resultsScene.GetComponent<SceneMover>());
        backButton = back.GetComponent<Button>();
    }

    public void moveAllLeft()
    {
        foreach(SceneMover scene in scenes){
            scene.MoveToLeft();
        }
        sceneNum += 1;
    }

    public void moveAllRight()
    {

        if (sceneNum > 0)
        {
            //orderCorrectly();
            foreach (SceneMover scene in scenes)
            {
                scene.MoveToRight();
            }

            

            sceneNum--;
            SearchPopupController.controller.Disappear();
            
          
        }
    }

    public void fastSearch()
    {

        quickSearch = true;

        //move slider scene out the way
        sliderScene.GetComponent<SceneMover>().TeleToPosition(-10000);


        //go straight to results scene
        resultsScene.GetComponent<SceneMover>().TeleToPosition(1500);

        sceneNum = 2;

        moveAllLeft();
    }

    public void filterSearch()
    {
        //move slider to next
        sliderScene.GetComponent<SceneMover>().TeleToPosition(1500);

        //move results scene to next
        resultsScene.GetComponent<SceneMover>().TeleToPosition(3000);

        moveAllLeft();
    }

    public void moveHome()
    {
        //move everythihg out of the way
        foreach (SceneMover scene in scenes)
        {
            scene.TeleToPosition(1500);
        }

        //put results scene back
        resultsScene.GetComponent<SceneMover>().TeleToPosition(0);

        //get the start screne
        startScene.GetComponent<SceneMover>().TeleToPosition(-1500);

        moveAllRight();

        sceneNum = 0;
        backButton.interactable = false;
    }

    

    public void snapAllToDefault()
    {
        foreach(SceneMover scene in scenes)
        {
            scene.TeleToDefault();
        }

        sceneNum = 0;
        backButton.interactable = false;
    }

    public void disableBackButton()
    {
        foreach(SceneMover scene in scenes)
        {
            scene.disableBackButton();
        }

   
    }

    public void Update()
    {
        backButton.interactable = sceneNum != 0;
    }
}
