using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBG : MonoBehaviour
{
    public GameObject BG;
    public GameObject firstBG;
    public GameObject secondBG;
    public GameObject thirdBG;
    public GameObject fourthBG;
    public GameObject fifthBG;
    public GameObject sixthBG;
    //public SpriteRenderer spriteRenderer;

    [SerializeField] float timer = 0;

    void Start()
    {
        //spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 4)
        {
           //this.spriteRenderer.sprite = firstBG;
           firstBG.SetActive(true);
           secondBG.SetActive(false);
           thirdBG.SetActive(false);
           fourthBG.SetActive(false);
           fifthBG.SetActive(false);
           sixthBG.SetActive(false);
           BG.SetActive(false);
        }

        if (timer >= 9)
        {
            //this.spriteRenderer.sprite = secondBG;
            firstBG.SetActive(false);
           secondBG.SetActive(true);
           thirdBG.SetActive(false);
           fourthBG.SetActive(false);
           fifthBG.SetActive(false);
           sixthBG.SetActive(false);
           BG.SetActive(false);
        }

        if (timer >= 19)
        {
            //this.spriteRenderer.sprite = thirdBG;
            firstBG.SetActive(false);
           secondBG.SetActive(false);
           thirdBG.SetActive(true);
           fourthBG.SetActive(false);
           fifthBG.SetActive(false);
           sixthBG.SetActive(false);
           BG.SetActive(false);
        }

        if (timer >= 24)
        {
            //this.spriteRenderer.sprite = fourthBG;
            firstBG.SetActive(false);
           secondBG.SetActive(false);
           thirdBG.SetActive(false);
           fourthBG.SetActive(true);
           fifthBG.SetActive(false);
           sixthBG.SetActive(false);
           BG.SetActive(false);


            if (timer >= 26) {
                //this.spriteRenderer.sprite = fifthBG;
                firstBG.SetActive(false);
           secondBG.SetActive(false);
           thirdBG.SetActive(false);
           fourthBG.SetActive(false);
           fifthBG.SetActive(true);
           sixthBG.SetActive(false);
           BG.SetActive(false);

            }
        }

        if (timer >= 28)
        {
            //this.spriteRenderer.sprite = BG;
            firstBG.SetActive(false);
           secondBG.SetActive(false);
           thirdBG.SetActive(false);
           fourthBG.SetActive(false);
           fifthBG.SetActive(false);
           sixthBG.SetActive(false);
           BG.SetActive(true);
        }

        if (timer >= 37)
        {
            //this.spriteRenderer.sprite = sixthBG;firstBG.SetActive(false);
           secondBG.SetActive(false);
           thirdBG.SetActive(false);
           fourthBG.SetActive(false);
           fifthBG.SetActive(false);
           sixthBG.SetActive(true);
           BG.SetActive(false);
        }
    }
}
