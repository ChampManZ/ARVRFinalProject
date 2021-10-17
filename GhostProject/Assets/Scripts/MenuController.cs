using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    [SerializeField] private string toStoryTeller;
    [SerializeField] private string toReplay;
    [SerializeField] private string toMenu;
    [SerializeField] private string toInstruct;

    public void GoStory()
    {
        SceneManager.LoadScene(toStoryTeller);
    }
    public void GoReplay()
    {
        SceneManager.LoadScene(toReplay);
    }
    public void GoMenu()
    {
        SceneManager.LoadScene(toMenu);
    }
    public void GoInstruct()
    {
        SceneManager.LoadScene(toInstruct);
    }
}
