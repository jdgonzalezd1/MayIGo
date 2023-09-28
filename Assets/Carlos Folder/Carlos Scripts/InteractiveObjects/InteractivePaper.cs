using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractivePaper : MonoBehaviour
{
    public void ActivarObjeto()
    {
        GameManager.Instance.PaperTake();
        Destroy(gameObject);
    }
}
