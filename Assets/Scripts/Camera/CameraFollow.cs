using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    //Size 2 
    //maxPos 52.4, -115
    //minPos 32.6, -135

    //size 5
    //maxPos 47, -118
    //minPos 38, -131.9

    //size 7
    //maxPos 43.5, -120
    //minPos 41.5, -129.9

    [SerializeField] float lerpTime = 1f;

    [SerializeField] Vector2 minPos;
    [SerializeField] Vector2 maxPos;
    Vector3 offSet = new Vector3(0, 0, -10);


    Transform myTransform;
    [SerializeField] Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                target.position.y, transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, lerpTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minPos.x, maxPos.x),
            Mathf.Clamp(transform.position.y, minPos.y, maxPos.y),
            transform.position.z);

        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            switch (GetComponent<Camera>().orthographicSize)
            {
                case 2:
                    maxPos = new Vector2(52.4f, -115f);
                    minPos = new Vector2(32.6f, -135f);
                    break;
                case 5:
                    maxPos = new Vector2(47f, -118f);
                    minPos = new Vector2(38f, -131.9f);
                    break;
                case 7:
                    maxPos = new Vector2(43.5f, -120f);
                    minPos = new Vector2(41.5f, -129.9f);
                    break;
            }
        }
    }
}
