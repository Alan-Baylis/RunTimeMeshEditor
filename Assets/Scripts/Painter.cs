using UnityEngine;
using System.Collections;

public class Painter : MonoBehaviour {

    public GameObject canvasObject;
    //public string[] colors;
    public Color[] color;
    Transform canvas;
	// Use this for initialization
	void Start () {
        canvas = canvasObject.transform;
        Mesh mesh = canvas.GetComponent<MeshFilter>().mesh;
        //Debug.Log(mesh.colors32.Length);
        //for (int i = 0; i < mesh.vertices.Length; i++)
        //{
        //    Debug.Log("Vertex Number : " + mesh.vertices[i] + "\n");
        //}
        //for (int i = 0; i < mesh.triangles.Length; i++)
        //{
        //    //Debug.Log("Triangle Number : " + mesh.triangles[i] + "\n");
        //}
        //color = new Color[6];
        Vector3[] vertices = mesh.vertices;
        color = new Color[vertices.Length];
        Debug.Log(vertices.Length);
        int i = 0;
        //while (i < vertices.Length)
        //{
        //    color[i] = Color.white;
        //    i++;
        //}
        //mesh.colors = color;
        //Debug.Log(mesh.colors.Length);


        //mesh.colors[0] = Color.white;
        //mesh.colors[1] = Color.white;
        //mesh.colors[2] = Color.white;
        //Debug.Log(mesh.colors[0].ToString());
        ////mesh.colo
        //while (i < vertices.Length)
        //{
        //    color[i] = mesh.colors[i];
        //    i++;
        //}

    }

    // Update is called once per frame

    void RecreateMesh(int index, Vector3 vertices)
    {
        Destroy(canvas.GetComponent<MeshCollider>());
        Mesh mesh = canvas.GetComponent<MeshFilter>().mesh;
        int[] oldTriangles = mesh.triangles;
        int[] newTriangles = new int[mesh.triangles.Length - 3];
        int j = 0;
        int i = 0;
        //mesh.triangles[index*3].colo
        while(j<mesh.triangles.Length)
        { 
            if (j != index*3) {
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
                newTriangles[i++] = oldTriangles[j++];
                //j = j + 2;
                //Debug.Log("i" + i + "j " + j);
            }
            else
            {
                //Debug.Log("Vertcies of triangle : " + mesh.vertices[mesh.triangles[j]] + mesh.vertices[mesh.triangles[j+1]] + mesh.vertices[mesh.triangles[j+2]]);
                //Mesh tempMesh = new Mesh();
                //int[] tempTriangles = new int[3];
                //Vector3[] tempVertices = new Vector3[3];
                //for (int x = 0; x < 3; x++)
                //{
                //   tempTriangles[x] = mesh.triangles[j + x];
                //   tempVertices[x] = mesh.vertices[mesh.triangles[j]];
                //}
                //mesh.Clear();
                //tempMesh.triangles = 
                j += 3;
            }
        }
        //Debug.Log(mesh.colors32.Length);
        // mesh.colors[0] = color[0];
        //mesh.colors = color;
        //Debug.Log(mesh.vertices[mesh.triangles[index]] + "baycentric vertices" + vertices);
        canvas.GetComponent<MeshFilter>().mesh.triangles = newTriangles;
        canvasObject.AddComponent<MeshCollider>();
    }
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.DrawRay();
            if (Physics.Raycast(ray,out hit,1000.0f))
            {
                //Debug.Log(hit.triangleIndex);
                RecreateMesh(hit.triangleIndex, hit.barycentricCoordinate);
               
                //RecreateMesh(hit.triangleIndex);

                //if(hit.triangleIndex%2 != 0)
                //{
                //    RecreateMesh(hit.triangleIndex+1);
                //}
                //else
                //{
                //    RecreateMesh(hit.triangleIndex-1);
                //}
            }

        }


    }
}
