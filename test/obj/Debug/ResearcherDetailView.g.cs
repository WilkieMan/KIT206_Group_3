﻿#pragma checksum "..\..\ResearcherDetailView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "849CB4725972C718BE6B49D21E10CC8450F748DCEEFF170AC4570DA4A4B73C9D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KIT206_RAP;
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


namespace KIT206_RAP {
    
    
    /// <summary>
    /// ResearcherDetailView
    /// </summary>
    public partial class ResearcherDetailView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 101 "..\..\ResearcherDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PastPositionsBox;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\ResearcherDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox LowerLimit;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\ResearcherDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox UpperLimit;
        
        #line default
        #line hidden
        
        
        #line 133 "..\..\ResearcherDetailView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox PublicationsListView;
        
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
            System.Uri resourceLocater = new System.Uri("/test;component/researcherdetailview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ResearcherDetailView.xaml"
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
            
            #line 67 "..\..\ResearcherDetailView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CummulativeCount_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 98 "..\..\ResearcherDetailView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Supervisions_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.PastPositionsBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            
            #line 123 "..\..\ResearcherDetailView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.OldestToNewest_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 124 "..\..\ResearcherDetailView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NewestToOldest_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.LowerLimit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.UpperLimit = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 131 "..\..\ResearcherDetailView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PublicationSearch_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.PublicationsListView = ((System.Windows.Controls.ListBox)(target));
            
            #line 133 "..\..\ResearcherDetailView.xaml"
            this.PublicationsListView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Publication_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

