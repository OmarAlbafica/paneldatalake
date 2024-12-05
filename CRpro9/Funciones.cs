using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRpro9
{
    public class Funciones
    {
        public string Conexion { get; set; }
        public ResponseCRpro9 Conectar()
        {
            var response = new ResponseCRpro9();
            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    ctx.Database.Connection.Open();

                    response.status = true;
                    response.message = "Conexion Establecida";

                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
            }

            return response;
        }
        public ResponseCRpro9 ListarSubsidiarys(short sbs_no, string tipoDB)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_SUBSIDIARY_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = " ";

                    if (tipoDB== "oracle_10")
                    {
                        sentencias = "SELECT " +
                                        "SBS_NO," +
                                        "SBS_NAME," +
                                        "LPAD(SBS_NO,3,'0') ||' - '|| SBS_NAME AS DISPLAY," +
                                        "(0) ITEM_SID_SRC," +
                                        "STYLE_DEF," +
                                        "STYLE_DEF," +
                                        "(0) CURRENCY_ID," +
                                        "(0) ACTIVE_PRICE_LVL " +
                                        "FROM " +
                                        "RPS.SUBSIDIARY " +
                                        "WHERE " +
                                        "SBS_NO > 0 " +
                                        "ORDER BY SBS_NO"; 
                    }
                    else
                    {
                         sentencias = "SELECT " +
                                        "SBS_NO," +
                                        "SBS_NAME," +
                                        "LPAD(SBS_NO,3,'0') ||' - '|| SBS_NAME AS DISPLAY," +
                                        "ITEM_SID_SRC," +
                                        "STYLE_DEF," +
                                        "CURRENCY_ID," +
                                        "ACTIVE_PRICE_LVL " +
                                        "FROM " +
                                        "SUBSIDIARY " +
                                        "WHERE " +
                                        "SBS_NO > 0 " +
                                        "ORDER BY SBS_NO";
                    }
                    

                    list = ctx.Database.SqlQuery<TX_SUBSIDIARY_V>(sentencias).ToList();
                    //list = ctx.Database.SqlQuery<TX_SUBSIDIARY_V>("SELECT * FROM TX_SUBSIDIARY_V").ToList();
                    //if (sbs_no == 0)
                    //{
                    //    list = ctx.Database.SqlQuery<TX_SUBSIDIARY_V>(sentencias).ToList();
                    //    //list = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_STORE_V").ToList();
                    //}
                    //else
                    //{
                    //    list = ctx.Database.SqlQuery<TX_SUBSIDIARY_V>(sentencias).ToList();
                    //    //var sbs = ctx.Database.SqlQuery<TX_SUBSIDIARY_V>(sentencias).ToList();
                    //    //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_STORE_V").ToList();

                    //    //list = sbs.Where(x => x.SBS_NO == sbs_no).ToList();
                    //}
                    if (list.Count > 0)
                    {
                        response.status = true;
                        response.message = "Datos Obtenidos";
                        response.result = list;
                    }
                    else
                    {
                        response.status = false;
                        response.message = "No Hay Subsidiarias";
                        response.result = list;
                    }


                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        
        public ResponseCRpro9 ListarStores(short sbs_no, string tipoDB)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_STORE_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "";
                    if (tipoDB== "oracle_10")
                    {
                         sentencias = "SELECT SB.SBS_NO, S.STORE_NO, S.STORE_CODE, S.STORE_NAME, " +
                                        "LPAD(S.STORE_NO,3,'0') || ' - ' || S.STORE_NAME AS DISPLAY, 0 PRICE_LVL, (0)TAX_AREA_ID,S.ACTIVE " +
                                        "FROM RPS.STORE S INNER JOIN RPS.SUBSIDIARY SB ON (S.SBS_SID=SB.SID) " +
                                        "WHERE 1=1 " +
                                        "AND S.ACTIVE=1 "+
                                        " " +
                                        "ORDER BY SB.SBS_NO, S.STORE_NO";

                    }
                    else
                    {
                         sentencias = "SELECT " +
                                        "SBS_NO," +
                                        "STORE_NO," +
                                        "STORE_CODE," +
                                        "STORE_NAME," +
                                        "LPAD(STORE_NO,3,'0') || ' - ' || STORE_NAME AS DISPLAY," +
                                        "PRICE_LVL," +
                                        "TAX_AREA_ID," +
                                        "ACTIVE " +
                                        "FROM " +
                                        "STORE " +
                                        "WHERE " +
                                        "SBS_NO > 0 AND STORE_NO BETWEEN 0 AND 249 " +
                                        "ORDER BY SBS_NO,STORE_NO";
                    }
                    

                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_STORE_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_STORE_V").ToList();
                    }
                    else
                    {
                        var tiendas = ctx.Database.SqlQuery<TX_STORE_V>(sentencias).ToList();
                        //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_STORE_V").ToList();

                        list = tiendas.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ObtenerStore(short sbs_no, short store_no)
        {
            var response = new ResponseCRpro9();
            var tienda = new TX_STORE_V();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {

                    string sentencias = "SELECT " +
                    "SBS_NO," +
                    "STORE_NO," +
                    "STORE_CODE," +
                    "STORE_NAME," +
                    "LPAD(STORE_NO,3,'0') || ' - ' || STORE_NAME AS DISPLAY," +
                    "PRICE_LVL," +
                    "TAX_AREA_ID," +
                    "ACTIVE " +
                    "FROM " +
                    "STORE " +
                    "WHERE " +
                    "SBS_NO > 0 AND STORE_NO BETWEEN 0 AND 249 " +
                    "ORDER BY SBS_NO,STORE_NO";

                    var tiendas = ctx.Database.SqlQuery<TX_STORE_V>(sentencias).ToList();
                    //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_STORE_V").ToList();

                    tienda = tiendas.Where(x => x.SBS_NO == sbs_no && x.STORE_NO == store_no).SingleOrDefault();

                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = tienda;
                }
            }
            catch (Exception ex)
            {
                response.status = true;
                response.message = ex.Message;
                response.result = tienda;
            }
            return response;
        }
        public ResponseCRpro9 ListarCurrencys(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_CURRENCY_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "S.SBS_NO," +
                                        "C.CURRENCY_ID," +
                                        "C.CURRENCY_NAME," +
                                        "C.DECIMALS," +
                                        "C.ACTIVE," +
                                        "S.ACTIVE_PRICE_LVL " +
                                        "FROM " +
                                        "CURRENCY C " +
                                        "LEFT JOIN SUBSIDIARY S ON(S.CURRENCY_ID = C.CURRENCY_ID) " +
                                        "WHERE " +
                                        "SBS_NO > 0";

                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_CURRENCY_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_CURRENCY_V").ToList();
                    }
                    else
                    {
                        var monedas = ctx.Database.SqlQuery<TX_CURRENCY_V>(sentencias).ToList();
                        //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_CURRENCY_V").ToList();

                        list = monedas.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarDCS(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_DCS_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "SBS_NO," +
                                        "DCS_CODE," +
                                        "USE_QTY_DECIMALS," +
                                        "TAX_CODE," +
                                        "ACTIVE " +
                                        "FROM " +
                                        "DCS";

                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_DCS_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_DCS_V").ToList();
                    }
                    else
                    {
                        var dcss = ctx.Database.SqlQuery<TX_DCS_V>(sentencias).ToList();
                        //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_DCS_V").ToList();

                        list = dcss.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarTaxs(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_TAX_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "SBS_NO," +
                                        "TAX_CODE," +
                                        "TAX_NAME " +
                                        "FROM " +
                                        "TAX_CODE " +
                                        "WHERE " +
                                        "SBS_NO > 0";

                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_TAX_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_DCS_V").ToList();
                    }
                    else
                    {
                        var taxs = ctx.Database.SqlQuery<TX_TAX_V>(sentencias).ToList();
                        //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_DCS_V").ToList();

                        list = taxs.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 PriceLvls(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TXT_PRICE_LIST>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "SBS_NO,"+
                                        "PRICE_LVL," +
                                        "PRICE_LVL_NAME," +
                                        "LPAD(PRICE_LVL, 2, '0') ||'-'||PRICE_LVL_NAME DISPLAY " +
                                        "FROM " +
                                        "PRICE_LEVEL";

                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TXT_PRICE_LIST>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_DCS_V").ToList();
                    }
                    else
                    {
                        var price_lvls = ctx.Database.SqlQuery<TXT_PRICE_LIST>(sentencias).ToList();
                        //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_DCS_V").ToList();

                        list = price_lvls.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarPriceLvls(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_PRICE_LVL_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "SBS_NO," +
                                        "ITEM_SID," +
                                        "PRICE_LVL," +
                                        "PRICE " +
                                        "FROM " +
                                        "INVN_SBS_PRICE";

                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_PRICE_LVL_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_DCS_V").ToList();
                    }
                    else
                    {
                        var price_lvls = ctx.Database.SqlQuery<TX_PRICE_LVL_V>(sentencias).ToList();
                        //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_DCS_V").ToList();

                        list = price_lvls.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarInventorys(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_INVENTORY_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "I.SBS_NO," +
                                        "I.ITEM_SID," +
                                        "I.LOCAL_UPC," +
                                        "I.ALU," +
                                        "I.CREATED_DATE," +
                                        "I.MODIFIED_DATE," +
                                        "I.STYLE_SID," +
                                        "I.DCS_CODE," +
                                        "I.VEND_CODE," +
                                        "I.DESCRIPTION1," +
                                        "I.DESCRIPTION2," +
                                        "I.DESCRIPTION3," +
                                        "I.DESCRIPTION4," +
                                        "I.ATTR," +
                                        "I.SIZ," +
                                        "I.COST," +
                                        "I.FC_COST," +
                                        "I.TAX_CODE," +
                                        "D.USE_QTY_DECIMALS," +
                                        "S.CURRENCY_ID," +
                                        "C.CURRENCY_NAME," +
                                        "I.MAX_DISC_PERC1," +
                                        "I.MAX_DISC_PERC2 " +
                                        "FROM " +
                                        "INVN_SBS I " +
                                        "LEFT JOIN DCS D ON(I.SBS_NO = D.SBS_NO AND I.DCS_CODE = D.DCS_CODE) " +
                                        "LEFT JOIN SUBSIDIARY S ON(I.SBS_NO = S.SBS_NO) " +
                                        "LEFT JOIN CURRENCY C ON(S.CURRENCY_ID = C.CURRENCY_ID AND C.ACTIVE = 1)";


                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_INVENTORY_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();
                    }
                    else
                    {
                        var articulos = ctx.Database.SqlQuery<TX_INVENTORY_V>(sentencias).ToList();
                        //var articulos = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                        list = articulos.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ObtenerInventory(short sbs_no, long item_sid)
        {
            var response = new ResponseCRpro9();
            var inventory = new TX_INVENTORY_V();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "I.SBS_NO," +
                                        "I.ITEM_SID," +
                                        "I.LOCAL_UPC," +
                                        "I.ALU," +
                                        "I.CREATED_DATE," +
                                        "I.STYLE_SID," +
                                        "I.DCS_CODE," +
                                        "I.VEND_CODE," +
                                        "I.DESCRIPTION1," +
                                        "I.DESCRIPTION2," +
                                        "I.DESCRIPTION3," +
                                        "I.DESCRIPTION4," +
                                        "I.ATTR," +
                                        "I.SIZ," +
                                        "I.COST," +
                                        "I.FC_COST," +
                                        "I.TAX_CODE," +
                                        "D.USE_QTY_DECIMALS," +
                                        "S.CURRENCY_ID," +
                                        "C.CURRENCY_NAME," +
                                        "I.MAX_DISC_PERC1," +
                                        "I.MAX_DISC_PERC2 " +
                                        "FROM " +
                                        "INVN_SBS I " +
                                        "LEFT JOIN DCS D ON(I.SBS_NO = D.SBS_NO AND I.DCS_CODE = D.DCS_CODE) " +
                                        "LEFT JOIN SUBSIDIARY S ON(I.SBS_NO = S.SBS_NO) " +
                                        "LEFT JOIN CURRENCY C ON(S.CURRENCY_ID = C.CURRENCY_ID AND C.ACTIVE = 1)";


                    var inventorys = ctx.Database.SqlQuery<TX_INVENTORY_V>(sentencias).ToList();
                    //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                    inventory = inventorys.Where(x => x.SBS_NO == sbs_no && x.ITEM_SID == item_sid).SingleOrDefault();

                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = inventory;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = inventory;
            }
            return response;
        }
        public ResponseCRpro9 ObtenerInventoryByUPC(short sbs_no, long local_upc)
        {
            var response = new ResponseCRpro9();
            var inventory = new TX_INVENTORY_V();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "I.SBS_NO," +
                                        "I.ITEM_SID," +
                                        "I.LOCAL_UPC," +
                                        "I.ALU," +
                                        "I.CREATED_DATE," +
                                        "I.STYLE_SID," +
                                        "I.DCS_CODE," +
                                        "I.VEND_CODE," +
                                        "I.DESCRIPTION1," +
                                        "I.DESCRIPTION2," +
                                        "I.DESCRIPTION3," +
                                        "I.DESCRIPTION4," +
                                        "I.ATTR," +
                                        "I.SIZ," +
                                        "I.COST," +
                                        "I.FC_COST," +
                                        "I.TAX_CODE," +
                                        "D.USE_QTY_DECIMALS," +
                                        "S.CURRENCY_ID," +
                                        "C.CURRENCY_NAME," +
                                        "I.MAX_DISC_PERC1," +
                                        "I.MAX_DISC_PERC2 " +
                                        "FROM " +
                                        "INVN_SBS I " +
                                        "LEFT JOIN DCS D ON(I.SBS_NO = D.SBS_NO AND I.DCS_CODE = D.DCS_CODE) " +
                                        "LEFT JOIN SUBSIDIARY S ON(I.SBS_NO = S.SBS_NO) " +
                                        "LEFT JOIN CURRENCY C ON(S.CURRENCY_ID = C.CURRENCY_ID AND C.ACTIVE = 1)";


                    var inventorys = ctx.Database.SqlQuery<TX_INVENTORY_V>(sentencias).ToList();
                    //var tiendas = ctx.Database.SqlQuery<TX_STORE_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                    inventory = inventorys.Where(x => x.SBS_NO == sbs_no && x.LOCAL_UPC == local_upc).SingleOrDefault();

                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = inventory;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = inventory;
            }
            return response;
        }
        public ResponseCRpro9 ListarInvnQty(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_INVN_QTY_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT" +
                                        "I.SBS_NO," +
	                                    "I.STORE_NO," +
	                                    "I.ITEM_SID," +
	                                    "NVL(I.MIN_QTY, 0) MIN_QTY," +
	                                    "NVL(I.MAX_QTY, 0) MAX_QTY " +
                                        "FROM " +
                                        "INVN_SBS_QTY I " +
                                        "LEFT JOIN STORE S ON(I.SBS_NO = S.SBS_NO AND I.STORE_NO = S.STORE_NO) " +
                                        "WHERE S.ACTIVE = 1";


                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_INVN_QTY_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();
                    }
                    else
                    {
                        var arts_qty = ctx.Database.SqlQuery<TX_INVN_QTY_V>(sentencias).ToList();
                        //var articulos = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                        list = arts_qty.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ObtenerInvnQty(short sbs_no, long item_sid)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_INVN_QTY_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT" +
                                        "I.SBS_NO," +
                                        "I.STORE_NO," +
                                        "I.ITEM_SID," +
                                        "NVL(I.MIN_QTY, 0) MIN_QTY," +
                                        "NVL(I.MAX_QTY, 0) MAX_QTY " +
                                        "FROM " +
                                        "INVN_SBS_QTY I " +
                                        "LEFT JOIN STORE S ON(I.SBS_NO = S.SBS_NO AND I.STORE_NO = S.STORE_NO) " +
                                        "WHERE S.ACTIVE = 1";


                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_INVN_QTY_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();
                    }
                    else
                    {
                        var arts_qty = ctx.Database.SqlQuery<TX_INVN_QTY_V>(sentencias).ToList();
                        //var articulos = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                        list = arts_qty.Where(x => x.SBS_NO == sbs_no && x.ITEM_SID ==  item_sid).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarVendors(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_VENDOR_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "SBS_NO," +
                                        "VEND_CODE," +
                                        "VEND_NAME," +
                                        "FIRST_NAME," +
                                        "LAST_NAME," +
                                        "ADDRESS1," +
                                        "ADDRESS2," +
                                        "ADDRESS3," +
                                        "ZIP," +
                                        "PHONE1," +
                                        "INFO1," +
                                        "ACTIVE," +
                                        "VEND_ID," +
                                        "CURRENCY_ID," +
                                        "NOTES " +
                                        "FROM " +
                                        "VENDOR " +
                                        "WHERE " +
                                        "ACTIVE= 1";


                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_VENDOR_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();
                    }
                    else
                    {
                        var vendors = ctx.Database.SqlQuery<TX_VENDOR_V>(sentencias).ToList();
                        //var articulos = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                        list = vendors.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarEmployees(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_EMPLOYEE_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT "+
                                        "SBS_NO," +
                                        "EMPL_ID," +
                                        "EMPL_NAME," +
                                        "EMPL_CODE," +
                                        "MAX_DISC_PERC," +
                                        "CUST_SID," +
                                        "ACTIVE," +
                                        "RPRO_FULL_NAME," +
                                        "HOME_SBS_NO," +
                                        "BASE_SBS_NO," +
                                        "BASE_STORE_NO," +
                                        "MODIFIED_DATE " +
                                        "FROM " +
                                        "EMPLOYEE " +
                                        "WHERE " +
                                        "ACTIVE = 1";


                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_EMPLOYEE_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();
                    }
                    else
                    {
                        var employees = ctx.Database.SqlQuery<TX_EMPLOYEE_V>(sentencias).ToList();
                        //var articulos = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                        list = employees.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarTaxAreas(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_TAX_AREA_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT "+
                                        "S.SBS_NO," +
                                        "S.STORE_NO," +
                                        "T.TAX_AREA_ID," +
                                        "T.TAX_AREA_NAME," +
                                        "T.ACTIVE " +
                                        "FROM STORE S " +
                                        "INNER JOIN TAX_AREA T ON(S.SBS_NO = T.SBS_NO AND S.TAX_AREA_ID = T.TAX_AREA_ID) " +
                                        "WHERE " +
                                        "S.ACTIVE = 1";


                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_TAX_AREA_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();
                    }
                    else
                    {
                        var taxareas = ctx.Database.SqlQuery<TX_TAX_AREA_V>(sentencias).ToList();
                        //var articulos = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                        list = taxareas.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarPOs(short sbs_no)
        {
            var response = new ResponseCRpro9();
            var list = new List<TX_PO_V>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    string sentencias = "SELECT " +
                                        "SBS_NO," +
                                        "STORE_NO," +
                                        "PO_SID," +
                                        "PO_NO " +
                                        "FROM " +
                                        "PO " +
                                        "WHERE " +
                                        "ACTIVE = 1";

                    if (sbs_no == 0)
                    {
                        list = ctx.Database.SqlQuery<TX_PO_V>(sentencias).ToList();
                        //list = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();
                    }
                    else
                    {
                        var pos = ctx.Database.SqlQuery<TX_PO_V>(sentencias).ToList();
                        //var articulos = ctx.Database.SqlQuery<TX_INVENTORY_V>("SELECT * FROM TX_INVENTORY_V").ToList();

                        list = pos.Where(x => x.SBS_NO == sbs_no).ToList();
                    }
                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 ListarArticulos(string Query)
        {
            var response = new ResponseCRpro9();
            var list = new List<INVN_QTY_BYSTORE>();

            try
            {
                using (var ctx = new ModelRpro9(this.Conexion))
                {

                    list = ctx.Database.SqlQuery<INVN_QTY_BYSTORE>(Query).ToList();

                    response.status = true;
                    response.message = "Datos Obtenidos";
                    response.result = list;
                }
            }
            catch (Exception ex)
            {
                response.status = false;
                response.message = ex.Message;
                response.result = list;
            }
            return response;
        }
        public ResponseCRpro9 GuardarArticulo(DLK_CONTROL datos)
        {
            var response = new ResponseCRpro9();

            try
            {

                using (var ctx = new ModelRpro9(this.Conexion))
                {
                    var vp = new ModelRpro9(this.Conexion);

                    var Darticul = new DLK_CONTROL();

                    Darticul = vp.DLK_CONTROL.Where(o => o.ID_SOCIEDAD == datos.ID_SOCIEDAD && o.ID_CENTRO == datos.ID_CENTRO && o.ARTICULO_SAP == datos.ARTICULO_SAP).SingleOrDefault();

                    if (!(Darticul == null))
                    {
                        //ctx.Entry(permiso).State = EntityState.Detached;
                        ctx.Entry(datos).State = EntityState.Modified;
                        //ctx.fn_permiso.Attach(datos);
                        ctx.SaveChanges();

                        response.status = true;
                        response.message = "Datos Actualizados";
                    }
                    else
                    {
                        //ctx.Entry(header).State = EntityState.Added;
                        ctx.DLK_CONTROL.Add(datos);
                        ctx.SaveChanges();

                        response.status = true;
                        response.message = "Datos Registrados";
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                response.status = false;
                response.message = "InvalidCastException-> " + ex.Message;
            }
            catch (DbEntityValidationException ex)
            {

                foreach (var eve in ex.EntityValidationErrors)
                {
                    string ErroresValidacion = "";
                    foreach (var ve in eve.ValidationErrors)
                    {
                        ErroresValidacion += ve.ErrorMessage + "." + Environment.NewLine;
                    }

                    response.status = false;
                    response.message = ErroresValidacion;
                }
            }
            catch (Exception ex)
            {
                response.status = false;

                if (ex.InnerException == null)
                {
                    response.message = "Exception-> " + ex.Message;
                }
                else
                {
                    response.message = "InnerException-> " + ex.InnerException.Message;
                }

            }
            return response;
        }
        
    }
}
