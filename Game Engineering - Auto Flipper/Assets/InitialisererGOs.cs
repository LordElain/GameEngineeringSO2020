using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialisererGOs : MonoBehaviour
{
    public GameObject m_KugelPrefab;
    public Transform m_SpawnKugelTransform;
    public float m_lifetime = 3.0f;

    private GameObject aKugel;
    private float m_timesincestart = 0;
    // Start is called before the first frame update
    void Awake()
    {
        aKugel = Instantiate(m_KugelPrefab, m_SpawnKugelTransform);
        aKugel.name = "Kugel";
    }

    // Update is called once per frame
    void Update()
    {
        m_timesincestart += Time.deltaTime;
        Debug.Log("Time: " + m_timesincestart);
   
        if(m_timesincestart > m_lifetime)
        {
            Destroy(aKugel);
        }
    }
}
