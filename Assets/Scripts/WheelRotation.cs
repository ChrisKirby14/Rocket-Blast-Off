using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    [SerializeField] float wheelRotation = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PropellerRotate();
    }
    void PropellerRotate()
    {
        transform.Rotate(Vector3.right * wheelRotation * Time.time);
    }
}
