using UnityEngine;

public class GroundController : MonoBehaviour
{

    private void OnCollisionExit(Collision otherCollision)
    {
        Destroy(otherCollision.gameObject);
    }

}
