using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBG : MonoBehaviour
{
    public Sprite BG;
    public Sprite firstBG;
    public Sprite secondBG;
    public Sprite thirdBG;
    public Sprite fourthBG;
    public Sprite fifthBG;
    public Sprite sixthBG;
    public SpriteRenderer spriteRenderer;

    [SerializeField] float timer = 0;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= 4)
        {
           this.spriteRenderer.sprite = firstBG;
        }

        if (timer >= 9)
        {
            this.spriteRenderer.sprite = secondBG;
        }

        if (timer >= 19)
        {
            this.spriteRenderer.sprite = thirdBG;
        }

        if (timer >= 24)
        {
            this.spriteRenderer.sprite = fourthBG;

            if (timer >= 26) {
                this.spriteRenderer.sprite = fifthBG;
            }
        }

        if (timer >= 28)
        {
            this.spriteRenderer.sprite = BG;
        }

        if (timer >= 37)
        {
            this.spriteRenderer.sprite = sixthBG;
        }
    }
}
