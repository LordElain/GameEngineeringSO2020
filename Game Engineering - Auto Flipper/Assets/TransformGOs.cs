using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformGOs : MonoBehaviour
{
    public Vector3 m_vectranslation;
    public Vector3 m_eulerAngles;
    // Start is called before the first frame update
    void Start()
    {
        //verschiebe den Kindknoten nach rechts und dann rotiere den Elternknoten
        this.transform.position = m_vectranslation;
        this.transform.parent.transform.rotation = Quaternion.Euler(m_eulerAngles.x, m_eulerAngles.y, m_eulerAngles.z);

        //rotiere den Elternknoten (Kindknoten befindet sich noch im Ursprung und wird mitrotiert) und dann verschiebe den Kindknoten nach rechts
        //this.transform.parent.transform.rotation = Quaternion.Euler(m_eulerAngles.x, m_eulerAngles.y, m_eulerAngles.z);
        //this.transform.position = m_vectranslation;
    }
}