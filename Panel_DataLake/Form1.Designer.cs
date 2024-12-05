using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Panel_DataLake
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class Form1 : Form
    {

        /// <summary>
        /// Libera los recursos no administrados que utiliza el <see cref="Form1"/> y, de forma opcional, libera los recursos administrados.
        /// </summary>
        /// <param name="disposing">true para liberar tanto los recursos administrados como los no administrados; false para liberar solo los recursos no administrados.</param>
        [DebuggerNonUserCode()]

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is not null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Requerido por el Diseñador de Windows Forms
        private System.ComponentModel.IContainer components;

        // NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
        // Se puede modificar usando el Diseñador de Windows Forms.  
        // No lo modifique con el editor de código.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TabPage9 = new System.Windows.Forms.TabPage();
            this.TabControl2 = new System.Windows.Forms.TabControl();
            this.TabPage6 = new System.Windows.Forms.TabPage();
            this.bt_agregarTieI = new System.Windows.Forms.Button();
            this.dgv_tiendas_tiemposI = new System.Windows.Forms.DataGridView();
            this.fc_sbs_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_store_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_lunes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_hora_lu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_martes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_hora_ma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_miercoles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_hora_Mi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_jueves = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_hora_Ju = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_viernes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_hora_Vi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_sabado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_hora_Sa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_domingo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_hora_do = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_tiempo = new System.Windows.Forms.TextBox();
            this.Label30 = new System.Windows.Forms.Label();
            this.txt_notiMail_Inv = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.cb_hSa = new System.Windows.Forms.ComboBox();
            this.cb_hVie = new System.Windows.Forms.ComboBox();
            this.cb_hJue = new System.Windows.Forms.ComboBox();
            this.cb_hMi = new System.Windows.Forms.ComboBox();
            this.cb_hMar = new System.Windows.Forms.ComboBox();
            this.Label37 = new System.Windows.Forms.Label();
            this.Label36 = new System.Windows.Forms.Label();
            this.Label35 = new System.Windows.Forms.Label();
            this.Label34 = new System.Windows.Forms.Label();
            this.Label33 = new System.Windows.Forms.Label();
            this.Label32 = new System.Windows.Forms.Label();
            this.cb_hLun = new System.Windows.Forms.ComboBox();
            this.cb_interfazD = new System.Windows.Forms.ComboBox();
            this.cb_interfazS = new System.Windows.Forms.ComboBox();
            this.cb_interfazV = new System.Windows.Forms.ComboBox();
            this.cb_interfazJ = new System.Windows.Forms.ComboBox();
            this.cb_interfazMI = new System.Windows.Forms.ComboBox();
            this.cb_interfazM = new System.Windows.Forms.ComboBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label12 = new System.Windows.Forms.Label();
            this.cb_interfazL = new System.Windows.Forms.ComboBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.cb_tiempoInv = new System.Windows.Forms.ComboBox();
            this.bt_guardarConfInv = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.cb_store_I = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.cb_subsidiariaInv = new System.Windows.Forms.ComboBox();
            this.TabPage7 = new System.Windows.Forms.TabPage();
            this.bt_GuardarMapI = new System.Windows.Forms.Button();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.cb_mapeo_tipo = new System.Windows.Forms.ComboBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.bt_agregarI = new System.Windows.Forms.Button();
            this.txt_dalake_campI = new System.Windows.Forms.TextBox();
            this.cb_rpro_campI = new System.Windows.Forms.ComboBox();
            this.dgv_mapeoInventario = new System.Windows.Forms.DataGridView();
            this.mc_campo_rpro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc_datalake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mc_tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabPageCorreo = new System.Windows.Forms.TabPage();
            this.btnSendTestEmail = new System.Windows.Forms.Button();
            this.lblRecipientEmails = new System.Windows.Forms.Label();
            this.txtRecipientEmails = new System.Windows.Forms.TextBox();
            this.lblSmtpServer = new System.Windows.Forms.Label();
            this.txtSmtpServer = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btnSaveEmailConfig = new System.Windows.Forms.Button();
            this.TabPage5 = new System.Windows.Forms.TabPage();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_db_con = new System.Windows.Forms.ComboBox();
            this.Label31 = new System.Windows.Forms.Label();
            this.bt_guardar_db = new System.Windows.Forms.Button();
            this.bt_test_db = new System.Windows.Forms.Button();
            this.txt_pass_db = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txt_user_db = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txt_port_db = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txt_db_name = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txt_host_db = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.bt_GuardarPrecios = new System.Windows.Forms.Button();
            this.txt_tokenPrecios = new System.Windows.Forms.TextBox();
            this.Label41 = new System.Windows.Forms.Label();
            this.txt_urlPrecios = new System.Windows.Forms.TextBox();
            this.Label42 = new System.Windows.Forms.Label();
            this.TabPage2 = new System.Windows.Forms.TabPage();
            this.TabControl4 = new System.Windows.Forms.TabControl();
            this.TabPage11 = new System.Windows.Forms.TabPage();
            this.B_SetConfCat_FilterD = new System.Windows.Forms.Button();
            this.GP_EjecD = new System.Windows.Forms.GroupBox();
            this.bt_ejecturarD = new System.Windows.Forms.Button();
            this.cb_list_storesD = new System.Windows.Forms.CheckedListBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.cb_sbs_noD = new System.Windows.Forms.ComboBox();
            this.bt_previaD = new System.Windows.Forms.Button();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.GP_FilterD = new System.Windows.Forms.GroupBox();
            this.gv_filtrosD = new System.Windows.Forms.DataGridView();
            this.fc_operadorD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_campo_rproD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_condicionD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_valorD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label26 = new System.Windows.Forms.Label();
            this.Label27 = new System.Windows.Forms.Label();
            this.Label28 = new System.Windows.Forms.Label();
            this.Label29 = new System.Windows.Forms.Label();
            this.bt_agregarFiltrosD = new System.Windows.Forms.Button();
            this.cb_condicionD = new System.Windows.Forms.ComboBox();
            this.cb_operadorD = new System.Windows.Forms.ComboBox();
            this.ch_activalFiltrosD = new System.Windows.Forms.CheckBox();
            this.txt_valD = new System.Windows.Forms.TextBox();
            this.cb_rproD = new System.Windows.Forms.ComboBox();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.TabControl3 = new System.Windows.Forms.TabControl();
            this.TabPage10 = new System.Windows.Forms.TabPage();
            this.B_SetConfCat_Filter = new System.Windows.Forms.Button();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.bt_ejecturarInv = new System.Windows.Forms.Button();
            this.cb_list_storesM = new System.Windows.Forms.CheckedListBox();
            this.Subsidiaria = new System.Windows.Forms.Label();
            this.cb_sbs_noM = new System.Windows.Forms.ComboBox();
            this.txt_previaInv = new System.Windows.Forms.Button();
            this.dg_PreviaInv = new System.Windows.Forms.DataGridView();
            this.GB_FilterI = new System.Windows.Forms.GroupBox();
            this.DGV_FiltrosCatalogo = new System.Windows.Forms.DataGridView();
            this.fc_operador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_campo_rpro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fc_valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label25 = new System.Windows.Forms.Label();
            this.Label24 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.B_AgregarFiltroCat = new System.Windows.Forms.Button();
            this.cb_codicionCat = new System.Windows.Forms.ComboBox();
            this.cb_operadorCat = new System.Windows.Forms.ComboBox();
            this.CHB_ActivarFiltrosCat = new System.Windows.Forms.CheckBox();
            this.txt_val_filt = new System.Windows.Forms.TextBox();
            this.cb_rpro_Cat = new System.Windows.Forms.ComboBox();
            this.TabPage8 = new System.Windows.Forms.TabPage();
            this.bt_GuardarCredI = new System.Windows.Forms.Button();
            this.txt_tokenI = new System.Windows.Forms.TextBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.txt_urlInv = new System.Windows.Forms.TextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TabControl5 = new System.Windows.Forms.TabControl();
            this.TabPage12 = new System.Windows.Forms.TabPage();
            this.bt_GuardarMov = new System.Windows.Forms.Button();
            this.txt_tokenMov = new System.Windows.Forms.TextBox();
            this.Label39 = new System.Windows.Forms.Label();
            this.txt_urlMov = new System.Windows.Forms.TextBox();
            this.Label40 = new System.Windows.Forms.Label();
            this.TabPage13 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dgv_configuracionPrecios = new System.Windows.Forms.DataGridView();
            this.TabPage9.SuspendLayout();
            this.TabControl2.SuspendLayout();
            this.TabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tiendas_tiemposI)).BeginInit();
            this.GroupBox5.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.TabPage7.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mapeoInventario)).BeginInit();
            this.TabPageCorreo.SuspendLayout();
            this.TabPage5.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TabPage2.SuspendLayout();
            this.TabControl4.SuspendLayout();
            this.TabPage11.SuspendLayout();
            this.GP_EjecD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.GP_FilterD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_filtrosD)).BeginInit();
            this.TabPage1.SuspendLayout();
            this.TabControl3.SuspendLayout();
            this.TabPage10.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_PreviaInv)).BeginInit();
            this.GB_FilterI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FiltrosCatalogo)).BeginInit();
            this.TabPage8.SuspendLayout();
            this.TabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.TabControl5.SuspendLayout();
            this.TabPage12.SuspendLayout();
            this.TabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_configuracionPrecios)).BeginInit();
            this.SuspendLayout();
            // 
            // TabPage9
            // 
            this.TabPage9.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage9.Controls.Add(this.TabControl2);
            this.TabPage9.Location = new System.Drawing.Point(4, 22);
            this.TabPage9.Name = "TabPage9";
            this.TabPage9.Size = new System.Drawing.Size(976, 400);
            this.TabPage9.TabIndex = 5;
            this.TabPage9.Text = "Configuracion de Ejecucion";
            // 
            // TabControl2
            // 
            this.TabControl2.Controls.Add(this.TabPage6);
            this.TabControl2.Controls.Add(this.TabPage7);
            this.TabControl2.Controls.Add(this.TabPageCorreo);
            this.TabControl2.Location = new System.Drawing.Point(5, 5);
            this.TabControl2.Name = "TabControl2";
            this.TabControl2.SelectedIndex = 0;
            this.TabControl2.Size = new System.Drawing.Size(967, 391);
            this.TabControl2.TabIndex = 1;
            // 
            // TabPage6
            // 
            this.TabPage6.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage6.Controls.Add(this.bt_agregarTieI);
            this.TabPage6.Controls.Add(this.dgv_tiendas_tiemposI);
            this.TabPage6.Controls.Add(this.GroupBox5);
            this.TabPage6.Controls.Add(this.GroupBox3);
            this.TabPage6.Controls.Add(this.bt_guardarConfInv);
            this.TabPage6.Controls.Add(this.GroupBox2);
            this.TabPage6.Location = new System.Drawing.Point(4, 22);
            this.TabPage6.Name = "TabPage6";
            this.TabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage6.Size = new System.Drawing.Size(959, 365);
            this.TabPage6.TabIndex = 0;
            this.TabPage6.Text = "Configuracion";
            // 
            // bt_agregarTieI
            // 
            this.bt_agregarTieI.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bt_agregarTieI.Location = new System.Drawing.Point(371, 138);
            this.bt_agregarTieI.Name = "bt_agregarTieI";
            this.bt_agregarTieI.Size = new System.Drawing.Size(75, 23);
            this.bt_agregarTieI.TabIndex = 5;
            this.bt_agregarTieI.Text = "Agregar";
            this.bt_agregarTieI.UseVisualStyleBackColor = true;
            this.bt_agregarTieI.Click += new System.EventHandler(this.bt_agregarTieI_Click_1);
            // 
            // dgv_tiendas_tiemposI
            // 
            this.dgv_tiendas_tiemposI.AllowUserToAddRows = false;
            this.dgv_tiendas_tiemposI.AllowUserToDeleteRows = false;
            this.dgv_tiendas_tiemposI.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_tiendas_tiemposI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tiendas_tiemposI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fc_sbs_no,
            this.fc_store_no,
            this.fc_lunes,
            this.fc_hora_lu,
            this.fc_martes,
            this.fc_hora_ma,
            this.fc_miercoles,
            this.fc_hora_Mi,
            this.fc_jueves,
            this.fc_hora_Ju,
            this.fc_viernes,
            this.fc_hora_Vi,
            this.fc_sabado,
            this.fc_hora_Sa,
            this.fc_domingo,
            this.fc_hora_do});
            this.dgv_tiendas_tiemposI.EnableHeadersVisualStyles = false;
            this.dgv_tiendas_tiemposI.Location = new System.Drawing.Point(371, 167);
            this.dgv_tiendas_tiemposI.Name = "dgv_tiendas_tiemposI";
            this.dgv_tiendas_tiemposI.ReadOnly = true;
            this.dgv_tiendas_tiemposI.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_tiendas_tiemposI.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dgv_tiendas_tiemposI.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_tiendas_tiemposI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_tiendas_tiemposI.Size = new System.Drawing.Size(582, 182);
            this.dgv_tiendas_tiemposI.TabIndex = 4;
            // 
            // fc_sbs_no
            // 
            this.fc_sbs_no.HeaderText = "Sbs_no";
            this.fc_sbs_no.Name = "fc_sbs_no";
            this.fc_sbs_no.ReadOnly = true;
            this.fc_sbs_no.Width = 70;
            // 
            // fc_store_no
            // 
            this.fc_store_no.HeaderText = "Store_no";
            this.fc_store_no.Name = "fc_store_no";
            this.fc_store_no.ReadOnly = true;
            this.fc_store_no.Width = 70;
            // 
            // fc_lunes
            // 
            this.fc_lunes.HeaderText = "Lunes";
            this.fc_lunes.Name = "fc_lunes";
            this.fc_lunes.ReadOnly = true;
            this.fc_lunes.Width = 70;
            // 
            // fc_hora_lu
            // 
            this.fc_hora_lu.HeaderText = "Horario Lunes";
            this.fc_hora_lu.Name = "fc_hora_lu";
            this.fc_hora_lu.ReadOnly = true;
            this.fc_hora_lu.Width = 70;
            // 
            // fc_martes
            // 
            this.fc_martes.HeaderText = "Martes";
            this.fc_martes.Name = "fc_martes";
            this.fc_martes.ReadOnly = true;
            this.fc_martes.Width = 70;
            // 
            // fc_hora_ma
            // 
            this.fc_hora_ma.HeaderText = "Horario Martes";
            this.fc_hora_ma.Name = "fc_hora_ma";
            this.fc_hora_ma.ReadOnly = true;
            this.fc_hora_ma.Width = 70;
            // 
            // fc_miercoles
            // 
            this.fc_miercoles.HeaderText = "Miercoles";
            this.fc_miercoles.Name = "fc_miercoles";
            this.fc_miercoles.ReadOnly = true;
            this.fc_miercoles.Width = 70;
            // 
            // fc_hora_Mi
            // 
            this.fc_hora_Mi.HeaderText = "Horario Miercoles";
            this.fc_hora_Mi.Name = "fc_hora_Mi";
            this.fc_hora_Mi.ReadOnly = true;
            this.fc_hora_Mi.Width = 70;
            // 
            // fc_jueves
            // 
            this.fc_jueves.HeaderText = "Jueves";
            this.fc_jueves.Name = "fc_jueves";
            this.fc_jueves.ReadOnly = true;
            this.fc_jueves.Width = 70;
            // 
            // fc_hora_Ju
            // 
            this.fc_hora_Ju.HeaderText = "Horario Jueves";
            this.fc_hora_Ju.Name = "fc_hora_Ju";
            this.fc_hora_Ju.ReadOnly = true;
            this.fc_hora_Ju.Width = 70;
            // 
            // fc_viernes
            // 
            this.fc_viernes.HeaderText = "Viernes";
            this.fc_viernes.Name = "fc_viernes";
            this.fc_viernes.ReadOnly = true;
            this.fc_viernes.Width = 70;
            // 
            // fc_hora_Vi
            // 
            this.fc_hora_Vi.HeaderText = "Horario Viernes";
            this.fc_hora_Vi.Name = "fc_hora_Vi";
            this.fc_hora_Vi.ReadOnly = true;
            this.fc_hora_Vi.Width = 70;
            // 
            // fc_sabado
            // 
            this.fc_sabado.HeaderText = "Sabado";
            this.fc_sabado.Name = "fc_sabado";
            this.fc_sabado.ReadOnly = true;
            this.fc_sabado.Width = 70;
            // 
            // fc_hora_Sa
            // 
            this.fc_hora_Sa.HeaderText = "Horario Sabado";
            this.fc_hora_Sa.Name = "fc_hora_Sa";
            this.fc_hora_Sa.ReadOnly = true;
            this.fc_hora_Sa.Width = 70;
            // 
            // fc_domingo
            // 
            this.fc_domingo.HeaderText = "Domingo";
            this.fc_domingo.Name = "fc_domingo";
            this.fc_domingo.ReadOnly = true;
            this.fc_domingo.Width = 70;
            // 
            // fc_hora_do
            // 
            this.fc_hora_do.HeaderText = "Horario Domingo";
            this.fc_hora_do.Name = "fc_hora_do";
            this.fc_hora_do.ReadOnly = true;
            this.fc_hora_do.Width = 70;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.txt_tiempo);
            this.GroupBox5.Controls.Add(this.Label30);
            this.GroupBox5.Controls.Add(this.txt_notiMail_Inv);
            this.GroupBox5.Controls.Add(this.Label8);
            this.GroupBox5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GroupBox5.Location = new System.Drawing.Point(650, 6);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(303, 112);
            this.GroupBox5.TabIndex = 3;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Notificaciones";
            // 
            // txt_tiempo
            // 
            this.txt_tiempo.Location = new System.Drawing.Point(130, 31);
            this.txt_tiempo.Name = "txt_tiempo";
            this.txt_tiempo.Size = new System.Drawing.Size(107, 20);
            this.txt_tiempo.TabIndex = 8;
            // 
            // Label30
            // 
            this.Label30.AutoSize = true;
            this.Label30.Location = new System.Drawing.Point(12, 34);
            this.Label30.Name = "Label30";
            this.Label30.Size = new System.Drawing.Size(110, 13);
            this.Label30.TabIndex = 7;
            this.Label30.Text = "Tiempo de Ejecucion:";
            // 
            // txt_notiMail_Inv
            // 
            this.txt_notiMail_Inv.Location = new System.Drawing.Point(130, 76);
            this.txt_notiMail_Inv.Name = "txt_notiMail_Inv";
            this.txt_notiMail_Inv.Size = new System.Drawing.Size(168, 20);
            this.txt_notiMail_Inv.TabIndex = 1;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(12, 76);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(115, 13);
            this.Label8.TabIndex = 0;
            this.Label8.Text = "Correo de Notificacion:";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.cb_hSa);
            this.GroupBox3.Controls.Add(this.cb_hVie);
            this.GroupBox3.Controls.Add(this.cb_hJue);
            this.GroupBox3.Controls.Add(this.cb_hMi);
            this.GroupBox3.Controls.Add(this.cb_hMar);
            this.GroupBox3.Controls.Add(this.Label37);
            this.GroupBox3.Controls.Add(this.Label36);
            this.GroupBox3.Controls.Add(this.Label35);
            this.GroupBox3.Controls.Add(this.Label34);
            this.GroupBox3.Controls.Add(this.Label33);
            this.GroupBox3.Controls.Add(this.Label32);
            this.GroupBox3.Controls.Add(this.cb_hLun);
            this.GroupBox3.Controls.Add(this.cb_interfazD);
            this.GroupBox3.Controls.Add(this.cb_interfazS);
            this.GroupBox3.Controls.Add(this.cb_interfazV);
            this.GroupBox3.Controls.Add(this.cb_interfazJ);
            this.GroupBox3.Controls.Add(this.cb_interfazMI);
            this.GroupBox3.Controls.Add(this.cb_interfazM);
            this.GroupBox3.Controls.Add(this.Label19);
            this.GroupBox3.Controls.Add(this.Label18);
            this.GroupBox3.Controls.Add(this.Label17);
            this.GroupBox3.Controls.Add(this.Label16);
            this.GroupBox3.Controls.Add(this.Label15);
            this.GroupBox3.Controls.Add(this.Label14);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Controls.Add(this.cb_interfazL);
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.cb_tiempoInv);
            this.GroupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GroupBox3.Location = new System.Drawing.Point(6, 6);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(354, 343);
            this.GroupBox3.TabIndex = 2;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Dias de Ejecucion";
            // 
            // cb_hSa
            // 
            this.cb_hSa.FormattingEnabled = true;
            this.cb_hSa.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cb_hSa.Location = new System.Drawing.Point(233, 184);
            this.cb_hSa.Name = "cb_hSa";
            this.cb_hSa.Size = new System.Drawing.Size(49, 21);
            this.cb_hSa.TabIndex = 37;
            // 
            // cb_hVie
            // 
            this.cb_hVie.FormattingEnabled = true;
            this.cb_hVie.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cb_hVie.Location = new System.Drawing.Point(89, 184);
            this.cb_hVie.Name = "cb_hVie";
            this.cb_hVie.Size = new System.Drawing.Size(49, 21);
            this.cb_hVie.TabIndex = 36;
            this.cb_hVie.SelectedIndexChanged += new System.EventHandler(this.ComboBox4_SelectedIndexChanged);
            // 
            // cb_hJue
            // 
            this.cb_hJue.FormattingEnabled = true;
            this.cb_hJue.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cb_hJue.Location = new System.Drawing.Point(233, 117);
            this.cb_hJue.Name = "cb_hJue";
            this.cb_hJue.Size = new System.Drawing.Size(49, 21);
            this.cb_hJue.TabIndex = 35;
            // 
            // cb_hMi
            // 
            this.cb_hMi.FormattingEnabled = true;
            this.cb_hMi.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cb_hMi.Location = new System.Drawing.Point(89, 117);
            this.cb_hMi.Name = "cb_hMi";
            this.cb_hMi.Size = new System.Drawing.Size(49, 21);
            this.cb_hMi.TabIndex = 34;
            // 
            // cb_hMar
            // 
            this.cb_hMar.FormattingEnabled = true;
            this.cb_hMar.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cb_hMar.Location = new System.Drawing.Point(233, 48);
            this.cb_hMar.Name = "cb_hMar";
            this.cb_hMar.Size = new System.Drawing.Size(49, 21);
            this.cb_hMar.TabIndex = 33;
            // 
            // Label37
            // 
            this.Label37.AutoSize = true;
            this.Label37.Location = new System.Drawing.Point(239, 168);
            this.Label37.Name = "Label37";
            this.Label37.Size = new System.Drawing.Size(33, 13);
            this.Label37.TabIndex = 32;
            this.Label37.Text = "Hora:";
            // 
            // Label36
            // 
            this.Label36.AutoSize = true;
            this.Label36.Location = new System.Drawing.Point(98, 168);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(33, 13);
            this.Label36.TabIndex = 31;
            this.Label36.Text = "Hora:";
            // 
            // Label35
            // 
            this.Label35.AutoSize = true;
            this.Label35.Location = new System.Drawing.Point(239, 95);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(33, 13);
            this.Label35.TabIndex = 30;
            this.Label35.Text = "Hora:";
            // 
            // Label34
            // 
            this.Label34.AutoSize = true;
            this.Label34.Location = new System.Drawing.Point(98, 95);
            this.Label34.Name = "Label34";
            this.Label34.Size = new System.Drawing.Size(33, 13);
            this.Label34.TabIndex = 29;
            this.Label34.Text = "Hora:";
            // 
            // Label33
            // 
            this.Label33.AutoSize = true;
            this.Label33.Location = new System.Drawing.Point(239, 35);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(33, 13);
            this.Label33.TabIndex = 28;
            this.Label33.Text = "Hora:";
            // 
            // Label32
            // 
            this.Label32.AutoSize = true;
            this.Label32.Location = new System.Drawing.Point(98, 32);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(33, 13);
            this.Label32.TabIndex = 27;
            this.Label32.Text = "Hora:";
            // 
            // cb_hLun
            // 
            this.cb_hLun.FormattingEnabled = true;
            this.cb_hLun.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cb_hLun.Location = new System.Drawing.Point(89, 48);
            this.cb_hLun.Name = "cb_hLun";
            this.cb_hLun.Size = new System.Drawing.Size(49, 21);
            this.cb_hLun.TabIndex = 26;
            // 
            // cb_interfazD
            // 
            this.cb_interfazD.FormattingEnabled = true;
            this.cb_interfazD.Items.AddRange(new object[] {
            "Inventario",
            "Delta",
            "Precios"});
            this.cb_interfazD.Location = new System.Drawing.Point(6, 254);
            this.cb_interfazD.Name = "cb_interfazD";
            this.cb_interfazD.Size = new System.Drawing.Size(65, 21);
            this.cb_interfazD.TabIndex = 25;
            // 
            // cb_interfazS
            // 
            this.cb_interfazS.FormattingEnabled = true;
            this.cb_interfazS.Items.AddRange(new object[] {
            "Inventario",
            "Delta",
            "Precios"});
            this.cb_interfazS.Location = new System.Drawing.Point(150, 184);
            this.cb_interfazS.Name = "cb_interfazS";
            this.cb_interfazS.Size = new System.Drawing.Size(65, 21);
            this.cb_interfazS.TabIndex = 24;
            // 
            // cb_interfazV
            // 
            this.cb_interfazV.FormattingEnabled = true;
            this.cb_interfazV.Items.AddRange(new object[] {
            "Inventario",
            "Delta",
            "Precios"});
            this.cb_interfazV.Location = new System.Drawing.Point(6, 184);
            this.cb_interfazV.Name = "cb_interfazV";
            this.cb_interfazV.Size = new System.Drawing.Size(65, 21);
            this.cb_interfazV.TabIndex = 23;
            // 
            // cb_interfazJ
            // 
            this.cb_interfazJ.FormattingEnabled = true;
            this.cb_interfazJ.Items.AddRange(new object[] {
            "Inventario",
            "Delta",
            "Precios"});
            this.cb_interfazJ.Location = new System.Drawing.Point(150, 117);
            this.cb_interfazJ.Name = "cb_interfazJ";
            this.cb_interfazJ.Size = new System.Drawing.Size(65, 21);
            this.cb_interfazJ.TabIndex = 22;
            // 
            // cb_interfazMI
            // 
            this.cb_interfazMI.FormattingEnabled = true;
            this.cb_interfazMI.Items.AddRange(new object[] {
            "Inventario",
            "Delta",
            "Precios"});
            this.cb_interfazMI.Location = new System.Drawing.Point(6, 117);
            this.cb_interfazMI.Name = "cb_interfazMI";
            this.cb_interfazMI.Size = new System.Drawing.Size(65, 21);
            this.cb_interfazMI.TabIndex = 21;
            // 
            // cb_interfazM
            // 
            this.cb_interfazM.FormattingEnabled = true;
            this.cb_interfazM.Items.AddRange(new object[] {
            "Inventario",
            "Delta",
            "Precios"});
            this.cb_interfazM.Location = new System.Drawing.Point(150, 48);
            this.cb_interfazM.Name = "cb_interfazM";
            this.cb_interfazM.Size = new System.Drawing.Size(65, 21);
            this.cb_interfazM.TabIndex = 20;
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(7, 238);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(49, 13);
            this.Label19.TabIndex = 19;
            this.Label19.Text = "Domingo";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(160, 168);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(44, 13);
            this.Label18.TabIndex = 18;
            this.Label18.Text = "Sabado";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(14, 168);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(42, 13);
            this.Label17.TabIndex = 17;
            this.Label17.Text = "Viernes";
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(163, 95);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(41, 13);
            this.Label16.TabIndex = 16;
            this.Label16.Text = "Jueves";
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(14, 95);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(52, 13);
            this.Label15.TabIndex = 15;
            this.Label15.Text = "Miercoles";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(166, 31);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(39, 13);
            this.Label14.TabIndex = 14;
            this.Label14.Text = "Martes";
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(14, 32);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(36, 13);
            this.Label12.TabIndex = 13;
            this.Label12.Text = "Lunes";
            // 
            // cb_interfazL
            // 
            this.cb_interfazL.FormattingEnabled = true;
            this.cb_interfazL.Items.AddRange(new object[] {
            "Inventario",
            "Delta",
            "Precios"});
            this.cb_interfazL.Location = new System.Drawing.Point(6, 48);
            this.cb_interfazL.Name = "cb_interfazL";
            this.cb_interfazL.Size = new System.Drawing.Size(65, 21);
            this.cb_interfazL.TabIndex = 12;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(98, 238);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(33, 13);
            this.Label7.TabIndex = 8;
            this.Label7.Text = "Hora:";
            // 
            // cb_tiempoInv
            // 
            this.cb_tiempoInv.FormattingEnabled = true;
            this.cb_tiempoInv.Items.AddRange(new object[] {
            "00:00",
            "01:00",
            "02:00",
            "03:00",
            "04:00",
            "05:00",
            "06:00",
            "07:00",
            "08:00",
            "09:00",
            "10:00",
            "11:00",
            "12:00",
            "13:00",
            "14:00",
            "15:00",
            "16:00",
            "17:00",
            "18:00",
            "19:00",
            "20:00",
            "21:00",
            "22:00",
            "23:00"});
            this.cb_tiempoInv.Location = new System.Drawing.Point(89, 254);
            this.cb_tiempoInv.Name = "cb_tiempoInv";
            this.cb_tiempoInv.Size = new System.Drawing.Size(49, 21);
            this.cb_tiempoInv.TabIndex = 7;
            // 
            // bt_guardarConfInv
            // 
            this.bt_guardarConfInv.ForeColor = System.Drawing.SystemColors.Highlight;
            this.bt_guardarConfInv.Location = new System.Drawing.Point(878, 138);
            this.bt_guardarConfInv.Name = "bt_guardarConfInv";
            this.bt_guardarConfInv.Size = new System.Drawing.Size(75, 23);
            this.bt_guardarConfInv.TabIndex = 1;
            this.bt_guardarConfInv.Text = "Guardar";
            this.bt_guardarConfInv.UseVisualStyleBackColor = true;
            this.bt_guardarConfInv.Click += new System.EventHandler(this.bt_guardarConfInv_Click_1);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.Label11);
            this.GroupBox2.Controls.Add(this.cb_store_I);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Controls.Add(this.cb_subsidiariaInv);
            this.GroupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GroupBox2.Location = new System.Drawing.Point(371, 6);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(273, 115);
            this.GroupBox2.TabIndex = 0;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Tiendas";
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(14, 62);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(45, 13);
            this.Label11.TabIndex = 4;
            this.Label11.Text = "Tiendas";
            // 
            // cb_store_I
            // 
            this.cb_store_I.FormattingEnabled = true;
            this.cb_store_I.Location = new System.Drawing.Point(12, 78);
            this.cb_store_I.Name = "cb_store_I";
            this.cb_store_I.Size = new System.Drawing.Size(242, 21);
            this.cb_store_I.TabIndex = 3;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(13, 16);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(58, 13);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Subsidiaria";
            // 
            // cb_subsidiariaInv
            // 
            this.cb_subsidiariaInv.FormattingEnabled = true;
            this.cb_subsidiariaInv.Location = new System.Drawing.Point(12, 32);
            this.cb_subsidiariaInv.Name = "cb_subsidiariaInv";
            this.cb_subsidiariaInv.Size = new System.Drawing.Size(153, 21);
            this.cb_subsidiariaInv.TabIndex = 0;
            this.cb_subsidiariaInv.SelectedValueChanged += new System.EventHandler(this.cb_subsidiariaInv_SelectedValueChanged);
            // 
            // TabPage7
            // 
            this.TabPage7.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage7.Controls.Add(this.bt_GuardarMapI);
            this.TabPage7.Controls.Add(this.GroupBox6);
            this.TabPage7.Location = new System.Drawing.Point(4, 22);
            this.TabPage7.Name = "TabPage7";
            this.TabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage7.Size = new System.Drawing.Size(959, 365);
            this.TabPage7.TabIndex = 1;
            this.TabPage7.Text = "Mapeo";
            // 
            // bt_GuardarMapI
            // 
            this.bt_GuardarMapI.Location = new System.Drawing.Point(564, 300);
            this.bt_GuardarMapI.Name = "bt_GuardarMapI";
            this.bt_GuardarMapI.Size = new System.Drawing.Size(75, 23);
            this.bt_GuardarMapI.TabIndex = 1;
            this.bt_GuardarMapI.Text = "Guardar";
            this.bt_GuardarMapI.UseVisualStyleBackColor = true;
            this.bt_GuardarMapI.Click += new System.EventHandler(this.bt_GuardarMapI_Click_1);
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.label38);
            this.GroupBox6.Controls.Add(this.cb_mapeo_tipo);
            this.GroupBox6.Controls.Add(this.Label10);
            this.GroupBox6.Controls.Add(this.Label9);
            this.GroupBox6.Controls.Add(this.bt_agregarI);
            this.GroupBox6.Controls.Add(this.txt_dalake_campI);
            this.GroupBox6.Controls.Add(this.cb_rpro_campI);
            this.GroupBox6.Controls.Add(this.dgv_mapeoInventario);
            this.GroupBox6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GroupBox6.Location = new System.Drawing.Point(6, 17);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(538, 313);
            this.GroupBox6.TabIndex = 0;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "Definicion de Campos";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(324, 31);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(64, 13);
            this.label38.TabIndex = 7;
            this.label38.Text = "Tipo Campo";
            // 
            // cb_mapeo_tipo
            // 
            this.cb_mapeo_tipo.FormattingEnabled = true;
            this.cb_mapeo_tipo.Items.AddRange(new object[] {
            "Inventario",
            "Precios"});
            this.cb_mapeo_tipo.Location = new System.Drawing.Point(310, 49);
            this.cb_mapeo_tipo.Name = "cb_mapeo_tipo";
            this.cb_mapeo_tipo.Size = new System.Drawing.Size(121, 21);
            this.cb_mapeo_tipo.TabIndex = 8;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(173, 31);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(90, 13);
            this.Label10.TabIndex = 5;
            this.Label10.Text = "Campo DataLake";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(24, 31);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(74, 13);
            this.Label9.TabIndex = 4;
            this.Label9.Text = "Campo RPRO";
            // 
            // bt_agregarI
            // 
            this.bt_agregarI.Location = new System.Drawing.Point(457, 50);
            this.bt_agregarI.Name = "bt_agregarI";
            this.bt_agregarI.Size = new System.Drawing.Size(75, 23);
            this.bt_agregarI.TabIndex = 3;
            this.bt_agregarI.Text = "Agregar";
            this.bt_agregarI.UseVisualStyleBackColor = true;
            this.bt_agregarI.Click += new System.EventHandler(this.bt_agregarI_Click_1);
            // 
            // txt_dalake_campI
            // 
            this.txt_dalake_campI.Location = new System.Drawing.Point(165, 50);
            this.txt_dalake_campI.Name = "txt_dalake_campI";
            this.txt_dalake_campI.Size = new System.Drawing.Size(110, 20);
            this.txt_dalake_campI.TabIndex = 2;
            // 
            // cb_rpro_campI
            // 
            this.cb_rpro_campI.FormattingEnabled = true;
            this.cb_rpro_campI.Location = new System.Drawing.Point(6, 50);
            this.cb_rpro_campI.Name = "cb_rpro_campI";
            this.cb_rpro_campI.Size = new System.Drawing.Size(121, 21);
            this.cb_rpro_campI.TabIndex = 1;
            // 
            // dgv_mapeoInventario
            // 
            this.dgv_mapeoInventario.AllowUserToAddRows = false;
            this.dgv_mapeoInventario.AllowUserToDeleteRows = false;
            this.dgv_mapeoInventario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_mapeoInventario.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_mapeoInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_mapeoInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mc_campo_rpro,
            this.mc_datalake,
            this.mc_tipo});
            this.dgv_mapeoInventario.EnableHeadersVisualStyles = false;
            this.dgv_mapeoInventario.Location = new System.Drawing.Point(6, 86);
            this.dgv_mapeoInventario.Name = "dgv_mapeoInventario";
            this.dgv_mapeoInventario.ReadOnly = true;
            this.dgv_mapeoInventario.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgv_mapeoInventario.RowHeadersVisible = false;
            this.dgv_mapeoInventario.Size = new System.Drawing.Size(526, 221);
            this.dgv_mapeoInventario.TabIndex = 0;
            this.dgv_mapeoInventario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_mapeoInventario_KeyDown);
            // 
            // mc_campo_rpro
            // 
            this.mc_campo_rpro.HeaderText = "Rpro";
            this.mc_campo_rpro.Name = "mc_campo_rpro";
            this.mc_campo_rpro.ReadOnly = true;
            this.mc_campo_rpro.Width = 150;
            // 
            // mc_datalake
            // 
            this.mc_datalake.HeaderText = "DataLake";
            this.mc_datalake.Name = "mc_datalake";
            this.mc_datalake.ReadOnly = true;
            this.mc_datalake.Width = 150;
            // 
            // mc_tipo
            // 
            this.mc_tipo.HeaderText = "Tipo";
            this.mc_tipo.Name = "mc_tipo";
            this.mc_tipo.ReadOnly = true;
            this.mc_tipo.Width = 150;
            // 
            // TabPageCorreo
            // 
            this.TabPageCorreo.BackColor = System.Drawing.SystemColors.Control;
            this.TabPageCorreo.Controls.Add(this.btnSendTestEmail);
            this.TabPageCorreo.Controls.Add(this.lblRecipientEmails);
            this.TabPageCorreo.Controls.Add(this.txtRecipientEmails);
            this.TabPageCorreo.Controls.Add(this.lblSmtpServer);
            this.TabPageCorreo.Controls.Add(this.txtSmtpServer);
            this.TabPageCorreo.Controls.Add(this.lblPort);
            this.TabPageCorreo.Controls.Add(this.txtPort);
            this.TabPageCorreo.Controls.Add(this.lblUsername);
            this.TabPageCorreo.Controls.Add(this.txtUsername);
            this.TabPageCorreo.Controls.Add(this.btnSaveEmailConfig);
            this.TabPageCorreo.Location = new System.Drawing.Point(4, 22);
            this.TabPageCorreo.Name = "TabPageCorreo";
            this.TabPageCorreo.Padding = new System.Windows.Forms.Padding(3);
            this.TabPageCorreo.Size = new System.Drawing.Size(959, 365);
            this.TabPageCorreo.TabIndex = 0;
            this.TabPageCorreo.Text = "Configuración de Correo";
            // 
            // btnSendTestEmail
            // 
            this.btnSendTestEmail.Location = new System.Drawing.Point(250, 180);
            this.btnSendTestEmail.Name = "btnSendTestEmail";
            this.btnSendTestEmail.Size = new System.Drawing.Size(175, 23);
            this.btnSendTestEmail.TabIndex = 9;
            this.btnSendTestEmail.Text = "Enviar Correo de Prueba";
            this.btnSendTestEmail.Click += new System.EventHandler(this.btnEnviarCorreoPrueba_Click);
            
            // 
            // lblRecipientEmails
            // 
            this.lblRecipientEmails.Location = new System.Drawing.Point(20, 140);
            this.lblRecipientEmails.Name = "lblRecipientEmails";
            this.lblRecipientEmails.Size = new System.Drawing.Size(120, 23);
            this.lblRecipientEmails.TabIndex = 6;
            this.lblRecipientEmails.Text = "Correos Destinatarios:";
            // 
            // txtRecipientEmails
            // 
            this.txtRecipientEmails.Location = new System.Drawing.Point(150, 140);
            this.txtRecipientEmails.Name = "txtRecipientEmails";
            this.txtRecipientEmails.Size = new System.Drawing.Size(400, 20);
            this.txtRecipientEmails.TabIndex = 7;
            // 
            // lblSmtpServer
            // 
            this.lblSmtpServer.Location = new System.Drawing.Point(20, 20);
            this.lblSmtpServer.Name = "lblSmtpServer";
            this.lblSmtpServer.Size = new System.Drawing.Size(100, 23);
            this.lblSmtpServer.TabIndex = 0;
            this.lblSmtpServer.Text = "Servidor SMTP:";
            // 
            // txtSmtpServer
            // 
            this.txtSmtpServer.Location = new System.Drawing.Point(150, 20);
            this.txtSmtpServer.Name = "txtSmtpServer";
            this.txtSmtpServer.Size = new System.Drawing.Size(200, 20);
            this.txtSmtpServer.TabIndex = 1;
            // 
            // lblPort
            // 
            this.lblPort.Location = new System.Drawing.Point(20, 60);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(100, 23);
            this.lblPort.TabIndex = 2;
            this.lblPort.Text = "Puerto:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(150, 60);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(20, 100);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(100, 23);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Usuario:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(150, 100);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(200, 20);
            this.txtUsername.TabIndex = 5;
            // 
            // btnSaveEmailConfig
            // 
            this.btnSaveEmailConfig.Location = new System.Drawing.Point(150, 180);
            this.btnSaveEmailConfig.Name = "btnSaveEmailConfig";
            this.btnSaveEmailConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveEmailConfig.TabIndex = 8;
            this.btnSaveEmailConfig.Text = "Guardar Configuración";
            this.btnSaveEmailConfig.Click += new System.EventHandler(this.btnSaveEmailConfig_Click);
            // 
            // TabPage5
            // 
            this.TabPage5.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage5.Controls.Add(this.GroupBox1);
            this.TabPage5.Location = new System.Drawing.Point(4, 22);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Size = new System.Drawing.Size(976, 400);
            this.TabPage5.TabIndex = 4;
            this.TabPage5.Text = "Base de Datos";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.cb_db_con);
            this.GroupBox1.Controls.Add(this.Label31);
            this.GroupBox1.Controls.Add(this.bt_guardar_db);
            this.GroupBox1.Controls.Add(this.bt_test_db);
            this.GroupBox1.Controls.Add(this.txt_pass_db);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.txt_user_db);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.txt_port_db);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.txt_db_name);
            this.GroupBox1.Controls.Add(this.Label2);
            this.GroupBox1.Controls.Add(this.txt_host_db);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GroupBox1.Location = new System.Drawing.Point(21, 29);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(660, 338);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Credenciales DB";
            // 
            // cb_db_con
            // 
            this.cb_db_con.FormattingEnabled = true;
            this.cb_db_con.Location = new System.Drawing.Point(450, 68);
            this.cb_db_con.Name = "cb_db_con";
            this.cb_db_con.Size = new System.Drawing.Size(100, 21);
            this.cb_db_con.TabIndex = 13;
            // 
            // Label31
            // 
            this.Label31.AutoSize = true;
            this.Label31.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label31.Location = new System.Drawing.Point(341, 68);
            this.Label31.Name = "Label31";
            this.Label31.Size = new System.Drawing.Size(76, 13);
            this.Label31.TabIndex = 12;
            this.Label31.Text = "Estructura DB:";
            // 
            // bt_guardar_db
            // 
            this.bt_guardar_db.Location = new System.Drawing.Point(475, 292);
            this.bt_guardar_db.Name = "bt_guardar_db";
            this.bt_guardar_db.Size = new System.Drawing.Size(75, 23);
            this.bt_guardar_db.TabIndex = 11;
            this.bt_guardar_db.Text = "Guardar";
            this.bt_guardar_db.UseVisualStyleBackColor = true;
            this.bt_guardar_db.Click += new System.EventHandler(this.bt_guardar_db_Click);
            // 
            // bt_test_db
            // 
            this.bt_test_db.Location = new System.Drawing.Point(177, 292);
            this.bt_test_db.Name = "bt_test_db";
            this.bt_test_db.Size = new System.Drawing.Size(75, 23);
            this.bt_test_db.TabIndex = 10;
            this.bt_test_db.Text = "Test";
            this.bt_test_db.UseVisualStyleBackColor = true;
            this.bt_test_db.Click += new System.EventHandler(this.bt_test_db_Click);
            // 
            // txt_pass_db
            // 
            this.txt_pass_db.Location = new System.Drawing.Point(450, 223);
            this.txt_pass_db.Name = "txt_pass_db";
            this.txt_pass_db.PasswordChar = '*';
            this.txt_pass_db.Size = new System.Drawing.Size(100, 20);
            this.txt_pass_db.TabIndex = 9;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(341, 223);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(64, 13);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Contraseña:";
            // 
            // txt_user_db
            // 
            this.txt_user_db.Location = new System.Drawing.Point(450, 144);
            this.txt_user_db.Name = "txt_user_db";
            this.txt_user_db.Size = new System.Drawing.Size(100, 20);
            this.txt_user_db.TabIndex = 7;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(341, 144);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(46, 13);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Usuario:";
            // 
            // txt_port_db
            // 
            this.txt_port_db.Location = new System.Drawing.Point(152, 223);
            this.txt_port_db.Name = "txt_port_db";
            this.txt_port_db.Size = new System.Drawing.Size(100, 20);
            this.txt_port_db.TabIndex = 5;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(43, 223);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(41, 13);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Puerto:";
            // 
            // txt_db_name
            // 
            this.txt_db_name.Location = new System.Drawing.Point(152, 144);
            this.txt_db_name.Name = "txt_db_name";
            this.txt_db_name.Size = new System.Drawing.Size(100, 20);
            this.txt_db_name.TabIndex = 3;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(43, 144);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(80, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Base de Datos:";
            // 
            // txt_host_db
            // 
            this.txt_host_db.Location = new System.Drawing.Point(152, 71);
            this.txt_host_db.Name = "txt_host_db";
            this.txt_host_db.Size = new System.Drawing.Size(100, 20);
            this.txt_host_db.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Label1.Location = new System.Drawing.Point(43, 71);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(32, 13);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Host:";
            // 
            // bt_GuardarPrecios
            // 
            this.bt_GuardarPrecios.Location = new System.Drawing.Point(6, 107);
            this.bt_GuardarPrecios.Name = "bt_GuardarPrecios";
            this.bt_GuardarPrecios.Size = new System.Drawing.Size(75, 23);
            this.bt_GuardarPrecios.TabIndex = 4;
            this.bt_GuardarPrecios.Text = "Guardar";
            this.bt_GuardarPrecios.UseVisualStyleBackColor = true;
            this.bt_GuardarPrecios.Click += new System.EventHandler(this.bt_GuardarPrecios_Click);
            // 
            // txt_tokenPrecios
            // 
            this.txt_tokenPrecios.Location = new System.Drawing.Point(6, 64);
            this.txt_tokenPrecios.Name = "txt_tokenPrecios";
            this.txt_tokenPrecios.Size = new System.Drawing.Size(385, 20);
            this.txt_tokenPrecios.TabIndex = 3;
            // 
            // Label41
            // 
            this.Label41.AutoSize = true;
            this.Label41.Location = new System.Drawing.Point(6, 48);
            this.Label41.Name = "Label41";
            this.Label41.Size = new System.Drawing.Size(38, 13);
            this.Label41.TabIndex = 2;
            this.Label41.Text = "Token";
            // 
            // txt_urlPrecios
            // 
            this.txt_urlPrecios.Location = new System.Drawing.Point(6, 25);
            this.txt_urlPrecios.Name = "txt_urlPrecios";
            this.txt_urlPrecios.Size = new System.Drawing.Size(385, 20);
            this.txt_urlPrecios.TabIndex = 1;
            // 
            // Label42
            // 
            this.Label42.AutoSize = true;
            this.Label42.Location = new System.Drawing.Point(6, 9);
            this.Label42.Name = "Label42";
            this.Label42.Size = new System.Drawing.Size(29, 13);
            this.Label42.TabIndex = 0;
            this.Label42.Text = "URL";
            // 
            // TabPage2
            // 
            this.TabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage2.Controls.Add(this.TabControl4);
            this.TabPage2.Location = new System.Drawing.Point(4, 22);
            this.TabPage2.Name = "TabPage2";
            this.TabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage2.Size = new System.Drawing.Size(976, 400);
            this.TabPage2.TabIndex = 1;
            this.TabPage2.Text = "Inventario Delta";
            // 
            // TabControl4
            // 
            this.TabControl4.Controls.Add(this.TabPage11);
            this.TabControl4.Location = new System.Drawing.Point(5, 3);
            this.TabControl4.Name = "TabControl4";
            this.TabControl4.SelectedIndex = 0;
            this.TabControl4.Size = new System.Drawing.Size(967, 394);
            this.TabControl4.TabIndex = 1;
            // 
            // TabPage11
            // 
            this.TabPage11.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage11.Controls.Add(this.B_SetConfCat_FilterD);
            this.TabPage11.Controls.Add(this.GP_EjecD);
            this.TabPage11.Controls.Add(this.GP_FilterD);
            this.TabPage11.Location = new System.Drawing.Point(4, 22);
            this.TabPage11.Name = "TabPage11";
            this.TabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage11.Size = new System.Drawing.Size(959, 368);
            this.TabPage11.TabIndex = 1;
            this.TabPage11.Text = "Ejecucion Manual";
            // 
            // B_SetConfCat_FilterD
            // 
            this.B_SetConfCat_FilterD.BackColor = System.Drawing.SystemColors.Control;
            this.B_SetConfCat_FilterD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.B_SetConfCat_FilterD.Location = new System.Drawing.Point(646, 338);
            this.B_SetConfCat_FilterD.Name = "B_SetConfCat_FilterD";
            this.B_SetConfCat_FilterD.Size = new System.Drawing.Size(79, 23);
            this.B_SetConfCat_FilterD.TabIndex = 39;
            this.B_SetConfCat_FilterD.Text = "Guardar";
            this.B_SetConfCat_FilterD.UseVisualStyleBackColor = false;
            this.B_SetConfCat_FilterD.Click += new System.EventHandler(this.B_SetConfCat_FilterD_Click);
            // 
            // GP_EjecD
            // 
            this.GP_EjecD.Controls.Add(this.bt_ejecturarD);
            this.GP_EjecD.Controls.Add(this.cb_list_storesD);
            this.GP_EjecD.Controls.Add(this.Label23);
            this.GP_EjecD.Controls.Add(this.cb_sbs_noD);
            this.GP_EjecD.Controls.Add(this.bt_previaD);
            this.GP_EjecD.Controls.Add(this.DataGridView1);
            this.GP_EjecD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GP_EjecD.Location = new System.Drawing.Point(474, 6);
            this.GP_EjecD.Name = "GP_EjecD";
            this.GP_EjecD.Size = new System.Drawing.Size(479, 326);
            this.GP_EjecD.TabIndex = 1;
            this.GP_EjecD.TabStop = false;
            this.GP_EjecD.Text = "Ejecucion";
            // 
            // bt_ejecturarD
            // 
            this.bt_ejecturarD.Location = new System.Drawing.Point(398, 171);
            this.bt_ejecturarD.Name = "bt_ejecturarD";
            this.bt_ejecturarD.Size = new System.Drawing.Size(75, 23);
            this.bt_ejecturarD.TabIndex = 44;
            this.bt_ejecturarD.Text = "Ejecutar";
            this.bt_ejecturarD.UseVisualStyleBackColor = true;
            this.bt_ejecturarD.Click += new System.EventHandler(this.bt_ejecturarD_Click);
            // 
            // cb_list_storesD
            // 
            this.cb_list_storesD.FormattingEnabled = true;
            this.cb_list_storesD.Location = new System.Drawing.Point(159, 54);
            this.cb_list_storesD.Name = "cb_list_storesD";
            this.cb_list_storesD.Size = new System.Drawing.Size(314, 94);
            this.cb_list_storesD.TabIndex = 43;
            // 
            // Label23
            // 
            this.Label23.AutoSize = true;
            this.Label23.Location = new System.Drawing.Point(26, 31);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(58, 13);
            this.Label23.TabIndex = 42;
            this.Label23.Text = "Subsidiaria";
            // 
            // cb_sbs_noD
            // 
            this.cb_sbs_noD.FormattingEnabled = true;
            this.cb_sbs_noD.Location = new System.Drawing.Point(16, 50);
            this.cb_sbs_noD.Name = "cb_sbs_noD";
            this.cb_sbs_noD.Size = new System.Drawing.Size(121, 21);
            this.cb_sbs_noD.TabIndex = 41;
            // 
            // bt_previaD
            // 
            this.bt_previaD.Location = new System.Drawing.Point(6, 171);
            this.bt_previaD.Name = "bt_previaD";
            this.bt_previaD.Size = new System.Drawing.Size(75, 23);
            this.bt_previaD.TabIndex = 40;
            this.bt_previaD.Text = "Previa";
            this.bt_previaD.UseVisualStyleBackColor = true;
            this.bt_previaD.Click += new System.EventHandler(this.bt_previaD_Click);
            // 
            // DataGridView1
            // 
            this.DataGridView1.AllowUserToAddRows = false;
            this.DataGridView1.AllowUserToDeleteRows = false;
            this.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridView1.EnableHeadersVisualStyles = false;
            this.DataGridView1.Location = new System.Drawing.Point(6, 200);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.ReadOnly = true;
            this.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView1.Size = new System.Drawing.Size(467, 115);
            this.DataGridView1.TabIndex = 39;
            // 
            // GP_FilterD
            // 
            this.GP_FilterD.Controls.Add(this.gv_filtrosD);
            this.GP_FilterD.Controls.Add(this.Label26);
            this.GP_FilterD.Controls.Add(this.Label27);
            this.GP_FilterD.Controls.Add(this.Label28);
            this.GP_FilterD.Controls.Add(this.Label29);
            this.GP_FilterD.Controls.Add(this.bt_agregarFiltrosD);
            this.GP_FilterD.Controls.Add(this.cb_condicionD);
            this.GP_FilterD.Controls.Add(this.cb_operadorD);
            this.GP_FilterD.Controls.Add(this.ch_activalFiltrosD);
            this.GP_FilterD.Controls.Add(this.txt_valD);
            this.GP_FilterD.Controls.Add(this.cb_rproD);
            this.GP_FilterD.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GP_FilterD.Location = new System.Drawing.Point(6, 6);
            this.GP_FilterD.Name = "GP_FilterD";
            this.GP_FilterD.Size = new System.Drawing.Size(462, 360);
            this.GP_FilterD.TabIndex = 0;
            this.GP_FilterD.TabStop = false;
            this.GP_FilterD.Text = "Parametros";
            // 
            // gv_filtrosD
            // 
            this.gv_filtrosD.AllowUserToAddRows = false;
            this.gv_filtrosD.AllowUserToDeleteRows = false;
            this.gv_filtrosD.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gv_filtrosD.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_filtrosD.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.gv_filtrosD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_filtrosD.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fc_operadorD,
            this.fc_campo_rproD,
            this.fc_condicionD,
            this.fc_valorD});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv_filtrosD.DefaultCellStyle = dataGridViewCellStyle7;
            this.gv_filtrosD.EnableHeadersVisualStyles = false;
            this.gv_filtrosD.Location = new System.Drawing.Point(3, 144);
            this.gv_filtrosD.Name = "gv_filtrosD";
            this.gv_filtrosD.ReadOnly = true;
            this.gv_filtrosD.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv_filtrosD.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gv_filtrosD.RowHeadersVisible = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.gv_filtrosD.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gv_filtrosD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gv_filtrosD.Size = new System.Drawing.Size(436, 216);
            this.gv_filtrosD.TabIndex = 38;
            // 
            // fc_operadorD
            // 
            this.fc_operadorD.HeaderText = "Operador";
            this.fc_operadorD.Name = "fc_operadorD";
            this.fc_operadorD.ReadOnly = true;
            this.fc_operadorD.Width = 80;
            // 
            // fc_campo_rproD
            // 
            this.fc_campo_rproD.HeaderText = "RPRO";
            this.fc_campo_rproD.Name = "fc_campo_rproD";
            this.fc_campo_rproD.ReadOnly = true;
            // 
            // fc_condicionD
            // 
            this.fc_condicionD.HeaderText = "Condicion";
            this.fc_condicionD.Name = "fc_condicionD";
            this.fc_condicionD.ReadOnly = true;
            // 
            // fc_valorD
            // 
            this.fc_valorD.HeaderText = "Valor";
            this.fc_valorD.Name = "fc_valorD";
            this.fc_valorD.ReadOnly = true;
            this.fc_valorD.Width = 200;
            // 
            // Label26
            // 
            this.Label26.AutoSize = true;
            this.Label26.Location = new System.Drawing.Point(268, 32);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(54, 13);
            this.Label26.TabIndex = 37;
            this.Label26.Text = "Condicion";
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(6, 32);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(51, 13);
            this.Label27.TabIndex = 36;
            this.Label27.Text = "Operador";
            // 
            // Label28
            // 
            this.Label28.AutoSize = true;
            this.Label28.Location = new System.Drawing.Point(23, 95);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(31, 13);
            this.Label28.TabIndex = 34;
            this.Label28.Text = "Valor";
            this.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label29
            // 
            this.Label29.AutoSize = true;
            this.Label29.Location = new System.Drawing.Point(116, 32);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(38, 13);
            this.Label29.TabIndex = 35;
            this.Label29.Text = "RPRO";
            this.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // bt_agregarFiltrosD
            // 
            this.bt_agregarFiltrosD.Location = new System.Drawing.Point(230, 111);
            this.bt_agregarFiltrosD.Name = "bt_agregarFiltrosD";
            this.bt_agregarFiltrosD.Size = new System.Drawing.Size(75, 23);
            this.bt_agregarFiltrosD.TabIndex = 33;
            this.bt_agregarFiltrosD.Text = "Agregar";
            this.bt_agregarFiltrosD.UseVisualStyleBackColor = true;
            this.bt_agregarFiltrosD.Click += new System.EventHandler(this.bt_agregarFiltrosD_Click);
            // 
            // cb_condicionD
            // 
            this.cb_condicionD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_condicionD.FormattingEnabled = true;
            this.cb_condicionD.Items.AddRange(new object[] {
            "IN",
            "=",
            ">",
            "<",
            "BETWEEN",
            "<>",
            "!="});
            this.cb_condicionD.Location = new System.Drawing.Point(230, 54);
            this.cb_condicionD.Name = "cb_condicionD";
            this.cb_condicionD.Size = new System.Drawing.Size(119, 21);
            this.cb_condicionD.TabIndex = 32;
            // 
            // cb_operadorD
            // 
            this.cb_operadorD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_operadorD.FormattingEnabled = true;
            this.cb_operadorD.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cb_operadorD.Location = new System.Drawing.Point(3, 54);
            this.cb_operadorD.Name = "cb_operadorD";
            this.cb_operadorD.Size = new System.Drawing.Size(65, 21);
            this.cb_operadorD.TabIndex = 31;
            // 
            // ch_activalFiltrosD
            // 
            this.ch_activalFiltrosD.AutoSize = true;
            this.ch_activalFiltrosD.Location = new System.Drawing.Point(384, 54);
            this.ch_activalFiltrosD.Name = "ch_activalFiltrosD";
            this.ch_activalFiltrosD.Size = new System.Drawing.Size(59, 17);
            this.ch_activalFiltrosD.TabIndex = 30;
            this.ch_activalFiltrosD.Text = "Activar";
            this.ch_activalFiltrosD.UseVisualStyleBackColor = true;
            this.ch_activalFiltrosD.CheckedChanged += new System.EventHandler(this.ch_activalFiltrosD_CheckedChanged);
            // 
            // txt_valD
            // 
            this.txt_valD.Location = new System.Drawing.Point(3, 111);
            this.txt_valD.Name = "txt_valD";
            this.txt_valD.Size = new System.Drawing.Size(210, 20);
            this.txt_valD.TabIndex = 29;
            // 
            // cb_rproD
            // 
            this.cb_rproD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_rproD.FormattingEnabled = true;
            this.cb_rproD.Items.AddRange(new object[] {
            "ACTIVE",
            "QTY",
            "D",
            "C",
            "S"});
            this.cb_rproD.Location = new System.Drawing.Point(74, 54);
            this.cb_rproD.Name = "cb_rproD";
            this.cb_rproD.Size = new System.Drawing.Size(139, 21);
            this.cb_rproD.TabIndex = 28;
            // 
            // TabPage1
            // 
            this.TabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage1.Controls.Add(this.TabControl3);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(976, 400);
            this.TabPage1.TabIndex = 0;
            this.TabPage1.Text = "Inventario Completo";
            // 
            // TabControl3
            // 
            this.TabControl3.Controls.Add(this.TabPage10);
            this.TabControl3.Controls.Add(this.TabPage8);
            this.TabControl3.Location = new System.Drawing.Point(3, 6);
            this.TabControl3.Name = "TabControl3";
            this.TabControl3.SelectedIndex = 0;
            this.TabControl3.Size = new System.Drawing.Size(967, 394);
            this.TabControl3.TabIndex = 0;
            // 
            // TabPage10
            // 
            this.TabPage10.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage10.Controls.Add(this.B_SetConfCat_Filter);
            this.TabPage10.Controls.Add(this.GroupBox7);
            this.TabPage10.Controls.Add(this.GB_FilterI);
            this.TabPage10.Location = new System.Drawing.Point(4, 22);
            this.TabPage10.Name = "TabPage10";
            this.TabPage10.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage10.Size = new System.Drawing.Size(959, 368);
            this.TabPage10.TabIndex = 1;
            this.TabPage10.Text = "Ejecucion Manual";
            // 
            // B_SetConfCat_Filter
            // 
            this.B_SetConfCat_Filter.BackColor = System.Drawing.SystemColors.Control;
            this.B_SetConfCat_Filter.ForeColor = System.Drawing.SystemColors.Highlight;
            this.B_SetConfCat_Filter.Location = new System.Drawing.Point(646, 338);
            this.B_SetConfCat_Filter.Name = "B_SetConfCat_Filter";
            this.B_SetConfCat_Filter.Size = new System.Drawing.Size(79, 23);
            this.B_SetConfCat_Filter.TabIndex = 39;
            this.B_SetConfCat_Filter.Text = "Guardar";
            this.B_SetConfCat_Filter.UseVisualStyleBackColor = false;
            this.B_SetConfCat_Filter.Click += new System.EventHandler(this.B_SetConfCat_Filter_Click);
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.bt_ejecturarInv);
            this.GroupBox7.Controls.Add(this.cb_list_storesM);
            this.GroupBox7.Controls.Add(this.Subsidiaria);
            this.GroupBox7.Controls.Add(this.cb_sbs_noM);
            this.GroupBox7.Controls.Add(this.txt_previaInv);
            this.GroupBox7.Controls.Add(this.dg_PreviaInv);
            this.GroupBox7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GroupBox7.Location = new System.Drawing.Point(474, 6);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(479, 326);
            this.GroupBox7.TabIndex = 1;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Ejecucion";
            // 
            // bt_ejecturarInv
            // 
            this.bt_ejecturarInv.Location = new System.Drawing.Point(398, 171);
            this.bt_ejecturarInv.Name = "bt_ejecturarInv";
            this.bt_ejecturarInv.Size = new System.Drawing.Size(75, 23);
            this.bt_ejecturarInv.TabIndex = 44;
            this.bt_ejecturarInv.Text = "Ejecutar";
            this.bt_ejecturarInv.UseVisualStyleBackColor = true;
            this.bt_ejecturarInv.Click += new System.EventHandler(this.bt_ejecturarInv_Click);
            // 
            // cb_list_storesM
            // 
            this.cb_list_storesM.FormattingEnabled = true;
            this.cb_list_storesM.Location = new System.Drawing.Point(159, 54);
            this.cb_list_storesM.Name = "cb_list_storesM";
            this.cb_list_storesM.Size = new System.Drawing.Size(314, 94);
            this.cb_list_storesM.TabIndex = 43;
            // 
            // Subsidiaria
            // 
            this.Subsidiaria.AutoSize = true;
            this.Subsidiaria.Location = new System.Drawing.Point(26, 31);
            this.Subsidiaria.Name = "Subsidiaria";
            this.Subsidiaria.Size = new System.Drawing.Size(58, 13);
            this.Subsidiaria.TabIndex = 42;
            this.Subsidiaria.Text = "Subsidiaria";
            // 
            // cb_sbs_noM
            // 
            this.cb_sbs_noM.FormattingEnabled = true;
            this.cb_sbs_noM.Location = new System.Drawing.Point(16, 50);
            this.cb_sbs_noM.Name = "cb_sbs_noM";
            this.cb_sbs_noM.Size = new System.Drawing.Size(121, 21);
            this.cb_sbs_noM.TabIndex = 41;
            this.cb_sbs_noM.SelectedValueChanged += new System.EventHandler(this.cb_sbs_noM_SelectedValueChanged);
            // 
            // txt_previaInv
            // 
            this.txt_previaInv.Location = new System.Drawing.Point(6, 171);
            this.txt_previaInv.Name = "txt_previaInv";
            this.txt_previaInv.Size = new System.Drawing.Size(75, 23);
            this.txt_previaInv.TabIndex = 40;
            this.txt_previaInv.Text = "Previa";
            this.txt_previaInv.UseVisualStyleBackColor = true;
            this.txt_previaInv.Click += new System.EventHandler(this.txt_previaInv_Click);
            // 
            // dg_PreviaInv
            // 
            this.dg_PreviaInv.AllowUserToAddRows = false;
            this.dg_PreviaInv.AllowUserToDeleteRows = false;
            this.dg_PreviaInv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dg_PreviaInv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_PreviaInv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dg_PreviaInv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_PreviaInv.DefaultCellStyle = dataGridViewCellStyle11;
            this.dg_PreviaInv.EnableHeadersVisualStyles = false;
            this.dg_PreviaInv.Location = new System.Drawing.Point(6, 200);
            this.dg_PreviaInv.Name = "dg_PreviaInv";
            this.dg_PreviaInv.ReadOnly = true;
            this.dg_PreviaInv.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_PreviaInv.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dg_PreviaInv.RowHeadersVisible = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.dg_PreviaInv.RowsDefaultCellStyle = dataGridViewCellStyle13;
            this.dg_PreviaInv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_PreviaInv.Size = new System.Drawing.Size(467, 115);
            this.dg_PreviaInv.TabIndex = 39;
            // 
            // GB_FilterI
            // 
            this.GB_FilterI.Controls.Add(this.DGV_FiltrosCatalogo);
            this.GB_FilterI.Controls.Add(this.Label25);
            this.GB_FilterI.Controls.Add(this.Label24);
            this.GB_FilterI.Controls.Add(this.Label21);
            this.GB_FilterI.Controls.Add(this.Label22);
            this.GB_FilterI.Controls.Add(this.B_AgregarFiltroCat);
            this.GB_FilterI.Controls.Add(this.cb_codicionCat);
            this.GB_FilterI.Controls.Add(this.cb_operadorCat);
            this.GB_FilterI.Controls.Add(this.CHB_ActivarFiltrosCat);
            this.GB_FilterI.Controls.Add(this.txt_val_filt);
            this.GB_FilterI.Controls.Add(this.cb_rpro_Cat);
            this.GB_FilterI.ForeColor = System.Drawing.SystemColors.Highlight;
            this.GB_FilterI.Location = new System.Drawing.Point(6, 6);
            this.GB_FilterI.Name = "GB_FilterI";
            this.GB_FilterI.Size = new System.Drawing.Size(462, 360);
            this.GB_FilterI.TabIndex = 0;
            this.GB_FilterI.TabStop = false;
            this.GB_FilterI.Text = "Parametros";
            // 
            // DGV_FiltrosCatalogo
            // 
            this.DGV_FiltrosCatalogo.AllowUserToAddRows = false;
            this.DGV_FiltrosCatalogo.AllowUserToDeleteRows = false;
            this.DGV_FiltrosCatalogo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGV_FiltrosCatalogo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FiltrosCatalogo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DGV_FiltrosCatalogo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_FiltrosCatalogo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fc_operador,
            this.fc_campo_rpro,
            this.fc_condicion,
            this.fc_valor});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_FiltrosCatalogo.DefaultCellStyle = dataGridViewCellStyle15;
            this.DGV_FiltrosCatalogo.EnableHeadersVisualStyles = false;
            this.DGV_FiltrosCatalogo.Location = new System.Drawing.Point(3, 144);
            this.DGV_FiltrosCatalogo.Name = "DGV_FiltrosCatalogo";
            this.DGV_FiltrosCatalogo.ReadOnly = true;
            this.DGV_FiltrosCatalogo.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.SlateGray;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV_FiltrosCatalogo.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.DGV_FiltrosCatalogo.RowHeadersVisible = false;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            this.DGV_FiltrosCatalogo.RowsDefaultCellStyle = dataGridViewCellStyle17;
            this.DGV_FiltrosCatalogo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_FiltrosCatalogo.Size = new System.Drawing.Size(436, 216);
            this.DGV_FiltrosCatalogo.TabIndex = 38;
            this.DGV_FiltrosCatalogo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DGV_FiltrosCatalogo_KeyDown);
            // 
            // fc_operador
            // 
            this.fc_operador.HeaderText = "Operador";
            this.fc_operador.Name = "fc_operador";
            this.fc_operador.ReadOnly = true;
            this.fc_operador.Width = 80;
            // 
            // fc_campo_rpro
            // 
            this.fc_campo_rpro.HeaderText = "RPRO";
            this.fc_campo_rpro.Name = "fc_campo_rpro";
            this.fc_campo_rpro.ReadOnly = true;
            // 
            // fc_condicion
            // 
            this.fc_condicion.HeaderText = "Condicion";
            this.fc_condicion.Name = "fc_condicion";
            this.fc_condicion.ReadOnly = true;
            // 
            // fc_valor
            // 
            this.fc_valor.HeaderText = "Valor";
            this.fc_valor.Name = "fc_valor";
            this.fc_valor.ReadOnly = true;
            this.fc_valor.Width = 200;
            // 
            // Label25
            // 
            this.Label25.AutoSize = true;
            this.Label25.Location = new System.Drawing.Point(268, 32);
            this.Label25.Name = "Label25";
            this.Label25.Size = new System.Drawing.Size(54, 13);
            this.Label25.TabIndex = 37;
            this.Label25.Text = "Condicion";
            // 
            // Label24
            // 
            this.Label24.AutoSize = true;
            this.Label24.Location = new System.Drawing.Point(6, 32);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(51, 13);
            this.Label24.TabIndex = 36;
            this.Label24.Text = "Operador";
            // 
            // Label21
            // 
            this.Label21.AutoSize = true;
            this.Label21.Location = new System.Drawing.Point(23, 95);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(31, 13);
            this.Label21.TabIndex = 34;
            this.Label21.Text = "Valor";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Label22
            // 
            this.Label22.AutoSize = true;
            this.Label22.Location = new System.Drawing.Point(116, 32);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(38, 13);
            this.Label22.TabIndex = 35;
            this.Label22.Text = "RPRO";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // B_AgregarFiltroCat
            // 
            this.B_AgregarFiltroCat.Location = new System.Drawing.Point(230, 111);
            this.B_AgregarFiltroCat.Name = "B_AgregarFiltroCat";
            this.B_AgregarFiltroCat.Size = new System.Drawing.Size(75, 23);
            this.B_AgregarFiltroCat.TabIndex = 33;
            this.B_AgregarFiltroCat.Text = "Agregar";
            this.B_AgregarFiltroCat.UseVisualStyleBackColor = true;
            this.B_AgregarFiltroCat.Click += new System.EventHandler(this.B_AgregarFiltroCat_Click);
            // 
            // cb_codicionCat
            // 
            this.cb_codicionCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_codicionCat.FormattingEnabled = true;
            this.cb_codicionCat.Items.AddRange(new object[] {
            "IN",
            "=",
            ">",
            "<",
            "BETWEEN",
            "<>",
            "!="});
            this.cb_codicionCat.Location = new System.Drawing.Point(230, 54);
            this.cb_codicionCat.Name = "cb_codicionCat";
            this.cb_codicionCat.Size = new System.Drawing.Size(119, 21);
            this.cb_codicionCat.TabIndex = 32;
            // 
            // cb_operadorCat
            // 
            this.cb_operadorCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_operadorCat.FormattingEnabled = true;
            this.cb_operadorCat.Items.AddRange(new object[] {
            "AND",
            "OR"});
            this.cb_operadorCat.Location = new System.Drawing.Point(3, 54);
            this.cb_operadorCat.Name = "cb_operadorCat";
            this.cb_operadorCat.Size = new System.Drawing.Size(65, 21);
            this.cb_operadorCat.TabIndex = 31;
            // 
            // CHB_ActivarFiltrosCat
            // 
            this.CHB_ActivarFiltrosCat.AutoSize = true;
            this.CHB_ActivarFiltrosCat.Location = new System.Drawing.Point(384, 54);
            this.CHB_ActivarFiltrosCat.Name = "CHB_ActivarFiltrosCat";
            this.CHB_ActivarFiltrosCat.Size = new System.Drawing.Size(59, 17);
            this.CHB_ActivarFiltrosCat.TabIndex = 30;
            this.CHB_ActivarFiltrosCat.Text = "Activar";
            this.CHB_ActivarFiltrosCat.UseVisualStyleBackColor = true;
            this.CHB_ActivarFiltrosCat.CheckedChanged += new System.EventHandler(this.CHB_ActivarFiltrosCat_CheckedChanged);
            // 
            // txt_val_filt
            // 
            this.txt_val_filt.Location = new System.Drawing.Point(3, 111);
            this.txt_val_filt.Name = "txt_val_filt";
            this.txt_val_filt.Size = new System.Drawing.Size(210, 20);
            this.txt_val_filt.TabIndex = 29;
            // 
            // cb_rpro_Cat
            // 
            this.cb_rpro_Cat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_rpro_Cat.FormattingEnabled = true;
            this.cb_rpro_Cat.Items.AddRange(new object[] {
            "ACTIVE",
            "QTY",
            "D",
            "C",
            "S"});
            this.cb_rpro_Cat.Location = new System.Drawing.Point(74, 54);
            this.cb_rpro_Cat.Name = "cb_rpro_Cat";
            this.cb_rpro_Cat.Size = new System.Drawing.Size(139, 21);
            this.cb_rpro_Cat.TabIndex = 28;
            // 
            // TabPage8
            // 
            this.TabPage8.BackColor = System.Drawing.SystemColors.Control;
            this.TabPage8.Controls.Add(this.bt_GuardarCredI);
            this.TabPage8.Controls.Add(this.txt_tokenI);
            this.TabPage8.Controls.Add(this.Label20);
            this.TabPage8.Controls.Add(this.txt_urlInv);
            this.TabPage8.Controls.Add(this.Label13);
            this.TabPage8.ForeColor = System.Drawing.SystemColors.Highlight;
            this.TabPage8.Location = new System.Drawing.Point(4, 22);
            this.TabPage8.Name = "TabPage8";
            this.TabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage8.Size = new System.Drawing.Size(959, 368);
            this.TabPage8.TabIndex = 0;
            this.TabPage8.Text = "Configuracion Interfaz";
            // 
            // bt_GuardarCredI
            // 
            this.bt_GuardarCredI.Location = new System.Drawing.Point(365, 273);
            this.bt_GuardarCredI.Name = "bt_GuardarCredI";
            this.bt_GuardarCredI.Size = new System.Drawing.Size(75, 23);
            this.bt_GuardarCredI.TabIndex = 4;
            this.bt_GuardarCredI.Text = "Guardar";
            this.bt_GuardarCredI.UseVisualStyleBackColor = true;
            this.bt_GuardarCredI.Click += new System.EventHandler(this.bt_GuardarCredI_Click);
            // 
            // txt_tokenI
            // 
            this.txt_tokenI.Location = new System.Drawing.Point(90, 143);
            this.txt_tokenI.Name = "txt_tokenI";
            this.txt_tokenI.Size = new System.Drawing.Size(333, 20);
            this.txt_tokenI.TabIndex = 3;
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(6, 143);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(41, 13);
            this.Label20.TabIndex = 2;
            this.Label20.Text = "Token:";
            // 
            // txt_urlInv
            // 
            this.txt_urlInv.Location = new System.Drawing.Point(90, 68);
            this.txt_urlInv.Name = "txt_urlInv";
            this.txt_urlInv.Size = new System.Drawing.Size(270, 20);
            this.txt_urlInv.TabIndex = 1;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(6, 68);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(52, 13);
            this.Label13.TabIndex = 0;
            this.Label13.Text = "Endpoint:";
            // 
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage1);
            this.TabControl1.Controls.Add(this.TabPage2);
            this.TabControl1.Controls.Add(this.tabPage3);
            this.TabControl1.Controls.Add(this.TabPage13);
            this.TabControl1.Controls.Add(this.TabPage5);
            this.TabControl1.Controls.Add(this.TabPage9);
            this.TabControl1.Location = new System.Drawing.Point(12, 12);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(984, 426);
            this.TabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TabControl5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(976, 400);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Movimientos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TabControl5
            // 
            this.TabControl5.Controls.Add(this.TabPage12);
            this.TabControl5.Location = new System.Drawing.Point(6, 6);
            this.TabControl5.Name = "TabControl5";
            this.TabControl5.SelectedIndex = 0;
            this.TabControl5.Size = new System.Drawing.Size(780, 412);
            this.TabControl5.TabIndex = 0;
            // 
            // TabPage12
            // 
            this.TabPage12.Controls.Add(this.bt_GuardarMov);
            this.TabPage12.Controls.Add(this.txt_tokenMov);
            this.TabPage12.Controls.Add(this.Label39);
            this.TabPage12.Controls.Add(this.txt_urlMov);
            this.TabPage12.Controls.Add(this.Label40);
            this.TabPage12.Location = new System.Drawing.Point(4, 22);
            this.TabPage12.Name = "TabPage12";
            this.TabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage12.Size = new System.Drawing.Size(772, 386);
            this.TabPage12.TabIndex = 0;
            this.TabPage12.Text = "Configuración de la Interfaz";
            this.TabPage12.UseVisualStyleBackColor = true;
            // 
            // bt_GuardarMov
            // 
            this.bt_GuardarMov.Location = new System.Drawing.Point(6, 90);
            this.bt_GuardarMov.Name = "bt_GuardarMov";
            this.bt_GuardarMov.Size = new System.Drawing.Size(75, 23);
            this.bt_GuardarMov.TabIndex = 4;
            this.bt_GuardarMov.Text = "Guardar";
            this.bt_GuardarMov.UseVisualStyleBackColor = true;
            this.bt_GuardarMov.Click += new System.EventHandler(this.bt_GuardarMov_Click);
            // 
            // txt_tokenMov
            // 
            this.txt_tokenMov.Location = new System.Drawing.Point(6, 64);
            this.txt_tokenMov.Name = "txt_tokenMov";
            this.txt_tokenMov.Size = new System.Drawing.Size(376, 20);
            this.txt_tokenMov.TabIndex = 3;
            // 
            // Label39
            // 
            this.Label39.AutoSize = true;
            this.Label39.Location = new System.Drawing.Point(6, 48);
            this.Label39.Name = "Label39";
            this.Label39.Size = new System.Drawing.Size(38, 13);
            this.Label39.TabIndex = 2;
            this.Label39.Text = "Token";
            // 
            // txt_urlMov
            // 
            this.txt_urlMov.Location = new System.Drawing.Point(6, 25);
            this.txt_urlMov.Name = "txt_urlMov";
            this.txt_urlMov.Size = new System.Drawing.Size(376, 20);
            this.txt_urlMov.TabIndex = 1;
            // 
            // Label40
            // 
            this.Label40.AutoSize = true;
            this.Label40.Location = new System.Drawing.Point(6, 9);
            this.Label40.Name = "Label40";
            this.Label40.Size = new System.Drawing.Size(29, 13);
            this.Label40.TabIndex = 0;
            this.Label40.Text = "URL";
            // 
            // TabPage13
            // 
            this.TabPage13.Controls.Add(this.button1);
            this.TabPage13.Controls.Add(this.button2);
            this.TabPage13.Controls.Add(this.dgv_configuracionPrecios);
            this.TabPage13.Controls.Add(this.bt_GuardarPrecios);
            this.TabPage13.Controls.Add(this.txt_tokenPrecios);
            this.TabPage13.Controls.Add(this.Label41);
            this.TabPage13.Controls.Add(this.txt_urlPrecios);
            this.TabPage13.Controls.Add(this.Label42);
            this.TabPage13.Location = new System.Drawing.Point(4, 22);
            this.TabPage13.Name = "TabPage13";
            this.TabPage13.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage13.Size = new System.Drawing.Size(976, 400);
            this.TabPage13.TabIndex = 1;
            this.TabPage13.Text = "Configuración de Precios";
            this.TabPage13.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(398, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 46;
            this.button1.Text = "Ejecutar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 45;
            this.button2.Text = "Previa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dgv_configuracionPrecios
            // 
            this.dgv_configuracionPrecios.AllowUserToAddRows = false;
            this.dgv_configuracionPrecios.AllowUserToDeleteRows = false;
            this.dgv_configuracionPrecios.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_configuracionPrecios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_configuracionPrecios.Location = new System.Drawing.Point(6, 194);
            this.dgv_configuracionPrecios.Name = "dgv_configuracionPrecios";
            this.dgv_configuracionPrecios.ReadOnly = true;
            this.dgv_configuracionPrecios.RowHeadersVisible = false;
            this.dgv_configuracionPrecios.Size = new System.Drawing.Size(467, 200);
            this.dgv_configuracionPrecios.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 450);
            this.Controls.Add(this.TabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Panel Conf. DataLake";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.TabPage9.ResumeLayout(false);
            this.TabControl2.ResumeLayout(false);
            this.TabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tiendas_tiemposI)).EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.TabPage7.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_mapeoInventario)).EndInit();
            this.TabPageCorreo.ResumeLayout(false);
            this.TabPageCorreo.PerformLayout();
            this.TabPage5.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabPage2.ResumeLayout(false);
            this.TabControl4.ResumeLayout(false);
            this.TabPage11.ResumeLayout(false);
            this.GP_EjecD.ResumeLayout(false);
            this.GP_EjecD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.GP_FilterD.ResumeLayout(false);
            this.GP_FilterD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv_filtrosD)).EndInit();
            this.TabPage1.ResumeLayout(false);
            this.TabControl3.ResumeLayout(false);
            this.TabPage10.ResumeLayout(false);
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_PreviaInv)).EndInit();
            this.GB_FilterI.ResumeLayout(false);
            this.GB_FilterI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FiltrosCatalogo)).EndInit();
            this.TabPage8.ResumeLayout(false);
            this.TabPage8.PerformLayout();
            this.TabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.TabControl5.ResumeLayout(false);
            this.TabPage12.ResumeLayout(false);
            this.TabPage12.PerformLayout();
            this.TabPage13.ResumeLayout(false);
            this.TabPage13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_configuracionPrecios)).EndInit();
            this.ResumeLayout(false);

        }

        internal TabPage TabPage9;
        internal TabControl TabControl2;
        internal TabPage TabPage6;
        internal Button bt_agregarTieI;
        internal DataGridView dgv_tiendas_tiemposI;
        internal DataGridViewTextBoxColumn fc_sbs_no;
        internal DataGridViewTextBoxColumn fc_store_no;
        internal DataGridViewTextBoxColumn fc_lunes;
        internal DataGridViewTextBoxColumn fc_hora_lu;
        internal DataGridViewTextBoxColumn fc_martes;
        internal DataGridViewTextBoxColumn fc_hora_ma;
        internal DataGridViewTextBoxColumn fc_miercoles;
        internal DataGridViewTextBoxColumn fc_hora_Mi;
        internal DataGridViewTextBoxColumn fc_jueves;
        internal DataGridViewTextBoxColumn fc_hora_Ju;
        internal DataGridViewTextBoxColumn fc_viernes;
        internal DataGridViewTextBoxColumn fc_hora_Vi;
        internal DataGridViewTextBoxColumn fc_sabado;
        internal DataGridViewTextBoxColumn fc_hora_Sa;
        internal DataGridViewTextBoxColumn fc_domingo;
        internal DataGridViewTextBoxColumn fc_hora_do;
        internal GroupBox GroupBox5;
        internal TextBox txt_tiempo;
        internal Label Label30;
        internal TextBox txt_notiMail_Inv;
        internal Label Label8;
        internal GroupBox GroupBox3;
        internal ComboBox cb_hSa;
        internal ComboBox cb_hVie;
        internal ComboBox cb_hJue;

        internal ComboBox cb_hMi;
        internal ComboBox cb_hMar;
        internal Label Label37;
        internal Label Label36;
        internal Label Label35;
        internal Label Label34;
        internal Label Label33;
        internal Label Label32;
        internal ComboBox cb_hLun;
        internal ComboBox cb_interfazD;
        internal ComboBox cb_interfazS;
        internal ComboBox cb_interfazV;
        internal ComboBox cb_interfazJ;
        internal ComboBox cb_interfazMI;
        internal ComboBox cb_interfazM;
        internal Label Label19;
        internal Label Label18;
        internal Label Label17;
        internal Label Label16;
        internal Label Label15;
        internal Label Label14;
        internal Label Label12;
        internal ComboBox cb_interfazL;
        internal Label Label7;
        internal ComboBox cb_tiempoInv;
        internal Button bt_guardarConfInv;
        internal GroupBox GroupBox2;
        internal Label Label11;
        internal ComboBox cb_store_I;
        internal Label Label6;
        internal ComboBox cb_subsidiariaInv;
        internal ComboBox cb_mapeo_tipo; 
        internal TabPage TabPage7;
        internal Button bt_GuardarMapI;
        internal GroupBox GroupBox6;
        internal Label Label10;
        internal Label Label9;
        internal Button bt_agregarI;
        internal TextBox txt_dalake_campI;
        internal ComboBox cb_rpro_campI;
        internal DataGridView dgv_mapeoInventario;
        internal DataGridViewTextBoxColumn mc_campo_rpro;
        internal DataGridViewTextBoxColumn mc_datalake;
        internal DataGridViewTextBoxColumn mc_tipo;
        internal TabPage TabPage5;
        internal GroupBox GroupBox1;
        internal ComboBox cb_db_con;
        internal Label Label31;
        internal Button bt_guardar_db;
        internal Button bt_test_db;
        internal TextBox txt_pass_db;
        internal Label Label5;
        internal TextBox txt_user_db;
        internal Label Label4;
        internal TextBox txt_port_db;
        internal Label Label3;
        internal TextBox txt_db_name;
        internal Label Label2;
        internal TextBox txt_host_db;
        internal Label Label1;
        internal TabPage TabPage2;
        internal TabControl TabControl4;
        internal TabPage TabPage11;
        internal Button B_SetConfCat_FilterD;
        internal GroupBox GP_EjecD;
        internal Button bt_ejecturarD;
        internal CheckedListBox cb_list_storesD;
        internal Label Label23;
        internal ComboBox cb_sbs_noD;
        internal Button bt_previaD;
        internal DataGridView DataGridView1;
        internal GroupBox GP_FilterD;
        internal DataGridView gv_filtrosD;
        internal DataGridViewTextBoxColumn fc_operadorD;
        internal DataGridViewTextBoxColumn fc_campo_rproD;
        internal DataGridViewTextBoxColumn fc_condicionD;
        internal DataGridViewTextBoxColumn fc_valorD;
        internal Label Label26;
        internal Label Label27;
        internal Label Label28;
        internal Label Label29;
        internal Button bt_agregarFiltrosD;
        internal ComboBox cb_condicionD;
        internal ComboBox cb_operadorD;
        internal CheckBox ch_activalFiltrosD;
        internal TextBox txt_valD;
        internal ComboBox cb_rproD;
        internal TabPage TabPage1;
        internal TabControl TabControl3;
        internal TabPage TabPage10;
        internal Button B_SetConfCat_Filter;
        internal GroupBox GroupBox7;
        internal Button bt_ejecturarInv;
        internal CheckedListBox cb_list_storesM;
        internal Label Subsidiaria;
        internal ComboBox cb_sbs_noM;
        internal Button txt_previaInv;
        internal DataGridView dg_PreviaInv;
        internal GroupBox GB_FilterI;
        internal DataGridView DGV_FiltrosCatalogo;
        internal DataGridViewTextBoxColumn fc_operador;
        internal DataGridViewTextBoxColumn fc_campo_rpro;
        internal DataGridViewTextBoxColumn fc_condicion;
        internal DataGridViewTextBoxColumn fc_valor;
        internal Label Label25;
        internal Label Label24;
        internal Label Label21;
        internal Label Label22;
        internal Button B_AgregarFiltroCat;
        internal ComboBox cb_codicionCat;
        internal ComboBox cb_operadorCat;
        internal CheckBox CHB_ActivarFiltrosCat;
        internal TextBox txt_val_filt;
        internal ComboBox cb_rpro_Cat;
        internal TabPage TabPage8;
        internal Button bt_GuardarCredI;
        internal TextBox txt_tokenI;
        internal Label Label20;
        internal TextBox txt_urlInv;
        internal Label Label13;
        internal TabControl TabControl1;
        internal TabControl TabControl5;
        private TabPage tabPage3;
        internal TabPage TabPage12; // Cambiado de TabPage8 a TabPage12
        internal Button bt_GuardarMov; // Cambiado de bt_GuardarCredI a bt_GuardarMov
        internal TextBox txt_tokenMov; // Cambiado de txt_tokenI a txt_tokenMov
        internal Label Label39; // Cambiado de Label20 a Label39
        internal TextBox txt_urlMov; // Cambiado de txt_urlInv a txt_urlMov
        internal Label Label40; // Cambiado de Label13 a Label40
        internal TabPage TabPage13;
        internal Button bt_GuardarPrecios;
        internal TextBox txt_tokenPrecios;
        internal Label Label41;
        internal TextBox txt_urlPrecios;
        internal Label Label42;
        internal Label label38;
        internal TabPage TabPageCorreo;
        internal DataGridView dgv_configuracionPrecios; // Agregar esta línea
        private Label lblSmtpServer;
        private TextBox txtSmtpServer;
        private Label lblPort;
        private TextBox txtPort;
        private Label lblUsername;
        private TextBox txtUsername;
        private Button btnSaveEmailConfig;
        private TextBox txtRecipientEmails;
        private Label lblRecipientEmails;
        private Button btnSendTestEmail;
        internal Button button1;
        internal Button button2;
    }
}