using UnityEngine;
using JetBrains.Annotations;

public class ControllerAttach : MonoBehaviour
{
    public GameObject ToAttach;
    public string DestChild = "trackhat";
    
    [UsedImplicitly]
	private void Update()
	{
	    var child = transform.FindChild(DestChild);
	    if (child == null) return;

	    ToAttach.transform.SetParent(child.FindChild("attach"), false);

	    Destroy(this);
	}
}
