using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodenplatteMesher : MonoBehaviour
{
    //public GameObject m_sphere;
    private GameObject m_sphere;
    public Material m_material; //a material
    private int m_panelindex = 0; //Counts panels
    public float m_radius = 0.5f;
    public float m_radiusoffset = 3.0f;

    void Start()
    {
        //Kugel wurde bereits in "Awake" vom Game Manager instanziiert 
        m_sphere = GameObject.Find("Kugel");
        Debug.Log("KUGEL found: " + m_sphere.name);
    }
    private void AddPanel(Vector3 apose)
    {
        float sizeofmesh = 2.0f;
        GameObject m_floorPanels = new GameObject("GOFloorPanel");
        m_floorPanels.AddComponent<MeshFilter>();
        m_floorPanels.AddComponent<MeshRenderer>();

        m_floorPanels.GetComponent<MeshFilter>().mesh.vertices = new Vector3[]
        {
            new Vector3(-sizeofmesh, 0, -sizeofmesh),//links vorne index 0
            new Vector3(sizeofmesh, 0, sizeofmesh), //rechts hinten index 1
            new Vector3(sizeofmesh, 0, -sizeofmesh), //rechts vorne index 2
            new Vector3(-sizeofmesh, 0, sizeofmesh) //links hinten index 3
        };

        //Unity wird die Vorderseite des Dreiecks festgelegt indem die Reihenfolge der Vertices mit dem Uhrzeigersinn festgelegt wird
        m_floorPanels.GetComponent<MeshFilter>().mesh.uv = new Vector2[] { new Vector2(0, 0), new Vector2(1, 1), new Vector2(1, 0), new Vector2(0, 1) };
        m_floorPanels.GetComponent<MeshFilter>().mesh.triangles = new int[] { 0, 1, 2, 0, 3, 1 };
        m_floorPanels.GetComponent<MeshRenderer>().material = m_material;
        m_floorPanels.GetComponent<Transform>().position = apose;

        m_floorPanels.AddComponent<MeshCollider>();
        m_floorPanels.GetComponent<MeshCollider>().sharedMesh = m_floorPanels.GetComponent<MeshFilter>().mesh;

        //Muss im Editor definiert werden
        m_floorPanels.tag = "TAGfloorpanel";
        //Füge das GO in die Hierachie ein
        m_floorPanels.transform.parent = this.transform;
        m_panelindex++;
        return;
    }
    private void RemovePanel(Vector3 apose)
    {
        foreach (GameObject panel in GameObject.FindGameObjectsWithTag("TAGfloorpanel"))
        {
            float distance = Vector3.Distance(apose, panel.transform.position);
            if (distance > m_radius + m_radiusoffset)
            {
                panel.AddComponent<Rigidbody>();
                Destroy(panel, 2);
            }
        }

        return;
    }

    private void Update()
    {
        Vector3 newpose = m_sphere.transform.position + m_sphere.GetComponent<Rigidbody>().velocity.normalized * m_radius;
        newpose.y = 0.0f;
        AddPanel(newpose);
        RemovePanel(m_sphere.transform.position);
    }
}
