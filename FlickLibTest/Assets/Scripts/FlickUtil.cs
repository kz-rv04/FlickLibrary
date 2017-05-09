using UnityEngine;

enum FlickState
{
    FREE,
    FLICKING,
}
public enum FlickDirection
{
    UP,
    DOWN,
    LEFT,
    RIGHT,
    TAP
}
namespace InputUtil
{
    public class FlickUtil :MonoBehaviour
    {
        [SerializeField]
        private FlickState state = FlickState.FREE;

        // フリック判定のための座標
        private Vector2 beginPoint, endPoint;
        // フリック判定の距離
        [SerializeField,Range(10.0f,Mathf.Infinity)]
        private float flickLength = 100.0f;
        // 分割する象限の数
        [SerializeField,Range(3,360)]
        private int quadrant = 3;
        [SerializeField, Range(0.0f, 360.0f)]
        private float offsetAngle = 0.0f;

        // ボタン押下時の処理
        #region
        public void OnButtonDown()
        {
            if (state == FlickState.FREE)
            {
                state = FlickState.FLICKING;
                beginPoint = Input.mousePosition;
            }
        }
        // クリックしたオブジェクトをレイで取りたい場合
        public void OnButtonDown(ref GameObject select)
        {
            if (state == FlickState.FREE)
            {
                state = FlickState.FLICKING;
                beginPoint = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 10.0f);
                Debug.Log("hit!" + hit.collider);
                if (hit.collider.tag == "Panel")
                {
                    select = hit.collider.gameObject;
                }
            }
        }
        #endregion

        // ボタン押下中の処理01
        #region
        public  void OnFlicking()
        {
            if (state == FlickState.FLICKING)
            {
                endPoint = Input.mousePosition;
            }
        }
        #endregion

        // ボタンを離した時にフリックした方向(象限)を返す
        public int OnFlicked()
        {
            // 終点の座標を取得
            this.endPoint = Input.mousePosition;
            int quadrant = 0;
            // フリックの方向
            Vector2 dir = this.endPoint - this.beginPoint;

            // フリック入力の長さ
            float flickLen = dir.sqrMagnitude;

            dir = dir.normalized;

            //Debug.Log("dir?" + dir);

            if (state == FlickState.FLICKING)
            {
                state = FlickState.FREE;
            }
            
            // FlickDirで指定した距離以下の入力はタップ判定とする
            if (flickLen < Mathf.Pow(flickLength, 2))
            {
                // (quadrant = 0) == TAP
                Debug.Log("tapped");
                return quadrant;
            }
            quadrant = GetQuadrantNum(CalcAngle(dir));
            return quadrant;
        }

        // ボタンを離した時にフリックした方向(象限)を返す
        public int OnFlicked(ref GameObject dest)
        {
            int quadrant = 0;
            Vector2 dir = this.endPoint - this.beginPoint;
            if (state == FlickState.FLICKING)
            {
                state = FlickState.FREE;
            }
            // FlickDirで指定した距離以下の入力はタップ判定とする
            if (dir.sqrMagnitude < Mathf.Pow(flickLength, 2))
            {
                // (quadrant = 0) == TAP
                return quadrant;
            }
            quadrant = GetQuadrantNum(CalcAngle(dir));
            return quadrant;
        }

        // フリックの入力方向から角度を計算する
        public float CalcAngle(Vector2 dir)
        {
            float angle = 0;
            angle = Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x);

            // 角度はオイラー角として算出する
            if (angle < 0.0f)
                angle += 360.0f;

            //Debug.Log("angle ?" + angle);
            return angle;
        }
        // 角度から象限を取得する
        public int GetQuadrantNum(float angle)
        {
            // 象限を分割する角度
            float margin = 360.0f / this.Quadrant;
            //Debug.Log("margin ? " + margin);
            // 入力された角度がどの位置かを判別するための変数
            float x = this.offsetAngle;

            int i = 1;
            for (i = 1; i < Quadrant; i++)
            {
                // angleが入っている象限の番号を返す
                if (x <= angle && angle < x + margin)
                {
                    return i;
                }
                x += margin;
            }
            return i;
        }

        // プロパティ
        #region
        public Vector2 GetBeginPoint
        {
            get { return this.beginPoint; }
        }
        public Vector2 GetEndPoint
        {
            get { return this.endPoint; }
        }
        public float FlickLength
        {
            get { return this.flickLength; }
            set { this.flickLength = value; }
        }
        public int Quadrant
        {
            get { return this.quadrant; }
            set { this.quadrant = value; }
        }
        public float OffsetAngle
        {
            get { return this.offsetAngle; }
            set { this.offsetAngle = value; }
        }
        #endregion
    }
}