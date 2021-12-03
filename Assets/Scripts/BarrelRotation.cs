using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Credit to ZeveonHD for a helpful tutorial to write this script
// This script is used to rotate the barrel visually, but the barrel was not used
// in our final product
public class BarrelRotation : MonoBehaviour
{
    public Transform pivot;
    public Transform barrel;

    public Tower tower;

    private void Update()
    {
        if (tower != null)
        {
            if (tower.currentTarget != null)
            {
                Vector2 relative = tower.currentTarget.transform.position - pivot.position;
                float angle = Mathf.Atan2(relative.y,relative.x) * Mathf.Rad2Deg;
                Vector3 newRotation = new Vector3(0,0,angle);
                pivot.localRotation = Quaternion.Euler(newRotation);
            }
        }
    }
}
