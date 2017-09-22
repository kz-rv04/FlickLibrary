using InputUtil;が必要

最大360分割、360度好きな角度に始点を変更して分割したフリック方向を取得できるクラス

// 基本的な使用方法
・FlickUtil.csをUnityのGameObjectに付けます
フリック入力を利用するクラスからFlickUtilクラスを取得します。

ボタン押下、押し込んでいる際、離した際の判定を取っている部分で
それぞれOnButtonDown(),OnFlicking(),OnFlicked()関数をFlickUtilのインスタンスから呼び出します。

※OnButtonDown()およびOnFlicked()メソッドはフリックの始点、終点の座標を取るのに使用しているので
必ず呼び出すこと。

OnFlicked()の返り値で分割した象限の番号を取得できます。(0番はタップ判定）

・象限の分割について
FlickUtilクラスのquadrantの値を変更することで分割する象限の数(3~360),
offsetAngleで象限を分割する始点の角度を調節(0~360)

また、flickLengthを変更することでフリック判定とする距離を指定できます。

・Gizmoによる分割した象限の可視化
DisplayGizmo.csをUnityのGameObjectにアタッチしFlickUtilクラスをInspectorにアタッチします。
DisplayGizmoクラスを付けたGameObjectを選択した時のみUnityEditor上で分割した象限を確認できます。