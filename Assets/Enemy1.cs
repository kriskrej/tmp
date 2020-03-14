using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject Player;
    public float speed = 1f;
    public Vector2 pos1;
    public Vector2 pos2;
    private float oldPosition = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);

        if (transform.position.x > oldPosition) // he's looking right
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (transform.position.x < oldPosition) // he's looking left
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        oldPosition = transform.position.x; // update the variable with the new position so we can chack against it next frame
    }

}
