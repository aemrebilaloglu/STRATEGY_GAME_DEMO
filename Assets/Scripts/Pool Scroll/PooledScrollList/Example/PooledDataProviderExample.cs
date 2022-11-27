using System.Collections.Generic;
using JetBrains.Annotations;
using PooledScrollList.Controller;
using PooledScrollList.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PooledScrollList.Example
{
    public class PooledDataProviderExample : PooledDataProvider
    {
        public PooledScrollRectBase ScrollRectController;
        public int Count;
        public List<Sprite> Colors;

        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Count = 3;
            }
        }
       
        public override List<PooledData> GetData()
        {
            var data = new List<PooledData>(Count);

            for (var i = 0; i < Count; i++)
            {
                int rnd = Random.Range(0, Colors.Count);
                data.Add(new PooledDataExample 
                {
                    Color = Colors[rnd]

                });
            }

            return data;
        }

        [UsedImplicitly]
        public void Apply()
        {
            var data = GetData();

            if (ScrollRectController != null)
            {
                ScrollRectController.Initialize(data);
            }
        }
    }
}