using System;
using System.Linq;
using System.Net;
using BruTile.Wmts;
using BruTile.Web;
using BruTile.Predefined;
using System.IO;
using BruTile.Wmsc;
using System.Collections.Generic;

namespace BruTile.Samples.Common
{
    public static class TDTTrans
    {
        public static ITileSource Create()
        {
            //这种取出的是经纬度，但是偏移了
            Uri uri =
                new Uri(
                    "http://t0.tianditu.com/img_c/wmts?SERVICE=WMTS&REQUEST=GetCapabilities&version=1.0.0");
            var req = WebRequest.Create(uri);
            var resp = req.GetResponseAsync();
            ITileSource tileSource;
            using (var stream = resp.Result.GetResponseStream())
            {
                var tileSources = WmtsParser.Parse(stream);
                tileSource = tileSources.First();
            }
            //using (var stream = System.IO.File.OpenRead(Path.Combine("Resources", "wmtsc2.xml")))
            //{
            //    var tileSources = WmtsParser.Parse(stream);
            //    tileSource = tileSources.First();
            //}
            return tileSource;
        }
        //public static ITileSource Create2()
        //{
        //    return new HttpTileSourceTDT(new TDTSchema(), "http://www.sdmap.gov.cn/tileservice/SdRasterPubMap?service=WMTS&request=GetTile&version=1.0.0&Layer=sdimg2017&Style=default&Format=tiles&TileMatrixSet=img2017&TileMatrix={z}&TileRow={y}&TileCol={x}", null,
        //      tileFetcher: null);
        //}
        //
        public static ITileSource Create2()
        {
            //这种方式取出的是投影坐标并且纵坐标不对
            return new HttpTileSourceTDT(new TDTSchema(), "http://t{c}.tianditu.cn/DataServer?T=img_c&X={x}&Y={y}&L={z}", null,
              tileFetcher: null);
        }
    }
}