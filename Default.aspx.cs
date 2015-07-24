using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Caching;
using ServiceLibrary;
using BusinessObjects;
using UtilityLayer;
using Siteyonetim.Framework.Data;

namespace AdminPanel
{
    public partial class _Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CountRecords();
            //ListStats(); --Statistics tablosu Organizaton'dan silinmiş!!!
        }
        // Connectorpool Kayıt sayılarını alır
        void CountRecords()
        {
            //IInboxManagerService objInboxManagerService = WCFProxy.Proxy<IInboxManagerService>();
            //IOutboxManagerService objOutboxManagerService = WCFProxy.Proxy<IOutboxManagerService>();
            //#region Kayıt Sayısı
            //lblInboxNew.Text = objInboxManagerService.GetCountByInboxStatus((int)Enums.StatusEnum.New, null).ToString();
            //lblInboxProcessing.Text = objInboxManagerService.GetCountByInboxStatus((int)Enums.StatusEnum.Processing, null).ToString();
            //lblInboxCompleted.Text = objInboxManagerService.GetCountByInboxStatus((int)Enums.StatusEnum.Completed, null).ToString();
            //lblInboxErpError.Text = objInboxManagerService.GetCountByInboxStatus((int)Enums.StatusEnum.ErpError, null).ToString();
            //lblInboxException.Text = objInboxManagerService.GetCountByInboxStatus((int)Enums.StatusEnum.Exception, null).ToString();
            //lblInboxParseError.Text = objInboxManagerService.GetCountByInboxStatus((int)Enums.StatusEnum.ParserError, null).ToString();
            //lblInboxPortError.Text = objInboxManagerService.GetCountByInboxStatus((int)Enums.StatusEnum.PortError, null).ToString();
            //lblInboxDied.Text = objInboxManagerService.GetCountByInboxStatus((int)Enums.StatusEnum.Died, null).ToString();
            //lblOutboxNew.Text = objOutboxManagerService.GetCountByOutboxStatus((int)Enums.StatusEnum.New, null).ToString();
            //lblOutboxProcessing.Text = objOutboxManagerService.GetCountByOutboxStatus((int)Enums.StatusEnum.Processing, null).ToString();
            //lblOutboxCompleted.Text = objOutboxManagerService.GetCountByOutboxStatus((int)Enums.StatusEnum.Completed, null).ToString();
            //lblOutboxErpError.Text = objOutboxManagerService.GetCountByOutboxStatus((int)Enums.StatusEnum.ErpError, null).ToString();
            //lblOutboxException.Text = objOutboxManagerService.GetCountByOutboxStatus((int)Enums.StatusEnum.Exception, null).ToString();
            //lblOutboxParseError.Text = objOutboxManagerService.GetCountByOutboxStatus((int)Enums.StatusEnum.ParserError, null).ToString();
            //lblOutboxPortError.Text = objOutboxManagerService.GetCountByOutboxStatus((int)Enums.StatusEnum.PortError, null).ToString();
            //lblOutboxDied.Text = objOutboxManagerService.GetCountByOutboxStatus((int)Enums.StatusEnum.Died, null).ToString();
            //#endregion
            //#region Son Kayıt Tarihleri
            //lblInboxProcessingRecordDate.Text = objInboxManagerService.GetLastRecordDateByInboxStatus((int)Enums.StatusEnum.Processing, null).ToString();
            //lblInboxCompletedRecordDate.Text = objInboxManagerService.GetLastRecordDateByInboxStatus((int)Enums.StatusEnum.Completed, null).ToString();
            //lblInboxParseErrorRecordDate.Text = objInboxManagerService.GetLastRecordDateByInboxStatus((int)Enums.StatusEnum.ParserError, null).ToString();
            //lblInboxPortErrorRecordDate.Text = objInboxManagerService.GetLastRecordDateByInboxStatus((int)Enums.StatusEnum.PortError, null).ToString();
            //lblInboxDiedRecordDate.Text = objInboxManagerService.GetLastRecordDateByInboxStatus((int)Enums.StatusEnum.Died, null).ToString();
            //lblInboxErpErrorRecordDate.Text = objInboxManagerService.GetLastRecordDateByInboxStatus((int)Enums.StatusEnum.ErpError, null).ToString();
            //lblInboxExceptionRecordDate.Text = objInboxManagerService.GetLastRecordDateByInboxStatus((int)Enums.StatusEnum.Exception, null).ToString();
            //lblOutboxProcessingRecordDate.Text = objOutboxManagerService.GetLastRecordDateByOutboxStatus((int)Enums.StatusEnum.Processing, null).ToString();
            //lblOutboxCompletedRecordDate.Text = objOutboxManagerService.GetLastRecordDateByOutboxStatus((int)Enums.StatusEnum.Completed, null).ToString();
            //lblOutboxParseErrorRecordDate.Text = objOutboxManagerService.GetLastRecordDateByOutboxStatus((int)Enums.StatusEnum.ParserError, null).ToString();
            //lblOutboxPortErrorRecordDate.Text = objOutboxManagerService.GetLastRecordDateByOutboxStatus((int)Enums.StatusEnum.PortError, null).ToString();
            //lblOutboxExceptionRecordDate.Text = objOutboxManagerService.GetLastRecordDateByOutboxStatus((int)Enums.StatusEnum.Exception, null).ToString();
            //lblOutboxErpErrorRecordDate.Text = objOutboxManagerService.GetLastRecordDateByOutboxStatus((int)Enums.StatusEnum.ErpError, null).ToString();
            //lblOutboxDiedRecordDate.Text = objOutboxManagerService.GetLastRecordDateByOutboxStatus((int)Enums.StatusEnum.Died, null).ToString();
            //#endregion
        }
        

    }
}