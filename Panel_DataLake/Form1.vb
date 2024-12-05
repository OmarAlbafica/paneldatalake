Imports System.IO
Imports CRpro9
Imports Oracle.ManagedDataAccess.Client
Imports System.Net
Public Class Form1
    Dim config As New CConfig
    Dim ora As New Funciones
    Dim archivo_config As Boolean
    Dim Credenciales As New Credenciales
    Dim StockConf As New ConfStock
    Dim ConfD As New ConfDelta
    Dim CatConf As New ConfCat
    Dim CatConfI As New ConfUrlTiendas
    Dim CredEndI As New CredenEndInv
    Dim ListasCB As New ListasCB
    Dim Sbs_no = ""
    Dim Sbs_noM = ""
    Dim Sbs_noD = ""
    Dim FiltRpro As String
    Dim num2 = 0
    Dim num1 = 0

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If archivo_config = True Then
            '+++++++++ Credenciales BaseDatos ++++++++++
            txt_host_db.Text = Credenciales.ip
            txt_port_db.Text = Credenciales.puerto
            txt_user_db.Text = Credenciales.usuario
            txt_pass_db.Text = Credenciales.password
            txt_db_name.Text = Credenciales.db
            cb_db_con.SelectedValue = Credenciales.plataforma

            txt_host_db.Enabled = False
            txt_port_db.Enabled = False
            txt_user_db.Enabled = False
            txt_pass_db.Enabled = False
            txt_db_name.Enabled = False
            cb_db_con.Enabled = False

            '+++++++++ Configuraciones Inventario ++++++++++
            CHB_ActivarFiltrosCat.Checked = CatConf.activar_filtros
            ch_activalFiltrosD.Checked = ConfD.activar_filtros
            If CatConf.Mapeos.Count > 0 Then
                For Each mapeo As Mapeo In CatConf.Mapeos
                    dgv_mapeoInventario.Rows.Add(mapeo.campo_rpro, mapeo.ecommerce)
                Next
            End If

            If CatConf.filtros.Count > 0 Then
                For Each filtro As Filtro In CatConf.filtros
                    DGV_FiltrosCatalogo.Rows.Add(filtro.operador, filtro.campo_rpro, filtro.condicion, filtro.valor)
                Next
            End If

            If ConfD.filtros.Count > 0 Then
                For Each filtro As Filtro In ConfD.filtros
                    gv_filtrosD.Rows.Add(filtro.operador, filtro.campo_rpro, filtro.condicion, filtro.valor)
                Next
            End If
            dgv_mapeoInventario.Enabled = False
            bt_agregarI.Enabled = False
            cb_rpro_campI.Enabled = False
            txt_dalake_campI.Enabled = False

            'cb_tiempoInv.SelectedItem = StockConf.tiempo
            'cb_hLun.SelectedItem = StockConf.Lu_tiempo
            'cb_hMar.SelectedItem = StockConf.Mar_tiempo
            'cb_hMi.SelectedItem = StockConf.Mar_tiempo
            'cb_hJue.SelectedItem = StockConf.Ju_tiempo
            'cb_hVie.SelectedItem = StockConf.Vi_tiempo
            'cb_hSa.SelectedItem = StockConf.Sa_tiempo
            txt_notiMail_Inv.Text = StockConf.Mail
            txt_tiempo.Text = StockConf.TiempoEjec
            cb_subsidiariaInv.Enabled = False
            cb_store_I.Enabled = False

            cb_interfazL.Enabled = False
            cb_interfazM.Enabled = False
            cb_interfazMI.Enabled = False
            cb_interfazJ.Enabled = False
            cb_interfazV.Enabled = False
            cb_interfazS.Enabled = False
            cb_interfazD.Enabled = False
            txt_notiMail_Inv.Enabled = False
            cb_tiempoInv.Enabled = False
            cb_hLun.Enabled = False
            cb_hMar.Enabled = False
            cb_hMi.Enabled = False
            cb_hJue.Enabled = False
            cb_hVie.Enabled = False
            cb_hSa.Enabled = False
            dgv_tiendas_tiemposI.Enabled = False
            bt_agregarTieI.Enabled = False
            txt_tiempo.Enabled = False

            'actualizacion variables Endpoint Inventario
            txt_urlInv.Text = CredEndI.url
            txt_tokenI.Text = CredEndI.token


            cb_rpro_Cat.SelectedItem = FiltRpro
            GB_FilterI.Enabled = False
            GP_FilterD.Enabled = False
            txt_urlInv.Enabled = False
            txt_tokenI.Enabled = False
            bt_guardarConfInv.Text = "Editar"
            bt_guardar_db.Text = "Editar"
            bt_GuardarMapI.Text = "Editar"
            bt_GuardarCredI.Text = "Editar"
            B_SetConfCat_Filter.Text = "Editar"
            B_SetConfCat_FilterD.Text = "Editar"


            If CatConfI.TiendasUrl.Count > 0 Then
                For Each tienda As TiendaUrl In CatConfI.TiendasUrl
                    dgv_tiendas_tiemposI.Rows.Add(tienda.sbs_no, tienda.store_no, tienda.Lunes, tienda.Lu_tiempo, tienda.Martes, tienda.Mar_tiempo, tienda.Miercoles, tienda.Mie_tiempo, tienda.Jueves, tienda.Ju_tiempo, tienda.Viernes, tienda.Vi_tiempo, tienda.Sabado, tienda.Sa_tiempo, tienda.Domingo, tienda.tiempo)
                Next
            End If

            'If StockConf.tiendas.Count > 0 Then
            '    For Each tienda As Tienda In StockConf.tiendas

            '        For i = 0 To cb_list_storesM.Items.Count - 1
            '            Dim num_tienda

            '            num_tienda = Convert.ToInt32(cb_list_storesM.GetItemText(cb_list_storesM.Items(i)).ToString.Substring(0, 3))

            '            If tienda.store_no = num_tienda Then
            '                cb_list_storesM.SetItemChecked(i, True)
            '            End If
            '        Next

            '    Next
            'End If

            If ConfD.tiendasD.Count > 0 Then
                For Each tienda As TiendaD In ConfD.tiendasD

                    For i = 0 To cb_list_storesD.Items.Count - 1
                        Dim num_tienda

                        num_tienda = Convert.ToInt32(cb_list_storesD.GetItemText(cb_list_storesD.Items(i)).ToString.Substring(0, 3))

                        If tienda.store_no = num_tienda Then
                            cb_list_storesD.SetItemChecked(i, True)
                        End If
                    Next

                Next
            End If
            'llenado de compo campos rpro

            Dim dt As DataTable = New DataTable("Tabla")

            dt.Columns.Add("Codigo")
            dt.Columns.Add("Descripcion")

            Dim dr As DataRow



            dr = dt.NewRow()
            dr("Codigo") = "IP.PRICE"
            dr("Descripcion") = "PRICE"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "TRIM('')"
            dr("Descripcion") = "VACIO"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "TRIM(I.ALU)"
            dr("Descripcion") = "ALU"
            dt.Rows.Add(dr)


            dr = dt.NewRow()
            dr("Codigo") = "I.ACTIVE"
            dr("Descripcion") = "ACTIVE"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.UPC"
            dr("Descripcion") = "UPC"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "D.DCS_CODE"
            dr("Descripcion") = "DCS_CODE"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "SUBSTR(D.DCS_CODE,0,3)"
            dr("Descripcion") = "D"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "D.D_NAME"
            dr("Descripcion") = "D_NAME"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "SUBSTR(D.DCS_CODE,4,3)"
            dr("Descripcion") = "C"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "D.C_NAME"
            dr("Descripcion") = "C_NAME"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "SUBSTR(D.DCS_CODE,7,3)"
            dr("Descripcion") = "S"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "D.S_NAME"
            dr("Descripcion") = "S_NAME"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.DESCRIPTION1"
            dr("Descripcion") = "DESCRIPTION1"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.DESCRIPTION2"
            dr("Descripcion") = "DESCRIPTION2"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.DESCRIPTION3"
            dr("Descripcion") = "DESCRIPTION3"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.DESCRIPTION4"
            dr("Descripcion") = "DESCRIPTION4"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "SUM(Q.QTY)"
            dr("Descripcion") = "QTY(suma)"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "NVL(Q.QTY,0)"
            dr("Descripcion") = "QTY"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.UDF1_STRING"
            dr("Descripcion") = "UDF1_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.UDF2_STRING"
            dr("Descripcion") = "UDF_2"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.UDF3_STRING"
            dr("Descripcion") = "UDF3_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.UDF4_STRING"
            dr("Descripcion") = "UDF4_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.UDF5_STRING"
            dr("Descripcion") = "UDF5_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF6_STRING"
            dr("Descripcion") = "UDF6_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF7_STRING"
            dr("Descripcion") = "UDF7_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF8_STRING"
            dr("Descripcion") = "UDF8_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF9_STRING"
            dr("Descripcion") = "UDF9_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF10_STRING"
            dr("Descripcion") = "UDF10_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF11_STRING"
            dr("Descripcion") = "UDF11_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF12_STRING"
            dr("Descripcion") = "UDF12_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF13_STRING"
            dr("Descripcion") = "UDF13_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "U.UDF14_STRING"
            dr("Descripcion") = "UDF14_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.ITEM_SIZE"
            dr("Descripcion") = "ITEM_SIZE"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.ATTRIBUTE"
            dr("Descripcion") = "ATTRIBUTE"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "V.VEND_CODE"
            dr("Descripcion") = "VEND_CODE"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "V.VEND_NAME"
            dr("Descripcion") = "VEND_NAME"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.COST"
            dr("Descripcion") = "COST"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT1"
            dr("Descripcion") = "TEXT1"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT2"
            dr("Descripcion") = "TEXT2"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT3"
            dr("Descripcion") = "TEXT3"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT4"
            dr("Descripcion") = "TEXT4"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT5"
            dr("Descripcion") = "TEXT5"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT6"
            dr("Descripcion") = "TEXT6"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT7"
            dr("Descripcion") = "TEXT7"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT8"
            dr("Descripcion") = "TEXT8"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT9"
            dr("Descripcion") = "TEXT9"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "I.TEXT10"
            dr("Descripcion") = "TEXT10"
            dt.Rows.Add(dr)
            dr = dt.NewRow()

            dr("Codigo") = "S.STORE_NO"
            dr("Descripcion") = "STORE_NO"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "S.STORE_CODE"
            dr("Descripcion") = "STORE_CODE"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "S.STORE_NAME"
            dr("Descripcion") = "STORE_NAME"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "S.GLOBAL_STORE_CODE"
            dr("Descripcion") = "GLOBAL_STORE_CODE"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "S.UDF1_STRING"
            dr("Descripcion") = "UDF1_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "S.UDF2_STRING"
            dr("Descripcion") = "UDF2_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "S.UDF3_STRING"
            dr("Descripcion") = "UDF3_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "S.UDF4_STRING"
            dr("Descripcion") = "UDF4_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "S.UDF5_STRING"
            dr("Descripcion") = "UDF5_STRING"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "SB.SBS_NO"
            dr("Descripcion") = "SBS_NO"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "SB.SBS_NAME"
            dr("Descripcion") = "SBS_NAME"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "SC.COD_SOCIEDAD"
            dr("Descripcion") = "ID_SOCIEDAD"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "CC.CENTRO"
            dr("Descripcion") = "ID_CENTRO"
            dt.Rows.Add(dr)

            dr = dt.NewRow()
            dr("Codigo") = "CC.ALMACEN"
            dr("Descripcion") = "ID_ALMACEN"
            dt.Rows.Add(dr)


            cb_rpro_campI.DataSource = dt
            cb_rpro_campI.ValueMember = "Codigo"
            cb_rpro_campI.DisplayMember = "Descripcion"

            cb_rpro_Cat.DataSource = dt
            cb_rpro_Cat.ValueMember = "Codigo"
            cb_rpro_Cat.DisplayMember = "Descripcion"

            cb_rproD.DataSource = dt
            cb_rproD.ValueMember = "Codigo"
            cb_rproD.DisplayMember = "Descripcion"
        Else
            txt_host_db.Enabled = True
            txt_port_db.Enabled = True
            txt_user_db.Enabled = True
            txt_pass_db.Enabled = True
            txt_db_name.Enabled = True
            cb_db_con.Enabled = True

            cb_subsidiariaInv.Enabled = True
            cb_store_I.Enabled = True

            cb_interfazL.Enabled = True
            cb_interfazM.Enabled = True
            cb_interfazMI.Enabled = True
            cb_interfazJ.Enabled = True
            cb_interfazV.Enabled = True
            cb_interfazS.Enabled = True
            cb_interfazD.Enabled = True
            txt_notiMail_Inv.Enabled = True
            cb_tiempoInv.Enabled = True
            cb_hLun.Enabled = True
            cb_hMar.Enabled = True
            cb_hMi.Enabled = True
            cb_hJue.Enabled = True
            cb_hVie.Enabled = True
            cb_hSa.Enabled = True
            dgv_tiendas_tiemposI.Enabled = True
            bt_agregarTieI.Enabled = True
            txt_tiempo.Enabled = True

            dgv_mapeoInventario.Enabled = True
            bt_agregarI.Enabled = True
            cb_rpro_campI.Enabled = True
            txt_dalake_campI.Enabled = True

            txt_urlInv.Enabled = True
            txt_tokenI.Enabled = True

            GB_FilterI.Enabled = True
            GP_FilterD.Enabled = True

            bt_guardarConfInv.Text = "Guardar"
            bt_guardar_db.Text = "Guardar"
            bt_GuardarMapI.Text = "Guardar"
            bt_GuardarCredI.Text = "Guardar"
            B_SetConfCat_Filter.Text = "Guardar"
            B_SetConfCat_FilterD.Text = "Guardar"
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try


            config.carpetaAplicativo = Environment.CurrentDirectory
            config.CarpetaLogAplicativo = Environment.CurrentDirectory & "/Log_Panel"
            config.MetodoEncriptar = "MD5"
            config.NombreArchivoConf = "Conf_DataLake"
            config.ClaveEncriptar = "Ecommerce"

            cb_db_con.DataSource = ListasCB.GetListDBType
            cb_db_con.DisplayMember = "Label"
            cb_db_con.ValueMember = "Value"

            If config.ExisteXML Then

                archivo_config = True

                LlenarVariablesCredenciales()
                LlenarVariablesInventario()
                LlenarVariablesMapeoInv()
                LlenarVariablesInv()
                LlenarVariablesCatFilter()
                LlenarVariablesCatFilterD()

                Try
                    ora.Conexion = "DATA SOURCE=" & Credenciales.ip & ":" & Credenciales.puerto & "/" & Credenciales.db & ";PASSWORD=" & Credenciales.password & ";PERSIST SECURITY INFO=True;USER ID=" & Credenciales.usuario

                    Dim RspConectar As New ResponseCRpro9
                    RspConectar = ora.Conectar()
                    If RspConectar.status Then
                        Dim RspSubsidiary As New ResponseCRpro9
                        Dim RspStores As New ResponseCRpro9
                        Dim RspSubsidiaryM As New ResponseCRpro9
                        Dim RspStoresM As New ResponseCRpro9
                        Dim RspSubsidiaryD As New ResponseCRpro9
                        Dim RspStoresD As New ResponseCRpro9

                        '******COMBO SUBSIDIARIA EJECUCION MANUAL INVENTARIO**************
                        Dim NodosTiendas As New List(Of NodoConAtributos)
                        NodosTiendas = config.LeerNodosConAtributos("", "Inventario", "Tiendas", "Tienda")


                        LlenarTiendas(NodosTiendas)
                        If StockConf.tiendas.Count > 0 Then
                            Sbs_noM = StockConf.tiendas(0).sbs_no
                            cb_sbs_noM.SelectedItem = Sbs_noM
                        Else
                            Sbs_noM = "0"
                        End If

                        RspSubsidiaryM = ora.ListarSubsidiarys(Convert.ToInt16(Sbs_noM), "oracle_10")

                        If RspSubsidiaryM.status Then

                            cb_sbs_noM.DataSource = RspSubsidiaryM.result
                            cb_sbs_noM.DisplayMember = "DISPLAY"
                            cb_sbs_noM.ValueMember = "SBS_NO"

                            RspStoresM = ora.ListarStores(Short.Parse(cb_sbs_noM.SelectedValue), "oracle_10")
                            If RspStoresM.status Then

                                cb_list_storesM.DataSource = RspStoresM.result
                                cb_list_storesM.DisplayMember = "DISPLAY"
                                cb_list_storesM.ValueMember = "STORE_NO"
                            Else
                                MsgBox(RspStoresM.message, MsgBoxStyle.Critical, "Error - Oracle")
                            End If
                        Else
                            MsgBox(RspSubsidiaryM.message, MsgBoxStyle.Critical, "Error - Oracle")
                        End If

                        '******COMBO SUBSIDIARIA EJECUCION MANUAL DELTA**************
                        Dim NodosTiendasD As New List(Of NodoConAtributos)
                        NodosTiendasD = config.LeerNodosConAtributos("", "InventarioDeltam", "Tiendas", "Tienda")


                        LlenarTiendasD(NodosTiendasD)
                        If ConfD.tiendasD.Count > 0 Then
                            Sbs_noD = ConfD.tiendasD(0).sbs_no
                            cb_sbs_noD.SelectedItem = Sbs_noD
                        Else
                            Sbs_noD = "0"
                        End If

                        RspSubsidiaryD = ora.ListarSubsidiarys(Convert.ToInt16(Sbs_noD), "oracle_10")

                        If RspSubsidiaryD.status Then

                            cb_sbs_noD.DataSource = RspSubsidiaryD.result
                            cb_sbs_noD.DisplayMember = "DISPLAY"
                            cb_sbs_noD.ValueMember = "SBS_NO"

                            RspStoresD = ora.ListarStores(Short.Parse(cb_sbs_noD.SelectedValue), "oracle_10")
                            If RspStoresD.status Then

                                cb_list_storesD.DataSource = RspStoresD.result
                                cb_list_storesD.DisplayMember = "DISPLAY"
                                cb_list_storesD.ValueMember = "STORE_NO"
                            Else
                                MsgBox(RspStoresD.message, MsgBoxStyle.Critical, "Error - Oracle")
                            End If
                        Else
                            MsgBox(RspSubsidiaryD.message, MsgBoxStyle.Critical, "Error - Oracle")
                        End If

                        '******COMBO SUBSIDIARIA EJECUCION AUTOMATICA **************
                        'CatConfI.TiendasUrl
                        If CatConfI.TiendasUrl.Count > 0 Then
                            Sbs_no = CatConfI.TiendasUrl(0).sbs_no
                        Else
                            Sbs_no = "0"
                        End If
                        RspSubsidiary = ora.ListarSubsidiarys(Convert.ToInt16(Sbs_no), "oracle_10")

                        If RspSubsidiary.status Then
                            cb_subsidiariaInv.DataSource = RspSubsidiary.result
                            cb_subsidiariaInv.DisplayMember = "DISPLAY"
                            cb_subsidiariaInv.ValueMember = "SBS_NO"


                            RspStores = ora.ListarStores(Short.Parse(cb_subsidiariaInv.SelectedValue), "oracle_10")
                            If RspStores.status Then

                                cb_store_I.DataSource = RspStores.result
                                cb_store_I.DisplayMember = "DISPLAY"
                                cb_store_I.ValueMember = "STORE_NO"
                            Else
                                MsgBox(RspStores.message, MsgBoxStyle.Critical, "Error - Oracle")
                            End If
                        Else
                            MsgBox(RspSubsidiary.message, MsgBoxStyle.Critical, "Error - Oracle")
                        End If
                    Else
                        MsgBox(RspConectar.message, MsgBoxStyle.Critical, "Error - Oracle")
                    End If
                Catch ex As Exception
                    MsgBox(ex, MsgBoxStyle.Critical, "Error - Aplicativo")
                End Try
            Else
                archivo_config = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error - Aplicacion")
        End Try
    End Sub
    Private Sub bt_test_db_Click(sender As Object, e As EventArgs) Handles bt_test_db.Click

        If txt_host_db.Text <> "" And txt_port_db.Text <> "" And txt_user_db.Text <> "" And txt_pass_db.Text <> "" And txt_db_name.Text <> "" Then

            ora.Conexion = "DATA SOURCE=" & txt_host_db.Text & ":" & txt_port_db.Text & "/" & txt_db_name.Text & ";PASSWORD=" & txt_pass_db.Text & ";PERSIST SECURITY INFO=True;USER ID=" & txt_user_db.Text

            If ora.Conectar.status Then
                MsgBox(ora.Conectar.message + " " + txt_db_name.Text, MsgBoxStyle.Information, "Informacion")
            Else
                MsgBox(ora.Conectar.message, MsgBoxStyle.Critical, "Error - Conexion")
            End If

        End If
    End Sub

    Private Sub bt_guardar_db_Click(sender As Object, e As EventArgs) Handles bt_guardar_db.Click
        If bt_guardar_db.Text.Contains("Guardar") Then

            'MySQL
            config.GuardarAtributo("", "Oracle", "IP", txt_host_db.Text, False)
            config.GuardarAtributo("", "Oracle", "Puerto", txt_port_db.Text, False)
            config.GuardarAtributo("", "Oracle", "Usuario", txt_user_db.Text, False)
            config.GuardarAtributo("", "Oracle", "Password", txt_pass_db.Text, True)
            config.GuardarAtributo("", "Oracle", "BaseDeDatos", txt_db_name.Text, False)
            config.GuardarAtributo("", "Oracle", "DB_TYPE", cb_db_con.SelectedValue, False)




            'Actualizar Variables
            Credenciales.ip = txt_host_db.Text
            Credenciales.puerto = txt_port_db.Text
            Credenciales.usuario = txt_user_db.Text
            Credenciales.password = txt_pass_db.Text
            Credenciales.db = txt_db_name.Text
            Credenciales.plataforma = cb_db_con.SelectedValue

            txt_host_db.Enabled = False
            txt_port_db.Enabled = False
            txt_user_db.Enabled = False
            txt_pass_db.Enabled = False
            txt_db_name.Enabled = False
            cb_db_con.Enabled = False

            MsgBox("Credenciales Guardadas con Exito", MsgBoxStyle.Information, "Info")
            bt_guardar_db.Text = "Editar"
        ElseIf bt_guardar_db.Text.Contains("Editar") Then

            txt_host_db.Enabled = True
            txt_port_db.Enabled = True
            txt_user_db.Enabled = True
            txt_pass_db.Enabled = True
            txt_db_name.Enabled = True
            cb_db_con.Enabled = True

            bt_guardar_db.Text = "Guardar"

        End If
    End Sub
    Private Sub LlenarVariablesCredenciales()
        Credenciales.ip = config.LeerAtributo("", "", "Oracle", "IP", False)
        Credenciales.puerto = config.LeerAtributo("", "", "Oracle", "Puerto", False)
        Credenciales.usuario = config.LeerAtributo("", "", "Oracle", "Usuario", False)
        Credenciales.password = config.LeerAtributo("", "", "Oracle", "Password", True)
        Credenciales.db = config.LeerAtributo("", "", "Oracle", "BaseDeDatos", False)
        Credenciales.plataforma = config.LeerAtributo("", "", "Oracle", "DB_TYPE", False)
    End Sub
    Private Sub LlenarVariablesInv()
        CredEndI.url = config.LeerAtributo("", "", "EndpointInv", "Url", False)
        CredEndI.token = config.LeerAtributo("", "", "EndpointInv", "Token", False)

    End Sub
    Private Sub LlenarTiendas(ByVal NTiendas As List(Of NodoConAtributos))
        If NTiendas.Count > 0 Then
            StockConf.tiendas.Clear()

            For Each Ntienda As NodoConAtributos In NTiendas
                Dim tienda As New Tienda
                tienda.sbs_no = Ntienda.Atributos.Find(Function(t) t.Nombre = "sbs_no").Valor
                tienda.store_no = Ntienda.Atributos.Find(Function(t) t.Nombre = "store_no").Valor

                StockConf.tiendas.Add(tienda)
            Next
        End If
    End Sub

    Private Sub LlenarTiendasD(ByVal NTiendas As List(Of NodoConAtributos))
        If NTiendas.Count > 0 Then
            ConfD.tiendasD.Clear()

            For Each Ntienda As NodoConAtributos In NTiendas
                Dim tienda As New TiendaD
                tienda.sbs_no = Ntienda.Atributos.Find(Function(t) t.Nombre = "sbs_no").Valor
                tienda.store_no = Ntienda.Atributos.Find(Function(t) t.Nombre = "store_no").Valor

                ConfD.tiendasD.Add(tienda)
            Next
        End If
    End Sub

    Private Sub LlenarVariablesMapeoInv()

        Dim NodosMapeos As New List(Of NodoConAtributos)
        NodosMapeos = config.LeerNodosConAtributos("", "Inventario", "MapeoInventario", "Mapeo")
        LlenarMapeo(CatConf.Mapeos, NodosMapeos)

    End Sub
    Private Sub LlenarMapeo(ByRef Mapeos As List(Of Mapeo), ByVal NMapeos As List(Of NodoConAtributos))
        If NMapeos.Count > 0 Then
            Mapeos.Clear()

            For Each NMapeo As NodoConAtributos In NMapeos
                Dim mapeo As New Mapeo
                mapeo.ecommerce = NMapeo.Atributos.Find(Function(t) t.Nombre = "DataLake").Valor
                mapeo.campo_rpro = NMapeo.Atributos.Find(Function(t) t.Nombre = "campo_rpro").Valor


                Mapeos.Add(mapeo)
            Next
        End If
    End Sub


    Private Sub LlenarVariablesInventario()
        Dim str_activar As String = config.LeerAtributo("", "Inventario", "Filtros", "Activar", False)

        CatConf.activar_filtros = IIf(str_activar.ToUpper = "TRUE" Or str_activar.ToUpper = "FALSE", str_activar, False)

        StockConf.Mail = config.LeerAtributo("", "", "Inventario", "Email", False)
        StockConf.TiempoEjec = config.LeerAtributo("", "", "Inventario", "Tiempo", False)
        Dim NodosFiltros As New List(Of NodoConAtributos)
        NodosFiltros = config.LeerNodosConAtributos("", "ConfTiendas", "ProcesTiendas", "Tienda")
        LlenarUrlTiendas(CatConfI.TiendasUrl, NodosFiltros)
    End Sub

    Private Sub LlenarUrlTiendas(ByRef Tiendas As List(Of TiendaUrl), ByVal NFiltros As List(Of NodoConAtributos))
        If NFiltros.Count > 0 Then
            Tiendas.Clear()
            'Latributos.Add(New Campo("Hora_Lunes", "", False))
            'Latributos.Add(New Campo("Martes", "", False))
            'Latributos.Add(New Campo("Hora_Martes", "", False))
            'Latributos.Add(New Campo("Miercoles", "", False))
            'Latributos.Add(New Campo("Hora_Miercoles", "", False))
            'Latributos.Add(New Campo("Jueves", "", False))
            'Latributos.Add(New Campo("Hora_Jueves", "", False))
            'Latributos.Add(New Campo("Viernes", "", False))
            'Latributos.Add(New Campo("Hora_Viernes", "", False))
            'Latributos.Add(New Campo("Sabado", "", False))
            'Latributos.Add(New Campo("Hora_Sabado", "", False))
            'Latributos.Add(New Campo("Domingo", "", False))
            'Latributos.Add(New Campo("Hora_Domingo", "", False))
            For Each Nfiltro As NodoConAtributos In NFiltros
                Dim tiendaURL As New TiendaUrl

                tiendaURL.sbs_no = Nfiltro.Atributos.Find(Function(t) t.Nombre = "sbs_no").Valor
                tiendaURL.store_no = Nfiltro.Atributos.Find(Function(t) t.Nombre = "store_no").Valor
                tiendaURL.Lunes = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Lunes").Valor
                tiendaURL.Lu_tiempo = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Hora_Lunes").Valor
                tiendaURL.Martes = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Martes").Valor
                tiendaURL.Mar_tiempo = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Hora_Martes").Valor
                tiendaURL.Miercoles = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Miercoles").Valor
                tiendaURL.Mie_tiempo = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Hora_Miercoles").Valor
                tiendaURL.Jueves = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Jueves").Valor
                tiendaURL.Ju_tiempo = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Hora_Jueves").Valor
                tiendaURL.Viernes = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Viernes").Valor
                tiendaURL.Vi_tiempo = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Hora_Viernes").Valor
                tiendaURL.Sabado = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Sabado").Valor
                tiendaURL.Sa_tiempo = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Hora_Sabado").Valor
                tiendaURL.Domingo = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Domingo").Valor
                tiendaURL.tiempo = Nfiltro.Atributos.Find(Function(t) t.Nombre = "Hora_Domingo").Valor

                Tiendas.Add(tiendaURL)
            Next
        End If
    End Sub
    Private Function GetStoreList(ByRef FilasUrl As DataGridView) As List(Of NodoConAtributos)
        Dim NodosFiltros As New List(Of NodoConAtributos)

        If FilasUrl.Rows.Count > 0 Then

            CatConfI.TiendasUrl.Clear()

            For Each fila As DataGridViewRow In FilasUrl.Rows
                Dim NodoFiltro As New NodoConAtributos
                Dim Latributos As New List(Of Campo)



                Latributos.Add(New Campo("sbs_no", fila.Cells("fc_sbs_no").Value, False))
                Latributos.Add(New Campo("store_no", fila.Cells("fc_store_no").Value, False))
                Latributos.Add(New Campo("Lunes", fila.Cells("fc_lunes").Value, False))
                Latributos.Add(New Campo("Hora_Lunes", fila.Cells("fc_hora_lu").Value, False))
                Latributos.Add(New Campo("Martes", fila.Cells("fc_martes").Value, False))
                Latributos.Add(New Campo("Hora_Martes", fila.Cells("fc_hora_ma").Value, False))
                Latributos.Add(New Campo("Miercoles", fila.Cells("fc_miercoles").Value, False))
                Latributos.Add(New Campo("Hora_Miercoles", fila.Cells("fc_hora_Mi").Value, False))
                Latributos.Add(New Campo("Jueves", fila.Cells("fc_jueves").Value, False))
                Latributos.Add(New Campo("Hora_Jueves", fila.Cells("fc_hora_Ju").Value, False))
                Latributos.Add(New Campo("Viernes", fila.Cells("fc_viernes").Value, False))
                Latributos.Add(New Campo("Hora_Viernes", fila.Cells("fc_hora_Vi").Value, False))
                Latributos.Add(New Campo("Sabado", fila.Cells("fc_sabado").Value, False))
                Latributos.Add(New Campo("Hora_Sabado", fila.Cells("fc_hora_Sa").Value, False))
                Latributos.Add(New Campo("Domingo", fila.Cells("fc_domingo").Value, False))
                Latributos.Add(New Campo("Hora_Domingo", fila.Cells("fc_hora_do").Value, False))


                NodoFiltro.Nombre = "Tienda"
                NodoFiltro.Atributos = Latributos
                NodosFiltros.Add(NodoFiltro)

                Dim TiendaUrl As New TiendaUrl


                TiendaUrl.sbs_no = fila.Cells("fc_sbs_no").Value
                TiendaUrl.store_no = fila.Cells("fc_store_no").Value
                TiendaUrl.Lunes = fila.Cells("fc_lunes").Value
                TiendaUrl.Lu_tiempo = fila.Cells("fc_hora_lu").Value
                TiendaUrl.Martes = fila.Cells("fc_martes").Value
                TiendaUrl.Mar_tiempo = fila.Cells("fc_hora_ma").Value
                TiendaUrl.Miercoles = fila.Cells("fc_miercoles").Value
                TiendaUrl.Mie_tiempo = fila.Cells("fc_hora_Mi").Value
                TiendaUrl.Jueves = fila.Cells("fc_jueves").Value
                TiendaUrl.Ju_tiempo = fila.Cells("fc_hora_Ju").Value
                TiendaUrl.Viernes = fila.Cells("fc_viernes").Value
                TiendaUrl.Vi_tiempo = fila.Cells("fc_hora_Vi").Value
                TiendaUrl.Sabado = fila.Cells("fc_sabado").Value
                TiendaUrl.Sa_tiempo = fila.Cells("fc_hora_Sa").Value
                TiendaUrl.Domingo = fila.Cells("fc_domingo").Value
                TiendaUrl.tiempo = fila.Cells("fc_hora_do").Value

                CatConfI.TiendasUrl.Add(TiendaUrl)
            Next


        End If

        Return NodosFiltros
    End Function
    Private Function GetStoreListManual(ByVal sbs_no As String, ByRef CheckedList As CheckedListBox) As List(Of NodoConAtributos)
        Dim NodosTiendas As New List(Of NodoConAtributos)

        If CheckedList.Items.Count > 0 Then

            StockConf.tiendas.Clear()
            For i = 0 To CheckedList.Items.Count - 1
                Dim NodoTienda As New NodoConAtributos
                Dim Latributos As New List(Of Campo)

                Dim Tienda As New Tienda
                If CheckedList.GetItemChecked(i) Then 'SI ESTA SELECCIONADO

                    Latributos.Add(New Campo("sbs_no", sbs_no, False))
                    Latributos.Add(New Campo("store_no", CheckedList.Items(i).STORE_NO, False))

                    NodoTienda.Nombre = "Tienda"
                    NodoTienda.Atributos = Latributos

                    NodosTiendas.Add(NodoTienda)

                    Tienda.sbs_no = sbs_no
                    Tienda.store_no = CheckedList.Items(i).STORE_NO
                    StockConf.tiendas.Add(Tienda)
                End If
            Next
        End If

        Return NodosTiendas
    End Function
    Private Function GetMapeoInv(ByRef FilasMapeo As DataGridView) As List(Of NodoConAtributos)
        Dim NodosMapeos As New List(Of NodoConAtributos)

        If FilasMapeo.Rows.Count > 0 Then

            CatConf.Mapeos.Clear()

            For Each fila As DataGridViewRow In FilasMapeo.Rows
                Dim NodoMapeo As New NodoConAtributos
                Dim Latributos As New List(Of Campo)

                Latributos.Add(New Campo("DataLake", fila.Cells("mc_datalake").Value, False))
                Latributos.Add(New Campo("campo_rpro", fila.Cells("mc_campo_rpro").Value, False))


                NodoMapeo.Nombre = "Mapeo"
                NodoMapeo.Atributos = Latributos
                NodosMapeos.Add(NodoMapeo)

                Dim Mapeo As New Mapeo
                Mapeo.ecommerce = fila.Cells("mc_datalake").Value
                Mapeo.campo_rpro = fila.Cells("mc_campo_rpro").Value

                CatConf.Mapeos.Add(Mapeo)
            Next
        End If

        Return NodosMapeos
    End Function


    Private Sub bt_guardarConfInv_Click_1(sender As Object, e As EventArgs) Handles bt_guardarConfInv.Click
        If bt_guardarConfInv.Text.Contains("Guardar") Then

            'config.GuardarAtributo("", "Inventario", "Lunes", StockConf.Lunes, False)
            'config.GuardarAtributo("", "Inventario", "Martes", StockConf.Martes, False)
            'config.GuardarAtributo("", "Inventario", "Miercoles", StockConf.Miercoles, False)
            'config.GuardarAtributo("", "Inventario", "Jueves", StockConf.Jueves, False)
            'config.GuardarAtributo("", "Inventario", "Viernes", StockConf.Viernes, False)
            'config.GuardarAtributo("", "Inventario", "Sabado", StockConf.Sabado, False)
            'config.GuardarAtributo("", "Inventario", "Domingo", StockConf.Domingo, False)
            config.GuardarAtributo("", "Inventario", "Tiempo", txt_tiempo.Text, False)
            config.GuardarAtributo("", "Inventario", "Email", txt_notiMail_Inv.Text, False)

            If dgv_tiendas_tiemposI.Rows.Count > 0 Then
                Dim NodosFiltros As List(Of NodoConAtributos) = GetStoreList(dgv_tiendas_tiemposI)

                config.GuardarNodosConAtributos("", "ConfTiendas", "ProcesTiendas", NodosFiltros)
            Else
                Dim NodosFiltros As New List(Of NodoConAtributos)
                Dim NodoFiltro As New NodoConAtributos
                Dim Latributos As New List(Of Campo)


                Latributos.Add(New Campo("sbs_no", "", False))
                Latributos.Add(New Campo("store_no", "", False))
                Latributos.Add(New Campo("Lunes", "", False))
                Latributos.Add(New Campo("Hora_Lunes", "", False))
                Latributos.Add(New Campo("Martes", "", False))
                Latributos.Add(New Campo("Hora_Martes", "", False))
                Latributos.Add(New Campo("Miercoles", "", False))
                Latributos.Add(New Campo("Hora_Miercoles", "", False))
                Latributos.Add(New Campo("Jueves", "", False))
                Latributos.Add(New Campo("Hora_Jueves", "", False))
                Latributos.Add(New Campo("Viernes", "", False))
                Latributos.Add(New Campo("Hora_Viernes", "", False))
                Latributos.Add(New Campo("Sabado", "", False))
                Latributos.Add(New Campo("Hora_Sabado", "", False))
                Latributos.Add(New Campo("Domingo", "", False))
                Latributos.Add(New Campo("Hora_Domingo", "", False))


                NodoFiltro.Nombre = "Tienda"
                NodoFiltro.Atributos = Latributos
                NodosFiltros.Add(NodoFiltro)

                config.GuardarNodosConAtributos("", "ConfTiendas", "ProcesTiendas", NodosFiltros)


            End If


            'If cb_subsidiariaInv.Items.Count > 0 Then
            '    Dim NodosTiendas As List(Of NodoConAtributos) = GetStoreList(cb_subsidiariaInv.SelectedValue, cb_store_I)

            '    config.GuardarNodosConAtributos("", "Inventario", "Tiendas", NodosTiendas)
            'End If


            cb_subsidiariaInv.Enabled = False
            cb_store_I.Enabled = False

            cb_interfazL.Enabled = False
            cb_interfazM.Enabled = False
            cb_interfazMI.Enabled = False
            cb_interfazJ.Enabled = False
            cb_interfazV.Enabled = False
            cb_interfazS.Enabled = False
            cb_interfazD.Enabled = False
            txt_notiMail_Inv.Enabled = False
            cb_tiempoInv.Enabled = False
            dgv_tiendas_tiemposI.Enabled = False
            bt_agregarTieI.Enabled = False
            txt_tiempo.Enabled = False
            cb_hLun.Enabled = False
            cb_hMar.Enabled = False
            cb_hMi.Enabled = False
            cb_hJue.Enabled = False
            cb_hVie.Enabled = False
            cb_hSa.Enabled = False


            bt_guardarConfInv.Text = "Editar"

            MsgBox("Campos de Configuracion Inventario Guardados con Exito", MsgBoxStyle.Information, "Info")
        ElseIf bt_guardarConfInv.Text.Contains("Editar") Then

            cb_subsidiariaInv.Enabled = True
            cb_store_I.Enabled = True

            cb_interfazL.Enabled = True
            cb_interfazM.Enabled = True
            cb_interfazMI.Enabled = True
            cb_interfazJ.Enabled = True
            cb_interfazV.Enabled = True
            cb_interfazS.Enabled = True
            cb_interfazD.Enabled = True
            txt_notiMail_Inv.Enabled = True
            cb_tiempoInv.Enabled = True
            dgv_tiendas_tiemposI.Enabled = True
            bt_agregarTieI.Enabled = True
            txt_tiempo.Enabled = True

            cb_hLun.Enabled = True
            cb_hMar.Enabled = True
            cb_hMi.Enabled = True
            cb_hJue.Enabled = True
            cb_hVie.Enabled = True
            cb_hSa.Enabled = True

            bt_guardarConfInv.Text = "Guardar"
        End If
    End Sub

    Private Sub bt_agregarTieI_Click_1(sender As Object, e As EventArgs) Handles bt_agregarTieI.Click
        Dim L = ""
        Dim M = ""
        Dim MI = ""
        Dim J = ""
        Dim V = ""
        Dim S = ""
        Dim D = ""



        If cb_interfazL.Text = "Inventario" Then
            L = "C"
        ElseIf cb_interfazL.Text = "Delta" Then
            L = "D"
        ElseIf cb_interfazL.Text = "Precios" Then
            L = "P"
        ElseIf cb_interfazL.Text = "Movimientos" Then
            L = "M"
        End If

        If cb_interfazM.Text = "Inventario" Then
            M = "C"
        ElseIf cb_interfazM.Text = "Delta" Then
            M = "D"
        ElseIf cb_interfazM.Text = "Precios" Then
            M = "P"
        ElseIf cb_interfazM.Text = "Movimientos" Then
            M = "M"
        End If

        If cb_interfazMI.Text = "Inventario" Then
            MI = "C"
        ElseIf cb_interfazMI.Text = "Delta" Then
            MI = "D"
        ElseIf cb_interfazMI.Text = "Precios" Then
            MI = "P"
        ElseIf cb_interfazMI.Text = "Movimientos" Then
            MI = "M"
        End If

        If cb_interfazJ.Text = "Inventario" Then
            J = "C"
        ElseIf cb_interfazJ.Text = "Delta" Then
            J = "D"
        ElseIf cb_interfazJ.Text = "Precios" Then
            J = "P"
        ElseIf cb_interfazJ.Text = "Movimientos" Then
            J = "M"
        End If

        If cb_interfazV.Text = "Inventario" Then
            V = "C"
        ElseIf cb_interfazV.Text = "Delta" Then
            V = "D"
        ElseIf cb_interfazV.Text = "Precios" Then
            V = "P"
        ElseIf cb_interfazV.Text = "Movimientos" Then
            V = "M"
        End If

        If cb_interfazS.Text = "Inventario" Then
            S = "C"
        ElseIf cb_interfazS.Text = "Delta" Then
            S = "D"
        ElseIf cb_interfazS.Text = "Precios" Then
            S = "P"
        ElseIf cb_interfazS.Text = "Movimientos" Then
            S = "M"
        End If

        If cb_interfazD.Text = "Inventario" Then
            D = "C"
        ElseIf cb_interfazD.Text = "Delta" Then
            D = "D"
        ElseIf cb_interfazD.Text = "Precios" Then
            D = "P"
        ElseIf cb_interfazD.Text = "Movimientos" Then
            D = "M"
        End If


        dgv_tiendas_tiemposI.Rows.Add(cb_subsidiariaInv.SelectedValue, cb_store_I.SelectedValue, L, cb_hLun.Text, M, cb_hMar.Text, MI, cb_hMi.Text, J, cb_hJue.Text, V, cb_hVie.Text, S, cb_hSa.Text, D, cb_tiempoInv.Text)

        cb_subsidiariaInv.SelectedIndex = -1
        cb_store_I.SelectedIndex = -1
        cb_tiempoInv.SelectedIndex = -1
        cb_interfazL.SelectedIndex = -1
        cb_interfazM.SelectedIndex = -1
        cb_interfazMI.SelectedIndex = -1
        cb_interfazJ.SelectedIndex = -1
        cb_interfazV.SelectedIndex = -1
        cb_interfazS.SelectedIndex = -1
        cb_interfazD.SelectedIndex = -1
        cb_hLun.SelectedIndex = -1
        cb_hMar.SelectedIndex = -1
        cb_hMi.SelectedIndex = -1
        cb_hJue.SelectedIndex = -1
        cb_hVie.SelectedIndex = -1
        cb_hSa.SelectedIndex = -1

    End Sub

    Private Sub bt_agregarI_Click_1(sender As Object, e As EventArgs) Handles bt_agregarI.Click
        dgv_mapeoInventario.Rows.Add(cb_rpro_campI.SelectedValue, txt_dalake_campI.Text)

        txt_dalake_campI.Text = ""
        cb_rpro_campI.SelectedIndex = -1
    End Sub

    Private Sub bt_GuardarMapI_Click_1(sender As Object, e As EventArgs) Handles bt_GuardarMapI.Click
        If bt_GuardarMapI.Text.Contains("Guardar") Then

            If dgv_mapeoInventario.Rows.Count > 0 Then
                Dim NodosMapeos As List(Of NodoConAtributos) = GetMapeoInv(dgv_mapeoInventario)

                config.GuardarNodosConAtributos("", "Inventario", "MapeoInventario", NodosMapeos)
            End If


            dgv_mapeoInventario.Enabled = False
            bt_agregarI.Enabled = False
            cb_rpro_campI.Enabled = False
            txt_dalake_campI.Enabled = False
            bt_GuardarMapI.Text = "Editar"

            MsgBox("Campos de Mapeo Catalogo Guardados con Exito", MsgBoxStyle.Information, "Info")
        ElseIf bt_GuardarMapI.Text.Contains("Editar") Then


            dgv_mapeoInventario.Enabled = True
            bt_agregarI.Enabled = True
            cb_rpro_campI.Enabled = True
            txt_dalake_campI.Enabled = True
            bt_GuardarMapI.Text = "Guardar"

        End If
    End Sub

    Private Sub dgv_mapeoInventario_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_mapeoInventario.KeyDown
        Dim li2_index As Integer
        If dgv_mapeoInventario.Rows.Count() >= 1 Then

            If e.KeyCode = Keys.Delete Then

                e.Handled = True

                li2_index = CType(sender, DataGridView).CurrentRow.Index

                dgv_mapeoInventario.Rows.RemoveAt(li2_index)

            End If
        End If
    End Sub

    Private Sub bt_GuardarCredI_Click(sender As Object, e As EventArgs) Handles bt_GuardarCredI.Click
        If bt_GuardarCredI.Text.Contains("Guardar") Then

            'MySQL
            config.GuardarAtributo("", "EndpointInv", "Url", txt_urlInv.Text, False)
            config.GuardarAtributo("", "EndpointInv", "Token", txt_tokenI.Text, False)




            'Actualizar Variables
            CredEndI.url = txt_urlInv.Text
            CredEndI.token = txt_tokenI.Text


            txt_urlInv.Enabled = False
            txt_tokenI.Enabled = False



            MsgBox("Credenciales Guardadas con Exito", MsgBoxStyle.Information, "Info")
            bt_GuardarCredI.Text = "Editar"
        ElseIf bt_GuardarCredI.Text.Contains("Editar") Then

            txt_urlInv.Enabled = True
            txt_tokenI.Enabled = True



            bt_GuardarCredI.Text = "Guardar"

        End If
    End Sub

    Private Sub B_AgregarFiltroCat_Click(sender As Object, e As EventArgs) Handles B_AgregarFiltroCat.Click
        DGV_FiltrosCatalogo.Rows.Add(cb_operadorCat.Text, cb_rpro_Cat.SelectedValue, cb_codicionCat.Text, txt_val_filt.Text)

        txt_val_filt.Text = ""
        cb_operadorCat.SelectedIndex = -1
        cb_rpro_Cat.SelectedIndex = -1
        cb_codicionCat.SelectedIndex = -1
    End Sub

    Private Sub DGV_FiltrosCatalogo_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_FiltrosCatalogo.KeyDown
        If e.KeyCode = Keys.Delete Then
            If DGV_FiltrosCatalogo.SelectedRows.Count > 0 Then
                Dim index As Integer = DGV_FiltrosCatalogo.SelectedRows(0).Index
                DGV_FiltrosCatalogo.Rows.RemoveAt(index)
            End If

            'e.Handled = True
        End If
    End Sub
    Private Function GetStoreListM(ByVal sbs_no As String, ByRef CheckedList As CheckedListBox) As List(Of NodoConAtributos)
        Dim NodosTiendas As New List(Of NodoConAtributos)

        If CheckedList.Items.Count > 0 Then

            StockConf.tiendas.Clear()
            For i = 0 To CheckedList.Items.Count - 1
                Dim NodoTienda As New NodoConAtributos
                Dim Latributos As New List(Of Campo)

                Dim Tienda As New Tienda
                If CheckedList.GetItemChecked(i) Then 'SI ESTA SELECCIONADO

                    Latributos.Add(New Campo("sbs_no", sbs_no, False))
                    Latributos.Add(New Campo("store_no", CheckedList.Items(i).STORE_NO, False))

                    NodoTienda.Nombre = "Tienda"
                    NodoTienda.Atributos = Latributos

                    NodosTiendas.Add(NodoTienda)

                    Tienda.sbs_no = sbs_no
                    Tienda.store_no = CheckedList.Items(i).STORE_NO
                    StockConf.tiendas.Add(Tienda)
                End If
            Next
        End If

        Return NodosTiendas
    End Function
    Private Function GetStoreListD(ByVal sbs_no As String, ByRef CheckedList As CheckedListBox) As List(Of NodoConAtributos)
        Dim NodosTiendas As New List(Of NodoConAtributos)

        If CheckedList.Items.Count > 0 Then

            ConfD.tiendasD.Clear()
            For i = 0 To CheckedList.Items.Count - 1
                Dim NodoTienda As New NodoConAtributos
                Dim Latributos As New List(Of Campo)

                Dim Tienda As New TiendaD
                If CheckedList.GetItemChecked(i) Then 'SI ESTA SELECCIONADO

                    Latributos.Add(New Campo("sbs_no", sbs_no, False))
                    Latributos.Add(New Campo("store_no", CheckedList.Items(i).STORE_NO, False))

                    NodoTienda.Nombre = "Tienda"
                    NodoTienda.Atributos = Latributos

                    NodosTiendas.Add(NodoTienda)

                    Tienda.sbs_no = sbs_no
                    Tienda.store_no = CheckedList.Items(i).STORE_NO
                    ConfD.tiendasD.Add(Tienda)
                End If
            Next
        End If

        Return NodosTiendas
    End Function
    Private Sub B_SetConfCat_Filter_Click(sender As Object, e As EventArgs) Handles B_SetConfCat_Filter.Click
        If B_SetConfCat_Filter.Text.Contains("Guardar") Then
            config.GuardarAtributo("Inventario.Filtros", "Activar", CatConf.activar_filtros, False)

            If cb_sbs_noM.Items.Count > 0 Then
                Dim NodosTiendas As List(Of NodoConAtributos) = GetStoreListM(cb_sbs_noM.SelectedValue, cb_list_storesM)

                config.GuardarNodosConAtributos("", "Inventario", "Tiendas", NodosTiendas)
            End If
            If DGV_FiltrosCatalogo.Rows.Count > 0 Then
                Dim NodosFiltros As List(Of NodoConAtributos) = GetFilterCat(DGV_FiltrosCatalogo)

                config.GuardarNodosConAtributos("", "Inventario", "Filtros", NodosFiltros)
            Else
                Dim NodosFiltros As New List(Of NodoConAtributos)
                Dim NodoFiltro As New NodoConAtributos
                Dim Latributos As New List(Of Campo)

                Latributos.Add(New Campo("operador", "", False))
                Latributos.Add(New Campo("campo_rpro", "", False))
                Latributos.Add(New Campo("condicion", "", False))
                Latributos.Add(New Campo("valor", "", False))


                NodoFiltro.Nombre = "Filtro"
                NodoFiltro.Atributos = Latributos
                NodosFiltros.Add(NodoFiltro)

                config.GuardarNodosConAtributos("", "Inventario", "Filtros", NodosFiltros)
                'Dim Filtro As New Filtro
                'Filtro.operador = ""
                'Filtro.campo_rpro = ""
                'Filtro.condicion = ""
                'Filtro.valor = ""
                'CatConf.filtros.Add(Filtro)

            End If

            GB_FilterI.Enabled = False
            B_SetConfCat_Filter.Text = "Editar"

            MsgBox("Campos de Filtros Guardados con Exito", MsgBoxStyle.Information, "Info")
        ElseIf B_SetConfCat_Filter.Text.Contains("Editar") Then
            GB_FilterI.Enabled = True
            B_SetConfCat_Filter.Text = "Guardar"
        End If
    End Sub
    Private Function GetFilterCat(ByRef FilasFiltro As DataGridView) As List(Of NodoConAtributos)
        Dim NodosFiltros As New List(Of NodoConAtributos)

        If FilasFiltro.Rows.Count > 0 Then

            CatConf.filtros.Clear()

            For Each fila As DataGridViewRow In FilasFiltro.Rows
                Dim NodoFiltro As New NodoConAtributos
                Dim Latributos As New List(Of Campo)

                Latributos.Add(New Campo("operador", fila.Cells("fc_operador").Value, False))
                Latributos.Add(New Campo("campo_rpro", fila.Cells("fc_campo_rpro").Value, False))
                Latributos.Add(New Campo("condicion", fila.Cells("fc_condicion").Value, False))
                Latributos.Add(New Campo("valor", fila.Cells("fc_valor").Value, False))


                NodoFiltro.Nombre = "Filtro"
                NodoFiltro.Atributos = Latributos
                NodosFiltros.Add(NodoFiltro)

                Dim Filtro As New Filtro
                Filtro.operador = fila.Cells("fc_operador").Value
                Filtro.campo_rpro = fila.Cells("fc_campo_rpro").Value
                Filtro.condicion = fila.Cells("fc_condicion").Value
                Filtro.valor = fila.Cells("fc_valor").Value
                CatConf.filtros.Add(Filtro)
            Next


        End If

        Return NodosFiltros
    End Function
    Private Function GetFilterCatD(ByRef FilasFiltro As DataGridView) As List(Of NodoConAtributos)
        Dim NodosFiltros As New List(Of NodoConAtributos)

        If FilasFiltro.Rows.Count > 0 Then

            ConfD.filtros.Clear()

            For Each fila As DataGridViewRow In FilasFiltro.Rows
                Dim NodoFiltro As New NodoConAtributos
                Dim Latributos As New List(Of Campo)

                Latributos.Add(New Campo("operador", fila.Cells("fc_operadorD").Value, False))
                Latributos.Add(New Campo("campo_rpro", fila.Cells("fc_campo_rproD").Value, False))
                Latributos.Add(New Campo("condicion", fila.Cells("fc_condicionD").Value, False))
                Latributos.Add(New Campo("valor", fila.Cells("fc_valorD").Value, False))


                NodoFiltro.Nombre = "Filtro"
                NodoFiltro.Atributos = Latributos
                NodosFiltros.Add(NodoFiltro)

                Dim Filtro As New Filtro
                Filtro.operador = fila.Cells("fc_operadorD").Value
                Filtro.campo_rpro = fila.Cells("fc_campo_rproD").Value
                Filtro.condicion = fila.Cells("fc_condicionD").Value
                Filtro.valor = fila.Cells("fc_valorD").Value
                ConfD.filtros.Add(Filtro)
            Next


        End If

        Return NodosFiltros
    End Function
    Private Sub LlenarFiltros(ByRef Filtros As List(Of Filtro), ByVal NFiltros As List(Of NodoConAtributos))
        If NFiltros.Count > 0 Then
            Filtros.Clear()

            For Each Nfiltro As NodoConAtributos In NFiltros
                Dim filtro As New Filtro
                filtro.operador = Nfiltro.Atributos.Find(Function(t) t.Nombre = "operador").Valor
                filtro.campo_rpro = Nfiltro.Atributos.Find(Function(t) t.Nombre = "campo_rpro").Valor
                filtro.condicion = Nfiltro.Atributos.Find(Function(t) t.Nombre = "condicion").Valor
                filtro.valor = Nfiltro.Atributos.Find(Function(t) t.Nombre = "valor").Valor

                Filtros.Add(filtro)
            Next
        End If
    End Sub
    Private Sub LlenarVariablesCatFilter()
        Dim str_activar As String = config.LeerAtributo("", "Inventario", "Filtros", "Activar", False)

        CatConf.activar_filtros = IIf(str_activar.ToUpper = "TRUE" Or str_activar.ToUpper = "FALSE", str_activar, False)

        Dim NodosFiltros As New List(Of NodoConAtributos)
        NodosFiltros = config.LeerNodosConAtributos("", "Inventario", "Filtros", "Filtro")
        LlenarFiltros(CatConf.filtros, NodosFiltros)
    End Sub

    '*********************************
    Private Sub LlenarFiltrosD(ByRef Filtros As List(Of Filtro), ByVal NFiltros As List(Of NodoConAtributos))
        If NFiltros.Count > 0 Then
            Filtros.Clear()

            For Each Nfiltro As NodoConAtributos In NFiltros
                Dim filtro As New Filtro
                filtro.operador = Nfiltro.Atributos.Find(Function(t) t.Nombre = "operador").Valor
                filtro.campo_rpro = Nfiltro.Atributos.Find(Function(t) t.Nombre = "campo_rpro").Valor
                filtro.condicion = Nfiltro.Atributos.Find(Function(t) t.Nombre = "condicion").Valor
                filtro.valor = Nfiltro.Atributos.Find(Function(t) t.Nombre = "valor").Valor

                Filtros.Add(filtro)
            Next
        End If
    End Sub
    Private Sub LlenarVariablesCatFilterD()
        Dim str_activar As String = config.LeerAtributo("", "InventarioDeltam", "Filtros", "Activar", False)

        ConfD.activar_filtros = IIf(str_activar.ToUpper = "TRUE" Or str_activar.ToUpper = "FALSE", str_activar, False)

        Dim NodosFiltros As New List(Of NodoConAtributos)
        NodosFiltros = config.LeerNodosConAtributos("", "InventarioDeltam", "Filtros", "Filtro")
        LlenarFiltrosD(ConfD.filtros, NodosFiltros)
    End Sub

    Private Sub txt_previaInv_Click(sender As Object, e As EventArgs) Handles txt_previaInv.Click
        If archivo_config = True Then


            Dim Query As String = ""
            Dim QSelec As String
            Dim QueryCamp As String = ""
            Dim QueryFrom As String
            Dim QueryWhere As String = ""
            Dim QueryGroup As String = "GROUP BY "

            QSelec = "SELECT A.* FROM ( SELECT "

            Dim Store_no = ""

            Sbs_no = cb_sbs_noM.SelectedValue
            If cb_sbs_noM.Items.Count > 0 Then
                'Dim NodosTiendas As List(Of NodoConAtributos) = GetStoreListManual(cb_sbs_noM.SelectedValue, cb_list_storesM)
                Dim str_tiendas As String = ""
                For Each item As TX_STORE_V In cb_list_storesM.CheckedItems
                    str_tiendas = str_tiendas + item.STORE_NO.ToString + ","
                Next
                str_tiendas = str_tiendas.Remove(str_tiendas.Length - 1) + ") "
                Store_no = str_tiendas
            End If

            Dim StringFiltros As String = ""

            If CatConf.filtros.Count > 0 Then

                For Each filtro As Filtro In CatConf.filtros
                    StringFiltros += filtro.operador + " "
                    'StringFiltros = StringFiltros + filtro.operador + " "

                    If filtro.campo_rpro = "D" Then
                        StringFiltros = StringFiltros + "SUBSTR(DCS_CODE,0,3)"
                    ElseIf filtro.campo_rpro = "C" Then
                        StringFiltros = StringFiltros + "SUBSTR(DCS_CODE,4,3)"
                    ElseIf filtro.campo_rpro = "S" Then
                        StringFiltros = StringFiltros + "SUBSTR(DCS_CODE,7,3)"
                    ElseIf filtro.condicion = "IN" Then
                        StringFiltros += filtro.campo_rpro + " " + " IN (" + filtro.valor + ") "

                    Else


                        StringFiltros += filtro.campo_rpro + " " + filtro.condicion + "'" + filtro.valor + "' "
                    End If


                Next
            End If

            If CatConf.Mapeos.Count > 0 Then

                QueryCamp += String.Join(",", CatConf.Mapeos.Select(Function(t) t.campo_rpro + " " + t.ecommerce + " ").ToList)

                If CatConf.Mapeos.Exists(Function(m) m.campo_rpro.Substring(0, 3) = "SUM") Then
                    QueryGroup += String.Join(",", CatConf.Mapeos.Where(Function(g) g.campo_rpro.Substring(0, 3) <> "SUM").Select(Function(t) t.campo_rpro).ToList)
                Else
                    QueryGroup += String.Join(",", CatConf.Mapeos.Select(Function(t) t.campo_rpro).ToList)
                End If
                QueryFrom = "from rps.invn_sbs_item i inner join rps.subsidiary sb on (i.sbs_sid=sb.sid) " +
                             "inner join rps.store s on (sb.sid=s.sbs_sid) " +
                             "inner join v_sociedades sc on (sb.sbs_no=sc.sbs_no) " +
                             "inner join v_centros_almacen cc on (sb.sbs_no=cc.sbs_no and s.store_code=cc.store_code) " +
                             "left join rps.invn_sbs_item_qty q on (i.sid=q.invn_sbs_item_sid and i.sbs_sid=q.sbs_sid and s.sid=q.store_sid) " +
                              ""



                If CatConf.activar_filtros Then

                    'QueryWhere = "WHERE 1=1 AND P.PRICE_LVL=" + Lvl_price + "  AND SB.SBS_NO=" + Sbs_no + " " + StringFiltros '" AND S.STORE_NO IN (" + Store_no + "  " + StringFiltros
                    QueryWhere = "where nvl(q.qty,0)>=0 AND SB.SBS_NO=" + Sbs_no.ToString() + " " + StringFiltros + " AND S.STORE_NO IN (" + Store_no
                Else
                    QueryWhere = "where nvl(q.qty,0)>=0 AND SB.SBS_NO=" + Sbs_no + " AND S.STORE_NO IN (" + Store_no
                End If

                Query = QSelec + QueryCamp + QueryFrom + QueryWhere + QueryGroup + " ) A"

                'Query = QSelec + QueryCamp + QueryFrom + QueryWhere + QueryGroup + " ) A"
                config.mylog("Panel Config", "Mensaje", "QUERY " + Query, True)


                ora.Conexion = "DATA SOURCE=" & Credenciales.ip & ":" & Credenciales.puerto & "/" & Credenciales.db & ";PASSWORD=" & Credenciales.password & ";PERSIST SECURITY INFO=True;USER ID=" & Credenciales.usuario

                If ora.Conectar.status Then
                    'EJECUTAMOS LA QUERY DE CATALOGO
                    Dim conn As New OracleConnection(ora.Conexion)

                    conn.Open()

                    'Dim sql As String = "select dname from dept where deptno = 10" ' VB.NET
                    Dim cmd As New OracleCommand(Query, conn)
                    cmd.CommandType = CommandType.Text
                    Dim dr As OracleDataReader = cmd.ExecuteReader()
                    Dim DataS As New DataSet
                    If dr.Read() Then
                        Dim da = New OracleDataAdapter(cmd)
                        da.Fill(DataS, "A")
                        dg_PreviaInv.DataSource = DataS.Tables("A")

                    End If
                    'HabilitaPlantillaCatalogo()


                Else
                    'HabilitaPlantillaCatalogo()
                    MsgBox(ora.Conectar.message, MsgBoxStyle.Critical, "Error - Conexion")
                End If

            End If

        Else
            MsgBox("Mapeo de campos no Encontrado", MsgBoxStyle.Critical, "Error - Archivo de Configuracion")
        End If
    End Sub

    Private Sub cb_subsidiariaInv_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_subsidiariaInv.SelectedValueChanged
        If num2 <> 0 Then
            If cb_subsidiariaInv.SelectedValue Is Nothing Then

            Else
                Dim RspStoreSel As New ResponseCRpro9
                RspStoreSel = ora.ListarStores(Short.Parse(cb_subsidiariaInv.SelectedValue), "oracle_10")
                If RspStoreSel.status Then

                    cb_store_I.DataSource = RspStoreSel.result
                    cb_store_I.DisplayMember = "DISPLAY"
                    cb_store_I.ValueMember = "STORE_NO"

                End If
            End If



        End If

        num2 = num2 + 1
    End Sub

    Private Sub CHB_ActivarFiltrosCat_CheckedChanged(sender As Object, e As EventArgs) Handles CHB_ActivarFiltrosCat.CheckedChanged
        If CHB_ActivarFiltrosCat.Checked Then
            CatConf.activar_filtros = True
        Else
            CatConf.activar_filtros = False
        End If
    End Sub

    Private Sub cb_sbs_noM_SelectedValueChanged(sender As Object, e As EventArgs) Handles cb_sbs_noM.SelectedValueChanged
        If num1 > 1 Then
            If cb_sbs_noM.SelectedValue Is Nothing Then

            Else
                Dim RspStoreSel As New ResponseCRpro9
                RspStoreSel = ora.ListarStores(Short.Parse(cb_sbs_noM.SelectedValue), "oracle_10")
                If RspStoreSel.status Then

                    cb_list_storesM.DataSource = RspStoreSel.result
                    cb_list_storesM.DisplayMember = "DISPLAY"
                    cb_list_storesM.ValueMember = "STORE_NO"

                End If
            End If



        End If

        num1 = num1 + 1
    End Sub

    Private Sub bt_ejecturarInv_Click(sender As Object, e As EventArgs) Handles bt_ejecturarInv.Click

        Dim ListaItem As New List(Of ElementItems)
        Dim json = "{""stocks"" " + ": ["
        Dim jsonCont = "},"
        Dim jsonFin = "}]}"
        Dim cont = 0
        Dim contF = 0
        For Each row As DataGridViewRow In dg_PreviaInv.Rows

            Dim item = New ElementItems()

            item.sku = Convert.ToString(row.Cells("SKU").Value)
            item.id_sociedad = Convert.ToString(row.Cells("ID_SOCIEDAD").Value)
            item.id_centro = Convert.ToString(row.Cells("ID_CENTRO").Value)
            item.id_almacen = Convert.ToString(row.Cells("ID_ALMACEN").Value)
            item.qty = Convert.ToString(row.Cells("QTY").Value)

            ListaItem.Add(item)
        Next
        Try
            Dim request As WebRequest
            request = DirectCast(WebRequest.Create(CredEndI.url), HttpWebRequest)
            request.Method = "POST"
            request.ContentType = "application/json; charset=utf-8"
            request.Headers.Add("Authorization", "Bearer " + CredEndI.token)

            config.mylog("Panel Config", "Mensaje", "url inventario " + CredEndI.url, True)

            If ListaItem.Count > 0 Then

                Dim lista_Art = ListaItem.GroupBy(Function(i) i.sku).Select(Function(s) s.First).ToList

                For Each it In lista_Art
                    cont = cont + 1
                    json = json + " {" +
                       " ""sku"" " + " : """ + Convert.ToString(it.sku) + """," +
                        " ""id_sociedad"" " + " : " + Convert.ToString(it.id_sociedad) + "," +
                         " ""id_centro"" " + " : " + Convert.ToString(it.id_centro) + "," +
                           " ""id_almacen"" " + " : """ + Convert.ToString(it.id_almacen) + """," +
                            " ""qty"" " + " : """ + Convert.ToString(it.qty) + """"

                    'config.mylog("Panel Config", "Mensaje", "numero contador " + cont.ToString() + " numero filas del grid " + dg_PreviaInv.Rows.Count.ToString(), True)
                    If cont = dg_PreviaInv.Rows.Count Then
                        json = json + jsonFin
                    Else
                        json = json + jsonCont
                    End If
                Next

                config.mylog("Panel Config", "Mensaje", "JSON " + json, True)

                Using streamWriter = New StreamWriter(request.GetRequestStream())


                    config.mylog("Panel Config", "Mensaje", "StreamWriter ", True)

                    streamWriter.Write(json)
                    streamWriter.Flush()
                    streamWriter.Close()

                End Using

                Using httpResponse As HttpWebResponse = DirectCast(request.GetResponse(), HttpWebResponse)

                    Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                        Dim responseBody = streamReader.ReadToEnd()
                        'config.mylog("Panel Config", "responseBody", responseBody, True)
                        If responseBody.Contains("Processing stocks") Then

                            For Each artic In lista_Art
                                Dim dato As New DLK_CONTROL()
                                Dim resultado = New ResponseCRpro9()

                                dato.ARTICULO_SAP = artic.sku
                                dato.ID_SOCIEDAD = artic.id_sociedad
                                dato.ID_CENTRO = artic.id_centro
                                dato.ID_ALMACEN = artic.id_almacen
                                dato.QTY = artic.qty

                                resultado = ora.GuardarArticulo(dato)
                                If resultado.status Then
                                    'config.mylog("Panel Config", "Mensaje", "Registro ingresado en la tabla de control ", True)
                                Else
                                    config.mylog("Panel Config", "Error DB ORACLE", resultado.message, True)
                                End If
                                contF = contF + 1
                                If contF = cont Then
                                    MsgBox("Termina proceso de actualizacion de stock", MsgBoxStyle.Information, "Info")
                                End If
                            Next
                        Else
                            config.mylog("Panel Config", "Error ", responseBody, True)
                        End If

                    End Using

                End Using
                json = ""
            Else
                MsgBox("No Hay Items para Procesar", MsgBoxStyle.Exclamation, "Error")
                config.mylog("Panel Config", "Error", "No Hay Items para Procesar", True)
            End If

        Catch ex As WebException
            config.mylog("Panel Config", "WebException", ex.Message, True)
        Catch ex As Exception
            config.mylog("Panel Config", "Exception", ex.Message, True)
        End Try

    End Sub

    Private Sub bt_agregarFiltrosD_Click(sender As Object, e As EventArgs) Handles bt_agregarFiltrosD.Click
        gv_filtrosD.Rows.Add(cb_operadorD.Text, cb_rproD.SelectedValue, cb_condicionD.Text, txt_valD.Text)

        txt_valD.Text = ""
        cb_operadorD.SelectedIndex = -1
        cb_rproD.SelectedIndex = -1
        cb_condicionD.SelectedIndex = -1
    End Sub

    Private Sub B_SetConfCat_FilterD_Click(sender As Object, e As EventArgs) Handles B_SetConfCat_FilterD.Click
        If B_SetConfCat_FilterD.Text.Contains("Guardar") Then
            config.GuardarAtributo("InventarioDeltam.Filtros", "Activar", ConfD.activar_filtros, False)

            If cb_sbs_noD.Items.Count > 0 Then
                Dim NodosTiendas As List(Of NodoConAtributos) = GetStoreListD(cb_sbs_noD.SelectedValue, cb_list_storesD)

                config.GuardarNodosConAtributos("", "InventarioDeltam", "Tiendas", NodosTiendas)
            End If
            If gv_filtrosD.Rows.Count > 0 Then
                Dim NodosFiltros As List(Of NodoConAtributos) = GetFilterCatD(gv_filtrosD)

                config.GuardarNodosConAtributos("", "InventarioDeltam", "Filtros", NodosFiltros)
            Else
                Dim NodosFiltros As New List(Of NodoConAtributos)
                Dim NodoFiltro As New NodoConAtributos
                Dim Latributos As New List(Of Campo)

                Latributos.Add(New Campo("operador", "", False))
                Latributos.Add(New Campo("campo_rpro", "", False))
                Latributos.Add(New Campo("condicion", "", False))
                Latributos.Add(New Campo("valor", "", False))


                NodoFiltro.Nombre = "Filtro"
                NodoFiltro.Atributos = Latributos
                NodosFiltros.Add(NodoFiltro)

                config.GuardarNodosConAtributos("", "InventarioDeltam", "Filtros", NodosFiltros)


            End If

            GP_FilterD.Enabled = False
            B_SetConfCat_FilterD.Text = "Editar"

            MsgBox("Campos de Filtros Guardados con Exito", MsgBoxStyle.Information, "Info")
        ElseIf B_SetConfCat_FilterD.Text.Contains("Editar") Then
            GP_FilterD.Enabled = True
            B_SetConfCat_FilterD.Text = "Guardar"
        End If
    End Sub

    Private Sub ch_activalFiltrosD_CheckedChanged(sender As Object, e As EventArgs) Handles ch_activalFiltrosD.CheckedChanged
        If ch_activalFiltrosD.Checked Then
            ConfD.activar_filtros = True
        Else
            ConfD.activar_filtros = False
        End If
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_hVie.SelectedIndexChanged

    End Sub
End Class
