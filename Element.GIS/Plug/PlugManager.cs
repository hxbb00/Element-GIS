using Element.GIS.Logs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace Element.GIS.Plug
{
    /// <summary>
    /// 插件管理器
    /// </summary>
    public class PlugManager
    {
        private readonly HashSet<string> _mefDlls = new HashSet<string>();

        [ImportMany(typeof(IPlug))]
        private IEnumerable<IPlug> _childrenImported = new List<IPlug>();
        public static List<IPlug> GetElementGISPlugs()
        {
            var root = new PlugManager();
            root.Compose();
            return new List<IPlug>(root._childrenImported);
        }

        private void Compose()
        {
            Compose(this);
        }

        private void Compose(object attributedParts)
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Adds all the parts found in the same assembly
            Assembly assemblyObj = attributedParts.GetType().Assembly;
            catalog.Catalogs.Add(new AssemblyCatalog(assemblyObj));

            AddCatalogs(catalog);

            //Create the CompositionContainer with the parts in the catalog
            var container = new CompositionContainer(catalog);

            //Fill the imports of this object
            try
            {
                container.ComposeParts(attributedParts);
            }
            catch (CompositionException compositionException)
            {
                ElementLogger.Error($"插件引发组合异常：{compositionException.Message}");
                for (var i = 0; i < compositionException.Errors.Count; i++)
                {
                    var compositionError = compositionException.Errors[i];
                    ElementLogger.Error($"插件引发组合异常_{i}：{compositionError.Description}");
                }
            }
            catch (ReflectionTypeLoadException loadException)
            {
                var stringBuilder = new StringBuilder();
                foreach (Exception loaderException in loadException.LoaderExceptions)
                {
                    stringBuilder.AppendLine(loaderException.Message);
                }

                Debug.WriteLine("TypeLoadException::" + stringBuilder);
                ElementLogger.Error($"插件引发加载库异常：{stringBuilder}");
            }
            catch (Exception e)
            {
                ElementLogger.Error($"插件ComposeParts发生未知异常：{e}");
            }
        }

        private void AddCatalogs(AggregateCatalog ac)
        {
            // 添加xml配置文件中的dll
            FindDlls();

            foreach (string mefDll in _mefDlls)
            {
                if (!File.Exists(mefDll)) { continue; }
                Assembly assembly = LoadAssembly(mefDll);
                if (assembly != null)
                {
                    ac.Catalogs.Add(new AssemblyCatalog(assembly));
                }
            }
        }

        private void FindDlls()
        {
            var dirPath = AppDomain.CurrentDomain.BaseDirectory;

            var files = Directory.EnumerateFiles(dirPath, "Element.GIS.Plug.*.dll", SearchOption.TopDirectoryOnly);
            foreach (string file in files)
            {
                string upperInvariant = file;
                if (!_mefDlls.Contains(upperInvariant))
                {
                    _mefDlls.Add(upperInvariant);
                }
            }
        }

        private static Assembly LoadAssembly(string codeBase)
        {
            AssemblyName assemblyName;
            try
            {
                assemblyName = AssemblyName.GetAssemblyName(codeBase);
            }
            catch (ArgumentException)
            {
                assemblyName = new AssemblyName
                {
                    CodeBase = codeBase
                };
            }
            catch (ReflectionTypeLoadException e0)
            {
                foreach (var item in e0.LoaderExceptions)
                {
                    ElementLogger.Error($"插件[{codeBase}]加载异常:{item}");
                }
                return null;
            }
            catch (Exception e)
            {
                ElementLogger.Error($"插件[{codeBase}]加载异常:{e}");

                return null;
            }

            try
            {
                var assembly = Assembly.Load(assemblyName);
                assembly.GetTypes();
                return assembly;
            }
            catch (ReflectionTypeLoadException e0)
            {
                foreach (var item in e0.LoaderExceptions)
                {
                    ElementLogger.Error($"插件[{codeBase}]加载异常:{item}");
                }
            }
            catch (Exception e)
            {
                ElementLogger.Error($"插件[{codeBase}]加载异常:{e}");
            }

            return null;
        }
    }
}