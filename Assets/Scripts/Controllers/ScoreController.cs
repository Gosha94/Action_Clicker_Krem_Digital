using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Класс описывает Контроллер Разрушения здания
/// </summary>
public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private int _scores;

    [SerializeField]
    private Slider _damageSlider;

    void Awake()
    {
        EventAggregator.PartDestroyed.Subscribe(OnPartBuildingDestroyed);
    }

    public void IncrementSliderScore()
    {
        _damageSlider.value++;
    }

    private void OnPartBuildingDestroyed(PartOfBuilding partOfBuilding)
    {        
        //this._scores++;
    }
}