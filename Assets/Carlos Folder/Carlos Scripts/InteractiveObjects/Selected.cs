using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Selected : MonoBehaviour
{
    // Raycast Variables
    LayerMask mask;
    public float distancia = 1.5f;

    // UI Variables
    public Texture2D puntero;
    public GameObject TextDetect;
    GameObject ultimoReconocido = null;


    private void Start()
    {
        mask = LayerMask.GetMask("RaycastDetect");
        TextDetect.SetActive(false);
    }

    private void Update()
    {
        //Raycast(Origen, direccion, out hit, distancia, mascara)

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),
            out hit, distancia, mask))
        {
            Deselect();
            SelectedObject(hit.transform);
            if (hit.collider.tag == "Paper")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //hit.collider.transform.GetComponent<SCRIPT>().FUNCION();
                    hit.collider.transform.GetComponent<InteractivePaper>().ActivarObjeto();
                }
            }

            if (hit.collider.tag == "Door")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //hit.collider.transform.GetComponent<SCRIPT>().FUNCION();
                    hit.collider.transform.GetComponent<InteractiveDoor>().ActivarObjeto();
                }
            }

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distancia, Color.red);
        }
        else
        {
            Deselect();
        }
    }

    void SelectedObject(Transform transform)
    {
        transform.GetComponent<MeshRenderer>().material.color = Color.gray;
        ultimoReconocido = transform.gameObject;
    }

    void Deselect()
    {
        if (ultimoReconocido)
        {
            ultimoReconocido.GetComponent<Renderer>().material.color = Color.white;
            ultimoReconocido = null;
        }
    }

    private void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);

        if (ultimoReconocido)
        {
            TextDetect.SetActive(true);
        }
        else
        {
            TextDetect.SetActive(false);
        }
    }
}
