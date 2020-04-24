using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float m_force = 10.0f;
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 newvelocitySphere = -collision.contacts[0].normal.normalized * m_force;
        newvelocitySphere.y = 0f;
        collision.gameObject.GetComponent<Rigidbody>().AddForce(newvelocitySphere, ForceMode.Impulse);
        Debug.DrawLine(collision.contacts[0].point, -collision.contacts[0].point + collision.contacts[0].normal * m_force);
    }
}
