using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformVertices : MonoBehaviour
{
    // Start is called before the first frame update
    // Use this for initialization
    public Vector3 m_vectranslation;
    public Vector3 m_eulerAngles;

    private MeshFilter m_meshfilter;
    private Vector3[] m_originalVertices;
    private Vector3[] m_newVertices;

    private Matrix4x4 m_rotation;
    private Matrix4x4 m_translation;

    void Start()
    {
        m_meshfilter = GetComponent<MeshFilter>();
        m_originalVertices = m_meshfilter.mesh.vertices;
        m_newVertices = new Vector3[m_originalVertices.Length];

        Quaternion rotation = Quaternion.Euler(m_eulerAngles.x, m_eulerAngles.y, m_eulerAngles.z);
        m_rotation = Matrix4x4.Rotate(rotation);
        m_translation = Matrix4x4.Translate(m_vectranslation);
        Matrix4x4 a_matrix = m_rotation * m_translation;  //Transliere zuerst den Cube und dann Rotiere 
        //Matrix4x4 a_matrix = m_translation*m_rotation; //Rotiere zuerst und dann transliere

        for (int i = 0; i < m_originalVertices.Length; i++)
        {
            m_newVertices[i] = a_matrix.MultiplyPoint3x4(m_originalVertices[i]);
        }
        m_meshfilter.mesh.vertices = m_newVertices;
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5;
        float scalefactor = 1;

        for (int i = 0; i < m_meshfilter.mesh.vertices.Length; i++)
        {
            float x_scale = Mathf.Sin(Time.time * m_originalVertices[i].z * speed) * scalefactor + scalefactor + 1;
            float y_scale = Mathf.Cos(Time.time * m_originalVertices[i].x * speed) * scalefactor + scalefactor + 1;
            float z_scale = Mathf.Cos(Time.time * m_originalVertices[i].y * speed) * scalefactor + scalefactor + 1;
            Vector3 scalvector = new Vector3(x_scale, y_scale, z_scale);
            Matrix4x4 a_scalematrix = Matrix4x4.Scale(scalvector);

            Matrix4x4 a_matrix = m_translation * m_rotation * a_scalematrix;

            m_newVertices[i] = a_matrix.MultiplyPoint3x4(m_originalVertices[i]);
        }
        m_meshfilter.mesh.vertices = m_newVertices;
    }
}
