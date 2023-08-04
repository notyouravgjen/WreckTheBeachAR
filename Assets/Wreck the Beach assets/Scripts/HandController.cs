using UnityEngine;

public class HandController : MonoBehaviour
{
	[SerializeField]
	private int rotationAngle;

	private bool handsDown;

    void Start ()
	{
		handsDown = false;
	}

    public void ApplyInput()
    {
		if (!GameManager.instance.interactionDisabled)
		{
			if (!handsDown)
			{
				transform.Rotate(rotationAngle, 0, 0);
				handsDown = true;
			}
			else
			{
				transform.Rotate(rotationAngle * -1, 0, 0);
				handsDown = false;
			}
		}
        else if (handsDown)
        {
            transform.Rotate(rotationAngle * -1, 0, 0);
            handsDown = false;
        }
    }
}
