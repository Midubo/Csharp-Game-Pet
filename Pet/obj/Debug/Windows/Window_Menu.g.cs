﻿#pragma checksum "..\..\..\Windows\Window_Menu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FAAB3D58DE6E768E17B9430A378CFFC00DE09D244C788CD8109A33A8C76A9028"
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
    /// Window_Menu
    /// </summary>
    public partial class Window_Menu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 80 "..\..\..\Windows\Window_Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_Restart;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\Windows\Window_Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_MainMenu;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Windows\Window_Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox_Music;
        
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
            System.Uri resourceLocater = new System.Uri("/Pet;component/windows/window_menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\Window_Menu.xaml"
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
            
            #line 15 "..\..\..\Windows\Window_Menu.xaml"
            ((Pet.Window_Menu)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 16 "..\..\..\Windows\Window_Menu.xaml"
            ((Pet.Window_Menu)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 76 "..\..\..\Windows\Window_Menu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Continue);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 78 "..\..\..\Windows\Window_Menu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Save);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_Restart = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\..\Windows\Window_Menu.xaml"
            this.btn_Restart.Click += new System.Windows.RoutedEventHandler(this.btn_Restart_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btn_MainMenu = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\Windows\Window_Menu.xaml"
            this.btn_MainMenu.Click += new System.Windows.RoutedEventHandler(this.btn_MainMenu_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 97 "..\..\..\Windows\Window_Menu.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Exit);
            
            #line default
            #line hidden
            return;
            case 7:
            this.checkBox_Music = ((System.Windows.Controls.CheckBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

