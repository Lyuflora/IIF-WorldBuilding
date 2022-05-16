using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportController : MonoBehaviour
{
	public Camera myCam;
	public Transform player;
	public Image cursor;
	public bool isTeleporting = false;
	private void Update()
	{

        if (!isTeleporting)
        {
			GetComponent<CharacterController>().enabled = true;
        }
        else
        {
			GetComponent<CharacterController>().enabled = false;
		}

        if (Input.GetKeyDown(KeyCode.T))
        {
			isTeleporting = !isTeleporting;
        }

		if (isTeleporting == false) return;

		RaycastHit hit;
		Vector3 rayOrigin = myCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.5f));
		Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, Mathf.Infinity))
		{
			TeleportTarget target = hit.collider.GetComponent<TeleportTarget>();
			if(target != null)
            {
				cursor.enabled = true;
            }
            else
            {
				cursor.enabled = false;
				return;
            }
			if (Input.GetMouseButton(0))
            {
				Debug.Log("Teleport to target");
				player.position = target.transform.position;
				player.rotation = target.transform.rotation;
            }
		}
	}
}
