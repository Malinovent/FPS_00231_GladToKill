using System.Collections.Generic;
using UnityEngine;

//Gerer le pistolet
public class Pistolet : WeaponBase
{
    Camera camera;

    private List<Vector3> hitPoints = new List<Vector3>();

    private void Awake()
    {
        camera = Camera.main;
    }

    public override void OnFirePressed()
    {

        //float xCenter = Screen.width / 2;
        //float yCenter = Screen.height / 2;

        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if( Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log($"I hit {hit.collider.name}.");
            hitPoints.Add(hit.point);
        }

    }

    public override void OnReload()
    {
        throw new System.NotImplementedException();
    }

    //Dessiner dans la scene
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray;

        if (!Application.isPlaying)
            return;

        //if (Camera.main)
        //{
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //}

        //ray = new Ray(transform.position, transform.forward);
        

        Vector3 worldPosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Gizmos.DrawLine(worldPosition, worldPosition + (transform.forward * 100));

        Gizmos.color = Color.blue;
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Gizmos.DrawSphere(hit.point, 0.25f);
        }

        Gizmos.color = Color.green;
        foreach(Vector3 point in hitPoints)
        {
            Gizmos.DrawSphere(point, 0.25f);
        }
    }

    public override void UpdateWeapon()
    {
        throw new System.NotImplementedException();
    }

    public override void OnFireReleased()
    {
        throw new System.NotImplementedException();
    }
}