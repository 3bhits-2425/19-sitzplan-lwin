using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private TableLayoutData tableLayout; //Ref zu TableLayout ScriptableObject
    [SerializeField] private StudentData[] students; //
    [SerializeField] private GameObject tablePrefab; //Prefab für Tisch
    [SerializeField] private GameObject chairPrefab; //Prefab für Stuhl

    // Start is called before the first frame update
    void Start()
    {
        for (int row = 0; row < tableLayout.rows; row++)
        {
            for (int col = 0; col < tableLayout.columns; col++)
            {
                Vector3 tablePosition = new Vector3(col * tableLayout.tableSpacing, 0, row * tableLayout.tableSpacing);
                GameObject table = Instantiate(tablePrefab, tablePosition, Quaternion.identity, transform);

                // Stühle platzieren
                Transform pos1 = table.transform.Find("Position1");
                Transform pos2 = table.transform.Find("Position2");

                if (pos1)
                {
                    GameObject chair = Instantiate(chairPrefab, pos1.position, pos1.rotation, table.transform);
                }

                if (pos2)
                {
                    GameObject chair = Instantiate(chairPrefab, pos2.position, pos2.rotation, table.transform);
                }
            }
        }
    }
}
