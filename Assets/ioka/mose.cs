using UnityEngine;

public class mose : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture; // カーソルにしたい画像
    [SerializeField] private int cursorWidth = 64;    // 希望する横幅
    [SerializeField] private int cursorHeight = 64;   // 希望する縦幅

    void Start()
    {
        if (cursorTexture != null)
        {
            // 画像を指定したサイズにリサイズする
            Texture2D resizedCursor = ResizeTexture(cursorTexture, cursorWidth, cursorHeight);

            // カーソルの中心点（左上を起点にする場合は Vector2.zero）
            Vector2 hotSpot = Vector2.zero;

            // カーソルを変更
            Cursor.SetCursor(resizedCursor, hotSpot, CursorMode.ForceSoftware);
        }
    }

    // テクスチャをリサイズするヘルパー関数
    private Texture2D ResizeTexture(Texture2D source, int newWidth, int newHeight)
    {
        RenderTexture rt = RenderTexture.GetTemporary(newWidth, newHeight);
        Graphics.Blit(source, rt);

        Texture2D result = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
        RenderTexture.active = rt;
        result.ReadPixels(new Rect(0, 0, newWidth, newHeight), 0, 0);
        result.Apply();

        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(rt);

        return result;
    }
}
