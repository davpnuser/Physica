using Microsoft.Xna.Framework.Graphics;
using System;

namespace Physica.Classes.Core
{
    public sealed class BatchManager
    {
        // Variables
        public static BatchManager Instance
        {
            get
            {
                if (_instance == null)
                    throw new Exception("The batch manager singleton has not been initalized yet.");

                return _instance;
            }
        }

        private static BatchManager _instance;
        public SpriteBatch Batch => _batch;
        readonly private SpriteBatch _batch;
        public bool HasBegan { get; private set; } = false;


        // Constructor
        private BatchManager(SpriteBatch batch)
            => _batch = batch;


        // Methods
        public static void Initialize(SpriteBatch batch)
        {
            if (_instance != null)
                throw new Exception("The batch manager singleton has already been initalized.");

            _instance = new(batch);
        }

        public void Begin()
        {
            if (HasBegan)
                return;

            _batch.Begin();
            HasBegan = true;
        }

        public void End()
        {
            if (!HasBegan)
                return;

            _batch.End();
            HasBegan = false;
        }
    }
}
