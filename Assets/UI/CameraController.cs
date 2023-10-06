using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float bottomLimit;

    GameObject player;

    public GameObject subScreen;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;


            if (x < leftLimit)
            {
                x = leftLimit;
            }
            else if(x > rightLimit)
            {
                x = rightLimit;
            }
            if (y > topLimit)
            {
                y = topLimit;
            }
            else if (y < bottomLimit)
            {
                y = bottomLimit;
            }

            Vector3 v3 = new(x, y, z);
            transform.position = v3;
            //transform.position = Vector3.Lerp(transform.position, v3, Time.deltaTime);

            if(subScreen != null)
            {
                y = subScreen.transform.position.y;
                z = subScreen.transform.position.z;
                Vector3 v = new(x * 0.5f, y, z);
                subScreen.transform.position = v;
            }
        }

    }
}
