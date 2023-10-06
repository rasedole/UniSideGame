using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Sprite leverOn;
    public GameObject[] removeGameObject;
    public GameObject[] addGameObject;

    private void Start()
    {
        foreach(GameObject go in addGameObject) 
        {
            go.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && GetComponent<SpriteRenderer>().sprite != leverOn)
        {
            GetComponent<SpriteRenderer>().sprite = leverOn;
            foreach(GameObject go in removeGameObject)
            {
                go.SetActive(false);
            }
            foreach(GameObject go in addGameObject)
            {
                go.SetActive(true);
            }
        }
    }
}
