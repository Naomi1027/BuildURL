using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildURL
{
    public class PropertyInfo
    {
        public string Price { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string LandArea { get; set; } = string.Empty;
        public string RoadAccess { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"価格: {Price}, 所在地: {Address}, 土地面積: {LandArea}, 接道状況: {RoadAccess}";
        }
    }
}
