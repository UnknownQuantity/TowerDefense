using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;

    BuildManager buildManager;

     void Start()
    {
        buildManager = BuildManager.instance;
    }


    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);

    }

}
