using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMovement : MonoBehaviour {

    void Update()
    {
        transform.Rotate(0, 0, 60 * Time.deltaTime);
    }


}


