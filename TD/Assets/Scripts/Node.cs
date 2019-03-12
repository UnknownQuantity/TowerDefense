using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    private Renderer rend;
    private Color startColor;

    [Header ("Optional")]
    public GameObject turret;

    BuildManager buildManager;

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        buildManager.BuildTurretOn(this);

    }


    private void Start()
    {
        rend = GetComponent<Renderer>();

        buildManager = BuildManager.instance;
    }


    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {


            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;

        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
