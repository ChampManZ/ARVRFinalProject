using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Intro : MonoBehaviour
{
    public TMPro.TextMeshProUGUI introText;
    // [SerializeField] Material sceneImage1;
    // [SerializeField] Material sceneImage2;
    // [SerializeField] Material sceneImage3;
    // [SerializeField] Material sceneImage4;
    // [SerializeField] Material sceneImage5;
    // [SerializeField] Material sceneImage6;
    [SerializeField] float timer = 0;
    [SerializeField] private string ingameName;
    // [SerializeField] Button startGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 1)
        {
            introText.text = "Once upon a time.";
        }
        
        if (timer >= 4)
        {
            introText.text = "There is a woman who is deeply in love with her boyfriend.";
            
        }

        if (timer >= 9)
        {
            introText.text = "Every year they will celebrate their anniversary in Japan and the man will always buy Maomori for her.";
        }

        if (timer >= 13)
        {
            introText.text = "On their tenth years anniversary,";
        }

        if (timer >= 19)
        {
            introText.text = "she found out that her boyfriend cheated on her with another woman.";
        }

        if (timer >= 24)
        {
            introText.text = "She killed her boyfriend and killed herself afterward because of the painful heartache.";
        }

        if (timer >= 28)
        {
            introText.text = "Do you know that where you are right now?";
        }

        if (timer >= 31)
        {
            introText.text = "She is still holding grudges and have a wrathful energy,";
        }

        if (timer >= 34)
        {
            introText.text = "which prevents her from being incarnate.";
        }

        if (timer >= 37)
        {
            introText.text = "In your place...";
        }

        if (timer >= 40)
        {
            introText.text = "";
            SceneManager.LoadScene(ingameName);
        }
    }
}
