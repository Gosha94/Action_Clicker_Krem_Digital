using UnityEngine;

public class DestroyingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DestroyObjectAfterStart(3);
    }

    /// <summary>
    /// ����� ���������� ������� ������, ����������� � ������� �������
    /// </summary>
    /// <param name="seconds">�����, ����� ������� ���������� ����������� �������</param>
    void DestroyObjectAfterStart(int seconds)
    {
        Destroy(this.gameObject, seconds);
    }

}
