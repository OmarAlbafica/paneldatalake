using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Panel_DataLake
{
    /// <summary>
/// Clase para guardar Parametros de configuracion en un XML Version 3.5
/// </summary>
/// <remarks></remarks>
    public class CConfig
    {
        private MD5CryptoServiceProvider Md5 = new MD5CryptoServiceProvider();
        private SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
        private SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
        private SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
        private SHA512CryptoServiceProvider sha512 = new SHA512CryptoServiceProvider();
        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

        private byte[] TablaBytes = new byte[9001];

        private string _carpetaAplicativo;
        private string _carpetLogAplicativo;
        private string _NombreArchivoConf;
        private string _metodoEncriptar;
        private string _claveEncriptar;

        public string carpetaAplicativo
        {
            get
            {
                return _carpetaAplicativo;
            }
            set
            {
                _carpetaAplicativo = value;
            }
        }
        public string CarpetaLogAplicativo
        {
            get
            {
                return _carpetLogAplicativo;
            }
            set
            {
                _carpetLogAplicativo = value;
            }
        }
        public string NombreArchivoConf
        {
            get
            {
                return _NombreArchivoConf;
            }
            set
            {
                _NombreArchivoConf = value;
            }
        }
        public string MetodoEncriptar
        {
            get
            {
                return _metodoEncriptar;
            }
            set
            {
                _metodoEncriptar = value;
            }
        }
        public string ClaveEncriptar
        {
            get
            {
                return _claveEncriptar;
            }
            set
            {
                _claveEncriptar = value;
            }
        }

        public bool ExisteXML()
        {
            bool existe = false;
            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                existe = true;
            }

            return existe;
        }

        public void mylog(string identificador, string tipomsj, string mensaje, bool estado, string NombreArchivo = "")
        {
            try
            {
                if (!Directory.Exists(_carpetLogAplicativo))
                {
                    Directory.CreateDirectory(_carpetLogAplicativo);
                }

                if (estado == true)
                {
                    string ruta = _carpetLogAplicativo + "/" + NombreArchivo + DateTime.Today.ToString("dd-MM-yyyy") + ".log";
                    string encabezado = "[" + Conversions.ToString(DateTime.Now) + "] [" + identificador + "]";
                    if (encabezado.Length < 40)
                    {
                        for (int i = encabezado.Length; i <= 40; i++)
                            encabezado += "-";
                    }
                    File.AppendAllText(ruta, encabezado + "|" + tipomsj + "| " + mensaje + ControlChars.CrLf, Encoding.UTF8);
                    // File.AppendAllText(ruta, "[" & Date.Now & "] [" & identificador & "]" & ControlChars.Tab & "|" & tipomsj & "| " & mensaje & ControlChars.CrLf, System.Text.Encoding.UTF8)
                }
            }
            catch (Exception ex)
            {

                // mylog("mylog", "Error", "Exception: " & ex.Message, True)
            }


        }



        private XElement CrearNodo(Campo nodo)
        {
            var xNodo = new XElement(nodo.Nombre);
            if (nodo.Encriptar)
            {

                string ValorEncriptado = Encriptar_conKey(nodo.Valor, _metodoEncriptar, _claveEncriptar);
                xNodo.SetValue(ValorEncriptado);
            }

            else
            {
                xNodo.SetValue(nodo.Valor);
            }

            return xNodo;
        }
        private XElement CrearNodo(string Nombre, string Valor, bool Encriptar)
        {
            var xNodo = new XElement(Nombre);
            if (Encriptar)
            {

                string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                xNodo.SetValue(ValorEncriptado);
            }

            else
            {
                xNodo.SetValue(Valor);
            }

            return xNodo;
        }

        private XElement CrearAtributo(XElement Nodo, Campo Atributo)
        {
            if (Atributo.Encriptar)
            {

                string ValorEncriptado = Encriptar_conKey(Atributo.Valor, _metodoEncriptar, _claveEncriptar);
                Nodo.SetAttributeValue(Atributo.Nombre, ValorEncriptado);
            }

            else
            {
                Nodo.SetAttributeValue(Atributo.Nombre, Atributo.Valor);
            }

            return Nodo;
        }
        private XElement CrearAtributo(XElement Nodo, string Nombre, string Valor, bool Encriptar)
        {
            if (Encriptar)
            {

                string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                Nodo.SetAttributeValue(Nombre, ValorEncriptado);
            }

            else
            {
                Nodo.SetAttributeValue(Nombre, Valor);
            }

            return Nodo;
        }

        private bool ExisteNodo(XElement Nodo, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                if (Nodo.Descendants(name).Any())
                {
                    if (Nodo.Element(name) is not null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        private bool ExisteNodo(XDocument Nodo, string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return Nodo.Descendants(name).Any();
            }
            else
            {
                return false;
            }

        }

        public void GuardarNodo(string NodoPadre, string NodoHijo, Campo Nodo)
        {
            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado.Root, "Configuracion"))
                {
                    var Configuracion = XMLCargado.Element("Configuracion");

                    Validar:
                    ;

                    if (!string.IsNullOrEmpty(NodoPadre))
                    {

                        if (ExisteNodo(Configuracion, NodoPadre))
                        {
                            if (!string.IsNullOrEmpty(NodoHijo))
                            {

                                if (ExisteNodo(Configuracion, NodoHijo))
                                {
                                    if (!string.IsNullOrEmpty(Nodo.Nombre))
                                    {

                                        if (ExisteNodo(Configuracion, Nodo.Nombre))
                                        {


                                            if (Nodo.Encriptar)
                                            {
                                                string ValorEncriptado = Encriptar_conKey(Nodo.Valor, _metodoEncriptar, _claveEncriptar);

                                                Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(ValorEncriptado);
                                            }

                                            else
                                            {
                                                Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(Nodo.Valor);
                                            }

                                            Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                                        }
                                        else
                                        {
                                            // aqui debe crear Nodo.Nombre
                                            var xNodo = new XElement(Nodo.Nombre);
                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodo);

                                            goto Validar;

                                        }
                                    }
                                }
                                else
                                {
                                    // aqui debe crear NodoHijo
                                    var xNodoHijo = new XElement(NodoHijo);
                                    Configuracion.Element(NodoPadre).Add(xNodoHijo);

                                    goto Validar;
                                }

                            }
                        }
                        else
                        {
                            // aqui debe crear NodoPadre
                            var xNodoPadre = new XElement(NodoPadre);
                            Configuracion.Add(xNodoPadre);

                            goto Validar;
                        }
                    }
                    else if (!string.IsNullOrEmpty(NodoHijo))
                    {
                        if (ExisteNodo(Configuracion, NodoHijo))
                        {
                            if (!string.IsNullOrEmpty(Nodo.Nombre))
                            {
                                if (ExisteNodo(Configuracion, Nodo.Nombre))
                                {
                                    if (Nodo.Encriptar)
                                    {
                                        string ValorEncriptado = Encriptar_conKey(Nodo.Valor, _metodoEncriptar, _claveEncriptar);

                                        Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(ValorEncriptado);
                                    }

                                    else
                                    {
                                        Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(Nodo.Valor);
                                    }

                                    Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                                }
                                else
                                {
                                    // aqui debe crear Nodo.Nombre
                                    var xNodo = new XElement(Nodo.Nombre);
                                    Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodo);

                                    goto Validar;
                                }
                            }
                        }
                        else
                        {
                            // aqui debe crear NodoHijo
                            var xNodoHijo = new XElement(NodoHijo);
                            Configuracion.Element(NodoPadre).Add(xNodoHijo);

                            goto Validar;
                        }
                    }
                    else if (!string.IsNullOrEmpty(Nodo.Nombre))
                    {
                        if (ExisteNodo(Configuracion, Nodo.Nombre))
                        {
                            if (Nodo.Encriptar)
                            {
                                string ValorEncriptado = Encriptar_conKey(Nodo.Valor, _metodoEncriptar, _claveEncriptar);

                                Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(ValorEncriptado);
                            }

                            else
                            {
                                Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(Nodo.Valor);
                            }

                            Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                        }
                        else
                        {
                            // aqui debe crear Nodo.Nombre
                            var xNodo = new XElement(Nodo.Nombre);
                            Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodo);

                            goto Validar;
                        }
                    }
                }
            }

            else
            {
                var XMLNuevo = new XElement("Configuracion");

                if (!string.IsNullOrEmpty(NodoPadre))
                {
                    if (!string.IsNullOrEmpty(NodoHijo))
                    {
                        if (!string.IsNullOrEmpty(Nodo.Nombre))
                        {
                            var xNodoPadre = new XElement(NodoPadre);
                            var xNodoHijo = new XElement(NodoHijo);

                            // retorna un nodo ya hecho
                            var xNodo = CrearNodo(Nodo);

                            xNodoHijo.Add(xNodo);
                            xNodoPadre.Add(xNodoHijo);
                            XMLNuevo.Add(xNodoPadre);

                            XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                        }

                    }
                }
                else if (!string.IsNullOrEmpty(NodoHijo))
                {
                    if (!string.IsNullOrEmpty(Nodo.Nombre))
                    {
                        var xNodoHijo = new XElement(NodoHijo);

                        // retorna un nodo ya hecho
                        var xNodo = CrearNodo(Nodo);

                        xNodoHijo.Add(xNodo);
                        XMLNuevo.Add(xNodoHijo);

                        XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                    }
                }
                else if (!string.IsNullOrEmpty(Nodo.Nombre))
                {

                    // retorna un nodo ya hecho
                    var xNodo = CrearNodo(Nodo);

                    XMLNuevo.Add(xNodo);

                    XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                }
            }
        }
        public void GuardarNodo(string NodoPadre, string NodoHijo, string Nombre, string Valor, bool Encriptar)
        {
            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado, "Configuracion"))
                {
                    var Configuracion = XMLCargado.Element("Configuracion");

                    Validar:
                    ;

                    if (!string.IsNullOrEmpty(NodoPadre))
                    {

                        if (ExisteNodo(Configuracion, NodoPadre))
                        {

                            if (!string.IsNullOrEmpty(NodoHijo))
                            {

                                if (ExisteNodo(Configuracion, NodoHijo))
                                {

                                    if (!string.IsNullOrEmpty(Nombre))
                                    {

                                        if (ExisteNodo(Configuracion, Nombre))
                                        {


                                            if (Encriptar)
                                            {
                                                string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);

                                                Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nombre).SetValue(ValorEncriptado);
                                            }

                                            else
                                            {
                                                Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nombre).SetValue(Valor);
                                            }

                                            Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                                        }
                                        else
                                        {
                                            // aqui debe crear Nombre

                                            var xNodo = new XElement(Nombre);
                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodo);

                                            goto Validar;

                                        }
                                    }
                                }
                                else
                                {
                                    // aqui debe crear NodoHijo

                                    var xNodoHijo = new XElement(NodoHijo);
                                    Configuracion.Element(NodoPadre).Add(xNodoHijo);

                                    goto Validar;
                                }

                            }
                        }
                        else
                        {
                            // aqui debe crear NodoPadre

                            var xNodoPadre = new XElement(NodoPadre);
                            Configuracion.Add(xNodoPadre);

                            goto Validar;
                        }
                    }
                    else if (!string.IsNullOrEmpty(NodoHijo))
                    {
                        if (ExisteNodo(Configuracion, NodoHijo))
                        {
                            if (!string.IsNullOrEmpty(Nombre))
                            {
                                if (ExisteNodo(Configuracion, Nombre))
                                {
                                    if (Encriptar)
                                    {
                                        string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);

                                        Configuracion.Element(NodoHijo).Element(Nombre).SetValue(ValorEncriptado);
                                    }

                                    else
                                    {
                                        Configuracion.Element(NodoHijo).Element(Nombre).SetValue(Valor);
                                    }

                                    Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                                }
                                else
                                {
                                    // aqui debe crear Nombre

                                    var xNodo = new XElement(Nombre);
                                    Configuracion.Element(NodoHijo).Add(xNodo);

                                    goto Validar;
                                }
                            }
                        }
                        else
                        {
                            // aqui debe crear NodoHijo

                            var xNodoHijo = new XElement(NodoHijo);
                            Configuracion.Add(xNodoHijo);

                            goto Validar;
                        }
                    }
                    else if (!string.IsNullOrEmpty(Nombre))
                    {
                        if (ExisteNodo(Configuracion, Nombre))
                        {
                            if (Encriptar)
                            {
                                string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);

                                Configuracion.Element(Nombre).SetValue(ValorEncriptado);
                            }

                            else
                            {
                                Configuracion.Element(Nombre).SetValue(Valor);
                            }

                            Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                        }
                        else
                        {
                            // aqui debe crear Nombre

                            var xNodo = new XElement(Nombre);
                            Configuracion.Add(xNodo);

                            goto Validar;
                        }
                    }
                }
            }

            else
            {
                var XMLNuevo = new XElement("Configuracion");

                if (!string.IsNullOrEmpty(NodoPadre))
                {
                    if (!string.IsNullOrEmpty(NodoHijo))
                    {
                        if (!string.IsNullOrEmpty(Nombre))
                        {
                            var xNodoPadre = new XElement(NodoPadre);
                            var xNodoHijo = new XElement(NodoHijo);

                            // retorna un nodo ya hecho
                            var nodo = new Campo();
                            nodo.Nombre = Nombre;
                            nodo.Valor = Valor;
                            nodo.Encriptar = Encriptar;

                            var xNodo = CrearNodo(nodo);

                            xNodoHijo.Add(xNodo);
                            xNodoPadre.Add(xNodoHijo);
                            XMLNuevo.Add(xNodoPadre);

                            XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                        }

                    }
                }
                else if (!string.IsNullOrEmpty(NodoHijo))
                {
                    if (!string.IsNullOrEmpty(Nombre))
                    {
                        var xNodoHijo = new XElement(NodoHijo);

                        // retorna un nodo ya hecho
                        var nodo = new Campo();
                        nodo.Nombre = Nombre;
                        nodo.Valor = Valor;
                        nodo.Encriptar = Encriptar;

                        var xNodo = CrearNodo(nodo);

                        xNodoHijo.Add(xNodo);
                        XMLNuevo.Add(xNodoHijo);

                        XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                    }
                }
                else if (!string.IsNullOrEmpty(Nombre))
                {

                    // retorna un nodo ya hecho
                    var nodo = new Campo();
                    nodo.Nombre = Nombre;
                    nodo.Valor = Valor;
                    nodo.Encriptar = Encriptar;

                    var xNodo = CrearNodo(nodo);

                    XMLNuevo.Add(xNodo);

                    XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                }
            }
        }

        public void GuardarNodos(string NodoPadre, string NodoHijo, List<Campo> Nodos)
        {

            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
            }

            else
            {

            }
        }

        public void GuardarAtributo(string NodoPadre, string NodoLeer, Campo Atributo)
        {
            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado.Root, "Configuracion"))
                {
                    var Configuracion = XMLCargado.Element("Configuracion");

                    Validar:
                    ;

                    if (!string.IsNullOrEmpty(NodoPadre))
                    {

                        if (ExisteNodo(Configuracion, NodoPadre))
                        {
                            if (!string.IsNullOrEmpty(NodoLeer))
                            {

                                if (ExisteNodo(Configuracion, NodoLeer))
                                {


                                    if (Atributo.Encriptar)
                                    {
                                        string ValorEncriptado = Encriptar_conKey(Atributo.Valor, _metodoEncriptar, _claveEncriptar);
                                        Configuracion.Element(NodoPadre).Element(NodoLeer).SetAttributeValue(Atributo.Nombre, ValorEncriptado);
                                    }
                                    else
                                    {
                                        Configuracion.Element(NodoPadre).Element(NodoLeer).SetAttributeValue(Atributo.Nombre, Atributo.Valor);
                                    }

                                    Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                                }
                                else
                                {
                                    // aqui debe crear NodoLeer
                                    var xNodoLeer = new XElement(NodoLeer);
                                    Configuracion.Element(NodoPadre).Add(xNodoLeer);

                                    goto Validar;
                                }
                            }
                        }
                        else
                        {
                            // aqui deberia crear NodoPadre
                            var xNodoPadre = new XElement(NodoPadre);
                            Configuracion.Add(xNodoPadre);

                            goto Validar;
                        }
                    }
                    else if (!string.IsNullOrEmpty(NodoLeer))
                    {
                        if (ExisteNodo(Configuracion, NodoLeer))
                        {

                            if (Atributo.Encriptar)
                            {
                                string ValorEncriptado = Encriptar_conKey(Atributo.Valor, _metodoEncriptar, _claveEncriptar);
                                Configuracion.Element(NodoLeer).SetAttributeValue(Atributo.Nombre, ValorEncriptado);
                            }
                            else
                            {
                                Configuracion.Element(NodoLeer).SetAttributeValue(Atributo.Nombre, Atributo.Valor);
                            }
                            Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                        }
                        else
                        {
                            // aqui debe crear NodoLeer
                            var xNodoLeer = new XElement(NodoLeer);
                            Configuracion.Add(xNodoLeer);

                            goto Validar;
                        }
                    }
                }
            }
            else
            {
                var XMLNuevo = new XElement("Configuracion");

                if (!string.IsNullOrEmpty(NodoPadre))
                {
                    if (!string.IsNullOrEmpty(NodoLeer))
                    {
                        var xNodoPadre = new XElement(NodoPadre);
                        var xNodoLeer = new XElement(NodoLeer);

                        xNodoLeer = CrearAtributo(xNodoLeer, Atributo);

                        xNodoPadre.Add(xNodoLeer);
                        XMLNuevo.Add(xNodoPadre);

                        XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                    }
                }
                else if (!string.IsNullOrEmpty(NodoLeer))
                {
                    var xNodoLeer = new XElement(NodoLeer);

                    xNodoLeer = CrearAtributo(xNodoLeer, Atributo);

                    XMLNuevo.Add(xNodoLeer);

                    XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                }
            }
        }
        public void GuardarAtributo(string NodoPadre, string NodoLeer, string Nombre, string Valor, ref bool Encriptar)
        {

            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado, "Configuracion"))
                {
                    var Configuracion = XMLCargado.Element("Configuracion");

                    Validar:
                    ;

                    if (!string.IsNullOrEmpty(NodoPadre))
                    {

                        if (ExisteNodo(Configuracion, NodoPadre))
                        {

                            if (!string.IsNullOrEmpty(NodoLeer))
                            {


                                if (ExisteNodo(Configuracion.Element(NodoPadre), NodoLeer))
                                {

                                    if (Encriptar)
                                    {
                                        string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                                        Configuracion.Element(NodoPadre).Element(NodoLeer).SetAttributeValue(Nombre, ValorEncriptado);
                                    }
                                    else
                                    {
                                        Configuracion.Element(NodoPadre).Element(NodoLeer).SetAttributeValue(Nombre, Valor);
                                    }

                                    Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                                }
                                else
                                {
                                    // aqui debe crear NodoLeer
                                    var xNodoLeer = new XElement(NodoLeer);
                                    Configuracion.Element(NodoPadre).Add(xNodoLeer);

                                    goto Validar;
                                }
                            }
                        }
                        else
                        {
                            // aqui debe crear NodoPadre
                            var xNodoPadre = new XElement(NodoPadre);
                            Configuracion.Add(xNodoPadre);

                            goto Validar;
                        }
                    }
                    else if (!string.IsNullOrEmpty(NodoLeer))
                    {
                        if (ExisteNodo(Configuracion, NodoLeer))
                        {

                            if (Encriptar)
                            {
                                string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                                Configuracion.Element(NodoLeer).SetAttributeValue(Nombre, ValorEncriptado);
                            }
                            else
                            {
                                Configuracion.Element(NodoLeer).SetAttributeValue(Nombre, Valor);
                            }
                            Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                        }
                        else
                        {
                            // aqui debe crear NodoLeer
                            var xNodoLeer = new XElement(NodoLeer);
                            Configuracion.Add(xNodoLeer);

                            goto Validar;

                        }
                    }
                }
            }
            else
            {
                var XMLNuevo = new XElement("Configuracion");

                if (!string.IsNullOrEmpty(NodoPadre))
                {
                    if (!string.IsNullOrEmpty(NodoLeer))
                    {
                        var xNodoPadre = new XElement(NodoPadre);
                        var xNodoLeer = new XElement(NodoLeer);

                        xNodoLeer = CrearAtributo(xNodoLeer, Nombre, Valor, Encriptar);

                        xNodoPadre.Add(xNodoLeer);
                        XMLNuevo.Add(xNodoPadre);

                        XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                    }
                }
                else if (!string.IsNullOrEmpty(NodoLeer))
                {
                    var xNodoLeer = new XElement(NodoLeer);

                    xNodoLeer = CrearAtributo(xNodoLeer, Nombre, Valor, Encriptar);

                    XMLNuevo.Add(xNodoLeer);

                    XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                }
            }
        }
        public void GuardarAtributo(string Nodo, string Nombre, string Valor, ref bool encriptar)
        {
            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado, "Configuracion"))
                {
                    var Configuracion = XMLCargado.Element("Configuracion");

                    if (Nodo.Contains("."))
                    {
                        var NodoActual = Configuracion;
                        string[] Nodos = Nodo.Split('.');

                        foreach (string NombreNodo in Nodos)
                        {
                            if (ExisteNodo(NodoActual, NombreNodo))
                            {
                                NodoActual = NodoActual.Element(NombreNodo);
                            }
                            else
                            {
                                var xNodo = new XElement(NombreNodo);
                                NodoActual.Add(xNodo);

                                NodoActual = NodoActual.Element(NombreNodo);
                            }
                        }

                        if (encriptar)
                        {
                            string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                            NodoActual.SetAttributeValue(Nombre, ValorEncriptado);
                        }
                        else
                        {
                            NodoActual.SetAttributeValue(Nombre, Valor);
                        }

                        Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                    }
                    // Unico Nodo

                    else if (ExisteNodo(Configuracion, Nodo))
                    {
                        if (encriptar)
                        {
                            string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                            Configuracion.Element(Nodo).SetAttributeValue(Nombre, ValorEncriptado);
                        }
                        else
                        {
                            Configuracion.Element(Nodo).SetAttributeValue(Nombre, Valor);
                        }
                    }
                    else
                    {
                        var xNodo = new XElement(Nodo);
                        Configuracion.Add(xNodo);

                        if (encriptar)
                        {
                            string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                            Configuracion.Element(Nodo).SetAttributeValue(Nombre, ValorEncriptado);
                        }
                        else
                        {
                            Configuracion.Element(Nodo).SetAttributeValue(Nombre, Valor);
                        }
                    }
                }
            }
            else
            {
                var XMLNuevo = new XElement("Configuracion");

                if (Nodo.Contains("."))
                {
                    var NodoActual = XMLNuevo;
                    string[] Nodos = Nodo.Split('.');

                    foreach (string NombreNodo in Nodos)
                    {
                        if (ExisteNodo(NodoActual, NombreNodo))
                        {
                            NodoActual = NodoActual.Element(NombreNodo);
                        }
                        else
                        {
                            var xNodo = new XElement(NombreNodo);
                            NodoActual.Add(xNodo);

                            NodoActual = NodoActual.Element(NombreNodo);
                        }
                    }

                    if (encriptar)
                    {
                        string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                        NodoActual.SetAttributeValue(Nombre, ValorEncriptado);
                    }
                    else
                    {
                        NodoActual.SetAttributeValue(Nombre, Valor);
                    }

                    XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                }
                else
                {
                    // Unico Nodo
                    var xNodo = new XElement(Nodo);
                    XMLNuevo.Add(xNodo);

                    if (encriptar)
                    {
                        string ValorEncriptado = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar);
                        XMLNuevo.Element(Nodo).SetAttributeValue(Nombre, ValorEncriptado);
                    }
                    else
                    {
                        XMLNuevo.Element(Nodo).SetAttributeValue(Nombre, Valor);
                    }

                    XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                }
            }
        }

        /// <summary>
    /// En esta Funcion el nombre de se guarda una lista de nodos con sus respectivos atributos
    /// </summary>
    /// <param name="NodoPadre"></param>
    /// <param name="NodoLeer"></param>
    /// <param name="NodosConAtributos"></param>
    /// <remarks></remarks>
        public void GuardarNodosConAtributos(string NodoPadre, string NodoHijo, string NodoLeer, List<NodoConAtributos> NodosConAtributos)
        {

            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado, "Configuracion"))
                {
                    var Configuracion = XMLCargado.Element("Configuracion");

                    Validar:
                    ;

                    if (!string.IsNullOrEmpty(NodoPadre))
                    {

                        if (ExisteNodo(Configuracion, NodoPadre))
                        {

                            if (!string.IsNullOrEmpty(NodoHijo))
                            {
                                if (ExisteNodo(Configuracion.Element(NodoPadre), NodoHijo))
                                {

                                    if (!string.IsNullOrEmpty(NodoLeer))
                                    {

                                        if (ExisteNodo(Configuracion.Element(NodoPadre).Element(NodoHijo), NodoLeer))
                                        {

                                            if (Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer).HasElements)
                                            {
                                                Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer).RemoveNodes();
                                            }


                                            foreach (NodoConAtributos Nodo in NodosConAtributos)
                                            {

                                                var xNodo = new XElement(Nodo.Nombre);

                                                foreach (Campo Atributo in Nodo.Atributos)


                                                    xNodo = CrearAtributo(xNodo, Atributo);
                                                Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer).Add(xNodo);

                                            }

                                            Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                                        }
                                        else
                                        {
                                            // aqui deberia crear NodoLeer
                                            var xNodoLeer = new XElement(NodoLeer);
                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodoLeer);

                                            goto Validar;
                                        }
                                    }
                                }

                                else
                                {
                                    // aqui deberia crear NodoLeer
                                    var xNodoHijo = new XElement(NodoHijo);
                                    Configuracion.Element(NodoPadre).Add(xNodoHijo);

                                    goto Validar;
                                }
                            }
                        }
                        else
                        {
                            // aqui deberia crear NodoPadre
                            var xNodoPadre = new XElement(NodoPadre);
                            Configuracion.Add(xNodoPadre);

                            goto Validar;
                        }
                    }
                    else if (!string.IsNullOrEmpty(NodoHijo))
                    {
                        if (ExisteNodo(Configuracion, NodoHijo))
                        {
                            if (!string.IsNullOrEmpty(NodoLeer))
                            {
                                if (ExisteNodo(Configuracion.Element(NodoHijo), NodoLeer))
                                {

                                    if (Configuracion.Element(NodoHijo).Element(NodoLeer).HasElements)
                                    {
                                        Configuracion.Element(NodoHijo).Element(NodoLeer).RemoveNodes();
                                    }

                                    foreach (NodoConAtributos Nodo in NodosConAtributos)
                                    {

                                        var xNodo = new XElement(Nodo.Nombre);

                                        foreach (Campo Atributo in Nodo.Atributos)


                                            xNodo = CrearAtributo(xNodo, Atributo);
                                        Configuracion.Element(NodoHijo).Element(NodoLeer).Add(xNodo);

                                    }

                                    Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                                }

                                else
                                {
                                    // aqui deberia crear NodoLeer
                                    var xNodoLeer = new XElement(NodoLeer);
                                    Configuracion.Element(NodoHijo).Add(xNodoLeer);

                                    goto Validar;
                                }
                            }
                        }
                        else
                        {
                            // aqui deberia crear NodoLeer
                            var xNodoHijo = new XElement(NodoHijo);
                            Configuracion.Add(xNodoHijo);

                            goto Validar;
                        }
                    }
                    else if (!string.IsNullOrEmpty(NodoLeer))
                    {
                        if (ExisteNodo(Configuracion, NodoLeer))
                        {

                            if (Configuracion.Element(NodoLeer).HasElements)
                            {
                                Configuracion.Element(NodoLeer).RemoveNodes();
                            }

                            foreach (NodoConAtributos Nodo in NodosConAtributos)
                            {

                                var xNodo = new XElement(Nodo.Nombre);

                                foreach (Campo Atributo in Nodo.Atributos)


                                    xNodo = CrearAtributo(xNodo, Atributo);
                                Configuracion.Element(NodoLeer).Add(xNodo);

                            }

                            Configuracion.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                        }
                        else
                        {
                            // aqui deberia crear NodoLeer
                            var xNodoLeer = new XElement(NodoLeer);
                            Configuracion.Add(xNodoLeer);

                            goto Validar;
                        }

                    }
                }
            }
            else
            {
                var XMLNuevo = new XElement("Configuracion");

                if (!string.IsNullOrEmpty(NodoPadre))
                {
                    if (!string.IsNullOrEmpty(NodoHijo))
                    {
                        if (!string.IsNullOrEmpty(NodoLeer))
                        {

                            var xNodoPadre = new XElement(NodoPadre);
                            var xNodoHijo = new XElement(NodoHijo);
                            var xNodoLeer = new XElement(NodoLeer);

                            foreach (NodoConAtributos Nodo in NodosConAtributos)
                            {

                                var xNodo = new XElement(Nodo.Nombre);

                                foreach (Campo Atributo in Nodo.Atributos)


                                    xNodo = CrearAtributo(xNodo, Atributo);

                                xNodoLeer.Add(xNodo);
                            }

                            xNodoHijo.Add(xNodoLeer);
                            xNodoPadre.Add(xNodoHijo);
                            XMLNuevo.Add(xNodoPadre);

                            XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                        }

                    }
                }
                else if (!string.IsNullOrEmpty(NodoHijo))
                {
                    if (!string.IsNullOrEmpty(NodoLeer))
                    {
                        var xNodoHijo = new XElement(NodoHijo);
                        var xNodoLeer = new XElement(NodoLeer);

                        foreach (NodoConAtributos Nodo in NodosConAtributos)
                        {

                            var xNodo = new XElement(Nodo.Nombre);

                            foreach (Campo Atributo in Nodo.Atributos)


                                xNodo = CrearAtributo(xNodo, Atributo);

                            xNodoLeer.Add(xNodo);
                        }

                        xNodoHijo.Add(xNodoLeer);
                        XMLNuevo.Add(xNodoHijo);
                        XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");
                    }
                }
                else if (!string.IsNullOrEmpty(NodoLeer))
                {
                    var xNodoLeer = new XElement(NodoLeer);

                    foreach (NodoConAtributos Nodo in NodosConAtributos)
                    {

                        var xNodo = new XElement(Nodo.Nombre);

                        foreach (Campo Atributo in Nodo.Atributos)


                            xNodo = CrearAtributo(xNodo, Atributo);

                        xNodoLeer.Add(xNodo);
                    }

                    XMLNuevo.Add(xNodoLeer);
                    XMLNuevo.Save(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                }
            }
        }

        public string LeerNodo(string NodoPadre, string NodoHijo, string Nombre, bool Encriptar)
        {
            string resultado = "";

            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado, "Configuracion"))
                {

                    var Configuracion = XMLCargado.Element("Configuracion");

                    if (ExisteNodo(Configuracion, NodoPadre) == true & ExisteNodo(Configuracion, NodoHijo) == true & ExisteNodo(Configuracion, Nombre) == true)
                    {

                        if (Encriptar)
                        {
                            string ValorEncriptado = Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nombre).Value;
                            resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar);
                        }
                        else
                        {
                            resultado = Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nombre).Value;
                        }
                    }

                    else if (ExisteNodo(Configuracion, NodoPadre) == false & ExisteNodo(Configuracion, NodoHijo) == true & ExisteNodo(Configuracion, Nombre) == true)
                    {

                        if (Encriptar)
                        {
                            string ValorEncriptado = Configuracion.Element(NodoHijo).Element(Nombre).Value;
                            resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar);
                        }
                        else
                        {
                            resultado = Configuracion.Element(NodoHijo).Element(Nombre).Value;
                        }
                    }

                    else if (ExisteNodo(Configuracion, NodoPadre) == false & ExisteNodo(Configuracion, NodoHijo) == false & ExisteNodo(Configuracion, Nombre) == true)
                    {

                        if (Encriptar)
                        {
                            string ValorEncriptado = Configuracion.Element(Nombre).Value;
                            resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar);
                        }
                        else
                        {
                            resultado = Configuracion.Element(Nombre).Value;
                        }

                    }

                }
            }

            return resultado;
        }

        public List<NodoConAtributos> LeerNodosConAtributos(string NodoPadre, string NodoHijo, string NodoLeer, string NodoFiltro)
        {
            var NodosConAtributos = new List<NodoConAtributos>();

            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado, "Configuracion"))
                {

                    var Configuracion = XMLCargado.Element("Configuracion");

                    if (ExisteNodo(Configuracion, NodoPadre))
                    {
                        if (ExisteNodo(Configuracion.Element(NodoPadre), NodoHijo))
                        {
                            if (ExisteNodo(Configuracion.Element(NodoPadre).Element(NodoHijo), NodoLeer))
                            {

                                var xNodoLeer = Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer);

                                var ListaNodos = xNodoLeer.Descendants(NodoFiltro);

                                if (ListaNodos.Count() != 0)
                                {

                                    foreach (XElement LNodo in ListaNodos)
                                    {
                                        var Nodo = new NodoConAtributos();

                                        Nodo.Nombre = LNodo.Name.ToString();

                                        var atributos = new List<Campo>();
                                        foreach (XAttribute Latributo in LNodo.Attributes())
                                        {
                                            var atributo = new Campo();

                                            atributo.Nombre = Latributo.Name.ToString();
                                            atributo.Valor = Latributo.Value;
                                            atributo.Encriptar = false;

                                            atributos.Add(atributo);
                                        }

                                        Nodo.Atributos = atributos;

                                        NodosConAtributos.Add(Nodo);
                                    }

                                }

                            }

                        }
                    }
                    else if (string.IsNullOrEmpty(NodoPadre))
                    {
                        if (ExisteNodo(Configuracion, NodoHijo))
                        {
                            if (ExisteNodo(Configuracion.Element(NodoHijo), NodoLeer))
                            {

                                var xNodoLeer = Configuracion.Element(NodoHijo).Element(NodoLeer);

                                var ListaNodos = xNodoLeer.Descendants(NodoFiltro);

                                if (ListaNodos.Count() != 0)
                                {

                                    foreach (XElement LNodo in ListaNodos)
                                    {
                                        var Nodo = new NodoConAtributos();

                                        Nodo.Nombre = LNodo.Name.ToString();

                                        var atributos = new List<Campo>();
                                        foreach (XAttribute Latributo in LNodo.Attributes())
                                        {
                                            var atributo = new Campo();

                                            atributo.Nombre = Latributo.Name.ToString();
                                            atributo.Valor = Latributo.Value;
                                            atributo.Encriptar = false;

                                            atributos.Add(atributo);
                                        }

                                        Nodo.Atributos = atributos;

                                        NodosConAtributos.Add(Nodo);
                                    }

                                }

                            }
                        }
                        else if (string.IsNullOrEmpty(NodoHijo)) // valida que en entro aqui xq no lleva NodoHijo
                        {
                            if (ExisteNodo(Configuracion, NodoLeer))
                            {

                                var xNodoLeer = Configuracion.Element(NodoLeer);

                                var ListaNodos = xNodoLeer.Descendants(NodoFiltro);

                                if (ListaNodos.Count() != 0)
                                {

                                    foreach (XElement LNodo in ListaNodos)
                                    {
                                        var Nodo = new NodoConAtributos();

                                        Nodo.Nombre = LNodo.Name.ToString();

                                        var atributos = new List<Campo>();
                                        foreach (XAttribute Latributo in LNodo.Attributes())
                                        {
                                            var atributo = new Campo();

                                            atributo.Nombre = Latributo.Name.ToString();
                                            atributo.Valor = Latributo.Value;
                                            atributo.Encriptar = false;

                                            atributos.Add(atributo);
                                        }

                                        Nodo.Atributos = atributos;

                                        NodosConAtributos.Add(Nodo);
                                    }

                                }

                            }
                        }
                    }
                }
            }

            return NodosConAtributos;
        }

        public string LeerAtributo(string NodoPadre, string NodoHijo, string NodoLeer, string NombreAtributo, bool Encriptar)
        {
            string resultado = "";

            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado, "Configuracion"))
                {

                    var Configuracion = XMLCargado.Element("Configuracion");

                    if (ExisteNodo(Configuracion, NodoPadre))
                    {
                        if (ExisteNodo(Configuracion.Element(NodoPadre), NodoHijo))
                        {
                            if (ExisteNodo(Configuracion.Element(NodoPadre).Element(NodoHijo), NodoLeer))
                            {

                                var xNodoLeer = Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer);

                                if (xNodoLeer.HasAttributes)
                                {

                                    if (xNodoLeer.Attributes().Any(d => d.Name == NombreAtributo))
                                    {

                                        if (Encriptar)
                                        {
                                            string ValorEncriptado = xNodoLeer.Attribute(NombreAtributo).Value;
                                            if (!string.IsNullOrEmpty(ValorEncriptado))
                                            {
                                                resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar);
                                            }
                                            else
                                            {
                                                resultado = ValorEncriptado;
                                            }
                                        }
                                        else
                                        {
                                            resultado = xNodoLeer.Attribute(NombreAtributo).Value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (string.IsNullOrEmpty(NodoPadre))
                    {
                        if (ExisteNodo(Configuracion, NodoHijo))
                        {
                            if (ExisteNodo(Configuracion.Element(NodoHijo), NodoLeer))
                            {

                                var xNodoLeer = Configuracion.Element(NodoHijo).Element(NodoLeer);

                                if (xNodoLeer.HasAttributes)
                                {

                                    if (xNodoLeer.Attributes().Any(d => d.Name == NombreAtributo))
                                    {

                                        if (Encriptar)
                                        {
                                            string ValorEncriptado = xNodoLeer.Attribute(NombreAtributo).Value;
                                            if (!string.IsNullOrEmpty(ValorEncriptado))
                                            {
                                                resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar);
                                            }
                                            else
                                            {
                                                resultado = ValorEncriptado;
                                            }
                                        }
                                        else
                                        {
                                            resultado = xNodoLeer.Attribute(NombreAtributo).Value;
                                        }
                                    }
                                }
                            }
                        }
                        else if (ExisteNodo(Configuracion, NodoLeer))
                        {
                            if (string.IsNullOrEmpty(NodoHijo)) // valida que en entro aqui xq no lleva NodoHijo
                            {

                                var xNodoLeer = Configuracion.Element(NodoLeer);

                                if (xNodoLeer.HasAttributes)
                                {

                                    if (xNodoLeer.Attributes().Any(d => d.Name == NombreAtributo))
                                    {

                                        if (Encriptar)
                                        {
                                            string ValorEncriptado = xNodoLeer.Attribute(NombreAtributo).Value;
                                            if (!string.IsNullOrEmpty(ValorEncriptado))
                                            {
                                                resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar);
                                            }
                                            else
                                            {
                                                resultado = ValorEncriptado;
                                            }
                                        }
                                        else
                                        {
                                            resultado = xNodoLeer.Attribute(NombreAtributo).Value;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return resultado;
        }
        public string LeerAtributo(string Nodo, string NombreAtributo, bool Encriptar)
        {
            string resultado = "";

            if (File.Exists(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml"))
            {
                var XMLCargado = XDocument.Load(_carpetaAplicativo + "/" + _NombreArchivoConf + ".xml");

                if (ExisteNodo(XMLCargado, "Configuracion"))
                {

                    var Configuracion = XMLCargado.Element("Configuracion");

                    if (Nodo.Contains("."))
                    {
                        var NodoActual = Configuracion;
                        string[] Nodos = Nodo.Split('.');

                        bool existen = true;
                        foreach (string NombreNodo in Nodos)
                        {
                            if (ExisteNodo(NodoActual, NombreNodo))
                            {
                                NodoActual = NodoActual.Element(NombreNodo);
                            }
                            else
                            {
                                existen = false;
                            }
                        }

                        if (existen)
                        {
                            if (NodoActual.HasAttributes)
                            {
                                if (NodoActual.Attributes().Any(d => d.Name == NombreAtributo))
                                {

                                    if (Encriptar)
                                    {
                                        string ValorEncriptado = NodoActual.Attribute(NombreAtributo).Value;
                                        if (!string.IsNullOrEmpty(ValorEncriptado))
                                        {
                                            resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar);
                                        }
                                        else
                                        {
                                            resultado = ValorEncriptado;
                                        }
                                    }
                                    else
                                    {
                                        resultado = NodoActual.Attribute(NombreAtributo).Value;
                                    }
                                }
                            }
                        }
                    }
                    // unico Nodo
                    else if (ExisteNodo(Configuracion, Nodo))
                    {
                        if (Configuracion.Element(Nodo).HasAttributes)
                        {
                            if (Configuracion.Element(Nodo).Attributes().Any(d => d.Name == NombreAtributo))
                            {

                                if (Encriptar)
                                {
                                    string ValorEncriptado = Configuracion.Element(Nodo).Attribute(NombreAtributo).Value;
                                    if (!string.IsNullOrEmpty(ValorEncriptado))
                                    {
                                        resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar);
                                    }
                                    else
                                    {
                                        resultado = ValorEncriptado;
                                    }
                                }
                                else
                                {
                                    resultado = Configuracion.Element(Nodo).Attribute(NombreAtributo).Value;
                                }
                            }
                        }

                    }
                }
            }

            return resultado;
        }

        public string Encriptar_conKey(string TxEncriptar, string tipoEncriptacion, string key)
        {
            string texto_encriptado = "";
            var Codificar = new UTF8Encoding();
            byte[] BytesTexto = Codificar.GetBytes(TxEncriptar);
            byte[] Byteskey = Codificar.GetBytes(key);
            // Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(TxEncriptar)
            try
            {

                switch (tipoEncriptacion ?? "")
                {
                    case "MD5":
                        {
                            des.Key = Md5.ComputeHash(Byteskey);
                            break;
                        }
                    case "MD5(SHA1)":
                        {
                            TablaBytes = sha1.ComputeHash(Byteskey);
                            des.Key = Md5.ComputeHash(TablaBytes);
                            break;
                        }
                    case "MD5(sha256)":
                        {
                            TablaBytes = sha256.ComputeHash(Byteskey);
                            des.Key = Md5.ComputeHash(TablaBytes);
                            break;
                        }
                    case "MD5(SHA384)":
                        {
                            TablaBytes = sha384.ComputeHash(Byteskey);
                            des.Key = Md5.ComputeHash(TablaBytes);
                            break;
                        }
                    case "MD5(SHA512)":
                        {
                            TablaBytes = sha512.ComputeHash(Byteskey);
                            des.Key = Md5.ComputeHash(TablaBytes);
                            break;
                        }

                }
                // des.GenerateIV()
                des.Mode = CipherMode.ECB;

                texto_encriptado = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(BytesTexto, 0, BytesTexto.Length));
            }

            catch (CryptographicException ex)
            {
                mylog("Encriptar_conKey", "Error", ex.Message, true);
            }
            catch (Exception ex)
            {
                mylog("Encriptar_conKey", "Error", ex.Message, true);
            }
            finally
            {
                // texto_encriptado = TxEncriptar
            }

            Codificar = null;
            BytesTexto = null;
            Byteskey = null;

            return texto_encriptado;
        }

        public string Desencriptar_conKey(string TxDesencriptar, string tipoEncriptacion, string key)
        {
            string texto_desencriptado = "";
            var Codificar = new UTF8Encoding();
            byte[] BytesTexto = Convert.FromBase64String(TxDesencriptar);
            byte[] Byteskey = Codificar.GetBytes(key);
            // Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(TxEncriptar)
            try
            {
                switch (tipoEncriptacion ?? "")
                {
                    case "MD5":
                        {
                            des.Key = Md5.ComputeHash(Byteskey);
                            break;
                        }
                    case "MD5(SHA1)":
                        {
                            TablaBytes = sha1.ComputeHash(Byteskey);
                            des.Key = Md5.ComputeHash(TablaBytes);
                            break;
                        }
                    case "MD5(sha256)":
                        {
                            TablaBytes = sha256.ComputeHash(Byteskey);
                            des.Key = Md5.ComputeHash(TablaBytes);
                            break;
                        }
                    case "MD5(SHA384)":
                        {
                            TablaBytes = sha384.ComputeHash(Byteskey);
                            des.Key = Md5.ComputeHash(TablaBytes);
                            break;
                        }
                    case "MD5(SHA512)":
                        {
                            TablaBytes = sha512.ComputeHash(Byteskey);
                            des.Key = Md5.ComputeHash(TablaBytes);
                            break;
                        }

                }
                // des.GenerateIV()
                des.Mode = CipherMode.ECB;

                texto_desencriptado = Codificar.GetString(des.CreateDecryptor().TransformFinalBlock(BytesTexto, 0, BytesTexto.Length));
            }
            catch (CryptographicException ex)
            {
                mylog("Desencriptar_conKey", "Error", ex.Message, true);
            }
            catch (Exception ex)
            {
                mylog("Desencriptar_conKey", "Error", ex.Message, true);

            }

            Codificar = null;
            BytesTexto = null;
            Byteskey = null;

            return texto_desencriptado;
        }

    }

    public class Campo
    {
        public Campo()
        {

        }

        public Campo(string Nombre, string Valor, bool Encriptar)
        {

            this.Nombre = Nombre;
            this.Valor = Valor;
            this.Encriptar = Encriptar;
        }

        public string Nombre { get; set; }
        public string Valor { get; set; }
        /// <summary>
        /// Indica si el campo debe ser encriptado.
        /// </summary>
        public bool Encriptar { get; set; }
    }

    public class NodoConAtributos
    {

        public NodoConAtributos()
        {

        }

        public NodoConAtributos(string Nombre, List<Campo> Atributos)
        {

            this.Nombre = Nombre;
            this.Atributos = Atributos;
        }

        public string Nombre { get; set; }
        public List<Campo> Atributos { get; set; }
    }
}