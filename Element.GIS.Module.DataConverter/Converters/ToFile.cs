using Element.GIS.Fx;
using System;
using System.Collections.Generic;
using System.IO;

namespace Element.GIS.Plugin.DataConverter
{
    public abstract class ToFile
    {
        private readonly Dictionary<string, Action<Options, IHostGrpc>> _handles
            = new Dictionary<string, Action<Options, IHostGrpc>>(StringComparer.OrdinalIgnoreCase);

        protected ToFile()
        {
            FillHandles(_handles);
        }

        protected virtual void FillHandles(Dictionary<string, Action<Options, IHostGrpc>> handles)
        {
        }

        public virtual void Convert(Options option, IHostGrpc hostGrpc)
        {
            if (!File.Exists(option.File))
            {
                return;
            }

            var ext = Path.GetExtension(option.File);
            if (_handles.ContainsKey(ext))
            {
                _handles[ext].Invoke(option, hostGrpc);
            }
        }
    }
}