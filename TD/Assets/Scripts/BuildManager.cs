using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    //singleton
   public static BuildManager instance;
    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Too many managers!");
            return;
        }
        instance = this;
        
    }

    public GameObject standardTurretPrefab;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    /* public void SetTurretToBuild(GameObject turret)
     {
         turretToBuild = turret;
     }*/

    //property

    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }



    public void BuildTurretOn(Node node )
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Too poor :(");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build money left" + PlayerStats.Money);

    }

    public void SelectNode(Node node)
    {

        if(selectedNode == node)
        {
            DeselectNode();
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;

        DeselectNode();
    }


}
