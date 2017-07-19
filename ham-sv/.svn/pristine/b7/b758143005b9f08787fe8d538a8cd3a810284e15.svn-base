package jp.co.isid.ham.common.model;

import java.util.List;

import jp.co.isid.ham.integ.tbl.Tbj27LogCrCreateData;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractSimpleRdbDao;
import jp.co.isid.nj.model.AbstractModel;

/**
 * <P>
 * CR制作費管理変更ログDAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/11/29 新HAMチーム)<BR>
 * </P>
 * @author 新HAMチーム
 */
public class Tbj27LogCrCreateDataDAO extends AbstractSimpleRdbDao {

    /** 検索条件 */
//    private Tbj27LogCrCreateDataCondition _condition = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode{LOAD, COND,  };
    private SelSqlMode _SelSqlMode = SelSqlMode.LOAD;

    /**
     * デフォルトコンストラクタ
     */
    public Tbj27LogCrCreateDataDAO() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを取得する
     *
     * @return String[] プライマリキー
     */
    public String[] getPrimryKeyNames() {
        return new String[] {
                Tbj27LogCrCreateData.DCARCD
                ,Tbj27LogCrCreateData.PHASE
                ,Tbj27LogCrCreateData.CRDATE
                ,Tbj27LogCrCreateData.SEQUENCENO
                ,Tbj27LogCrCreateData.HISTORYNO
        };
    }

    /**
     * 更新日付フィールドを取得する
     *
     * @return String 更新日付フィールド
     */
    public String getTimeStampKeyName() {
        return Tbj27LogCrCreateData.UPDDATE;
    }

    /**
     * システム日付で更新を行うカラム名の配列を取得する
     *
     * @return システム日付で更新を行うカラム名の配列
     */
    @Override
    public String[] getSystemDateColumnNames() {
        return new String[] {
                Tbj27LogCrCreateData.CRTDATE
                ,Tbj27LogCrCreateData.UPDDATE
        };
    }

    /**
     * テーブル名を取得する
     *
     * @return String テーブル名
     */
    public String getTableName() {
        return Tbj27LogCrCreateData.TBNAME;
    }

    /**
     * テーブル列名を取得する
     *
     * @return String[] テーブル列名
     */
    public String[] getTableColumnNames() {
        return new String[] {
                Tbj27LogCrCreateData.DCARCD
                ,Tbj27LogCrCreateData.PHASE
                ,Tbj27LogCrCreateData.CRDATE
                ,Tbj27LogCrCreateData.SEQUENCENO
                ,Tbj27LogCrCreateData.HISTORYNO
                ,Tbj27LogCrCreateData.HISTORYKBN
                ,Tbj27LogCrCreateData.CLASSDIV
                ,Tbj27LogCrCreateData.SORTNO
                ,Tbj27LogCrCreateData.CLASSCD
                ,Tbj27LogCrCreateData.EXPCD
                ,Tbj27LogCrCreateData.EXPENSE
                ,Tbj27LogCrCreateData.DETAIL
                ,Tbj27LogCrCreateData.KIKANS
                ,Tbj27LogCrCreateData.KIKANE
                ,Tbj27LogCrCreateData.CONTRACTDATE
                ,Tbj27LogCrCreateData.CONTRACTTERM
                ,Tbj27LogCrCreateData.SEIKYU
                ,Tbj27LogCrCreateData.TRTHSKGYCD
                ,Tbj27LogCrCreateData.TRSEQNO
                ,Tbj27LogCrCreateData.ORDERNO
                ,Tbj27LogCrCreateData.PAY
                ,Tbj27LogCrCreateData.HRTHSKGYCD
                ,Tbj27LogCrCreateData.HRSEQNO
                ,Tbj27LogCrCreateData.USERNAME
                ,Tbj27LogCrCreateData.GETMONEY
                ,Tbj27LogCrCreateData.GETCONF
                ,Tbj27LogCrCreateData.PAYMONEY
                ,Tbj27LogCrCreateData.PAYCONF
                ,Tbj27LogCrCreateData.ESTMONEY
                ,Tbj27LogCrCreateData.CLMMONEY
                ,Tbj27LogCrCreateData.DELIVERDAY
                ,Tbj27LogCrCreateData.SETMONTH
                ,Tbj27LogCrCreateData.DIVCD
                ,Tbj27LogCrCreateData.GROUPCD
                ,Tbj27LogCrCreateData.STKYKNO
                ,Tbj27LogCrCreateData.EGTYKFLG
                ,Tbj27LogCrCreateData.INPUTTNTCD
                ,Tbj27LogCrCreateData.CPTNTNM
                ,Tbj27LogCrCreateData.NOTE
                ,Tbj27LogCrCreateData.TCKEY
                ,Tbj27LogCrCreateData.TRSUBNO
                ,Tbj27LogCrCreateData.HRSUBNO
                ,Tbj27LogCrCreateData.RSTATUS
                ,Tbj27LogCrCreateData.STPKBN
                ,Tbj27LogCrCreateData.DCARCDFLG
                ,Tbj27LogCrCreateData.CLASSCDFLG
                ,Tbj27LogCrCreateData.EXPCDFLG
                ,Tbj27LogCrCreateData.EXPENSEFLG
                ,Tbj27LogCrCreateData.DETAILFLG
                ,Tbj27LogCrCreateData.KIKANSFLG
                ,Tbj27LogCrCreateData.KIKANEFLG
                ,Tbj27LogCrCreateData.CONTRACTDATEFLG
                ,Tbj27LogCrCreateData.CONTRACTTERMFLG
                ,Tbj27LogCrCreateData.SEIKYUFLG
                ,Tbj27LogCrCreateData.ORDERNOFLG
                ,Tbj27LogCrCreateData.PAYFLG
                ,Tbj27LogCrCreateData.USERNAMEFLG
                ,Tbj27LogCrCreateData.GETMONEYFLG
                ,Tbj27LogCrCreateData.GETCONFIRMFLG
                ,Tbj27LogCrCreateData.PAYMONEYFLG
                ,Tbj27LogCrCreateData.PAYCONFIRMFLG
                ,Tbj27LogCrCreateData.ESTMONEYFLG
                ,Tbj27LogCrCreateData.CLMMONEYFLG
                ,Tbj27LogCrCreateData.DELIVERDAYFLG
                ,Tbj27LogCrCreateData.SETMONTHFLG
                ,Tbj27LogCrCreateData.DIVISIONFLG
                ,Tbj27LogCrCreateData.GROUPCDFLG
                ,Tbj27LogCrCreateData.STKYKNOFLG
                ,Tbj27LogCrCreateData.EGTYKFLGFLG
                ,Tbj27LogCrCreateData.INPUTTNTCDFLG
                ,Tbj27LogCrCreateData.CPTNTNMFLG
                ,Tbj27LogCrCreateData.NOTEFLG
                ,Tbj27LogCrCreateData.DCARCDCONFFLG
                ,Tbj27LogCrCreateData.DCARCDCONFSIKCD
                ,Tbj27LogCrCreateData.DCARCDCONFHAMID
                ,Tbj27LogCrCreateData.CLASSCDCONFFLG
                ,Tbj27LogCrCreateData.CLASSCDCONFSIKCD
                ,Tbj27LogCrCreateData.CLASSCDCONFHAMID
                ,Tbj27LogCrCreateData.EXPCDCONFFLG
                ,Tbj27LogCrCreateData.EXPCDCONFSIKCD
                ,Tbj27LogCrCreateData.EXPCDCONFHAMID
                ,Tbj27LogCrCreateData.EXPENSECONFFLG
                ,Tbj27LogCrCreateData.EXPENSECONFSIKCD
                ,Tbj27LogCrCreateData.EXPENSECONFHAMID
                ,Tbj27LogCrCreateData.DETAILCONFFLG
                ,Tbj27LogCrCreateData.DETAILCONFSIKCD
                ,Tbj27LogCrCreateData.DETAILCONFHAMID
                ,Tbj27LogCrCreateData.KIKANSCONFFLG
                ,Tbj27LogCrCreateData.KIKANSCONFSIKCD
                ,Tbj27LogCrCreateData.KIKANSCONFHAMID
                ,Tbj27LogCrCreateData.KIKANECONFFLG
                ,Tbj27LogCrCreateData.KIKANECONFSIKCD
                ,Tbj27LogCrCreateData.KIKANECONFHAMID
                ,Tbj27LogCrCreateData.CONTRACTDATECONFFLG
                ,Tbj27LogCrCreateData.CONTRACTDATECONFSIKCD
                ,Tbj27LogCrCreateData.CONTRACTDATECONFHAMID
                ,Tbj27LogCrCreateData.CONTRACTTERMCONFFLG
                ,Tbj27LogCrCreateData.CONTRACTTERMCONFSIKCD
                ,Tbj27LogCrCreateData.CONTRACTTERMCONFHAMID
                ,Tbj27LogCrCreateData.SEIKYUCONFFLG
                ,Tbj27LogCrCreateData.SEIKYUCONFSIKCD
                ,Tbj27LogCrCreateData.SEIKYUCONFHAMID
                ,Tbj27LogCrCreateData.ORDERNOCONFFLG
                ,Tbj27LogCrCreateData.ORDERNOCONFSIKCD
                ,Tbj27LogCrCreateData.ORDERNOCONFHAMID
                ,Tbj27LogCrCreateData.PAYCONFFLG
                ,Tbj27LogCrCreateData.PAYCONFSIKCD
                ,Tbj27LogCrCreateData.PAYCONFHAMID
                ,Tbj27LogCrCreateData.USERNAMECONFFLG
                ,Tbj27LogCrCreateData.USERNAMECONFSIKCD
                ,Tbj27LogCrCreateData.USERNAMECONFHAMID
                ,Tbj27LogCrCreateData.GETMONEYCONFFLG
                ,Tbj27LogCrCreateData.GETMONEYCONFSIKCD
                ,Tbj27LogCrCreateData.GETMONEYCONFHAMID
                ,Tbj27LogCrCreateData.GETCONFCONFFLG
                ,Tbj27LogCrCreateData.GETCONFCONFSIKCD
                ,Tbj27LogCrCreateData.GETCONFCONFHAMID
                ,Tbj27LogCrCreateData.PAYMONEYCONFFLG
                ,Tbj27LogCrCreateData.PAYMONEYCONFSIKCD
                ,Tbj27LogCrCreateData.PAYMONEYCONFHAMID
                ,Tbj27LogCrCreateData.PAYCONFCONFFLG
                ,Tbj27LogCrCreateData.PAYCONFCONFSIKCD
                ,Tbj27LogCrCreateData.PAYCONFCONFHAMID
                ,Tbj27LogCrCreateData.ESTMONEYCONFFLG
                ,Tbj27LogCrCreateData.ESTMONEYCONFSIKCD
                ,Tbj27LogCrCreateData.ESTMONEYCONFHAMID
                ,Tbj27LogCrCreateData.CLMMONEYCONFFLG
                ,Tbj27LogCrCreateData.CLMMONEYCONFSIKCD
                ,Tbj27LogCrCreateData.CLMMONEYCONFHAMID
                ,Tbj27LogCrCreateData.DELIVERDAYCONFFLG
                ,Tbj27LogCrCreateData.DELIVERDAYCONFSIKCD
                ,Tbj27LogCrCreateData.DELIVERDAYCONFHAMID
                ,Tbj27LogCrCreateData.SETMONTHCONFFLG
                ,Tbj27LogCrCreateData.SETMONTHCONFSIKCD
                ,Tbj27LogCrCreateData.SETMONTHCONFHAMID
                ,Tbj27LogCrCreateData.DIVISIONCONFFLG
                ,Tbj27LogCrCreateData.DIVISIONCONFSIKCD
                ,Tbj27LogCrCreateData.DIVISIONCONFHAMID
                ,Tbj27LogCrCreateData.GROUPCDCONFFLG
                ,Tbj27LogCrCreateData.GROUPCDCONFSIKCD
                ,Tbj27LogCrCreateData.GROUPCDCONFHAMID
                ,Tbj27LogCrCreateData.STKYKNOCONFFLG
                ,Tbj27LogCrCreateData.STKYKNOCONFSIKCD
                ,Tbj27LogCrCreateData.STKYKNOCONFHAMID
                ,Tbj27LogCrCreateData.EGTYKCONFFLG
                ,Tbj27LogCrCreateData.EGTYKCONFSIKCD
                ,Tbj27LogCrCreateData.EGTYKCONFHAMID
                ,Tbj27LogCrCreateData.INPUTTNTCDCONFFLG
                ,Tbj27LogCrCreateData.INPUTTNTCDCONFSIKCD
                ,Tbj27LogCrCreateData.INPUTTNTCDCONFHAMID
                ,Tbj27LogCrCreateData.CPTNTNMCONFFLG
                ,Tbj27LogCrCreateData.CPTNTNMCONFSIKCD
                ,Tbj27LogCrCreateData.CPTNTNMCONFHAMID
                ,Tbj27LogCrCreateData.NOTECONFFLG
                ,Tbj27LogCrCreateData.NOTECONFSIKCD
                ,Tbj27LogCrCreateData.NOTECONFHAMID
                ,Tbj27LogCrCreateData.CRTDATE
                ,Tbj27LogCrCreateData.CRTNM
                ,Tbj27LogCrCreateData.CRTAPL
                ,Tbj27LogCrCreateData.CRTID
                ,Tbj27LogCrCreateData.UPDDATE
                ,Tbj27LogCrCreateData.UPDNM
                ,Tbj27LogCrCreateData.UPDAPL
                ,Tbj27LogCrCreateData.UPDID
        };
    }

    /**
     * CondtionからVOに変換する
     * @param cond
     * @return
     */
    private Tbj27LogCrCreateDataVO convertCondToVo(Tbj27LogCrCreateDataCondition cond) {
        Tbj27LogCrCreateDataVO vo = new Tbj27LogCrCreateDataVO();

        vo.setDCARCD(cond.getDcarcd());                                                 //電通車種コード
        vo.setPHASE(cond.getPhase());                                                   //フェイズ
        vo.setCRDATE(cond.getCrdate());                                                 //年月
        vo.setSEQUENCENO(cond.getSequenceno());                                         //制作費管理NO
        vo.setHISTORYNO(cond.getHistoryno());                                           //履歴NO
        vo.setHISTORYKBN(cond.getHistorykbn());                                         //履歴区分
        vo.setCLASSDIV(cond.getClassdiv());                                             //種別判断フラグ
        vo.setSORTNO(cond.getSortno());                                                 //ソート順
        vo.setCLASSCD(cond.getClasscd());                                               //予算分類コード
        vo.setEXPCD(cond.getExpcd());                                                   //予算表費目コード
        vo.setEXPENSE(cond.getExpense());                                               //費目
        vo.setDETAIL(cond.getDetail());                                                 //詳細
        vo.setKIKANS(cond.getKikans());                                                 //期間開始
        vo.setKIKANE(cond.getKikane());                                                 //期間終了
        vo.setCONTRACTDATE(cond.getContractdate());                                     //契約開始年月日
        vo.setCONTRACTTERM(cond.getContractterm());                                     //契約期間(ヶ月)
        vo.setSEIKYU(cond.getSeikyu());                                                 //請求先
        vo.setTRTHSKGYCD(cond.getTrthskgycd());                                         //請求先取引先企業コード
        vo.setTRSEQNO(cond.getTrseqno());                                               //請求先ＳＥＱＮＯ
        vo.setORDERNO(cond.getOrderno());                                               //受注NO
        vo.setPAY(cond.getPay());                                                       //支払先
        vo.setHRTHSKGYCD(cond.getHrthskgycd());                                         //支払先取引先企業コード
        vo.setHRSEQNO(cond.getHrseqno());                                               //支払先ＳＥＱＮＯ
        vo.setUSERNAME(cond.getUsername());                                             //担当者
        vo.setGETMONEY(cond.getGetmoney());                                             //取り金額
        vo.setGETCONF(cond.getGetconf());                                               //取り金額確認
        vo.setPAYMONEY(cond.getPaymoney());                                             //払い金額
        vo.setPAYCONF(cond.getPayconf());                                               //払い金額確認
        vo.setESTMONEY(cond.getEstmoney());                                             //見積金額
        vo.setCLMMONEY(cond.getClmmoney());                                             //請求金額
        vo.setDELIVERDAY(cond.getDeliverday());                                         //支払先納品日
        vo.setSETMONTH(cond.getSetmonth());                                             //設定月
        vo.setDIVCD(cond.getDivcd());                                                   //区分コード
        vo.setGROUPCD(cond.getGroupcd());                                               //グループコード
        vo.setSTKYKNO(cond.getStkykno());                                               //設定局ナンバー
        vo.setEGTYKFLG(cond.getEgtykflg());                                             //営直チェック
        vo.setINPUTTNTCD(cond.getInputtntcd());                                         //入力担当コード
        vo.setCPTNTNM(cond.getCptntnm());                                               //CP担当者名
        vo.setNOTE(cond.getNote());                                                     //備考
        vo.setTCKEY(cond.getTckey());                                                   //TCKEY
        vo.setTRSUBNO(cond.getTrsubno());                                               //取サブＮＯ
        vo.setHRSUBNO(cond.getHrsubno());                                               //払サブＮＯ
        vo.setRSTATUS(cond.getRstatus());                                               //連携ステータス
        vo.setSTPKBN(cond.getStpkbn());                                                 //中止区分
        vo.setDCARCDFLG(cond.getDcarcdflg());                                           //電通車種コードフラグ
        vo.setCLASSCDFLG(cond.getClasscdflg());                                         //予算分類フラグ
        vo.setEXPCDFLG(cond.getExpcdflg());                                             //予算表費目フラグ
        vo.setEXPENSEFLG(cond.getExpenseflg());                                         //費目フラグ
        vo.setDETAILFLG(cond.getDetailflg());                                           //詳細フラグ
        vo.setKIKANSFLG(cond.getKikansflg());                                           //期間開始フラグ
        vo.setKIKANEFLG(cond.getKikaneflg());                                           //期間終了フラグ
        vo.setCONTRACTDATEFLG(cond.getContractdateflg());                               //契約開始年月日フラグ
        vo.setCONTRACTTERMFLG(cond.getContracttermflg());                               //契約期間(ヶ月)フラグ
        vo.setSEIKYUFLG(cond.getSeikyuflg());                                           //請求先フラグ
        vo.setORDERNOFLG(cond.getOrdernoflg());                                         //受注NOフラグ
        vo.setPAYFLG(cond.getPayflg());                                                 //支払先フラグ
        vo.setUSERNAMEFLG(cond.getUsernameflg());                                       //担当者フラグ
        vo.setGETMONEYFLG(cond.getGetmoneyflg());                                       //取り金額フラグ
        vo.setGETCONFIRMFLG(cond.getGetconfirmflg());                                   //取り金額確認フラグ
        vo.setPAYMONEYFLG(cond.getPaymoneyflg());                                       //払い金額フラグ
        vo.setPAYCONFIRMFLG(cond.getPayconfirmflg());                                   //払い金額確認フラグ
        vo.setESTMONEYFLG(cond.getEstmoneyflg());                                       //見積金額フラグ
        vo.setCLMMONEYFLG(cond.getClmmoneyflg());                                       //請求金額フラグ
        vo.setDELIVERDAYFLG(cond.getDeliverdayflg());                                   //支払先納品日フラグ
        vo.setSETMONTHFLG(cond.getSetmonthflg());                                       //設定月フラグ
        vo.setDIVISIONFLG(cond.getDivisionflg());                                       //区分フラグ
        vo.setGROUPCDFLG(cond.getGroupcdflg());                                         //グループコードフラグ
        vo.setSTKYKNOFLG(cond.getStkyknoflg());                                         //設定局ナンバーフラグ
        vo.setEGTYKFLGFLG(cond.getEgtykflgflg());                                       //営直チェックフラグ
        vo.setINPUTTNTCDFLG(cond.getInputtntcdflg());                                   //入力担当コードフラグ
        vo.setCPTNTNMFLG(cond.getCptntnmflg());                                         //CP担当者フラグ
        vo.setNOTEFLG(cond.getNoteflg());                                               //備考フラグ
        vo.setDCARCDCONFFLG(cond.getDcarcdconfflg());                                   //電通車種コード確認フラグ
        vo.setDCARCDCONFSIKCD(cond.getDcarcdconfsikcd());                               //電通車種コード確認組織コード
        vo.setDCARCDCONFHAMID(cond.getDcarcdconfhamid());                               //電通車種コード確認担当者コード
        vo.setCLASSCDCONFFLG(cond.getClasscdconfflg());                                 //予算表分類確認フラグ
        vo.setCLASSCDCONFSIKCD(cond.getClasscdconfsikcd());                             //予算表分類確認組織コード
        vo.setCLASSCDCONFHAMID(cond.getClasscdconfhamid());                             //予算表分類確認担当者コード
        vo.setEXPCDCONFFLG(cond.getExpcdconfflg());                                     //予算表費目確認フラグ
        vo.setEXPCDCONFSIKCD(cond.getExpcdconfsikcd());                                 //予算表費目確認組織コード
        vo.setEXPCDCONFHAMID(cond.getExpcdconfhamid());                                 //予算表費目確認担当者コード
        vo.setEXPENSECONFFLG(cond.getExpenseconfflg());                                 //費目確認フラグ
        vo.setEXPENSECONFSIKCD(cond.getExpenseconfsikcd());                             //費目確認組織コード
        vo.setEXPENSECONFHAMID(cond.getExpenseconfhamid());                             //費目確認担当者コード
        vo.setDETAILCONFFLG(cond.getDetailconfflg());                                   //詳細確認フラグ
        vo.setDETAILCONFSIKCD(cond.getDetailconfsikcd());                               //詳細確認組織コード
        vo.setDETAILCONFHAMID(cond.getDetailconfhamid());                               //詳細確認担当者コード
        vo.setKIKANSCONFFLG(cond.getKikansconfflg());                                   //期間開始確認フラグ
        vo.setKIKANSCONFSIKCD(cond.getKikansconfsikcd());                               //期間開始確認組織コード
        vo.setKIKANSCONFHAMID(cond.getKikansconfhamid());                               //期間開始確認担当者コード
        vo.setKIKANECONFFLG(cond.getKikaneconfflg());                                   //期間終了確認フラグ
        vo.setKIKANECONFSIKCD(cond.getKikaneconfsikcd());                               //期間終了確認組織コード
        vo.setKIKANECONFHAMID(cond.getKikaneconfhamid());                               //期間終了確認担当者コード
        vo.setCONTRACTDATECONFFLG(cond.getContractdateconfflg());                       //契約開始年月日確認フラグ
        vo.setCONTRACTDATECONFSIKCD(cond.getContractdateconfsikcd());                   //契約開始年月日確認組織コード
        vo.setCONTRACTDATECONFHAMID(cond.getContractdateconfhamid());                   //契約開始年月日確認担当者コード
        vo.setCONTRACTTERMCONFFLG(cond.getContracttermconfflg());                       //契約期間(ヶ月)確認フラグ
        vo.setCONTRACTTERMCONFSIKCD(cond.getContracttermconfsikcd());                   //契約期間(ヶ月)確認組織コード
        vo.setCONTRACTTERMCONFHAMID(cond.getContracttermconfhamid());                   //契約期間(ヶ月)確認担当者コード
        vo.setSEIKYUCONFFLG(cond.getSeikyuconfflg());                                   //請求先確認フラグ
        vo.setSEIKYUCONFSIKCD(cond.getSeikyuconfsikcd());                               //請求先確認組織コード
        vo.setSEIKYUCONFHAMID(cond.getSeikyuconfhamid());                               //請求先確認担当者コード
        vo.setORDERNOCONFFLG(cond.getOrdernoconfflg());                                 //受注NO確認フラグ
        vo.setORDERNOCONFSIKCD(cond.getOrdernoconfsikcd());                             //受注NO確認組織コード
        vo.setORDERNOCONFHAMID(cond.getOrdernoconfhamid());                             //受注NO確認担当者コード
        vo.setPAYCONFFLG(cond.getPayconfflg());                                         //支払先確認フラグ
        vo.setPAYCONFSIKCD(cond.getPayconfsikcd());                                     //支払先確認組織コード
        vo.setPAYCONFHAMID(cond.getPayconfhamid());                                     //支払先確認担当者コード
        vo.setUSERNAMECONFFLG(cond.getUsernameconfflg());                               //担当者確認フラグ
        vo.setUSERNAMECONFSIKCD(cond.getUsernameconfsikcd());                           //担当者確認組織コード
        vo.setUSERNAMECONFHAMID(cond.getUsernameconfhamid());                           //担当者確認担当者コード
        vo.setGETMONEYCONFFLG(cond.getGetmoneyconfflg());                               //取り金額確認フラグ
        vo.setGETMONEYCONFSIKCD(cond.getGetmoneyconfsikcd());                           //取り金額確認組織コード
        vo.setGETMONEYCONFHAMID(cond.getGetmoneyconfhamid());                           //取り金額確認担当者コード
        vo.setGETCONFCONFFLG(cond.getGetconfconfflg());                                 //取り金額確認確認フラグ
        vo.setGETCONFCONFSIKCD(cond.getGetconfconfsikcd());                             //取り金額確認確認組織コード
        vo.setGETCONFCONFHAMID(cond.getGetconfconfhamid());                             //取り金額確認確認担当者コード
        vo.setPAYMONEYCONFFLG(cond.getPaymoneyconfflg());                               //払い金額確認フラグ
        vo.setPAYMONEYCONFSIKCD(cond.getPaymoneyconfsikcd());                           //払い金額確認組織コード
        vo.setPAYMONEYCONFHAMID(cond.getPaymoneyconfhamid());                           //払い金額確認担当者コード
        vo.setPAYCONFCONFFLG(cond.getPayconfconfflg());                                 //払い金額確認確認フラグ
        vo.setPAYCONFCONFSIKCD(cond.getPayconfconfsikcd());                             //払い金額確認確認組織コード
        vo.setPAYCONFCONFHAMID(cond.getPayconfconfhamid());                             //払い金額確認確認担当者コード
        vo.setESTMONEYCONFFLG(cond.getEstmoneyconfflg());                               //見積金額確認フラグ
        vo.setESTMONEYCONFSIKCD(cond.getEstmoneyconfsikcd());                           //見積金額確認組織コード
        vo.setESTMONEYCONFHAMID(cond.getEstmoneyconfhamid());                           //見積金額確認担当者コード
        vo.setCLMMONEYCONFFLG(cond.getClmmoneyconfflg());                               //請求金額確認フラグ
        vo.setCLMMONEYCONFSIKCD(cond.getClmmoneyconfsikcd());                           //請求金額確認組織コード
        vo.setCLMMONEYCONFHAMID(cond.getClmmoneyconfhamid());                           //請求金額確認担当者コード
        vo.setDELIVERDAYCONFFLG(cond.getDeliverdayconfflg());                           //支払先納品日確認フラグ
        vo.setDELIVERDAYCONFSIKCD(cond.getDeliverdayconfsikcd());                       //支払先納品日確認組織コード
        vo.setDELIVERDAYCONFHAMID(cond.getDeliverdayconfhamid());                       //支払先納品日確認担当者コード
        vo.setSETMONTHCONFFLG(cond.getSetmonthconfflg());                               //設定月確認フラグ
        vo.setSETMONTHCONFSIKCD(cond.getSetmonthconfsikcd());                           //設定月確認組織コード
        vo.setSETMONTHCONFHAMID(cond.getSetmonthconfhamid());                           //設定月確認担当者コード
        vo.setDIVISIONCONFFLG(cond.getDivisionconfflg());                               //区分コード確認フラグ
        vo.setDIVISIONCONFSIKCD(cond.getDivisionconfsikcd());                           //区分コード確認組織コード
        vo.setDIVISIONCONFHAMID(cond.getDivisionconfhamid());                           //区分コード確認担当者コード
        vo.setGROUPCDCONFFLG(cond.getGroupcdconfflg());                                 //グループコード確認フラグ
        vo.setGROUPCDCONFSIKCD(cond.getGroupcdconfsikcd());                             //グループコード確認組織コード
        vo.setGROUPCDCONFHAMID(cond.getGroupcdconfhamid());                             //グループコード確認担当者コード
        vo.setSTKYKNOCONFFLG(cond.getStkyknoconfflg());                                 //設定局ナンバー確認フラグ
        vo.setSTKYKNOCONFSIKCD(cond.getStkyknoconfsikcd());                             //設定局ナンバー確認組織コード
        vo.setSTKYKNOCONFHAMID(cond.getStkyknoconfhamid());                             //設定局ナンバー確認担当者コード
        vo.setEGTYKCONFFLG(cond.getEgtykconfflg());                                     //営直チェック確認フラグ
        vo.setEGTYKCONFSIKCD(cond.getEgtykconfsikcd());                                 //営直チェック確認組織コード
        vo.setEGTYKCONFHAMID(cond.getEgtykconfhamid());                                 //営直チェック確認担当者コード
        vo.setINPUTTNTCDCONFFLG(cond.getInputtntcdconfflg());                           //入力担当コード確認フラグ
        vo.setINPUTTNTCDCONFSIKCD(cond.getInputtntcdconfsikcd());                       //入力担当コード確認組織コード
        vo.setINPUTTNTCDCONFHAMID(cond.getInputtntcdconfhamid());                       //入力担当コード確認担当者コード
        vo.setCPTNTNMCONFFLG(cond.getCptntnmconfflg());                                 //CP担当者確認フラグ
        vo.setCPTNTNMCONFSIKCD(cond.getCptntnmconfsikcd());                             //CP担当者確認組織コード
        vo.setCPTNTNMCONFHAMID(cond.getCptntnmconfhamid());                             //CP担当者確認担当者コード
        vo.setNOTECONFFLG(cond.getNoteconfflg());                                       //備考確認フラグ
        vo.setNOTECONFSIKCD(cond.getNoteconfsikcd());                                   //備考確認組織コード
        vo.setNOTECONFHAMID(cond.getNoteconfhamid());                                   //備考確認担当者コード
        vo.setCRTDATE(cond.getCrtdate());                                               //データ作成日時
        vo.setCRTNM(cond.getCrtnm());                                                   //データ作成者
        vo.setUPDDATE(cond.getUpddate());                                               //データ更新日時
        vo.setUPDNM(cond.getUpdnm());                                                   //データ更新者
        vo.setUPDAPL(cond.getUpdapl());                                                 //更新プログラム
        vo.setUPDID(cond.getUpdid());                                                   //更新担当者ID


        return vo;
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {
        StringBuffer sql = new StringBuffer();

        if (_SelSqlMode.equals(SelSqlMode.LOAD)) {

            //*******************************************
            //Load()で使用されるSELECT + FROM句のSQL
            //*******************************************
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.COND)) {

            //*******************************************
            //selectVOで使用されるSQL
            //*******************************************
            //SELECT + FROM句
            sql.append(" SELECT ");
            for (int i = 0; i < getTableColumnNames().length; i++) {
                sql.append((i != 0 ? " ," : " "));
                sql.append("" + getTableColumnNames()[i] +" ");
            }
            sql.append(" FROM ");
            sql.append(" " + getTableName() + " ");
            //WHERE句
            sql.append(generateWhereByCond(getModel()));
            //OrderBy句
            sql.append(" ORDER BY ");
            sql.append(" " + Tbj27LogCrCreateData.HISTORYNO + " ");

        }

        return sql.toString();
    };

    /**
     * 値の設定有無からSQLのWHERE句を生成する
     * @param vo
     * @return
     */
    private String generateWhereByCond(AbstractModel vo) {
        StringBuffer sql = new StringBuffer();

        for (int i = 0; i < getTableColumnNames().length; i++) {
            Object value = vo.get(getTableColumnNames()[i]);
            if (value != null) {
                if (sql.length() == 0) {
                    sql.append(" WHERE ");
                } else {
                    sql.append(" AND ");
                }
                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
            }
        }

        return sql.toString();
    }

//    /**
//     * 値の設定有無からUPDATEのSET句を生成する
//     * @param vo
//     * @return
//     */
//    private String generateSetByCond(AbstractModel vo) {
//        StringBuffer sql = new StringBuffer();
//
//        for (int i = 0; i < getTableColumnNames().length; i++) {
//            Object value = vo.get(getTableColumnNames()[i]);
//            if (value != null) {
//                if (sql.length() == 0) {
//                    sql.append(" SET ");
//                } else {
//                    sql.append("    ,");
//                }
//                sql.append(getTableColumnNames()[i] + " = " + getDBModelInterface().ConvertToDBString(value));
//            }
//        }
//
//        return sql.toString();
//    }

    /**
     * 指定した条件で検索を行い、データを取得します
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj27LogCrCreateDataVO> selectVO(Tbj27LogCrCreateDataCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(convertCondToVo(cond));
        try {
            _SelSqlMode = SelSqlMode.COND;
            return (List<Tbj27LogCrCreateDataVO>)super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * PK検索
     * @param cond
     * @return
     * @throws HAMException
     */
    public Tbj27LogCrCreateDataVO loadVO(Tbj27LogCrCreateDataVO vo) throws HAMException {
        //パラメータチェック
        if (vo == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(vo);
        try {
            return (Tbj27LogCrCreateDataVO)super.load();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

}
