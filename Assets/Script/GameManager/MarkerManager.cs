using UnityEngine;
using UnityEngine.Tilemaps;

public class MarkerManager : MonoBehaviour
{
    [SerializeField] Tilemap targetTilemap;
    [SerializeField] TileBase tile;
    public Vector3Int markedCellPosition;
    Vector3Int oldCellPosition;

    private bool show = true; // Tambahkan deklarasi untuk variabel `show`

    private void Update()
    {
        if (!show) return;

        // Hapus tile lama
        targetTilemap.SetTile(oldCellPosition, null);

        // Tampilkan tile marker baru
        targetTilemap.SetTile(markedCellPosition, tile);

        // Simpan posisi marker yang sekarang sebagai lama
        oldCellPosition = markedCellPosition;
    }

    internal void Show(bool selectable)
    {
        show = selectable;
        targetTilemap.gameObject.SetActive(show);
    }
}
