﻿#pragma checksum "..\..\..\View\BierToevoegen.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0200B679E697903B35CC7710E094AD8B9BAADA45"
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
    /// BierToevoegen
    /// </summary>
    public partial class BierToevoegen : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 37 "..\..\..\View\BierToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxNaam;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\BierToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxSoort;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\View\BierToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxPercentage;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\View\BierToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxBrouwerij;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\View\BierToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxImage;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\View\BierToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button KnopToevoegen;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\View\BierToevoegen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup Popup;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\View\BierToevoegen.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Bierbank;component/view/biertoevoegen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\BierToevoegen.xaml"
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
            this.textBoxNaam = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.textBoxSoort = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.textBoxPercentage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.textBoxBrouwerij = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.textBoxImage = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.KnopToevoegen = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\View\BierToevoegen.xaml"
            this.KnopToevoegen.Click += new System.Windows.RoutedEventHandler(this.KnopToevoegen_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Popup = ((System.Windows.Controls.Primitives.Popup)(target));
            return;
            case 8:
            this.KnopClosePopup = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\View\BierToevoegen.xaml"
            this.KnopClosePopup.Click += new System.Windows.RoutedEventHandler(this.KnopClosePopup_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

