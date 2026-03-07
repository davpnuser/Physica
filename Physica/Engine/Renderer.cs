using Microsoft.Xna.Framework.Graphics;
using Physica.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Physica.Engine
{
    public class Renderer
    {
        //Variables
        readonly GraphicsDevice _graphics;
        readonly SpriteBatch _batch;
        readonly List<IPipeline> _pipelines;


        //Constructor
        public Renderer(GraphicsDevice graphics, SpriteBatch batch)
        {
            _graphics = graphics;
            _batch = batch;
            _pipelines = [];
        }


        //Methods
        public void Add(IPipeline pipeline)
            => _pipelines.Add(pipeline);

        public void AddPipelines(IPipeline[] pipelines)
        {
            foreach (IPipeline pipeline in pipelines)
                _pipelines.Add(pipeline);
        }

        public void Remove(IPipeline pipeline)
            => _pipelines.Remove(pipeline);

        public IPipeline GetPipeline(string PipelineName)
        {
            IPipeline pipeline = _pipelines.FirstOrDefault(x => x.Name == PipelineName);
            return pipeline;
        }

        public void Render()
        {
            foreach (IPipeline pipeline in _pipelines)
                pipeline.Draw();
        }
    }
}
