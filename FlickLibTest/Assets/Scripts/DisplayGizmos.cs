using UnityEngine;
using InputUtil;

[System.Serializable]
public class DisplayGizmos : MonoBehaviour {
    
    [SerializeField]
    private bool DrawLine;
    [SerializeField]
    private bool DrawDivisionLine;
    [SerializeField]
    private bool DrawDivisionLabel;
    [SerializeField]
    private float DivisionLineLength = 10.0f;

    [SerializeField]
    private Color TracksColor;
    [SerializeField]
    private Color DivisionColor;
    
    [SerializeField]
    private FlickUtil instance;

    void OnDrawGizmosSelected()
    {
        if (instance == null)
            return;
        Vector2 begin = Camera.main.ScreenToWorldPoint(this.instance.GetBeginPoint);
        Vector2 end = Camera.main.ScreenToWorldPoint(this.instance.GetEndPoint);

        if (DrawLine)
        {
            Gizmos.color = this.TracksColor;

            Gizmos.DrawSphere(end, 0.1f);

            Gizmos.DrawLine(begin, end);
        }

        if (DrawDivisionLine)
        {
            Gizmos.color = this.DivisionColor;

            float margin = 360.0f / this.instance.Quadrant;

            float x = this.instance.OffsetAngle;

            Vector2 center = Vector2.Lerp(begin, end, 0.5f);
            
            Gizmos.DrawSphere(center, 0.1f);
            
            for (int i = 0; i < this.instance.Quadrant; i++)
            {
                Vector2 a = new Vector2(Mathf.Cos(x * Mathf.Deg2Rad), Mathf.Sin(x * Mathf.Deg2Rad));
                Gizmos.DrawLine(center, center + a * DivisionLineLength);
                x += margin;
                if (this.DrawDivisionLabel)
                {
                    Vector2 b = new Vector2(Mathf.Cos(x * Mathf.Deg2Rad), Mathf.Sin(x * Mathf.Deg2Rad));
#if UNITY_EDITOR
                    UnityEditor.Handles.Label(Vector2.Lerp(center + a * DivisionLineLength, center + b * DivisionLineLength, 0.5f), (i + 1).ToString());
#endif
                }
            }
        }
    }
}
