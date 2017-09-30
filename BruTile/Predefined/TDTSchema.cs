using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BruTile.Predefined
{
    public class TDTSchema : TileSchema
    {
        // Well known scale set: urn:ogc:def:wkss:OGC:1.0:NLDEPSG28992Scale
        // see: http://www.geonovum.nl/sites/default/files/Nederlandse_richtlijn_tiling_-_versie_1.0.pdf
        private const int TileSize = 256;
        private double _originX = -20037508.342789;
        private double _originY = 20037508.342789;
        //private double _originX = -180;
        //private double _originY = 90;

        public TDTSchema()
        {
            var unitsPerPixelArray = new[] {
                156543.033928,
                78271.51696402048,
                39135.75848201024,
                19567.87924100512 ,
                9783.93962050256,
                4891.96981025128,
                2445.98490512564,
                1222.99245256282,
                611.49622628141,
                305.748113140705,
                 152.8740565703525,
                76.43702828517625,
                38.21851414258813,
                19.109257071294063,
                9.554628535647032,
                4.777314267823516,
                2.388657133911758,
                1.194328566955879,
                 0.597164283559817,
                 0.298582141647617
            };
            //var unitsPerPixelArray = new[] {
            //    0.703125,
            //    0.3515625,
            //    0.17578125,
            //    0.087890625,
            //    0.0439453125,
            //    0.02197265625,
            //    0.010986328125,
            //    0.0054931640625,
            //    0.00274658203125,
            //    0.001373291015625,
            //    0.0006866455078125,
            //    0.00034332275390625,
            //    0.000171661376953125,
            //    8.58306884765625e-005,
            //    4.291534423828125e-005,
            //    2.1457672119140625e-005,
            //    1.0728836059570313e-005,
            //    5.3644180297851563e-006,
            //     0.597164283559817,
            //     0.298582141647617
            //};
            //var unitsPerPixelArray = new[] {
            //    73874398.264688,
            //    36937199.132344,
            //    18468599.566172,
            //    9234299.783086,
            //    4617149.891543,
            //    2308574.945771,
            //    1154287.472886,
            //    577143.736443,
            //    288571.86822143558,
            //    144285.93411071779,
            //    72142.967055358895,
            //    36071.483527679447,
            //    18035.741763839724 ,
            //    18035.741763839724,
            //    9017.8708819198619,
            //    4508.9354409599309,
            //    2254.4677204799655
            //};
            //var unitsPerPixelArray = new[] {
            //    590995186.11759996,
            //    295497593.0588,
            //    147748796.5294,
            //    73874398.2647,
            //    36937199.1323,
            //    18468599.566175,
            //    9234299.7830875,
            //    4617149.89154375,
            //    2308574.94577187,
            //    1154287.47288594,
            //    577143.736442969,
            //    288571.868221484,
            //    144285.934110742,
            //    72223.960000000006,
            //    36071.4835276855,
            //    18035.7417638428,
            //    9017.87088192139,
            //    4508.93544096069,
            //    2254.46772048035,
            //    1127.23386024017,
            //    563.616930120087
            //};
            var count = 0;
            foreach (var unitsPerPixel in unitsPerPixelArray)
            {
                var levelId = count.ToString(CultureInfo.InvariantCulture);
                Resolutions[levelId] = new Resolution
                (
                    levelId,
                    unitsPerPixel,
                    TileSize,
                    TileSize,
                    _originX,
                    _originY
                );
                count++;
            }

            Extent = new Extent(-20037508.342789, -20037508.342789, 20037508.342789, 20037508.342789);
            OriginX = _originX;
            OriginY = _originY;
            Name = "img_c";
            Format = "png";
            YAxis = YAxis.OSM;
            Srs = "EPSG:4490";
        }
    }
}
