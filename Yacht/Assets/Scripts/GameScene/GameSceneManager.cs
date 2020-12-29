using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameSceneManager : MonoBehaviour
{
    public Sprite[] Dice;
    public Image[] RollDice;

    private int[] diceStates = new int[5];
    private int[] diceNumber = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<5; i++)
        {
            diceStates[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D ray = new Ray2D(pos, Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 1000);

            if (hit && hit.transform.gameObject.tag == "Dice")
            {
                int index = int.Parse(hit.transform.gameObject.name) - 1;
                if (diceStates[index] == 0)
                {
                    diceStates[index] = 1;
                    hit.transform.position = new Vector2(hit.transform.position.x, hit.transform.position.y - 150);
                }
                else
                {
                    diceStates[index] = 0;
                    hit.transform.position = new Vector2(hit.transform.position.x, hit.transform.position.y + 150);
                }
            }
        }
    }

    public void Roll()
    {
        for(int i=0; i<5; i++)
        {
            if(diceStates[i] == 0)
            {
                diceNumber[i] = Random.Range(1, 7);
                RollDice[i].sprite = Dice[diceNumber[i] - 1];
            }
        }
    }
}
