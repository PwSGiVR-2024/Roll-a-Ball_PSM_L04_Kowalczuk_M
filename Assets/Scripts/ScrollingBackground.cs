using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private enum direction { x, y, z };
    [SerializeField] private Transform endPoint, startPoint;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private direction movementAxis;
    private bool axisDirection; // if moves along axis 1, if in opposite direction 0

    private void ResetPosition()
    {
        transform.position = startPoint.position + (!axisDirection ? (transform.position - endPoint.position) : (endPoint.position - transform.position));
    }
    private void Start()
    {
        switch (movementAxis)
        {
            case direction.x:
                if(velocity.x >=0)
                {
                    axisDirection = true;
                }
                else
                {
                    axisDirection = false;
                }
                break;
            case direction.y:
                if (velocity.y >= 0)
                {
                    axisDirection = true;
                }
                else
                {
                    axisDirection = false;
                }
                break;
            case direction.z:
                if (velocity.z >= 0)
                {
                    axisDirection = true;
                }
                else
                {
                    axisDirection = false;
                }
                break;
        }
    }
    private void Update()
    {
        transform.position += velocity * Time.deltaTime;
        switch (movementAxis)
        {
            case direction.x:
                if((transform.position.x >= endPoint.position.x && axisDirection) || (transform.position.x <= endPoint.position.x && !axisDirection))
                {
                    ResetPosition();
                }
                break;
            case direction.y:
                if ((transform.position.y >= endPoint.position.y && axisDirection) || (transform.position.y <= endPoint.position.y && !axisDirection))
                {
                    ResetPosition();
                }
                break;
            case direction.z:
                if ((transform.position.z >= endPoint.position.z && axisDirection) || (transform.position.z <= endPoint.position.z && !axisDirection))
                {
                    ResetPosition();
                }
                break;
        }
    }
}
