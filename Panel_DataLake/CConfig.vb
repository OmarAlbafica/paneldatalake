Imports System.IO
Imports System.Reflection
Imports System.Xml
Imports System.Xml.XPath
Imports System.Security.Cryptography
Imports System.Text
''' <summary>
''' Clase para guardar Parametros de configuracion en un XML Version 3.5
''' </summary>
''' <remarks></remarks>
Public Class CConfig
    Dim Md5 As New MD5CryptoServiceProvider
    Dim sha1 As New SHA1CryptoServiceProvider
    Dim sha256 As New SHA256CryptoServiceProvider
    Dim sha384 As New SHA384CryptoServiceProvider
    Dim sha512 As New SHA512CryptoServiceProvider
    Dim des As New TripleDESCryptoServiceProvider

    Dim TablaBytes(9000) As Byte

    Private _carpetaAplicativo As String
    Private _carpetLogAplicativo As String
    Private _NombreArchivoConf As String
    Private _metodoEncriptar As String
    Private _claveEncriptar As String

    Public Property carpetaAplicativo As String
        Get
            Return _carpetaAplicativo
        End Get
        Set(ByVal value As String)
            _carpetaAplicativo = value
        End Set
    End Property
    Public Property CarpetaLogAplicativo As String
        Get
            Return _carpetLogAplicativo
        End Get
        Set(ByVal value As String)
            _carpetLogAplicativo = value
        End Set
    End Property
    Public Property NombreArchivoConf As String
        Get
            Return _NombreArchivoConf
        End Get
        Set(ByVal value As String)
            _NombreArchivoConf = value
        End Set
    End Property
    Public Property MetodoEncriptar As String
        Get
            Return _metodoEncriptar
        End Get
        Set(ByVal value As String)
            _metodoEncriptar = value
        End Set
    End Property
    Public Property ClaveEncriptar As String
        Get
            Return _claveEncriptar
        End Get
        Set(ByVal value As String)
            _claveEncriptar = value
        End Set
    End Property

    Public Function ExisteXML() As Boolean
        Dim existe As Boolean = False
        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            existe = True
        End If

        Return existe
    End Function

    Public Sub mylog(ByVal identificador As String, ByVal tipomsj As String, ByVal mensaje As String, ByVal estado As Boolean, Optional ByVal NombreArchivo As String = "")
        Try
            If Not Directory.Exists(_carpetLogAplicativo) Then
                Directory.CreateDirectory(_carpetLogAplicativo)
            End If

            If estado = True Then
                Dim ruta As String = _carpetLogAplicativo & "/" & NombreArchivo & Date.Today.ToString("dd-MM-yyyy") & ".log"
                Dim encabezado As String = "[" & Date.Now & "] [" & identificador & "]"
                If encabezado.Length < 40 Then
                    For i = encabezado.Length To 40
                        encabezado += "-"
                    Next
                End If
                File.AppendAllText(ruta, encabezado & "|" & tipomsj & "| " & mensaje & ControlChars.CrLf, System.Text.Encoding.UTF8)
                'File.AppendAllText(ruta, "[" & Date.Now & "] [" & identificador & "]" & ControlChars.Tab & "|" & tipomsj & "| " & mensaje & ControlChars.CrLf, System.Text.Encoding.UTF8)
            End If
        Catch ex As Exception

            'mylog("mylog", "Error", "Exception: " & ex.Message, True)
        End Try


    End Sub



    Private Function CrearNodo(ByVal nodo As Campo) As XElement
        Dim xNodo As XElement = New XElement(nodo.Nombre)
        If nodo.Encriptar Then

            Dim ValorEncriptado As String = Encriptar_conKey(nodo.Valor, _metodoEncriptar, _claveEncriptar)
            xNodo.SetValue(ValorEncriptado)

        Else
            xNodo.SetValue(nodo.Valor)
        End If

        Return xNodo
    End Function
    Private Function CrearNodo(ByVal Nombre As String, ByVal Valor As String, ByVal Encriptar As Boolean) As XElement
        Dim xNodo As XElement = New XElement(Nombre)
        If Encriptar Then

            Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
            xNodo.SetValue(ValorEncriptado)

        Else
            xNodo.SetValue(Valor)
        End If

        Return xNodo
    End Function

    Private Overloads Function CrearAtributo(ByVal Nodo As XElement, ByVal Atributo As Campo) As XElement
        If Atributo.Encriptar Then

            Dim ValorEncriptado As String = Encriptar_conKey(Atributo.Valor, _metodoEncriptar, _claveEncriptar)
            Nodo.SetAttributeValue(Atributo.Nombre, ValorEncriptado)

        Else
            Nodo.SetAttributeValue(Atributo.Nombre, Atributo.Valor)
        End If

        Return Nodo
    End Function
    Private Overloads Function CrearAtributo(ByVal Nodo As XElement, ByVal Nombre As String, ByVal Valor As String, Encriptar As Boolean) As XElement
        If Encriptar Then

            Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
            Nodo.SetAttributeValue(Nombre, ValorEncriptado)

        Else
            Nodo.SetAttributeValue(Nombre, Valor)
        End If

        Return Nodo
    End Function

    Private Overloads Function ExisteNodo(ByVal Nodo As XElement, ByVal name As String) As Boolean
        If name <> "" Then
            If Nodo.Descendants(name).Any() Then
                If Not Nodo.Element(name) Is Nothing Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function
    Private Overloads Function ExisteNodo(ByVal Nodo As XDocument, ByVal name As String) As Boolean
        If name <> "" Then
            Return Nodo.Descendants(name).Any()
        Else
            Return False
        End If

    End Function

    Public Overloads Sub GuardarNodo(ByVal NodoPadre As String, ByVal NodoHijo As String, ByVal Nodo As Campo)
        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado.Root, "Configuracion") Then
                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

Validar:
                If NodoPadre <> "" Then

                    If ExisteNodo(Configuracion, NodoPadre) Then
                        If NodoHijo <> "" Then

                            If ExisteNodo(Configuracion, NodoHijo) Then
                                If Nodo.Nombre <> "" Then

                                    If ExisteNodo(Configuracion, Nodo.Nombre) Then


                                        If Nodo.Encriptar Then
                                            Dim ValorEncriptado As String = Encriptar_conKey(Nodo.Valor, _metodoEncriptar, _claveEncriptar)

                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(ValorEncriptado)

                                        Else
                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(Nodo.Valor)
                                        End If

                                        Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                                    Else
                                        'aqui debe crear Nodo.Nombre
                                        Dim xNodo As XElement = New XElement(Nodo.Nombre)
                                        Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodo)

                                        GoTo Validar

                                    End If
                                End If
                            Else
                                'aqui debe crear NodoHijo
                                Dim xNodoHijo As XElement = New XElement(NodoHijo)
                                Configuracion.Element(NodoPadre).Add(xNodoHijo)

                                GoTo Validar
                            End If

                        End If
                    Else
                        ' aqui debe crear NodoPadre
                        Dim xNodoPadre As XElement = New XElement(NodoPadre)
                        Configuracion.Add(xNodoPadre)

                        GoTo Validar
                    End If
                Else
                    If NodoHijo <> "" Then
                        If ExisteNodo(Configuracion, NodoHijo) Then
                            If Nodo.Nombre <> "" Then
                                If ExisteNodo(Configuracion, Nodo.Nombre) Then
                                    If Nodo.Encriptar Then
                                        Dim ValorEncriptado As String = Encriptar_conKey(Nodo.Valor, _metodoEncriptar, _claveEncriptar)

                                        Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(ValorEncriptado)

                                    Else
                                        Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(Nodo.Valor)
                                    End If

                                    Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                                Else
                                    'aqui debe crear Nodo.Nombre
                                    Dim xNodo As XElement = New XElement(Nodo.Nombre)
                                    Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodo)

                                    GoTo Validar
                                End If
                            End If
                        Else
                            'aqui debe crear NodoHijo
                            Dim xNodoHijo As XElement = New XElement(NodoHijo)
                            Configuracion.Element(NodoPadre).Add(xNodoHijo)

                            GoTo Validar
                        End If
                    Else
                        If Nodo.Nombre <> "" Then
                            If ExisteNodo(Configuracion, Nodo.Nombre) Then
                                If Nodo.Encriptar Then
                                    Dim ValorEncriptado As String = Encriptar_conKey(Nodo.Valor, _metodoEncriptar, _claveEncriptar)

                                    Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(ValorEncriptado)

                                Else
                                    Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nodo.Nombre).SetValue(Nodo.Valor)
                                End If

                                Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                            Else
                                'aqui debe crear Nodo.Nombre
                                Dim xNodo As XElement = New XElement(Nodo.Nombre)
                                Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodo)

                                GoTo Validar
                            End If
                        End If
                    End If
                End If
            End If

        Else
            Dim XMLNuevo As XElement = New XElement("Configuracion")

            If NodoPadre <> "" Then
                If NodoHijo <> "" Then
                    If Nodo.Nombre <> "" Then
                        Dim xNodoPadre As XElement = New XElement(NodoPadre)
                        Dim xNodoHijo As XElement = New XElement(NodoHijo)

                        'retorna un nodo ya hecho
                        Dim xNodo As XElement = CrearNodo(Nodo)

                        xNodoHijo.Add(xNodo)
                        xNodoPadre.Add(xNodoHijo)
                        XMLNuevo.Add(xNodoPadre)

                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                    End If

                End If
            Else
                If NodoHijo <> "" Then
                    If Nodo.Nombre <> "" Then
                        Dim xNodoHijo As XElement = New XElement(NodoHijo)

                        'retorna un nodo ya hecho
                        Dim xNodo As XElement = CrearNodo(Nodo)

                        xNodoHijo.Add(xNodo)
                        XMLNuevo.Add(xNodoHijo)

                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                    End If
                Else
                    If Nodo.Nombre <> "" Then

                        'retorna un nodo ya hecho
                        Dim xNodo As XElement = CrearNodo(Nodo)

                        XMLNuevo.Add(xNodo)

                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                    End If
                End If
            End If
        End If
    End Sub
    Public Overloads Sub GuardarNodo(ByVal NodoPadre As String, ByVal NodoHijo As String, ByVal Nombre As String, ByVal Valor As String, ByVal Encriptar As Boolean)
        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado, "Configuracion") Then
                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

Validar:
                If NodoPadre <> "" Then

                    If ExisteNodo(Configuracion, NodoPadre) Then

                        If NodoHijo <> "" Then

                            If ExisteNodo(Configuracion, NodoHijo) Then

                                If Nombre <> "" Then

                                    If ExisteNodo(Configuracion, Nombre) Then


                                        If Encriptar Then
                                            Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)

                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nombre).SetValue(ValorEncriptado)

                                        Else
                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nombre).SetValue(Valor)
                                        End If

                                        Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                                    Else
                                        'aqui debe crear Nombre

                                        Dim xNodo As XElement = New XElement(Nombre)
                                        Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodo)

                                        GoTo Validar

                                    End If
                                End If
                            Else
                                'aqui debe crear NodoHijo

                                Dim xNodoHijo As XElement = New XElement(NodoHijo)
                                Configuracion.Element(NodoPadre).Add(xNodoHijo)

                                GoTo Validar
                            End If

                        End If
                    Else
                        ' aqui debe crear NodoPadre

                        Dim xNodoPadre As XElement = New XElement(NodoPadre)
                        Configuracion.Add(xNodoPadre)

                        GoTo Validar
                    End If
                Else
                    If NodoHijo <> "" Then
                        If ExisteNodo(Configuracion, NodoHijo) Then
                            If Nombre <> "" Then
                                If ExisteNodo(Configuracion, Nombre) Then
                                    If Encriptar Then
                                        Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)

                                        Configuracion.Element(NodoHijo).Element(Nombre).SetValue(ValorEncriptado)

                                    Else
                                        Configuracion.Element(NodoHijo).Element(Nombre).SetValue(Valor)
                                    End If

                                    Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                                Else
                                    'aqui debe crear Nombre

                                    Dim xNodo As XElement = New XElement(Nombre)
                                    Configuracion.Element(NodoHijo).Add(xNodo)

                                    GoTo Validar
                                End If
                            End If
                        Else
                            'aqui debe crear NodoHijo

                            Dim xNodoHijo As XElement = New XElement(NodoHijo)
                            Configuracion.Add(xNodoHijo)

                            GoTo Validar
                        End If
                    Else
                        If Nombre <> "" Then
                            If ExisteNodo(Configuracion, Nombre) Then
                                If Encriptar Then
                                    Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)

                                    Configuracion.Element(Nombre).SetValue(ValorEncriptado)

                                Else
                                    Configuracion.Element(Nombre).SetValue(Valor)
                                End If

                                Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                            Else
                                'aqui debe crear Nombre

                                Dim xNodo As XElement = New XElement(Nombre)
                                Configuracion.Add(xNodo)

                                GoTo Validar
                            End If
                        End If
                    End If
                End If
            End If

        Else
            Dim XMLNuevo As XElement = New XElement("Configuracion")

            If NodoPadre <> "" Then
                If NodoHijo <> "" Then
                    If Nombre <> "" Then
                        Dim xNodoPadre As XElement = New XElement(NodoPadre)
                        Dim xNodoHijo As XElement = New XElement(NodoHijo)

                        'retorna un nodo ya hecho
                        Dim nodo As New Campo
                        nodo.Nombre = Nombre
                        nodo.Valor = Valor
                        nodo.Encriptar = Encriptar

                        Dim xNodo As XElement = CrearNodo(nodo)

                        xNodoHijo.Add(xNodo)
                        xNodoPadre.Add(xNodoHijo)
                        XMLNuevo.Add(xNodoPadre)

                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                    End If

                End If
            Else
                If NodoHijo <> "" Then
                    If Nombre <> "" Then
                        Dim xNodoHijo As XElement = New XElement(NodoHijo)

                        'retorna un nodo ya hecho
                        Dim nodo As New Campo
                        nodo.Nombre = Nombre
                        nodo.Valor = Valor
                        nodo.Encriptar = Encriptar

                        Dim xNodo As XElement = CrearNodo(nodo)

                        xNodoHijo.Add(xNodo)
                        XMLNuevo.Add(xNodoHijo)

                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                    End If
                Else
                    If Nombre <> "" Then

                        'retorna un nodo ya hecho
                        Dim nodo As New Campo
                        nodo.Nombre = Nombre
                        nodo.Valor = Valor
                        nodo.Encriptar = Encriptar

                        Dim xNodo As XElement = CrearNodo(nodo)

                        XMLNuevo.Add(xNodo)

                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub GuardarNodos(ByVal NodoPadre As String, ByVal NodoHijo As String, ByVal Nodos As List(Of Campo))

        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

        Else

        End If
    End Sub

    Public Overloads Sub GuardarAtributo(ByVal NodoPadre As String, ByVal NodoLeer As String, ByVal Atributo As Campo)
        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado.Root, "Configuracion") Then
                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

Validar:
                If NodoPadre <> "" Then

                    If ExisteNodo(Configuracion, NodoPadre) Then
                        If NodoLeer <> "" Then

                            If ExisteNodo(Configuracion, NodoLeer) Then


                                If Atributo.Encriptar Then
                                    Dim ValorEncriptado As String = Encriptar_conKey(Atributo.Valor, _metodoEncriptar, _claveEncriptar)
                                    Configuracion.Element(NodoPadre).Element(NodoLeer).SetAttributeValue(Atributo.Nombre, ValorEncriptado)
                                Else
                                    Configuracion.Element(NodoPadre).Element(NodoLeer).SetAttributeValue(Atributo.Nombre, Atributo.Valor)
                                End If

                                Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                            Else
                                'aqui debe crear NodoLeer
                                Dim xNodoLeer As XElement = New XElement(NodoLeer)
                                Configuracion.Element(NodoPadre).Add(xNodoLeer)

                                GoTo Validar
                            End If
                        End If
                    Else
                        'aqui deberia crear NodoPadre
                        Dim xNodoPadre As XElement = New XElement(NodoPadre)
                        Configuracion.Add(xNodoPadre)

                        GoTo Validar
                    End If
                Else
                    If NodoLeer <> "" Then
                        If ExisteNodo(Configuracion, NodoLeer) Then

                            If Atributo.Encriptar Then
                                Dim ValorEncriptado As String = Encriptar_conKey(Atributo.Valor, _metodoEncriptar, _claveEncriptar)
                                Configuracion.Element(NodoLeer).SetAttributeValue(Atributo.Nombre, ValorEncriptado)
                            Else
                                Configuracion.Element(NodoLeer).SetAttributeValue(Atributo.Nombre, Atributo.Valor)
                            End If
                            Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                        Else
                            'aqui debe crear NodoLeer
                            Dim xNodoLeer As XElement = New XElement(NodoLeer)
                            Configuracion.Add(xNodoLeer)

                            GoTo Validar
                        End If
                    End If
                End If
            End If
        Else
            Dim XMLNuevo As XElement = New XElement("Configuracion")

            If NodoPadre <> "" Then
                If NodoLeer <> "" Then
                    Dim xNodoPadre As XElement = New XElement(NodoPadre)
                    Dim xNodoLeer As XElement = New XElement(NodoLeer)

                    xNodoLeer = CrearAtributo(xNodoLeer, Atributo)

                    xNodoPadre.Add(xNodoLeer)
                    XMLNuevo.Add(xNodoPadre)

                    XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                End If
            Else
                If NodoLeer <> "" Then
                    Dim xNodoLeer As XElement = New XElement(NodoLeer)

                    xNodoLeer = CrearAtributo(xNodoLeer, Atributo)

                    XMLNuevo.Add(xNodoLeer)

                    XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                End If
            End If
        End If
    End Sub
    Public Overloads Sub GuardarAtributo(ByVal NodoPadre As String, ByVal NodoLeer As String, ByVal Nombre As String, ByVal Valor As String, ByRef Encriptar As Boolean)

        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado, "Configuracion") Then
                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

Validar:
                If NodoPadre <> "" Then

                    If ExisteNodo(Configuracion, NodoPadre) Then

                        If NodoLeer <> "" Then


                            If ExisteNodo(Configuracion.Element(NodoPadre), NodoLeer) Then

                                If Encriptar Then
                                    Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
                                    Configuracion.Element(NodoPadre).Element(NodoLeer).SetAttributeValue(Nombre, ValorEncriptado)
                                Else
                                    Configuracion.Element(NodoPadre).Element(NodoLeer).SetAttributeValue(Nombre, Valor)
                                End If

                                Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                            Else
                                'aqui debe crear NodoLeer
                                Dim xNodoLeer As XElement = New XElement(NodoLeer)
                                Configuracion.Element(NodoPadre).Add(xNodoLeer)

                                GoTo Validar
                            End If
                        End If
                    Else
                        'aqui debe crear NodoPadre
                        Dim xNodoPadre As XElement = New XElement(NodoPadre)
                        Configuracion.Add(xNodoPadre)

                        GoTo Validar
                    End If
                Else
                    If NodoLeer <> "" Then
                        If ExisteNodo(Configuracion, NodoLeer) Then

                            If Encriptar Then
                                Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
                                Configuracion.Element(NodoLeer).SetAttributeValue(Nombre, ValorEncriptado)
                            Else
                                Configuracion.Element(NodoLeer).SetAttributeValue(Nombre, Valor)
                            End If
                            Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                        Else
                            'aqui debe crear NodoLeer
                            Dim xNodoLeer As XElement = New XElement(NodoLeer)
                            Configuracion.Add(xNodoLeer)

                            GoTo Validar

                        End If
                    End If
                End If
            End If
        Else
            Dim XMLNuevo As XElement = New XElement("Configuracion")

            If NodoPadre <> "" Then
                If NodoLeer <> "" Then
                    Dim xNodoPadre As XElement = New XElement(NodoPadre)
                    Dim xNodoLeer As XElement = New XElement(NodoLeer)

                    xNodoLeer = CrearAtributo(xNodoLeer, Nombre, Valor, Encriptar)

                    xNodoPadre.Add(xNodoLeer)
                    XMLNuevo.Add(xNodoPadre)

                    XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                End If
            Else
                If NodoLeer <> "" Then
                    Dim xNodoLeer As XElement = New XElement(NodoLeer)

                    xNodoLeer = CrearAtributo(xNodoLeer, Nombre, Valor, Encriptar)

                    XMLNuevo.Add(xNodoLeer)

                    XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                End If
            End If
        End If
    End Sub
    Public Overloads Sub GuardarAtributo(ByVal Nodo As String, ByVal Nombre As String, ByVal Valor As String, ByRef encriptar As Boolean)
        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado, "Configuracion") Then
                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

                If Nodo.Contains(".") Then
                    Dim NodoActual As XElement = Configuracion
                    Dim Nodos As String() = Nodo.Split(".")

                    For Each NombreNodo As String In Nodos
                        If ExisteNodo(NodoActual, NombreNodo) Then
                            NodoActual = NodoActual.Element(NombreNodo)
                        Else
                            Dim xNodo As XElement = New XElement(NombreNodo)
                            NodoActual.Add(xNodo)

                            NodoActual = NodoActual.Element(NombreNodo)
                        End If
                    Next

                    If encriptar Then
                        Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
                        NodoActual.SetAttributeValue(Nombre, ValorEncriptado)
                    Else
                        NodoActual.SetAttributeValue(Nombre, Valor)
                    End If

                    Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                Else
                    'Unico Nodo

                    If ExisteNodo(Configuracion, Nodo) Then
                        If encriptar Then
                            Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
                            Configuracion.Element(Nodo).SetAttributeValue(Nombre, ValorEncriptado)
                        Else
                            Configuracion.Element(Nodo).SetAttributeValue(Nombre, Valor)
                        End If
                    Else
                        Dim xNodo As XElement = New XElement(Nodo)
                        Configuracion.Add(xNodo)

                        If encriptar Then
                            Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
                            Configuracion.Element(Nodo).SetAttributeValue(Nombre, ValorEncriptado)
                        Else
                            Configuracion.Element(Nodo).SetAttributeValue(Nombre, Valor)
                        End If
                    End If
                End If
            End If
        Else
            Dim XMLNuevo As XElement = New XElement("Configuracion")

            If Nodo.Contains(".") Then
                Dim NodoActual As XElement = XMLNuevo
                Dim Nodos As String() = Nodo.Split(".")

                For Each NombreNodo As String In Nodos
                    If ExisteNodo(NodoActual, NombreNodo) Then
                        NodoActual = NodoActual.Element(NombreNodo)
                    Else
                        Dim xNodo As XElement = New XElement(NombreNodo)
                        NodoActual.Add(xNodo)

                        NodoActual = NodoActual.Element(NombreNodo)
                    End If
                Next

                If encriptar Then
                    Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
                    NodoActual.SetAttributeValue(Nombre, ValorEncriptado)
                Else
                    NodoActual.SetAttributeValue(Nombre, Valor)
                End If

                XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
            Else
                'Unico Nodo
                Dim xNodo As XElement = New XElement(Nodo)
                XMLNuevo.Add(xNodo)

                If encriptar Then
                    Dim ValorEncriptado As String = Encriptar_conKey(Valor, _metodoEncriptar, _claveEncriptar)
                    XMLNuevo.Element(Nodo).SetAttributeValue(Nombre, ValorEncriptado)
                Else
                    XMLNuevo.Element(Nodo).SetAttributeValue(Nombre, Valor)
                End If

                XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
            End If
        End If
    End Sub

    ''' <summary>
    ''' En esta Funcion el nombre de se guarda una lista de nodos con sus respectivos atributos
    ''' </summary>
    ''' <param name="NodoPadre"></param>
    ''' <param name="NodoLeer"></param>
    ''' <param name="NodosConAtributos"></param>
    ''' <remarks></remarks>
    Public Sub GuardarNodosConAtributos(ByVal NodoPadre As String, ByVal NodoHijo As String, ByVal NodoLeer As String, ByVal NodosConAtributos As List(Of NodoConAtributos))

        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado, "Configuracion") Then
                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

Validar:
                If NodoPadre <> "" Then

                    If ExisteNodo(Configuracion, NodoPadre) Then

                        If NodoHijo <> "" Then
                            If ExisteNodo(Configuracion.Element(NodoPadre), NodoHijo) Then

                                If NodoLeer <> "" Then

                                    If ExisteNodo(Configuracion.Element(NodoPadre).Element(NodoHijo), NodoLeer) Then

                                        If Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer).HasElements Then
                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer).RemoveNodes()
                                        End If


                                        For Each Nodo As NodoConAtributos In NodosConAtributos

                                            Dim xNodo As XElement = New XElement(Nodo.Nombre)

                                            For Each Atributo As Campo In Nodo.Atributos

                                                xNodo = CrearAtributo(xNodo, Atributo)

                                            Next
                                            Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer).Add(xNodo)

                                        Next

                                        Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                                    Else
                                        'aqui deberia crear NodoLeer
                                        Dim xNodoLeer As XElement = New XElement(NodoLeer)
                                        Configuracion.Element(NodoPadre).Element(NodoHijo).Add(xNodoLeer)

                                        GoTo Validar
                                    End If
                                End If

                            Else
                                'aqui deberia crear NodoLeer
                                Dim xNodoHijo As XElement = New XElement(NodoHijo)
                                Configuracion.Element(NodoPadre).Add(xNodoHijo)

                                GoTo Validar
                            End If
                        End If
                    Else
                        'aqui deberia crear NodoPadre
                        Dim xNodoPadre As XElement = New XElement(NodoPadre)
                        Configuracion.Add(xNodoPadre)

                        GoTo Validar
                    End If
                Else
                    If NodoHijo <> "" Then
                        If ExisteNodo(Configuracion, NodoHijo) Then
                            If NodoLeer <> "" Then
                                If ExisteNodo(Configuracion.Element(NodoHijo), NodoLeer) Then

                                    If Configuracion.Element(NodoHijo).Element(NodoLeer).HasElements Then
                                        Configuracion.Element(NodoHijo).Element(NodoLeer).RemoveNodes()
                                    End If

                                    For Each Nodo As NodoConAtributos In NodosConAtributos

                                        Dim xNodo As XElement = New XElement(Nodo.Nombre)

                                        For Each Atributo As Campo In Nodo.Atributos

                                            xNodo = CrearAtributo(xNodo, Atributo)

                                        Next
                                        Configuracion.Element(NodoHijo).Element(NodoLeer).Add(xNodo)

                                    Next

                                    Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

                                Else
                                    'aqui deberia crear NodoLeer
                                    Dim xNodoLeer As XElement = New XElement(NodoLeer)
                                    Configuracion.Element(NodoHijo).Add(xNodoLeer)

                                    GoTo Validar
                                End If
                            End If
                        Else
                            'aqui deberia crear NodoLeer
                            Dim xNodoHijo As XElement = New XElement(NodoHijo)
                            Configuracion.Add(xNodoHijo)

                            GoTo Validar
                        End If
                    Else
                        If NodoLeer <> "" Then
                            If ExisteNodo(Configuracion, NodoLeer) Then

                                If Configuracion.Element(NodoLeer).HasElements Then
                                    Configuracion.Element(NodoLeer).RemoveNodes()
                                End If

                                For Each Nodo As NodoConAtributos In NodosConAtributos

                                    Dim xNodo As XElement = New XElement(Nodo.Nombre)

                                    For Each Atributo As Campo In Nodo.Atributos

                                        xNodo = CrearAtributo(xNodo, Atributo)

                                    Next
                                    Configuracion.Element(NodoLeer).Add(xNodo)

                                Next

                                Configuracion.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                            Else
                                'aqui deberia crear NodoLeer
                                Dim xNodoLeer As XElement = New XElement(NodoLeer)
                                Configuracion.Add(xNodoLeer)

                                GoTo Validar
                            End If
                        End If
                    End If

                End If
            End If
        Else
            Dim XMLNuevo As XElement = New XElement("Configuracion")

            If NodoPadre <> "" Then
                If NodoHijo <> "" Then
                    If NodoLeer <> "" Then

                        Dim xNodoPadre As XElement = New XElement(NodoPadre)
                        Dim xNodoHijo As XElement = New XElement(NodoHijo)
                        Dim xNodoLeer As XElement = New XElement(NodoLeer)

                        For Each Nodo As NodoConAtributos In NodosConAtributos

                            Dim xNodo As XElement = New XElement(Nodo.Nombre)

                            For Each Atributo As Campo In Nodo.Atributos

                                xNodo = CrearAtributo(xNodo, Atributo)

                            Next

                            xNodoLeer.Add(xNodo)
                        Next

                        xNodoHijo.Add(xNodoLeer)
                        xNodoPadre.Add(xNodoHijo)
                        XMLNuevo.Add(xNodoPadre)

                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

                    End If

                End If
            Else
                If NodoHijo <> "" Then
                    If NodoLeer <> "" Then
                        Dim xNodoHijo As XElement = New XElement(NodoHijo)
                        Dim xNodoLeer As XElement = New XElement(NodoLeer)

                        For Each Nodo As NodoConAtributos In NodosConAtributos

                            Dim xNodo As XElement = New XElement(Nodo.Nombre)

                            For Each Atributo As Campo In Nodo.Atributos

                                xNodo = CrearAtributo(xNodo, Atributo)

                            Next

                            xNodoLeer.Add(xNodo)
                        Next

                        xNodoHijo.Add(xNodoLeer)
                        XMLNuevo.Add(xNodoHijo)
                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                    End If
                Else
                    If NodoLeer <> "" Then
                        Dim xNodoLeer As XElement = New XElement(NodoLeer)

                        For Each Nodo As NodoConAtributos In NodosConAtributos

                            Dim xNodo As XElement = New XElement(Nodo.Nombre)

                            For Each Atributo As Campo In Nodo.Atributos

                                xNodo = CrearAtributo(xNodo, Atributo)

                            Next

                            xNodoLeer.Add(xNodo)
                        Next

                        XMLNuevo.Add(xNodoLeer)
                        XMLNuevo.Save(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")
                    End If
                End If

            End If
        End If
    End Sub

    Public Function LeerNodo(ByVal NodoPadre As String, ByVal NodoHijo As String, ByVal Nombre As String, ByVal Encriptar As Boolean) As String
        Dim resultado As String = ""

        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado, "Configuracion") Then

                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

                If ExisteNodo(Configuracion, NodoPadre) = True And ExisteNodo(Configuracion, NodoHijo) = True And ExisteNodo(Configuracion, Nombre) = True Then

                    If Encriptar Then
                        Dim ValorEncriptado As String = Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nombre).Value
                        resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar)
                    Else
                        resultado = Configuracion.Element(NodoPadre).Element(NodoHijo).Element(Nombre).Value
                    End If

                ElseIf ExisteNodo(Configuracion, NodoPadre) = False And ExisteNodo(Configuracion, NodoHijo) = True And ExisteNodo(Configuracion, Nombre) = True Then

                    If Encriptar Then
                        Dim ValorEncriptado As String = Configuracion.Element(NodoHijo).Element(Nombre).Value
                        resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar)
                    Else
                        resultado = Configuracion.Element(NodoHijo).Element(Nombre).Value
                    End If

                ElseIf ExisteNodo(Configuracion, NodoPadre) = False And ExisteNodo(Configuracion, NodoHijo) = False And ExisteNodo(Configuracion, Nombre) = True Then

                    If Encriptar Then
                        Dim ValorEncriptado As String = Configuracion.Element(Nombre).Value
                        resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar)
                    Else
                        resultado = Configuracion.Element(Nombre).Value
                    End If

                End If

            End If
        End If

        Return resultado
    End Function

    Public Function LeerNodosConAtributos(ByVal NodoPadre As String, ByVal NodoHijo As String, ByVal NodoLeer As String, ByVal NodoFiltro As String) As List(Of NodoConAtributos)
        Dim NodosConAtributos As New List(Of NodoConAtributos)

        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado, "Configuracion") Then

                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

                If ExisteNodo(Configuracion, NodoPadre) Then
                    If ExisteNodo(Configuracion.Element(NodoPadre), NodoHijo) Then
                        If ExisteNodo(Configuracion.Element(NodoPadre).Element(NodoHijo), NodoLeer) Then

                            Dim xNodoLeer As XElement = Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer)

                            Dim ListaNodos As IEnumerable(Of XElement) = xNodoLeer.Descendants(NodoFiltro)

                            If ListaNodos.Count <> 0 Then

                                For Each LNodo As XElement In ListaNodos
                                    Dim Nodo As New NodoConAtributos

                                    Nodo.Nombre = LNodo.Name.ToString

                                    Dim atributos As New List(Of Campo)
                                    For Each Latributo As XAttribute In LNodo.Attributes
                                        Dim atributo As New Campo

                                        atributo.Nombre = Latributo.Name.ToString
                                        atributo.Valor = Latributo.Value
                                        atributo.Encriptar = False

                                        atributos.Add(atributo)
                                    Next

                                    Nodo.Atributos = atributos

                                    NodosConAtributos.Add(Nodo)
                                Next

                            End If

                        End If

                    End If
                Else
                    If NodoPadre = "" Then
                        If ExisteNodo(Configuracion, NodoHijo) Then
                            If ExisteNodo(Configuracion.Element(NodoHijo), NodoLeer) Then

                                Dim xNodoLeer As XElement = Configuracion.Element(NodoHijo).Element(NodoLeer)

                                Dim ListaNodos As IEnumerable(Of XElement) = xNodoLeer.Descendants(NodoFiltro)

                                If ListaNodos.Count <> 0 Then

                                    For Each LNodo As XElement In ListaNodos
                                        Dim Nodo As New NodoConAtributos

                                        Nodo.Nombre = LNodo.Name.ToString

                                        Dim atributos As New List(Of Campo)
                                        For Each Latributo As XAttribute In LNodo.Attributes
                                            Dim atributo As New Campo

                                            atributo.Nombre = Latributo.Name.ToString
                                            atributo.Valor = Latributo.Value
                                            atributo.Encriptar = False

                                            atributos.Add(atributo)
                                        Next

                                        Nodo.Atributos = atributos

                                        NodosConAtributos.Add(Nodo)
                                    Next

                                End If

                            End If
                        Else
                            If NodoHijo = "" Then 'valida que en entro aqui xq no lleva NodoHijo
                                If ExisteNodo(Configuracion, NodoLeer) Then

                                    Dim xNodoLeer As XElement = Configuracion.Element(NodoLeer)

                                    Dim ListaNodos As IEnumerable(Of XElement) = xNodoLeer.Descendants(NodoFiltro)

                                    If ListaNodos.Count <> 0 Then

                                        For Each LNodo As XElement In ListaNodos
                                            Dim Nodo As New NodoConAtributos

                                            Nodo.Nombre = LNodo.Name.ToString

                                            Dim atributos As New List(Of Campo)
                                            For Each Latributo As XAttribute In LNodo.Attributes
                                                Dim atributo As New Campo

                                                atributo.Nombre = Latributo.Name.ToString
                                                atributo.Valor = Latributo.Value
                                                atributo.Encriptar = False

                                                atributos.Add(atributo)
                                            Next

                                            Nodo.Atributos = atributos

                                            NodosConAtributos.Add(Nodo)
                                        Next

                                    End If

                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return NodosConAtributos
    End Function

    Public Overloads Function LeerAtributo(ByVal NodoPadre As String, ByVal NodoHijo As String, ByVal NodoLeer As String, ByVal NombreAtributo As String, ByVal Encriptar As Boolean) As String
        Dim resultado As String = ""

        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado, "Configuracion") Then

                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

                If ExisteNodo(Configuracion, NodoPadre) Then
                    If ExisteNodo(Configuracion.Element(NodoPadre), NodoHijo) Then
                        If ExisteNodo(Configuracion.Element(NodoPadre).Element(NodoHijo), NodoLeer) Then

                            Dim xNodoLeer As XElement = Configuracion.Element(NodoPadre).Element(NodoHijo).Element(NodoLeer)

                            If xNodoLeer.HasAttributes Then

                                If xNodoLeer.Attributes.Any(Function(d) d.Name = NombreAtributo) Then

                                    If Encriptar Then
                                        Dim ValorEncriptado As String = xNodoLeer.Attribute(NombreAtributo).Value
                                        If ValorEncriptado <> "" Then
                                            resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar)
                                        Else
                                            resultado = ValorEncriptado
                                        End If
                                    Else
                                        resultado = xNodoLeer.Attribute(NombreAtributo).Value
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else
                    If NodoPadre = "" Then
                        If ExisteNodo(Configuracion, NodoHijo) Then
                            If ExisteNodo(Configuracion.Element(NodoHijo), NodoLeer) Then

                                Dim xNodoLeer As XElement = Configuracion.Element(NodoHijo).Element(NodoLeer)

                                If xNodoLeer.HasAttributes Then

                                    If xNodoLeer.Attributes.Any(Function(d) d.Name = NombreAtributo) Then

                                        If Encriptar Then
                                            Dim ValorEncriptado As String = xNodoLeer.Attribute(NombreAtributo).Value
                                            If ValorEncriptado <> "" Then
                                                resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar)
                                            Else
                                                resultado = ValorEncriptado
                                            End If
                                        Else
                                            resultado = xNodoLeer.Attribute(NombreAtributo).Value
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            If ExisteNodo(Configuracion, NodoLeer) Then
                                If NodoHijo = "" Then 'valida que en entro aqui xq no lleva NodoHijo

                                    Dim xNodoLeer As XElement = Configuracion.Element(NodoLeer)

                                    If xNodoLeer.HasAttributes Then

                                        If xNodoLeer.Attributes.Any(Function(d) d.Name = NombreAtributo) Then

                                            If Encriptar Then
                                                Dim ValorEncriptado As String = xNodoLeer.Attribute(NombreAtributo).Value
                                                If ValorEncriptado <> "" Then
                                                    resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar)
                                                Else
                                                    resultado = ValorEncriptado
                                                End If
                                            Else
                                                resultado = xNodoLeer.Attribute(NombreAtributo).Value
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

        Return resultado
    End Function
    Public Overloads Function LeerAtributo(ByVal Nodo As String, ByVal NombreAtributo As String, ByVal Encriptar As Boolean) As String
        Dim resultado As String = ""

        If System.IO.File.Exists(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml") Then
            Dim XMLCargado As XDocument = XDocument.Load(_carpetaAplicativo & "/" & _NombreArchivoConf & ".xml")

            If ExisteNodo(XMLCargado, "Configuracion") Then

                Dim Configuracion As XElement = XMLCargado.Element("Configuracion")

                If Nodo.Contains(".") Then
                    Dim NodoActual As XElement = Configuracion
                    Dim Nodos As String() = Nodo.Split(".")

                    Dim existen As Boolean = True
                    For Each NombreNodo As String In Nodos
                        If ExisteNodo(NodoActual, NombreNodo) Then
                            NodoActual = NodoActual.Element(NombreNodo)
                        Else
                            existen = False
                        End If
                    Next

                    If existen Then
                        If NodoActual.HasAttributes Then
                            If NodoActual.Attributes.Any(Function(d) d.Name = NombreAtributo) Then

                                If Encriptar Then
                                    Dim ValorEncriptado As String = NodoActual.Attribute(NombreAtributo).Value
                                    If ValorEncriptado <> "" Then
                                        resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar)
                                    Else
                                        resultado = ValorEncriptado
                                    End If
                                Else
                                    resultado = NodoActual.Attribute(NombreAtributo).Value
                                End If
                            End If
                        End If
                    End If
                Else
                    'unico Nodo
                    If ExisteNodo(Configuracion, Nodo) Then
                        If Configuracion.Element(Nodo).HasAttributes Then
                            If Configuracion.Element(Nodo).Attributes.Any(Function(d) d.Name = NombreAtributo) Then

                                If Encriptar Then
                                    Dim ValorEncriptado As String = Configuracion.Element(Nodo).Attribute(NombreAtributo).Value
                                    If ValorEncriptado <> "" Then
                                        resultado = Desencriptar_conKey(ValorEncriptado, _metodoEncriptar, _claveEncriptar)
                                    Else
                                        resultado = ValorEncriptado
                                    End If
                                Else
                                    resultado = Configuracion.Element(Nodo).Attribute(NombreAtributo).Value
                                End If
                            End If
                        End If

                    End If
                End If
            End If
        End If

        Return resultado
    End Function

    Public Function Encriptar_conKey(ByVal TxEncriptar As String, ByVal tipoEncriptacion As String, ByVal key As String) As String
        Dim texto_encriptado As String = ""
        Dim Codificar As New UTF8Encoding()
        Dim BytesTexto() As Byte = Codificar.GetBytes(TxEncriptar)
        Dim Byteskey() As Byte = Codificar.GetBytes(key)
        'Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(TxEncriptar)
        Try

            Select Case tipoEncriptacion
                Case "MD5"
                    des.Key = Md5.ComputeHash(Byteskey)
                Case "MD5(SHA1)"
                    TablaBytes = sha1.ComputeHash(Byteskey)
                    des.Key = Md5.ComputeHash(TablaBytes)
                Case "MD5(sha256)"
                    TablaBytes = sha256.ComputeHash(Byteskey)
                    des.Key = Md5.ComputeHash(TablaBytes)
                Case "MD5(SHA384)"
                    TablaBytes = sha384.ComputeHash(Byteskey)
                    des.Key = Md5.ComputeHash(TablaBytes)
                Case "MD5(SHA512)"
                    TablaBytes = sha512.ComputeHash(Byteskey)
                    des.Key = Md5.ComputeHash(TablaBytes)

            End Select
            'des.GenerateIV()
            des.Mode = CipherMode.ECB

            texto_encriptado = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(BytesTexto, 0, BytesTexto.Length))

        Catch ex As CryptographicException
            mylog("Encriptar_conKey", "Error", ex.Message, True)
        Catch ex As Exception
            mylog("Encriptar_conKey", "Error", ex.Message, True)
        Finally
            'texto_encriptado = TxEncriptar
        End Try

        Codificar = Nothing
        BytesTexto = Nothing
        Byteskey = Nothing

        Return texto_encriptado
    End Function

    Public Function Desencriptar_conKey(ByVal TxDesencriptar As String, ByVal tipoEncriptacion As String, ByVal key As String) As String
        Dim texto_desencriptado As String = ""
        Dim Codificar As New UTF8Encoding()
        Dim BytesTexto() As Byte = Convert.FromBase64String(TxDesencriptar)
        Dim Byteskey() As Byte = Codificar.GetBytes(key)
        'Dim Buffer As Byte() = ASCIIEncoding.ASCII.GetBytes(TxEncriptar)
        Try
            Select Case tipoEncriptacion
                Case "MD5"
                    des.Key = Md5.ComputeHash(Byteskey)
                Case "MD5(SHA1)"
                    TablaBytes = sha1.ComputeHash(Byteskey)
                    des.Key = Md5.ComputeHash(TablaBytes)
                Case "MD5(sha256)"
                    TablaBytes = sha256.ComputeHash(Byteskey)
                    des.Key = Md5.ComputeHash(TablaBytes)
                Case "MD5(SHA384)"
                    TablaBytes = sha384.ComputeHash(Byteskey)
                    des.Key = Md5.ComputeHash(TablaBytes)
                Case "MD5(SHA512)"
                    TablaBytes = sha512.ComputeHash(Byteskey)
                    des.Key = Md5.ComputeHash(TablaBytes)

            End Select
            'des.GenerateIV()
            des.Mode = CipherMode.ECB

            texto_desencriptado = Codificar.GetString(des.CreateDecryptor().TransformFinalBlock(BytesTexto, 0, BytesTexto.Length))
        Catch ex As CryptographicException
            mylog("Desencriptar_conKey", "Error", ex.Message, True)
        Catch ex As Exception
            mylog("Desencriptar_conKey", "Error", ex.Message, True)

        End Try

        Codificar = Nothing
        BytesTexto = Nothing
        Byteskey = Nothing

        Return texto_desencriptado
    End Function

End Class

Public Class Campo
    Sub New()

    End Sub

    Sub New(ByVal Nombre As String, ByVal Valor As String, ByVal Encriptar As Boolean)

        Me.Nombre = Nombre
        Me.Valor = Valor
        Me.Encriptar = Encriptar
    End Sub

    Public Property Nombre As String
    Public Property Valor As String
    Public Property Encriptar As Boolean
End Class

Public Class NodoConAtributos

    Sub New()

    End Sub

    Sub New(ByVal Nombre As String, ByVal Atributos As List(Of Campo))

        Me.Nombre = Nombre
        Me.Atributos = Atributos
    End Sub

    Public Property Nombre As String
    Public Property Atributos As List(Of Campo)
End Class
