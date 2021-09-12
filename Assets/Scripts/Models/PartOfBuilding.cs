using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс описывает разрушаемую часть здания
/// </summary>
public class PartOfBuilding : MonoBehaviour
{
    /// <summary>
    /// Поле для хранения цельного элемента постройки
    /// </summary>
    [SerializeField]
    private GameObject _solidBuildingPart;

    /// <summary>
    /// Поле для хранения фрагментированного элемента постройки
    /// </summary>
    [SerializeField]
    private GameObject _fractalBuildingPart;

    public void Start()
    {
        this._fractalBuildingPart.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        // Отключаем цельный объект
        this._solidBuildingPart.SetActive(false);        

        SyncroniseBuildingParts();

        // Включаем частичный объект
        this._fractalBuildingPart.SetActive(true);        

        BreakBuildingPart();

        DestroyFractals(3.0f);
    }

    /// <summary>
    /// Метод получения очков за разрушение стены
    /// </summary>
    /// <returns>Кол-во очков (int)</returns>
    public int GetScoreOfDestroyingPart()
        => 5;

    /// <summary>
    /// Ломаем часть здания, на которой было воздействие взрыва
    /// </summary>
    private void BreakBuildingPart()
    {
        this.tag = "BrokenBuildingPart";
        MainSceneController.Instanse.DamageSlider.value += GetScoreOfDestroyingPart();
        PublishEvent();
    }

    /// <summary>
    /// Метод публикует событие об уничтожении стены в канал
    /// </summary>
    private void PublishEvent()
    {
        EventAggregator.PartDestroyed.Publish(this);
    }

    /// <summary>
    /// Метод уничтожает обломки через указанное время
    /// </summary>
    /// <param name="time"></param>
    private void DestroyFractals(float time)
    {
        Destroy(_fractalBuildingPart, time);
    }

    /// <summary>
    /// Метод синхронизирует позиции и поворот объектов скрипта
    /// </summary>
    private void SyncroniseBuildingParts()
    {
        this._fractalBuildingPart.transform.position = this._solidBuildingPart.transform.position;
        this._fractalBuildingPart.transform.rotation = this._solidBuildingPart.transform.rotation;
    }

}