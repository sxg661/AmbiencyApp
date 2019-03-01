using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void FilteredSearch()
    {
        SceneManager.LoadScene("SliderScene");
    }

    public void Type()
    {
        SceneManager.LoadScene("VenueScene");
    }

    public void Result()
    {
        SceneManager.LoadScene("ResultsScene");
    }

    public void StartScene()
    {
        SceneManager.LoadScene("LocationScene");
    }

}
