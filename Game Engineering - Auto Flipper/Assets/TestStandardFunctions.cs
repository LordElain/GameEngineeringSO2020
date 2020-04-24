using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStandardFunctions : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 m_vectranslation;
    public Vector3 m_eulerAngles;
    private MeshFilter m_meshfilter;
    private Vector3[] m_originalVertices;
    private Vector3[] m_newVertices;
    void Start()
    {
        m_meshfilter = GetComponent<MeshFilter>();
        m_originalVertices = m_meshfilter.mesh.vertices;
        m_newVertices = new Vector3[m_originalVertices.Length];
        Quaternion rotation = Quaternion.Euler(m_eulerAngles.x, m_eulerAngles.y, m_eulerAngles.z);
        Matrix4x4 m_rotation = Matrix4x4.Rotate(rotation);
        Matrix4x4 m_translation = Matrix4x4.Translate(m_vectranslation);
        //Matrix4x4 a_matrix = m_rotation * m_translation; //Transliere zuerst den Cube und dann Rotiere
        Matrix4x4 a_matrix = m_translation * m_rotation; //Rotiere zuerst und dann transliere
        for (int i = 0; i < m_originalVertices.Length; i++)
        {
            m_newVertices[i] = a_matrix.MultiplyPoint3x4(m_originalVertices[i]);
        }
        m_meshfilter.mesh.vertices = m_newVertices;
    }
}
