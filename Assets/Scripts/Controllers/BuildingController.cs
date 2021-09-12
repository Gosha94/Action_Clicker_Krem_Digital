using UnityEngine;

public class BuildingController : MonoBehaviour
{    
    private GameObject[] _buildingsOnScene;

    private void Awake()
    {
        this._buildingsOnScene = GameObject.FindGameObjectsWithTag("Building");

        ChangeVisibilityBuildingsOnScene(false);
    }

    void Update()
    {
        var isStart = MainSceneController.Instanse.IsGameStarted;
        ChangeVisibilityBuildingsOnScene(isStart);
    }

    /// <summary>
    /// Метод управляет видимостью строений на сцене
    /// </summary>
    private void ChangeVisibilityBuildingsOnScene(bool state)
    {
        foreach (var building in _buildingsOnScene)
        {
            building.SetActive(state);
        }
    }

}
