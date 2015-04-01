﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "139FC24106590FFF740CEAF4ACD33A0A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Converters;
using FirstFloor.ModernUI.Windows.Navigation;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Paint_v2._0 {
    
    
    /// <summary>
    /// Paint
    /// </summary>
    public partial class Paint : FirstFloor.ModernUI.Windows.Controls.ModernWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 108 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ColorWheel;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas drawingColorBox;
        
        #line default
        #line hidden
        
        
        #line 169 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PencilButton;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EraserButton;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FillButton;
        
        #line default
        #line hidden
        
        
        #line 232 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ColorPickerButton;
        
        #line default
        #line hidden
        
        
        #line 270 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RectangleButton;
        
        #line default
        #line hidden
        
        
        #line 291 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EllipseButton;
        
        #line default
        #line hidden
        
        
        #line 312 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LineButton;
        
        #line default
        #line hidden
        
        
        #line 359 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Position;
        
        #line default
        #line hidden
        
        
        #line 367 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label CanvasSize;
        
        #line default
        #line hidden
        
        
        #line 383 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas paintSurface;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Paint v2.0;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\MainWindow.xaml"
            ((Paint_v2._0.Paint)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Close_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 26 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.New_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 32 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Open_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 37 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 43 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Exit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 55 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Undo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 60 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Redo_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 72 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.VerticalFlip_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 77 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.HorizontalFlip_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 83 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.RightRotate_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 88 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.LeftRotate_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 93 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.Rotate180_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ColorWheel = ((System.Windows.Controls.Image)(target));
            
            #line 116 "..\..\MainWindow.xaml"
            this.ColorWheel.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ChangeColor_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.drawingColorBox = ((System.Windows.Controls.Canvas)(target));
            return;
            case 15:
            this.PencilButton = ((System.Windows.Controls.Button)(target));
            
            #line 174 "..\..\MainWindow.xaml"
            this.PencilButton.Click += new System.Windows.RoutedEventHandler(this.Pencil_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.EraserButton = ((System.Windows.Controls.Button)(target));
            
            #line 195 "..\..\MainWindow.xaml"
            this.EraserButton.Click += new System.Windows.RoutedEventHandler(this.Eraser_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.FillButton = ((System.Windows.Controls.Button)(target));
            
            #line 216 "..\..\MainWindow.xaml"
            this.FillButton.Click += new System.Windows.RoutedEventHandler(this.Fill_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.ColorPickerButton = ((System.Windows.Controls.Button)(target));
            
            #line 237 "..\..\MainWindow.xaml"
            this.ColorPickerButton.Click += new System.Windows.RoutedEventHandler(this.ColorPicker_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.RectangleButton = ((System.Windows.Controls.Button)(target));
            
            #line 275 "..\..\MainWindow.xaml"
            this.RectangleButton.Click += new System.Windows.RoutedEventHandler(this.Rectangle_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.EllipseButton = ((System.Windows.Controls.Button)(target));
            
            #line 296 "..\..\MainWindow.xaml"
            this.EllipseButton.Click += new System.Windows.RoutedEventHandler(this.Ellipse_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.LineButton = ((System.Windows.Controls.Button)(target));
            
            #line 317 "..\..\MainWindow.xaml"
            this.LineButton.Click += new System.Windows.RoutedEventHandler(this.Line_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.Position = ((System.Windows.Controls.Label)(target));
            return;
            case 23:
            this.CanvasSize = ((System.Windows.Controls.Label)(target));
            return;
            case 24:
            this.paintSurface = ((System.Windows.Controls.Canvas)(target));
            
            #line 385 "..\..\MainWindow.xaml"
            this.paintSurface.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MouseDown_Click);
            
            #line default
            #line hidden
            
            #line 386 "..\..\MainWindow.xaml"
            this.paintSurface.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.MouseUp_Click);
            
            #line default
            #line hidden
            
            #line 387 "..\..\MainWindow.xaml"
            this.paintSurface.MouseMove += new System.Windows.Input.MouseEventHandler(this.Mouse_Move);
            
            #line default
            #line hidden
            
            #line 388 "..\..\MainWindow.xaml"
            this.paintSurface.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Mouse_Leave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

