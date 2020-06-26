﻿using Unity.Mathematics;
using UnityEngine;

namespace Eldemarkki.VoxelTerrain.World
{
    /// <summary>
    /// A procedurally generated world
    /// </summary>
    public class HeightmapWorldGenerator : WorldGenerator
    {
        [SerializeField] private HeightmapTerrainSettings heightmapTerrainSettings;

        public HeightmapTerrainSettings HeightmapTerrainSettings => heightmapTerrainSettings;

        private void Awake()
        {
            heightmapTerrainSettings.Initialize(heightmapTerrainSettings.Heightmap, heightmapTerrainSettings.Amplitude, heightmapTerrainSettings.HeightOffset);
        }

        private void Start()
        {
            CreateHeightmapTerrain();
        }

        private void OnDestroy()
        {
            heightmapTerrainSettings.Dispose();
        }

        /// <summary>
        /// Creates the heightmap terrain and instantiates the chunks.
        /// </summary>
        private void CreateHeightmapTerrain()
        {
            int chunkCountX = Mathf.CeilToInt((float)(heightmapTerrainSettings.Width - 1) / VoxelWorld.WorldSettings.ChunkSize);
            int chunkCountZ = Mathf.CeilToInt((float)(heightmapTerrainSettings.Height - 1) / VoxelWorld.WorldSettings.ChunkSize);
            int chunkCountY = Mathf.CeilToInt(heightmapTerrainSettings.Amplitude / VoxelWorld.WorldSettings.ChunkSize);

            for (int x = 0; x < chunkCountX; x++)
            {
                for (int y = 0; y < chunkCountY; y++)
                {
                    for (int z = 0; z < chunkCountZ; z++)
                    {
                        VoxelWorld.ChunkProvider.EnsureChunkExistsAtCoordinate(new int3(x, y, z));
                    }
                }
            }
        }
    }
}