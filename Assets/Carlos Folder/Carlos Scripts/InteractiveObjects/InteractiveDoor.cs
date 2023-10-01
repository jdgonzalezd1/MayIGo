using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InteractiveDoor : MonoBehaviour
{
    public GameObject noPaperMessage;

    private void Awake()
    {
        noPaperMessage.SetActive(false);
    }
    public void ActivarObjeto()
    {
        if (GameManager.Instance.isPaperTaken)
        {
            Debug.Log("Has logrado cagar");

            GameManager.Instance.CancelInvoke();

            EndMenu();
        }
        else
        {
            StartCoroutine("PaperMessage");
            Debug.Log("No hay papel, ve a buscarlo!!!");
        }
    }

    public void EndMenu()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator PaperMessage()
    {
        noPaperMessage.SetActive (true);
        yield return new WaitForSeconds(4f);
        noPaperMessage.SetActive(false);
    }
}
