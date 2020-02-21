using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(Collider))]
public class ObjTrigger : MonoBehaviour
{
    public LayerMask layers;
    public UnityEvent OnEnter, OnExit;
    protected Collider m_Collider;

    void Reset()
    {
        layers = LayerMask.NameToLayer("Everything");
        m_Collider = GetComponent<Collider>();
        m_Collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!enabled)
            return;

        if (layers.Contains(other.gameObject))
        {
            Debug.Log("OnTriggerEnter:"+other.name);
            OnEnter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (!enabled)
            return;

        if (layers.Contains(other.gameObject))
        {
            Debug.Log("OnTriggerExit:" + other.name);
            OnExit.Invoke();
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "trigger", false);
    }
}
