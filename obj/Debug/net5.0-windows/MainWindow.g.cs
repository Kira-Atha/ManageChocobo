﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CBD2A3F49A9AD0B1478DA0CC3FFE0EBF5DF91338"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using ChocoboManagement;
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


namespace ChocoboManagement {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TrainerAdd;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TrainerModify;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button TrainerDelete;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StableAdd;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StableModify;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StableDelete;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChocoboAdd;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChocoboModify;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChocoboDelete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ChocoboManagement;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.6.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TrainerAdd = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\MainWindow.xaml"
            this.TrainerAdd.Click += new System.Windows.RoutedEventHandler(this.TrainerAdd_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TrainerModify = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\MainWindow.xaml"
            this.TrainerModify.Click += new System.Windows.RoutedEventHandler(this.TrainerModify_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TrainerDelete = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\MainWindow.xaml"
            this.TrainerDelete.Click += new System.Windows.RoutedEventHandler(this.TrainerDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 26 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.ListBox)(target)).SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.StableAdd = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\MainWindow.xaml"
            this.StableAdd.Click += new System.Windows.RoutedEventHandler(this.StableAdd_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.StableModify = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.StableModify.Click += new System.Windows.RoutedEventHandler(this.StableModify_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.StableDelete = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\MainWindow.xaml"
            this.StableDelete.Click += new System.Windows.RoutedEventHandler(this.StableDelete_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ChocoboAdd = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\MainWindow.xaml"
            this.ChocoboAdd.Click += new System.Windows.RoutedEventHandler(this.ChocoboAdd_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ChocoboModify = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\MainWindow.xaml"
            this.ChocoboModify.Click += new System.Windows.RoutedEventHandler(this.ChocoboModify_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ChocoboDelete = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\MainWindow.xaml"
            this.ChocoboDelete.Click += new System.Windows.RoutedEventHandler(this.ChocoboDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

