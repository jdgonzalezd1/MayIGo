using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveDoor : MonoBehaviour
{
    public void ActivarObjeto()
    {
        if (GameManager.Instance.isPaperTaken)
        {
            Debug.Log("Has logrado cagar");
            GameManager.Instance.CancelInvoke();
        }
        else
        {
            Debug.Log("No hay papel, ve a buscarlo!!!");
        }
    }
}
