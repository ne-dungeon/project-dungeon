using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

public class SpriteProcessor : AssetPostprocessor
{
    void OnPreprocessTexture()
    {
        // This could be for example "Art/Character/Sprites/" or "Art/Enemy/Sprites".
        if (assetPath.Contains("/Sprites/"))
        {
            Debug.Log("Processing texture " + assetImporter.assetPath);
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            textureImporter.textureType = TextureImporterType.Sprite;
            textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            textureImporter.spritePixelsPerUnit = 32f;
            textureImporter.wrapMode = TextureWrapMode.Clamp;
            textureImporter.filterMode = FilterMode.Point;
            // We can enable/edit this if needed. 2048 is default anyway.
            // Smaller sizes may improve performance if we have an issue here.
            // textureImporter.maxTextureSize = 2048;
            textureImporter.textureCompression = TextureImporterCompression.Uncompressed;

        }
    }


    void OnPostprocessTexture(Texture2D texture)
    {
        Debug.Log("Texture2D: (" + texture.width + "x" + texture.height + ")");

        // // Works except for populating the subassets:
        // int spriteSize = 64;
        // int colCount = texture.width / spriteSize;
        // int rowCount = texture.height / spriteSize;

        // List<SpriteMetaData> metas = new List<SpriteMetaData>();

        // for (int r = 0; r < rowCount; ++r)
        // {
        //     for (int c = 0; c < colCount; ++c)
        //     {
        //         SpriteMetaData meta = new SpriteMetaData();
        //         meta.rect = new Rect(c * spriteSize, r * spriteSize, spriteSize, spriteSize);
        //         meta.name = c + "-" + r;
        //         metas.Add(meta);
        //     }
        // }
        // // Debug.Log(metas.Count);
        // // Debug.Log(metas.Capacity);
        // TextureImporter textureImporter = (TextureImporter)assetImporter;
        // // Debug.Log(textureImporter.spritesheet.Length);
        // textureImporter.spritesheet = metas.ToArray();
        // // Debug.Log(textureImporter.spritesheet.Length);
        // // spritesheet updates from 0 to 6

        // // end

        Vector2 spriteSize = new Vector2(64, 64);


        Rect[] spriteRects = InternalSpriteUtility.GenerateGridSpriteRectangles(texture, Vector2.zero, spriteSize, Vector2.zero, true);

        Debug.Log(spriteRects);
        Debug.Log(spriteRects.Length);

        List<SpriteMetaData> metas = new List<SpriteMetaData>();
        string fileNameNoExtension = Path.GetFileNameWithoutExtension(assetPath);

        TextureImporter textureImporter = (TextureImporter)assetImporter;

        for (int i = 0; i < spriteRects.Length; i++)
        {
            SpriteMetaData meta = new SpriteMetaData();
            meta.rect = spriteRects[i];
            meta.name = fileNameNoExtension + "_" + i;
            metas.Add(meta);
        }


        textureImporter.spritesheet = metas.ToArray();

        // Debug.Log("Meta rects:");
        // for (int i = 0; i < textureImporter.spritesheet.Length; i++)
        // {
        //     Debug.Log(textureImporter.spritesheet[i]);
        //     Debug.Log(textureImporter.spritesheet[i].rect);
        // }

        AssetDatabase.ForceReserializeAssets(new List<string>() { assetImporter.assetPath });
        AssetDatabase.ImportAsset(assetPath, ImportAssetOptions.ForceUpdate);

    }

    void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
    {
        Debug.Log("Found Sprites: " + sprites.Length);

        // Debug.Log("Sprite rects:");
        // for (int i = 0; i < sprites.Length; i++)
        // {
        //     Debug.Log(sprites[i]);
        //     Debug.Log(sprites[i].rect);
        // }

        // if (sprites.Length == 0)
        // {
        //     AssetDatabase.ImportAsset(assetImporter.assetPath);
        //     return;
        // }
    }
}
