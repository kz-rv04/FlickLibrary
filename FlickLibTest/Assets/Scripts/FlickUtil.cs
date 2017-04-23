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

    public class FlickUtil
    {
        [SerializeField]
        private static FlickState state = FlickState.FREE;

        // フリック判定のための座標
        private static Vector3 beginPoint, endPoint;
        // フリック判定の距離
        public static float flickDir = 0.0f;

        // フリックなどの入力系統の処理
        #region
        // ボタン押下時の処理
        #region
        public static void OnButtonDown()
        {
            if (state == FlickState.FREE)
            {
                state = FlickState.FLICKING;
                beginPoint = Input.mousePosition;
            }
        }
        // クリックしたオブジェクトをレイで取りたい場合
        public static void OnButtonDown(ref GameObject select)
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
        #region
        // ボタン押下中の処理
        public static void OnFlicking()
        {
            if (state == FlickState.FLICKING)
            {
                endPoint = Input.mousePosition;
            }
        }
        #endregion
        // ボタンを離した時にフリックした方向を返す
        public static FlickDirection OnFlicked()
        {

            if (state == FlickState.FLICKING)
            {
                state = FlickState.FREE;
            }
            return GetDirection(beginPoint, endPoint);
        }
        // ボタンを離した時にフリックした方向を返す
        public static FlickDirection OnFlicked(ref GameObject dest)
        {

            if (state == FlickState.FLICKING)
            {
                state = FlickState.FREE;
            }
            return GetDirection(beginPoint, endPoint);
        }
        // フリックの方向を取得する関数
        private static FlickDirection GetDirection(Vector3 begin, Vector3 end)
        {
            float dirX, dirY;
            dirX = end.x - begin.x;
            dirY = end.y - begin.x;
            // 横方向のフリックの場合
            if (Mathf.Abs(dirX) > Mathf.Abs(dirY))
            {
                // 左方向への入力
                if (dirX < 0)
                {
                    return FlickDirection.LEFT;
                }
                else
                {
                    return FlickDirection.RIGHT;
                }
            }
            // 縦方向のフリックの場合
            if (Mathf.Abs(dirX) < Mathf.Abs(dirY))
            {
                // 下方向への入力
                if (dirY < 0)
                {
                    return FlickDirection.DOWN;
                }
                else
                {
                    return FlickDirection.UP;
                }

            }
            else
            {
                return FlickDirection.TAP;
            }
        }
        #endregion
    }
}
