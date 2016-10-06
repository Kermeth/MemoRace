using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

    //For Test
    void Start()
    {
        StartCoroutine(GeneratePointAfterScreenRefresh());
    }
    //For Test
    private IEnumerator GeneratePointAfterScreenRefresh()
    {
        yield return new WaitForEndOfFrame();
        GenerateRound();
    }

    public void GenerateRound()
    {
        GameManager.Instance.round++;
        if (GameManager.Instance.pointsInRound == null)
        {
            GameManager.Instance.pointsInRound = new List<PointController>();
        }
        else
        {
            GameManager.Instance.pointsInRound.Clear();
        }
        for(int i = 1; i <= GameManager.Instance.round; i++)
        {
            PointController point = GeneratePoint();
            point.SetNumber(i);
            GameManager.Instance.pointsInRound.Add(point);
        }
        GameManager.Instance.ChangeRoundState(RoundState.Generating);
    }

    public void PlayRound()
    {
        foreach(PointController point in GameManager.Instance.pointsInRound)
        {
            point.Disapear();
        }
        GameManager.Instance.ChangeRoundState(RoundState.Playing);
    }

    public PointController GeneratePoint()
    {
        GameObject newPoint = Instantiate(pointPrefab);
        newPoint.GetComponent<RectTransform>().SetParent(gamePanel);
        newPoint.transform.localPosition = GenerateRandomPointInsidePanel();
        return newPoint.GetComponent<PointController>();
    }

    private Vector3 GenerateRandomPointInsidePanel()
    {
        Vector3 newPosition = new Vector3(
            Random.Range(gamePanel.rect.xMin + (pointPrefab.GetComponent<RectTransform>().rect.width /2), gamePanel.rect.xMax) - (pointPrefab.GetComponent<RectTransform>().rect.width / 2),
            Random.Range(gamePanel.rect.yMin + (pointPrefab.GetComponent<RectTransform>().rect.height / 2), gamePanel.rect.yMax - (pointPrefab.GetComponent<RectTransform>().rect.height / 2)),
            0);
        return newPosition;
    }

}
