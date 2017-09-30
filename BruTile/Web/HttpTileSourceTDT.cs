using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BruTile.Cache;

namespace BruTile.Web
{
    public class HttpTileSourceTDT : ITileSource, IRequest
    {
        private readonly HttpTileProvider _provider;

        public HttpTileSourceTDT(ITileSchema tileSchema, string urlFormatter, IEnumerable<string> serverNodes = null,
            string apiKey = null, string name = null, IPersistentCache<byte[]> persistentCache = null,
            Func<Uri, byte[]> tileFetcher = null, Attribution attribution = null)
            : this(tileSchema, new BasicRequestTDT(urlFormatter, serverNodes, apiKey), name, persistentCache, tileFetcher, attribution)
        {

        }

        public HttpTileSourceTDT(ITileSchema tileSchema, IRequest request, string name = null,
            IPersistentCache<byte[]> persistentCache = null, Func<Uri, byte[]> tileFetcher = null, Attribution attibution = null)
        {
            _provider = new HttpTileProvider(request, persistentCache, tileFetcher);
            Schema = tileSchema;
            Name = name ?? string.Empty;
            Attribution = attibution ?? new Attribution();
        }

        public IPersistentCache<byte[]> PersistentCache => _provider.PersistentCache;

        public Uri GetUri(TileInfo tileInfo)
        {
            return _provider.GetUri(tileInfo);
        }

        public ITileSchema Schema { get; }

        public string Name { get; set; }

        public Attribution Attribution { get; set; }

        /// <summary>
        /// Gets the actual image content of the tile as byte array
        /// </summary>
        public virtual byte[] GetTile(TileInfo tileInfo)
        {
            return _provider.GetTile(tileInfo);
        }
    }
}
