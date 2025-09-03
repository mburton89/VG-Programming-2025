using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
  // Start is called before the first frame update
  public static MainCamera Instance;

  public Vector3 rotation;

  public Vector3 position = new Vector3(0, 0, -10f);


  private void Awake()
  {
    Instance = this;
  }
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.rotation = Quaternion.Euler(rotation);
    transform.position = position;

    if (rotation.y > 0.002f)
    {
      rotation.y -= 0.005f;
    }

    else if (rotation.y < -0.002f)
    {
      rotation.y += 0.005f;
    }

    if (position.z < -10.003f)
    {
      position.z += 0.0025f;
    }




  }
}
