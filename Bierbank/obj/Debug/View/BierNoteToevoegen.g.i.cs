﻿#pragma checksum "..\..\..\View\BierNoteToevoegen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "022E7178EECEBE2ED3510EC46CD9F2A9B47E73AA"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bierbank.View;
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


namespace Bierbank.View {
    
    
    /// <summary>
    /// BierNoteToevoegen
    /// </summary>
    public partial class BierNoteToevoegen : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\View\BierNoteToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KnopToevoegen;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\BierNoteToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup Popup;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\View\BierNoteToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KnopClosePopup;
        
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
            System.Uri resourceLocater = new System.Uri("/Bierbank;component/view/biernotetoevoegen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\BierNoteToevoegen.xaml"
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
            this.KnopToevoegen = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\View\BierNoteToevoegen.xaml"
            this.KnopToevoegen.Click += new System.Windows.RoutedEventHandler(this.KnopToevoegen_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 3:
            this.KnopClosePopup = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\View\BierNoteToevoegen.xaml"
            this.KnopClosePopup.Click += new System.Windows.RoutedEventHandler(this.KnopClosePopup_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

