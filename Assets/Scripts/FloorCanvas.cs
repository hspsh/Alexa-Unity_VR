using UnityEngine;
using System.Collections;

public class FloorCanvas : MonoBehaviour
{
    public void RecenterView()
    {
        GvrViewer.Instance.Recenter();
    }

    public void ChangeMode()
    {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
    }
}
