using UnityEngine;

public class CamFollowsPlayer : MonoBehaviour
{
    [Header("Set in the inspector")]
    public Transform target;
    public Vector3 offset = new Vector3(0f, 8f, -6f);

    void LateUpdate()
    {
        if (target == null) return;

        transform.position = target.position + offset;
        //transform.LookAt(target);
    }
}
