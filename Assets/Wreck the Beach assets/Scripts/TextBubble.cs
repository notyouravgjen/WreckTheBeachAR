using UnityEngine;

public class TextBubble : MonoBehaviour {

    public GameObject backgroundBubble;
    public string text;
    public float timeDisplayedInSec=2;
    public float upOffset;
    public float rightOffset;
    public float forwardOffset=1.5f;
    public float width=.25f;
    public float height=.25f;
    public ActivatedTextBubbles.Trigger triggersOn;
    public float textOffset = -.2f;
    public float textXRotate, textYRotate = 90, textZRotate;
    private GameObject displayedBubble;

    public void Display()
    {
        if (displayedBubble == null)
        {
            displayedBubble = Instantiate(backgroundBubble, new Vector3(transform.position.x - forwardOffset, transform.position.y + upOffset, transform.position.z - rightOffset), Quaternion.Euler(90, 90, 90), transform);
            displayedBubble.transform.localScale = new Vector3(width, 1, height);
            GameObject textMeshObject = new GameObject("TextMeshObject");
            TextMesh textMesh = textMeshObject.AddComponent<TextMesh>();
            WrapText(textMesh, text);
            textMeshObject.transform.SetParent(displayedBubble.transform, false);
            textMesh.transform.rotation = Quaternion.Euler(textXRotate, textYRotate, textZRotate);
            textMesh.alignment = TextAlignment.Center;
            textMesh.anchor = TextAnchor.MiddleCenter;
            textMesh.offsetZ = textOffset;
            textMesh.color = Color.black;
            Destroy(displayedBubble, timeDisplayedInSec);
        }
    }
    void WrapText(TextMesh textMesh, string text)
    {
      string builder = "";
      textMesh.text = "";
      float rowLimit = width * 10f; //find the sweet spot
      string[] parts = text.Split(' ');
        for (int i = 0; i < parts.Length; i++)
        {
            Debug.Log(parts[i]);
            textMesh.text += parts[i] + " ";
            if (textMesh.GetComponent<Renderer>().bounds.extents.x > rowLimit)
            {
                textMesh.text = builder.TrimEnd() + System.Environment.NewLine + parts[i] + " ";
            }
            builder = textMesh.text;
        }
     }
}
