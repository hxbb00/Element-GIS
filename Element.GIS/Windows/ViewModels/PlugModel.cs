using Element.GIS.Fx.Plug;
using Neumorphism.Avalonia.Demo.Interfaces;
using Neumorphism.Avalonia.Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Neumorphism.Avalonia.Demo.Windows.ViewModels
{
    public class PlugModel
    {
        private readonly IPlug _elementGISPlug;

        public PlugModel(IPlug elementGISPlug)
        {
            _elementGISPlug = elementGISPlug;
        }

        public string Name { get { return _elementGISPlug.Name; } }
        public string Title { get { return _elementGISPlug.Title; } }
        public string Description { get { return _elementGISPlug.Description; } }
        public bool FreeUse { get { return _elementGISPlug.FreeUse; } }

        public IEnumerable<SubPlugModel> GetSubs(ICardsDemoHost cardsDemoHost)
        {
            return _elementGISPlug.Subs.Select(x => new SubPlugModel(this, x, cardsDemoHost));
        }
    }
}