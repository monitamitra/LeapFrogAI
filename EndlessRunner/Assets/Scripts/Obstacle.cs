using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float endOfScreen;

    // Start is called before the first frame update
    void Start()
    {
        endOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * GameManagerScript.myGameManager.gameSpeed * Time.deltaTime;
        if (transform.position.x < endOfScreen)
        {
            Destroy(gameObject);
        }
    }
}
