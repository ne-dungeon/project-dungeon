using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteProcessor : AssetPostprocessor
{
    void OnPostprocessTexture(Texture2D texture)
    {
        Debug.Log("In onPostProcessTexture");
        string lowerCaseAssetPath = assetPath.ToLower();

        // This could be for example "Art/Character/Sprites/" or "Art/Enemy/Sprites".
        bool isInSpritesDirectory = lowerCaseAssetPath.IndexOf("/sprites/") != -1;


        if (isInSpritesDirectory)
        {
            TextureImporter textureImporter = (TextureImporter)assetImporter;
            Debug.Log("Processing texture " + assetImporter.assetPath);
            textureImporter.textureType = TextureImporterType.Sprite;
            // textureImporter.spriteImportMode = SpriteImportMode.Multiple;
            // textureImporter.spritePixelsPerUnit = 32f;
            // textureImporter.wrapMode = TextureWrapMode.Clamp;
            // textureImporter.filterMode = FilterMode.Point;
            // textureImporter.maxTextureSize = 2048;
            // textureImporter.textureCompression = TextureImporterCompression.Uncompressed;
        }
    }
}
