using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPropeller : MonoBehaviour
{
    [SerializeField] float propeller = 1f;
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
        transform.Rotate(Vector3.forward * propeller);
    }
}
