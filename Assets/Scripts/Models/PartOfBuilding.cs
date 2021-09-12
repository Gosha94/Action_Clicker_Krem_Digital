using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ����� ��������� ����������� ����� ������
/// </summary>
public class PartOfBuilding : MonoBehaviour
{
    /// <summary>
    /// ���� ��� �������� �������� �������� ���������
    /// </summary>
    [SerializeField]
    private GameObject _solidBuildingPart;

    /// <summary>
    /// ���� ��� �������� ������������������ �������� ���������
    /// </summary>
    [SerializeField]
    private GameObject _fractalBuildingPart;

    public void Start()
    {
        this._fractalBuildingPart.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        // ��������� ������� ������
        this._solidBuildingPart.SetActive(false);        

        SyncroniseBuildingParts();

        // �������� ��������� ������
        this._fractalBuildingPart.SetActive(true);        

        BreakBuildingPart();

        DestroyFractals(3.0f);
    }

    /// <summary>
    /// ����� ��������� ����� �� ���������� �����
    /// </summary>
    /// <returns>���-�� ����� (int)</returns>
    public int GetScoreOfDestroyingPart()
        => 5;

    /// <summary>
    /// ������ ����� ������, �� ������� ���� ����������� ������
    /// </summary>
    private void BreakBuildingPart()
    {
        this.tag = "BrokenBuildingPart";
        MainSceneController.Instanse.DamageSlider.value += GetScoreOfDestroyingPart();
        PublishEvent();
    }

    /// <summary>
    /// ����� ��������� ������� �� ����������� ����� � �����
    /// </summary>
    private void PublishEvent()
    {
        EventAggregator.PartDestroyed.Publish(this);
    }

    /// <summary>
    /// ����� ���������� ������� ����� ��������� �����
    /// </summary>
    /// <param name="time"></param>
    private void DestroyFractals(float time)
    {
        Destroy(_fractalBuildingPart, time);
    }

    /// <summary>
    /// ����� �������������� ������� � ������� �������� �������
    /// </summary>
    private void SyncroniseBuildingParts()
    {
        this._fractalBuildingPart.transform.position = this._solidBuildingPart.transform.position;
        this._fractalBuildingPart.transform.rotation = this._solidBuildingPart.transform.rotation;
    }

}