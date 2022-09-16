using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StatsRadarChart : MonoBehaviour
{
    [SerializeField] private Material radarMaterial;
    private Stats stats;
    private CanvasRenderer radarMeshCanvasRenderer;

    private void Awake()
    {
        radarMeshCanvasRenderer = transform.Find("radarMesh").GetComponent<CanvasRenderer>();
    }

    public void SetStats(Stats stats)
    {
        this.stats = stats;
        UpdateStatsVisual();
        //stats.OnStatsChanged += Stats_OnStatsChanged;
    }
    private void Update()
    {
        UpdateStatsVisual();
    }
    /*private void Stats_OnStatsChanged(object sender, System.EventArgs e)
    {
        UpdateStatsVisual();
    }*/
    private void UpdateStatsVisual()
    {
        //transform.Find("masteryBar").localScale = new Vector3(1, stats.GetStatAmountNormalized(Stats.Type.Mastery));
        //transform.Find("troubleshootingBar").localScale = new Vector3(1, stats.GetStatAmountNormalized(Stats.Type.Troubleshooting));

        Mesh mesh = new Mesh();

        Vector3[] vertices = new Vector3[7];
        Vector2[] uv = new Vector2[7];
        int[] triangles = new int[3 * 6];

        float angleIncrement = 360f / 6;
        float radarChartSize = 180f;
        Vector3 masteryVertex = Quaternion.Euler(0, 0, - angleIncrement * 0) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Mastery);
        int masteryVertexIndex = 1;

        Vector3 troubleshootingVertex = Quaternion.Euler(0, 0, - angleIncrement * 1) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Troubleshooting);
        int troubleshootingVertexIndex = 2;

        Vector3 explanationVertex = Quaternion.Euler(0, 0, -angleIncrement * 2) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Explanation);
        int explanationVertexIndex = 3;

        Vector3 selflearningVertex = Quaternion.Euler(0, 0, -angleIncrement * 3) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Selflearning);
        int selflearningVertexIndex = 4;

        Vector3 writingVertex = Quaternion.Euler(0, 0, -angleIncrement * 4) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Writing);
        int writingVertexIndex = 5;

        Vector3 pressureVertex = Quaternion.Euler(0, 0, -angleIncrement * 5) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Pressure);
        int pressureVertexIndex = 6;

        vertices[0] = Vector3.zero;
        vertices[masteryVertexIndex]            = masteryVertex;
        vertices[troubleshootingVertexIndex]    = troubleshootingVertex;
        vertices[explanationVertexIndex]        = explanationVertex;
        vertices[selflearningVertexIndex]       = selflearningVertex;
        vertices[writingVertexIndex]            = writingVertex;
        vertices[pressureVertexIndex]           = pressureVertex;

        triangles[0] = 0;
        triangles[1] = masteryVertexIndex;
        triangles[2] = troubleshootingVertexIndex;

        triangles[3] = 0;
        triangles[4] = troubleshootingVertexIndex;
        triangles[5] = explanationVertexIndex;

        triangles[6] = 0;
        triangles[7] = explanationVertexIndex;
        triangles[8] = selflearningVertexIndex;

        triangles[9] = 0;
        triangles[10] = selflearningVertexIndex;
        triangles[11] = writingVertexIndex;

        triangles[12] = 0;
        triangles[13] = writingVertexIndex;
        triangles[14] = pressureVertexIndex;

        triangles[15] = 0;
        triangles[16] = pressureVertexIndex;
        triangles[17] = masteryVertexIndex;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        radarMeshCanvasRenderer.SetMesh(mesh);
        radarMeshCanvasRenderer.SetMaterial(radarMaterial, null);
    }
}
