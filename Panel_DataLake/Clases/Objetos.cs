using System.Collections.Generic;

namespace Panel_DataLake
{
    /// <summary>
    /// Representa las credenciales necesarias para conectarse a una plataforma.
    /// </summary>
    public class Credenciales
    {
        /// <summary>
        /// Plataforma a la que se conecta.
        /// </summary>
        public string plataforma { get; set; }

        /// <summary>
        /// Dirección IP de la plataforma.
        /// </summary>
        public string ip { get; set; }

        /// <summary>
        /// Puerto de conexión.
        /// </summary>
        public string puerto { get; set; }

        /// <summary>
        /// Nombre de usuario para la conexión.
        /// </summary>
        public string usuario { get; set; }

        /// <summary>
        /// Contraseña para la conexión.
        /// </summary>
        public string password { get; set; }

        /// <summary>
        /// Base de datos a la que se conecta.
        /// </summary>
        public string db { get; set; }

        /// <summary>
        /// Proveedor de la base de datos.
        /// </summary>
        public string proveedor { get; set; }
    }

    /// <summary>
    /// Representa las credenciales necesarias para el inventario final.
    /// </summary>
    public class CredenEndInv
    {
        /// <summary>
        /// URL del inventario final.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Token de acceso para el inventario final.
        /// </summary>
        public string token { get; set; }
    }

    public class CredenEndMovimientos
    {
        /// <summary>
        /// URL del inventario final.
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// Token de acceso para el inventario final.
        /// </summary>
        public string token { get; set; }
    }

    public class CredenEndPrecios
    {

        public string url { get; set; }


        public string token { get; set; }
    }

    /// <summary>  
    /// Configuración del stock.  
    /// </summary>  
    public class ConfStock
    {
        public ConfStock()
        {
            tiendas = new List<Tienda>();
            filtros = new List<Filtro>();
            nodos_json = new List<NodoJson>();
            Mapeos = new List<Mapeo>();
            ecommerce = new EcommerceCodeStock();
            api = new ApiStock();
        }

        /// <summary>  
        /// Tiempo de configuración.  
        /// </summary>  
        public string tiempo { get; set; }

        /// <summary>  
        /// Tiempo de ejecución.  
        /// </summary>  
        public string TiempoEjec { get; set; }

        /// <summary>  
        /// Lista de tiendas.  
        /// </summary>  
        public List<Tienda> tiendas { get; set; }

        /// <summary>  
        /// Indica si está activo el lunes.  
        /// </summary>  
        public bool Lunes { get; set; }

        /// <summary>  
        /// Indica si está activo el martes.  
        /// </summary>  
        public bool Martes { get; set; }

        /// <summary>  
        /// Indica si está activo el miércoles.  
        /// </summary>  
        public bool Miercoles { get; set; }

        /// <summary>  
        /// Indica si está activo el jueves.  
        /// </summary>  
        public bool Jueves { get; set; }

        /// <summary>  
        /// Indica si está activo el viernes.  
        /// </summary>  
        public bool Viernes { get; set; }

        /// <summary>  
        /// Indica si está activo el sábado.  
        /// </summary>  
        public bool Sabado { get; set; }

        /// <summary>  
        /// Indica si está activo el domingo.  
        /// </summary>  
        public bool Domingo { get; set; }

        /// <summary>  
        /// Correo electrónico.  
        /// </summary>  
        public string Mail { get; set; }

        /// <summary>  
        /// Lista de filtros.  
        /// </summary>  
        public List<Filtro> filtros { get; set; }

        /// <summary>  
        /// Lista de nodos JSON.  
        /// </summary>  
        public List<NodoJson> nodos_json { get; set; }

        /// <summary>  
        /// Lista de mapeos.  
        /// </summary>  
        public List<Mapeo> Mapeos { get; set; }

        /// <summary>  
        /// Código de stock de comercio electrónico.  
        /// </summary>  
        public EcommerceCodeStock ecommerce { get; set; }

        /// <summary>  
        /// API de stock.  
        /// </summary>  
        public ApiStock api { get; set; }
    }


    public class Tienda
    {
        public string sbs_no { get; set; }
        public string store_no { get; set; }
    }

    public class ConfDelta
    {

        public ConfDelta()
        {
            tiendasD = new List<TiendaD>();
            filtros = new List<Filtro>();
        }
        public List<TiendaD> tiendasD { get; set; }
        public bool activar_filtros { get; set; }
        public List<Filtro> filtros { get; set; }
    }

    public class TiendaD
    {
        public string sbs_no { get; set; }
        public string store_no { get; set; }
    }

    public class Filtro
    {
        public string operador { get; set; }
        public string campo_rpro { get; set; }
        public string condicion { get; set; }
        public string valor { get; set; }
    }

    public class ConfUrlTiendas
    {
        public ConfUrlTiendas()
        {
            TiendasUrl = new List<TiendaUrl>();

        }


        public List<TiendaUrl> TiendasUrl { get; set; }

    }

    public class TiendaUrl
    {
        public string Lunes { get; set; }
        public string Martes { get; set; }
        public string Miercoles { get; set; }
        public string Jueves { get; set; }
        public string Viernes { get; set; }
        public string Sabado { get; set; }
        public string Domingo { get; set; }
        public string sbs_no { get; set; }
        public string store_no { get; set; }
        public string tiempo { get; set; }
        public string Lu_tiempo { get; set; }
        public string Mar_tiempo { get; set; }
        public string Mie_tiempo { get; set; }
        public string Ju_tiempo { get; set; }
        public string Vi_tiempo { get; set; }
        public string Sa_tiempo { get; set; }

    }

    public class NodoJson
    {
        public string nivel { get; set; }
        public string padre { get; set; }
        public string name { get; set; }
        public string tipo { get; set; }
    }

    public class Mapeo
    {
        public string ecommerce { get; set; }
        public string campo_rpro { get; set; }
        public string tipo { get; set; }
    }

    public class EcommerceCodeStock
    {
        public string campo_rpro { get; set; }
        public string valor { get; set; }
        public bool activar { get; set; }
    }

    public class ApiStock
    {
        public ApiStock()
        {
            credenciales = new CredencialesToken();
            urls = new URLsStock();
            headers = new List<Header>();
        }

        public CredencialesToken credenciales { get; set; }
        public URLsStock urls { get; set; }
        public List<Header> headers { get; set; }
    }

    public class CredencialesToken
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string URL { get; set; }
        public bool Activar { get; set; }
    }

    public class URLsStock
    {
        public string URLIdWHoLOTStock { get; set; }
        public bool ActivarIdWHoLOTStock { get; set; }
        public string URLValidarStock { get; set; }
        public bool ActivarValidarStock { get; set; }
        public string URLStock { get; set; }
    }

    public class Header
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class ConfCat
    {
        public ConfCat()
        {
            filtros = new List<Filtro>();
            Mapeos = new List<Mapeo>();
            api = new ApiCat();
        }

        public bool activar_filtros { get; set; }
        public List<Filtro> filtros { get; set; }
        public List<Mapeo> Mapeos { get; set; }
        public ApiCat api { get; set; }
    }

    public class confLisPrice
    {
        public string SBS_NO { get; set; }
        public string PRICE_LVL { get; set; }
    }

    public class ApiCat
    {
        public ApiCat()
        {
            credenciales = new CredencialesToken();
            urls = new URLsCat();
            headers = new List<Header>();
        }

        public CredencialesToken credenciales { get; set; }
        public URLsCat urls { get; set; }
        public List<Header> headers { get; set; }
    }

    public class URLsCat
    {
        public string URLValidarItemCat { get; set; }
        public bool ActivarValidarItemCat { get; set; }
        public string URLCrearItem { get; set; }
        public string URLActualizarItem { get; set; }
    }

    public class ElementItems
    {

        public string sku { get; set; }
        public string id_sociedad { get; set; }
        public string id_centro { get; set; }
        public string id_almacen { get; set; }
        public string qty { get; set; }
        public string original_price { get; set; }
        public string regular_price { get; set; }

    }

    public class ListasCB
    {

        public List<CBItem> GetListDBType()
        {
            var List = new List<CBItem>();

            List.Add(new CBItem("oracle_9", "RetailPro9"));
            List.Add(new CBItem("oracle_10", "Prism (Oracle)"));
            List.Add(new CBItem("mysql_10", "Prism (MySQL)"));

            return List;
        }
        public List<CBItem> GetListRetailProFields(ref string type_retail)
        {
            var List = new List<CBItem>();

            if (type_retail == "oracle_9")
            {
                List.Add(new CBItem("IP.PRICE", "PRICE"));
                List.Add(new CBItem("TRIM('')", "VACIO"));
                List.Add(new CBItem("TRIM(I.ALU)", "ALU"));
                List.Add(new CBItem("TO_CHAR(I.CREATED_DATE,'DD/MM/YYYY')", "CREATED_DATE"));
                List.Add(new CBItem("I.LOCAL_UPC", "UPC"));
                List.Add(new CBItem("I.ACTIVE", "ACTIVE"));
                List.Add(new CBItem("D.DCS_CODE", "DCS_CODE"));
                List.Add(new CBItem("D.D_NAME", "DEPT NAME"));
                List.Add(new CBItem("D.C_NAME", "CLASS NAME"));
                List.Add(new CBItem("D.S_NAME", "SUBCLASS NAME"));
                List.Add(new CBItem("SUBSTR(D.DCS_CODE,0,3)", "D_CODE"));
                List.Add(new CBItem("SUBSTR(D.DCS_CODE,4,3)", "C_CODE"));
                List.Add(new CBItem("SUBSTR(D.DCS_CODE,7,3)", "S_CODE"));
                List.Add(new CBItem("I.DESCRIPTION1", "DESCRIPTION 1"));
                List.Add(new CBItem("I.DESCRIPTION2", "DESCRIPTION 2"));
                List.Add(new CBItem("I.DESCRIPTION3", "DESCRIPTION 3"));
                List.Add(new CBItem("I.DESCRIPTION4", "DESCRIPTION 4"));
                List.Add(new CBItem("Q.QTY", "QTY"));
                List.Add(new CBItem("SUM(Q.QTY)", "SUMA(QTY)"));
                List.Add(new CBItem("U.UDF1_VALUE", "UDF1"));
                List.Add(new CBItem("U.UDF2_VALUE", "UDF2"));
                List.Add(new CBItem("U.UDF3_VALUE", "UDF3"));
                List.Add(new CBItem("U.UDF4_VALUE", "UDF4"));
                List.Add(new CBItem("U.UDF5_VALUE", "UDF5"));
                List.Add(new CBItem("U.UDF6_VALUE", "UDF6"));
                List.Add(new CBItem("U.AUX1_VALUE", "AUX1"));
                List.Add(new CBItem("U.AUX2_VALUE", "AUX2"));
                List.Add(new CBItem("U.AUX3_VALUE", "AUX3"));
                List.Add(new CBItem("U.AUX4_VALUE", "AUX4"));
                List.Add(new CBItem("U.AUX5_VALUE", "AUX5"));
                List.Add(new CBItem("U.AUX6_VALUE", "AUX6"));
                List.Add(new CBItem("U.AUX7_VALUE", "AUX7"));
                List.Add(new CBItem("U.AUX8_VALUE", "AUX8"));
                List.Add(new CBItem("I.SIZ", "SIZ"));
                List.Add(new CBItem("I.ATTR", "ATTR"));
                List.Add(new CBItem("V.VEND_CODE", "VEND_CODE"));
                List.Add(new CBItem("V.VEND_NAME", "VEND_NAME"));
                List.Add(new CBItem("I.COST", "COST"));
                List.Add(new CBItem("I.TEXT1", "TEXT1"));
                List.Add(new CBItem("I.TEXT2", "TEXT2"));
                List.Add(new CBItem("I.TEXT3", "TEXT3"));
                List.Add(new CBItem("I.TEXT4", "TEXT4"));
                List.Add(new CBItem("I.TEXT5", "TEXT5"));
                List.Add(new CBItem("I.TEXT6", "TEXT6"));
                List.Add(new CBItem("I.TEXT7", "TEXT7"));
                List.Add(new CBItem("I.TEXT8", "TEXT8"));
                List.Add(new CBItem("I.TEXT9", "TEXT9"));
                List.Add(new CBItem("I.TEXT10", "TEXT10"));
                // TABLA HAPP CARGA ARTICULOS
                List.Add(new CBItem("H.SKU_PADRE", "SKU_PADRE_HAPP"));
                List.Add(new CBItem("H.SKU", "SKU_HAPP"));
                List.Add(new CBItem("H.NAME", "NAME_HAPP"));
                List.Add(new CBItem("H.DESCRIPTION", "DESCRIPTION_HAPP"));
                List.Add(new CBItem("H.PRICE", "PRICE_HAPP"));
                List.Add(new CBItem("H.ESTADO", "ESTADO_HAPP"));
                List.Add(new CBItem("H.TAXONOMY", "TAXONOMY_HAPP"));
                List.Add(new CBItem("H.COLOR", "COLOR_HAPP"));
                List.Add(new CBItem("H.TALLA", "TALLA_HAPP"));
                List.Add(new CBItem("H.STORE_CODE", "STORE_CODE_HAPP"));
                List.Add(new CBItem("H.SBS_NO", "SBS_NO_HAPP"));
                List.Add(new CBItem("H.COMERCIO", "COMERCIO_HAPP"));
            }



            else if (type_retail == "oracle_10")
            {
                List.Add(new CBItem("IP.PRICE", "PRICE"));
                List.Add(new CBItem("TRIM('')", "VACIO"));
                List.Add(new CBItem("TRIM(invn.ALU)", "ALU"));
                List.Add(new CBItem("TO_CHAR(invn.CREATED_DATETIME,'DD/MM/YYYY')", "CREATED_DATE"));
                List.Add(new CBItem("invn.ACTIVE", "ACTIVE"));
                List.Add(new CBItem("invn.UPC", "UPC"));
                List.Add(new CBItem("D.DCS_CODE", "DCS_CODE"));
                List.Add(new CBItem("invn.DESCRIPTION1", "DESCRIPTION 1"));
                List.Add(new CBItem("invn.DESCRIPTION2", "DESCRIPTION 2"));
                List.Add(new CBItem("invn.DESCRIPTION3", "DESCRIPTION 3"));
                List.Add(new CBItem("invn.DESCRIPTION4", "DESCRIPTION 4"));
                List.Add(new CBItem("Q.QTY", "QTY"));
                List.Add(new CBItem("SUM(Q.QTY)", "SUMA(QTY)"));
                List.Add(new CBItem("invn.UDF1_STRING", "UDF1_STRING"));
                List.Add(new CBItem("invn.UDF2_STRING", "UDF2_STRING"));
                List.Add(new CBItem("invn.UDF3_STRING", "UDF3_STRING"));
                List.Add(new CBItem("invn.UDF4_STRING", "UDF4_STRING"));
                List.Add(new CBItem("invn.UDF5_STRING", "UDF5_STRING"));
                List.Add(new CBItem("U.UDF6_STRING", "UDF6_STRING"));
                List.Add(new CBItem("U.UDF7_STRING", "UDF7_STRING"));
                List.Add(new CBItem("U.UDF8_STRING", "UDF8_STRING"));
                List.Add(new CBItem("U.UDF9_STRING", "UDF9_STRING"));
                List.Add(new CBItem("U.UDF10_STRING", "UDF10_STRING"));
                List.Add(new CBItem("U.UDF11_STRING", "UDF11_STRING"));
                List.Add(new CBItem("U.UDF12_STRING", "UDF12_STRING"));
                List.Add(new CBItem("U.UDF13_STRING", "UDF13_STRING"));
                List.Add(new CBItem("U.UDF14_STRING", "UDF14_STRING"));
                List.Add(new CBItem("invn.ITEM_SIZE", "ITEM_SIZE"));
                List.Add(new CBItem("invn.ATTRIBUTE", "ATTRIBUTE"));
                List.Add(new CBItem("VEND_CODE", "VEND_CODE"));
                List.Add(new CBItem("invn.COST", "COST"));
                List.Add(new CBItem("invn.TEXT1", "TEXT1"));
                List.Add(new CBItem("invn.TEXT2", "TEXT2"));
                List.Add(new CBItem("invn.TEXT3", "TEXT3"));
                List.Add(new CBItem("invn.TEXT4", "TEXT4"));
                List.Add(new CBItem("invn.TEXT5", "TEXT5"));
                List.Add(new CBItem("invn.TEXT6", "TEXT6"));
                List.Add(new CBItem("invn.TEXT7", "TEXT7"));
                List.Add(new CBItem("invn.TEXT8", "TEXT8"));
                List.Add(new CBItem("invn.TEXT9", "TEXT9"));
                List.Add(new CBItem("invn.TEXT10", "TEXT10"));
                // TABLA HAPP CARGA ARTICULOS
                List.Add(new CBItem("H.SKU_PADRE", "SKU_PADRE_HAPP"));
                List.Add(new CBItem("H.SKU", "SKU_HAPP"));
                List.Add(new CBItem("H.NAME", "NAME_HAPP"));
                List.Add(new CBItem("H.DESCRIPTION", "DESCRIPTION_HAPP"));
                List.Add(new CBItem("H.PRICE", "PRICE_HAPP"));
                List.Add(new CBItem("H.ESTADO", "ESTADO_HAPP"));
                List.Add(new CBItem("H.TAXONOMY", "TAXONOMY_HAPP"));
                List.Add(new CBItem("H.COLOR", "COLOR_HAPP"));
                List.Add(new CBItem("H.TALLA", "TALLA_HAPP"));
                List.Add(new CBItem("H.STORE_CODE", "STORE_CODE_HAPP"));
                List.Add(new CBItem("H.SBS_NO", "SBS_NO_HAPP"));
                List.Add(new CBItem("H.COMERCIO", "COMERCIO_HAPP"));
            }

            else if (type_retail == "mysql_10")
            {
                List.Add(new CBItem("IP.PRICE", "PRICE"));
                List.Add(new CBItem("' '", "VACIO"));
                List.Add(new CBItem("I.ALU", "ALU"));
                List.Add(new CBItem("TO_CHAR(I.CREATED_DATETIME,'DD/MM/YYYY')", "CREATED_DATE"));
                List.Add(new CBItem("I.ACTIVE", "ACTIVE"));
                List.Add(new CBItem("I.UPC", "UPC"));
                List.Add(new CBItem("D.DCS_CODE", "DCS_CODE"));
                List.Add(new CBItem("I.DESCRIPTION1", "DESCRIPTION 1"));
                List.Add(new CBItem("I.DESCRIPTION2", "DESCRIPTION 2"));
                List.Add(new CBItem("I.DESCRIPTION3", "DESCRIPTION 3"));
                List.Add(new CBItem("I.DESCRIPTION4", "DESCRIPTION 4"));
                List.Add(new CBItem("Q.QTY", "QTY"));
                List.Add(new CBItem("SUM(Q.QTY)", "SUMA(QTY)"));
                List.Add(new CBItem("I.UDF1_STRING", "UDF1_STRING"));
                List.Add(new CBItem("I.UDF2_STRING", "UDF2_STRING"));
                List.Add(new CBItem("I.UDF3_STRING", "UDF3_STRING"));
                List.Add(new CBItem("I.UDF4_STRING", "UDF4_STRING"));
                List.Add(new CBItem("I.UDF5_STRING", "UDF5_STRING"));
                List.Add(new CBItem("I.UDF6_STRING", "UDF6_STRING"));
                List.Add(new CBItem("I.UDF7_STRING", "UDF7_STRING"));
                List.Add(new CBItem("I.UDF8_STRING", "UDF8_STRING"));
                List.Add(new CBItem("I.UDF9_STRING", "UDF9_STRING"));
                List.Add(new CBItem("I.UDF10_STRING", "UDF10_STRING"));
                List.Add(new CBItem("I.UDF11_STRING", "UDF11_STRING"));
                List.Add(new CBItem("I.UDF12_STRING", "UDF12_STRING"));
                List.Add(new CBItem("I.UDF13_STRING", "UDF13_STRING"));
                List.Add(new CBItem("I.UDF14_STRING", "UDF14_STRING"));
                List.Add(new CBItem("I.ITEM_SIZE", "ITEM_SIZE"));
                List.Add(new CBItem("I.ATTRIBUTE", "ATTRIBUTE"));
                List.Add(new CBItem("VEND_CODE", "VEND_CODE"));
                List.Add(new CBItem("I.COST", "COST"));
                List.Add(new CBItem("I.TEXT1", "TEXT1"));
                List.Add(new CBItem("I.TEXT2", "TEXT2"));
                List.Add(new CBItem("I.TEXT3", "TEXT3"));
                List.Add(new CBItem("I.TEXT4", "TEXT4"));
                List.Add(new CBItem("I.TEXT5", "TEXT5"));
                List.Add(new CBItem("I.TEXT6", "TEXT6"));
                List.Add(new CBItem("I.TEXT7", "TEXT7"));
                List.Add(new CBItem("I.TEXT8", "TEXT8"));
                List.Add(new CBItem("I.TEXT9", "TEXT9"));
                List.Add(new CBItem("I.TEXT10", "TEXT10"));
            }

            return List;
        }
        public List<CBItem> GetListConditionalFields()
        {
            var List = new List<CBItem>();

            List.Add(new CBItem("EQUAL", "="));
            List.Add(new CBItem("GREATER_THAN", ">"));
            List.Add(new CBItem("LESS_THAN", "<"));
            List.Add(new CBItem("DIFERENT", "<>"));
            List.Add(new CBItem("GREATER_OR_EQUAL", ">="));
            List.Add(new CBItem("LESS_OR_EQUAL", "<="));
            List.Add(new CBItem("IN", "IN"));
            List.Add(new CBItem("BETWEEN", "BETWEEN"));

            return List;
        }
        public List<CBItem> GetListRetailProFieldsByJson()
        {
            var List = new List<CBItem>();

            List.Add(new CBItem("-1", "NULL"));
            List.Add(new CBItem("0", "VACIO"));
            List.Add(new CBItem("1", "STORE.SBS_NO"));
            List.Add(new CBItem("2", "STORE.STORE_NO"));
            List.Add(new CBItem("3", "STORE.ECOMMERCE_CODE"));
            // List.Add(New CBItem("4", "ADDRESS1"))
            // List.Add(New CBItem("5", "ADDRESS2"))
            // List.Add(New CBItem("6", "ADDRESS3"))
            // List.Add(New CBItem("7", "ADDRESS4"))
            // List.Add(New CBItem("8", "ADDRESS5"))
            // List.Add(New CBItem("9", "ADDRESS6"))
            // List.Add(New CBItem("10", "UDF1_VALUE"))
            // List.Add(New CBItem("11", "UDF2_VALUE"))
            // List.Add(New CBItem("12", "UDF3_VALUE"))
            // List.Add(New CBItem("13", "UDF4_VALUE"))
            // List.Add(New CBItem("14", "STORES.SBS_NO"))
            // List.Add(New CBItem("15", "STORES.STORE_NO"))
            // List.Add(New CBItem("16", "STORES.GLOB_STORE_CODE"))
            // List.Add(New CBItem("17", "STORES.ADDRESS1"))
            // List.Add(New CBItem("18", "STORES.ADDRESS2"))
            // List.Add(New CBItem("19", "STORES.ADDRESS3"))
            // List.Add(New CBItem("20", "STORES.ADDRESS4"))
            // List.Add(New CBItem("21", "STORES.ADDRESS5"))
            // List.Add(New CBItem("22", "STORES.ADDRESS6"))
            // List.Add(New CBItem("23", "STORES.UDF1_VALUE"))
            // List.Add(New CBItem("24", "STORES.UDF2_VALUE"))
            // List.Add(New CBItem("25", "STORES.UDF3_VALUE"))
            // List.Add(New CBItem("26", "STORES.UDF4_VALUE"))
            List.Add(new CBItem("27", "ITEMS.ALU"));
            List.Add(new CBItem("28", "ITEMS.UPC"));
            List.Add(new CBItem("29", "ITEMS.QTY"));
            List.Add(new CBItem("30", "P.PRICE"));
            List.Add(new CBItem("31", "ITEMS.ACTIVE"));

            return List;
        }
        public List<CBItem> GetListRetailProFieldsByEcommerceCode(ref string db)
        {
            var List = new List<CBItem>();
            if (db == "oracle_9")
            {
                List.Add(new CBItem("S.STORE_NO", "STORE_NO"));
                List.Add(new CBItem("S.GLOB_STORE_CODE", "GLOB_STORE_CODE"));
                List.Add(new CBItem("S.STORE_NAME", "STORE_NAME"));
                List.Add(new CBItem("S.ADDRESS1", "ADDRESS1"));
                List.Add(new CBItem("S.ADDRESS2", "ADDRESS2"));
                List.Add(new CBItem("S.ADDRESS3", "ADDRESS3"));
                List.Add(new CBItem("S.ADDRESS4", "ADDRESS4"));
                List.Add(new CBItem("S.ADDRESS5", "ADDRESS5"));
                List.Add(new CBItem("S.ADDRESS6", "ADDRESS6"));
                List.Add(new CBItem("S.UDF1_VALUE", "UDF1_VALUE"));
                List.Add(new CBItem("S.UDF2_VALUE", "UDF2_VALUE"));
                List.Add(new CBItem("S.UDF3_VALUE", "UDF3_VALUE"));
                List.Add(new CBItem("S.UDF4_VALUE", "UDF4_VALUE"));
            }
            else if (db == "oracle_10")
            {
                List.Add(new CBItem("S.STORE_NO", "STORE_NO"));
                List.Add(new CBItem("S.GLOB_STORE_CODE", "GLOB_STORE_CODE"));
                List.Add(new CBItem("S.STORE_NAME", "STORE_NAME"));
                List.Add(new CBItem("S.ADDRESS1", "ADDRESS1"));
                List.Add(new CBItem("S.ADDRESS2", "ADDRESS2"));
                List.Add(new CBItem("S.ADDRESS3", "ADDRESS3"));
                List.Add(new CBItem("S.ADDRESS4", "ADDRESS4"));
                List.Add(new CBItem("S.ADDRESS5", "ADDRESS5"));
                List.Add(new CBItem("S.ADDRESS6", "ADDRESS6"));
                List.Add(new CBItem("S.UDF1_STRING", "UDF1_STRING"));
                List.Add(new CBItem("S.UDF2_STRING", "UDF2_STRING"));
                List.Add(new CBItem("S.UDF3_STRING", "UDF3_STRING"));
                List.Add(new CBItem("S.UDF4_STRING", "UDF4_STRING"));
                List.Add(new CBItem("S.UDF5_STRING", "UDF5_STRING"));
            }


            return List;
        }

    }

    public class CBItem
    {

        public CBItem()
        {

        }

        public CBItem(string Value, string Label)
        {

            this.Label = Label;
            this.Value = Value;
        }

        public string Label { get; set; }
        public string Value { get; set; }
    }

    public class EmailConfig
    {
        public string SmtpServer { get; set; } // Servidor SMTP
        public int Port { get; set; }           // Puerto del servidor SMTP
        public string Username { get; set; }    // Usuario (correo electrónico)
        public List<string> RecipientEmails { get; set; } // Lista de correos de destinatarios

    }
}