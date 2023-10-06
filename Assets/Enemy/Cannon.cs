using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cannon : MonoBehaviour
{
    public GameObject shell;
    public float shootTime = 3.0f;
    public GameObject shootTransform;
    float currentTime;

    private void Start()
    {
        currentTime = 0;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if( currentTime > shootTime )
        {
            Instantiate( shell );
            shell.transform.position = shootTransform.transform.position;
            shell.GetComponent<Shell>().direction = Vector2.left;
            currentTime = 0;
        }
    }

}
