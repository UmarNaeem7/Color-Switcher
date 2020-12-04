using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowThrough : MonoBehaviour
{
    public Transform ballLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //scroll camera upwards
        if (ballLocation.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, ballLocation.position.y, transform.position.z);
            return;
        }

        //ball falls below camera view, then game over so reload scene
        if (ballLocation.position.y < (transform.position.y - Camera.main.orthographicSize))
        {
            SceneManager.LoadScene(0);
        }
    }
}
