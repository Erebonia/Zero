using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float ghostDelay;
    private float ghostDelaySeconds;
    public GameObject ghost;
    public bool makeGhost;

    // Start is called before the first frame update
    void Start()
    {
        ghostDelaySeconds = ghostDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (makeGhost == true)
        {
            if (ghostDelaySeconds > 0)
            {
                ghostDelaySeconds -= Time.deltaTime;
            }
            else
            {
                //Create instance in game.
                GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);

                //Grab the sprite renderer and store it as a variable.
                Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;

                //Grab the CURRENT sprite that is in use in game and that will become the ghost.
                currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;

                //Destroy duplicate instantiated ghosts.
                Destroy(currentGhost, 1f);

                ghostDelaySeconds = ghostDelay;

                //Turn off making the ghost. Lest we infinitely spawn them.
                makeGhost = false;
            }
        }


    }
}
