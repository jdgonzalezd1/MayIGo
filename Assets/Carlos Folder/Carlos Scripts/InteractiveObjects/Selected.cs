using UnityEngine;

public class Selected : MonoBehaviour
{
    // Raycast Variables
    LayerMask mask;
    public float distancia = 1.5f;

    // UI Variables
    public Texture2D puntero;
    public GameObject TextDetect;
    public GameObject BoxDetect;
    GameObject ultimoReconocido = null;


    private void Start()
    {
        mask = LayerMask.GetMask("RaycastDetect");
        TextDetect.SetActive(false);
        BoxDetect.SetActive(false);
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

            if (hit.collider.tag == "Box")
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //hit.collider.transform.GetComponent<SCRIPT>().FUNCION();
                    hit.collider.transform.GetComponent<InteractiveBox>().ActivarEmpuje();
                }
                else
                {
                    hit.collider.transform.GetComponent<InteractiveBox>().DesactivarEmpuje();

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

            if (ultimoReconocido.GetComponent<InteractiveBox>())
            {
                ultimoReconocido.GetComponent<InteractiveBox>().DesactivarEmpuje();
            }

            ultimoReconocido = null;
        }
    }

    private void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, puntero.width, puntero.height);
        GUI.DrawTexture(rect, puntero);

        if (ultimoReconocido)
        {
            if(ultimoReconocido.tag == "Box")
            {
                BoxDetect.SetActive(true);
            }
            else
            {
                TextDetect.SetActive(true);
            }
        }
        else
        {
            TextDetect.SetActive(false);
            BoxDetect.SetActive(false);
        }
    }
}
