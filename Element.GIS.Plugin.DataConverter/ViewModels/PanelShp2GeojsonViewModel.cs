using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Avalonia.Themes.Neumorphism.Controls;
using System.Collections.Generic;

namespace Neumorphism.Avalonia.Demo.ViewModels.Panels
{
    public sealed class PanelShp2GeojsonViewModel : ViewModelBase
    {

        #region properties

        private string _shpPath;
        public string ShpPath
        {
            get
            {
                return _shpPath;
            }
            set
            {
                _shpPath = value;
                OnPropertyChanged();
            }
        }

        private string _geoJsonPath;
        public string GeoJsonPath
        {
            get
            {
                return _geoJsonPath;
            }
            set
            {
                _geoJsonPath = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region commands

        public async void ButtonSelShpPathClick(Button sender)
        {
            // 从当前控件获取 TopLevel。或者，您也可以使用 Window 引用。
            var topLevel = TopLevel.GetTopLevel(sender);

            // 启动异步操作以打开对话框。
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open Shp File",
                FileTypeFilter = GetFileTypes(),
                AllowMultiple = false
            });

            if (files.Count >= 1)
            {
                // 打开第一个文件的读取流。

            }
        }

        public List<FilePickerFileType> GetFileTypes()
        {
            return new List<FilePickerFileType>
            {
                new("shapefile")
                {
                    Patterns = new[] { "*.shp" },
                    AppleUniformTypeIdentifiers = new[] { "public.shapefile" },
                    MimeTypes = new[] { "application/octet-stream" }
                },

                FilePickerFileTypes.All
            };
        }

        public void ButtonSelGeoJsonPathClick(object sender)
        {

        }

        public void ButtonLoginClick(object sender)
        {
            if (sender is Button)
            {
                if (string.IsNullOrEmpty(ShpPath))
                {
                    SnackbarHost.Post("Please enter a login !");
                }
                else if (string.IsNullOrEmpty(GeoJsonPath))
                {
                    SnackbarHost.Post("Please enter a password !");
                }
                else
                {
                    SnackbarHost.Post("You have signed in with login " + ShpPath + " and password " + GeoJsonPath + " !");
                }
            }
        }

        #endregion
    }
}
