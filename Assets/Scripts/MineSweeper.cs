using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{

    public bool mine;

    public Sprite[] emptyTextures;
    public Sprite mineTexture;

    // Start is called before the first frame update
    void Start()
    {
        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        Playfield.elements[x, y] = this;
    }

    public void loadTexture(int adjacentCount)
    {
        if (mine)
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        else
            GetComponent<SpriteRenderer>().sprite = emptyTextures[adjacentCount];
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton()
    {
        // It's a mine
        if (mine)
        {
                // Uncover all mines
                Playfield.uncoverMines();

                // game over
                print("you lose");
        }
        else
        {
            int x = (int)transform.position.x; //show adjacent number
            int y = (int)transform.position.y;
            loadTexture(Playfield.adjacentMines(x, y));


            // TODO: uncover area without mines
            // ...

            // TODO: find out if the game was won now
            // ...
        }
    }

}
