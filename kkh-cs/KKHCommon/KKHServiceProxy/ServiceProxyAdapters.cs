using System;
using System.Collections.Generic;
using Isid.Soa.Framework.Client.Filter;
using Isid.Soa.Framework.Client.Exception;
using Isid.Soa.Framework.Client.Proxy;
using Isid.Soa.Framework.Client.Core;
using Microsoft.Web.Services3;

namespace Isid.KKH.Common.KKHServiceProxy
{
    /// <remarks/>
    public class masterServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public masterServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.masterRegisterResult registerMasterTables(Isid.KKH.Common.KKHServiceProxy.masterRegisterVO masterRegisterVO1, Isid.KKH.Common.KKHServiceProxy.masterRegisterVO masterRegisterVO2)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerMasterTables");
            Object[] args = new Object[] {masterRegisterVO1, masterRegisterVO2};
            return (Isid.KKH.Common.KKHServiceProxy.masterRegisterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.masterRegisterResult registerMaster(Isid.KKH.Common.KKHServiceProxy.masterRegisterVO masterRegisterVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerMaster");
            Object[] args = new Object[] {masterRegisterVO};
            return (Isid.KKH.Common.KKHServiceProxy.masterRegisterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.masterResult findMasterByCond(Isid.KKH.Common.KKHServiceProxy.masterCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findMasterByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.masterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.masterResult findMasterDefineByCond(Isid.KKH.Common.KKHServiceProxy.masterCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findMasterDefineByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.masterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.masterItemResult findMasterItemByCond(Isid.KKH.Common.KKHServiceProxy.masterCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findMasterItemByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.masterItemResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class inputServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public inputServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.hikSearchResult findHikByCond(Isid.KKH.Common.KKHServiceProxy.hikCommonCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findHikByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.hikSearchResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.hikRegistResult registHikByCond(Isid.KKH.Common.KKHServiceProxy.hikRegistVOList volist)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registHikByCond");
            Object[] args = new Object[] {volist};
            return (Isid.KKH.Common.KKHServiceProxy.hikRegistResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.hikSearchResult findHikDateCntByCond(Isid.KKH.Common.KKHServiceProxy.hikSearchDateCntVOList volist)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findHikDateCntByCond");
            Object[] args = new Object[] {volist};
            return (Isid.KKH.Common.KKHServiceProxy.hikSearchResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.hikSearchResult findHikCheckDataByCond(Isid.KKH.Common.KKHServiceProxy.hikRegistVOList volist)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findHikCheckDataByCond");
            Object[] args = new Object[] {volist};
            return (Isid.KKH.Common.KKHServiceProxy.hikSearchResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class detailServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public detailServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.jyutyuDataMergeResult mergeJyutyuData(Isid.KKH.Common.KKHServiceProxy.jyutyuDataMergeVO JyutyuDataMergeVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("mergeJyutyuData");
            Object[] args = new Object[] {JyutyuDataMergeVO};
            return (Isid.KKH.Common.KKHServiceProxy.jyutyuDataMergeResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.jyutNoTouInsResult JyutNoTouGouIns(Isid.KKH.Common.KKHServiceProxy.jyutNoTouInsVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("JyutNoTouGouIns");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.jyutNoTouInsResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.detailUpdateDataResult updateDisplayData(Isid.KKH.Common.KKHServiceProxy.detailUpdateDataVO DetailUpdateDataVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("updateDisplayData");
            Object[] args = new Object[] {DetailUpdateDataVO};
            return (Isid.KKH.Common.KKHServiceProxy.detailUpdateDataResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.thb8DownRResult findJyutyuRirekiDataByCond(Isid.KKH.Common.KKHServiceProxy.thb8DownRCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findJyutyuRirekiDataByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.thb8DownRResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.detailDataResult findDetailDataByCond(Isid.KKH.Common.KKHServiceProxy.detailDataCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findDetailDataByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.detailDataResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.jyutNoTouUpdateResult JyutNoTouGou(Isid.KKH.Common.KKHServiceProxy.jyutNoTouUpdateVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("JyutNoTouGou");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.jyutNoTouUpdateResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.jyutyuDataCondResult findJyutyuDataByCond(Isid.KKH.Common.KKHServiceProxy.jyutyuDataCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findJyutyuDataByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.jyutyuDataCondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.bulkDataRegisterResult registerBulkData(Isid.KKH.Common.KKHServiceProxy.bulkDataRegisterVO bulkDataRegisterVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerBulkData");
            Object[] args = new Object[] {bulkDataRegisterVO};
            return (Isid.KKH.Common.KKHServiceProxy.bulkDataRegisterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.detailDataBulkUpdateResult bulkUpdateDetailData(Isid.KKH.Common.KKHServiceProxy.detailDataBulkUpdateVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("bulkUpdateDetailData");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.detailDataBulkUpdateResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.jyutyuDataRegisterResult registerJyutyuData(Isid.KKH.Common.KKHServiceProxy.jyutyuDataRegisterVO JyutyuDataRegisterVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerJyutyuData");
            Object[] args = new Object[] {JyutyuDataRegisterVO};
            return (Isid.KKH.Common.KKHServiceProxy.jyutyuDataRegisterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.seikyuYymmChangeResult changeSeikyuYymm(Isid.KKH.Common.KKHServiceProxy.seikyuYymmChangeVO SeikyuYymmChangeVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("changeSeikyuYymm");
            Object[] args = new Object[] {SeikyuYymmChangeVO};
            return (Isid.KKH.Common.KKHServiceProxy.seikyuYymmChangeResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.jyutyuDataMergeCancelResult mergeCancelJyutyuData(Isid.KKH.Common.KKHServiceProxy.jyutyuDataMergeCancelVO JyutyuDataMergeCancelVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("mergeCancelJyutyuData");
            Object[] args = new Object[] {JyutyuDataMergeCancelVO};
            return (Isid.KKH.Common.KKHServiceProxy.jyutyuDataMergeCancelResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.jyutyuDataDeleteResult deleteJyutyuData(Isid.KKH.Common.KKHServiceProxy.jyutyuDataDeleteVO JyutyuDataDeleteVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("deleteJyutyuData");
            Object[] args = new Object[] {JyutyuDataDeleteVO};
            return (Isid.KKH.Common.KKHServiceProxy.jyutyuDataDeleteResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class commonServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public commonServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.eigyoBiResult getEigyoBi(Isid.KKH.Common.KKHServiceProxy.eigyoBiCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("getEigyoBi");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.eigyoBiResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.commonCodeMasterResult findCommonCodeMasterByCond(Isid.KKH.Common.KKHServiceProxy.commonCodeMasterCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findCommonCodeMasterByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.commonCodeMasterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.commonResult findCommonByCond(Isid.KKH.Common.KKHServiceProxy.commonCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findCommonByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.commonResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.accountOperationStatusResult checkAccountOperationStatus(Isid.KKH.Common.KKHServiceProxy.accountOperationStatusCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("checkAccountOperationStatus");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.accountOperationStatusResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class logServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public logServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.logResult registLog(Isid.KKH.Common.KKHServiceProxy.logVO logVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registLog");
            Object[] args = new Object[] {logVO};
            return (Isid.KKH.Common.KKHServiceProxy.logResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.logResult findLogByCond(Isid.KKH.Common.KKHServiceProxy.logCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findLogByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.logResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class detailTakedaServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public detailTakedaServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.upJissiBycondResult upJissiNoBycond(Isid.KKH.Common.KKHServiceProxy.upJissiBycondVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("upJissiNoBycond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.upJissiBycondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findMaxJissiNoByCondResult findMaxJissiNoByCond(Isid.KKH.Common.KKHServiceProxy.findMaxJissiNoCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findMaxJissiNoByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findMaxJissiNoByCondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.autoJissiBycondResult autoNoBycond(Isid.KKH.Common.KKHServiceProxy.autoJissiBycondVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("autoNoBycond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.autoJissiBycondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findJissiNoCntByCondResult findJissiNoCntByCond(Isid.KKH.Common.KKHServiceProxy.findJissiNoCntCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findJissiNoCntByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findJissiNoCntByCondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findThb2KmeiBycondResult jissiNo(Isid.KKH.Common.KKHServiceProxy.findThb2KmeiBycondVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("jissiNo");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findThb2KmeiBycondResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class reportServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public reportServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportTohResult findReportTohByCond(Isid.KKH.Common.KKHServiceProxy.reportTohCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportTohByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportTohResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportTohTotalResult findReportTohTotalByCond(Isid.KKH.Common.KKHServiceProxy.reportTohTotalCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportTohTotalByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportTohTotalResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class detailSkypServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public detailSkypServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findOrderByCondResult findOrderByCond(Isid.KKH.Common.KKHServiceProxy.findOrderCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findOrderByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findOrderByCondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.updateOrderResult updateOrderData(Isid.KKH.Common.KKHServiceProxy.updateOrderVO vo)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("updateOrderData");
            Object[] args = new Object[] {vo};
            return (Isid.KKH.Common.KKHServiceProxy.updateOrderResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class macReportServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public macReportServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportMacGetDenNumResult findReportMacGetDenNumByCond(Isid.KKH.Common.KKHServiceProxy.reportMacGetDenNumCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportMacGetDenNumByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportMacGetDenNumResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportMacPurchaseResult findReportMacPurchaseByCond(Isid.KKH.Common.KKHServiceProxy.reportMacPurchaseCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportMacPurchaseByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportMacPurchaseResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportMacRequestResult findReportMacRequestByCond(Isid.KKH.Common.KKHServiceProxy.reportMacRequestCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportMacRequestByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportMacRequestResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportMacSchklstResult findReportMacSchklstByCond(Isid.KKH.Common.KKHServiceProxy.reportMacSchklstCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportMacSchklstByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportMacSchklstResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportMacLicenseeResult findReportMacLicenseeByCond(Isid.KKH.Common.KKHServiceProxy.reportMacCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportMacLicenseeByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportMacLicenseeResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.updateReportMacReqResult updateReportMacReq(Isid.KKH.Common.KKHServiceProxy.updateReportMacReqCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("updateReportMacReq");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.updateReportMacReqResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.updateReportMacPurResult updateReportMacPur(Isid.KKH.Common.KKHServiceProxy.updateReportMacPurCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("updateReportMacPur");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.updateReportMacPurResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportMacResult findReportMacByCond(Isid.KKH.Common.KKHServiceProxy.reportMacCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportMacByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportMacResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class masterMacServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public masterMacServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findMasterMacTnpRByCondResult findMacMasterTnpR(Isid.KKH.Common.KKHServiceProxy.findMasterMacTnpRByCondCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findMacMasterTnpR");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findMasterMacTnpRByCondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findMasterMacTnpRKeyByCondResult findMacMasterTnpRKey(Isid.KKH.Common.KKHServiceProxy.findMasterMacTnpRByCondCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findMacMasterTnpRKey");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findMasterMacTnpRKeyByCondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.masterMacRegisterResult registerMacMaster(Isid.KKH.Common.KKHServiceProxy.masterMacRegisterVO masterMacRegisterVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerMacMaster");
            Object[] args = new Object[] {masterMacRegisterVO};
            return (Isid.KKH.Common.KKHServiceProxy.masterMacRegisterResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class detailAshServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public detailAshServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.getFDSeqResult getFDSeq(Isid.KKH.Common.KKHServiceProxy.getFDSeqCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("getFDSeq");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.getFDSeqResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.detailDataAshResult findDetailDataAshByCond(Isid.KKH.Common.KKHServiceProxy.detailDataAshCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findDetailDataAshByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.detailDataAshResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.detailDataAshMergeResult mergeData(Isid.KKH.Common.KKHServiceProxy.detailDataAshMergeVO DetailDataAshMergeVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("mergeData");
            Object[] args = new Object[] {DetailDataAshMergeVO};
            return (Isid.KKH.Common.KKHServiceProxy.detailDataAshMergeResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findKeyKyokuBangumiCdResult findKeyKyokuBangumiCd(Isid.KKH.Common.KKHServiceProxy.findKeyKyokuBangumiCdCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findKeyKyokuBangumiCd");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findKeyKyokuBangumiCdResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class acomReportServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public acomReportServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportAcomResult findReportAcomByCond(Isid.KKH.Common.KKHServiceProxy.reportAcomCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportAcomByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportAcomResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class reportSkypServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public reportSkypServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportSkypResult findReportSkypByCond(Isid.KKH.Common.KKHServiceProxy.reportSkypCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportSkypByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportSkypResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class ashReportServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public ashReportServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportAshMediaChklstResult findReportAshMediaChklstByCond(Isid.KKH.Common.KKHServiceProxy.reportAshMediaCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportAshMediaChklstByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportAshMediaChklstResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportAshMediaCodeResult findReportAshMediaCodeByCond(Isid.KKH.Common.KKHServiceProxy.reportAshMediaCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportAshMediaCodeByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportAshMediaCodeResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportAshMediaResult findReportAshMediaByCond(Isid.KKH.Common.KKHServiceProxy.reportAshMediaCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportAshMediaByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportAshMediaResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.fdAshResult findFDAshByCond(Isid.KKH.Common.KKHServiceProxy.reportAshMediaCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findFDAshByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.fdAshResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportAshKoukokuHiResult findReportAshKoukokuHiByCond(Isid.KKH.Common.KKHServiceProxy.reportAshMediaCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportAshKoukokuHiByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportAshKoukokuHiResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class uniReportServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public uniReportServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportUniResult findReportUniByCond(Isid.KKH.Common.KKHServiceProxy.reportUniCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportUniByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportUniResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class reportTkdBillingServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public reportTkdBillingServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportTkdBillingForPlanningCostResult findReportTkdBillingForPlanningCostByCond(Isid.KKH.Common.KKHServiceProxy.reportTkdBillingForPlanningCostCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportTkdBillingForPlanningCostByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportTkdBillingForPlanningCostResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportTkdBillingByItemResult findReportTkdBillingByItemByCond(Isid.KKH.Common.KKHServiceProxy.reportTkdBillingByItemCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportTkdBillingByItemByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportTkdBillingByItemResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportTkdBillingByMiddleClassificationResult findReportTkdBillingByMiddleClassificationByCond(Isid.KKH.Common.KKHServiceProxy.reportTkdBillingByMiddleClassificationCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportTkdBillingByMiddleClassificationByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportTkdBillingByMiddleClassificationResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class historyServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public historyServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.historyJyutDownResult findHistoryByCond(Isid.KKH.Common.KKHServiceProxy.historyJyutDownCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findHistoryByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.historyJyutDownResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class masterLionServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public masterLionServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.lionRegisterResult registerLionTvKMast(Isid.KKH.Common.KKHServiceProxy.lionTvKMastRegisterVO lionTvKMastRegisterVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerLionTvKMast");
            Object[] args = new Object[] {lionTvKMastRegisterVO};
            return (Isid.KKH.Common.KKHServiceProxy.lionRegisterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findTvMastResult findTvMastByCond(Isid.KKH.Common.KKHServiceProxy.findTvMastCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findTvMastByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findTvMastResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findRdMastResult findRdMastByCond(Isid.KKH.Common.KKHServiceProxy.findRdMastCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findRdMastByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findRdMastResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.lionRegisterResult registerLionRdKMast(Isid.KKH.Common.KKHServiceProxy.lionRdKMastRegisterVO lionRdKMastRegisterVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerLionRdKMast");
            Object[] args = new Object[] {lionRdKMastRegisterVO};
            return (Isid.KKH.Common.KKHServiceProxy.lionRegisterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.lionRegisterResult registerLionTvMast(Isid.KKH.Common.KKHServiceProxy.lionTvMastRegisterVO lionTvMastRegisterVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerLionTvMast");
            Object[] args = new Object[] {lionTvMastRegisterVO};
            return (Isid.KKH.Common.KKHServiceProxy.lionRegisterResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.insertLionZashiRyoSpcMastResult insertLionZashiRyoSpcMast(Isid.KKH.Common.KKHServiceProxy.insertLionZashiRyoSpcMastVO insertLionZashiRyoSpcMastVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("insertLionZashiRyoSpcMast");
            Object[] args = new Object[] {insertLionZashiRyoSpcMastVO};
            return (Isid.KKH.Common.KKHServiceProxy.insertLionZashiRyoSpcMastResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findRdKMastResult findRdKMastByCond(Isid.KKH.Common.KKHServiceProxy.findRdKMastCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findRdKMastByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findRdKMastResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findTvKMastResult findTvKMastByCond(Isid.KKH.Common.KKHServiceProxy.findTvKMastCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findTvKMastByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findTvKMastResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.lionZashiRyoSpcMastResult lionZashiRyoSpcMastByCond(Isid.KKH.Common.KKHServiceProxy.lionZashiRyoSpcMastCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("lionZashiRyoSpcMastByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.lionZashiRyoSpcMastResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.updateTimeStampResult updateTimeStampData(Isid.KKH.Common.KKHServiceProxy.updateTimeStampVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("updateTimeStampData");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.updateTimeStampResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.lionRegisterResult registerLionRdMast(Isid.KKH.Common.KKHServiceProxy.lionRdMastRegisterVO lionRdMastRegisterVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerLionRdMast");
            Object[] args = new Object[] {lionRdMastRegisterVO};
            return (Isid.KKH.Common.KKHServiceProxy.lionRegisterResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class lionReportServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public lionReportServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.detailListLionResult findDetailListLionByCond(Isid.KKH.Common.KKHServiceProxy.detailListLionCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findDetailListLionByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.detailListLionResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.invoicePlanLionResult findInvoicePlanByCond(Isid.KKH.Common.KKHServiceProxy.invoicePlanLionCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findInvoicePlanByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.invoicePlanLionResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.addChangeReportLionSeisakuResult findAddChangeReportSeisakuByCond(Isid.KKH.Common.KKHServiceProxy.addChangeReportLionSeisakuCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findAddChangeReportSeisakuByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.addChangeReportLionSeisakuResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportLionResult findReportLionByCond(Isid.KKH.Common.KKHServiceProxy.reportLionCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportLionByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportLionResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.addChangeReportLionBaitaiResult findAddChangeReportBaitaiByCond(Isid.KKH.Common.KKHServiceProxy.addChangeReportLionBaitaiCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findAddChangeReportBaitaiByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.addChangeReportLionBaitaiResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.lionHistoryResult registerLionOrderHistory(Isid.KKH.Common.KKHServiceProxy.lionHistoryCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("registerLionOrderHistory");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.lionHistoryResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.orderDiffListLionResult findOrderDiffListByCond(Isid.KKH.Common.KKHServiceProxy.orderDiffListLionCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findOrderDiffListByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.orderDiffListLionResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.fdLionResult findFDLionByCond(Isid.KKH.Common.KKHServiceProxy.fdLionCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findFDLionByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.fdLionResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.newReportLionResult findNewReportLionByCond(Isid.KKH.Common.KKHServiceProxy.newReportLionCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findNewReportLionByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.newReportLionResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class lionDetailServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public lionDetailServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findLionDetailResult findLionDetailByCond(Isid.KKH.Common.KKHServiceProxy.findLionDetailCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findLionDetailByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findLionDetailResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findLionTVSpotResult findLionTVSpotByCond(Isid.KKH.Common.KKHServiceProxy.findLionTVSpotCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findLionTVSpotByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findLionTVSpotResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findLionCardNoItrResult cardNoItrData(Isid.KKH.Common.KKHServiceProxy.findLionCardNoItrCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("cardNoItrData");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findLionCardNoItrResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findLionCardNoGetResult findLionCardNoGetByCond(Isid.KKH.Common.KKHServiceProxy.findLionCardNoGetCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findLionCardNoGetByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findLionCardNoGetResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findLionCodeItrResult codeItrData(Isid.KKH.Common.KKHServiceProxy.findLionCodeItrCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("codeItrData");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findLionCodeItrResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.updateSubjectResult updateSubjectData(Isid.KKH.Common.KKHServiceProxy.updateSubjectVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("updateSubjectData");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.updateSubjectResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class claimAcomServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public claimAcomServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findClaimByCondResult findClaimByCond(Isid.KKH.Common.KKHServiceProxy.findClaimCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findClaimByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findClaimByCondResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.updateOutFlgResult updateOutFlg(Isid.KKH.Common.KKHServiceProxy.updateOutFlgVO vo)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("updateOutFlg");
            Object[] args = new Object[] {vo};
            return (Isid.KKH.Common.KKHServiceProxy.updateOutFlgResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class loginServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public loginServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.customerInfoResult getCustomerInfo(Isid.KKH.Common.KKHServiceProxy.customerInfoCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("getCustomerInfo");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.customerInfoResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.accountSecurityRoleResult getAccountSecurityRole(Isid.KKH.Common.KKHServiceProxy.accountSecurityRoleCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("getAccountSecurityRole");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.accountSecurityRoleResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.openCustomerInfoResult getOpenCustomerInfo(Isid.KKH.Common.KKHServiceProxy.openCustomerInfoCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("getOpenCustomerInfo");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.openCustomerInfoResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.loginResult login(Isid.KKH.Common.KKHServiceProxy.loginCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("login");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.loginResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.loginInitInfoResult getLoginInitInfo(Isid.KKH.Common.KKHServiceProxy.loginInitInfoCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("getLoginInitInfo");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.loginInitInfoResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class epsonReportServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public epsonReportServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportEpsonSubMissionResult findReportEpsonSubMissionByCond(Isid.KKH.Common.KKHServiceProxy.reportEpsonSubMissionCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportEpsonSubMissionByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportEpsonSubMissionResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportEpsonSeikyuPlanResult findReportEpsonSeikyuPlanByCond(Isid.KKH.Common.KKHServiceProxy.reportEpsonSeikyuPlanCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportEpsonSeikyuPlanByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportEpsonSeikyuPlanResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class detailEpsonServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public detailEpsonServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.detailDataEpsonBulkUpdateResult bulkUpdateDetailDataEpson(Isid.KKH.Common.KKHServiceProxy.detailDataEpsonBulkUpdateVO condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("bulkUpdateDetailDataEpson");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.detailDataEpsonBulkUpdateResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.seikyuDataEpsonResult findSeikyuDataEpsonByCond(Isid.KKH.Common.KKHServiceProxy.seikyuDataCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findSeikyuDataEpsonByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.seikyuDataEpsonResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.detailDataEpsonResult findDetailDataEpsonByCond(Isid.KKH.Common.KKHServiceProxy.detailDataEpsonCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findDetailDataEpsonByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.detailDataEpsonResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.bulkJyutyuDataEpsonMergeResult mergeBulkJyutyuDataEpson(Isid.KKH.Common.KKHServiceProxy.bulkJyutyuDataEpsonMergeVO bulkJyutyuDataEpsonMergeVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("mergeBulkJyutyuDataEpson");
            Object[] args = new Object[] {bulkJyutyuDataEpsonMergeVO};
            return (Isid.KKH.Common.KKHServiceProxy.bulkJyutyuDataEpsonMergeResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class detailAcomServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public detailAcomServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findHatyuConfirmResult findHatyuConfirm(Isid.KKH.Common.KKHServiceProxy.findHatyuNumByCondVO FindHatyuNumByCondVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findHatyuConfirm");
            Object[] args = new Object[] {FindHatyuNumByCondVO};
            return (Isid.KKH.Common.KKHServiceProxy.findHatyuConfirmResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public System.String findsyouhinName(Isid.KKH.Common.KKHServiceProxy.findSyohinNameGetCond condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findsyouhinName");
            Object[] args = new Object[] {condition};
            return (System.String) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findMeisaiDataResult findMeisaiDataByCond(Isid.KKH.Common.KKHServiceProxy.findMeisaiDataCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findMeisaiDataByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.findMeisaiDataResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findThb5HikResult findHatyuget(Isid.KKH.Common.KKHServiceProxy.thb5HikVO Thb5HikVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findHatyuget");
            Object[] args = new Object[] {Thb5HikVO};
            return (Isid.KKH.Common.KKHServiceProxy.findThb5HikResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.findHatyuNumBycondResult findHatyuNumget(Isid.KKH.Common.KKHServiceProxy.findHatyuNumByCondVO FindHatyuNumByCondVO)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findHatyuNumget");
            Object[] args = new Object[] {FindHatyuNumByCondVO};
            return (Isid.KKH.Common.KKHServiceProxy.findHatyuNumBycondResult) filterChain.doFilter(args);
        }


    }
    /// <remarks/>
    public class kmnReportServiceAdapter : BaseServiceProxyAdapter, IServiceProxyAdapter
    {
        /// <remarks/>
        public kmnReportServiceAdapter(WebServicesClientProtocol service, SOAPolicy policy) : base(service, policy)
        {
        }
        
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.updateSeqNoResult updateSeqNoByCond(Isid.KKH.Common.KKHServiceProxy.updateSeqNoCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("updateSeqNoByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.updateSeqNoResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportKmnResult findReportKmnByCond(Isid.KKH.Common.KKHServiceProxy.reportKmnCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportKmnByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportKmnResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.maxSeqNoResult getMaxSeqNoByCond(Isid.KKH.Common.KKHServiceProxy.maxSeqNoCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("getMaxSeqNoByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.maxSeqNoResult) filterChain.doFilter(args);
        }
        
        /// <remarks/>
        public Isid.KKH.Common.KKHServiceProxy.reportKmnListResult findReportKmnListByCond(Isid.KKH.Common.KKHServiceProxy.reportKmnListCondition condition)
        {
            ProxyFilterChain filterChain = base.CreateNewProxyFilterChain("findReportKmnListByCond");
            Object[] args = new Object[] {condition};
            return (Isid.KKH.Common.KKHServiceProxy.reportKmnListResult) filterChain.doFilter(args);
        }


    }

}
