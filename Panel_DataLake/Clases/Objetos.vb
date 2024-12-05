Public Class Credenciales
    Public Property plataforma As String
    Public Property ip As String
    Public Property puerto As String
    Public Property usuario As String
    Public Property password As String
    Public Property db As String
    Public Property proveedor As String
End Class
Public Class CredenEndInv
    Public Property url As String
    Public Property token As String

End Class

Public Class ConfStock

    Sub New()
        Me.tiendas = New List(Of Tienda)
        Me.filtros = New List(Of Filtro)
        Me.nodos_json = New List(Of NodoJson)
        Me.Mapeos = New List(Of Mapeo)
        Me.ecommerce = New EcommerceCodeStock
        Me.api = New ApiStock
    End Sub

    Public Property tiempo As String

    Public Property TiempoEjec As String
    Public Property tiendas As List(Of Tienda)
    Public Property Lunes As Boolean
    Public Property Martes As Boolean
    Public Property Miercoles As Boolean
    Public Property Jueves As Boolean
    Public Property Viernes As Boolean
    Public Property Sabado As Boolean
    Public Property Domingo As Boolean
    Public Property Mail As String
    Public Property filtros As List(Of Filtro)
    Public Property nodos_json As List(Of NodoJson)
    Public Property Mapeos As List(Of Mapeo)
    Public Property ecommerce As EcommerceCodeStock
    Public Property api As ApiStock


End Class


Public Class Tienda
    Public Property sbs_no As String
    Public Property store_no As String
End Class
Public Class ConfDelta

    Sub New()
        Me.tiendasD = New List(Of TiendaD)
        Me.filtros = New List(Of Filtro)
    End Sub
    Public Property tiendasD As List(Of TiendaD)
    Public Property activar_filtros As Boolean
    Public Property filtros As List(Of Filtro)
End Class
Public Class TiendaD
    Public Property sbs_no As String
    Public Property store_no As String
End Class
Public Class Filtro
    Public Property operador As String
    Public Property campo_rpro As String
    Public Property condicion As String
    Public Property valor As String
End Class
Public Class ConfUrlTiendas
    Sub New()
        Me.TiendasUrl = New List(Of TiendaUrl)

    End Sub


    Public Property TiendasUrl As List(Of TiendaUrl)

End Class
Public Class TiendaUrl
    Public Property Lunes As String
    Public Property Martes As String
    Public Property Miercoles As String
    Public Property Jueves As String
    Public Property Viernes As String
    Public Property Sabado As String
    Public Property Domingo As String
    Public Property sbs_no As String
    Public Property store_no As String
    Public Property tiempo As String
    Public Property Lu_tiempo As String
    Public Property Mar_tiempo As String
    Public Property Mie_tiempo As String
    Public Property Ju_tiempo As String
    Public Property Vi_tiempo As String
    Public Property Sa_tiempo As String

End Class
Public Class NodoJson
    Public Property nivel As String
    Public Property padre As String
    Public Property name As String
    Public Property tipo As String
End Class
Public Class Mapeo
    Public Property ecommerce As String
    Public Property campo_rpro As String
End Class
Public Class EcommerceCodeStock
    Public Property campo_rpro As String
    Public Property valor As String
    Public Property activar As Boolean
End Class
Public Class ApiStock
    Sub New()
        Me.credenciales = New CredencialesToken
        Me.urls = New URLsStock
        Me.headers = New List(Of Header)
    End Sub

    Public Property credenciales As CredencialesToken
    Public Property urls As URLsStock
    Public Property headers As List(Of Header)
End Class
Public Class CredencialesToken
    Public Property User As String
    Public Property Password As String
    Public Property URL As String
    Public Property Activar As Boolean
End Class
Public Class URLsStock
    Public Property URLIdWHoLOTStock As String
    Public Property ActivarIdWHoLOTStock As Boolean
    Public Property URLValidarStock As String
    Public Property ActivarValidarStock As Boolean
    Public Property URLStock As String
End Class
Public Class Header
    Public Property Key As String
    Public Property Value As String
End Class

Public Class ConfCat
    Sub New()
        Me.filtros = New List(Of Filtro)
        Me.Mapeos = New List(Of Mapeo)
        Me.api = New ApiCat
    End Sub

    Public Property activar_filtros As Boolean
    Public Property filtros As List(Of Filtro)
    Public Property Mapeos As List(Of Mapeo)
    Public Property api As ApiCat
End Class
Public Class confLisPrice
    Public Property SBS_NO As String
    Public Property PRICE_LVL As String
End Class
Public Class ApiCat
    Sub New()
        Me.credenciales = New CredencialesToken
        Me.urls = New URLsCat
        Me.headers = New List(Of Header)
    End Sub

    Public Property credenciales As CredencialesToken
    Public Property urls As URLsCat
    Public Property headers As List(Of Header)
End Class
Public Class URLsCat
    Public Property URLValidarItemCat As String
    Public Property ActivarValidarItemCat As Boolean
    Public Property URLCrearItem As String
    Public Property URLActualizarItem As String
End Class

Public Class ElementItems

    Public Property sku As String
    Public Property id_sociedad As String
    Public Property id_centro As String
    Public Property id_almacen As String
    Public Property qty As String
    Public Property original_price As String
    Public Property regular_price As String

End Class

Public Class ListasCB

    Public Function GetListDBType() As List(Of CBItem)
        Dim List As New List(Of CBItem)

        List.Add(New CBItem("oracle_9", "RetailPro9"))
        List.Add(New CBItem("oracle_10", "Prism (Oracle)"))
        List.Add(New CBItem("mysql_10", "Prism (MySQL)"))

        Return List
    End Function
    Public Function GetListRetailProFields(ByRef type_retail As String) As List(Of CBItem)
        Dim List As New List(Of CBItem)

        If type_retail = "oracle_9" Then
            List.Add(New CBItem("IP.PRICE", "PRICE"))
            List.Add(New CBItem("TRIM('')", "VACIO"))
            List.Add(New CBItem("TRIM(I.ALU)", "ALU"))
            List.Add(New CBItem("TO_CHAR(I.CREATED_DATE,'DD/MM/YYYY')", "CREATED_DATE"))
            List.Add(New CBItem("I.LOCAL_UPC", "UPC"))
            List.Add(New CBItem("I.ACTIVE", "ACTIVE"))
            List.Add(New CBItem("D.DCS_CODE", "DCS_CODE"))
            List.Add(New CBItem("D.D_NAME", "DEPT NAME"))
            List.Add(New CBItem("D.C_NAME", "CLASS NAME"))
            List.Add(New CBItem("D.S_NAME", "SUBCLASS NAME"))
            List.Add(New CBItem("SUBSTR(D.DCS_CODE,0,3)", "D_CODE"))
            List.Add(New CBItem("SUBSTR(D.DCS_CODE,4,3)", "C_CODE"))
            List.Add(New CBItem("SUBSTR(D.DCS_CODE,7,3)", "S_CODE"))
            List.Add(New CBItem("I.DESCRIPTION1", "DESCRIPTION 1"))
            List.Add(New CBItem("I.DESCRIPTION2", "DESCRIPTION 2"))
            List.Add(New CBItem("I.DESCRIPTION3", "DESCRIPTION 3"))
            List.Add(New CBItem("I.DESCRIPTION4", "DESCRIPTION 4"))
            List.Add(New CBItem("Q.QTY", "QTY"))
            List.Add(New CBItem("SUM(Q.QTY)", "SUMA(QTY)"))
            List.Add(New CBItem("U.UDF1_VALUE", "UDF1"))
            List.Add(New CBItem("U.UDF2_VALUE", "UDF2"))
            List.Add(New CBItem("U.UDF3_VALUE", "UDF3"))
            List.Add(New CBItem("U.UDF4_VALUE", "UDF4"))
            List.Add(New CBItem("U.UDF5_VALUE", "UDF5"))
            List.Add(New CBItem("U.UDF6_VALUE", "UDF6"))
            List.Add(New CBItem("U.AUX1_VALUE", "AUX1"))
            List.Add(New CBItem("U.AUX2_VALUE", "AUX2"))
            List.Add(New CBItem("U.AUX3_VALUE", "AUX3"))
            List.Add(New CBItem("U.AUX4_VALUE", "AUX4"))
            List.Add(New CBItem("U.AUX5_VALUE", "AUX5"))
            List.Add(New CBItem("U.AUX6_VALUE", "AUX6"))
            List.Add(New CBItem("U.AUX7_VALUE", "AUX7"))
            List.Add(New CBItem("U.AUX8_VALUE", "AUX8"))
            List.Add(New CBItem("I.SIZ", "SIZ"))
            List.Add(New CBItem("I.ATTR", "ATTR"))
            List.Add(New CBItem("V.VEND_CODE", "VEND_CODE"))
            List.Add(New CBItem("V.VEND_NAME", "VEND_NAME"))
            List.Add(New CBItem("I.COST", "COST"))
            List.Add(New CBItem("I.TEXT1", "TEXT1"))
            List.Add(New CBItem("I.TEXT2", "TEXT2"))
            List.Add(New CBItem("I.TEXT3", "TEXT3"))
            List.Add(New CBItem("I.TEXT4", "TEXT4"))
            List.Add(New CBItem("I.TEXT5", "TEXT5"))
            List.Add(New CBItem("I.TEXT6", "TEXT6"))
            List.Add(New CBItem("I.TEXT7", "TEXT7"))
            List.Add(New CBItem("I.TEXT8", "TEXT8"))
            List.Add(New CBItem("I.TEXT9", "TEXT9"))
            List.Add(New CBItem("I.TEXT10", "TEXT10"))
            'TABLA HAPP CARGA ARTICULOS
            List.Add(New CBItem("H.SKU_PADRE", "SKU_PADRE_HAPP"))
            List.Add(New CBItem("H.SKU", "SKU_HAPP"))
            List.Add(New CBItem("H.NAME", "NAME_HAPP"))
            List.Add(New CBItem("H.DESCRIPTION", "DESCRIPTION_HAPP"))
            List.Add(New CBItem("H.PRICE", "PRICE_HAPP"))
            List.Add(New CBItem("H.ESTADO", "ESTADO_HAPP"))
            List.Add(New CBItem("H.TAXONOMY", "TAXONOMY_HAPP"))
            List.Add(New CBItem("H.COLOR", "COLOR_HAPP"))
            List.Add(New CBItem("H.TALLA", "TALLA_HAPP"))
            List.Add(New CBItem("H.STORE_CODE", "STORE_CODE_HAPP"))
            List.Add(New CBItem("H.SBS_NO", "SBS_NO_HAPP"))
            List.Add(New CBItem("H.COMERCIO", "COMERCIO_HAPP"))



        ElseIf type_retail = "oracle_10" Then
            List.Add(New CBItem("IP.PRICE", "PRICE"))
            List.Add(New CBItem("TRIM('')", "VACIO"))
            List.Add(New CBItem("TRIM(invn.ALU)", "ALU"))
            List.Add(New CBItem("TO_CHAR(invn.CREATED_DATETIME,'DD/MM/YYYY')", "CREATED_DATE"))
            List.Add(New CBItem("invn.ACTIVE", "ACTIVE"))
            List.Add(New CBItem("invn.UPC", "UPC"))
            List.Add(New CBItem("D.DCS_CODE", "DCS_CODE"))
            List.Add(New CBItem("invn.DESCRIPTION1", "DESCRIPTION 1"))
            List.Add(New CBItem("invn.DESCRIPTION2", "DESCRIPTION 2"))
            List.Add(New CBItem("invn.DESCRIPTION3", "DESCRIPTION 3"))
            List.Add(New CBItem("invn.DESCRIPTION4", "DESCRIPTION 4"))
            List.Add(New CBItem("Q.QTY", "QTY"))
            List.Add(New CBItem("SUM(Q.QTY)", "SUMA(QTY)"))
            List.Add(New CBItem("invn.UDF1_STRING", "UDF1_STRING"))
            List.Add(New CBItem("invn.UDF2_STRING", "UDF2_STRING"))
            List.Add(New CBItem("invn.UDF3_STRING", "UDF3_STRING"))
            List.Add(New CBItem("invn.UDF4_STRING", "UDF4_STRING"))
            List.Add(New CBItem("invn.UDF5_STRING", "UDF5_STRING"))
            List.Add(New CBItem("U.UDF6_STRING", "UDF6_STRING"))
            List.Add(New CBItem("U.UDF7_STRING", "UDF7_STRING"))
            List.Add(New CBItem("U.UDF8_STRING", "UDF8_STRING"))
            List.Add(New CBItem("U.UDF9_STRING", "UDF9_STRING"))
            List.Add(New CBItem("U.UDF10_STRING", "UDF10_STRING"))
            List.Add(New CBItem("U.UDF11_STRING", "UDF11_STRING"))
            List.Add(New CBItem("U.UDF12_STRING", "UDF12_STRING"))
            List.Add(New CBItem("U.UDF13_STRING", "UDF13_STRING"))
            List.Add(New CBItem("U.UDF14_STRING", "UDF14_STRING"))
            List.Add(New CBItem("invn.ITEM_SIZE", "ITEM_SIZE"))
            List.Add(New CBItem("invn.ATTRIBUTE", "ATTRIBUTE"))
            List.Add(New CBItem("VEND_CODE", "VEND_CODE"))
            List.Add(New CBItem("invn.COST", "COST"))
            List.Add(New CBItem("invn.TEXT1", "TEXT1"))
            List.Add(New CBItem("invn.TEXT2", "TEXT2"))
            List.Add(New CBItem("invn.TEXT3", "TEXT3"))
            List.Add(New CBItem("invn.TEXT4", "TEXT4"))
            List.Add(New CBItem("invn.TEXT5", "TEXT5"))
            List.Add(New CBItem("invn.TEXT6", "TEXT6"))
            List.Add(New CBItem("invn.TEXT7", "TEXT7"))
            List.Add(New CBItem("invn.TEXT8", "TEXT8"))
            List.Add(New CBItem("invn.TEXT9", "TEXT9"))
            List.Add(New CBItem("invn.TEXT10", "TEXT10"))
            'TABLA HAPP CARGA ARTICULOS
            List.Add(New CBItem("H.SKU_PADRE", "SKU_PADRE_HAPP"))
            List.Add(New CBItem("H.SKU", "SKU_HAPP"))
            List.Add(New CBItem("H.NAME", "NAME_HAPP"))
            List.Add(New CBItem("H.DESCRIPTION", "DESCRIPTION_HAPP"))
            List.Add(New CBItem("H.PRICE", "PRICE_HAPP"))
            List.Add(New CBItem("H.ESTADO", "ESTADO_HAPP"))
            List.Add(New CBItem("H.TAXONOMY", "TAXONOMY_HAPP"))
            List.Add(New CBItem("H.COLOR", "COLOR_HAPP"))
            List.Add(New CBItem("H.TALLA", "TALLA_HAPP"))
            List.Add(New CBItem("H.STORE_CODE", "STORE_CODE_HAPP"))
            List.Add(New CBItem("H.SBS_NO", "SBS_NO_HAPP"))
            List.Add(New CBItem("H.COMERCIO", "COMERCIO_HAPP"))

        ElseIf type_retail = "mysql_10" Then
            List.Add(New CBItem("IP.PRICE", "PRICE"))
            List.Add(New CBItem("' '", "VACIO"))
            List.Add(New CBItem("I.ALU", "ALU"))
            List.Add(New CBItem("TO_CHAR(I.CREATED_DATETIME,'DD/MM/YYYY')", "CREATED_DATE"))
            List.Add(New CBItem("I.ACTIVE", "ACTIVE"))
            List.Add(New CBItem("I.UPC", "UPC"))
            List.Add(New CBItem("D.DCS_CODE", "DCS_CODE"))
            List.Add(New CBItem("I.DESCRIPTION1", "DESCRIPTION 1"))
            List.Add(New CBItem("I.DESCRIPTION2", "DESCRIPTION 2"))
            List.Add(New CBItem("I.DESCRIPTION3", "DESCRIPTION 3"))
            List.Add(New CBItem("I.DESCRIPTION4", "DESCRIPTION 4"))
            List.Add(New CBItem("Q.QTY", "QTY"))
            List.Add(New CBItem("SUM(Q.QTY)", "SUMA(QTY)"))
            List.Add(New CBItem("I.UDF1_STRING", "UDF1_STRING"))
            List.Add(New CBItem("I.UDF2_STRING", "UDF2_STRING"))
            List.Add(New CBItem("I.UDF3_STRING", "UDF3_STRING"))
            List.Add(New CBItem("I.UDF4_STRING", "UDF4_STRING"))
            List.Add(New CBItem("I.UDF5_STRING", "UDF5_STRING"))
            List.Add(New CBItem("I.UDF6_STRING", "UDF6_STRING"))
            List.Add(New CBItem("I.UDF7_STRING", "UDF7_STRING"))
            List.Add(New CBItem("I.UDF8_STRING", "UDF8_STRING"))
            List.Add(New CBItem("I.UDF9_STRING", "UDF9_STRING"))
            List.Add(New CBItem("I.UDF10_STRING", "UDF10_STRING"))
            List.Add(New CBItem("I.UDF11_STRING", "UDF11_STRING"))
            List.Add(New CBItem("I.UDF12_STRING", "UDF12_STRING"))
            List.Add(New CBItem("I.UDF13_STRING", "UDF13_STRING"))
            List.Add(New CBItem("I.UDF14_STRING", "UDF14_STRING"))
            List.Add(New CBItem("I.ITEM_SIZE", "ITEM_SIZE"))
            List.Add(New CBItem("I.ATTRIBUTE", "ATTRIBUTE"))
            List.Add(New CBItem("VEND_CODE", "VEND_CODE"))
            List.Add(New CBItem("I.COST", "COST"))
            List.Add(New CBItem("I.TEXT1", "TEXT1"))
            List.Add(New CBItem("I.TEXT2", "TEXT2"))
            List.Add(New CBItem("I.TEXT3", "TEXT3"))
            List.Add(New CBItem("I.TEXT4", "TEXT4"))
            List.Add(New CBItem("I.TEXT5", "TEXT5"))
            List.Add(New CBItem("I.TEXT6", "TEXT6"))
            List.Add(New CBItem("I.TEXT7", "TEXT7"))
            List.Add(New CBItem("I.TEXT8", "TEXT8"))
            List.Add(New CBItem("I.TEXT9", "TEXT9"))
            List.Add(New CBItem("I.TEXT10", "TEXT10"))
        End If

        Return List
    End Function
    Public Function GetListConditionalFields() As List(Of CBItem)
        Dim List As New List(Of CBItem)

        List.Add(New CBItem("EQUAL", "="))
        List.Add(New CBItem("GREATER_THAN", ">"))
        List.Add(New CBItem("LESS_THAN", "<"))
        List.Add(New CBItem("DIFERENT", "<>"))
        List.Add(New CBItem("GREATER_OR_EQUAL", ">="))
        List.Add(New CBItem("LESS_OR_EQUAL", "<="))
        List.Add(New CBItem("IN", "IN"))
        List.Add(New CBItem("BETWEEN", "BETWEEN"))

        Return List
    End Function
    Public Function GetListRetailProFieldsByJson() As List(Of CBItem)
        Dim List As New List(Of CBItem)

        List.Add(New CBItem("-1", "NULL"))
        List.Add(New CBItem("0", "VACIO"))
        List.Add(New CBItem("1", "STORE.SBS_NO"))
        List.Add(New CBItem("2", "STORE.STORE_NO"))
        List.Add(New CBItem("3", "STORE.ECOMMERCE_CODE"))
        'List.Add(New CBItem("4", "ADDRESS1"))
        'List.Add(New CBItem("5", "ADDRESS2"))
        'List.Add(New CBItem("6", "ADDRESS3"))
        'List.Add(New CBItem("7", "ADDRESS4"))
        'List.Add(New CBItem("8", "ADDRESS5"))
        'List.Add(New CBItem("9", "ADDRESS6"))
        'List.Add(New CBItem("10", "UDF1_VALUE"))
        'List.Add(New CBItem("11", "UDF2_VALUE"))
        'List.Add(New CBItem("12", "UDF3_VALUE"))
        'List.Add(New CBItem("13", "UDF4_VALUE"))
        'List.Add(New CBItem("14", "STORES.SBS_NO"))
        'List.Add(New CBItem("15", "STORES.STORE_NO"))
        'List.Add(New CBItem("16", "STORES.GLOB_STORE_CODE"))
        'List.Add(New CBItem("17", "STORES.ADDRESS1"))
        'List.Add(New CBItem("18", "STORES.ADDRESS2"))
        'List.Add(New CBItem("19", "STORES.ADDRESS3"))
        'List.Add(New CBItem("20", "STORES.ADDRESS4"))
        'List.Add(New CBItem("21", "STORES.ADDRESS5"))
        'List.Add(New CBItem("22", "STORES.ADDRESS6"))
        'List.Add(New CBItem("23", "STORES.UDF1_VALUE"))
        'List.Add(New CBItem("24", "STORES.UDF2_VALUE"))
        'List.Add(New CBItem("25", "STORES.UDF3_VALUE"))
        'List.Add(New CBItem("26", "STORES.UDF4_VALUE"))
        List.Add(New CBItem("27", "ITEMS.ALU"))
        List.Add(New CBItem("28", "ITEMS.UPC"))
        List.Add(New CBItem("29", "ITEMS.QTY"))
        List.Add(New CBItem("30", "P.PRICE"))
        List.Add(New CBItem("31", "ITEMS.ACTIVE"))

        Return List
    End Function
    Public Function GetListRetailProFieldsByEcommerceCode(ByRef db As String) As List(Of CBItem)
        Dim List As New List(Of CBItem)
        If db = "oracle_9" Then
            List.Add(New CBItem("S.STORE_NO", "STORE_NO"))
            List.Add(New CBItem("S.GLOB_STORE_CODE", "GLOB_STORE_CODE"))
            List.Add(New CBItem("S.STORE_NAME", "STORE_NAME"))
            List.Add(New CBItem("S.ADDRESS1", "ADDRESS1"))
            List.Add(New CBItem("S.ADDRESS2", "ADDRESS2"))
            List.Add(New CBItem("S.ADDRESS3", "ADDRESS3"))
            List.Add(New CBItem("S.ADDRESS4", "ADDRESS4"))
            List.Add(New CBItem("S.ADDRESS5", "ADDRESS5"))
            List.Add(New CBItem("S.ADDRESS6", "ADDRESS6"))
            List.Add(New CBItem("S.UDF1_VALUE", "UDF1_VALUE"))
            List.Add(New CBItem("S.UDF2_VALUE", "UDF2_VALUE"))
            List.Add(New CBItem("S.UDF3_VALUE", "UDF3_VALUE"))
            List.Add(New CBItem("S.UDF4_VALUE", "UDF4_VALUE"))
        ElseIf db = "oracle_10" Then
            List.Add(New CBItem("S.STORE_NO", "STORE_NO"))
            List.Add(New CBItem("S.GLOB_STORE_CODE", "GLOB_STORE_CODE"))
            List.Add(New CBItem("S.STORE_NAME", "STORE_NAME"))
            List.Add(New CBItem("S.ADDRESS1", "ADDRESS1"))
            List.Add(New CBItem("S.ADDRESS2", "ADDRESS2"))
            List.Add(New CBItem("S.ADDRESS3", "ADDRESS3"))
            List.Add(New CBItem("S.ADDRESS4", "ADDRESS4"))
            List.Add(New CBItem("S.ADDRESS5", "ADDRESS5"))
            List.Add(New CBItem("S.ADDRESS6", "ADDRESS6"))
            List.Add(New CBItem("S.UDF1_STRING", "UDF1_STRING"))
            List.Add(New CBItem("S.UDF2_STRING", "UDF2_STRING"))
            List.Add(New CBItem("S.UDF3_STRING", "UDF3_STRING"))
            List.Add(New CBItem("S.UDF4_STRING", "UDF4_STRING"))
            List.Add(New CBItem("S.UDF5_STRING", "UDF5_STRING"))
        End If


        Return List
    End Function

End Class
Public Class CBItem

    Sub New()

    End Sub

    Sub New(ByVal Value As String, ByVal Label As String)

        Me.Label = Label
        Me.Value = Value
    End Sub

    Public Property Label As String
    Public Property Value As String
End Class


