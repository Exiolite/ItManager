﻿#pragma checksum "..\..\..\..\View\MainWindowView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "DD68391F6CCD16B9DFE81E384B12CB9AD3CC7DBC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace ItManager.View {
    
    
    /// <summary>
    /// MainWindowView
    /// </summary>
    public partial class MainWindowView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\View\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel Menu;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\View\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel View;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DockPanel EditorWindow;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\..\View\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel CompanyView;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ItManager;component/view/mainwindowview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MainWindowView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Menu = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 2:
            this.View = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 3:
            
            #line 37 "..\..\..\..\View\MainWindowView.xaml"
            ((System.Windows.Controls.ListBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.OnClickCompany);
            
            #line default
            #line hidden
            return;
            case 4:
            this.EditorWindow = ((System.Windows.Controls.DockPanel)(target));
            return;
            case 5:
            this.CompanyView = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            
            #line 89 "..\..\..\..\View\MainWindowView.xaml"
            ((System.Windows.Controls.ListView)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ComputerDoubleClicked);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 125 "..\..\..\..\View\MainWindowView.xaml"
            ((System.Windows.Controls.ListView)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ServerDoubleClicked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

