using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public GameObject targetObject;

    public float speed = 1.0f;
    public void getAbsorbed()
    {
        if (targetObject != null)
        {
            Vector3 objectPosition = targetObject.transform.position;

            float step = speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, targetObject.transform.position, step);
        }
    }
}    
