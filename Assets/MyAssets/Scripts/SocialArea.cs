using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class SocialArea : MonoBehaviour
{
    public Color gizmoColor = new Color(255, 0, 0, 0.70f);
    public Color gizmoWireColor = new Color(1, 1, 1, 0.8f);

    void OnDrawGizmos()
    {
        SphereCollider collider = GetComponent<SphereCollider>();
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.color = gizmoColor;
        Gizmos.DrawSphere(collider.center, collider.radius);
        Gizmos.color = gizmoWireColor;
        Gizmos.DrawWireSphere(collider.center, collider.radius);
        Gizmos.matrix = Matrix4x4.identity;
    }
}
