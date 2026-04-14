using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    public Transform shootingPoint;

    private GameObject blockObject;

    private bool eraser;
    private bool isOverUI;

    private void Update()
    {
        isOverUI = UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();

        if (Input.GetMouseButtonDown(0))
        {
            if (!isOverUI)
            {
                if (!eraser) BuildBlock(blockObject);

                else DestroyBlock();
            }
        }

        //Debug.Log(isOverUI);
    }

    private void BuildBlock(GameObject block)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
        {
            //if (!isOverUI)
            //{
                if (hitInfo.transform.tag == "Block")
                {
                    Vector3 spawnPosition = new Vector3(Mathf.Round((hitInfo.point.x + hitInfo.normal.x / 175) * 40) / 40, Mathf.Round((hitInfo.point.y + hitInfo.normal.y / 175) * 40) / 40, Mathf.Round((hitInfo.point.z + hitInfo.normal.z / 175) * 40) / 40);
                    Instantiate(block.gameObject, spawnPosition, Quaternion.identity);
                }
                else if (hitInfo.transform.tag == "spawnTag")
                {
                    Vector3 spawnPosition = new Vector3(Mathf.Round(hitInfo.point.x * 40) / 40, Mathf.Round(hitInfo.point.y * 40) / 40, Mathf.Round(hitInfo.point.z * 40) / 40);
                    Instantiate(block.gameObject, spawnPosition, Quaternion.identity);
                }
            //}
        }
    }

    private void DestroyBlock()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo))
        {
            //if (!isOverUI)
            //{
                if (hitInfo.transform.tag == "Block")
                {
                    Destroy(hitInfo.transform.gameObject);
                }
            //}
        }
    }

    public void BlockSelect(GameObject block)
    {
        blockObject = block;
        eraser = false;
    }

    public void Eraser()
    {
        eraser = !eraser;
    }
}
