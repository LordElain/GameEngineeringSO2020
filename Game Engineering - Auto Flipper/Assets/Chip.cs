using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chip : MonoBehaviour
{
    // Start is called before the first frame update
    public float m_rotationspeed = 10.0f;
    void Update()
    {
        this.transform.rotation *= Quaternion.Euler(Time.deltaTime * m_rotationspeed, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SCORE!!!!!!!!!!!");
        //Handle collection points here!
        Destroy(this.gameObject);
    }

}
