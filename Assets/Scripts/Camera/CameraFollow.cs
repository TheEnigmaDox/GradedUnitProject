using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //max 4.27, 4
    //min -4.27, -4

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
    }
}
