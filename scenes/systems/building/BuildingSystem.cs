using Godot;
using Catcophony.data;
using Catcophony.data.enums;
using Catcophony.scenes.common.interfaces;
using Catcophony.scenes.world;
using System.Collections.Generic;

namespace Catcophony.scenes.systems.building
{
    public partial class BuildingSystem : Node2D, IBuildingSystem
    {
        public Buildable Current 
        { 
            get
            {
                if (_current == TileType.NONE)
                {
                    return null;
                }

                return new(_current, GetItemMaterial());
            }
        }

        private TileType _current = TileType.NONE;

        private List<Vector2I> _atlasCoords = [];

        private int _atlasIndex = 0;

        private IMultiColorTileMapLayer _buildingPreviewTileMapLayer;

        public override void _Ready()
        {
            _buildingPreviewTileMapLayer = GetNode<IMultiColorTileMapLayer>("BuildingPreviewTileMapLayer");
        }

        public override void _Process(double delta)
        {
            if (_current != TileType.NONE)
            {
                ShowBuildPreview();
            } 
        }

        public void SetCurrent(TileType current)
        {
            _current = current;
            if (_current != TileType.NONE)
            {
                _atlasCoords.AddRange(AtlasConstants.AtlasCoords[_current]);
                _atlasIndex = 0;
            }
        }

        public void Clear()
        {
            _buildingPreviewTileMapLayer.Clear();
            _current = TileType.NONE;
            _atlasCoords.Clear();
            _atlasIndex = 0;
        }

        public void NextBuildable()
        {
            _atlasIndex++;
            _atlasIndex %= _atlasCoords.Count;
        }

        private void ShowBuildPreview()
        {
            _buildingPreviewTileMapLayer.Clear();

            var localPos = GetGlobalMousePosition();
            var coords = _buildingPreviewTileMapLayer.LocalToMap(localPos);
            var atlasCoords = _atlasCoords[_atlasIndex];
            var color = AtlasConstants.GetColor(_current);

            _buildingPreviewTileMapLayer.SetCell(coords, atlasCoords, color);
        }

        private TileMaterial GetItemMaterial()
        {
            var atlasCoords = _atlasCoords[_atlasIndex];
            var color = AtlasConstants.GetColor(_current);

            return new TileMaterial(_current, atlasCoords, color);
        }
    }
}
