using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed;

    public int lifetime = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = VacPackAlpha.Instance.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime++;
        transform.position += transform.forward * Speed * Time.deltaTime;
        if (lifetime > 500)
        {
            Destroy(gameObject);
        }
    }
}
