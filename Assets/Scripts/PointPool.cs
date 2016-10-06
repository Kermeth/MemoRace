using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PointPool : MonoBehaviour {

    /// <summary>
    /// Point Prefab
    /// </summary>
    public GameObject pointPrefab;

    private RectTransform gamePanel
    {
        get
        {
            return this.GetComponent<RectTransform>();
        }
    }

    void Start()
    {
        GeneratePoint();
    }

    public void GeneratePoint()
    {
        GameObject newPoint = Instantiate(pointPrefab);
        newPoint.GetComponent<RectTransform>().SetParent(gamePanel);
    }

}
