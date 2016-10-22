using UnityEngine;
using System.Collections;

public class MessageInvoker : MonoBehaviour
{
    [SerializeField]
    private GameObject messageObject;

    private void Awake()
    {
        messageObject.SetActive(false);
    }

    public void OnPointerEnter()
    {
        messageObject.SetActive(true);
    }

    public void OnPointerExit()
    {
        messageObject.SetActive(false);
    }
}
