using UnityEngine;
using UnityEngine.UI;

public class BuildingDamageProgressBarScript : MonoBehaviour
{
    private Slider _slider;
    private ScoreController _scoreController;

    [SerializeField]
    private Text _percentageText;

    private void Awake()
    {
        this._slider = gameObject.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        this._percentageText.text = (int)this._slider.value + "%";
    }
}