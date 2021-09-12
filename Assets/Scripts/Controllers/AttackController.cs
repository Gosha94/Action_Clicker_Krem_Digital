using UnityEngine;

public class AttackController : MonoBehaviour
{

    [SerializeField]
    private GameObject _explosion;

    [SerializeField]
    private Camera _mainCamera;
   
    private int _leftMouseButton = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                RaycastHit raycastHit;
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out raycastHit))
                {
                    Instantiate(_explosion, raycastHit.point, Quaternion.identity);
                }
            }
        }
    }
}