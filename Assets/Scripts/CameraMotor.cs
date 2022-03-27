using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    [SerializeField]
    private Transform lookAt;
    [SerializeField]
    private float boundX = 0.15f;
    [SerializeField]
    private float boundY = 0.15f;

    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float deltaX = lookAt.position.x - transform.position.x;

        if (Mathf.Abs(deltaX) > boundX)
        {
            delta.x = deltaX - Mathf.Sign(deltaX) * boundX;

        }

        float deltaY = lookAt.position.y - transform.position.y;

        if (Mathf.Abs(deltaY) > boundY)
        {
            delta.y = deltaY - Mathf.Sign(deltaY) * boundY;
        }

        transform.position += delta;
    }
}