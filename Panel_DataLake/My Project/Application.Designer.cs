﻿// ------------------------------------------------------------------------------
// <auto-generated>
// Este código fue generado por una herramienta.
// Versión de runtime:4.0.30319.42000
// 
// Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
// se vuelve a generar el código.
// </auto-generated>
// ------------------------------------------------------------------------------

using System.Diagnostics;

namespace Panel_DataLake.My
{

    // NOTA: Este archivo se genera automáticamente; no lo modifique directamente.  Para hacer cambios,
    // o si detecta errores de compilación en este archivo, vaya al Diseñador de proyectos
    // (vaya a Propiedades del proyecto o haga doble clic en el nodo My Project en el
    // Explorador de soluciones) y realice cambios en la pestaña Aplicación.
    // 
    internal partial class MyApplication
    {

        [DebuggerStepThrough()]
        public MyApplication() : base(Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
        {
            IsSingleInstance = false;
            EnableVisualStyles = true;
            SaveMySettingsOnExit = true;
            ShutdownStyle = Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses;
        }

        [DebuggerStepThrough()]
        protected override void OnCreateMainForm()
        {
            MainForm = MyProject.Forms.Form1;
        }

        [DebuggerStepThrough()]
        protected override bool OnInitialize(System.Collections.ObjectModel.ReadOnlyCollection<string> commandLineArgs)
        {
            MinimumSplashScreenDisplayTime = 0;
            return base.OnInitialize(commandLineArgs);
        }
    }
}