﻿#pragma checksum "..\..\..\UserControls\UserControl_MainMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "18028C4CEF7157DED316024260148BF463EB72C819D1296130E7FD564974C2F1"
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


namespace Pet {
    
    
    /// <summary>
    /// UserControl_MainMenu
    /// </summary>
    public partial class UserControl_MainMenu : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 82 "..\..\..\UserControls\UserControl_MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Load;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\..\UserControls\UserControl_MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border border_Creators;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\UserControls\UserControl_MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Hyperlink link;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\UserControls\UserControl_MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tblc_version;
        
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
            System.Uri resourceLocater = new System.Uri("/Pet;component/usercontrols/usercontrol_mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\UserControl_MainMenu.xaml"
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
            
            #line 80 "..\..\..\UserControls\UserControl_MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Play_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_Load = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\UserControls\UserControl_MainMenu.xaml"
            this.btn_Load.Click += new System.Windows.RoutedEventHandler(this.btn_Load_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 84 "..\..\..\UserControls\UserControl_MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Options_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 86 "..\..\..\UserControls\UserControl_MainMenu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btn_Exit_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.border_Creators = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.link = ((System.Windows.Documents.Hyperlink)(target));
            
            #line 124 "..\..\..\UserControls\UserControl_MainMenu.xaml"
            this.link.RequestNavigate += new System.Windows.Navigation.RequestNavigateEventHandler(this.Hyperlink_RequestNavigate);
            
            #line default
            #line hidden
            return;
            case 7:
            this.tblc_version = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

