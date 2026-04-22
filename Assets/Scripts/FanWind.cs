using UnityEngine;

public class FanWind : MonoBehaviour
{
    [Header("風力設定")]
    [Tooltip("風扇底部的最大推力 (要設得很大，防止玩家碰到)")]
    public float maxForce = 80f;

    [Tooltip("風扇頂部的最小推力 (要小於玩家受到的重力，這樣才不會無限飛)")]
    public float minForce = 5f;

    [Tooltip("風場的總高度 (建議與你設定的 Trigger 高度差不多)")]
    public float maxWindHeight = 5f;

    private void OnTriggerStay2D(Collider2D other)
    {
        // 確認進入風場的是不是玩家
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 1. 計算玩家目前相對於風扇底部的高度差 (Y軸距離)
                float currentHeight = other.transform.position.y - transform.position.y;

                // 防呆：將距離限制在 0 到 maxWindHeight 之間
                currentHeight = Mathf.Clamp(currentHeight, 0, maxWindHeight);

                // 2. 計算高度比例 (距離底部越近，比例越接近 0；越接近頂部，比例越接近 1)
                float heightRatio = currentHeight / maxWindHeight;

                // 3. 根據比例計算當前風力 (反向運算)
                // 當 ratio 為 0 (在底部)，風力 = maxForce
                // 當 ratio 為 1 (在頂部)，風力 = minForce
                float currentForce = Mathf.Lerp(maxForce, minForce, heightRatio);

                // 4. 對玩家施加向上的力
                // 乘以 rb.mass 可以讓設定的數值不受玩家質量影響
                rb.AddForce(Vector2.up * currentForce * rb.mass, ForceMode2D.Force);
            }
        }
    }
}