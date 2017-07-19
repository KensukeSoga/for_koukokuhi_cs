package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Map;

import jp.co.isid.ham.common.model.Tbj16ContractInfoVO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj24LogContractInfoVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj19Jasrac;
import jp.co.isid.ham.integ.tbl.Tbj24LogContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj40TempSozaiContent;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;

/**
 * <P>
 * 素材登録テーブル取得DAO
 * </P>
 * <P>
 * <B>修正履歴</B><BR>
 * ・新規作成(2012/12/03 JSE A.Naito)<BR>
 * ・JASRAC対応(2015/11/27 HLC S.Fujimoto)<BR>
 * ・HDX対応(2016/02/24 HLC K.Oki)<BR>
 * </P>
 *
 * @author
 */
public class ContractRegisterDao extends AbstractRdbDao {

    /** getSelectSQLで発行するSQLのモード() */
    private enum SelSqlMode {
        CONTRACT,
        CONTENT,
        TALENT,
        MUSIC,
        CountC,
        CountJ,
        TimeStamp,
        CmCd,
        ContractInfo,
        CTRTNO,
        History,
        SearchM,
        Category,
        Second,
        Syatan,
    };
    private SelSqlMode _SelSqlMode = null;

    /** getSelectSQLで発行するSQLのモード() */
    private enum ExecSqlMode {
        DeleteC,
        DeleteJ,
        UpdateC,
        UpdateContent,
        InsertHistory,
        UpdateKLIMIT,
    };
    private ExecSqlMode _ExecSqlMode = null;

    /** 汎用マスタ検索条件 */
    private ContractDeleteCondition _cond2;
    /** 汎用マスタ検索条件 */
    private GetContractInfoListCondition _cond4;
    /** 汎用マスタ検索条件 */
    private Tbj16ContractInfoUpdateVO _vo;
    /** 汎用マスタ検索条件 */
    private Tbj18SozaiKanriDataUpdateVO _vo2;
    /** コード種別：素材 */
    private String CODETYPE_CONTRACTINFO = "16";
    /** 削除フラグ：削除(D) */
    private String DeleteYes = "D";
    /** 削除フラグ：( ) */
    private String DeleteNo = " ";

    /* 2015/11/27 JASRAC対応 HLC S.Fujimoto DEL Start */
    //    /** 契約種類(タレント) */
    //    private String CTRTKBN_TALENT = "1";
    //    /** 契約種類(ナレーター) */
    //    private String CTRTKBN_NARRATOR = "3";
    //    /** 契約種類(楽曲) */
    //    private String CTRTKBN_MUSIC = "4";
    //    /** 契約種類(その他) */
    //    private String CTRTKBN_SONOTA = "5";
    /* 2015/11/27 JASRAC対応 HLC S.Fujimoto DEL End */

    /** 検索条件 */
    private FindLogContractInfoCondition _condLogContractInfo = null;

    /**
     * デフォルトコンストラクタ
     */
    public ContractRegisterDao() {
        super.setPoolConnectClass(HAMPoolConnect.class);
        super.setDBModelInterface(HAMOracleModel.getInstance());
        super.setBigDecimalMode(true);
    }

    /**
     * プライマリキーを返します
     *
     * @return String[] プライマリキー
     */
    @Override
    public String[] getPrimryKeyNames() {
        return null;
    }

    /**
     * 更新日付フィールドを返します
     *
     * @return String 更新日付フィールド
     */
    @Override
    public String getTimeStampKeyName() {
        return null;
    }

    /**
     * テーブル名を返します
     *
     * @return String テーブル名
     */
    @Override
    public String getTableName() {
        return null;
    }

    /**
     * テーブル列名を返します
     *
     * @return String[] テーブル列名
     */
    @Override
    public String[] getTableColumnNames() {
        return null;
    }

    /**
     * デフォルトのSQL文を返します
     */
    @Override
    public String getSelectSQL() {

        StringBuffer sql = new StringBuffer();

        //使用素材表示用データ(タレント・ナレーター)の取得SQL
        if (_SelSqlMode.equals(SelSqlMode.TALENT)) {

            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD Start */
            //            sql.append(" SELECT ");
            //            sql.append("   " + Tbj17Content.CTRTKBN + " "); //契約種類
            //            sql.append("  ," + Tbj17Content.CTRTNO + " "); //契約コード
            //            sql.append("  ," + Tbj18SozaiKanriData.NOKBN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CMCD + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.STATUS + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DCARCD + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CATEGORY + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.TITLE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.SECOND + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.SYATAN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.NOHIN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.PRODUCT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATEFROM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATETO + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.MLIMIT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.KLIMIT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATERECOG + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATEPRT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.BIKO + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTDATE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTNM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTAPL + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTID + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDDATE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDNM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDAPL + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDID + " ");
            //            sql.append(" FROM ");
            //            sql.append("  " + Tbj17Content.TBNAME + " ");
            //            sql.append(" ," + Tbj18SozaiKanriData.TBNAME + " ");
            //            sql.append(" WHERE ");
            //            sql.append("  " + Tbj17Content.CMCD + " ");
            //            sql.append(" = " + Tbj18SozaiKanriData.CMCD + " ");
            //            sql.append(" AND " + Tbj17Content.CTRTKBN + " ");
            //            sql.append(" <> " + CTRTKBN_MUSIC + " "); //4：楽曲
            //            sql.append(" AND " + Tbj18SozaiKanriData.STATUS + " NOT IN ('D', 'I') ");
            //            sql.append(" ORDER BY ");
            //            sql.append("  " + Tbj17Content.CMCD + " "); //10桁CMコード
            //            sql.append(" ," + Tbj17Content.CTRTKBN + " "); //契約種類
            //            sql.append(" ," + Tbj17Content.CTRTNO + " "); //契約コード

            //本素材
            sql.append(" SELECT");
            sql.append(" " + Tbj17Content.CTRTKBN + " " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj17Content.CTRTNO + " " + Tbj17Content.CTRTNO + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + " " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj18SozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj18SozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj18SozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDID + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + FindUseMaterialVO.TEMPFLG); //本素材

            sql.append(" FROM");
            sql.append(" " + Tbj17Content.TBNAME + ",");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj17Content.CMCD + " = " + Tbj18SozaiKanriData.CMCD + " AND");
            sql.append(" " + Tbj17Content.CTRTKBN + " <> " + HAMConstants.CTRTKBN_MUSIC + " AND");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + " NOT IN ('D', 'I')");

            sql.append(" UNION ALL");

            //仮素材
            sql.append(" SELECT");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " " + Tbj17Content.CTRTNO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN+ " ,");
            sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDID + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "'");    //仮素材

            sql.append(" FROM");
            sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " = " + Tbj40TempSozaiContent.TEMPCMCD + " AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " <> " + HAMConstants.CTRTKBN_MUSIC + " AND");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + " NOT IN ('D', 'I')");

            sql.append(" ORDER BY");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj17Content.CTRTNO);
            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD End */
        }

        //使用素材表示用データ(楽曲)の取得SQL
        else if (_SelSqlMode.equals(SelSqlMode.MUSIC)) {

            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD Start */
            //            sql.append(" SELECT ");
            //            sql.append("   " + Tbj17Content.CTRTKBN + " "); //契約種類
            //            sql.append("  ," + Tbj17Content.CTRTNO + " "); //契約コード
            //            sql.append("  ," + Tbj18SozaiKanriData.NOKBN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CMCD + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.STATUS + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DCARCD + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CATEGORY + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.TITLE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.SECOND + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.SYATAN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.NOHIN + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.PRODUCT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATEFROM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATETO + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.MLIMIT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.KLIMIT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATERECOG + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.DATEPRT + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.BIKO + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTDATE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTNM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTAPL + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.CRTID + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDDATE + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDNM + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDAPL + " ");
            //            sql.append("  ," + Tbj18SozaiKanriData.UPDID + " ");
            //            sql.append(" FROM ");
            //            sql.append("  " + Tbj17Content.TBNAME + " ");
            //            sql.append(" ," + Tbj18SozaiKanriData.TBNAME + " ");
            //            sql.append(" WHERE ");
            //            sql.append("  " + Tbj17Content.CMCD + " ");
            //            sql.append(" = " + Tbj18SozaiKanriData.CMCD + " ");
            //            sql.append(" AND " + Tbj17Content.CTRTKBN + " ");
            //            sql.append(" = " + CTRTKBN_MUSIC + " "); //4：楽曲
            //            sql.append(" AND " + Tbj18SozaiKanriData.STATUS + " NOT IN ('D', 'I') ");
            //            sql.append(" ORDER BY ");
            //            sql.append("  " + Tbj17Content.CMCD + " "); //10桁CMコード
            //            sql.append(" ," + Tbj17Content.CTRTKBN + " "); //契約種類
            //            sql.append(" ," + Tbj17Content.CTRTNO + " "); //契約コード

            //本素材
            sql.append(" SELECT");
            sql.append(" " + Tbj17Content.CTRTKBN + " " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj17Content.CTRTNO + " " + Tbj17Content.CTRTNO + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + " " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj18SozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj18SozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj18SozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDID + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + FindUseMaterialVO.TEMPFLG);

            sql.append(" FROM");
            sql.append(" " + Tbj17Content.TBNAME + ",");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj17Content.CTRTKBN + " = " + HAMConstants.CTRTKBN_MUSIC + " AND");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + " NOT IN ( '" + HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE + "', '" + HAMConstants.MATERIAL_REGISTER_DELFLG_IGNORE + "' ) AND");
            sql.append(" " + Tbj17Content.CMCD + " = " + Tbj18SozaiKanriData.CMCD);

            sql.append(" UNION ALL");

            //仮素材
            sql.append(" SELECT");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " " + Tbj17Content.CTRTNO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDID + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "'");

            sql.append(" FROM");
            sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = " + HAMConstants.CTRTKBN_MUSIC + " AND");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + " NOT IN ( '" + HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE + "', '" + HAMConstants.MATERIAL_REGISTER_DELFLG_IGNORE + "' ) AND");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " = " + Tbj36TempSozaiKanriData.TEMPCMCD);

            sql.append(" ORDER BY");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj17Content.CTRTKBN + ",");
            sql.append(" " + Tbj17Content.CTRTNO);
            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD End */
        }

        //コンテンツデータのカウントの取得SQL
        else if (_SelSqlMode.equals(SelSqlMode.CountC)) {

            sql.append(" SELECT ");
            sql.append("  " + "COUNT(*) COUNT" + " ");
            sql.append(" FROM ");
            sql.append("  " + Tbj17Content.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj17Content.CTRTKBN + " ");
            sql.append(" = " + _cond2.getStrCtrtKbn() + " ");
            sql.append(" AND " + Tbj17Content.CTRTNO + " ");
            sql.append(" = " + _cond2.getStrCtrtNo() + " ");
        }

        //JASRACデータのカウントの取得SQL
        else if (_SelSqlMode.equals(SelSqlMode.CountJ)) {

            sql.append(" SELECT ");
            sql.append("  " + "COUNT(*) COUNT" + " ");
            sql.append(" FROM ");
            sql.append("  " + Tbj19Jasrac.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj19Jasrac.CTRTNO + " ");
            sql.append(" = " + _cond2.getStrCtrtNo() + " ");
            sql.append(" AND " + Tbj19Jasrac.DELFLG + " ");
            sql.append(" = '" + DeleteNo + "' ");
        }

        //TIMESTAMP項目の取得SQL
        else if (_SelSqlMode.equals(SelSqlMode.TimeStamp)) {

            sql.append(" SELECT ");
            sql.append("   " + Tbj16ContractInfo.UPDDATE + " ");
            sql.append(" FROM ");
            sql.append("   " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("   " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append("   = " + _cond4.getStrCtrtKbn() + " ");
            sql.append("  AND ");
            sql.append("   " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append("   = " + _cond4.getStrCtrtNo() + " ");
        }

        //コンテンツテーブル、素材登録テーブルの読込SQL
        else if (_SelSqlMode.equals(SelSqlMode.CmCd)) {

            sql.append(" SELECT ");
            sql.append("  " + Tbj17Content.CMCD + " ");
            sql.append(" ," + Tbj17Content.CTRTKBN + " ");
            sql.append(" ," + Tbj17Content.CTRTNO + " ");
            sql.append(" ," + Tbj18SozaiKanriData.DATEFROM + " ");
            sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
            sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
            sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
            sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
            /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
            sql.append(" ,'" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + GetContentMaterialVO.TEMPFLG); //本素材
            /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */

            sql.append(" FROM ");
            sql.append("  " + Tbj17Content.TBNAME + " ");
            sql.append(" ," + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" ," + Tbj18SozaiKanriData.TBNAME + " ");

            sql.append(" WHERE ");
            sql.append("     " + Tbj18SozaiKanriData.CMCD + " ");
            sql.append(" =  " + Tbj17Content.CMCD + " ");
            sql.append(" AND " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" =  " + Tbj17Content.CTRTKBN + " ");
            sql.append(" AND " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" =  " + Tbj17Content.CTRTNO + " ");
            sql.append(" AND " + Tbj17Content.CMCD + " ");
            sql.append(" IN ( ");
            sql.append(" SELECT ");
            sql.append("  " + Tbj17Content.CMCD + " ");
            sql.append(" FROM ");
            sql.append("  " + Tbj17Content.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj17Content.CTRTKBN + " ");
            sql.append(" = '" + _vo.getCTRTKBN() + "' ");
            sql.append(" AND " + Tbj17Content.CTRTNO + " ");
            sql.append(" = '" + _vo.getCTRTNO() + "' ");
            sql.append(" ) ");

            /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
            sql.append(" UNION ALL");

            sql.append(" SELECT");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + ",");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + ",");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj16ContractInfo.NAMES + ",");
            sql.append(" " + Tbj16ContractInfo.DATEFROM + ",");
            sql.append(" " + Tbj16ContractInfo.DATETO + ",");
            sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "'");    //仮素材

            sql.append(" FROM");
            sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
            sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " = " + Tbj36TempSozaiKanriData.TEMPCMCD + " AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = " + Tbj16ContractInfo.CTRTKBN + " AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " = " + Tbj16ContractInfo.CTRTNO + " AND");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " IN (");
            sql.append(" SELECT");
            sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD);
            sql.append(" FROM");
            sql.append(" " + Tbj40TempSozaiContent.TBNAME);
            sql.append(" WHERE");
            sql.append(" " + Tbj40TempSozaiContent.CTRTKBN + " = '" + _vo.getCTRTKBN() + "' AND");
            sql.append(" " + Tbj40TempSozaiContent.CTRTNO + " = '" + _vo.getCTRTNO() + "'");
            sql.append(" )");

            sql.append(" ORDER BY ");
            sql.append("  " + Tbj17Content.CMCD + " ");
            /* 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */
        }

//        //素材登録10桁CMコードに紐づく契約情報取得SQL
//        else if (_SelSqlMode.equals(SelSqlMode.ContractInfo)) {
//
//            sql.append(" SELECT ");
//            sql.append("  " + Tbj16ContractInfo.DATEFROM + " ");
//            sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
//            sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
//            sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
//            sql.append(" FROM ");
//            sql.append("  " + Tbj17Content.TBNAME + " ");
//            sql.append(" ," + Tbj16ContractInfo.TBNAME + " ");
//            sql.append(" WHERE ");
//            sql.append("  " + Tbj17Content.CMCD + " ");
//            sql.append(" = '" + _cond3.getStrCmCd() + "' ");
//            sql.append(" AND " + Tbj16ContractInfo.DELFLG + " ");
//            sql.append(" != '" + DeleteYes + "' ");
//            sql.append(" AND " + Tbj17Content.CTRTKBN + " ");
//            sql.append(" = " + Tbj16ContractInfo.CTRTKBN + " ");
//            sql.append(" AND " + Tbj17Content.CTRTNO + " ");
//            sql.append(" = " + Tbj16ContractInfo.CTRTNO + " ");
//            sql.append(" ORDER BY ");
//            sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
//            sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
//            sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
//            sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
//        }

        //契約コードMAX値取得SQL
        else if (_SelSqlMode.equals(SelSqlMode.CTRTNO)) {

            sql.append(" SELECT ");
            sql.append(" MAX(" + Tbj16ContractInfo.CTRTNO + ") ");
            sql.append(" AS " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" FROM ");
            sql.append(" " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" = '" + _vo.getCTRTKBN() + "' ");
            sql.append(" AND ");
            sql.append(" SUBSTR(" + Tbj16ContractInfo.CTRTNO + ",1,4) ");
            sql.append(" = " + "(TO_CHAR (SYSDATE, 'YYMM'))" + " ");
        }

        //契約情報変更ログ取得SQL
        else if (_SelSqlMode.equals(SelSqlMode.History)) {

            sql.append(" SELECT ");
            sql.append("     " + Mbj12Code.CODENAME + " AS HISTORYNM "); //作業区分
            sql.append("    ,(");
            sql.append("         SELECT ");
            sql.append("             " + Mbj12Code.CODENAME);
            sql.append("         FROM ");
            sql.append("             " + Mbj12Code.TBNAME);
            sql.append("         WHERE ");
            sql.append("             " + Mbj12Code.CODETYPE + " = '" + CODETYPE_CONTRACTINFO + "' ");
            sql.append("         AND ");
            sql.append("             " + Mbj12Code.KEYCODE + " = " + Tbj24LogContractInfo.CTRTKBN + " ");
            sql.append("     ) CTRTKBNNAM"); //契約種類
            sql.append("    ,    '0' as ROWST "); //行ステータス
            sql.append("    ,    '0' as COLST "); //列ステータス
            sql.append("    ," + Tbj24LogContractInfo.CTRTNO + " "); //契約コード
            sql.append("    ," + Tbj24LogContractInfo.CTRTKBN + " "); //旧契約種類
            sql.append("    ,(");
            sql.append("         SELECT ");
            sql.append("             " + Mbj05Car.CARNM);
            sql.append("         FROM ");
            sql.append("             " + Mbj05Car.TBNAME);
            sql.append("         WHERE ");
            sql.append("             " + Mbj05Car.DCARCD + "(+) = " + Tbj24LogContractInfo.DCARCD);
            sql.append("     ) SHASHU"); //車種
            sql.append("    ," + Tbj24LogContractInfo.CATEGORY + " "); //カテゴリ
            sql.append("    ," + Tbj24LogContractInfo.MUSIC + " "); //曲名
            sql.append("    ," + Tbj24LogContractInfo.NAMES + " "); //人名、アーティスト
            sql.append("    ," + Tbj24LogContractInfo.DATEFROM + " "); //期間(From)
            sql.append("    ," + Tbj24LogContractInfo.DATETO + " "); //期間(To)
            sql.append("    ," + Tbj24LogContractInfo.JASRACFLG + " "); //JASRAC登録
            sql.append("    ," + Tbj24LogContractInfo.SALEFLG + " "); //CD発売
            /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
            sql.append("    ," + Tbj24LogContractInfo.ENDTITLEFLG + " "); //ぶら下がり
            sql.append("    ," + Tbj24LogContractInfo.ARRGORGFLG + " "); //アレンジ・オリジナル
            /* 2016/02/24 HDX対応 HLC K.Oki ADD End */

            sql.append("    ," + Tbj24LogContractInfo.BIKO + " "); //備考
            sql.append("    ," + Tbj24LogContractInfo.CRTNM + " "); //登録者
            sql.append("    ," + Tbj24LogContractInfo.CRTAPL + " "); //登録プログラム
            sql.append("    ," + Tbj24LogContractInfo.CRTID + " "); //登録者ID
            sql.append("    ," + Tbj24LogContractInfo.CRTDATE + " "); //登録日時
            sql.append("    ," + Tbj24LogContractInfo.UPDNM + " "); //更新者
            sql.append("    ," + Tbj24LogContractInfo.UPDDATE + " "); //更新日時

            sql.append(" FROM ");
            sql.append("     " + Tbj24LogContractInfo.TBNAME + " ");
            sql.append("    ," + Mbj12Code.TBNAME + " ");

            sql.append(" WHERE ");
            sql.append("     " + Tbj24LogContractInfo.HISTORYKEY + " = " + ConvertToDBString(_condLogContractInfo.getHistorykey()));
            sql.append(" AND " + Mbj12Code.CODETYPE + " = '33' ");
            sql.append(" AND " + Mbj12Code.KEYCODE + " = " + Tbj24LogContractInfo.HISTORYKBN + " ");
            sql.append(" ORDER BY ");
            sql.append("     " + Tbj24LogContractInfo.HISTORYNO + " ");

        } else if (_SelSqlMode.equals(SelSqlMode.SearchM)) {

            //本素材
            sql.append(" SELECT ");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj18SozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj18SozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj18SozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj18SozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj18SozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj18SozaiKanriData.UPDID + ",");
            sql.append(" " + Mbj05Car.CARNM + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_ACTUAL + "' " + SozaiKanriDataVO.TEMPFLG);
            sql.append(" FROM ");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);
            sql.append(" WHERE ");
            sql.append(" " + Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD + " AND");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "'");

            /* 2015/11/30 JASRAC対応 HLC S.Fujimoto ADD Start */
            sql.append(" UNION ALL");

            //仮素材
            sql.append(" SELECT");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.STATUS + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.NOHIN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.PRODUCT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATETO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.MLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.KLIMIT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATERECOG + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.DATEPRT + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.BIKO + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.CRTID + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDDATE + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDNM + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDAPL + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.UPDID + ",");
            sql.append(" " + Mbj05Car.CARNM + ",");
            sql.append(" '" + HAMConstants.MATERIAL_KBN_TEMP + "'");

            sql.append(" FROM");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Mbj05Car.DCARCD + " = " + Tbj36TempSozaiKanriData.DCARCD);
            /* 2015/11/30 JASRAC対応 HLC S.Fujimoto ADD End */

            sql.append(" ORDER BY ");
            sql.append(Tbj18SozaiKanriData.CRTDATE + ", ");
            sql.append(Tbj18SozaiKanriData.CMCD);

        } else if (_SelSqlMode.equals(SelSqlMode.Category)) {

            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD Start */
//            sql.append(" SELECT ");
//            sql.append("     " + Tbj18SozaiKanriData.CATEGORY + " ");
//            sql.append(" FROM ");
//            sql.append("     " + Tbj18SozaiKanriData.TBNAME + " ");
//            sql.append("    ," + Mbj05Car.TBNAME + " ");
//            sql.append(" WHERE ");
//            sql.append("     " + Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD);
//            sql.append(" AND " + Mbj05Car.DISPSTS + " = '1'");
//            sql.append(" GROUP BY ");
//            sql.append("     " + Tbj18SozaiKanriData.CATEGORY + " ");
//            sql.append(" ORDER BY ");
//            sql.append("     MIN(" + Tbj18SozaiKanriData.CRTDATE + ") ");
//            sql.append("    ,MIN(" + Tbj18SozaiKanriData.CMCD + ") ");

            sql.append(" SELECT");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY);

            sql.append(" FROM");
            sql.append(" (");

            //本素材
            sql.append(" SELECT");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
            sql.append(" MIN(" + Tbj18SozaiKanriData.CRTDATE + ") " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj18SozaiKanriData.CMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD  + " = " + Mbj05Car.DCARCD + "(+)");
            sql.append(" GROUP BY");
            sql.append(" " + Tbj18SozaiKanriData.CATEGORY);

            sql.append(" UNION ALL");

            //仮素材
            sql.append(" SELECT");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CRTDATE + ") " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.TEMPCMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" GROUP BY");
            sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY);

            sql.append(" )");

            sql.append(" ORDER BY");
            sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" " + Tbj18SozaiKanriData.CMCD);
            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD End */

        } else if (_SelSqlMode.equals(SelSqlMode.Second)) {

            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD Start */
//            sql.append(" SELECT ");
//            sql.append("     " + Tbj18SozaiKanriData.NOKBN + " ");
//            sql.append("    ," + Tbj18SozaiKanriData.SECOND + " ");
//            sql.append(" FROM ");
//            sql.append("     " + Tbj18SozaiKanriData.TBNAME + " ");
//            sql.append("    ," + Mbj05Car.TBNAME + " ");
//            sql.append(" WHERE ");
//            sql.append("     " + Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD);
//            sql.append(" AND " + Mbj05Car.DISPSTS + " = '1'");
//            sql.append(" GROUP BY ");
//            sql.append("     " + Tbj18SozaiKanriData.NOKBN + " ");
//            sql.append("    ," + Tbj18SozaiKanriData.SECOND + " ");
//            sql.append(" ORDER BY ");
//            sql.append("     MIN(" + Tbj18SozaiKanriData.CRTDATE + ") ");
//            sql.append("    ,MIN(" + Tbj18SozaiKanriData.CMCD + ") ");

            sql.append(" SELECT");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND);

            sql.append(" FROM");
            sql.append(" (");

            sql.append(" SELECT");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + " " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND + " " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" MIN(" + Tbj18SozaiKanriData.CRTDATE + ") " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj18SozaiKanriData.CMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Tbj18SozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" GROUP BY");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND);

            sql.append(" UNION ALL");

            sql.append(" SELECT");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + " " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND + " " + Tbj18SozaiKanriData.SECOND + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CRTDATE + ")  " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
            sql.append(" " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "' AND");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + "(+)");

            sql.append(" GROUP BY");
            sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj36TempSozaiKanriData.SECOND);

            sql.append(" )");

            sql.append(" ORDER BY");
            sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
            sql.append(" " + Tbj18SozaiKanriData.SECOND);
            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD End */

        } else if (_SelSqlMode.equals(SelSqlMode.Syatan)) {

            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD Start */
//            sql.append(" SELECT ");
//            sql.append("     " + Tbj18SozaiKanriData.SYATAN + " ");
//            sql.append(" FROM ");
//            sql.append("     " + Tbj18SozaiKanriData.TBNAME + " ");
//            sql.append("    ," + Mbj05Car.TBNAME + " ");
//            sql.append(" WHERE ");
//            sql.append("     " + Mbj05Car.DCARCD + " = " + Tbj18SozaiKanriData.DCARCD);
//            sql.append(" AND " + Mbj05Car.DISPSTS + " = '1'");
//            sql.append(" GROUP BY ");
//            sql.append("     " + Tbj18SozaiKanriData.SYATAN + " ");
//            sql.append(" ORDER BY ");
//            sql.append("     MIN(" + Tbj18SozaiKanriData.CRTDATE + ") ");
//            sql.append("    ,MIN(" + Tbj18SozaiKanriData.CMCD + ") ");

            sql.append(" SELECT");
            sql.append("  " + Tbj18SozaiKanriData.SYATAN);

            sql.append(" FROM");
            sql.append(" (");

            sql.append(" SELECT");
            sql.append("  " + Tbj18SozaiKanriData.SYATAN + "  " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" MIN( " + Tbj18SozaiKanriData.CRTDATE + ")  " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN( " + Tbj18SozaiKanriData.CMCD + ")  " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append("  " + Tbj18SozaiKanriData.TBNAME + ",");
            sql.append("  " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append("  " + Tbj18SozaiKanriData.DCARCD + " = MBJ05_DCARCD(+) AND");
            sql.append("  " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "'");

            sql.append(" GROUP BY");
            sql.append("  " + Tbj18SozaiKanriData.SYATAN);

            sql.append(" UNION ALL");

            sql.append(" SELECT");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + " " + Tbj18SozaiKanriData.SYATAN + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CRTDATE + ") " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append(" MIN(" + Tbj36TempSozaiKanriData.CMCD + ") " + Tbj18SozaiKanriData.CMCD);

            sql.append(" FROM");
            sql.append("  " + Tbj36TempSozaiKanriData.TBNAME + ",");
            sql.append("  " + Mbj05Car.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
            sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + " = MBJ05_DCARCD(+) AND");
            sql.append("  " + Mbj05Car.DISPSTS + " = '" + HAMConstants.CAR_DISP_VISIBLE + "'");

            sql.append(" GROUP BY");
            sql.append(" " + Tbj36TempSozaiKanriData.SYATAN);

            sql.append(" )");

            sql.append(" ORDER BY");
            sql.append("  " + Tbj18SozaiKanriData.CRTDATE + ",");
            sql.append("  " + Tbj18SozaiKanriData.CMCD);
            /* 2015/11/27 JASRAC対応 HLC S.Fujimoto MOD End */
        }

        return sql.toString();
    }


    /**
     * 使用素材表示用(タレント・ナレーター)データの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindUseMaterialVO> findUseMaterialTalentListByCondition() throws HAMException {
        super.setModel(new FindUseMaterialVO());
        try {
            _SelSqlMode = SelSqlMode.TALENT;
            return (List<FindUseMaterialVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 使用素材表示用(楽曲)データの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<FindUseMaterialVO> findUseMaterialMusicListByCondition() throws HAMException {
        super.setModel(new FindUseMaterialVO());
        try {
            _SelSqlMode = SelSqlMode.MUSIC;
            return (List<FindUseMaterialVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * コンテンツデータのカウントを行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<ContractDeleteCVO> countContentListByCondition(ContractDeleteCondition cond) throws HAMException {
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new ContractDeleteCVO());
        try {
            _SelSqlMode = SelSqlMode.CountC;
            _cond2 = cond;
            return (List<ContractDeleteCVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * JASRACデータのカウントを行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<ContractDeleteJVO> countJasracListByCondition(ContractDeleteCondition cond) throws HAMException {
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new ContractDeleteJVO());
        try {
            _SelSqlMode = SelSqlMode.CountJ;
            _cond2 = cond;
            return (List<ContractDeleteJVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * TIMESTAMP項目値を取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public Date findTimeStamp(GetContractInfoListCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.TimeStamp;
            _cond4 = cond;
            List<Tbj16ContractInfoVO> _tbj16ContractInfoVO = (List<Tbj16ContractInfoVO>) super.find();
            Date strUPDDATE = _tbj16ContractInfoVO.size() <= 0 ? null : _tbj16ContractInfoVO.get(0).getUPDDATE();
            return strUPDDATE;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 契約コードのMAX値の検索を行います
     *
     * @return 契約コードのMAX値
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public String searchCtrtNoByCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new Tbj16ContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.CTRTNO;
            _vo = vo;
            //List<AbstractModel> _tbj16ContractInfoVO = (List<AbstractModel>) super.find();
            List<Tbj16ContractInfoVO> _tbj16ContractInfoVO = (List<Tbj16ContractInfoVO>) super.find();
            String strCtrtNo = _tbj16ContractInfoVO.get(0).getCTRTNO();
            if (strCtrtNo.length() == 0) {
                Calendar calendar = Calendar.getInstance();
                Date nowTime = calendar.getTime();
                strCtrtNo = DateUtil.toStringGeneral(nowTime, "yyMM") + "001";
            } else {
                //発行前の番号（登録済み番号）が999野場合、エラー
                if (Integer.valueOf(strCtrtNo.substring(strCtrtNo.length() - 3)) >= 999)
                    throw new HAMException("自動採番桁あふれ", "BJ-E0001");

                int intCtrtNo = Integer.parseInt(strCtrtNo) + 1;
                strCtrtNo = Integer.toString(intCtrtNo);

            }
            return strCtrtNo;
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * コンテンツテーブル、素材登録テーブルの読込を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<GetContentMaterialVO> getContentMaterialCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new GetContentMaterialVO());
        try {
            _SelSqlMode = SelSqlMode.CmCd;
            _vo = vo;
            return (List<GetContentMaterialVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

//    /**
//     * 素材登録の10桁CMコードに紐づく契約情報の取得を行います
//     *
//     * @return 汎用テーブルマスタVOリスト
//     * @throws UserException データアクセス中にエラーが発生した場合
//     */
//    @SuppressWarnings("unchecked")
//    public List<ContractContentVO> getContractContentCondition(UpdateContractInfoCondition cond) throws HAMException {
//        if (cond == null) {
//            throw new HAMException("検索エラー", "BJ-E0001");
//        }
//        super.setModel(new ContractContentVO());
//        try {
//            _SelSqlMode = SelSqlMode.ContractInfo;
//            _cond3 = cond;
//            return (List<ContractContentVO>) super.find();
//        } catch (UserException e) {
//            throw new HAMException(e.getMessage(), "BJ-E0001");
//        }
//    }

    //    /**
    //     * 契約情報テーブルの検索を行います
    //     *
    //     * @return 汎用テーブルマスタVOリスト
    //     * @throws UserException データアクセス中にエラーが発生した場合
    //     */
    //    @SuppressWarnings("unchecked")
    //    public List<Tbj16ContractInfoVO> findContractByCondition(GetContractInfoListCondition cond) throws HAMException {
    //        if (cond == null) {
    //            throw new HAMException("検索エラー", "BJ-E0001");
    //        }
    //        super.setModel(new Tbj16ContractInfoVO());
    //        try {
    //            if (cond.getStrCtrtKbn().equals(CTRTKBN_MUSIC)) {
    //                _SelSqlMode = SelSqlMode.ContractMusic;
    //            }
    //            else
    //            {
    //                _SelSqlMode = SelSqlMode.ContractTalent;
    //            }
    //            _cond4 = cond;
    //            return (List<Tbj16ContractInfoVO>) super.find();
    //        } catch (UserException e) {
    //            throw new HAMException(e.getMessage(), "BJ-E0001");
    //        }
    //    }

    /**
     * 履歴画面に表示するタレント・ナレーター・その他データを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<FindLogContractInfoVO> findLogContractInfo(FindLogContractInfoCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new FindLogContractInfoVO());
        try {
            _SelSqlMode = SelSqlMode.History;
            _condLogContractInfo = cond;
            return (List<FindLogContractInfoVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材検索画面に表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<SozaiKanriDataVO> findSozaiKanriData(MaterialSearchCondition cond) throws HAMException {
        //パラメータチェック
        if (cond == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }
        super.setModel(new SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.SearchM;
            return (List<SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * カテゴリのリストに表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> getCategory() throws HAMException {
        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.Category;
            return (List<Tbj18SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 秒数のリストに表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> getSecond() throws HAMException {
        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.Second;
            return (List<Tbj18SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 車種担当のリストに表示するデータを取得します
     *
     * @param cond
     * @return
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<Tbj18SozaiKanriDataVO> getSyatan() throws HAMException {
        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.Syatan;
            return (List<Tbj18SozaiKanriDataVO>) super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * Modelの生成を行う<br>
     * 検索結果のVOのKEYが大文字のため変換処理を行う<br>
     * AbstractRdbDaoのcreateFindedModelInstancesをオーバーライド<br>
     *
     * @param hashList List 検索結果
     * @return List<CommonCodeMasterVO> 変換後の検索結果
     */
    @Override
    @SuppressWarnings("unchecked")
    protected List createFindedModelInstances(List hashList) {
        List list = null;
        if (getModel() instanceof ContractDeleteCVO) {
            list = new ArrayList<ContractDeleteCVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                ContractDeleteCVO vo = new ContractDeleteCVO();
                vo.setCOUNT(((BigDecimal)result.get("COUNT")).intValue());

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if (getModel() instanceof ContractDeleteJVO) {
            list = new ArrayList<ContractDeleteJVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                ContractDeleteJVO vo = new ContractDeleteJVO();
                vo.setCOUNT(((BigDecimal)result.get("COUNT")).intValue());

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else {
            list = super.createFindedModelInstances(hashList);
        }
        return list;
    }

    /**
     * EXEC-SQL生成
     */
    @Override
    public String getExecString() {
        StringBuffer sql = new StringBuffer();

        //契約情報テーブルの論理削除SQL
        if (_ExecSqlMode.equals(ExecSqlMode.DeleteC)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" SET ");
            sql.append("  " + Tbj16ContractInfo.DELFLG + " ");
            sql.append(" = '" + DeleteYes + "' ");
            sql.append(" ," + Tbj16ContractInfo.UPDDATE + " ");
            sql.append(" = " + "SYSDATE" + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDNM + " ");
            sql.append(" = '" + _vo.getUPDNM() + "' ");
            sql.append(" ," + Tbj16ContractInfo.UPDAPL + " ");
            sql.append(" = '" + _vo.getUPDAPL() + "' ");
            sql.append(" ," + Tbj16ContractInfo.UPDID + " ");
            sql.append(" = '" + _vo.getUPDID() + "' ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" = " + _vo.getCTRTKBN() + " ");
            sql.append(" AND " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" = '" + _vo.getCTRTNO() + "' ");
        }

        //JASRACテーブルの論理削除SQL
        else if (_ExecSqlMode.equals(ExecSqlMode.DeleteJ)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj19Jasrac.TBNAME + " ");
            sql.append(" SET ");
            sql.append("  " + Tbj19Jasrac.DELFLG + " ");
            sql.append(" = '" + DeleteYes + "' ");
            sql.append(" ," + Tbj19Jasrac.UPDDATE + " ");
            sql.append(" = " + "SYSDATE" + " ");
            sql.append(" ," + Tbj19Jasrac.UPDNM + " ");
            sql.append(" = '" + _vo.getUPDNM() + "' ");
            sql.append(" ," + Tbj19Jasrac.UPDAPL + " ");
            sql.append(" = '" + _vo.getUPDAPL() + "' ");
            sql.append(" ," + Tbj19Jasrac.UPDID + " ");
            sql.append(" = '" + _vo.getUPDID() + "' ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj19Jasrac.CTRTKBN + " ");
            sql.append(" = " + _vo.getCTRTKBN() + " ");
            sql.append(" AND " + Tbj19Jasrac.CTRTNO + " ");
            sql.append(" = '" + _vo.getCTRTNO() + "' ");
        }

        //契約情報テーブルのUpdateSQL(契約コードに変更がない場合)
        else if (_ExecSqlMode.equals(ExecSqlMode.UpdateC)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj16ContractInfo.TBNAME + " ");
            sql.append(" SET ");
            sql.append(" " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTKBN()) + " ");
            sql.append(" ," + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTNONEW()) + " ");
            sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
            sql.append(" = " + ConvertToDBString(_vo.getNAMES()) + " ");
            sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
            sql.append(" = " + ConvertToDBString(_vo.getDATEFROM()) + " ");
            sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getDATETO()) + " ");
            sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
            sql.append(" = " + ConvertToDBString(_vo.getMUSIC()) + " ");
            sql.append(" ," + Tbj16ContractInfo.SALEFLG + " ");
            sql.append(" = " + ConvertToDBString(_vo.getSALEFLG()) + " ");
            /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
            if(_vo.getENDTITLEFLG() != null){
                sql.append(" ," + Tbj16ContractInfo.ENDTITLEFLG+ " ");
                sql.append(" = " + ConvertToDBString(_vo.getENDTITLEFLG()) + " ");
            }
            if(_vo.getARRGORGFLG() != null){
                sql.append(" ," + Tbj16ContractInfo.ARRGORGFLG+ " ");
                sql.append(" = " + ConvertToDBString(_vo.getARRGORGFLG()) + " ");
            }
            /* 2016/02/24 HDX対応 HLC K.Oki ADD End */
            sql.append(" ," + Tbj16ContractInfo.BIKO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getBIKO()) + " ");
            sql.append(" ," + Tbj16ContractInfo.HISTORYKEY + " ");
            sql.append(" = " + ConvertToDBString(_vo.getHISTORYKEY()) + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDDATE + " ");
            sql.append(" = " + "SYSDATE" + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDNM + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDNM()) + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDAPL + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDAPL()) + " ");
            sql.append(" ," + Tbj16ContractInfo.UPDID + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDID()) + " ");
            sql.append(" ," + Tbj16ContractInfo.DCARCD + " ");
            sql.append(" = " + ConvertToDBString(_vo.getDCARCD()) + " ");
            sql.append(" ," + Tbj16ContractInfo.CATEGORY + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCATEGORY()) + " ");
            sql.append(" ," + Tbj16ContractInfo.JASRACFLG + " ");
            sql.append(" = " + ConvertToDBString(_vo.getJASRACFLG()) + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj16ContractInfo.CTRTKBN + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTKBNOLD()) + " "); //契約種類(旧)
            sql.append(" AND ");
            sql.append("  " + Tbj16ContractInfo.CTRTNO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTNO()) + " ");
        }

        //コンテンツテーブルのUpdateSQL(契約コードに変更がある場合)
        else if (_ExecSqlMode.equals(ExecSqlMode.UpdateContent)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj17Content.TBNAME + " ");
            sql.append(" SET ");
            sql.append(" " + Tbj17Content.CTRTKBN + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTKBN()) + " ");
            sql.append(" ," + Tbj17Content.CTRTNO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTNONEW()) + " "); //契約コード(自動採番されたもの)
            sql.append(" ," + Tbj17Content.UPDDATE + " ");
            sql.append(" = " + "SYSDATE" + " ");
            sql.append(" ," + Tbj17Content.UPDNM + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDNM()) + " ");
            sql.append(" ," + Tbj17Content.UPDAPL + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDAPL()) + " ");
            sql.append(" ," + Tbj17Content.UPDID + " ");
            sql.append(" = " + ConvertToDBString(_vo.getUPDID()) + " ");
            sql.append(" WHERE ");
            sql.append("  " + Tbj17Content.CTRTKBN + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTKBNOLD()) + " "); //契約種類(旧)
            sql.append(" AND ");
            sql.append("  " + Tbj17Content.CTRTNO + " ");
            sql.append(" = " + ConvertToDBString(_vo.getCTRTNO()) + " ");
        }

        //素材登録テーブルのUpdateSQL(契約期間更新時)
        else if (_ExecSqlMode.equals(ExecSqlMode.UpdateKLIMIT)) {

            sql.append(" UPDATE ");
            sql.append("  " + Tbj18SozaiKanriData.TBNAME + " ");
            sql.append(" SET ");
            sql.append("  " + Tbj18SozaiKanriData.KLIMIT + " = " + ConvertToDBString(_vo2.getKLIMIT()) + " "); //権利使用期限
            sql.append(" ," + Tbj18SozaiKanriData.UPDDATE + " = " + "SYSDATE" + " "); //データ更新日時
            sql.append(" ," + Tbj18SozaiKanriData.UPDNM + " = " + ConvertToDBString(_vo2.getUPDNM()) + " "); //データ更新者
            sql.append(" ," + Tbj18SozaiKanriData.UPDAPL + " = " + ConvertToDBString(_vo2.getUPDAPL()) + " "); //更新プログラム
            sql.append(" ," + Tbj18SozaiKanriData.UPDID + " = " + ConvertToDBString(_vo2.getUPDID()) + " "); //更新担当者ID
            sql.append(" WHERE ");
            sql.append("  " + Tbj18SozaiKanriData.CMCD + " = " + " ");
            sql.append("    ( ");
            sql.append("    SELECT ");
            sql.append("     " + Tbj17Content.CMCD + " ");
            sql.append("    FROM ");
            sql.append("     " + Tbj17Content.TBNAME + " ");
            sql.append("    WHERE ");
            sql.append("     " + Tbj17Content.CTRTKBN + " = " + ConvertToDBString(_vo2.getCTRTKBN()) + " ");
            sql.append("    AND ");
            sql.append("     " + Tbj17Content.CTRTNO + " = " + ConvertToDBString(_vo2.getCTRTNO()) + " ");
            sql.append("    ) ");
        }

        //契約情報テーブルのInsertSQL
        else if (_ExecSqlMode.equals(ExecSqlMode.InsertHistory)) {

            Tbj24LogContractInfoVO vo = (Tbj24LogContractInfoVO) getModel();

            sql.append(" INSERT INTO ");
            sql.append("    " + Tbj24LogContractInfo.TBNAME + " ");
            sql.append(" ( ");
            sql.append("     " + Tbj24LogContractInfo.CTRTKBN);
            sql.append("    ," + Tbj24LogContractInfo.CTRTNO);
            sql.append("    ," + Tbj24LogContractInfo.HISTORYKEY);
            sql.append("    ," + Tbj24LogContractInfo.HISTORYNO);
            sql.append("    ," + Tbj24LogContractInfo.HISTORYKBN);
            sql.append("    ," + Tbj24LogContractInfo.DCARCD);
            sql.append("    ," + Tbj24LogContractInfo.CATEGORY);
            sql.append("    ," + Tbj24LogContractInfo.DELFLG);
            sql.append("    ," + Tbj24LogContractInfo.NAMES);
            sql.append("    ," + Tbj24LogContractInfo.DATEFROM);
            sql.append("    ," + Tbj24LogContractInfo.DATETO);
            sql.append("    ," + Tbj24LogContractInfo.MUSIC);
            sql.append("    ," + Tbj24LogContractInfo.JASRACFLG);
            sql.append("    ," + Tbj24LogContractInfo.SALEFLG);
            /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
            sql.append("    ," + Tbj24LogContractInfo.ENDTITLEFLG);
            sql.append("    ," + Tbj24LogContractInfo.ARRGORGFLG);
            /* 2016/02/24 HDX対応 HLC K.Oki ADD End */
            sql.append("    ," + Tbj24LogContractInfo.BIKO);
            sql.append("    ," + Tbj24LogContractInfo.CRTDATE);
            sql.append("    ," + Tbj24LogContractInfo.CRTNM);
            sql.append("    ," + Tbj24LogContractInfo.CRTAPL);
            sql.append("    ," + Tbj24LogContractInfo.CRTID);
            sql.append("    ," + Tbj24LogContractInfo.UPDDATE);
            sql.append("    ," + Tbj24LogContractInfo.UPDNM);
            sql.append("    ," + Tbj24LogContractInfo.UPDAPL);
            sql.append("    ," + Tbj24LogContractInfo.UPDID);
            sql.append(" ) ");
            sql.append(" SELECT ");
            sql.append("     " + Tbj16ContractInfo.CTRTKBN);
            sql.append("    ," + Tbj16ContractInfo.CTRTNO);
            sql.append("    ," + Tbj16ContractInfo.HISTORYKEY);
            sql.append("    ,(");
            sql.append("         SELECT ");
            sql.append("             NVL(MAX(" + Tbj24LogContractInfo.HISTORYNO + "), 0) + 1");
            sql.append("         FROM ");
            sql.append("             " + Tbj24LogContractInfo.TBNAME);
            sql.append("         WHERE ");
            sql.append("             " + Tbj24LogContractInfo.HISTORYKEY + " = " + Tbj16ContractInfo.HISTORYKEY);
            sql.append("     )");
            sql.append("    ," + ConvertToDBString(vo.getHISTORYKBN()) + "");
            sql.append("    ," + Tbj16ContractInfo.DCARCD);
            sql.append("    ," + Tbj16ContractInfo.CATEGORY);
            sql.append("    ," + Tbj16ContractInfo.DELFLG);
            sql.append("    ," + Tbj16ContractInfo.NAMES);
            sql.append("    ," + Tbj16ContractInfo.DATEFROM);
            sql.append("    ," + Tbj16ContractInfo.DATETO);
            sql.append("    ," + Tbj16ContractInfo.MUSIC);
            sql.append("    ," + Tbj16ContractInfo.JASRACFLG);
            sql.append("    ," + Tbj16ContractInfo.SALEFLG);
            /* 2016/02/24 HDX対応 HLC K.Oki ADD Start */
            sql.append("    ," + Tbj16ContractInfo.ENDTITLEFLG);
            sql.append("    ," + Tbj16ContractInfo.ARRGORGFLG);
            /* 2016/02/24 HDX対応 HLC K.Oki ADD End */
            sql.append("    ," + Tbj16ContractInfo.BIKO);
            sql.append("    ," + Tbj16ContractInfo.CRTDATE);
            sql.append("    ," + Tbj16ContractInfo.CRTNM);
            sql.append("    ," + Tbj16ContractInfo.CRTAPL);
            sql.append("    ," + Tbj16ContractInfo.CRTID);
            sql.append("    ," + Tbj16ContractInfo.UPDDATE);
            sql.append("    ," + Tbj16ContractInfo.UPDNM);
            sql.append("    ," + Tbj16ContractInfo.UPDAPL);
            sql.append("    ," + Tbj16ContractInfo.UPDID);

            sql.append(" FROM ");
            sql.append("     " + Tbj16ContractInfo.TBNAME);
            sql.append(" WHERE ");
            sql.append("     " + Tbj16ContractInfo.CTRTKBN + " = " + ConvertToDBString(vo.getCTRTKBN()));
            sql.append(" AND " + Tbj16ContractInfo.CTRTNO + " = " + ConvertToDBString(vo.getCTRTNO()));
        }

        return sql.toString();
    }

    /**
     * 契約情報テーブルの論理削除を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    public void deleteContractInfoCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        try {
            _ExecSqlMode = ExecSqlMode.DeleteC;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * JASRACテーブルの論理削除を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    public void deleteJasracCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("削除エラー", "BJ-E0004");
        }
        try {
            _ExecSqlMode = ExecSqlMode.DeleteJ;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * 契約情報テーブルのUpdate(契約種類変更なし)を行いますUpdateCtrtC
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    public void updateContractInfoCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        try {
            _ExecSqlMode = ExecSqlMode.UpdateC;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * コンテンツテーブル(契約種類変更時)のUpdateを行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    public void updateContentCondition(Tbj16ContractInfoUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        try {
            _ExecSqlMode = ExecSqlMode.UpdateContent;
            _vo = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * 権利使用期限(契約情報登録時)のUpdateを行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    public void updateKenriLimit(Tbj18SozaiKanriDataUpdateVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }
        try {
            _ExecSqlMode = ExecSqlMode.UpdateKLIMIT;
            _vo2 = vo;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * 契約情報変更ログ（履歴）のInsertを行います
     *
     * @return テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    public void insertHistoryForContractInfo(Tbj24LogContractInfoVO vo) throws HAMException {
        if (vo == null) {
            throw new HAMException("登録エラー", "BJ-E0002");
        }
        super.setModel(vo);
        try {
            _ExecSqlMode = ExecSqlMode.InsertHistory;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    private String ConvertToDBString(Object obj) {
        if (obj == null) {
            return null;
        }
        return super.getDBModelInterface().ConvertToDBString(obj);
    }

}
