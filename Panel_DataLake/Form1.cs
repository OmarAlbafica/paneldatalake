using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;
using CRpro9;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Panel_DataLake
{
    public partial class Form1
    {
        private CConfig config = new CConfig();
        private Funciones ora = new Funciones();
        private bool archivo_config;
        private Credenciales Credenciales = new Credenciales();
        private ConfStock StockConf = new ConfStock();
        private ConfDelta ConfD = new ConfDelta();
        private ConfCat CatConf = new ConfCat();
        private ConfUrlTiendas CatConfI = new ConfUrlTiendas();
        private CredenEndPrecios CredEndPrecios = new CredenEndPrecios();
        private CredenEndInv CredEndI = new CredenEndInv();
        CredenEndMovimientos CredEndMov = new CredenEndMovimientos();
        private ListasCB ListasCB = new ListasCB();
        private object Sbs_no = "";
        private object Sbs_noM = "";
        private object Sbs_noD = "";
        private string FiltRpro;
        private object num2 = 0;
        private object num1 = 0;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Form1"/>.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (archivo_config == true)
            {
                // +++++++++ Credenciales BaseDatos ++++++++++
                txt_host_db.Text = Credenciales.ip;
                txt_port_db.Text = Credenciales.puerto;
                txt_user_db.Text = Credenciales.usuario;
                txt_pass_db.Text = Credenciales.password;
                txt_db_name.Text = Credenciales.db;
                cb_db_con.SelectedValue = Credenciales.plataforma;

                txt_host_db.Enabled = false;
                txt_port_db.Enabled = false;
                txt_user_db.Enabled = false;
                txt_pass_db.Enabled = false;
                txt_db_name.Enabled = false;
                cb_db_con.Enabled = false;

                // +++++++++ Configuraciones Inventario ++++++++++
                CHB_ActivarFiltrosCat.Checked = CatConf.activar_filtros;
                ch_activalFiltrosD.Checked = ConfD.activar_filtros;
                if (CatConf.Mapeos.Count > 0)
                {
                    foreach (Mapeo mapeo in CatConf.Mapeos)
                        dgv_mapeoInventario.Rows.Add(mapeo.campo_rpro, mapeo.ecommerce, mapeo.tipo);
                }

                if (CatConf.filtros.Count > 0)
                {
                    foreach (Filtro filtro in CatConf.filtros)
                        DGV_FiltrosCatalogo.Rows.Add(filtro.operador, filtro.campo_rpro, filtro.condicion, filtro.valor);
                }

                if (ConfD.filtros.Count > 0)
                {
                    foreach (Filtro filtro in ConfD.filtros)
                        gv_filtrosD.Rows.Add(filtro.operador, filtro.campo_rpro, filtro.condicion, filtro.valor);
                }
                dgv_mapeoInventario.Enabled = false;
                bt_agregarI.Enabled = false;
                cb_rpro_campI.Enabled = false;
                txt_dalake_campI.Enabled = false;
                cb_mapeo_tipo.Enabled = false;

                // cb_tiempoInv.SelectedItem = StockConf.tiempo
                // cb_hLun.SelectedItem = StockConf.Lu_tiempo
                // cb_hMar.SelectedItem = StockConf.Mar_tiempo
                // cb_hMi.SelectedItem = StockConf.Mar_tiempo
                // cb_hJue.SelectedItem = StockConf.Ju_tiempo
                // cb_hVie.SelectedItem = StockConf.Vi_tiempo
                // cb_hSa.SelectedItem = StockConf.Sa_tiempo
                txt_notiMail_Inv.Text = StockConf.Mail;
                txt_tiempo.Text = StockConf.TiempoEjec;
                cb_subsidiariaInv.Enabled = false;
                cb_store_I.Enabled = false;

                cb_interfazL.Enabled = false;
                cb_interfazM.Enabled = false;
                cb_interfazMI.Enabled = false;
                cb_interfazJ.Enabled = false;
                cb_interfazV.Enabled = false;
                cb_interfazS.Enabled = false;
                cb_interfazD.Enabled = false;
                txt_notiMail_Inv.Enabled = false;
                cb_tiempoInv.Enabled = false;
                cb_hLun.Enabled = false;
                cb_hMar.Enabled = false;
                cb_hMi.Enabled = false;
                cb_hJue.Enabled = false;
                cb_hVie.Enabled = false;
                cb_hSa.Enabled = false;
                dgv_tiendas_tiemposI.Enabled = false;
                bt_agregarTieI.Enabled = false;
                txt_tiempo.Enabled = false;

                // actualizacion variables Endpoint Inventario
                txt_urlInv.Text = CredEndI.url;
                txt_tokenI.Text = CredEndI.token;

                txt_urlPrecios.Text = CredEndPrecios.url;
                txt_tokenPrecios.Text = CredEndPrecios.token;

                txt_urlMov.Text = CredEndMov.url;
                txt_tokenMov.Text = CredEndMov.token;

                cb_rpro_Cat.SelectedItem = FiltRpro;
                GB_FilterI.Enabled = false;
                GP_FilterD.Enabled = false;
                txt_urlInv.Enabled = false;
                txt_tokenI.Enabled = false;
                bt_guardarConfInv.Text = "Editar";
                bt_guardar_db.Text = "Editar";
                bt_GuardarMapI.Text = "Editar";
                bt_GuardarCredI.Text = "Editar";
                B_SetConfCat_Filter.Text = "Editar";
                B_SetConfCat_FilterD.Text = "Editar";
                txtSmtpServer.Enabled = false;
                txtPort.Enabled = false;
                txtUsername.Enabled = false;
                txtRecipientEmails.Enabled = false;
                btnSaveEmailConfig.Text = "Editar";
                txt_urlPrecios.Enabled = false;
                txt_tokenPrecios.Enabled = false;

                // Cambiar el texto del botón a "Editar"
                bt_GuardarPrecios.Text = "Editar";

                txt_urlMov.Enabled = false;
                txt_tokenMov.Enabled = false;

                // Cambiar el texto del botón a "Editar"
                bt_GuardarMov.Text = "Editar";



                if (CatConfI.TiendasUrl.Count > 0)
                {
                    foreach (TiendaUrl tienda in CatConfI.TiendasUrl)
                        dgv_tiendas_tiemposI.Rows.Add(tienda.sbs_no, tienda.store_no, tienda.Lunes, tienda.Lu_tiempo, tienda.Martes, tienda.Mar_tiempo, tienda.Miercoles, tienda.Mie_tiempo, tienda.Jueves, tienda.Ju_tiempo, tienda.Viernes, tienda.Vi_tiempo, tienda.Sabado, tienda.Sa_tiempo, tienda.Domingo, tienda.tiempo);
                }

                // If StockConf.tiendas.Count > 0 Then
                // For Each tienda As Tienda In StockConf.tiendas

                // For i = 0 To cb_list_storesM.Items.Count - 1
                // Dim num_tienda

                // num_tienda = Convert.ToInt32(cb_list_storesM.GetItemText(cb_list_storesM.Items(i)).ToString.Substring(0, 3))

                // If tienda.store_no = num_tienda Then
                // cb_list_storesM.SetItemChecked(i, True)
                // End If
                // Next

                // Next
                // End If

                if (ConfD.tiendasD.Count > 0)
                {
                    foreach (TiendaD tienda in ConfD.tiendasD)
                    {

                        for (int i = 0, loopTo = cb_list_storesD.Items.Count - 1; i <= loopTo; i++)
                        {
                            object num_tienda;

                            num_tienda = Convert.ToInt32(cb_list_storesD.GetItemText(cb_list_storesD.Items[i]).ToString().Substring(0, 3));

                            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectEqual(tienda.store_no, num_tienda, false)))
                            {
                                cb_list_storesD.SetItemChecked(i, true);
                            }
                        }

                    }
                }
                // llenado de compo campos rpro

                var dt = new DataTable("Tabla");

                dt.Columns.Add("Codigo");
                dt.Columns.Add("Descripcion");

                DataRow dr;



                dr = dt.NewRow();
                dr["Codigo"] = "IP.PRICE";
                dr["Descripcion"] = "PRICE";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "TRIM('')";
                dr["Descripcion"] = "VACIO";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "TRIM(I.ALU)";
                dr["Descripcion"] = "ALU";
                dt.Rows.Add(dr);


                dr = dt.NewRow();
                dr["Codigo"] = "I.ACTIVE";
                dr["Descripcion"] = "ACTIVE";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.UPC";
                dr["Descripcion"] = "UPC";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "D.DCS_CODE";
                dr["Descripcion"] = "DCS_CODE";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "SUBSTR(D.DCS_CODE,0,3)";
                dr["Descripcion"] = "D";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "D.D_NAME";
                dr["Descripcion"] = "D_NAME";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "SUBSTR(D.DCS_CODE,4,3)";
                dr["Descripcion"] = "C";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "D.C_NAME";
                dr["Descripcion"] = "C_NAME";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "SUBSTR(D.DCS_CODE,7,3)";
                dr["Descripcion"] = "S";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "D.S_NAME";
                dr["Descripcion"] = "S_NAME";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.DESCRIPTION1";
                dr["Descripcion"] = "DESCRIPTION1";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.DESCRIPTION2";
                dr["Descripcion"] = "DESCRIPTION2";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.DESCRIPTION3";
                dr["Descripcion"] = "DESCRIPTION3";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.DESCRIPTION4";
                dr["Descripcion"] = "DESCRIPTION4";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "SUM(Q.QTY)";
                dr["Descripcion"] = "QTY(suma)";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "NVL(Q.QTY,0)";
                dr["Descripcion"] = "QTY";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.UDF1_STRING";
                dr["Descripcion"] = "UDF1_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.UDF2_STRING";
                dr["Descripcion"] = "UDF_2";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.UDF3_STRING";
                dr["Descripcion"] = "UDF3_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.UDF4_STRING";
                dr["Descripcion"] = "UDF4_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.UDF5_STRING";
                dr["Descripcion"] = "UDF5_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF6_STRING";
                dr["Descripcion"] = "UDF6_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF7_STRING";
                dr["Descripcion"] = "UDF7_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF8_STRING";
                dr["Descripcion"] = "UDF8_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF9_STRING";
                dr["Descripcion"] = "UDF9_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF10_STRING";
                dr["Descripcion"] = "UDF10_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF11_STRING";
                dr["Descripcion"] = "UDF11_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF12_STRING";
                dr["Descripcion"] = "UDF12_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF13_STRING";
                dr["Descripcion"] = "UDF13_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "U.UDF14_STRING";
                dr["Descripcion"] = "UDF14_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.ITEM_SIZE";
                dr["Descripcion"] = "ITEM_SIZE";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.ATTRIBUTE";
                dr["Descripcion"] = "ATTRIBUTE";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "V.VEND_CODE";
                dr["Descripcion"] = "VEND_CODE";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "V.VEND_NAME";
                dr["Descripcion"] = "VEND_NAME";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.COST";
                dr["Descripcion"] = "COST";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT1";
                dr["Descripcion"] = "TEXT1";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT2";
                dr["Descripcion"] = "TEXT2";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT3";
                dr["Descripcion"] = "TEXT3";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT4";
                dr["Descripcion"] = "TEXT4";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT5";
                dr["Descripcion"] = "TEXT5";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT6";
                dr["Descripcion"] = "TEXT6";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT7";
                dr["Descripcion"] = "TEXT7";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT8";
                dr["Descripcion"] = "TEXT8";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT9";
                dr["Descripcion"] = "TEXT9";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "I.TEXT10";
                dr["Descripcion"] = "TEXT10";
                dt.Rows.Add(dr);
                dr = dt.NewRow();

                dr["Codigo"] = "S.STORE_NO";
                dr["Descripcion"] = "STORE_NO";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "S.STORE_CODE";
                dr["Descripcion"] = "STORE_CODE";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "S.STORE_NAME";
                dr["Descripcion"] = "STORE_NAME";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "S.GLOBAL_STORE_CODE";
                dr["Descripcion"] = "GLOBAL_STORE_CODE";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "S.UDF1_STRING";
                dr["Descripcion"] = "UDF1_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "S.UDF2_STRING";
                dr["Descripcion"] = "UDF2_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "S.UDF3_STRING";
                dr["Descripcion"] = "UDF3_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "S.UDF4_STRING";
                dr["Descripcion"] = "UDF4_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "S.UDF5_STRING";
                dr["Descripcion"] = "UDF5_STRING";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "SB.SBS_NO";
                dr["Descripcion"] = "SBS_NO";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "SB.SBS_NAME";
                dr["Descripcion"] = "SBS_NAME";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "SC.COD_SOCIEDAD";
                dr["Descripcion"] = "ID_SOCIEDAD";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "CC.CENTRO";
                dr["Descripcion"] = "ID_CENTRO";
                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Codigo"] = "CC.ALMACEN";
                dr["Descripcion"] = "ID_ALMACEN";
                dt.Rows.Add(dr);
                dr = dt.NewRow();

                dr["Codigo"] = "p.PRICE";
                dr["Descripcion"] = "PRICE2";
                dt.Rows.Add(dr);


                cb_rpro_campI.DataSource = dt;
                cb_rpro_campI.ValueMember = "Codigo";
                cb_rpro_campI.DisplayMember = "Descripcion";

                cb_rpro_Cat.DataSource = dt;
                cb_rpro_Cat.ValueMember = "Codigo";
                cb_rpro_Cat.DisplayMember = "Descripcion";

                cb_rproD.DataSource = dt;
                cb_rproD.ValueMember = "Codigo";
                cb_rproD.DisplayMember = "Descripcion";
            }
            else
            {
                txt_host_db.Enabled = true;
                txt_port_db.Enabled = true;
                txt_user_db.Enabled = true;
                txt_pass_db.Enabled = true;
                txt_db_name.Enabled = true;
                cb_db_con.Enabled = true;

                cb_subsidiariaInv.Enabled = true;
                cb_store_I.Enabled = true;

                cb_interfazL.Enabled = true;
                cb_interfazM.Enabled = true;
                cb_interfazMI.Enabled = true;
                cb_interfazJ.Enabled = true;
                cb_interfazV.Enabled = true;
                cb_interfazS.Enabled = true;
                cb_interfazD.Enabled = true;
                txt_notiMail_Inv.Enabled = true;
                cb_tiempoInv.Enabled = true;
                cb_hLun.Enabled = true;
                cb_hMar.Enabled = true;
                cb_hMi.Enabled = true;
                cb_hJue.Enabled = true;
                cb_hVie.Enabled = true;
                cb_hSa.Enabled = true;
                dgv_tiendas_tiemposI.Enabled = true;
                bt_agregarTieI.Enabled = true;
                txt_tiempo.Enabled = true;

                dgv_mapeoInventario.Enabled = true;
                bt_agregarI.Enabled = true;
                cb_rpro_campI.Enabled = true;
                txt_dalake_campI.Enabled = true;
                cb_mapeo_tipo.Enabled = true;

                txt_urlInv.Enabled = true;
                txt_tokenI.Enabled = true;

                GB_FilterI.Enabled = true;
                GP_FilterD.Enabled = true;

                bt_guardarConfInv.Text = "Guardar";
                bt_guardar_db.Text = "Guardar";
                bt_GuardarMapI.Text = "Guardar";
                bt_GuardarCredI.Text = "Guardar";
                B_SetConfCat_Filter.Text = "Guardar";
                B_SetConfCat_FilterD.Text = "Guardar";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {


                config.carpetaAplicativo = Environment.CurrentDirectory;
                config.CarpetaLogAplicativo = Environment.CurrentDirectory + "/Log_Panel";
                config.MetodoEncriptar = "MD5";
                config.NombreArchivoConf = "Conf_DataLake";
                config.ClaveEncriptar = "Ecommerce";

                cb_db_con.DataSource = ListasCB.GetListDBType();
                cb_db_con.DisplayMember = "Label";
                cb_db_con.ValueMember = "Value";

                if (config.ExisteXML())
                {

                    archivo_config = true;

                    LlenarVariablesCredenciales();
                    LlenarVariablesInventario();
                    LlenarVariablesMapeoInv();
                    LlenarVariablesInv();
                    LlenarVariablesPrecios();
                    LlenarVariablesMovimientos();
                    LlenarVariablesCatFilter();
                    LlenarVariablesCatFilterD();
                    LoadEmailConfig();

                    try
                    {
                        ora.Conexion = "DATA SOURCE=" + Credenciales.ip + ":" + Credenciales.puerto + "/" + Credenciales.db + ";PASSWORD=" + Credenciales.password + ";PERSIST SECURITY INFO=True;USER ID=" + Credenciales.usuario;

                        var RspConectar = new ResponseCRpro9();
                        RspConectar = ora.Conectar();
                        if (RspConectar.status)
                        {
                            var RspSubsidiary = new ResponseCRpro9();
                            var RspStores = new ResponseCRpro9();
                            var RspSubsidiaryM = new ResponseCRpro9();
                            var RspStoresM = new ResponseCRpro9();
                            var RspSubsidiaryD = new ResponseCRpro9();
                            var RspStoresD = new ResponseCRpro9();

                            // ******COMBO SUBSIDIARIA EJECUCION MANUAL INVENTARIO**************
                            var NodosTiendas = new List<NodoConAtributos>();
                            NodosTiendas = config.LeerNodosConAtributos("", "Inventario", "Tiendas", "Tienda");


                            LlenarTiendas(NodosTiendas);
                            if (StockConf.tiendas.Count > 0)
                            {
                                Sbs_noM = StockConf.tiendas[0].sbs_no;
                                cb_sbs_noM.SelectedItem = Sbs_noM;
                            }
                            else
                            {
                                Sbs_noM = "0";
                            }

                            RspSubsidiaryM = ora.ListarSubsidiarys(Convert.ToInt16(Sbs_noM), "oracle_10");

                            if (RspSubsidiaryM.status)
                            {

                                cb_sbs_noM.DataSource = RspSubsidiaryM.result;
                                cb_sbs_noM.DisplayMember = "DISPLAY";
                                cb_sbs_noM.ValueMember = "SBS_NO";

                                RspStoresM = ora.ListarStores(short.Parse(Conversions.ToString(cb_sbs_noM.SelectedValue)), "oracle_10");
                                if (RspStoresM.status)
                                {

                                    cb_list_storesM.DataSource = RspStoresM.result;
                                    cb_list_storesM.DisplayMember = "DISPLAY";
                                    cb_list_storesM.ValueMember = "STORE_NO";
                                }
                                else
                                {
                                    Interaction.MsgBox(RspStoresM.message, MsgBoxStyle.Critical, "Error - Oracle");
                                }
                            }
                            else
                            {
                                Interaction.MsgBox(RspSubsidiaryM.message, MsgBoxStyle.Critical, "Error - Oracle");
                            }

                            // ******COMBO SUBSIDIARIA EJECUCION MANUAL DELTA**************
                            var NodosTiendasD = new List<NodoConAtributos>();
                            NodosTiendasD = config.LeerNodosConAtributos("", "InventarioDeltam", "Tiendas", "Tienda");


                            LlenarTiendasD(NodosTiendasD);
                            if (ConfD.tiendasD.Count > 0)
                            {
                                Sbs_noD = ConfD.tiendasD[0].sbs_no;
                                cb_sbs_noD.SelectedItem = Sbs_noD;
                            }
                            else
                            {
                                Sbs_noD = "0";
                            }

                            RspSubsidiaryD = ora.ListarSubsidiarys(Convert.ToInt16(Sbs_noD), "oracle_10");

                            if (RspSubsidiaryD.status)
                            {

                                cb_sbs_noD.DataSource = RspSubsidiaryD.result;
                                cb_sbs_noD.DisplayMember = "DISPLAY";
                                cb_sbs_noD.ValueMember = "SBS_NO";

                                RspStoresD = ora.ListarStores(short.Parse(Conversions.ToString(cb_sbs_noD.SelectedValue)), "oracle_10");
                                if (RspStoresD.status)
                                {

                                    cb_list_storesD.DataSource = RspStoresD.result;
                                    cb_list_storesD.DisplayMember = "DISPLAY";
                                    cb_list_storesD.ValueMember = "STORE_NO";
                                }
                                else
                                {
                                    Interaction.MsgBox(RspStoresD.message, MsgBoxStyle.Critical, "Error - Oracle");
                                }
                            }
                            else
                            {
                                Interaction.MsgBox(RspSubsidiaryD.message, MsgBoxStyle.Critical, "Error - Oracle");
                            }

                            // ******COMBO SUBSIDIARIA EJECUCION AUTOMATICA **************
                            // CatConfI.TiendasUrl
                            if (CatConfI.TiendasUrl.Count > 0)
                            {
                                Sbs_no = CatConfI.TiendasUrl[0].sbs_no;
                            }
                            else
                            {
                                Sbs_no = "0";
                            }
                            RspSubsidiary = ora.ListarSubsidiarys(Convert.ToInt16(Sbs_no), "oracle_10");

                            if (RspSubsidiary.status)
                            {
                                cb_subsidiariaInv.DataSource = RspSubsidiary.result;
                                cb_subsidiariaInv.DisplayMember = "DISPLAY";
                                cb_subsidiariaInv.ValueMember = "SBS_NO";


                                RspStores = ora.ListarStores(short.Parse(Conversions.ToString(cb_subsidiariaInv.SelectedValue)), "oracle_10");
                                if (RspStores.status)
                                {

                                    cb_store_I.DataSource = RspStores.result;
                                    cb_store_I.DisplayMember = "DISPLAY";
                                    cb_store_I.ValueMember = "STORE_NO";
                                }
                                else
                                {
                                    Interaction.MsgBox(RspStores.message, MsgBoxStyle.Critical, "Error - Oracle");
                                }
                            }
                            else
                            {
                                Interaction.MsgBox(RspSubsidiary.message, MsgBoxStyle.Critical, "Error - Oracle");
                            }
                        }
                        else
                        {
                            Interaction.MsgBox(RspConectar.message, MsgBoxStyle.Critical, "Error - Oracle");
                        }
                    }
                    catch (Exception ex)
                    {
                        Interaction.MsgBox(ex, MsgBoxStyle.Critical, "Error - Aplicativo");
                    }
                }
                else
                {
                    archivo_config = false;
                }
            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical, "Error - Aplicacion");
            }
        }
        private void bt_test_db_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txt_host_db.Text) & !string.IsNullOrEmpty(txt_port_db.Text) & !string.IsNullOrEmpty(txt_user_db.Text) & !string.IsNullOrEmpty(txt_pass_db.Text) & !string.IsNullOrEmpty(txt_db_name.Text))
            {

                ora.Conexion = "DATA SOURCE=" + txt_host_db.Text + ":" + txt_port_db.Text + "/" + txt_db_name.Text + ";PASSWORD=" + txt_pass_db.Text + ";PERSIST SECURITY INFO=True;USER ID=" + txt_user_db.Text;

                if (ora.Conectar().status)
                {
                    Interaction.MsgBox(ora.Conectar().message + " " + txt_db_name.Text, MsgBoxStyle.Information, "Informacion");
                }
                else
                {
                    Interaction.MsgBox(ora.Conectar().message, MsgBoxStyle.Critical, "Error - Conexion");
                }

            }
        }

        private void bt_guardar_db_Click(object sender, EventArgs e)
        {
            if (bt_guardar_db.Text.Contains("Guardar"))
            {

                // MySQL
                bool argEncriptar = false;
                config.GuardarAtributo("", "Oracle", "IP", txt_host_db.Text, ref argEncriptar);
                bool argEncriptar1 = false;
                config.GuardarAtributo("", "Oracle", "Puerto", txt_port_db.Text, ref argEncriptar1);
                bool argEncriptar2 = false;
                config.GuardarAtributo("", "Oracle", "Usuario", txt_user_db.Text, ref argEncriptar2);
                bool argEncriptar3 = true;
                config.GuardarAtributo("", "Oracle", "Password", txt_pass_db.Text, ref argEncriptar3);
                bool argEncriptar4 = false;
                config.GuardarAtributo("", "Oracle", "BaseDeDatos", txt_db_name.Text, ref argEncriptar4);
                bool argEncriptar5 = false;
                config.GuardarAtributo("", "Oracle", "DB_TYPE", Conversions.ToString(cb_db_con.SelectedValue), ref argEncriptar5);




                // Actualizar Variables
                Credenciales.ip = txt_host_db.Text;
                Credenciales.puerto = txt_port_db.Text;
                Credenciales.usuario = txt_user_db.Text;
                Credenciales.password = txt_pass_db.Text;
                Credenciales.db = txt_db_name.Text;
                Credenciales.plataforma = Conversions.ToString(cb_db_con.SelectedValue);

                txt_host_db.Enabled = false;
                txt_port_db.Enabled = false;
                txt_user_db.Enabled = false;
                txt_pass_db.Enabled = false;
                txt_db_name.Enabled = false;
                cb_db_con.Enabled = false;

                Interaction.MsgBox("Credenciales Guardadas con Exito", MsgBoxStyle.Information, "Info");
                bt_guardar_db.Text = "Editar";
            }
            else if (bt_guardar_db.Text.Contains("Editar"))
            {

                txt_host_db.Enabled = true;
                txt_port_db.Enabled = true;
                txt_user_db.Enabled = true;
                txt_pass_db.Enabled = true;
                txt_db_name.Enabled = true;
                cb_db_con.Enabled = true;

                bt_guardar_db.Text = "Guardar";

            }
        }
        private void LlenarVariablesCredenciales()
        {
            Credenciales.ip = config.LeerAtributo("", "", "Oracle", "IP", false);
            Credenciales.puerto = config.LeerAtributo("", "", "Oracle", "Puerto", false);
            Credenciales.usuario = config.LeerAtributo("", "", "Oracle", "Usuario", false);
            Credenciales.password = config.LeerAtributo("", "", "Oracle", "Password", true);
            Credenciales.db = config.LeerAtributo("", "", "Oracle", "BaseDeDatos", false);
            Credenciales.plataforma = config.LeerAtributo("", "", "Oracle", "DB_TYPE", false);
        }

        private void LoadEmailConfig()
        {
            string smtpServer = config.LeerAtributo("", "", "EmailConfig", "SmtpServer", false);
            string port = config.LeerAtributo("", "", "EmailConfig", "Port", false);
            string username = config.LeerAtributo("", "", "EmailConfig", "Username", false);
            // No se carga la contraseña, ya que la hemos eliminado

            // Leer la lista de correos
            string recipientEmails = config.LeerAtributo("", "", "EmailConfig", "RecipientEmails", false);

            // Asignar los valores a los controles
            txtSmtpServer.Text = smtpServer;
            txtPort.Text = port;
            txtUsername.Text = username;
            txtRecipientEmails.Text = recipientEmails; // Asignar la lista de correos
        }
        private void LlenarVariablesInv()
        {
            CredEndI.url = config.LeerAtributo("", "", "EndpointInv", "Url", false);
            CredEndI.token = config.LeerAtributo("", "", "EndpointInv", "Token", false);

        }

        private void LlenarVariablesPrecios()
        {
            CredEndPrecios.url = config.LeerAtributo("", "", "EndpointPrecios", "Url", false);
            CredEndPrecios.token = config.LeerAtributo("", "", "EndpointPrecios", "Token", false);

        }

        private void LlenarVariablesMovimientos()
        {
            CredEndMov.url = config.LeerAtributo("", "", "EndpointMovimientos", "Url", false);
            CredEndMov.token = config.LeerAtributo("", "", "EndpointMovimientos", "Token", false);

        }

        private void LlenarTiendas(List<NodoConAtributos> NTiendas)
        {
            if (NTiendas.Count > 0)
            {
                StockConf.tiendas.Clear();

                foreach (NodoConAtributos Ntienda in NTiendas)
                {
                    var tienda = new Tienda();
                    tienda.sbs_no = Ntienda.Atributos.Find(t => t.Nombre == "sbs_no").Valor;
                    tienda.store_no = Ntienda.Atributos.Find(t => t.Nombre == "store_no").Valor;

                    StockConf.tiendas.Add(tienda);
                }
            }
        }

        private void LlenarTiendasD(List<NodoConAtributos> NTiendas)
        {
            if (NTiendas.Count > 0)
            {
                ConfD.tiendasD.Clear();

                foreach (NodoConAtributos Ntienda in NTiendas)
                {
                    var tienda = new TiendaD();
                    tienda.sbs_no = Ntienda.Atributos.Find(t => t.Nombre == "sbs_no").Valor;
                    tienda.store_no = Ntienda.Atributos.Find(t => t.Nombre == "store_no").Valor;

                    ConfD.tiendasD.Add(tienda);
                }
            }
        }

        private void LlenarVariablesMapeoInv()
        {

            var NodosMapeos = new List<NodoConAtributos>();
            NodosMapeos = config.LeerNodosConAtributos("", "Inventario", "MapeoInventario", "Mapeo");
            var argMapeos = CatConf.Mapeos;
            LlenarMapeo(ref argMapeos, NodosMapeos);
            CatConf.Mapeos = argMapeos;

        }
        private void LlenarMapeo(ref List<Mapeo> Mapeos, List<NodoConAtributos> NMapeos)
        {
            if (NMapeos.Count > 0)
            {
                Mapeos.Clear();

                foreach (NodoConAtributos NMapeo in NMapeos)
                {
                    var mapeo = new Mapeo();
                    mapeo.ecommerce = NMapeo.Atributos.Find(t => t.Nombre == "DataLake").Valor;
                    mapeo.campo_rpro = NMapeo.Atributos.Find(t => t.Nombre == "campo_rpro").Valor;
                    mapeo.tipo = NMapeo.Atributos.Find(t => t.Nombre == "Tipo").Valor;

                    Mapeos.Add(mapeo);
                }
            }
        }


        private void LlenarVariablesInventario()
        {
            string str_activar = config.LeerAtributo("", "Inventario", "Filtros", "Activar", false);

            CatConf.activar_filtros = Conversions.ToBoolean(Interaction.IIf(str_activar.ToUpper() == "TRUE" | str_activar.ToUpper() == "FALSE", str_activar, false));

            StockConf.Mail = config.LeerAtributo("", "", "Inventario", "Email", false);
            StockConf.TiempoEjec = config.LeerAtributo("", "", "Inventario", "Tiempo", false);
            var NodosFiltros = new List<NodoConAtributos>();
            NodosFiltros = config.LeerNodosConAtributos("", "ConfTiendas", "ProcesTiendas", "Tienda");
            var argTiendas = CatConfI.TiendasUrl;
            LlenarUrlTiendas(ref argTiendas, NodosFiltros);
            CatConfI.TiendasUrl = argTiendas;
        }

        private void LlenarUrlTiendas(ref List<TiendaUrl> Tiendas, List<NodoConAtributos> NFiltros)
        {
            if (NFiltros.Count > 0)
            {
                Tiendas.Clear();

                foreach (NodoConAtributos Nfiltro in NFiltros)
                {
                    var tiendaURL = new TiendaUrl();

                    tiendaURL.sbs_no = Nfiltro.Atributos.Find(t => t.Nombre == "sbs_no").Valor;
                    tiendaURL.store_no = Nfiltro.Atributos.Find(t => t.Nombre == "store_no").Valor;
                    tiendaURL.Lunes = Nfiltro.Atributos.Find(t => t.Nombre == "Lunes").Valor;
                    tiendaURL.Lu_tiempo = Nfiltro.Atributos.Find(t => t.Nombre == "Hora_Lunes").Valor;
                    tiendaURL.Martes = Nfiltro.Atributos.Find(t => t.Nombre == "Martes").Valor;
                    tiendaURL.Mar_tiempo = Nfiltro.Atributos.Find(t => t.Nombre == "Hora_Martes").Valor;
                    tiendaURL.Miercoles = Nfiltro.Atributos.Find(t => t.Nombre == "Miercoles").Valor;
                    tiendaURL.Mie_tiempo = Nfiltro.Atributos.Find(t => t.Nombre == "Hora_Miercoles").Valor;
                    tiendaURL.Jueves = Nfiltro.Atributos.Find(t => t.Nombre == "Jueves").Valor;
                    tiendaURL.Ju_tiempo = Nfiltro.Atributos.Find(t => t.Nombre == "Hora_Jueves").Valor;
                    tiendaURL.Viernes = Nfiltro.Atributos.Find(t => t.Nombre == "Viernes").Valor;
                    tiendaURL.Vi_tiempo = Nfiltro.Atributos.Find(t => t.Nombre == "Hora_Viernes").Valor;
                    tiendaURL.Sabado = Nfiltro.Atributos.Find(t => t.Nombre == "Sabado").Valor;
                    tiendaURL.Sa_tiempo = Nfiltro.Atributos.Find(t => t.Nombre == "Hora_Sabado").Valor;
                    tiendaURL.Domingo = Nfiltro.Atributos.Find(t => t.Nombre == "Domingo").Valor;
                    tiendaURL.tiempo = Nfiltro.Atributos.Find(t => t.Nombre == "Hora_Domingo").Valor;

                    Tiendas.Add(tiendaURL);
                }
            }
        }
        private List<NodoConAtributos> GetStoreList(ref DataGridView FilasUrl)
        {
            var NodosFiltros = new List<NodoConAtributos>();

            if (FilasUrl.Rows.Count > 0)
            {

                CatConfI.TiendasUrl.Clear();

                foreach (DataGridViewRow fila in FilasUrl.Rows)
                {
                    var NodoFiltro = new NodoConAtributos();
                    var Latributos = new List<Campo>();



                    Latributos.Add(new Campo("sbs_no", Conversions.ToString(fila.Cells["fc_sbs_no"].Value), false));
                    Latributos.Add(new Campo("store_no", Conversions.ToString(fila.Cells["fc_store_no"].Value), false));
                    Latributos.Add(new Campo("Lunes", Conversions.ToString(fila.Cells["fc_lunes"].Value), false));
                    Latributos.Add(new Campo("Hora_Lunes", Conversions.ToString(fila.Cells["fc_hora_lu"].Value), false));
                    Latributos.Add(new Campo("Martes", Conversions.ToString(fila.Cells["fc_martes"].Value), false));
                    Latributos.Add(new Campo("Hora_Martes", Conversions.ToString(fila.Cells["fc_hora_ma"].Value), false));
                    Latributos.Add(new Campo("Miercoles", Conversions.ToString(fila.Cells["fc_miercoles"].Value), false));
                    Latributos.Add(new Campo("Hora_Miercoles", Conversions.ToString(fila.Cells["fc_hora_Mi"].Value), false));
                    Latributos.Add(new Campo("Jueves", Conversions.ToString(fila.Cells["fc_jueves"].Value), false));
                    Latributos.Add(new Campo("Hora_Jueves", Conversions.ToString(fila.Cells["fc_hora_Ju"].Value), false));
                    Latributos.Add(new Campo("Viernes", Conversions.ToString(fila.Cells["fc_viernes"].Value), false));
                    Latributos.Add(new Campo("Hora_Viernes", Conversions.ToString(fila.Cells["fc_hora_Vi"].Value), false));
                    Latributos.Add(new Campo("Sabado", Conversions.ToString(fila.Cells["fc_sabado"].Value), false));
                    Latributos.Add(new Campo("Hora_Sabado", Conversions.ToString(fila.Cells["fc_hora_Sa"].Value), false));
                    Latributos.Add(new Campo("Domingo", Conversions.ToString(fila.Cells["fc_domingo"].Value), false));
                    Latributos.Add(new Campo("Hora_Domingo", Conversions.ToString(fila.Cells["fc_hora_do"].Value), false));


                    NodoFiltro.Nombre = "Tienda";
                    NodoFiltro.Atributos = Latributos;
                    NodosFiltros.Add(NodoFiltro);

                    var TiendaUrl = new TiendaUrl();


                    TiendaUrl.sbs_no = Conversions.ToString(fila.Cells["fc_sbs_no"].Value);
                    TiendaUrl.store_no = Conversions.ToString(fila.Cells["fc_store_no"].Value);
                    TiendaUrl.Lunes = Conversions.ToString(fila.Cells["fc_lunes"].Value);
                    TiendaUrl.Lu_tiempo = Conversions.ToString(fila.Cells["fc_hora_lu"].Value);
                    TiendaUrl.Martes = Conversions.ToString(fila.Cells["fc_martes"].Value);
                    TiendaUrl.Mar_tiempo = Conversions.ToString(fila.Cells["fc_hora_ma"].Value);
                    TiendaUrl.Miercoles = Conversions.ToString(fila.Cells["fc_miercoles"].Value);
                    TiendaUrl.Mie_tiempo = Conversions.ToString(fila.Cells["fc_hora_Mi"].Value);
                    TiendaUrl.Jueves = Conversions.ToString(fila.Cells["fc_jueves"].Value);
                    TiendaUrl.Ju_tiempo = Conversions.ToString(fila.Cells["fc_hora_Ju"].Value);
                    TiendaUrl.Viernes = Conversions.ToString(fila.Cells["fc_viernes"].Value);
                    TiendaUrl.Vi_tiempo = Conversions.ToString(fila.Cells["fc_hora_Vi"].Value);
                    TiendaUrl.Sabado = Conversions.ToString(fila.Cells["fc_sabado"].Value);
                    TiendaUrl.Sa_tiempo = Conversions.ToString(fila.Cells["fc_hora_Sa"].Value);
                    TiendaUrl.Domingo = Conversions.ToString(fila.Cells["fc_domingo"].Value);
                    TiendaUrl.tiempo = Conversions.ToString(fila.Cells["fc_hora_do"].Value);

                    CatConfI.TiendasUrl.Add(TiendaUrl);
                }


            }

            return NodosFiltros;
        }
        private List<NodoConAtributos> GetStoreListManual(string sbs_no, ref CheckedListBox CheckedList)
        {
            var NodosTiendas = new List<NodoConAtributos>();

            if (CheckedList.Items.Count > 0)
            {

                StockConf.tiendas.Clear();
                for (int i = 0, loopTo = CheckedList.Items.Count - 1; i <= loopTo; i++)
                {
                    var NodoTienda = new NodoConAtributos();
                    var Latributos = new List<Campo>();

                    var Tienda = new Tienda();
                    if (CheckedList.GetItemChecked(i)) // SI ESTA SELECCIONADO
                    {

                        Latributos.Add(new Campo("sbs_no", sbs_no, false));
                        Latributos.Add(new Campo("store_no", Conversions.ToString(((dynamic)CheckedList.Items[i]).STORE_NO), false));

                        NodoTienda.Nombre = "Tienda";
                        NodoTienda.Atributos = Latributos;

                        NodosTiendas.Add(NodoTienda);

                        Tienda.sbs_no = sbs_no;
                        Tienda.store_no = Conversions.ToString(((dynamic)CheckedList.Items[i]).STORE_NO);
                        StockConf.tiendas.Add(Tienda);
                    }
                }
            }

            return NodosTiendas;
        }
        private List<NodoConAtributos> GetMapeoInv(ref DataGridView FilasMapeo)
        {
            var NodosMapeos = new List<NodoConAtributos>();

            if (FilasMapeo.Rows.Count > 0)
            {

                CatConf.Mapeos.Clear();

                foreach (DataGridViewRow fila in FilasMapeo.Rows)
                {
                    var NodoMapeo = new NodoConAtributos();
                    var Latributos = new List<Campo>();

                    Latributos.Add(new Campo("DataLake", Conversions.ToString(fila.Cells["mc_datalake"].Value), false));
                    Latributos.Add(new Campo("campo_rpro", Conversions.ToString(fila.Cells["mc_campo_rpro"].Value), false));
                    Latributos.Add(new Campo("Tipo", Conversions.ToString(fila.Cells["mc_tipo"].Value), false));

                    NodoMapeo.Nombre = "Mapeo";
                    NodoMapeo.Atributos = Latributos;
                    NodosMapeos.Add(NodoMapeo);

                    var Mapeo = new Mapeo();
                    Mapeo.ecommerce = Conversions.ToString(fila.Cells["mc_datalake"].Value);
                    Mapeo.campo_rpro = Conversions.ToString(fila.Cells["mc_campo_rpro"].Value);
                    Mapeo.tipo = Conversions.ToString(fila.Cells["mc_tipo"].Value);

                    CatConf.Mapeos.Add(Mapeo);
                }
            }

            return NodosMapeos;
        }


        private void bt_guardarConfInv_Click_1(object sender, EventArgs e)
        {
            if (bt_guardarConfInv.Text.Contains("Guardar"))
            {

                // config.GuardarAtributo("", "Inventario", "Lunes", StockConf.Lunes, False)
                // config.GuardarAtributo("", "Inventario", "Martes", StockConf.Martes, False)
                // config.GuardarAtributo("", "Inventario", "Miercoles", StockConf.Miercoles, False)
                // config.GuardarAtributo("", "Inventario", "Jueves", StockConf.Jueves, False)
                // config.GuardarAtributo("", "Inventario", "Viernes", StockConf.Viernes, False)
                // config.GuardarAtributo("", "Inventario", "Sabado", StockConf.Sabado, False)
                // config.GuardarAtributo("", "Inventario", "Domingo", StockConf.Domingo, False)
                bool argEncriptar = false;
                config.GuardarAtributo("", "Inventario", "Tiempo", txt_tiempo.Text, ref argEncriptar);
                bool argEncriptar1 = false;
                config.GuardarAtributo("", "Inventario", "Email", txt_notiMail_Inv.Text, ref argEncriptar1);

                if (dgv_tiendas_tiemposI.Rows.Count > 0)
                {
                    var argFilasUrl = dgv_tiendas_tiemposI;
                    var NodosFiltros = GetStoreList(ref argFilasUrl);
                    dgv_tiendas_tiemposI = argFilasUrl;

                    config.GuardarNodosConAtributos("", "ConfTiendas", "ProcesTiendas", NodosFiltros);
                }
                else
                {
                    var NodosFiltros = new List<NodoConAtributos>();
                    var NodoFiltro = new NodoConAtributos();
                    var Latributos = new List<Campo>();


                    Latributos.Add(new Campo("sbs_no", "", false));
                    Latributos.Add(new Campo("store_no", "", false));
                    Latributos.Add(new Campo("Lunes", "", false));
                    Latributos.Add(new Campo("Hora_Lunes", "", false));
                    Latributos.Add(new Campo("Martes", "", false));
                    Latributos.Add(new Campo("Hora_Martes", "", false));
                    Latributos.Add(new Campo("Miercoles", "", false));
                    Latributos.Add(new Campo("Hora_Miercoles", "", false));
                    Latributos.Add(new Campo("Jueves", "", false));
                    Latributos.Add(new Campo("Hora_Jueves", "", false));
                    Latributos.Add(new Campo("Viernes", "", false));
                    Latributos.Add(new Campo("Hora_Viernes", "", false));
                    Latributos.Add(new Campo("Sabado", "", false));
                    Latributos.Add(new Campo("Hora_Sabado", "", false));
                    Latributos.Add(new Campo("Domingo", "", false));
                    Latributos.Add(new Campo("Hora_Domingo", "", false));


                    NodoFiltro.Nombre = "Tienda";
                    NodoFiltro.Atributos = Latributos;
                    NodosFiltros.Add(NodoFiltro);

                    config.GuardarNodosConAtributos("", "ConfTiendas", "ProcesTiendas", NodosFiltros);


                }


                // If cb_subsidiariaInv.Items.Count > 0 Then
                // Dim NodosTiendas As List(Of NodoConAtributos) = GetStoreList(cb_subsidiariaInv.SelectedValue, cb_store_I)

                // config.GuardarNodosConAtributos("", "Inventario", "Tiendas", NodosTiendas)
                // End If


                cb_subsidiariaInv.Enabled = false;
                cb_store_I.Enabled = false;

                cb_interfazL.Enabled = false;
                cb_interfazM.Enabled = false;
                cb_interfazMI.Enabled = false;
                cb_interfazJ.Enabled = false;
                cb_interfazV.Enabled = false;
                cb_interfazS.Enabled = false;
                cb_interfazD.Enabled = false;
                txt_notiMail_Inv.Enabled = false;
                cb_tiempoInv.Enabled = false;
                dgv_tiendas_tiemposI.Enabled = false;
                bt_agregarTieI.Enabled = false;
                txt_tiempo.Enabled = false;
                cb_hLun.Enabled = false;
                cb_hMar.Enabled = false;
                cb_hMi.Enabled = false;
                cb_hJue.Enabled = false;
                cb_hVie.Enabled = false;
                cb_hSa.Enabled = false;


                bt_guardarConfInv.Text = "Editar";

                Interaction.MsgBox("Campos de Configuracion Inventario Guardados con Exito", MsgBoxStyle.Information, "Info");
            }
            else if (bt_guardarConfInv.Text.Contains("Editar"))
            {

                cb_subsidiariaInv.Enabled = true;
                cb_store_I.Enabled = true;

                cb_interfazL.Enabled = true;
                cb_interfazM.Enabled = true;
                cb_interfazMI.Enabled = true;
                cb_interfazJ.Enabled = true;
                cb_interfazV.Enabled = true;
                cb_interfazS.Enabled = true;
                cb_interfazD.Enabled = true;
                txt_notiMail_Inv.Enabled = true;
                cb_tiempoInv.Enabled = true;
                dgv_tiendas_tiemposI.Enabled = true;
                bt_agregarTieI.Enabled = true;
                txt_tiempo.Enabled = true;

                cb_hLun.Enabled = true;
                cb_hMar.Enabled = true;
                cb_hMi.Enabled = true;
                cb_hJue.Enabled = true;
                cb_hVie.Enabled = true;
                cb_hSa.Enabled = true;

                bt_guardarConfInv.Text = "Guardar";
            }
        }

        private void bt_agregarTieI_Click_1(object sender, EventArgs e)
        {
            string[] interfaces = { cb_interfazL.Text, cb_interfazM.Text, cb_interfazMI.Text, cb_interfazJ.Text, cb_interfazV.Text, cb_interfazS.Text, cb_interfazD.Text };
            string[] valores = new string[interfaces.Length];

            for (int i = 0; i < interfaces.Length; i++)
            {
                switch (interfaces[i])
                {
                    case "Inventario":
                        valores[i] = "C";
                        break;
                    case "Delta":
                        valores[i] = "D";
                        break;
                    case "Precios":
                        valores[i] = "P";
                        break;
                    case "Movimientos":
                        valores[i] = "M";
                        break;
                }
            }

            dgv_tiendas_tiemposI.Rows.Add(cb_subsidiariaInv.SelectedValue, cb_store_I.SelectedValue, valores[0], cb_hLun.Text, valores[1], cb_hMar.Text, valores[2], cb_hMi.Text, valores[3], cb_hJue.Text, valores[4], cb_hVie.Text, valores[5], cb_hSa.Text, valores[6], cb_tiempoInv.Text);

            cb_subsidiariaInv.SelectedIndex = -1;
            cb_store_I.SelectedIndex = -1;
            cb_tiempoInv.SelectedIndex = -1;
            cb_interfazL.SelectedIndex = -1;
            cb_interfazM.SelectedIndex = -1;
            cb_interfazMI.SelectedIndex = -1;
            cb_interfazJ.SelectedIndex = -1;
            cb_interfazV.SelectedIndex = -1;
            cb_interfazS.SelectedIndex = -1;
            cb_interfazD.SelectedIndex = -1;
            cb_hLun.SelectedIndex = -1;
            cb_hMar.SelectedIndex = -1;
            cb_hMi.SelectedIndex = -1;
            cb_hJue.SelectedIndex = -1;
            cb_hVie.SelectedIndex = -1;
            cb_hSa.SelectedIndex = -1;
        }
        //private void bt_agregarTieI_Click_1(object sender, EventArgs e)
        //{
        //    string L = "";
        //    string M = "";
        //    string MI = "";
        //    string J = "";
        //    string V = "";
        //    string S = "";
        //    string D = "";



        //    if (cb_interfazL.Text == "Inventario")
        //    {
        //        L = "C";
        //    }
        //    else if (cb_interfazL.Text == "Delta")
        //    {
        //        L = "D";
        //    }
        //    else if (cb_interfazL.Text == "Precios")
        //    {
        //        L = "P";
        //    }
        //    else if (cb_interfazL.Text == "Movimientos")
        //    {
        //        L = "M";
        //    }

        //    if (cb_interfazM.Text == "Inventario")
        //    {
        //        M = "C";
        //    }
        //    else if (cb_interfazM.Text == "Delta")
        //    {
        //        M = "D";
        //    }
        //    else if (cb_interfazM.Text == "Precios")
        //    {
        //        M = "P";
        //    }
        //    else if (cb_interfazM.Text == "Movimientos")
        //    {
        //        M = "M";
        //    }

        //    if (cb_interfazMI.Text == "Inventario")
        //    {
        //        MI = "C";
        //    }
        //    else if (cb_interfazMI.Text == "Delta")
        //    {
        //        MI = "D";
        //    }
        //    else if (cb_interfazMI.Text == "Precios")
        //    {
        //        MI = "P";
        //    }
        //    else if (cb_interfazMI.Text == "Movimientos")
        //    {
        //        MI = "M";
        //    }

        //    if (cb_interfazJ.Text == "Inventario")
        //    {
        //        J = "C";
        //    }
        //    else if (cb_interfazJ.Text == "Delta")
        //    {
        //        J = "D";
        //    }
        //    else if (cb_interfazJ.Text == "Precios")
        //    {
        //        J = "P";
        //    }
        //    else if (cb_interfazJ.Text == "Movimientos")
        //    {
        //        J = "M";
        //    }

        //    if (cb_interfazV.Text == "Inventario")
        //    {
        //        V = "C";
        //    }
        //    else if (cb_interfazV.Text == "Delta")
        //    {
        //        V = "D";
        //    }
        //    else if (cb_interfazV.Text == "Precios")
        //    {
        //        V = "P";
        //    }
        //    else if (cb_interfazV.Text == "Movimientos")
        //    {
        //        V = "M";
        //    }

        //    if (cb_interfazS.Text == "Inventario")
        //    {
        //        S = "C";
        //    }
        //    else if (cb_interfazS.Text == "Delta")
        //    {
        //        S = "D";
        //    }
        //    else if (cb_interfazS.Text == "Precios")
        //    {
        //        S = "P";
        //    }
        //    else if (cb_interfazS.Text == "Movimientos")
        //    {
        //        S = "M";
        //    }

        //    if (cb_interfazD.Text == "Inventario")
        //    {
        //        D = "C";
        //    }
        //    else if (cb_interfazD.Text == "Delta")
        //    {
        //        D = "D";
        //    }
        //    else if (cb_interfazD.Text == "Precios")
        //    {
        //        D = "P";
        //    }
        //    else if (cb_interfazD.Text == "Movimientos")
        //    {
        //        D = "M";
        //    }


        //    dgv_tiendas_tiemposI.Rows.Add(cb_subsidiariaInv.SelectedValue, cb_store_I.SelectedValue, L, cb_hLun.Text, M, cb_hMar.Text, MI, cb_hMi.Text, J, cb_hJue.Text, V, cb_hVie.Text, S, cb_hSa.Text, D, cb_tiempoInv.Text);

        //    cb_subsidiariaInv.SelectedIndex = -1;
        //    cb_store_I.SelectedIndex = -1;
        //    cb_tiempoInv.SelectedIndex = -1;
        //    cb_interfazL.SelectedIndex = -1;
        //    cb_interfazM.SelectedIndex = -1;
        //    cb_interfazMI.SelectedIndex = -1;
        //    cb_interfazJ.SelectedIndex = -1;
        //    cb_interfazV.SelectedIndex = -1;
        //    cb_interfazS.SelectedIndex = -1;
        //    cb_interfazD.SelectedIndex = -1;
        //    cb_hLun.SelectedIndex = -1;
        //    cb_hMar.SelectedIndex = -1;
        //    cb_hMi.SelectedIndex = -1;
        //    cb_hJue.SelectedIndex = -1;
        //    cb_hVie.SelectedIndex = -1;
        //    cb_hSa.SelectedIndex = -1;

        //}

        private void bt_agregarI_Click_1(object sender, EventArgs e)
        {
            dgv_mapeoInventario.Rows.Add(cb_rpro_campI.SelectedValue, txt_dalake_campI.Text, cb_mapeo_tipo.SelectedItem);

            txt_dalake_campI.Text = "";
            cb_mapeo_tipo.SelectedIndex = -1;
            cb_rpro_campI.SelectedIndex = -1;
        }

        private void bt_GuardarMapI_Click_1(object sender, EventArgs e)
        {
            if (bt_GuardarMapI.Text.Contains("Guardar"))
            {

                if (dgv_mapeoInventario.Rows.Count > 0)
                {
                    var argFilasMapeo = dgv_mapeoInventario;
                    var NodosMapeos = GetMapeoInv(ref argFilasMapeo);
                    dgv_mapeoInventario = argFilasMapeo;

                    config.GuardarNodosConAtributos("", "Inventario", "MapeoInventario", NodosMapeos);
                }


                dgv_mapeoInventario.Enabled = false;
                bt_agregarI.Enabled = false;
                cb_rpro_campI.Enabled = false;
                txt_dalake_campI.Enabled = false;
                cb_mapeo_tipo.Enabled = false;
                bt_GuardarMapI.Text = "Editar";

                Interaction.MsgBox("Campos de Mapeo Catalogo Guardados con Exito", MsgBoxStyle.Information, "Info");
            }
            else if (bt_GuardarMapI.Text.Contains("Editar"))
            {


                dgv_mapeoInventario.Enabled = true;
                bt_agregarI.Enabled = true;
                cb_rpro_campI.Enabled = true;
                cb_mapeo_tipo.Enabled = true;
                txt_dalake_campI.Enabled = true;
                bt_GuardarMapI.Text = "Guardar";

            }
        }

        private void dgv_mapeoInventario_KeyDown(object sender, KeyEventArgs e)
        {
            int li2_index;
            if (dgv_mapeoInventario.Rows.Count >= 1)
            {

                if (e.KeyCode == Keys.Delete)
                {

                    e.Handled = true;

                    li2_index = ((DataGridView)sender).CurrentRow.Index;

                    dgv_mapeoInventario.Rows.RemoveAt(li2_index);

                }
            }
        }

        private void bt_GuardarCredI_Click(object sender, EventArgs e)
        {
            if (bt_GuardarCredI.Text.Contains("Guardar"))
            {

                // MySQL
                bool argEncriptar = false;
                config.GuardarAtributo("", "EndpointInv", "Url", txt_urlInv.Text, ref argEncriptar);
                bool argEncriptar1 = false;
                config.GuardarAtributo("", "EndpointInv", "Token", txt_tokenI.Text, ref argEncriptar1);




                // Actualizar Variables
                CredEndI.url = txt_urlInv.Text;
                CredEndI.token = txt_tokenI.Text;


                txt_urlInv.Enabled = false;
                txt_tokenI.Enabled = false;



                Interaction.MsgBox("Credenciales Guardadas con Exito", MsgBoxStyle.Information, "Info");
                bt_GuardarCredI.Text = "Editar";
            }
            else if (bt_GuardarCredI.Text.Contains("Editar"))
            {

                txt_urlInv.Enabled = true;
                txt_tokenI.Enabled = true;



                bt_GuardarCredI.Text = "Guardar";

            }
        }

        private void B_AgregarFiltroCat_Click(object sender, EventArgs e)
        {
            DGV_FiltrosCatalogo.Rows.Add(cb_operadorCat.Text, cb_rpro_Cat.SelectedValue, cb_codicionCat.Text, txt_val_filt.Text);

            txt_val_filt.Text = "";
            cb_operadorCat.SelectedIndex = -1;
            cb_rpro_Cat.SelectedIndex = -1;
            cb_codicionCat.SelectedIndex = -1;
        }

        private void DGV_FiltrosCatalogo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (DGV_FiltrosCatalogo.SelectedRows.Count > 0)
                {
                    int index = DGV_FiltrosCatalogo.SelectedRows[0].Index;
                    DGV_FiltrosCatalogo.Rows.RemoveAt(index);
                }

                // e.Handled = True
            }
        }
        private List<NodoConAtributos> GetStoreListM(string sbs_no, ref CheckedListBox CheckedList)
        {
            var NodosTiendas = new List<NodoConAtributos>();

            if (CheckedList.Items.Count > 0)
            {

                StockConf.tiendas.Clear();
                for (int i = 0, loopTo = CheckedList.Items.Count - 1; i <= loopTo; i++)
                {
                    var NodoTienda = new NodoConAtributos();
                    var Latributos = new List<Campo>();

                    var Tienda = new Tienda();
                    if (CheckedList.GetItemChecked(i)) // SI ESTA SELECCIONADO
                    {

                        Latributos.Add(new Campo("sbs_no", sbs_no, false));
                        Latributos.Add(new Campo("store_no", Conversions.ToString(((dynamic)CheckedList.Items[i]).STORE_NO), false));

                        NodoTienda.Nombre = "Tienda";
                        NodoTienda.Atributos = Latributos;

                        NodosTiendas.Add(NodoTienda);

                        Tienda.sbs_no = sbs_no;
                        Tienda.store_no = Conversions.ToString(((dynamic)CheckedList.Items[i]).STORE_NO);
                        StockConf.tiendas.Add(Tienda);
                    }
                }
            }

            return NodosTiendas;
        }
        private List<NodoConAtributos> GetStoreListD(string sbs_no, ref CheckedListBox CheckedList)
        {
            var NodosTiendas = new List<NodoConAtributos>();

            if (CheckedList.Items.Count > 0)
            {

                ConfD.tiendasD.Clear();
                for (int i = 0, loopTo = CheckedList.Items.Count - 1; i <= loopTo; i++)
                {
                    var NodoTienda = new NodoConAtributos();
                    var Latributos = new List<Campo>();

                    var Tienda = new TiendaD();
                    if (CheckedList.GetItemChecked(i)) // SI ESTA SELECCIONADO
                    {

                        Latributos.Add(new Campo("sbs_no", sbs_no, false));
                        Latributos.Add(new Campo("store_no", Conversions.ToString(((dynamic)CheckedList.Items[i]).STORE_NO), false));

                        NodoTienda.Nombre = "Tienda";
                        NodoTienda.Atributos = Latributos;

                        NodosTiendas.Add(NodoTienda);

                        Tienda.sbs_no = sbs_no;
                        Tienda.store_no = Conversions.ToString(((dynamic)CheckedList.Items[i]).STORE_NO);
                        ConfD.tiendasD.Add(Tienda);
                    }
                }
            }

            return NodosTiendas;
        }
        private void B_SetConfCat_Filter_Click(object sender, EventArgs e)
        {
            if (B_SetConfCat_Filter.Text.Contains("Guardar"))
            {
                bool argencriptar = false;
                config.GuardarAtributo("Inventario.Filtros", "Activar", Conversions.ToString(CatConf.activar_filtros), ref argencriptar);

                if (cb_sbs_noM.Items.Count > 0)
                {
                    var argCheckedList = cb_list_storesM;
                    var NodosTiendas = GetStoreListM(Conversions.ToString(cb_sbs_noM.SelectedValue), ref argCheckedList);
                    cb_list_storesM = argCheckedList;

                    config.GuardarNodosConAtributos("", "Inventario", "Tiendas", NodosTiendas);
                }
                if (DGV_FiltrosCatalogo.Rows.Count > 0)
                {
                    var argFilasFiltro = DGV_FiltrosCatalogo;
                    var NodosFiltros = GetFilterCat(ref argFilasFiltro);
                    DGV_FiltrosCatalogo = argFilasFiltro;

                    config.GuardarNodosConAtributos("", "Inventario", "Filtros", NodosFiltros);
                }
                else
                {
                    var NodosFiltros = new List<NodoConAtributos>();
                    var NodoFiltro = new NodoConAtributos();
                    var Latributos = new List<Campo>();

                    Latributos.Add(new Campo("operador", "", false));
                    Latributos.Add(new Campo("campo_rpro", "", false));
                    Latributos.Add(new Campo("condicion", "", false));
                    Latributos.Add(new Campo("valor", "", false));


                    NodoFiltro.Nombre = "Filtro";
                    NodoFiltro.Atributos = Latributos;
                    NodosFiltros.Add(NodoFiltro);

                    config.GuardarNodosConAtributos("", "Inventario", "Filtros", NodosFiltros);
                    // Dim Filtro As New Filtro
                    // Filtro.operador = ""
                    // Filtro.campo_rpro = ""
                    // Filtro.condicion = ""
                    // Filtro.valor = ""
                    // CatConf.filtros.Add(Filtro)

                }

                GB_FilterI.Enabled = false;
                B_SetConfCat_Filter.Text = "Editar";

                Interaction.MsgBox("Campos de Filtros Guardados con Exito", MsgBoxStyle.Information, "Info");
            }
            else if (B_SetConfCat_Filter.Text.Contains("Editar"))
            {
                GB_FilterI.Enabled = true;
                B_SetConfCat_Filter.Text = "Guardar";
            }
        }
        private List<NodoConAtributos> GetFilterCat(ref DataGridView FilasFiltro)
        {
            var NodosFiltros = new List<NodoConAtributos>();

            if (FilasFiltro.Rows.Count > 0)
            {

                CatConf.filtros.Clear();

                foreach (DataGridViewRow fila in FilasFiltro.Rows)
                {
                    var NodoFiltro = new NodoConAtributos();
                    var Latributos = new List<Campo>();

                    Latributos.Add(new Campo("operador", Conversions.ToString(fila.Cells["fc_operador"].Value), false));
                    Latributos.Add(new Campo("campo_rpro", Conversions.ToString(fila.Cells["fc_campo_rpro"].Value), false));
                    Latributos.Add(new Campo("condicion", Conversions.ToString(fila.Cells["fc_condicion"].Value), false));
                    Latributos.Add(new Campo("valor", Conversions.ToString(fila.Cells["fc_valor"].Value), false));


                    NodoFiltro.Nombre = "Filtro";
                    NodoFiltro.Atributos = Latributos;
                    NodosFiltros.Add(NodoFiltro);

                    var Filtro = new Filtro();
                    Filtro.operador = Conversions.ToString(fila.Cells["fc_operador"].Value);
                    Filtro.campo_rpro = Conversions.ToString(fila.Cells["fc_campo_rpro"].Value);
                    Filtro.condicion = Conversions.ToString(fila.Cells["fc_condicion"].Value);
                    Filtro.valor = Conversions.ToString(fila.Cells["fc_valor"].Value);
                    CatConf.filtros.Add(Filtro);
                }


            }

            return NodosFiltros;
        }
        private List<NodoConAtributos> GetFilterCatD(ref DataGridView FilasFiltro)
        {
            var NodosFiltros = new List<NodoConAtributos>();

            if (FilasFiltro.Rows.Count > 0)
            {

                ConfD.filtros.Clear();

                foreach (DataGridViewRow fila in FilasFiltro.Rows)
                {
                    var NodoFiltro = new NodoConAtributos();
                    var Latributos = new List<Campo>();

                    Latributos.Add(new Campo("operador", Conversions.ToString(fila.Cells["fc_operadorD"].Value), false));
                    Latributos.Add(new Campo("campo_rpro", Conversions.ToString(fila.Cells["fc_campo_rproD"].Value), false));
                    Latributos.Add(new Campo("condicion", Conversions.ToString(fila.Cells["fc_condicionD"].Value), false));
                    Latributos.Add(new Campo("valor", Conversions.ToString(fila.Cells["fc_valorD"].Value), false));


                    NodoFiltro.Nombre = "Filtro";
                    NodoFiltro.Atributos = Latributos;
                    NodosFiltros.Add(NodoFiltro);

                    var Filtro = new Filtro();
                    Filtro.operador = Conversions.ToString(fila.Cells["fc_operadorD"].Value);
                    Filtro.campo_rpro = Conversions.ToString(fila.Cells["fc_campo_rproD"].Value);
                    Filtro.condicion = Conversions.ToString(fila.Cells["fc_condicionD"].Value);
                    Filtro.valor = Conversions.ToString(fila.Cells["fc_valorD"].Value);
                    ConfD.filtros.Add(Filtro);
                }


            }

            return NodosFiltros;
        }
        private void LlenarFiltros(ref List<Filtro> Filtros, List<NodoConAtributos> NFiltros)
        {
            if (NFiltros.Count > 0)
            {
                Filtros.Clear();

                foreach (NodoConAtributos Nfiltro in NFiltros)
                {
                    var filtro = new Filtro();
                    filtro.operador = Nfiltro.Atributos.Find(t => t.Nombre == "operador").Valor;
                    filtro.campo_rpro = Nfiltro.Atributos.Find(t => t.Nombre == "campo_rpro").Valor;
                    filtro.condicion = Nfiltro.Atributos.Find(t => t.Nombre == "condicion").Valor;
                    filtro.valor = Nfiltro.Atributos.Find(t => t.Nombre == "valor").Valor;

                    Filtros.Add(filtro);
                }
            }
        }
        private void LlenarVariablesCatFilter()
        {
            string str_activar = config.LeerAtributo("", "Inventario", "Filtros", "Activar", false);

            CatConf.activar_filtros = Conversions.ToBoolean(Interaction.IIf(str_activar.ToUpper() == "TRUE" | str_activar.ToUpper() == "FALSE", str_activar, false));

            var NodosFiltros = new List<NodoConAtributos>();
            NodosFiltros = config.LeerNodosConAtributos("", "Inventario", "Filtros", "Filtro");
            var argFiltros = CatConf.filtros;
            LlenarFiltros(ref argFiltros, NodosFiltros);
            CatConf.filtros = argFiltros;
        }

        // *********************************
        private void LlenarFiltrosD(ref List<Filtro> Filtros, List<NodoConAtributos> NFiltros)
        {
            if (NFiltros.Count > 0)
            {
                Filtros.Clear();

                foreach (NodoConAtributos Nfiltro in NFiltros)
                {
                    var filtro = new Filtro();
                    filtro.operador = Nfiltro.Atributos.Find(t => t.Nombre == "operador").Valor;
                    filtro.campo_rpro = Nfiltro.Atributos.Find(t => t.Nombre == "campo_rpro").Valor;
                    filtro.condicion = Nfiltro.Atributos.Find(t => t.Nombre == "condicion").Valor;
                    filtro.valor = Nfiltro.Atributos.Find(t => t.Nombre == "valor").Valor;

                    Filtros.Add(filtro);
                }
            }
        }
        private void LlenarVariablesCatFilterD()
        {
            string str_activar = config.LeerAtributo("", "InventarioDeltam", "Filtros", "Activar", false);

            ConfD.activar_filtros = Conversions.ToBoolean(Interaction.IIf(str_activar.ToUpper() == "TRUE" | str_activar.ToUpper() == "FALSE", str_activar, false));

            var NodosFiltros = new List<NodoConAtributos>();
            NodosFiltros = config.LeerNodosConAtributos("", "InventarioDeltam", "Filtros", "Filtro");
            var argFiltros = ConfD.filtros;
            LlenarFiltrosD(ref argFiltros, NodosFiltros);
            ConfD.filtros = argFiltros;
        }

        private void txt_previaInv_Click(object sender, EventArgs e)
        {
            if (archivo_config == true)
            {


                string Query = "";
                string QSelec;
                string QueryCamp = "";
                string QueryFrom;
                string QueryWhere = "";
                string QueryGroup = "GROUP BY ";

                QSelec = "SELECT A.* FROM ( SELECT ";

                string Store_no = "";

                Sbs_no = cb_sbs_noM.SelectedValue;
                if (cb_sbs_noM.Items.Count > 0)
                {
                    // Dim NodosTiendas As List(Of NodoConAtributos) = GetStoreListManual(cb_sbs_noM.SelectedValue, cb_list_storesM)
                    string str_tiendas = "";
                    foreach (TX_STORE_V item in cb_list_storesM.CheckedItems)
                        str_tiendas = str_tiendas + item.STORE_NO.ToString() + ",";
                    str_tiendas = str_tiendas.Remove(str_tiendas.Length - 1) + ") ";
                    Store_no = str_tiendas;
                }

                //string StringFiltros = "";

                //if (CatConf.filtros.Count > 0)
                //{

                //    foreach (Filtro filtro in CatConf.filtros)
                //    {
                //        StringFiltros += filtro.operador + " ";
                //        // StringFiltros = StringFiltros + filtro.operador + " "

                //        if (filtro.campo_rpro == "D")
                //        {
                //            StringFiltros = StringFiltros + "SUBSTR(DCS_CODE,0,3)";
                //        }
                //        else if (filtro.campo_rpro == "C")
                //        {
                //            StringFiltros = StringFiltros + "SUBSTR(DCS_CODE,4,3)";
                //        }
                //        else if (filtro.campo_rpro == "S")
                //        {
                //            StringFiltros = StringFiltros + "SUBSTR(DCS_CODE,7,3)";
                //        }
                //        else if (filtro.condicion == "IN")
                //        {
                //            StringFiltros += filtro.campo_rpro + " " + " IN (" + filtro.valor + ") ";
                //        }

                //        else
                //        {


                //            StringFiltros += filtro.campo_rpro + " " + filtro.condicion + "'" + filtro.valor + "' ";
                //        }


                //    }
                //}

                if (CatConf.Mapeos.Count > 0)
                {

                    //QueryCamp += string.Join(",", CatConf.Mapeos.Select(t => t.campo_rpro + " " + t.ecommerce + " ").ToList());

                    //if (CatConf.Mapeos.Exists(m => m.campo_rpro.Substring(0, 3) == "SUM"))
                    //{
                    //    QueryGroup += string.Join(",", CatConf.Mapeos.Where(g => g.campo_rpro.Substring(0, 3) != "SUM").Select(t => t.campo_rpro).ToList());
                    //}
                    //else
                    //{
                    //    QueryGroup += string.Join(",", CatConf.Mapeos.Select(t => t.campo_rpro).ToList());
                    //}
                    //QueryFrom = "from rps.invn_sbs_item i inner join rps.subsidiary sb on (i.sbs_sid=sb.sid) " + "inner join rps.store s on (sb.sid=s.sbs_sid) " + "inner join v_sociedades sc on (sb.sbs_no=sc.sbs_no) " + "inner join v_centros_almacen cc on (sb.sbs_no=cc.sbs_no and s.store_code=cc.store_code) " + "left join rps.invn_sbs_item_qty q on (i.sid=q.invn_sbs_item_sid and i.sbs_sid=q.sbs_sid and s.sid=q.store_sid) " + "";



                    //if (CatConf.activar_filtros)
                    //{

                    //    // QueryWhere = "WHERE 1=1 AND P.PRICE_LVL=" + Lvl_price + "  AND SB.SBS_NO=" + Sbs_no + " " + StringFiltros '" AND S.STORE_NO IN (" + Store_no + "  " + StringFiltros
                     //  QueryWhere = "where nvl(q.qty,0)>=0 AND SB.SBS_NO=" + Sbs_no.ToString() + " " + StringFiltros + " AND S.STORE_NO IN (" + Store_no;
                    //}
                    //else
                    //{
                    //    QueryWhere = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject("where nvl(q.qty,0)>=0 AND SB.SBS_NO=", Sbs_no), " AND S.STORE_NO IN ("), Store_no));
                    //}

                   // Query = QSelec + QueryCamp + QueryFrom + QueryWhere + QueryGroup + " ) A";
                    Query = GenerarConsultaInventario(Sbs_no.ToString(), Store_no, ref config);
                    // Query = QSelec + QueryCamp + QueryFrom + QueryWhere + QueryGroup + " ) A"
                    config.mylog("Panel Config", "Mensaje", "QUERY " + Query, true);


                    ora.Conexion = "DATA SOURCE=" + Credenciales.ip + ":" + Credenciales.puerto + "/" + Credenciales.db + ";PASSWORD=" + Credenciales.password + ";PERSIST SECURITY INFO=True;USER ID=" + Credenciales.usuario;

                    if (ora.Conectar().status)
                    {
                        // EJECUTAMOS LA QUERY DE CATALOGO
                        var conn = new OracleConnection(ora.Conexion);

                        conn.Open();

                        // Dim sql As String = "select dname from dept where deptno = 10" ' VB.NET
                        var cmd = new OracleCommand(Query, conn);
                        cmd.CommandType = CommandType.Text;
                        var dr = cmd.ExecuteReader();
                        var DataS = new DataSet();
                        if (dr.Read())
                        {
                            var da = new OracleDataAdapter(cmd);
                            da.Fill(DataS, "A");
                            dg_PreviaInv.DataSource = DataS.Tables["A"];

                        }
                    }
                    // HabilitaPlantillaCatalogo()


                    else
                    {
                        // HabilitaPlantillaCatalogo()
                        Interaction.MsgBox(ora.Conectar().message, MsgBoxStyle.Critical, "Error - Conexion");
                    }

                }
            }

            else
            {
                Interaction.MsgBox("Mapeo de campos no Encontrado", MsgBoxStyle.Critical, "Error - Archivo de Configuracion");
            }
        }

        private void cb_subsidiariaInv_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectNotEqual(num2, 0, false)))
            {
                if (cb_subsidiariaInv.SelectedValue is null)
                {
                }

                else
                {
                    var RspStoreSel = new ResponseCRpro9();
                    RspStoreSel = ora.ListarStores(short.Parse(Conversions.ToString(cb_subsidiariaInv.SelectedValue)), "oracle_10");
                    if (RspStoreSel.status)
                    {

                        cb_store_I.DataSource = RspStoreSel.result;
                        cb_store_I.DisplayMember = "DISPLAY";
                        cb_store_I.ValueMember = "STORE_NO";

                    }
                }



            }

            num2 = Operators.AddObject(num2, 1);
        }

        private void CHB_ActivarFiltrosCat_CheckedChanged(object sender, EventArgs e)
        {
            if (CHB_ActivarFiltrosCat.Checked)
            {
                CatConf.activar_filtros = true;
            }
            else
            {
                CatConf.activar_filtros = false;
            }
        }

        private void cb_sbs_noM_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(Operators.ConditionalCompareObjectGreater(num1, 1, false)))
            {
                if (cb_sbs_noM.SelectedValue is null)
                {
                }

                else
                {
                    var RspStoreSel = new ResponseCRpro9();
                    RspStoreSel = ora.ListarStores(short.Parse(Conversions.ToString(cb_sbs_noM.SelectedValue)), "oracle_10");
                    if (RspStoreSel.status)
                    {

                        cb_list_storesM.DataSource = RspStoreSel.result;
                        cb_list_storesM.DisplayMember = "DISPLAY";
                        cb_list_storesM.ValueMember = "STORE_NO";

                    }
                }



            }

            num1 = Operators.AddObject(num1, 1);
        }

        private void bt_ejecturarInv_Click(object sender, EventArgs e)
        {
            var ListaItem = new List<ElementItems>();
            foreach (DataGridViewRow row in dg_PreviaInv.Rows)
            {
                var item = new ElementItems
                {
                    sku = Convert.ToString(row.Cells["SKU"].Value),
                    id_sociedad = Convert.ToString(row.Cells["ID_SOCIEDAD"].Value),
                    id_centro = Convert.ToString(row.Cells["ID_CENTRO"].Value),
                    id_almacen = Convert.ToString(row.Cells["ID_ALMACEN"].Value),
                    qty = Convert.ToString(row.Cells["QTY"].Value)
                };

                ListaItem.Add(item);
            }

            try
            {
                if (ListaItem.Count > 0)
                {
                    var request = (HttpWebRequest)WebRequest.Create(CredEndI.url);
                    request.Method = "POST";
                    request.ContentType = "application/json; charset=utf-8";
                    request.Headers.Add("Authorization", "Bearer " + CredEndI.token);

                    config.mylog("Panel Config", "Mensaje", "url inventario " + CredEndI.url, true);

                    var lista_Art = ListaItem.GroupBy(i => i.sku).Select(s => s.First()).ToList();
                    var jsonData = new { stocks = lista_Art };
                    var json = JsonConvert.SerializeObject(jsonData);

                    config.mylog("Panel Config", "Mensaje", "JSON " + json, true);

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        config.mylog("Panel Config", "Mensaje", "StreamWriter ", true);
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    using (var httpResponse = (HttpWebResponse)request.GetResponse())
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string responseBody = streamReader.ReadToEnd();
                            // config.mylog("Panel Config", "responseBody", responseBody, True)
                            if (responseBody.Contains("Processing stocks"))
                            {
                                int contF = 0;
                                foreach (var artic in lista_Art)
                                {
                                    var dato = new DLK_CONTROL
                                    {
                                        ARTICULO_SAP = artic.sku,
                                        ID_SOCIEDAD = artic.id_sociedad,
                                        ID_CENTRO = artic.id_centro,
                                        ID_ALMACEN = artic.id_almacen,
                                        QTY = Conversions.ToDecimal(artic.qty)
                                    };

                                    var resultado = ora.GuardarArticulo(dato);
                                    if (!resultado.status)
                                    {
                                        config.mylog("Panel Config", "Error DB ORACLE", resultado.message, true);
                                    }

                                    contF++;
                                    if (contF == lista_Art.Count)
                                    {
                                        Interaction.MsgBox("Termina proceso de actualizacion de stock", MsgBoxStyle.Information, "Info");
                                    }
                                }
                            }
                            else
                            {
                                config.mylog("Panel Config", "Error ", responseBody, true);
                            }
                        }
                    }
                }
                else
                {
                    Interaction.MsgBox("No Hay Items para Procesar", MsgBoxStyle.Exclamation, "Error");
                    config.mylog("Panel Config", "Error", "No Hay Items para Procesar", true);
                }
            }
            catch (WebException ex)
            {
                config.mylog("Panel Config", "WebException", ex.Message, true);
            }
            catch (Exception ex)
            {
                config.mylog("Panel Config", "Exception", ex.Message, true);
            }
        }

        private void bt_agregarFiltrosD_Click(object sender, EventArgs e)
        {
            gv_filtrosD.Rows.Add(cb_operadorD.Text, cb_rproD.SelectedValue, cb_condicionD.Text, txt_valD.Text);

            txt_valD.Text = "";
            cb_operadorD.SelectedIndex = -1;
            cb_rproD.SelectedIndex = -1;
            cb_condicionD.SelectedIndex = -1;
        }

        private void B_SetConfCat_FilterD_Click(object sender, EventArgs e)
        {
            if (B_SetConfCat_FilterD.Text.Contains("Guardar"))
            {
                bool argencriptar = false;
                config.GuardarAtributo("InventarioDeltam.Filtros", "Activar", Conversions.ToString(ConfD.activar_filtros), ref argencriptar);

                if (cb_sbs_noD.Items.Count > 0)
                {
                    var argCheckedList = cb_list_storesD;
                    var NodosTiendas = GetStoreListD(Conversions.ToString(cb_sbs_noD.SelectedValue), ref argCheckedList);
                    cb_list_storesD = argCheckedList;

                    config.GuardarNodosConAtributos("", "InventarioDeltam", "Tiendas", NodosTiendas);
                }
                if (gv_filtrosD.Rows.Count > 0)
                {
                    var argFilasFiltro = gv_filtrosD;
                    var NodosFiltros = GetFilterCatD(ref argFilasFiltro);
                    gv_filtrosD = argFilasFiltro;

                    config.GuardarNodosConAtributos("", "InventarioDeltam", "Filtros", NodosFiltros);
                }
                else
                {
                    var NodosFiltros = new List<NodoConAtributos>();
                    var NodoFiltro = new NodoConAtributos();
                    var Latributos = new List<Campo>();

                    Latributos.Add(new Campo("operador", "", false));
                    Latributos.Add(new Campo("campo_rpro", "", false));
                    Latributos.Add(new Campo("condicion", "", false));
                    Latributos.Add(new Campo("valor", "", false));


                    NodoFiltro.Nombre = "Filtro";
                    NodoFiltro.Atributos = Latributos;
                    NodosFiltros.Add(NodoFiltro);

                    config.GuardarNodosConAtributos("", "InventarioDeltam", "Filtros", NodosFiltros);


                }

                GP_FilterD.Enabled = false;
                B_SetConfCat_FilterD.Text = "Editar";

                Interaction.MsgBox("Campos de Filtros Guardados con Exito", MsgBoxStyle.Information, "Info");
            }
            else if (B_SetConfCat_FilterD.Text.Contains("Editar"))
            {
                GP_FilterD.Enabled = true;
                B_SetConfCat_FilterD.Text = "Guardar";
            }
        }

        private void ch_activalFiltrosD_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_activalFiltrosD.Checked)
            {
                ConfD.activar_filtros = true;
            }
            else
            {
                ConfD.activar_filtros = false;
            }
        }

        private void ComboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bt_GuardarPrecios_Click(object sender, EventArgs e)
        {
            // Verificar si el botón está en modo "Guardar"
            if (bt_GuardarPrecios.Text.Contains("Guardar"))
            {
                // Obtener valores de los controles de la interfaz de usuario
                string urlPrecios = txt_urlPrecios.Text;
                string tokenPrecios = txt_tokenPrecios.Text;

                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(urlPrecios) || string.IsNullOrEmpty(tokenPrecios))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Actualizar Variables
                CredEndPrecios.url = txt_urlPrecios.Text;
                CredEndPrecios.token = txt_tokenPrecios.Text;

                // Guardar las credenciales en la configuración
                bool argEncriptarP = false;
                config.GuardarAtributo("", "EndpointPrecios", "Url", urlPrecios, ref argEncriptarP);
                config.GuardarAtributo("", "EndpointPrecios", "Token", tokenPrecios, ref argEncriptarP);

                // Mostrar mensaje de éxito
                MessageBox.Show("Credenciales de precios guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Deshabilitar los campos de entrada
                txt_urlPrecios.Enabled = false;
                txt_tokenPrecios.Enabled = false;

                // Cambiar el texto del botón a "Editar"
                bt_GuardarPrecios.Text = "Editar";
            }
            else if (bt_GuardarPrecios.Text.Contains("Editar"))
            {
                // Habilitar los campos de entrada
                txt_urlPrecios.Enabled = true;
                txt_tokenPrecios.Enabled = true;

                // Cambiar el texto del botón a "Guardar"
                bt_GuardarPrecios.Text = "Guardar";
            }
        }

        private void bt_GuardarMov_Click(object sender, EventArgs e)
        {
            // Verificar si el botón está en modo "Guardar"
            if (bt_GuardarMov.Text.Contains("Guardar"))
            {
                // Obtener valores de los controles de la interfaz de usuario
                string urlMovimientos = txt_urlMov.Text;
                string tokenMovimientos = txt_tokenMov.Text;

                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(urlMovimientos) || string.IsNullOrEmpty(tokenMovimientos))
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Actualizar Variables
                CredEndMov.url = txt_urlMov.Text;
                CredEndMov.token = txt_tokenMov.Text;

                // Guardar las credenciales en la configuración
                bool argEncriptarP = false;
                config.GuardarAtributo("", "EndpointMovimientos", "Url", urlMovimientos, ref argEncriptarP);
                config.GuardarAtributo("", "EndpointMovimientos", "Token", tokenMovimientos, ref argEncriptarP);

                // Mostrar mensaje de éxito
                MessageBox.Show("Credenciales de movimientos guardadas correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Deshabilitar los campos de entrada
                txt_urlMov.Enabled = false;
                txt_tokenMov.Enabled = false;

                // Cambiar el texto del botón a "Editar"
                bt_GuardarMov.Text = "Editar";
            }
            else if (bt_GuardarMov.Text.Contains("Editar"))
            {
                // Habilitar los campos de entrada
                txt_urlMov.Enabled = true;
                txt_tokenMov.Enabled = true;

                // Cambiar el texto del botón a "Guardar"
                bt_GuardarMov.Text = "Guardar";
            }
        }



        private void bt_ejecturarD_Click(object sender, EventArgs e)
        {
            var ListaItem = new List<ElementItems>();
            foreach (DataGridViewRow row in DataGridView1.Rows)
            {
                var item = new ElementItems
                {
                    sku = Convert.ToString(row.Cells["SKU"].Value),
                    id_sociedad = Convert.ToString(row.Cells["ID_SOCIEDAD"].Value),
                    id_centro = Convert.ToString(row.Cells["ID_CENTRO"].Value),
                    id_almacen = Convert.ToString(row.Cells["ID_ALMACEN"].Value),
                    qty = Convert.ToString(row.Cells["QTY"].Value)
                };

                ListaItem.Add(item);
            }

            try
            {
                if (ListaItem.Count > 0)
                {
                    var request = (HttpWebRequest)WebRequest.Create(CredEndI.url);
                    request.Method = "POST";
                    request.ContentType = "application/json; charset=utf-8";
                    request.Headers.Add("Authorization", "Bearer " + CredEndI.token);

                    config.mylog("Panel Config", "Mensaje", "url inventario " + CredEndI.url, true);

                    var lista_Art = ListaItem.GroupBy(i => i.sku).Select(s => s.First()).ToList();
                    var jsonData = new { stocks = lista_Art };
                    var json = JsonConvert.SerializeObject(jsonData);

                    config.mylog("Panel Config", "Mensaje", "JSON " + json, true);

                    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                    {
                        config.mylog("Panel Config", "Mensaje", "StreamWriter ", true);
                        streamWriter.Write(json);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    using (var httpResponse = (HttpWebResponse)request.GetResponse())
                    {
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string responseBody = streamReader.ReadToEnd();
                            // config.mylog("Panel Config", "responseBody", responseBody, True)
                            if (responseBody.Contains("Processing stocks"))
                            {
                                int contF = 0;
                                foreach (var artic in lista_Art)
                                {
                                    var dato = new DLK_CONTROL
                                    {
                                        ARTICULO_SAP = artic.sku,
                                        ID_SOCIEDAD = artic.id_sociedad,
                                        ID_CENTRO = artic.id_centro,
                                        ID_ALMACEN = artic.id_almacen,
                                        QTY = Conversions.ToDecimal(artic.qty)
                                    };

                                    var resultado = ora.GuardarArticulo(dato);
                                    if (!resultado.status)
                                    {
                                        config.mylog("Panel Config", "Error DB ORACLE", resultado.message, true);
                                    }

                                    contF++;
                                    if (contF == lista_Art.Count)
                                    {
                                        Interaction.MsgBox("Termina proceso de actualizacion de stock", MsgBoxStyle.Information, "Info");
                                    }
                                }
                            }
                            else
                            {
                                config.mylog("Panel Config", "Error ", responseBody, true);
                            }
                        }
                    }
                }
                else
                {
                    Interaction.MsgBox("No Hay Items para Procesar", MsgBoxStyle.Exclamation, "Error");
                    config.mylog("Panel Config", "Error", "No Hay Items para Procesar", true);
                }
            }
            catch (WebException ex)
            {
                config.mylog("Panel Config", "WebException", ex.Message, true);
            }
            catch (Exception ex)
            {
                config.mylog("Panel Config", "Exception", ex.Message, true);
            }
        }


        public string GenerarConsultaInventario(string Sbs_no, string Store_no, ref CConfig config)
        {
            try
            {
                var Query = "";
                var QSelec = "";
                var QueryCamp = "";
                var QueryFrom = "";
                var QueryWhere = "";
                var QueryGroup = "GROUP BY ";

                QSelec = "SELECT A.* FROM ( SELECT ";

                QueryCamp += string.Join(",", CatConf.Mapeos.Where(t => t.tipo.Equals("Inventario")).Select(t => t.campo_rpro + " " + t.ecommerce + " ").ToList());
                QueryGroup += string.Join(",", CatConf.Mapeos.Where(t => t.tipo.Equals("Inventario")).Select(t => t.campo_rpro).ToList());

                QueryFrom = "from rps.invn_sbs_item i inner join rps.subsidiary sb on (i.sbs_sid=sb.sid) " +
                             "inner join rps.store s on (sb.sid=s.sbs_sid) " +
                             "inner join v_sociedades sc on (sb.sbs_no=sc.sbs_no) " +
                             "inner join v_centros_almacen cc on (sb.sbs_no=cc.sbs_no and s.store_code=cc.store_code) " +
                             "left join rps.invn_sbs_item_qty q on (i.sid=q.invn_sbs_item_sid and i.sbs_sid=q.sbs_sid and s.sid=q.store_sid) ";

                string StringFiltros = "";

                // Lógica para construir StringFiltros
                if (CatConf.filtros.Count > 0)
                {
                    foreach (Filtro filtro in CatConf.filtros)
                    {
                        StringFiltros += filtro.operador + " ";

                        if (filtro.campo_rpro == "D")
                        {
                            StringFiltros += "SUBSTR(DCS_CODE,0,3)";
                        }
                        else if (filtro.campo_rpro == "C")
                        {
                            StringFiltros += "SUBSTR(DCS_CODE,4,3)";
                        }
                        else if (filtro.campo_rpro == "S")
                        {
                            StringFiltros += "SUBSTR(DCS_CODE,7,3)";
                        }
                        else if (filtro.condicion == "IN")
                        {
                            StringFiltros += filtro.campo_rpro + " IN (" + filtro.valor + ") ";
                        }
                        else
                        {
                            StringFiltros += filtro.campo_rpro + " " + filtro.condicion + " '" + filtro.valor + "' ";
                        }
                    }
                }

                // Construcción de QueryWhere
                QueryWhere = "WHERE 1=1 AND q.qty >= 0 AND i.upc = 194497882451 AND SB.SBS_NO = " + Sbs_no +
                             " AND S.STORE_NO IN (" + Store_no + ") " +
                             (StringFiltros.Trim().Length > 0 ? " AND " + StringFiltros : "");


                Query = QSelec + QueryCamp + QueryFrom + QueryWhere + QueryGroup + " ) A";

                config.mylog("InventComp", "Mensaje", "QUERY " + Query, true);

                return Query;
            }
            catch (Exception ex)
            {
                config.mylog("GenerarConsultaInventario", "Error", ex.Message, true);
                return string.Empty;
            }
        }

        public  string GenerarConsultaDelta( string Sbs_no, string Store_no, ref CConfig config)
        {
            try
            {
                // Definición de la consulta
                var Query = "";
                var QSelec = "";
                var QueryCamp = "";
                var QueryFrom = "";
                var QueryWhere = "";
                var QueryGroup = "GROUP BY ";
                QSelec = "SELECT A.* FROM ( SELECT ";
                QueryFrom = "from rps.invn_sbs_item i inner join rps.subsidiary sb on (i.sbs_sid=sb.sid) " +
                               "inner join rps.store s on (sb.sid=s.sbs_sid) " +
                               "inner join v_sociedades sc on (sb.sbs_no=sc.sbs_no) " +
                               "inner join v_centros_almacen cc on (sb.sbs_no=cc.sbs_no and s.store_code=cc.store_code) " +
                               "left join rps.invn_sbs_item_qty q on (i.sid=q.invn_sbs_item_sid and i.sbs_sid=q.sbs_sid and s.sid=q.store_sid) " +
                               "left join dl_control_inv li on (i.description3=li.sku and SC.COD_SOCIEDAD=li.id_sociedad and CC.CENTRO=li.id_centro and CC.ALMACEN=li.id_almacen) ";

                // Construcción de la cláusula WHERE
                // Inicializa StringFiltros
                string StringFiltros = "";

                // Lógica para construir StringFiltros
                if (CatConf.filtros.Count > 0)
                {
                    foreach (Filtro filtro in CatConf.filtros)
                    {
                        StringFiltros += filtro.operador + " ";

                        if (filtro.campo_rpro == "D")
                        {
                            StringFiltros += "SUBSTR(DCS_CODE,0,3)";
                        }
                        else if (filtro.campo_rpro == "C")
                        {
                            StringFiltros += "SUBSTR(DCS_CODE,4,3)";
                        }
                        else if (filtro.campo_rpro == "S")
                        {
                            StringFiltros += "SUBSTR(DCS_CODE,7,3)";
                        }
                        else if (filtro.condicion == "IN")
                        {
                            StringFiltros += filtro.campo_rpro + " IN (" + filtro.valor + ") ";
                        }
                        else
                        {
                            StringFiltros += filtro.campo_rpro + " " + filtro.condicion + " '" + filtro.valor + "' ";
                        }
                    }
                }

                // Construcción de la cláusula WHERE
                QueryWhere = "WHERE nvl(q.qty,0) >= 0 AND nvl(q.qty,0) <> nvl(li.qty,0) AND i.upc = 194497882451 " +
                             "AND SB.SBS_NO = " + Sbs_no + " AND S.STORE_NO IN (" + Store_no + ") " +
                             (StringFiltros.Trim().Length > 0 ? " AND " + StringFiltros : "");

                // Construcción de la cláusula GROUP BY
                QueryCamp += string.Join(",", CatConf.Mapeos.Where(t => t.tipo.Equals("Inventario")).Select(t => t.campo_rpro + " " + t.ecommerce + " ").ToList());
                QueryGroup += string.Join(",", CatConf.Mapeos.Where(t => t.tipo.Equals("Inventario")).Select(t => t.campo_rpro).ToList());

                // Combinación de todas las partes de la consulta
                Query = QSelec + QueryCamp + QueryFrom + QueryWhere + QueryGroup + " ) A";

                // Registro de la consulta generada
                config.mylog("InventComp", "Mensaje", "QUERY " + Query, true);

                return Query;
            }
            catch (Exception ex)
            {
                config.mylog("GenerarConsultaDelta", "Error", ex.Message, true);
                return string.Empty;
            }
        }

        private void bt_previaD_Click(object sender, EventArgs e)
        {
            if (archivo_config == true)
            {


                string Query = "";
                string QSelec;
                string QueryCamp = "";
                string QueryFrom;
                string QueryWhere = "";
                string QueryGroup = "GROUP BY ";

                QSelec = "SELECT A.* FROM ( SELECT ";

                string Store_no = "";

                Sbs_no = cb_sbs_noM.SelectedValue;
                if (cb_sbs_noM.Items.Count > 0)
                {
                    // Dim NodosTiendas As List(Of NodoConAtributos) = GetStoreListManual(cb_sbs_noM.SelectedValue, cb_list_storesM)
                    string str_tiendas = "";
                    foreach (TX_STORE_V item in cb_list_storesM.CheckedItems)
                        str_tiendas = str_tiendas + item.STORE_NO.ToString() + ",";
                    str_tiendas = str_tiendas.Remove(str_tiendas.Length - 1) + ") ";
                    Store_no = str_tiendas;
                }

           

                if (CatConf.Mapeos.Count > 0)
                {

                   
                    Query = GenerarConsultaDelta(Sbs_no.ToString(), Store_no, ref config);
                    // Query = QSelec + QueryCamp + QueryFrom + QueryWhere + QueryGroup + " ) A"
                    config.mylog("Panel Config", "Mensaje", "QUERY " + Query, true);


                    ora.Conexion = "DATA SOURCE=" + Credenciales.ip + ":" + Credenciales.puerto + "/" + Credenciales.db + ";PASSWORD=" + Credenciales.password + ";PERSIST SECURITY INFO=True;USER ID=" + Credenciales.usuario;

                    if (ora.Conectar().status)
                    {
                        // EJECUTAMOS LA QUERY DE CATALOGO
                        var conn = new OracleConnection(ora.Conexion);

                        conn.Open();

                        // Dim sql As String = "select dname from dept where deptno = 10" ' VB.NET
                        var cmd = new OracleCommand(Query, conn);
                        cmd.CommandType = CommandType.Text;
                        var dr = cmd.ExecuteReader();
                        var DataS = new DataSet();
                        if (dr.Read())
                        {
                            var da = new OracleDataAdapter(cmd);
                            da.Fill(DataS, "A");
                            DataGridView1.DataSource = DataS.Tables["A"];

                        }
                    }
                


                    else
                    {
            
                        Interaction.MsgBox(ora.Conectar().message, MsgBoxStyle.Critical, "Error - Conexion");
                    }

                }
            }

            else
            {
                Interaction.MsgBox("Mapeo de campos no Encontrado", MsgBoxStyle.Critical, "Error - Archivo de Configuracion");
            }
        }

        private void btnSaveEmailConfig_Click(object sender, EventArgs e)
        {
            // Verificar si el botón está en modo "Guardar"
            if (btnSaveEmailConfig.Text.Contains("Guardar"))
            {
                // Guardar en el archivo XML
                bool argEncriptar = false;

                config.GuardarAtributo("", "EmailConfig", "SmtpServer", txtSmtpServer.Text, ref argEncriptar);
                config.GuardarAtributo("", "EmailConfig", "Port", txtPort.Text, ref argEncriptar);
                config.GuardarAtributo("", "EmailConfig", "Username", txtUsername.Text, ref argEncriptar);

                // Guardar la lista de correos
                string[] correos = txtRecipientEmails.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                string listaCorreos = string.Join(";", correos.Select(c => c.Trim())); // Usar un separador como ";"
                config.GuardarAtributo("", "EmailConfig", "RecipientEmails", listaCorreos, ref argEncriptar);

                MessageBox.Show("Configuración de correo guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Deshabilitar los campos de entrada
                txtSmtpServer.Enabled = false;
                txtPort.Enabled = false;
                txtUsername.Enabled = false;
                txtRecipientEmails.Enabled = false; // Deshabilitar el campo de correos

                // Cambiar el texto del botón a "Editar"
                btnSaveEmailConfig.Text = "Editar";
            }
            else if (btnSaveEmailConfig.Text.Contains("Editar"))
            {
                // Habilitar los campos de entrada
                txtSmtpServer.Enabled = true;
                txtPort.Enabled = true;
                txtUsername.Enabled = true;
                txtRecipientEmails.Enabled = true; // Habilitar el campo de correos

                // Cambiar el texto del botón a "Guardar"
                btnSaveEmailConfig.Text = "Guardar";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Llamar a ObtenerPrecios para ejecutar y enviar la información
            ObtenerPrecios(Sbs_noM.ToString(), cb_store_I.SelectedValue.ToString(), true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Llamar a ObtenerPrecios para mostrar la previa
            ObtenerPrecios(Sbs_noM.ToString(), cb_store_I.SelectedValue.ToString(), false);
        }

        private void ObtenerPrecios(string Sbs_no, string Store_no, bool enviarDatos = false)
        {
            try
            {
                config.mylog("Serv_Datalake", "Mensaje", "Ingreso a funcion de ObtenerPrecios", true);
                Funciones FunDB = new Funciones();
                List<ElementItems> ListaItem = new List<ElementItems>();

                FunDB.Conexion = "DATA SOURCE=" + Credenciales.ip + ":" + Credenciales.puerto + "/" + Credenciales.db + ";PASSWORD=" + Credenciales.password + ";PERSIST SECURITY INFO=True;USER ID=" + Credenciales.usuario;

                ResponseCRpro9 RespCon = FunDB.Conectar();
                if (RespCon.status)
                {
                    var Query = "";
                    var QSelec = "SELECT A.* FROM ( SELECT ";
                    var QueryCamp = "";
                    var QueryFrom = "";
                    var QueryWhere = "";
                    var QueryGroup = "GROUP BY ";

                    // Suponiendo que CatConf.Mapeos tiene los campos necesarios para la selección
                    if (CatConf.Mapeos.Count > 0)
                    {
                        // Construcción de los campos seleccionados
                        QueryCamp += string.Join(", ", CatConf.Mapeos.Select(t => $"I.{t.campo_rpro} AS {t.ecommerce}").ToList());

                        // Agregar campos fijos a la selección
                        QueryCamp += ", SC.COD_SOCIEDAD AS id_sociedad, ";
                        QueryCamp += "CC.CENTRO AS id_centro, ";
                        QueryCamp += "CC.ALMACEN AS id_almacen, ";
                        QueryCamp += "NVL(Q.QTY, 0) AS qty, ";
                        QueryCamp += "p.PRICE, ";
                        QueryCamp += "NVL(MIN((SELECT pp.price FROM rps.invn_sbs_price pp " +
                                      "INNER JOIN RPS.price_level pl ON (pp.price_lvl_sid = pl.sid AND pp.sbs_sid = pl.sbs_sid) " +
                                      "WHERE pl.price_lvl = 2 AND pp.invn_sbs_item_sid = i.sid)), 0) AS PRICE2 ";

                        // Construcción de la parte FROM
                        QueryFrom = "FROM rps.invn_sbs_item i " +
                                     "INNER JOIN rps.subsidiary sb ON (i.sbs_sid = sb.sid) " +
                                     "INNER JOIN rps.store s ON (sb.sid = s.sbs_sid) " +
                                     "INNER JOIN v_sociedades sc ON (sb.sbs_no = sc.sbs_no) " +
                                     "INNER JOIN v_centros_almacen cc ON (sb.sbs_no = cc.sbs_no AND s.store_code = cc.store_code) " +
                                     "LEFT JOIN rps.invn_sbs_item_qty q ON (i.sid = q.invn_sbs_item_sid AND i.sbs_sid = q.sbs_sid AND s.sid = q.store_sid) " +
                                     "LEFT JOIN rps.invn_sbs_price p ON (p.invn_sbs_item_sid = i.sid AND p.sbs_sid = i.sbs_sid AND p.price_lvl_sid = sb.active_price_lvl_sid) ";

                        // Construcción de la parte WHERE
                        QueryWhere = "WHERE NVL(q.qty, 0) >= 0 AND SB.SBS_NO = " + Sbs_no + " AND S.STORE_NO IN (" + Store_no + ") ";

                        // Construcción de la parte GROUP BY
                        QueryGroup += string.Join(", ", CatConf.Mapeos.Select(t => $"I.{t.campo_rpro}").ToList());
                        QueryGroup += ", SC.COD_SOCIEDAD, CC.CENTRO, CC.ALMACEN, NVL(Q.QTY, 0), p.PRICE ";

                        // Construcción de la consulta final
                        Query = QSelec + QueryCamp + QueryFrom + QueryWhere + QueryGroup + " ) A";

                        // Registro de la consulta
                        config.mylog("Precios", "Mensaje", "QUERY " + Query, true);

                        using (OracleConnection conn = new OracleConnection(FunDB.Conexion))
                        {
                            conn.Open();
                            using (OracleCommand comV = new OracleCommand(Query, conn))
                            {
                                using (OracleDataReader regV = comV.ExecuteReader())
                                {
                                    DataTable dt = new DataTable();
                                    dt.Load(regV);
                                    dgv_configuracionPrecios.DataSource = dt; // Si se debe enviar los datos al endpoint
                                    if (enviarDatos)
                                    {
                                        foreach (DataRow row in dt.Rows)
                                        {
                                            ElementItems item = new ElementItems
                                            {
                                                sku = row["SKU"].ToString(),
                                                id_sociedad = row["ID_SOCIEDAD"].ToString(),
                                                original_price = row["PRICE"].ToString(),
                                                regular_price = row["PRICE2"].ToString(),
                                                id_centro = row["ID_CENTRO"].ToString(),
                                                id_almacen = row["ID_ALMACEN"].ToString(),
                                                qty = row["QTY"].ToString()
                                            };
                                            ListaItem.Add(item);
                                        }

                                        // Enviar la información al endpoint
                                        var request = (HttpWebRequest)WebRequest.Create(CredEndPrecios.url);
                                        request.Method = "POST";
                                        request.ContentType = "application/json; charset=utf-8";
                                        request.Headers.Add("Authorization", "Bearer " + CredEndPrecios.token);

                                        var jsonData = new { stocks = ListaItem };
                                        string json = JsonConvert.SerializeObject(jsonData, Newtonsoft.Json.Formatting.Indented);

                                        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                                        {
                                            streamWriter.Write(json);
                                            streamWriter.Flush();
                                            streamWriter.Close();
                                        }

                                        using (HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse())
                                        {
                                            using (Stream streamReader = httpResponse.GetResponseStream())
                                            {
                                                using (StreamReader objReader = new StreamReader(streamReader))
                                                {
                                                    var responseBody = objReader.ReadToEnd();
                                                    config.mylog("Precios", "Mensaje", "Respuesta del endpoint: " + responseBody, true);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No hay mapeos disponibles para la consulta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                config.mylog("Precios", "Error", "Ocurrió un error: " + ex.Message, true);
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnviarCorreoPrueba_Click(object sender, EventArgs e)
        {
            try
            {
                // Cargar la configuración de correo
                var emailConfig = new EmailConfig
                {
                    Username = config.LeerAtributo("", "", "EmailConfig", "Username", false),
                    Port = Convert.ToInt32(config.LeerAtributo("", "", "EmailConfig", "Port", false)),
                    SmtpServer = config.LeerAtributo("", "", "EmailConfig", "SmtpServer", false),
                    RecipientEmails = config.LeerAtributo("", "", "EmailConfig", "RecipientEmails", false)
                                        .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(d => d.Trim())
                                        .ToList()
                };

                // Validar que la configuración no esté vacía
                if (string.IsNullOrEmpty(emailConfig.Username) ||
                    string.IsNullOrEmpty(emailConfig.SmtpServer) ||
                    emailConfig.Port <= 0 ||
                    emailConfig.RecipientEmails.Count == 0)
                {
                    config.mylog("EnviarCorreoPrueba", "Error", "La configuración de correo está incompleta o es inválida.", true);
                    return;
                }

                // Asunto del correo de prueba
                string asunto = "Correo de Prueba";

                // Generar el cuerpo del correo de prueba
                string cuerpo = GenerarCuerpoCorreoPrueba();

                // Enviar el correo de prueba
                EnviarCorreo(emailConfig, asunto, cuerpo, config);
            }
            catch (FormatException formatEx)
            {
                config.mylog("EnviarCorreoPrueba", "Error", "Error al convertir la configuración: " + formatEx.Message, true);
            }
            catch (Exception ex)
            {
                config.mylog("EnviarCorreoPrueba", "Error", "Error inesperado: " + ex.Message, true);
            }
        }

        public void EnviarCorreo(EmailConfig emailConfig, string asunto, string cuerpo, CConfig config)
        {
            try
            {
                // Validar que el correo no sea nulo o vacío
                if (string.IsNullOrEmpty(emailConfig.Username))
                {
                    config.mylog("EnviarCorreo", "Error", "El correo electrónico no puede ser nulo o vacío.", true);
                    return;
                }

                // Validar que el correo tenga una estructura válida (Gmail o Microsoft)
                if (!emailConfig.Username.EndsWith("@gmail.com") &&
                    !emailConfig.Username.EndsWith("@outlook.com") &&
                    !emailConfig.Username.EndsWith("@hotmail.com"))
                {
                    config.mylog("EnviarCorreo", "Error", "El correo electrónico debe ser de Gmail o Microsoft.", true);
                    return;
                }

                // Crear el cliente SMTP para Gmail
                using (var client = new SmtpClient(emailConfig.SmtpServer, emailConfig.Port)) // Usando el servidor de Gmail Relay
                {
                    client.EnableSsl = false; // Cambiar a true si usas STARTTLS
                    client.Timeout = 30000; // Tiempo de espera

                    // Configura las credenciales del cliente SMTP
                    client.Credentials = new NetworkCredential(emailConfig.Username, "tu_contraseña"); // Reemplaza con la contraseña real

                    // Crear el mensaje de correo
                    using (var mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress(emailConfig.Username);
                        mailMessage.Subject = asunto;
                        mailMessage.Body = cuerpo;
                        mailMessage.IsBodyHtml = true; // Configura si el cuerpo del correo es HTML

                        // Agregar la lista de destinatarios
                        foreach (var destinatario in emailConfig.RecipientEmails)
                        {
                            mailMessage.To.Add(destinatario);
                        }

                        // Enviar el correo
                        client.Send(mailMessage);
                        config.mylog("EnviarCorreo", "Mensaje", "Correo enviado exitosamente a " + string.Join(", ", emailConfig.RecipientEmails), true);
                    }
                }
            }
            catch (Exception emailEx)
            {
                // Manejo de errores al enviar el correo
                config.mylog("EnviarCorreo", "Error", "Error al enviar correo: " + emailEx.Message, true);
            }
        }

        private string GenerarCuerpoCorreoPrueba()
        {
            StringBuilder cuerpo = new StringBuilder();
            cuerpo.Append("<h2>Este es un Correo de Prueba</h2>");
            cuerpo.Append($"<p>Fecha: {DateTime.Now}</p>");
            cuerpo.Append("<p>Este es un mensaje de prueba para verificar la configuración de envío de correos.</p>");
            cuerpo.Append("<p>Si recibes este correo, la configuración es correcta.</p>");
            return cuerpo.ToString();
        }
    }
}