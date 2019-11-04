using UnityEngine;

public class ParentOnTrigger : MonoBehaviour
{
    public LayerMask mask = -1;
    private Vector3 globalScale;

    private bool InMask(Collider collider)
    {
        return ((mask.value & (1 << collider.gameObject.layer)) > 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if(InMask(other)) {
            globalScale = other.transform.localScale;
            other.transform.SetParent(transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(InMask(other) && other.transform.parent == transform) {
            other.transform.SetParent(null);
            if(globalScale != null) {
                other.transform.localScale = globalScale;
            }
        }
    }

}
