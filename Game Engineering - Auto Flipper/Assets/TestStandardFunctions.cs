using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStandardFunctions : MonoBehaviour
{
    // Start is called before the first frame update

    private void Awake()
    {
        Debug.Log("Awake called");
    }
    void Start()
    {
        Debug.Log("Start called");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate called");
    }

    private void LateUpdate()
    {
        Debug.Log("LateUpdate called");
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update called");
    }
}
