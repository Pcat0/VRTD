using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Building", menuName = "Building", order = 2)]
public class BuildingType : ScriptableObject {
    public string buildingName;
    [TextArea]
    public string description;
    public int cost;
    public int teir;
    public GameObject preFab;


}
