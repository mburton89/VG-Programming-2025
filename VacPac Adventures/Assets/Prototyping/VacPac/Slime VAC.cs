using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public void getAbsorbed()
    {
        Destroy(this.gameObject);
    }
}
