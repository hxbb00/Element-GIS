﻿using System;
using System.Collections.Generic;
using Avalonia.Controls.Primitives;
using Avalonia.Media;
using Avalonia.Themes.Neumorphism.Additional;

namespace Avalonia.Themes.Neumorphism.Controls
{
    public sealed class MaterialInternalIcon : TemplatedControl
    {
        private static readonly Lazy<IDictionary<string, string>> DataSetInstance = new(IconsDataSet.CreateDataSet);

        public static readonly AvaloniaProperty<string> KindProperty =
            AvaloniaProperty.Register<MaterialInternalIcon, string>(nameof(Kind));

        private static readonly DirectProperty<MaterialInternalIcon, Geometry> DataProperty =
            AvaloniaProperty.RegisterDirect<MaterialInternalIcon, Geometry>(nameof(Data), icon => icon.Data);

        private Geometry _data;

        static MaterialInternalIcon()
        {
            KindProperty.Changed.Subscribe(args => (args.Sender as MaterialInternalIcon)?.UpdateData());
        }

        /// <summary>
        /// Gets or sets the icon to display.
        /// </summary>
        public string Kind
        {
            get => GetValue(KindProperty) as string;
            set => SetValue(KindProperty, value);
        }

        /// <summary>
        /// Gets the icon path data for the current <see cref="Kind"/>.
        /// </summary>
        public Geometry Data
        {
            get
            {
                _data = _data switch
                {
                    null => Geometry.Parse(IconsDataSet.UnknownIconData),
                    _ => _data
                };
                return _data;
            }
            private set => SetAndRaise(DataProperty, ref _data, value);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            UpdateData();
        }

        private void UpdateData()
        {
            if (Kind is null)
                return;

            if (DataSetInstance.Value?.TryGetValue(Kind, out var data) ?? false)
                Data = Geometry.Parse(data);

            else
                Data = null;
        }
    }
}