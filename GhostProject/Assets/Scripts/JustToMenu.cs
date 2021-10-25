using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JustToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string toMenu;

    public void GoMenuAgain()
    {
        SceneManager.LoadScene(toMenu);
    }
}
