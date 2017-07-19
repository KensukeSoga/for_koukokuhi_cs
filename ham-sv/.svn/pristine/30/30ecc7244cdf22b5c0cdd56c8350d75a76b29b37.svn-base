package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj20CarCategoryVO;
import jp.co.isid.ham.common.model.Mbj38CarConvertVO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj20CarCategory;
import jp.co.isid.ham.integ.tbl.Mbj22CategoryContent;
import jp.co.isid.ham.integ.tbl.Mbj38CarConvert;
import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_TransactionSecurity;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj26LogSozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj40TempSozaiContent;
import jp.co.isid.ham.integ.tbl.Tbj42SozaiKanriListCmn;
import jp.co.isid.ham.integ.tbl.Tbj43SozaiKanriListCmnOA;
import jp.co.isid.ham.integ.tbl.Tbj44LogSozaiKanriListCmn;
import jp.co.isid.ham.integ.tbl.Tbj45LogSozaiKanriListCmnOA;
import jp.co.isid.ham.integ.util.HAMPoolConnect;
import jp.co.isid.ham.model.HAMOracleModel;
import jp.co.isid.ham.model.base.HAMException;
import jp.co.isid.ham.util.DateUtil;
import jp.co.isid.ham.util.StringUtil;
import jp.co.isid.ham.util.constants.HAMConstants;
import jp.co.isid.nj.exp.UserException;
import jp.co.isid.nj.integ.sql.AbstractRdbDao;
import jp.co.isid.nj.model.ModelUtils;
/**
*
* <P>
* 素材一覧DAO<P>
* <B>修正履歴</B><BR>
* ・新規作成 HAMメンバー<BR>
* ・JASRAC対応(2015/11/19 HLC K.Soga)<BR>
* ・HDX対応(2016/02/18 HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialListDAO extends AbstractRdbDao {

    /** 検索用条件 */
    private MaterialListCondition _cond = null;

    /** 更新用VO(Tbj20) */
    private RegisterMaterialListUpdateVO _mateListVo = null;

    /** 選択SQLモード変数 */
    private SelSqlMode _SelSqlMode = null;

    /** トランザクションSQLモード変数 */
    private ExcSqlMode _ExcSqlMode = null;

    /** SELECT-SQLモード */
    private enum SelSqlMode {
        ContentCntrct,
        MaterialList,
        MaterialRegist,
        CategoryMst,
        CarMst,
        MaterialListPk,
        MaterialSozaiYm,
        LogMaterialList,
        /** 2016/02/29 HDX対応 HLC K.Soga ADD Start */
        SecGrpUser
        /** 2016/02/29 HDX対応 HLC K.Soga ADD End */
    };

    /** EXEC-SQLモード */
    private enum ExcSqlMode {
        RegistMaterialList,
        UpdateMaterialList,
        DeletePhaseMatterialList,
        MergeMaterialList,
        InsertMaterialListLog,
        /** 2016/02/26 HDX対応 HLC K.Soga ADD Start */
        InsertMaterialListCmnLog,
        InsertMaterialListCmnOALog,
        /** 2016/02/26 HDX対応 HLC K.Soga ADD End */
        InsertCarConvert
    };

    /** デフォルトコンストラクタ */
    public MaterialListDAO() {
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
     *
     * @return String SQL文
     */
    @Override
    public String getSelectSQL() {

        String sql = "";

        if (_SelSqlMode.equals(SelSqlMode.ContentCntrct)) {
            sql = getSelectSQLForContentCntrct();
        } else if (_SelSqlMode.equals(SelSqlMode.MaterialList)) {
            sql = getSelectSQLForMaterialList();
        } else if (_SelSqlMode.equals(SelSqlMode.MaterialRegist)) {
            sql = getSelectSQLForMaterialRegistList();
        } else if (_SelSqlMode.equals(SelSqlMode.CategoryMst)) {
            sql = getSelectSQLForCategoryMst();
        } else if (_SelSqlMode.equals(SelSqlMode.CarMst)) {
            sql = getSelectSQLForMaterialCarMst();
        } else if (_SelSqlMode.equals(SelSqlMode.MaterialListPk)) {
            sql = getSelectSQLForMaterialListByPrimaryKey();
        } else if (_SelSqlMode.equals(SelSqlMode.MaterialSozaiYm)) {
            sql = getSelectSQLForMaterialListBySozaiYm();
        } else if (_SelSqlMode.equals(SelSqlMode.LogMaterialList)) {
            sql = getSelectSQLForLogMaterialList();
        /** 2016/02/29 HDX対応 HLC K.Soga ADD Start */
        } else if (_SelSqlMode.equals(SelSqlMode.SecGrpUser)) {
            sql = getSelectSQLFindSecGrpUser();
        }
        /** 2016/02/29 HDX対応 HLC K.Soga ADD End */

        return sql;
    }

    /**
     * EXEC-SQL文を返します
     */
    @Override
    public String getExecString() {

        String sql = "";

        if (_ExcSqlMode.equals(ExcSqlMode.DeletePhaseMatterialList)) {
            sql = getExecSQLForDeleteMaterialListBySpecificYM();
        } else if (_ExcSqlMode.equals(ExcSqlMode.RegistMaterialList)) {
            sql = getExecSQLForRegistMaterialList();
        } else if (_ExcSqlMode.equals(ExcSqlMode.UpdateMaterialList)) {
            sql = getExecSQLForUpdateMaterialList();
        } else if (_ExcSqlMode.equals(ExcSqlMode.MergeMaterialList)) {
            sql = getExecSQLForUpdateMaterialFromRegisterToList();
        } else if (_ExcSqlMode.equals(ExcSqlMode.InsertMaterialListLog)) {
            sql = getExecSQLForInsertMaterialListLog();
        } else if (_ExcSqlMode.equals(ExcSqlMode.InsertCarConvert)) {
            sql = getExecSQLForInsertCarConvert();
        }

        return sql;
    }

    /**
     * 素材情報取得SQL
     * @return
     */
    private String getSelectSQLForMaterialList() {

        StringBuffer sql = new StringBuffer();

          /** 2015/10/14 JASRAC対応 HLC K.Soga MOD Start */
//        sql.append("SELECT ");
//        sql.append("  " + Tbj20SozaiKanriList.DCARCD + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.DCARCD + " AS  PREVDCARCD");
//        sql.append("  ,B." + Mbj20CarCategory.CATEGORYNO + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.SOZAIYM + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.RECKBN + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.RECNO + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.DELFLG + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.CMCD + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.TITLE + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.SECOND + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.RCODE + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.ESTIMATE + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.DATEFROM + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.DATETO + " ");
//        sql.append("  ,D.DATEFROM");
//        sql.append("  ,D.DATETO");
//        sql.append("  ," + Tbj20SozaiKanriList.NEWFLG + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.TIMEUSE + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.SPOTUSE + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.SPOTCTRT + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.SPOTSPAN + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.SPOTESTM + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.LIMIT + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.SYATAN + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.BIKO + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.CRTDATE + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.CRTNM + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.CRTAPL + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.CRTID + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.UPDDATE + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.UPDNM  + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.UPDAPL + " ");
//        sql.append("  ," + Tbj20SozaiKanriList.UPDID + " ");
//
//        sql.append(" FROM");
//        sql.append("  " + Tbj20SozaiKanriList.TBNAME + " ");
//        sql.append("  ," + Mbj05Car.TBNAME + " ");
//        sql.append("  ,(");
//        sql.append("     SELECT ");
//        sql.append("       " + Mbj22CategoryContent.DCARCD + " AS DCARCD ");
//        sql.append("      ," + Mbj20CarCategory.CATEGORYNO + " ");
//        sql.append("      ," + Mbj20CarCategory.SORTNO + " ");
//        sql.append("       FROM");
//        sql.append("       " + Mbj22CategoryContent.TBNAME + " ");
//        sql.append("      ," + Mbj20CarCategory.TBNAME + " ");
//        sql.append("      WHERE");
//        sql.append("       " + Mbj20CarCategory.CATEGORYNO + " = " + Mbj22CategoryContent.CATEGORYNO);
//        sql.append("        AND " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE);
//        sql.append("        AND " + Mbj22CategoryContent.PHASE + " = '" + _cond.getPhase() + "'");
//        sql.append("   ) B");
//        sql.append("  ,(");
//        sql.append("     SELECT ");
//        sql.append("          E." + Tbj17Content.CMCD + " AS CMCD");
//        sql.append("         ,E.DATEFROM ");
//        sql.append("         ,E.DATETO ");
//        sql.append("       FROM");
//        sql.append("           (");
//        sql.append("            SELECT");
//        sql.append("               " + Tbj17Content.CMCD + " ");
//        sql.append("              ,MIN(" + Tbj16ContractInfo.DATEFROM + ") AS DATEFROM ");
//        sql.append("              ,MIN(" + Tbj16ContractInfo.DATETO + ") AS DATETO ");
//        sql.append("              FROM ");
//        sql.append("                " + Tbj16ContractInfo.TBNAME + " ");
//        sql.append("               ," + Tbj17Content.TBNAME + " ");
//        sql.append("               ," + Tbj18SozaiKanriData.TBNAME + " ");
//        sql.append("             WHERE");
//        sql.append("                   " + Tbj16ContractInfo.DATEFROM + " IS NOT NULL");
//        sql.append("               AND " + Tbj16ContractInfo.CTRTKBN + " = " + Tbj17Content.CTRTKBN);
//        sql.append("               AND " + Tbj16ContractInfo.CTRTNO + " = " + Tbj17Content.CTRTNO);
//        sql.append("               AND " + Tbj17Content.CMCD + " = " + Tbj18SozaiKanriData.CMCD);
//        sql.append("             GROUP BY");
//        sql.append("               " + Tbj17Content.CMCD + " ");
//        sql.append("           ) E");
//        sql.append("   ) D");
//
//        sql.append(" WHERE");
//        sql.append("       " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD);
//        sql.append("   AND TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ",'YYYYMM') = '" + _cond.getYmDate() + "'");
//        sql.append("   AND " + Tbj20SozaiKanriList.DELFLG + " <> '" + _listDelFlg + "'");
//        sql.append("   AND B.DCARCD(+) = " + Tbj20SozaiKanriList.DCARCD);
//        sql.append("   AND D.CMCD(+) = " + Tbj20SozaiKanriList.CMCD);
//        if (_cond.getCopyMode()) {
//            sql.append("   AND (" + Tbj20SozaiKanriList.TIMEUSE + " != '0'");
//            sql.append("     OR " + Tbj20SozaiKanriList.SPOTUSE + " != '0' )");
//            sql.append("   AND (" + Tbj20SozaiKanriList.LIMIT + " IS NULL");
//            sql.append("     OR " + Tbj20SozaiKanriList.LIMIT + " >= '" +
//                    DateUtil.getFormatStringDate(_cond.getYmDate() + "01", "yyyyMMdd") + "')");
//        }
//
//        sql.append(" ORDER BY");
//        sql.append("       B." + Mbj20CarCategory.SORTNO + " ");
//        sql.append("      ," + Mbj05Car.SORTNO + "");
//        sql.append("      ," + Tbj20SozaiKanriList.RCODE + " ");
//        sql.append("      ," + Tbj20SozaiKanriList.RECKBN + " DESC");
//        sql.append("      ," + Tbj20SozaiKanriList.TIMEUSE + " DESC");
//        sql.append("      ," + Tbj20SozaiKanriList.SPOTUSE + " DESC");
//        sql.append("      ," + Tbj20SozaiKanriList.NEWFLG + " DESC");
//        sql.append("      ," + Tbj20SozaiKanriList.TITLE + " ");
//        sql.append("      ,D.DATEFROM");
//        sql.append("      ,D.DATETO");
        sql.append("WITH CONTRACT AS");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj17Content.CMCD + ",");
        sql.append(" " + "MIN(" + Tbj16ContractInfo.DATEFROM + ") " + Tbj16ContractInfo.DATEFROM + ",");
        sql.append(" " + "MIN(" + Tbj16ContractInfo.DATETO + ") " + Tbj16ContractInfo.DATETO);
        sql.append(" FROM");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Tbj17Content.TBNAME + ",");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + " IS NOT NULL AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + " = " + Tbj17Content.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + " = " + Tbj17Content.CTRTNO + " AND");
        sql.append(" " + Tbj17Content.CMCD + " = " + Tbj18SozaiKanriData.CMCD);
        sql.append(" GROUP BY");
        sql.append(" " + Tbj17Content.CMCD);
        sql.append("  ) , TEMPCONTRACT AS ");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + ",");
        sql.append(" " + "MIN(" + Tbj16ContractInfo.DATEFROM + ") " + Tbj16ContractInfo.DATEFROM + ",");
        sql.append(" " + "MIN(" + Tbj16ContractInfo.DATETO + ") " + Tbj16ContractInfo.DATETO);
        sql.append(" FROM");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + " IS NOT NULL AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + " = " + Tbj40TempSozaiContent.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + " = " + Tbj40TempSozaiContent.CTRTNO + " AND");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " = " + Tbj36TempSozaiKanriData.CMCD);
        sql.append(" GROUP BY");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD);
        sql.append("  )");

        //素材一覧画面で作成した素材(10桁CMコード、仮10桁CMコードがNULL)
        sql.append(" SELECT");
        sql.append(" 1 SEQ,");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + HAMConstants.MATERIAL_LIST + " MATERIAL_REG_LIST_FLG,");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.HCSYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.HMSYATAN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TIMEUSE + " HDXTIMEUSE,");
        sql.append(" " + Tbj42SozaiKanriListCmn.BSCSUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTUSE + " HDXSPOTUSE,");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.OADATETERM + ",");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " PREVDCARCD,");
        sql.append(" " + Mbj20CarCategory.CATEGORYNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" NULL DATEFROM,");
        sql.append(" NULL DATETO,");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + ",");
        /** 2016/03/29 HDX対応 HLC K.Oki MOD Start */
        //sql.append(" " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTCTRT + ",");
        /** 2016/03/29 HDX対応 HLC K.Oki MOD End */
        sql.append(" " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDID + ",");
        sql.append(" " + Mbj05Car.SORTNO + ",");
        sql.append(" " + Mbj20CarCategory.SORTNO + ",");
        sql.append(" NULL NOKBN");

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
        /** 2016/02/19 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Mbj20CarCategory.TBNAME);
        sql.append(" " + Mbj20CarCategory.TBNAME + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME);
        /** 2016/02/19 HDX対応 HLC K.Soga MOD End */

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " IS NULL AND");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ",'YYYYMM') = '" + _cond.getYmDate() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " <> '" + HAMConstants.MATERIAL_LIST_DELFLG_DELETE + "' AND");
        sql.append(" " + Mbj22CategoryContent.PHASE + " = '" + _cond.getPhase() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj22CategoryContent.DCARCD + "(+) AND");
        sql.append(" " + Mbj20CarCategory.CATEGORYNO + " = " + Mbj22CategoryContent.CATEGORYNO + " AND");
        /** 2016/02/19 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE);
        sql.append(" " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Tbj42SozaiKanriListCmn.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + Tbj42SozaiKanriListCmn.SOZAIYM + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = " + Tbj42SozaiKanriListCmn.RECKBN + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + " = " + Tbj43SozaiKanriListCmnOA.RECNO + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Tbj43SozaiKanriListCmnOA.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + "(+), 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = " + Tbj43SozaiKanriListCmnOA.RECKBN + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + " = " + Tbj43SozaiKanriListCmnOA.RECNO + "(+)");
        /** 2016/02/19 HDX対応 HLC K.Soga MOD End */
        if (_cond.getCopyMode()) {
            sql.append(" AND (" + Tbj20SozaiKanriList.TIMEUSE + " != '0' OR ");
            sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + " != '0' ) AND");
            sql.append(" (" + Tbj20SozaiKanriList.LIMIT + " IS NULL OR");
            sql.append(" " + Tbj20SozaiKanriList.LIMIT + " >= '" +
            DateUtil.getFormatStringDate(_cond.getYmDate() + "01", "yyyyMMdd") + "')");
        }
        //仮素材(10桁CMコードがNULL)
        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" 2,");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + HAMConstants.MATERIAL_LIST + " MATERIAL_REG_LIST_FLG,");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.HCSYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.HMSYATAN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TIMEUSE + " HDXTIMEUSE,");
        sql.append(" " + Tbj42SozaiKanriListCmn.BSCSUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTUSE + " HDXSPOTUSE,");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.OADATETERM + ",");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " PREVDCARCD,");
        sql.append(" " + Mbj20CarCategory.CATEGORYNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" TEMPCONTRACT. " + Tbj16ContractInfo.DATEFROM + " DATEFROM,");
        sql.append(" TEMPCONTRACT." + Tbj16ContractInfo.DATETO + " DATETO,");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + ",");
        /** 2016/03/29 HDX対応 HLC K.Oki MOD Start */
        //sql.append(" " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTCTRT + ",");
        /** 2016/03/29 HDX対応 HLC K.Oki MOD End */
        sql.append(" " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDID + ",");
        sql.append(" " + Mbj05Car.SORTNO + ",");
        sql.append(" " + Mbj20CarCategory.SORTNO + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
        sql.append(" " + Mbj20CarCategory.TBNAME + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME + ",");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD End */
        sql.append(" TEMPCONTRACT");

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " IS NOT NULL AND");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ",'YYYYMM') = '" + _cond.getYmDate() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " <> '" + HAMConstants.MATERIAL_LIST_DELFLG_DELETE + "' AND");
        sql.append(" " + Mbj22CategoryContent.PHASE + " = '" + _cond.getPhase() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj22CategoryContent.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " = " + Tbj36TempSozaiKanriData.TEMPCMCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " = " + Tbj40TempSozaiContent.TEMPCMCD + "(+) AND");
        sql.append(" " + Mbj20CarCategory.CATEGORYNO + " = " + Mbj22CategoryContent.CATEGORYNO + " AND");
        /** 2016/02/19 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE);
        sql.append(" " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Tbj42SozaiKanriListCmn.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + Tbj42SozaiKanriListCmn.SOZAIYM + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = " + Tbj42SozaiKanriListCmn.RECKBN + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + " = " + Tbj42SozaiKanriListCmn.RECNO + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Tbj43SozaiKanriListCmnOA.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + "(+), 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = " + Tbj43SozaiKanriListCmnOA.RECKBN + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + " = " + Tbj43SozaiKanriListCmnOA.RECNO + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " = " + Tbj43SozaiKanriListCmnOA.TEMPCMCD + "(+) AND");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.DELFLG + " <> '" + HAMConstants.DELFLG + "'");
        /** 2016/02/19 HDX対応 HLC K.Soga MOD End */
        if (_cond.getCopyMode()) {
            sql.append(" AND (" + Tbj20SozaiKanriList.TIMEUSE + " != '0' OR ");
            sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + " != '0' ) AND");
            sql.append(" (" + Tbj20SozaiKanriList.LIMIT + " IS NULL OR");
            sql.append(" " + Tbj20SozaiKanriList.LIMIT + " >= '" +
            DateUtil.getFormatStringDate(_cond.getYmDate() + "01", "yyyyMMdd") + "')");
        }

        //本素材
        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" 3,");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + HAMConstants.MATERIAL_LIST + " MATERIAL_REG_LIST_FLG,");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.HCSYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.HMSYATAN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TIMEUSE + " HDXTIMEUSE,");
        sql.append(" " + Tbj42SozaiKanriListCmn.BSCSUSE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTUSE + " HDXSPOTUSE,");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.OADATETERM + ",");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " PREVDCARCD,");
        sql.append(" " + Mbj20CarCategory.CATEGORYNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" CONTRACT." + Tbj16ContractInfo.DATEFROM + " DATEFROM,");
        sql.append(" CONTRACT." + Tbj16ContractInfo.DATETO + " DATETO,");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + ",");
        /** 2016/03/29 HDX対応 HLC K.Oki MOD Start */
        //sql.append(" " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj42SozaiKanriListCmn.SPOTCTRT + ",");
        /** 2016/03/29 HDX対応 HLC K.Oki MOD End */
        sql.append(" " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDID + ",");
        sql.append(" " + Mbj05Car.SORTNO + ",");
        sql.append(" " + Mbj20CarCategory.SORTNO + ",");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
        sql.append(" " + Mbj20CarCategory.TBNAME + ",");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME + ",");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj42SozaiKanriListCmn.TBNAME + ",");
        sql.append(" " + Tbj43SozaiKanriListCmnOA.TBNAME + ",");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD End */
        sql.append(" CONTRACT");

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NOT NULL AND");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ",'YYYYMM') = '" + _cond.getYmDate() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " <> '" + HAMConstants.MATERIAL_LIST_DELFLG_DELETE + "' AND");
        sql.append(" " + Mbj22CategoryContent.PHASE + " = '" + _cond.getPhase() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Mbj22CategoryContent.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + Tbj17Content.CMCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + Tbj18SozaiKanriData.CMCD + "(+) AND");
        sql.append(" " + Mbj20CarCategory.CATEGORYNO + " = " + Mbj22CategoryContent.CATEGORYNO + " AND");
        /** 2016/02/19 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE);
        sql.append(" " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Tbj42SozaiKanriListCmn.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + Tbj42SozaiKanriListCmn.SOZAIYM + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = " + Tbj42SozaiKanriListCmn.RECKBN + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + " = " + Tbj42SozaiKanriListCmn.RECNO + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + Tbj43SozaiKanriListCmnOA.DCARCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = TO_CHAR(" + Tbj43SozaiKanriListCmnOA.SOZAIYM + "(+), 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = " + Tbj43SozaiKanriListCmnOA.RECKBN + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + " = " + Tbj43SozaiKanriListCmnOA.RECNO + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + Tbj43SozaiKanriListCmnOA.CMCD + "(+) AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " <> '" + HAMConstants.DELFLG + "'");
        /** 2016/02/19 HDX対応 HLC K.Soga MOD End */
        if (_cond.getCopyMode()) {
            sql.append(" AND (" + Tbj20SozaiKanriList.TIMEUSE + " != '0' OR ");
            sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + " != '0' ) AND");
            sql.append(" (" + Tbj20SozaiKanriList.LIMIT + " IS NULL OR");
            sql.append(" " + Tbj20SozaiKanriList.LIMIT + " >= '" + DateUtil.getFormatStringDate(_cond.getYmDate() + "01", "yyyyMMdd") + "')");
        }

        sql.append(" ORDER BY");
        sql.append(" " + Mbj20CarCategory.SORTNO + ",");
        sql.append(" " + Mbj05Car.SORTNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " DESC,");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + " DESC,");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + " DESC,");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + " DESC,");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO);
        /** 2015/10/14 JASRAC対応 HLC K.Soga MOD End */

        return sql.toString();
    }

    /**
     * 素材登録情報取得SQL
     * @return
     */
    private String getSelectSQLForMaterialRegistList() {

        StringBuffer sql = new StringBuffer();

        /** 2015/11/24 JASRAC対応 HLC K.Soga MOD Start */
//        sql.append("SELECT ");
//        sql.append("   B." + Mbj20CarCategory.SORTNO + "  AS CATEGORY_SORTNO");
//        sql.append("  ," + Mbj05Car.SORTNO + " AS CAR_SORTNO");
//        sql.append("  ," + Tbj18SozaiKanriData.DCARCD + " AS "+ Tbj20SozaiKanriList.DCARCD + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.DCARCD + " AS  PREVDCARCD");
//        sql.append("  ,B." + Mbj20CarCategory.CATEGORYNO + " ");
//        sql.append("  ,TO_DATE('" + _cond.getYmDate().concat("01") + "') AS " + Tbj20SozaiKanriList.SOZAIYM + " ");
//        sql.append("  ,'0' AS " + Tbj20SozaiKanriList.RECKBN + " ");
//        sql.append("  ,'0000' AS " + Tbj20SozaiKanriList.RECNO + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.DELFLG + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CMCD + " AS "+ Tbj20SozaiKanriList.CMCD + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.TITLE + " AS "+ Tbj20SozaiKanriList.TITLE + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.SECOND + " AS "+ Tbj20SozaiKanriList.SECOND + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.RCODE + " ");
//        sql.append("  ,0 AS " + Tbj20SozaiKanriList.ESTIMATE + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.DATEFROM + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.DATETO + " ");
//        sql.append("  ,D.DATEFROM");
//        sql.append("  ,D.DATETO");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.NEWFLG + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.TIMEUSE + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.SPOTUSE + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.SPOTCTRT + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.SPOTSPAN + " ");
//        sql.append("  ,0 AS " + Tbj20SozaiKanriList.SPOTESTM + " ");
//        sql.append("  ,TO_CHAR(" + Tbj18SozaiKanriData.MLIMIT + ") AS "+ Tbj20SozaiKanriList.LIMIT + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.SYATAN + " AS "+ Tbj20SozaiKanriList.SYATAN + " ");
//        sql.append("  ,NULL AS " + Tbj20SozaiKanriList.BIKO + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CRTDATE + " AS "+ Tbj20SozaiKanriList.CRTDATE + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CRTNM + " AS "+ Tbj20SozaiKanriList.CRTNM + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CRTAPL + " AS "+ Tbj20SozaiKanriList.CRTAPL + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CRTID + " AS "+ Tbj20SozaiKanriList.CRTID + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.UPDDATE + " AS "+ Tbj20SozaiKanriList.UPDDATE + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.UPDNM + " AS "+ Tbj20SozaiKanriList.UPDNM  + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.UPDAPL + " AS "+ Tbj20SozaiKanriList.UPDAPL + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.UPDID + " AS "+ Tbj20SozaiKanriList.UPDID + " ");
//
//        sql.append(" FROM");
//        sql.append("  " + Tbj18SozaiKanriData.TBNAME+ " ");
//        sql.append("  ," + Mbj05Car.TBNAME + " ");
//        sql.append("  ,(");
//        sql.append("     SELECT ");
//        sql.append("       " + Mbj22CategoryContent.DCARCD + " AS DCARCD ");
//        sql.append("      ," + Mbj20CarCategory.CATEGORYNO + " ");
//        sql.append("      ," + Mbj20CarCategory.SORTNO + " ");
//        sql.append("       FROM");
//        sql.append("       " + Mbj22CategoryContent.TBNAME + " ");
//        sql.append("      ," + Mbj20CarCategory.TBNAME + " ");
//        sql.append("      WHERE");
//        sql.append("       " + Mbj20CarCategory.CATEGORYNO + " = " + Mbj22CategoryContent.CATEGORYNO);
//        sql.append("        AND " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE);
//        sql.append("        AND " + Mbj22CategoryContent.PHASE + " = '" + _cond.getPhase() + "'");
//        sql.append("   ) B");
//        sql.append("  ,(");
//        sql.append("     SELECT ");
//        sql.append("          E." + Tbj17Content.CMCD + " AS CMCD");
//        sql.append("         ,E.DATEFROM ");
//        sql.append("         ,E.DATETO ");
//        sql.append("       FROM");
//        sql.append("           (");
//        sql.append("            SELECT");
//        sql.append("               " + Tbj17Content.CMCD + " ");
//        sql.append("              ,MIN(" + Tbj16ContractInfo.DATEFROM + ") AS DATEFROM ");
//        sql.append("              ,MIN(" + Tbj16ContractInfo.DATETO + ") AS DATETO ");
//        sql.append("              FROM ");
//        sql.append("                " + Tbj16ContractInfo.TBNAME + " ");
//        sql.append("               ," + Tbj17Content.TBNAME + " ");
//        sql.append("               ," + Tbj18SozaiKanriData.TBNAME + " ");
//        sql.append("             WHERE ");
//        sql.append("                   " + Tbj16ContractInfo.DATEFROM + " IS NOT NULL");
//        sql.append("               AND " + Tbj16ContractInfo.CTRTKBN + " = " + Tbj17Content.CTRTKBN);
//        sql.append("               AND " + Tbj16ContractInfo.CTRTNO + " = " + Tbj17Content.CTRTNO);
//        sql.append("               AND " + Tbj17Content.CMCD + " = " + Tbj18SozaiKanriData.CMCD);
//        sql.append("             GROUP BY");
//        sql.append("               " + Tbj17Content.CMCD + " ");
//        sql.append("           ) E");
//        sql.append("   ) D");
//
//        sql.append(" WHERE");
//        sql.append("       " + Tbj18SozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD);
//        sql.append("   AND " + Tbj18SozaiKanriData.STATUS + " <> '" + _delFlg + "'");
//        sql.append("   AND " + Tbj18SozaiKanriData.STATUS + " <> '" + _invalidFlg + "'");
//        sql.append("   AND (" + Tbj18SozaiKanriData.DATEFROM + " IS NULL");
//        sql.append("         OR TO_CHAR(" + Tbj18SozaiKanriData.DATEFROM + ",'YYYYMM') <= '" + _cond.getYmDate() + "')");
//        sql.append("   AND (" + Tbj18SozaiKanriData.MLIMIT + " IS NULL");
//        sql.append("         OR TO_CHAR(" + Tbj18SozaiKanriData.MLIMIT + ",'YYYYMM') >= '" + _cond.getYmDate() + "')");
//        sql.append("   AND B.DCARCD(+) = " + Tbj18SozaiKanriData.DCARCD);
//        sql.append("   AND D.CMCD(+) = " + Tbj18SozaiKanriData.CMCD);
//
//        sql.append(" GROUP BY");
//        sql.append("       B." + Mbj20CarCategory.SORTNO + " ");
//        sql.append("      ," + Mbj05Car.SORTNO + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.DCARCD + " ");
//        sql.append("      ,B." + Mbj20CarCategory.CATEGORYNO + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.CMCD + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.TITLE + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.SECOND + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.MLIMIT + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.SYATAN + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.CRTDATE + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.CRTNM + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.CRTAPL + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.CRTID + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.UPDDATE + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.UPDNM + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.UPDAPL + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.UPDID + " ");
//        sql.append("      ,D.DATEFROM");
//        sql.append("      ,D.DATETO");
//
//        sql.append(" ORDER BY");
//        sql.append("       B." + Mbj20CarCategory.SORTNO + " ");
//        sql.append("      ," + Mbj05Car.SORTNO + " ");
//        sql.append("      ," + Tbj18SozaiKanriData.TITLE + " ");
//        sql.append("      ," + Tbj20SozaiKanriList.CMCD + " ");
//        sql.append("      ,D.DATEFROM");
//        sql.append("      ,D.DATETO");
        sql.append("WITH CATEGORYRY AS");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Mbj22CategoryContent.DCARCD + " DCARCD,");
        sql.append(" " + Mbj20CarCategory.CATEGORYNO + ",");
        sql.append(" " + Mbj20CarCategory.SORTNO);
        sql.append(" FROM");
        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
        sql.append(" " + Mbj20CarCategory.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Mbj20CarCategory.CATEGORYNO + " = " + Mbj22CategoryContent.CATEGORYNO + " AND");
        sql.append(" " + Mbj20CarCategory.PHASE + " = " + Mbj22CategoryContent.PHASE + " AND");
        sql.append(" " + Mbj22CategoryContent.PHASE + " = '" + _cond.getPhase() + "'");
        sql.append("  ) , CONTRACTINFO AS ");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj17Content.CMCD + " CMCD,");
        sql.append(" MIN(" + Tbj16ContractInfo.DATEFROM + ") DATEFROM,");
        sql.append(" MIN(" + Tbj16ContractInfo.DATETO + ") DATETO");
        sql.append(" FROM");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Tbj17Content.TBNAME + ",");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + " IS NOT NULL AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + "=" + Tbj17Content.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + "=" + Tbj17Content.CTRTNO + " AND");
        sql.append(" " + Tbj17Content.CMCD + "=" + Tbj18SozaiKanriData.CMCD);
        sql.append(" GROUP BY");
        sql.append(" " + Tbj17Content.CMCD);
        sql.append("  ) , TEMPCONTRACTINFO AS ");
        sql.append(" (");
        sql.append(" SELECT");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " TEMPCMCD,");
        sql.append(" MIN(" + Tbj16ContractInfo.DATEFROM + ") DATEFROM,");
        sql.append(" MIN(" + Tbj16ContractInfo.DATETO + ") DATETO");
        sql.append(" FROM");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + " IS NOT NULL AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + "=" + Tbj40TempSozaiContent.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + "=" + Tbj40TempSozaiContent.CTRTNO + " AND");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + "=" + Tbj36TempSozaiKanriData.TEMPCMCD);
        sql.append(" GROUP BY");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD);
        sql.append("  )");

        sql.append(" SELECT");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + HAMConstants.MATERIAL_REGIST + " MATERIAL_REG_LIST_FLG,");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD End */
        sql.append(" CATEGORYRY." + Mbj20CarCategory.SORTNO + " CATEGORY_SORTNO,");
        sql.append(" " + Mbj05Car.SORTNO + " CAR_SORTNO,");
        sql.append(" " + Tbj18SozaiKanriData.DCARCD + " "+ Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj18SozaiKanriData.DCARCD + " PREVDCARCD,");
        sql.append(" CATEGORYRY." + Mbj20CarCategory.CATEGORYNO + ",");
        sql.append(" TO_DATE('" + _cond.getYmDate().concat("01") + "') " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" '" + HAMConstants.RECKBN_SYSTEM +"' " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" '" + HAMConstants.RECKNO + "' " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + " NOKBN" + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " "+ Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Tbj18SozaiKanriData.TITLE + " "+ Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj18SozaiKanriData.SECOND + " "+ Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" 0 " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" CONTRACTINFO.DATEFROM,");
        sql.append(" CONTRACTINFO.DATETO,");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj18SozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj18SozaiKanriData.ENDTITLE + ",");
        sql.append(" NULL " + Tbj18SozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" NULL " + Tbj18SozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
        sql.append(" NULL " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.SPOTUSE + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" 0 " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" TO_CHAR(" + Tbj18SozaiKanriData.MLIMIT + ") "+ Tbj20SozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj18SozaiKanriData.SYATAN + " "+ Tbj20SozaiKanriList.SYATAN + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj18SozaiKanriData.CRTDATE + " "+ Tbj20SozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj18SozaiKanriData.CRTNM + " "+ Tbj20SozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj18SozaiKanriData.CRTAPL + " "+ Tbj20SozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj18SozaiKanriData.CRTID + " "+ Tbj20SozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj18SozaiKanriData.UPDDATE + " "+ Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj18SozaiKanriData.UPDNM + " "+ Tbj20SozaiKanriList.UPDNM  + ",");
        sql.append(" " + Tbj18SozaiKanriData.UPDAPL + " "+ Tbj20SozaiKanriList.UPDAPL + ",");
        sql.append(" " + Tbj18SozaiKanriData.UPDID + " "+ Tbj20SozaiKanriList.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME+ ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME+ ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" CATEGORYRY,");
        sql.append(" CONTRACTINFO");

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + " AND");
        sql.append(" " + Tbj18SozaiKanriData.STATUS + " <> '" + HAMConstants.DELFLG + "' AND");
        sql.append(" " + Tbj18SozaiKanriData.STATUS + " <> '" + HAMConstants.MATERIAL_REGISTER_DELFLG_IGNORE + "' AND");
        sql.append(" (" + Tbj18SozaiKanriData.DATEFROM + " IS NULL");
        sql.append(" OR TO_CHAR(" + Tbj18SozaiKanriData.DATEFROM + ",'YYYYMM') <= '" + _cond.getYmDate() + "') AND");
        sql.append(" (" + Tbj18SozaiKanriData.MLIMIT + " IS NULL");
        sql.append(" OR TO_CHAR(" + Tbj18SozaiKanriData.MLIMIT + ",'YYYYMM') >= '" + _cond.getYmDate() + "') AND");
        sql.append(" CATEGORYRY.DCARCD(+) = " + Tbj18SozaiKanriData.DCARCD + " AND");
        sql.append(" CONTRACTINFO.CMCD(+) = " + Tbj18SozaiKanriData.CMCD + " AND");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + "(+) = " + Tbj18SozaiKanriData.CMCD);
        /** 2016/04/12 HDX対応 HLC K.Soga ADD Start */
        //全件表示フラグがfalseの場合
        if(!_cond.getDispAllList()){
            //現在から過去2年分の素材登録データを取得する
            sql.append(" AND " + Tbj18SozaiKanriData.CRTDATE + " >= '" + _cond.getDispAllListYmDate() + "'");
        }
        /** 2016/04/12 HDX対応 HLC K.Soga ADD End */

        sql.append(" UNION ALL");
        sql.append(" SELECT");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + HAMConstants.MATERIAL_REGIST + " MATERIAL_REG_LIST_FLG,");
        /** 2016/02/19 HDX対応 HLC K.Soga ADD End */
        sql.append(" CATEGORYRY." + Mbj20CarCategory.SORTNO + ",");
        sql.append(" " + Mbj05Car.SORTNO + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
        sql.append(" CATEGORYRY." + Mbj20CarCategory.CATEGORYNO + ",");
        sql.append(" TO_DATE('" + _cond.getYmDate().concat("01") + "'),");
        sql.append(" '" + HAMConstants.RECKBN_SYSTEM +"',");
        sql.append(" '" + HAMConstants.RECKNO + "',");
        sql.append(" NULL " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.SECOND + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" 0 " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" TEMPCONTRACTINFO.DATEFROM,");
        sql.append(" TEMPCONTRACTINFO.DATETO,");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj36TempSozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.ENDTITLE + ",");
        sql.append(" NULL " + Tbj36TempSozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" NULL " + Tbj36TempSozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
        sql.append(" NULL " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.SPOTUSE + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" 0 " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" TO_CHAR(" + Tbj36TempSozaiKanriData.MLIMIT + "),");
        sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + ",");
        sql.append(" NULL " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.CRTNM + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.CRTAPL + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.CRTID + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.UPDDATE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.UPDNM + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.UPDAPL + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME+ ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" CATEGORYRY,");
        sql.append(" TEMPCONTRACTINFO");

        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
        sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + " AND");
        sql.append(" " + Tbj36TempSozaiKanriData.STATUS + " <> '" + HAMConstants.DELFLG + "' AND");
        sql.append(" " + Tbj36TempSozaiKanriData.STATUS + " <> '" + HAMConstants.MATERIAL_REGISTER_DELFLG_IGNORE + "' AND");
        sql.append(" (" + Tbj36TempSozaiKanriData.DATEFROM + " IS NULL");
        sql.append(" OR TO_CHAR(" + Tbj36TempSozaiKanriData.DATEFROM + ",'YYYYMM') <= '" + _cond.getYmDate() + "') AND");
        sql.append(" (" + Tbj36TempSozaiKanriData.MLIMIT + " IS NULL");
        sql.append(" OR TO_CHAR(" + Tbj36TempSozaiKanriData.MLIMIT + ",'YYYYMM') >= '" + _cond.getYmDate() + "') AND");
        sql.append(" CATEGORYRY.DCARCD(+) = " + Tbj36TempSozaiKanriData.DCARCD + " AND");
        sql.append(" TEMPCONTRACTINFO.TEMPCMCD(+) = " + Tbj36TempSozaiKanriData.TEMPCMCD);
        /** 2016/04/12 HDX対応 HLC K.Soga ADD Start */
        //全件表示フラグがfalseの場合
        if(!_cond.getDispAllList()){
            //現在から過去2年分の素材登録データを取得する
            sql.append(" AND " + Tbj36TempSozaiKanriData.CRTDATE + " >= '" + _cond.getDispAllListYmDate() + "'");
        }
        /** 2016/04/12 HDX対応 HLC K.Soga ADD End */

        sql.append(" ORDER BY");
        sql.append(" CATEGORY_SORTNO,");
        sql.append(" CAR_SORTNO,");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        sql.append(" DATEFROM,");
        sql.append(" DATETO");
        /** 2015/11/24 JASRAC対応 HLC K.Soga MOD End */

        return sql.toString();
    }

    /**
     * コンテンツに紐付く契約情報取得SQL
     * @return
     */
    private String getSelectSQLForContentCntrct() {

        StringBuffer sql = new StringBuffer();

        /** 2015/11/24 JASRAC対応 HLC K.Soga MOD Start */
//        sql.append("SELECT ");
//        sql.append("  " + Tbj17Content.CMCD + " ");
//        sql.append(" ," + Tbj16ContractInfo.CTRTKBN + " ");
//        sql.append(" ," + Tbj16ContractInfo.CTRTNO + " ");
//        sql.append(" ," + Mbj12Code.CODENAME + " AS CTRTKBNNAME");
//        sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
//        sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
//        sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
//        sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
//        sql.append(" ,DECODE(" + Tbj16ContractInfo.SALEFLG + ",'Y','あり','--') AS " + Tbj16ContractInfo.SALEFLG);
//        sql.append(" ," + Tbj16ContractInfo.BIKO + " ");
//        sql.append(" ," + Tbj16ContractInfo.DCARCD + " ");
//        sql.append(" ," + Tbj16ContractInfo.CATEGORY + " ");
//        sql.append(" ,DECODE(" + Tbj16ContractInfo.JASRACFLG  + ",'Y','あり','--') AS " + Tbj16ContractInfo.JASRACFLG);
//        sql.append(" ," + Tbj16ContractInfo.CRTDATE + " ");
//        sql.append(" ," + Tbj16ContractInfo.CRTNM + " ");
//        sql.append(" ," + Tbj16ContractInfo.CRTAPL + " ");
//        sql.append(" ," + Tbj16ContractInfo.CRTID + " ");
//        sql.append(" ," + Tbj16ContractInfo.UPDDATE + " ");
//        sql.append(" ," + Tbj16ContractInfo.UPDNM + " ");
//        sql.append(" ," + Tbj16ContractInfo.UPDID + " ");
//        sql.append(" ," + Tbj17Content.CRTDATE + " ");
//        sql.append(" ," + Tbj17Content.UPDDATE + " ");
//
//        sql.append(" FROM ");
//        sql.append("  " + Tbj17Content.TBNAME + " ");
//        sql.append("  ," + Tbj16ContractInfo.TBNAME + " ");
//        sql.append("  ," + Mbj12Code.TBNAME + " ");
//
//        sql.append(" WHERE ");
//        sql.append("  " + Tbj16ContractInfo.CTRTKBN +  " = " + Tbj17Content.CTRTKBN);
//        sql.append(" AND " + Tbj16ContractInfo.CTRTNO +  " = " + Tbj17Content.CTRTNO);
//        sql.append(" AND " + Tbj16ContractInfo.DELFLG + " != 'D'");
//        sql.append(" AND " + Mbj12Code.CODETYPE + "(+)" + " = '16'" );
//        sql.append(" AND " + Tbj16ContractInfo.CTRTKBN + " = " + Mbj12Code.KEYCODE + "(+)" );
//
//        sql.append("  ORDER BY ");
//        sql.append(Tbj17Content.CMCD + ", ");
//        sql.append(Tbj17Content.CTRTKBN + ", ");
//        sql.append(Tbj17Content.CTRTNO + ", ");
//        sql.append(Tbj16ContractInfo.DATETO );
        sql.append("SELECT");
        sql.append(" " + Tbj17Content.CMCD + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Mbj12Code.CODENAME + " CTRTKBNNAME,");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" DECODE(" + Tbj16ContractInfo.SALEFLG + ", 'Y', 'あり', '--') " + Tbj16ContractInfo.SALEFLG + ",");
        sql.append(" " + Tbj16ContractInfo.BIKO + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" DECODE(" + Tbj16ContractInfo.JASRACFLG  + ", 'Y', 'あり', '--') " + Tbj16ContractInfo.JASRACFLG + ",");
        sql.append(" " + Tbj16ContractInfo.CRTDATE + ",");
        sql.append(" " + Tbj16ContractInfo.CRTNM + ",");
        sql.append(" " + Tbj16ContractInfo.CRTAPL + ",");
        sql.append(" " + Tbj16ContractInfo.CRTID + ",");
        sql.append(" " + Tbj16ContractInfo.UPDDATE + ",");
        sql.append(" " + Tbj16ContractInfo.UPDNM + ",");
        sql.append(" " + Tbj16ContractInfo.UPDID + ",");
        sql.append(" " + Tbj17Content.CRTDATE + ",");
        sql.append(" " + Tbj17Content.UPDDATE);

        sql.append(" FROM");
        sql.append(" " + Tbj17Content.TBNAME + ",");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN +  " = " + Tbj17Content.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO +  " = " + Tbj17Content.CTRTNO + " AND");
        sql.append(" " + Tbj16ContractInfo.DELFLG + " != '" + HAMConstants.CONTRACT_REGISTER_DELFLG_DELETE + "' AND");
        sql.append(" " + Mbj12Code.CODETYPE + "(+)" + " = '" + HAMConstants.CODETYPE_CTRTKBN + "' AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + " = " + Mbj12Code.KEYCODE + "(+)");

        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Mbj12Code.CODENAME + " CTRTKBNNAME,");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" DECODE(" + Tbj16ContractInfo.SALEFLG + ", 'Y', 'あり', '--'),");
        sql.append(" " + Tbj16ContractInfo.BIKO + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" DECODE(" + Tbj16ContractInfo.JASRACFLG  + ", 'Y', 'あり', '--'),");
        sql.append(" " + Tbj16ContractInfo.CRTDATE + ",");
        sql.append(" " + Tbj16ContractInfo.CRTNM + ",");
        sql.append(" " + Tbj16ContractInfo.CRTAPL + ",");
        sql.append(" " + Tbj16ContractInfo.CRTID + ",");
        sql.append(" " + Tbj16ContractInfo.UPDDATE + ",");
        sql.append(" " + Tbj16ContractInfo.UPDNM + ",");
        sql.append(" " + Tbj16ContractInfo.UPDID + ",");
        sql.append(" " + Tbj40TempSozaiContent.CRTDATE + ",");
        sql.append(" " + Tbj40TempSozaiContent.UPDDATE);

        sql.append(" FROM");
        sql.append(" " + Tbj40TempSozaiContent.TBNAME + ",");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN +  " = " + Tbj40TempSozaiContent.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO +  " = " + Tbj40TempSozaiContent.CTRTNO + " AND");
        sql.append(" " + Tbj16ContractInfo.DELFLG + " != '" + HAMConstants.CONTRACT_REGISTER_DELFLG_DELETE + "' AND");
        sql.append(" " + Mbj12Code.CODETYPE + "(+)" + " = '" + HAMConstants.CODETYPE_CTRTKBN + "' AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + " = " + Mbj12Code.KEYCODE + "(+)");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj17Content.CMCD + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO);
        /** 2015/11/24 JASRAC対応 HLC K.Soga MOD End */

        return sql.toString();
    }

    /**
     * カテゴリマスタ取得SQL
     * @return
     */
    private String getSelectSQLForCategoryMst() {
        StringBuffer sql = new StringBuffer();

        sql.append("SELECT ");
        sql.append("   " + Mbj20CarCategory.CATEGORYNO + " ");
        sql.append("  ," + Mbj20CarCategory.CATEGORYNM + " ");
        sql.append("  ," + Mbj20CarCategory.PHASE + " ");
        sql.append(" FROM ");
        sql.append("     " + Mbj20CarCategory.TBNAME + " ");
        sql.append(" ORDER BY");
        sql.append("     " + Mbj20CarCategory.PHASE);
        sql.append("    ," + Mbj20CarCategory.SORTNO);

        return sql.toString();
    }

    /**
     * 車種マスタ取得SQL
     * @return
     */
    private String getSelectSQLForMaterialCarMst() {

        StringBuffer sql = new StringBuffer();
        sql.append("SELECT ");
        sql.append("    " + Mbj05Car.DCARCD);
        sql.append("   ," + Mbj05Car.CARNM);
        sql.append("   ," + Mbj22CategoryContent.PHASE + " AS PHASE");
        sql.append("   ," + Mbj22CategoryContent.CATEGORYNO + " AS CATEGORYNO");
        sql.append("   ," + Mbj05Car.SORTNO);
        sql.append(" FROM");
        sql.append("   " + Mbj22CategoryContent.TBNAME);
        sql.append("   ," + Mbj05Car.TBNAME);
        sql.append(" WHERE");
        sql.append("   " + Mbj05Car.DCARCD + " = " + Mbj22CategoryContent.DCARCD + " ");

        sql.append(" UNION ALL ");

        sql.append("SELECT ");
        sql.append("    " + Mbj05Car.DCARCD);
        sql.append("   ," + Mbj05Car.CARNM);
        sql.append("   ,NULL AS PHASE");
        sql.append("   ,NULL AS CATEGORYNO");
        sql.append("   ," + Mbj05Car.SORTNO);
        sql.append(" FROM");
        sql.append("    " + Mbj05Car.TBNAME);
        sql.append(" ORDER BY ");
        sql.append("    PHASE ASC ");
        sql.append("   ,CATEGORYNO ASC ");
        sql.append("   ," + Mbj05Car.SORTNO + " ASC ");
        sql.append("   ," + Mbj05Car.CARNM + " ASC ");

        return sql.toString();
    }

    /**
     * 素材一覧の主キー検索SQL
     * @return
     */
    private String getSelectSQLForMaterialListByPrimaryKey() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT *");
        sql.append(" FROM ");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = '" + _mateListVo.getPrevDCarCd() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_mateListVo.getSOZAIYM()) + " ");
        sql.append(" AND ");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = '" + _mateListVo.getRECKBN() + "' ");
        sql.append(" AND ");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + " = '" + _mateListVo.getRECNO() + "' ");

        return sql.toString();
    }

    /**
     * 素材一覧の主キー検索SQL
     * @return
     */
    private String getSelectSQLForMaterialListBySozaiYm() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append("       " + Tbj18SozaiKanriData.CMCD + " AS " + Tbj20SozaiKanriList.CMCD);
        sql.append("      ," + Tbj18SozaiKanriData.STATUS + " AS " + Tbj20SozaiKanriList.DELFLG);
        sql.append("      ," + Tbj20SozaiKanriList.RECKBN);
        sql.append("      ," + Tbj20SozaiKanriList.RECNO);
        sql.append("      ," + Tbj20SozaiKanriList.DCARCD + " AS " + Tbj20SozaiKanriList.DCARCD);
        sql.append("      ," + Tbj18SozaiKanriData.DCARCD + " AS PREVDCARCD");
        sql.append("      ," + Tbj18SozaiKanriData.TITLE + " AS " + Tbj20SozaiKanriList.TITLE);
        sql.append("      ," + Tbj18SozaiKanriData.SECOND + " AS " + Tbj20SozaiKanriList.SECOND);
        sql.append("      ," + Tbj18SozaiKanriData.SYATAN + " AS " + Tbj20SozaiKanriList.SYATAN);
        sql.append("      ," + Tbj20SozaiKanriList.SOZAIYM);
        sql.append(" FROM ");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME + " ");
        sql.append("  ," + Tbj18SozaiKanriData.TBNAME + " ");
        sql.append(" WHERE ");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = " + Tbj18SozaiKanriData.CMCD + " ");
        sql.append(" AND ");
        sql.append(" TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ",'YYYYMM') = '" + _cond.getYmDate() + "' ");

        return sql.toString();
    }

    /**
     * 履歴画面用のデータ取得SQL
     * @return
     */
    private String getSelectSQLForLogMaterialList() {
        StringBuffer sql = new StringBuffer();

        /** 2015/12/8 JASRAC対応 HLC K.Soga MOD Start */
//        sql.append("SELECT");
//        sql.append(" " + Mbj12Code.CODENAME + " HISTORYNM" + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + ",");
//        sql.append(" " + Mbj20CarCategory.CATEGORYNM + ",");
//        sql.append(" " + Mbj05Car.CARNM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SECOND + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.RCODE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.NEWFLG + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.TITLE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.TIMEUSE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SPOTUSE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SPOTCTRT + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SPOTSPAN + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SPOTESTM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.LIMIT + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.BIKO + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SYATAN + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.ESTIMATE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.DATETO + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CRTNM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CRTAPL + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CRTID + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CRTDATE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.UPDNM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.UPDDATE);
//        sql.append(" FROM");
//        sql.append(" " + Tbj26LogSozaiKanriList.TBNAME + ",");
//        sql.append(" " + Mbj05Car.TBNAME + ",");
//        sql.append(" " + Mbj20CarCategory.TBNAME + ",");
//        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
//        sql.append(" " + Mbj12Code.TBNAME);
//        sql.append(" WHERE");
//        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + ConvertToDBNullString(_cond.getDCarCd()) + " AND (");
//        sql.append(" TO_CHAR(" + Tbj26LogSozaiKanriList.SOZAIYM + ", 'YYYYMM') = " + ConvertToDBNullString(_cond.getYmDate()) + " AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + ConvertToDBNullString(_cond.getRecKbn()) + " AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.RECNO + " = " + ConvertToDBNullString(_cond.getRecNo()) + " AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
//        sql.append(" " + Mbj05Car.DCARCD  + " = " + Mbj22CategoryContent.DCARCD + "(+) AND");
//        sql.append(" " + Mbj22CategoryContent.PHASE + "(+) = " + getDBModelInterface().ConvertToDBString(_cond.getPhase()) + " AND");
//        sql.append(" " + Mbj22CategoryContent.PHASE  + " = " + Mbj20CarCategory.PHASE + "(+) AND");
//        sql.append(" " + Mbj22CategoryContent.CATEGORYNO  + " = " + Mbj20CarCategory.CATEGORYNO + "(+) AND");
//        sql.append(" " + Mbj12Code.CODETYPE + "(+) = '" + HAMConstants.CODETYPE_HISTORYNM + "' AND");
//        sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN);
//        sql.append(" ORDER BY");
//        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO);
        //本素材
        sql.append("SELECT");
        sql.append(" 1 SEQ,");
        sql.append(" " + Mbj12Code.CODENAME + " HISTORYNM" + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Mbj20CarCategory.CATEGORYNM + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTUSE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATETO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDDATE + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO);
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.OPENFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATETO_ATTR + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HCSYATAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HMSYATAN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TIMEUSE + " HDXTIMEUSE,");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.BSCSUSE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTUSE + " HDXSPOTUSE,");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.OADATETERM);
        /** 2016/02/25 HDX対応 HLC K.Soga MOD End */

        sql.append(" FROM");
        sql.append(" " + Tbj26LogSozaiKanriList.TBNAME + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TBNAME + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.TBNAME + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj20CarCategory.TBNAME + ",");
        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = " + ConvertToDBNullString(_cond.getCmCd()) + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " IS NULL AND");
        /** 2016/02/25 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.TITLE + " = " + ConvertToDBNullString(_cond.getTitle()) + " AND");
        /** 2016/02/25 HDX対応 HLC K.Soga DEL End */
        sql.append(" TO_CHAR(" + Tbj26LogSozaiKanriList.SOZAIYM + ", 'YYYYMM') = " + ConvertToDBNullString(_cond.getYmDate()) + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + ConvertToDBNullString(_cond.getRecKbn()) + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Mbj05Car.DCARCD  + " = " + Mbj22CategoryContent.DCARCD + "(+) AND");
        sql.append(" " + Mbj22CategoryContent.PHASE + "(+) = " + getDBModelInterface().ConvertToDBString(_cond.getPhase()) + " AND");
        sql.append(" " + Mbj22CategoryContent.PHASE  + " = " + Mbj20CarCategory.PHASE + "(+) AND");
        sql.append(" " + Mbj22CategoryContent.CATEGORYNO  + " = " + Mbj20CarCategory.CATEGORYNO + "(+) AND");
        sql.append(" " + Mbj12Code.CODETYPE + "(+) = '" + HAMConstants.CODETYPE_HISTORYNM + "' AND");
        /** 2016/02/26 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN);
        sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj44LogSozaiKanriListCmn.DCARCD + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = " + Tbj44LogSozaiKanriListCmn.SOZAIYM + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj44LogSozaiKanriListCmn.RECKBN + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + " = " + Tbj44LogSozaiKanriListCmn.HISTORYNO + "(+) AND");
        if(_cond.getCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = " + Tbj44LogSozaiKanriListCmn.CMCD + "(+) AND");
            }
        if(_cond.getTempCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + "(+) AND");
            }
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj45LogSozaiKanriListCmnOA.DCARCD + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = TO_CHAR(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + "(+), 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj45LogSozaiKanriListCmnOA.RECKBN + "(+) AND");
        if(_cond.getCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = " + Tbj45LogSozaiKanriListCmnOA.CMCD + "(+) AND");
            }
        if(_cond.getTempCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + Tbj45LogSozaiKanriListCmnOA.TEMPCMCD + "(+) AND");
            }
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYKBN + " = " + Tbj45LogSozaiKanriListCmnOA.HISTORYKBN + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + " = " + Tbj45LogSozaiKanriListCmnOA.HISTORYNO + "(+)");
        /** 2016/02/26 HDX対応 HLC K.Soga MOD End */

        //仮素材
        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" 2 SEQ,");
        sql.append(" " + Mbj12Code.CODENAME + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Mbj20CarCategory.CATEGORYNM + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTUSE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATETO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDDATE + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO);
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.OPENFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATETO_ATTR + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HCSYATAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HMSYATAN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TIMEUSE + " HDXTIMEUSE,");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.BSCSUSE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTUSE + " HDXSPOTUSE,");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.OADATETERM);
        /** 2016/02/25 HDX対応 HLC K.Soga MOD End */

        sql.append(" FROM");
        sql.append(" " + Tbj26LogSozaiKanriList.TBNAME + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TBNAME + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.TBNAME + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj20CarCategory.TBNAME + ",");
        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + ConvertToDBNullString(_cond.getTempCmCd()) + " AND");
        /** 2016/02/25 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.TITLE + " = " + ConvertToDBNullString(_cond.getTitle()) + " AND");
        /** 2016/02/25 HDX対応 HLC K.Soga DEL End */
        sql.append(" TO_CHAR(" + Tbj26LogSozaiKanriList.SOZAIYM + ", 'YYYYMM') = " + ConvertToDBNullString(_cond.getYmDate()) + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + ConvertToDBNullString(_cond.getRecKbn()) + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Mbj05Car.DCARCD  + " = " + Mbj22CategoryContent.DCARCD + "(+) AND");
        sql.append(" " + Mbj22CategoryContent.PHASE + "(+) = " + getDBModelInterface().ConvertToDBString(_cond.getPhase()) + " AND");
        sql.append(" " + Mbj22CategoryContent.PHASE  + " = " + Mbj20CarCategory.PHASE + "(+) AND");
        sql.append(" " + Mbj22CategoryContent.CATEGORYNO  + " = " + Mbj20CarCategory.CATEGORYNO + "(+) AND");
        sql.append(" " + Mbj12Code.CODETYPE + "(+) = '" + HAMConstants.CODETYPE_HISTORYNM + "' AND");
        /** 2016/02/26 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN);
        sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj44LogSozaiKanriListCmn.DCARCD + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = " + Tbj44LogSozaiKanriListCmn.SOZAIYM + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj44LogSozaiKanriListCmn.RECKBN + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + " = " + Tbj44LogSozaiKanriListCmn.HISTORYNO + "(+) AND");
        if(_cond.getTempCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + "(+) AND");
            }
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj45LogSozaiKanriListCmnOA.DCARCD + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = TO_CHAR(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + "(+), 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj45LogSozaiKanriListCmnOA.RECKBN + "(+) AND");
        if(_cond.getTempCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + Tbj45LogSozaiKanriListCmnOA.TEMPCMCD + "(+) AND");
            }
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYKBN + " = " + Tbj45LogSozaiKanriListCmnOA.HISTORYKBN + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + " = " + Tbj45LogSozaiKanriListCmnOA.HISTORYNO + "(+)");
        /** 2016/02/26 HDX対応 HLC K.Soga MOD End */
        /** 2016/02/26 HDX対応 HLC K.Soga DEL Start */
//        //手作成素材
//        sql.append(" UNION ALL");
//        sql.append(" SELECT");
//        sql.append(" 3 SEQ,");
//        sql.append(" " + Mbj12Code.CODENAME + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + ",");
//        sql.append(" " + Mbj20CarCategory.CATEGORYNM + ",");
//        sql.append(" " + Mbj05Car.CARNM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SECOND + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.RCODE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.NEWFLG + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.TITLE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.TIMEUSE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SPOTUSE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SPOTCTRT + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SPOTSPAN + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SPOTESTM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.LIMIT + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.BIKO + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.SYATAN + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.ESTIMATE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.DATETO + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CRTNM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CRTAPL + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CRTID + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.CRTDATE + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.UPDNM + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.UPDDATE + ",");
//        /** 2016/02/25 HDX対応 HLC K.Soga MOD Start */
//        //sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO);
//        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.OPENFLG + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.NEWDISPFLG + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM_ATTR + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.DATETO_ATTR + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.HCSYATAN + ",");
//        sql.append(" " + Tbj26LogSozaiKanriList.HMSYATAN + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.ALIASTITLE + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.ENDTITLE + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.TIMEUSE + " HDXTIMEUSE,");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.BSCSUSE + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTUSE + " HDXSPOTUSE,");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTFROM + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTTO + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.HMORDER + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.LAYOUTORDER + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OANGSPAN + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.TARGET + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.CARNEWS + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.NEXTCARNEWS + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
//        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.OADATETERM);
//        /** 2016/02/25 HDX対応 HLC K.Soga MOD End */
//
//        sql.append(" FROM");
//        sql.append(" " + Tbj26LogSozaiKanriList.TBNAME + ",");
//        /** 2016/02/25 HDX対応 HLC K.Soga ADD Start */
//        sql.append(" " + Tbj44LogSozaiKanriListCmn.TBNAME + ",");
//        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.TBNAME + ",");
//        /** 2016/02/25 HDX対応 HLC K.Soga ADD End */
//        sql.append(" " + Mbj05Car.TBNAME + ",");
//        sql.append(" " + Mbj20CarCategory.TBNAME + ",");
//        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
//        sql.append(" " + Mbj12Code.TBNAME);
//
//        sql.append(" WHERE");
//        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " IS NULL AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " IS NULL AND");
//        /** 2016/02/25 HDX対応 HLC K.Soga DEL Start */
//        //sql.append(" " + Tbj26LogSozaiKanriList.TITLE + " = " + ConvertToDBNullString(_cond.getTitle()) + " AND");
//        /** 2016/02/25 HDX対応 HLC K.Soga DEL End */
//        sql.append(" TO_CHAR(" + Tbj26LogSozaiKanriList.SOZAIYM + ", 'YYYYMM') = " + ConvertToDBNullString(_cond.getYmDate()) + " AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + ConvertToDBNullString(_cond.getRecKbn()) + " AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
//        sql.append(" " + Mbj05Car.DCARCD  + " = " + Mbj22CategoryContent.DCARCD + "(+) AND");
//        sql.append(" " + Mbj22CategoryContent.PHASE + "(+) = " + getDBModelInterface().ConvertToDBString(_cond.getPhase()) + " AND");
//        sql.append(" " + Mbj22CategoryContent.PHASE  + " = " + Mbj20CarCategory.PHASE + "(+) AND");
//        sql.append(" " + Mbj22CategoryContent.CATEGORYNO  + " = " + Mbj20CarCategory.CATEGORYNO + "(+) AND");
//        sql.append(" " + Mbj12Code.CODETYPE + "(+) = '" + HAMConstants.CODETYPE_HISTORYNM + "' AND");
//        /** 2016/02/26 HDX対応 HLC K.Soga MOD Start */
//        //sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN);
//        sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN + " AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj44LogSozaiKanriListCmn.DCARCD + "(+) AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = " + Tbj44LogSozaiKanriListCmn.SOZAIYM + "(+) AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj44LogSozaiKanriListCmn.RECKBN + "(+) AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + " = " + Tbj44LogSozaiKanriListCmn.HISTORYNO + "(+) AND");
//        if(_cond.getCmCd().length() != 0){
//            sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = " + Tbj44LogSozaiKanriListCmn.CMCD + "(+) AND");
//            }
//        if(_cond.getTempCmCd().length() != 0){
//            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + "(+) AND");
//            }
//        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj45LogSozaiKanriListCmnOA.DCARCD + "(+) AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = TO_CHAR(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + "(+), 'YYYY/MM/DD') AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj45LogSozaiKanriListCmnOA.RECKBN + "(+) AND");
//        if(_cond.getCmCd().length() != 0){
//            sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = " + Tbj45LogSozaiKanriListCmnOA.CMCD + "(+) AND");
//            }
//        if(_cond.getTempCmCd().length() != 0){
//            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + Tbj45LogSozaiKanriListCmnOA.TEMPCMCD + "(+) AND");
//            }
//        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYKBN + " = " + Tbj45LogSozaiKanriListCmnOA.HISTORYKBN + "(+) AND");
//        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + " = " + Tbj45LogSozaiKanriListCmnOA.HISTORYNO + "(+)");
//        /** 2016/02/26 HDX対応 HLC K.Soga MOD End */

        //本素材(仮素材⇒本素材)
        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" 4 SEQ,");
        sql.append(" " + Mbj12Code.CODENAME + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + ",");
        sql.append(" " + Mbj20CarCategory.CATEGORYNM + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTUSE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.LIMIT + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SYATAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATETO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDDATE + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO);
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.OPENFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATETO_ATTR + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HCSYATAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HMSYATAN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.ALIASTITLE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.ENDTITLE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TIMEUSE + " HDXTIMEUSE,");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.BSCSUSE + ",");;
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTUSE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTFROM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.SPOTTO + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.HMORDER + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.LAYOUTORDER + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OANGSPAN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TARGET + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.CARNEWS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.NEXTCARNEWS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MVCHL + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MXTV + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_FMJPN + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_WTCC + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER1 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER2 + ",");
        sql.append(" " + Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER3 + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.OADATETERM);
        /** 2016/02/25 HDX対応 HLC K.Soga MOD End */

        sql.append(" FROM");
        sql.append(" " + Tbj26LogSozaiKanriList.TBNAME + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj44LogSozaiKanriListCmn.TBNAME + ",");
        sql.append(" " + Tbj45LogSozaiKanriListCmnOA.TBNAME + ",");
        /** 2016/02/25 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj20CarCategory.TBNAME + ",");
        sql.append(" " + Mbj22CategoryContent.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = " + ConvertToDBNullString(_cond.getCmCd()) + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + ConvertToDBNullString(_cond.getTempCmCd()) + " AND");
        /** 2016/02/25 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.TITLE + " = " + ConvertToDBNullString(_cond.getTitle()) + " AND");
        /** 2016/02/25 HDX対応 HLC K.Soga DEL End */
        sql.append(" TO_CHAR(" + Tbj26LogSozaiKanriList.SOZAIYM + ", 'YYYYMM') = " + ConvertToDBNullString(_cond.getYmDate()) + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + ConvertToDBNullString(_cond.getRecKbn()) + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Mbj05Car.DCARCD  + " = " + Mbj22CategoryContent.DCARCD + "(+) AND");
        sql.append(" " + Mbj22CategoryContent.PHASE + "(+) = " + getDBModelInterface().ConvertToDBString(_cond.getPhase()) + " AND");
        sql.append(" " + Mbj22CategoryContent.PHASE  + " = " + Mbj20CarCategory.PHASE + "(+) AND");
        sql.append(" " + Mbj22CategoryContent.CATEGORYNO  + " = " + Mbj20CarCategory.CATEGORYNO + "(+) AND");
        sql.append(" " + Mbj12Code.CODETYPE + "(+) = '" + HAMConstants.CODETYPE_HISTORYNM + "' AND");
        /** 2016/02/26 HDX対応 HLC K.Soga MOD Start */
        //sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN);
        sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj26LogSozaiKanriList.HISTORYKBN + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj44LogSozaiKanriListCmn.DCARCD + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = " + Tbj44LogSozaiKanriListCmn.SOZAIYM + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj44LogSozaiKanriListCmn.RECKBN + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + " = " + Tbj44LogSozaiKanriListCmn.HISTORYNO + "(+) AND");
        if(_cond.getCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = " + Tbj44LogSozaiKanriListCmn.CMCD + "(+) AND");
        }
        if(_cond.getTempCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + Tbj44LogSozaiKanriListCmn.TEMPCMCD + "(+) AND");
        }
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj45LogSozaiKanriListCmnOA.DCARCD + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = TO_CHAR(" + Tbj45LogSozaiKanriListCmnOA.SOZAIYM + "(+), 'YYYY/MM/DD') AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj45LogSozaiKanriListCmnOA.RECKBN + "(+) AND");
        if(_cond.getCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.CMCD + " = " + Tbj45LogSozaiKanriListCmnOA.CMCD + "(+) AND");
        }
        if(_cond.getTempCmCd().length() != 0){
            sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = " + Tbj45LogSozaiKanriListCmnOA.TEMPCMCD + "(+) AND");
        }
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYKBN + " = " + Tbj45LogSozaiKanriListCmnOA.HISTORYKBN + "(+) AND");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + " = " + Tbj45LogSozaiKanriListCmnOA.HISTORYNO + "(+)");
        /** 2016/02/26 HDX対応 HLC K.Soga MOD End */

        sql.append(" ORDER BY");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO);
        /** 2015/12/8 JASRAC対応 HLC K.Soga MOD End */

        return sql.toString();
    }

    /**
     * 特定年月の素材一覧を削除するSQLを取得
     * @return
     */
    private String getExecSQLForDeleteMaterialListBySpecificYM() {

        StringBuffer sql = new StringBuffer();

        sql.append("DELETE ");
        sql.append(" FROM " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" WHERE TO_CHAR(" + Tbj20SozaiKanriList.SOZAIYM + ",'YYYYMM') = '" + _cond.getYmDate() + "'");

        return sql.toString();
    }

    /**
     * 素材一覧登録SQL取得
     * @return
     */
    private String getExecSQLForRegistMaterialList() {

        StringBuffer sql = new StringBuffer();

        sql.append("INSERT");
        sql.append(" INTO " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" (");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        /** 2015/12/08 JASRAC対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        /** 2015/12/08 JASRAC対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + ",");
        /** 2016/03/25 HDX対応 HLC K.Oki DEL Start */
        //sql.append(" " + Tbj20SozaiKanriList.SYATAN + ",");
        /** 2016/03/25 HDX対応 HLC K.Oki DEL Start */
        sql.append(" " + Tbj20SozaiKanriList.BIKO + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + ",");
        /** 2016/03/25 HDX対応 HLC K.Oki MOD Start */
        //sql.append(" " + Tbj20SozaiKanriList.UPDID);

        sql.append(" " + Tbj20SozaiKanriList.UPDID + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO_ATTR);
        /** 2016/03/25 HDX対応 HLC K.Oki MOD End */
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" '" + _mateListVo.getDCARCD() + "',");
        sql.append(" " + getDBModelInterface().ConvertToDBString(_mateListVo.getSOZAIYM()) + ",");
        sql.append(" '" + _mateListVo.getRECKBN() + "',");
        sql.append(" (SELECT TO_CHAR(NVL(MAX(" + Tbj20SozaiKanriList.RECNO + "),0) + 1,'FM0000')");
        sql.append(" FROM " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" WHERE " + Tbj20SozaiKanriList.DCARCD + " = " + "'" + _mateListVo.getDCARCD() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_mateListVo.getSOZAIYM()) + " AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = " + "'" + _mateListVo.getRECKBN() + "'");
        sql.append(" ),");
        sql.append(" ' ',");
        sql.append(" '" + _mateListVo.getCMCD() + "',");
        /** 2015/12/8 JASRAC対応 HLC K.Soga ADD Start */
        sql.append(" '" + _mateListVo.getTEMPCMCD() + "',");
        /** 2015/12/8 JASRAC対応 HLC K.Soga ADD End */
        sql.append(" '" + _mateListVo.getTITLE() + "',");
        sql.append(" '" + _mateListVo.getSECOND() + "',");
        sql.append(" '" + _mateListVo.getRCODE() + "',");
        sql.append(" '" + _mateListVo.getESTIMATE() + "',");
        sql.append(" " + ConvertToDBNullString(_mateListVo.getDATEFROM()) + ",");
        sql.append(" " + ConvertToDBNullString(_mateListVo.getDATETO()) + ",");
        sql.append(" '" + _mateListVo.getNEWFLG() + "',");
        sql.append(" '" + _mateListVo.getTIMEUSE() + "',");
        sql.append(" '" + _mateListVo.getSPOTUSE() + "',");
        sql.append(" '" + _mateListVo.getSPOTCTRT() + "',");
        sql.append(" '" + _mateListVo.getSPOTSPAN() + "',");
        sql.append(" '" + _mateListVo.getSPOTESTM() + "',");
        sql.append(" " + ConvertToDBNullString(_mateListVo.getLIMIT()) + ",");
        /** 2016/03/25 HDX対応 HLC K.Oki DEL Start */
        //sql.append(" '" + _mateListVo.getSYATAN() + "',");
        /** 2016/03/25 HDX対応 HLC K.Oki DEL End */

        /** 2016/03/09 HDX対応 HLC K.Soga ADD Start */
//        sql.append(" '" + _mateListVo.getHCSYATAN() + "',");
//        sql.append(" '" + _mateListVo.getHMSYATAN() + "',");
        /** 2016/03/09 HDX対応 HLC K.Soga ADD End */
        sql.append(" '" + _mateListVo.getBIKO() + "',");
        sql.append(" SYSDATE,");
        sql.append(" '" + _mateListVo.getCRTNM() + "',");

        /** 2016/03/25 HDX対応 HLC K.Oki MOD Start */
        //sql.append(" SYSDATE,");
        //sql.append(" '" + _mateListVo.getUPDNM() + "',");
        //sql.append(" '" + _mateListVo.getUPDAPL() + "',");
        //sql.append(" '" + _mateListVo.getUPDID() + "'");
        //sql.append(" FROM DUAL");

        sql.append(" '" + _mateListVo.getCRTAPL() + "',");
        sql.append(" '" + _mateListVo.getCRTID() + "',");
        sql.append(" SYSDATE,");
        sql.append(" '" + _mateListVo.getUPDNM() + "',");
        sql.append(" '" + _mateListVo.getUPDAPL() + "',");
        sql.append(" '" + _mateListVo.getUPDID() + "',");
        sql.append(" '" + _mateListVo.getNEWDISPFLG() + "',");
        sql.append(" '" + _mateListVo.getOPENFLG() + "',");
        sql.append(" '" + _mateListVo.getDATEFROM_ATTR() + "',");
        sql.append(" '" + _mateListVo.getDATETO_ATTR() + "'");
        sql.append(" FROM DUAL");
        /** 2016/03/25 HDX対応 HLC K.Oki MOD Start */

        return sql.toString();
    }

    /**
     * 素材一覧更新SQL取得
     * @return
     */
    private String getExecSQLForUpdateMaterialList() {

        StringBuffer sql = new StringBuffer();

        sql.append("UPDATE");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" SET");
        if (_mateListVo.getDELFLG() == null || _mateListVo.getDELFLG().length() <= 0)
            sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ',");
        else
            sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = '" + _mateListVo.getDELFLG() + "',");
        if (!_mateListVo.getPrevDCarCd().equals(_mateListVo.getDCARCD())) {
            sql.append(" " + Tbj20SozaiKanriList.RECNO + " = (");
            sql.append("SELECT");
            sql.append(" TO_CHAR(NVL(MAX(" + Tbj20SozaiKanriList.RECNO + "), 0) + 1,'FM0000')");

            sql.append(" FROM");
            sql.append(" " + Tbj20SozaiKanriList.TBNAME);

            sql.append(" WHERE");
            sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = '" + _mateListVo.getDCARCD() + "' AND");
            sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_mateListVo.getSOZAIYM()) + " AND");
            sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = '" + _mateListVo.getRECKBN() + "'");
            sql.append(" ),");
        }
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = '" + _mateListVo.getDCARCD() + "',");
        sql.append(" " + Tbj20SozaiKanriList.ESTIMATE + " = '" + _mateListVo.getESTIMATE() + "',");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + " = " + ConvertToDBNullString(_mateListVo.getDATEFROM()) + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO + " = " + ConvertToDBNullString(_mateListVo.getDATETO()) + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + " = '" + _mateListVo.getCMCD() + "',");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + " = '" + _mateListVo.getSECOND() + "',");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + " = '" + _mateListVo.getRCODE() + "',");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + " = '" + _mateListVo.getNEWFLG() + "',");
        sql.append(" " + Tbj20SozaiKanriList.TITLE + " = '" + _mateListVo.getTITLE() + "',");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + " = '" + _mateListVo.getTIMEUSE() + "',");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + " = '" + _mateListVo.getSPOTUSE() + "',");
        sql.append(" " + Tbj20SozaiKanriList.SPOTCTRT + " = '" + _mateListVo.getSPOTCTRT() + "',");
        sql.append(" " + Tbj20SozaiKanriList.SPOTSPAN + " = '" + _mateListVo.getSPOTSPAN() + "',");
        sql.append(" " + Tbj20SozaiKanriList.SPOTESTM + " = '" + _mateListVo.getSPOTESTM() + "',");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + " = " + ConvertToDBNullString(_mateListVo.getLIMIT()) + ",");
        /** 2016/02/24 HDX対応 HLC K.Soga ADD Start */
        //sql.append(" " + Tbj20SozaiKanriList.SYATAN + " = '" + _mateListVo.getSYATAN() + "',");
        /** 2016/02/24 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.BIKO + " = '" + _mateListVo.getBIKO() + "',");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + " = SYSDATE,");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + " = '" + _mateListVo.getUPDNM() + "',");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + " = '" + _mateListVo.getUPDAPL() + "',");
        sql.append(" " + Tbj20SozaiKanriList.UPDID + " = '" + _mateListVo.getUPDID() + "',");
        /** 2016/02/24 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM_ATTR + " = '" + _mateListVo.getDATEFROM_ATTR() + "',");
        sql.append(" " + Tbj20SozaiKanriList.DATETO_ATTR + " = '" + _mateListVo.getDATETO_ATTR() + "',");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + " = '" + _mateListVo.getOPENFLG() + "',");
        sql.append(" " + Tbj20SozaiKanriList.NEWDISPFLG + " = '" + _mateListVo.getNEWDISPFLG() + "'");
        /** 2016/02/24 HDX対応 HLC K.Soga ADD End */
        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = '" + _mateListVo.getPrevDCarCd() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_mateListVo.getSOZAIYM()) + " AND");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = '" + _mateListVo.getRECKBN() + "' AND");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + " = '" + _mateListVo.getRECNO() + "'");

        return sql.toString();
    }

    /**
     * 素材一覧更新SQL取得
     */
    private String getExecSQLForUpdateMaterialFromRegisterToList() {
        StringBuffer sql = new StringBuffer();

        sql.append("UPDATE " + Tbj20SozaiKanriList.TBNAME + " A");
        if (_mateListVo.getDELFLG() == null || _mateListVo.getDELFLG().length() <= 0)
            sql.append("   SET A." + Tbj20SozaiKanriList.DELFLG + " = ' '");
        else
            sql.append("   SET A." + Tbj20SozaiKanriList.DELFLG + " = '" + _mateListVo.getDELFLG() + "'");
        sql.append("      ,A." + Tbj20SozaiKanriList.DCARCD + " = '" + _mateListVo.getDCARCD() + "'");
        sql.append("      ,A." + Tbj20SozaiKanriList.RECNO + " = CASE WHEN A." + Tbj20SozaiKanriList.DCARCD + " != '" + _mateListVo.getPrevDCarCd() + "' THEN " );
        sql.append("           (");
        sql.append("           SELECT TO_CHAR(NVL(MAX(" + Tbj20SozaiKanriList.RECNO + "),0) + 1,'FM0000') ");
        sql.append("             FROM " + Tbj20SozaiKanriList.TBNAME + " C");
        sql.append("            WHERE C." + Tbj20SozaiKanriList.DCARCD + " = '" + _mateListVo.getPrevDCarCd() + "'");
        sql.append("              AND C." + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(_mateListVo.getSOZAIYM()));
        sql.append("              AND C." + Tbj20SozaiKanriList.RECKBN + " = '" + _mateListVo.getRECKBN() + "'");
        sql.append("            )");
        sql.append("        ELSE A." + Tbj20SozaiKanriList.RECNO);
        sql.append("       END");
        sql.append("      ,A." + Tbj20SozaiKanriList.SECOND + " = '" + _mateListVo.getSECOND() + "'");
        sql.append("      ,A." + Tbj20SozaiKanriList.TITLE + " = '" + _mateListVo.getTITLE() + "'");
        /** 2015/12/8 JASRAC対応 HLC K.Soga DEL Start */
        //sql.append("      ,A." + Tbj20SozaiKanriList.SYATAN + " = '" + _mateListVo.getSYATAN() + "'");
        /** 2015/12/8 JASRAC対応 HLC K.Soga DEL End */
        sql.append("      ,A." + Tbj20SozaiKanriList.UPDDATE + " = SYSDATE");
        sql.append("      ,A." + Tbj20SozaiKanriList.UPDNM + " = '" + _cond.getHamNm() + "'");
        sql.append("      ,A." + Tbj20SozaiKanriList.UPDAPL + " = '" + _cond.getFormid() + "'");
        sql.append("      ,A." + Tbj20SozaiKanriList.UPDID + " = '" + _cond.getHamid() + "'");
        sql.append(" WHERE A." + Tbj20SozaiKanriList.CMCD + " = '" + _mateListVo.getCMCD() + "'");
        sql.append("   AND A." + Tbj20SozaiKanriList.DCARCD + " = '" + _mateListVo.getDCARCD() + "'");
        sql.append("   AND TO_CHAR(A." + Tbj20SozaiKanriList.SOZAIYM + ",'YYYYMM') = '" + _cond.getYmDate() + "'");
        sql.append("   AND A." + Tbj20SozaiKanriList.RECKBN + " = '" + _mateListVo.getRECKBN() + "'");
        sql.append("   AND A." + Tbj20SozaiKanriList.RECNO + " = '" + _mateListVo.getRECNO() + "'");

        return sql.toString();
    }

    /**
     * 素材一覧ログを作成するSQLを取得
     * @return
     */
    private String getExecSQLForInsertMaterialListLog() {

        Tbj26LogSozaiKanriListVO vo = (Tbj26LogSozaiKanriListVO)super.getModel();
        StringBuffer sql = new StringBuffer();

        sql.append("INSERT");
        sql.append(" INTO " + Tbj26LogSozaiKanriList.TBNAME);
        sql.append(" (");
        sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYNO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.HISTORYKBN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CMCD + ",");
        /** 2015/12/8 JASRAC対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + ",");
        /** 2015/12/8 JASRAC対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj26LogSozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATETO + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTUSE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.LIMIT + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.SYATAN + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga DEL End */
        sql.append(" " + Tbj26LogSozaiKanriList.BIKO + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj26LogSozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.DATETO_ATTR + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.OPENFLG + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj26LogSozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDAPL + ",");
        sql.append(" " + Tbj26LogSozaiKanriList.UPDID);
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" (SELECT NVL(MAX(" + Tbj26LogSozaiKanriList.HISTORYNO + "),0) + 1");
        sql.append(" FROM " + Tbj26LogSozaiKanriList.TBNAME);
        sql.append(" WHERE " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj20SozaiKanriList.DCARCD + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = " + Tbj20SozaiKanriList.SOZAIYM + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj20SozaiKanriList.RECKBN + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECNO + " = " + Tbj20SozaiKanriList.RECNO);
        sql.append(" ),");
        sql.append(" '" + vo.getHISTORYKBN() + "',");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        /** 2015/12/8 JASRAC対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        /** 2015/12/8 JASRAC対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.TITLE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.ESTIMATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.TIMEUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTCTRT + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTSPAN + ",");
        sql.append(" " + Tbj20SozaiKanriList.SPOTESTM + ",");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga ADD Start */
        //sql.append(" " + Tbj20SozaiKanriList.SYATAN + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.BIKO + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj20SozaiKanriList.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.DATETO_ATTR + ",");
        sql.append(" " + Tbj20SozaiKanriList.NEWDISPFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.OPENFLG + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.CRTDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.CRTID + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDID);

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);
        StringBuffer sbWhere = new StringBuffer();
        if (vo.getDCARCD() != null) {
            sbWhere.append(" " + Tbj20SozaiKanriList.DCARCD + " = " + ConvertToDBNullString(vo.getDCARCD()));
        }
        if (vo.getSOZAIYM() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + ConvertToDBNullString(vo.getSOZAIYM()));
        }
        if (vo.getRECKBN() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj20SozaiKanriList.RECKBN + " = " + ConvertToDBNullString(vo.getRECKBN()));
        }
        if (vo.getRECNO() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj20SozaiKanriList.RECNO + " = " + ConvertToDBNullString(vo.getRECNO()));
        }
        /** 2014/10/30 マスタ追加対応 HLC K.Soga ADD Start */
        if (vo.getCMCD() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND");
            sbWhere.append(" " + Tbj20SozaiKanriList.CMCD + " = " + ConvertToDBNullString(vo.getCMCD()));
        }
        /** 2014/10/30 マスタ追加対応 HLC K.Soga ADD End */

        if (sbWhere.length() > 0) {
            sql.append(" WHERE");
            sql.append(" " + sbWhere.toString());
        }

        return sql.toString();
    }

    /**
     * HC/HM担当者検索SQLを作成する
     * @return String HC/HM担当者検索SQL文
     */
    private String getSelectSQLFindSecGrpUser() {

        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" " + Mbj12Code.CODENAME + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" TRANSEC." + T_TransactionSecurity.TRANSACTIONNO + ",");
        sql.append(" USERINFO." + T_UserInfo.USERNAME + ",");
        sql.append(" SECGRP." + T_SecurityGroup.SECURITYGROUPCODE);

        sql.append(" FROM");
        sql.append(" " + T_TransactionSecurity.TBNAME + " TRANSEC,");
        sql.append(" " + T_UserInfo.TBNAME + " USERINFO,");
        sql.append(" " + T_SecurityGroup.TBNAME + " SECGRP,");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" TRANSEC." + T_TransactionSecurity.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.MENUTABCODE + " = '" + HAMConstants.MENUTABCODE_HDX + "' AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.USERID + " = USERINFO." + T_UserInfo.USERID + " AND");
        sql.append(" USERINFO." + T_UserInfo.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" USERINFO." + T_UserInfo.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND");
        sql.append(" USERINFO." + T_UserInfo.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" USERINFO." + T_UserInfo.SECURITYGROUPCODE + " = SECGRP." + T_SecurityGroup.SECURITYGROUPCODE + " AND");
        sql.append(" SECGRP." + T_SecurityGroup.DELETEFLG + " = '" + HAMConstants.ZERO + "' AND");
        sql.append(" SECGRP." + T_SecurityGroup.SYSTEMID + " = '" + HAMConstants.SYSTEMID_HDX + "' AND");
        sql.append(" SECGRP." + T_SecurityGroup.CLIENTSBT + " = '" + HAMConstants.CLIENTSBT_HDX + "' AND");
        sql.append(" SECGRP." + T_SecurityGroup.SECURITYGROUPCODE + " = " + Mbj12Code.YOBI1 + "(+) AND");
        sql.append(" TRANSEC." + T_TransactionSecurity.TRANSACTIONNO + " = " + Mbj05Car.DCARCD + "(+)");

        return sql.toString();
    };
    /** 2016/02/26 HDX対応 HLC K.Soga ADD End */

    /**
     * 車種変換マスタを作成するSQLを取得
     * @return
     */
    private String getExecSQLForInsertCarConvert() {

        Mbj38CarConvertVO vo = (Mbj38CarConvertVO)super.getModel();
        StringBuffer sql = new StringBuffer();

        sql.append("INSERT");
        sql.append(" INTO " + Mbj38CarConvert.TBNAME);
        sql.append(" (");
        sql.append(" " + Mbj38CarConvert.PHASE + ",");
        sql.append(" " + Mbj38CarConvert.SOZAIYM + ",");
        sql.append(" " + Mbj38CarConvert.SOZAIKG + ",");
        sql.append(" " + Mbj38CarConvert.DCARCD + ",");
        sql.append(" " + Mbj38CarConvert.UPDDATE + ",");
        sql.append(" " + Mbj38CarConvert.UPDNM + ",");
        sql.append(" " + Mbj38CarConvert.UPDAPL + ",");
        sql.append(" " + Mbj38CarConvert.UPDID);
        sql.append(" )");

        sql.append(" SELECT");
        sql.append(" " + getDBModelInterface().ConvertToDBString(vo.getPHASE()) + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + getDBModelInterface().getSystemDateString() + ",");
        sql.append(" " + getDBModelInterface().ConvertToDBString(vo.getUPDNM()) + ",");
        sql.append(" " + getDBModelInterface().ConvertToDBString(vo.getUPDAPL()) + ",");
        sql.append(" " + getDBModelInterface().ConvertToDBString(vo.getUPDID()));

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(vo.getSOZAIYM()) + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" (" + Tbj20SozaiKanriList.TIMEUSE + " = '1' OR");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + " = '1') AND");
        sql.append(" NVL(" + Tbj20SozaiKanriList.RCODE + ", ' ') <> ' ' AND");

        /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD Start */
        sql.append(" (" + Tbj20SozaiKanriList.CMCD + " NOT LIKE '%" + HAMConstants.CMCODE_NOKBN_RADIO + "%' OR");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " NOT LIKE '" + HAMConstants.TEMPCMCODE_NOKBN_RADIO + "%')");
        /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD End */

        sql.append(" GROUP BY");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD);

        /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD Start */
        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + getDBModelInterface().ConvertToDBString(vo.getPHASE()) + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" " + getDBModelInterface().getSystemDateString() + ",");
        sql.append(" " + getDBModelInterface().ConvertToDBString(vo.getUPDNM()) + ",");
        sql.append(" " + getDBModelInterface().ConvertToDBString(vo.getUPDAPL()) + ",");
        sql.append(" " + getDBModelInterface().ConvertToDBString(vo.getUPDID()));

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = " + getDBModelInterface().ConvertToDBString(vo.getSOZAIYM()) + " AND");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = ' ' AND");
        sql.append(" (" + Tbj20SozaiKanriList.TIMEUSE + " = '1' OR");
        sql.append(" " + Tbj20SozaiKanriList.SPOTUSE + " = '1') AND");
        sql.append(" NVL(" + Tbj20SozaiKanriList.RCODE + ", ' ') <> ' ' AND");

        sql.append(" " + Tbj20SozaiKanriList.CMCD + " IS NULL AND");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " IS NULL");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD);
        /** 2016/1/18 JASRAC不具合対応 HLC K.Soga ADD End */

        return sql.toString();
    }

    /**
     * 素材一覧画面用の契約情報の検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MaterialListCntrctVO> findMaterialListForCntrctByCondition(MaterialListCondition cond) throws HAMException {

        super.setModel(new MaterialListCntrctVO());
        try {
            _SelSqlMode = SelSqlMode.ContentCntrct;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材一覧テーブルの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MaterialListVO> findMaterialListByCondition(MaterialListCondition cond) throws HAMException {

        super.setModel(new MaterialListVO());
        try {
            _SelSqlMode = SelSqlMode.MaterialList;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材登録テーブルの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MaterialListVO> findMaterialRegistByCondition(MaterialListCondition cond) throws HAMException {

        super.setModel(new MaterialListVO());
        try {
            _SelSqlMode = SelSqlMode.MaterialRegist;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * カテゴリマスタの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Mbj20CarCategoryVO> findCategoryMstByCondition(MaterialListCondition cond) throws HAMException {

        super.setModel(new Mbj20CarCategoryVO());
        try {
            _SelSqlMode = SelSqlMode.CategoryMst;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 車種マスタの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MaterialCarMstVO> findMaterialCarMstByCondition(MaterialListCondition cond) throws HAMException {

        super.setModel(new MaterialCarMstVO());
        try {
            _SelSqlMode = SelSqlMode.CarMst;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材一覧の主キー検索を行います(loadが思ったよりも使えないため)
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> findMaterialListByPrimaryKey(RegisterMaterialListUpdateVO vo) throws HAMException {

        super.setModel(new Tbj20SozaiKanriListVO());
        try {
            _SelSqlMode = SelSqlMode.MaterialListPk;
            this._mateListVo = vo;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材一覧ログ画面のデータを取得します
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<LogMaterialListVO> findLogMaterialListByCondition(MaterialListCondition cond) throws HAMException {

        super.setModel(new LogMaterialListVO());
        try {
            _SelSqlMode = SelSqlMode.LogMaterialList;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }
    /**
     * 特定のコンテンツテーブルを削除します
     * @param vo
     * @throws HAMException
     */
    public void deleteMaterialListSpecificYM(MaterialListCondition cond) throws HAMException {
        if (cond == null)
            throw new HAMException("削除エラー", "BJ-E0008");

        try {
            _cond = cond;
            _ExcSqlMode = ExcSqlMode.DeletePhaseMatterialList;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * 素材一覧テーブルに追加します
     * @param vo
     * @throws HAMException
     */
    public void registMaterialList(RegisterMaterialListUpdateVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("登録エラー", "BJ-E0008");

        try {
            _mateListVo = vo;
            _ExcSqlMode = ExcSqlMode.RegistMaterialList;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 素材一覧テーブルを更新します
     * @param vo
     * @throws HAMException
     */
    public void updateMaterialList(RegisterMaterialListUpdateVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("更新エラー", "BJ-E0008");

        try {
            _mateListVo = vo;
            _ExcSqlMode = ExcSqlMode.UpdateMaterialList;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * 素材登録と一覧をマージします
     * @param vo
     * @throws HAMException
     */
    public void mergeMaterialFromRegisterToList(MaterialListCondition cond) throws HAMException {
        if (cond == null)
            throw new HAMException("更新エラー", "BJ-E0008");

        super.setModel(new RegisterMaterialListUpdateVO());
        try {
            _cond = cond;
            _SelSqlMode = SelSqlMode.MaterialSozaiYm;
            for (Object vo : super.find()) {
                this._mateListVo = (RegisterMaterialListUpdateVO)vo;
                _ExcSqlMode = ExcSqlMode.MergeMaterialList;
                super.exec();

                _ExcSqlMode = ExcSqlMode.InsertMaterialListLog;
                super.setModel(this.getMaterialListLogVo(_mateListVo, HAMConstants.HISTORYKBN_UPDATE));
                super.exec();
            }
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * 素材一覧ログテーブルに追加します
     * @param vo
     * @throws HAMException
     */
    public void insertMaterialListLog(Tbj26LogSozaiKanriListVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("登録エラー", "BJ-E0008");

        super.setModel(vo);
        try {
            _ExcSqlMode = ExcSqlMode.InsertMaterialListLog;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * HC/HM担当者検索
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<HCHMSecGrpUserVO> findHCHMSecGrpUser( MaterialListCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new HCHMSecGrpUserVO());
        _SelSqlMode = SelSqlMode.SecGrpUser;
        _cond = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 車種変換マスタに追加します
     * @param vo
     * @throws HAMException
     */
    public void insertCarConvert(Mbj38CarConvertVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("登録エラー", "BJ-E0008");

        super.setModel(vo);
        try {
            _ExcSqlMode = ExcSqlMode.InsertCarConvert;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
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
        if (getModel() instanceof MaterialListCntrctVO) {
            list = new ArrayList<MaterialListCntrctVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                MaterialListCntrctVO vo = new MaterialListCntrctVO();
                vo.setCMCD(StringUtil.trim((String)result.get(Tbj17Content.CMCD.toUpperCase())));
                vo.setCTRTKBN(StringUtil.trim((String)result.get(Tbj16ContractInfo.CTRTKBN.toUpperCase())));
                vo.setCTRTNO(StringUtil.trim((String)result.get(Tbj16ContractInfo.CTRTNO.toUpperCase())));
                vo.setCTRTKBNNAME(StringUtil.trim((String)result.get("CTRTKBNNAME")));
                vo.setNAMES(StringUtil.trim((String)result.get(Tbj16ContractInfo.NAMES.toUpperCase())));
                vo.setDATEFROM(DateUtil.toDateForNull(result.get(Tbj16ContractInfo.DATEFROM.toUpperCase())));
                vo.setDATETO(DateUtil.toDateForNull(result.get(Tbj16ContractInfo.DATETO.toUpperCase())));
                vo.setMUSIC(StringUtil.trim((String)result.get(Tbj16ContractInfo.MUSIC.toUpperCase())));
                vo.setSALES(StringUtil.trim((String)result.get(Tbj16ContractInfo.SALEFLG.toUpperCase())));
                vo.setBIKO(StringUtil.trim((String)result.get(Tbj16ContractInfo.BIKO.toUpperCase())));
                vo.setCRTDATE(DateUtil.toDateForNull(result.get(Tbj16ContractInfo.CRTDATE.toUpperCase())));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get(Tbj16ContractInfo.UPDDATE.toUpperCase())));
                vo.setUPDNM(StringUtil.trim((String)result.get(Tbj16ContractInfo.UPDNM.toUpperCase())));
                vo.setUPDAPL(StringUtil.trim((String)result.get(Tbj16ContractInfo.UPDAPL.toUpperCase())));
                vo.setUPDID(StringUtil.trim((String)result.get(Tbj16ContractInfo.UPDID.toUpperCase())));
                vo.setDCARCD(StringUtil.trim((String)result.get(Tbj16ContractInfo.DCARCD.toUpperCase())));
                vo.setCATEGORY(StringUtil.trim((String)result.get(Tbj16ContractInfo.CATEGORY.toUpperCase())));
                vo.setJASRAC(StringUtil.trim((String)result.get(Tbj16ContractInfo.JASRACFLG.toUpperCase())));
                vo.setCONCRTDATE(DateUtil.toDateForNull(result.get(Tbj17Content.CRTDATE.toUpperCase())));
                vo.setCONUPDDATE(DateUtil.toDateForNull(result.get(Tbj17Content.UPDDATE.toUpperCase())));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if ((getModel() instanceof MaterialListVO)) {
            list = new ArrayList<MaterialListVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                MaterialListVO vo = new MaterialListVO();
                vo.setCATEGORY_SORTNO(StringUtil.toString((BigDecimal)result.get("CATEGORY_SORTNO")));
                vo.setCAR_SORTNO((BigDecimal)result.get("CAR_SORTNO"));
                vo.setDCARCD(StringUtil.trim(result.get(Tbj20SozaiKanriList.DCARCD.toUpperCase()).toString()));
                vo.setCATEGORYNO((BigDecimal)result.get(Mbj20CarCategory.CATEGORYNO.toUpperCase()));
                vo.setSOZAIYM(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.SOZAIYM.toUpperCase())));
                vo.setRECKBN(StringUtil.trim(result.get(Tbj20SozaiKanriList.RECKBN.toUpperCase()).toString()));
                vo.setRECNO(StringUtil.trim(result.get(Tbj20SozaiKanriList.RECNO.toUpperCase()).toString()));
                vo.setDELFLG(StringUtil.trim(result.get(Tbj20SozaiKanriList.DELFLG.toUpperCase()).toString()));
                vo.setCMCD(StringUtil.trim(result.get(Tbj20SozaiKanriList.CMCD.toUpperCase()).toString()));
                /** 2015/10/14 JASRAC対応 HLC K.Soga ADD Start */
                vo.setTEMPCMCD(StringUtil.trim(result.get(Tbj20SozaiKanriList.TEMPCMCD.toUpperCase()).toString()));
                vo.setNOKBN(StringUtil.trim(result.get("NOKBN").toString()));
                /** 2015/10/14 JASRAC対応 HLC K.Soga ADD End */
                /** 2016/02/18 HDX対応 HLC K.Soga ADD Start */
                //素材一覧データ取得の場合
                if(result.get("MATERIAL_REG_LIST_FLG").toString().equals(HAMConstants.MATERIAL_LIST)){
                    vo.setDATEFROM_ATTR(StringUtil.trim(result.get(Tbj20SozaiKanriList.DATEFROM_ATTR.toUpperCase()).toString()));
                    vo.setDATETO_ATTR(StringUtil.trim(result.get(Tbj20SozaiKanriList.DATETO_ATTR.toUpperCase()).toString()));
                    vo.setNEWDISPFLG(StringUtil.trim(result.get(Tbj20SozaiKanriList.NEWDISPFLG.toUpperCase()).toString()));
                    vo.setOPENFLG(StringUtil.trim(result.get(Tbj20SozaiKanriList.OPENFLG.toUpperCase()).toString()));
                    vo.setHCSYATAN(StringUtil.trim(result.get(Tbj20SozaiKanriList.HCSYATAN.toUpperCase()).toString()));
                    vo.setHMSYATAN(StringUtil.trim(result.get(Tbj20SozaiKanriList.HMSYATAN.toUpperCase()).toString()));
                    vo.setALIASTITLE(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.ALIASTITLE.toUpperCase()).toString()));
                    vo.setENDTITLE(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.ENDTITLE.toUpperCase()).toString()));
                    vo.setHDXTIMEUSE(StringUtil.trim(result.get("HDXTIMEUSE").toString()));
                    vo.setBSCSUSE(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.BSCSUSE.toUpperCase()).toString()));
                    vo.setHDXSPOTUSE(StringUtil.trim(result.get("HDXSPOTUSE").toString()));
                    vo.setSPOTFROM(DateUtil.toDateForNull(result.get(Tbj42SozaiKanriListCmn.SPOTFROM.toUpperCase())));
                    vo.setSPOTTO(DateUtil.toDateForNull(result.get(Tbj42SozaiKanriListCmn.SPOTTO.toUpperCase())));
                    /** 2016/03/29 HDX対応 HLC K.Oki ADD Start */
                    vo.setSPOTCTRT(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.SPOTCTRT.toUpperCase()).toString()));
                    /** 2016/03/29 HDX対応 HLC K.Oki ADD End */
                    vo.setHMORDER(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.HMORDER.toUpperCase()).toString()));
                    vo.setLAYOUTORDER(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.LAYOUTORDER.toUpperCase()).toString()));
                    vo.setOANGSPAN(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OANGSPAN.toUpperCase()).toString()));
                    vo.setTARGET(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.TARGET.toUpperCase()).toString()));
                    vo.setCARNEWS(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.CARNEWS.toUpperCase()).toString()));
                    vo.setNEXTCARNEWS(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.NEXTCARNEWS.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_MVCHL(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MVCHL.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_YOUTUBE(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_MXTV(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_MXTV.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_KYOSERADM(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_CIRCUITVS(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_FMJPN(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_FMJPN.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_WTCC(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_WTCC.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_OTHER1(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER1.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_OTHER2(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER2.toUpperCase()).toString()));
                    vo.setOTHERMEDIAUSE_OTHER3(StringUtil.trim(result.get(Tbj42SozaiKanriListCmn.OTHERMEDIAUSE_OTHER3.toUpperCase()).toString()));
                    vo.setOADATETERM(StringUtil.trim(result.get(Tbj43SozaiKanriListCmnOA.OADATETERM.toUpperCase()).toString()));
                //素材登録データ取得の場合
                }else{
                    vo.setALIASTITLE(StringUtil.trim(result.get(Tbj18SozaiKanriData.ALIASTITLE.toUpperCase()).toString()));
                    vo.setDATEFROM_ATTR(StringUtil.trim(result.get(Tbj18SozaiKanriData.DATEFROM_ATTR.toUpperCase()).toString()));
                    vo.setDATETO_ATTR(StringUtil.trim(result.get(Tbj18SozaiKanriData.DATETO_ATTR.toUpperCase()).toString()));
                    vo.setENDTITLE(StringUtil.trim(result.get(Tbj18SozaiKanriData.ENDTITLE.toUpperCase()).toString()));
                }
                /** 2016/02/18 HDX対応 HLC K.Soga ADD End */
                vo.setTITLE(StringUtil.trim(result.get(Tbj20SozaiKanriList.TITLE.toUpperCase()).toString()));
                vo.setSECOND(StringUtil.trim(result.get(Tbj20SozaiKanriList.SECOND.toUpperCase()).toString()));
                vo.setRCODE(StringUtil.trim(result.get(Tbj20SozaiKanriList.RCODE.toUpperCase()).toString()));
                vo.setESTIMATE((BigDecimal)result.get(Tbj20SozaiKanriList.ESTIMATE.toUpperCase()));
                vo.setDATEFROM(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.DATEFROM.toUpperCase())));
                vo.setDATETO(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.DATETO.toUpperCase())));
                vo.setCNTDATEFROM(DateUtil.toDateForNull(result.get("DATEFROM")));
                vo.setCNTDATETO(DateUtil.toDateForNull(result.get("DATETO")));
                vo.setNEWFLG(StringUtil.trim(result.get(Tbj20SozaiKanriList.NEWFLG.toUpperCase()).toString()));
                vo.setTIMEUSE(StringUtil.trim(result.get(Tbj20SozaiKanriList.TIMEUSE.toUpperCase()).toString()));
                vo.setSPOTUSE(StringUtil.trim(result.get(Tbj20SozaiKanriList.SPOTUSE.toUpperCase()).toString()));
                /** 2016/03/29 HDX対応 HLC K.Oki DEL Start */
                //vo.setSPOTCTRT(StringUtil.trim(result.get(Tbj20SozaiKanriList.SPOTCTRT.toUpperCase()).toString()));
                /** 2016/03/29 HDX対応 HLC K.Oki DEL End */
                vo.setSPOTSPAN(StringUtil.trim(result.get(Tbj20SozaiKanriList.SPOTSPAN.toUpperCase()).toString()));
                vo.setSPOTESTM((BigDecimal)result.get(Tbj20SozaiKanriList.SPOTESTM.toUpperCase()));
                vo.setLIMIT(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.LIMIT.toUpperCase())));
                vo.setSYATAN(StringUtil.trim(result.get(Tbj20SozaiKanriList.SYATAN.toUpperCase()).toString()));
                vo.setBIKO(StringUtil.trim(result.get(Tbj20SozaiKanriList.BIKO.toUpperCase()).toString()));
                vo.setCRTDATE(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.CRTDATE.toUpperCase())));
                vo.setCRTNM(StringUtil.trim(result.get(Tbj20SozaiKanriList.CRTNM.toUpperCase()).toString()));
                vo.setCRTAPL(StringUtil.trim(result.get(Tbj20SozaiKanriList.CRTAPL.toUpperCase()).toString()));
                vo.setCRTID(StringUtil.trim(result.get(Tbj20SozaiKanriList.CRTID.toUpperCase()).toString()));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.UPDDATE.toUpperCase())));
                vo.setUPDNM(StringUtil.trim(result.get(Tbj20SozaiKanriList.UPDNM.toUpperCase()).toString()));
                vo.setUPDAPL(StringUtil.trim(result.get(Tbj20SozaiKanriList.UPDAPL.toUpperCase()).toString()));
                vo.setUPDID(StringUtil.trim(result.get(Tbj20SozaiKanriList.UPDID.toUpperCase()).toString()));
                vo.setPrevDCarCd(StringUtil.trim(result.get("PREVDCARCD").toString()));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if ((getModel() instanceof RegisterMaterialListUpdateVO)) {
            list = new ArrayList<RegisterMaterialListUpdateVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                RegisterMaterialListUpdateVO vo = new RegisterMaterialListUpdateVO();
                vo.setDCARCD(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.DCARCD.toUpperCase())));
                vo.setSOZAIYM(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.SOZAIYM.toUpperCase())));
                vo.setRECKBN(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.RECKBN.toUpperCase())));
                vo.setRECNO(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.RECNO.toUpperCase())));
                vo.setDELFLG(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.DELFLG.toUpperCase())));
                vo.setCMCD(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.CMCD.toUpperCase())));
                vo.setTITLE(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.TITLE.toUpperCase())));
                vo.setSECOND(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.SECOND.toUpperCase())));
                vo.setRCODE(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.RCODE.toUpperCase())));
                vo.setESTIMATE((BigDecimal)result.get(Tbj20SozaiKanriList.ESTIMATE.toUpperCase()));
                vo.setDATEFROM(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.DATEFROM.toUpperCase())));
                vo.setDATETO(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.DATETO.toUpperCase())));
                vo.setNEWFLG(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.NEWFLG.toUpperCase())));
                vo.setTIMEUSE(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.TIMEUSE.toUpperCase())));
                vo.setSPOTUSE(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.SPOTUSE.toUpperCase())));
                vo.setSPOTCTRT(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.SPOTCTRT.toUpperCase())));
                vo.setSPOTSPAN(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.SPOTSPAN.toUpperCase())));
                vo.setSPOTESTM((BigDecimal)result.get(Tbj20SozaiKanriList.SPOTESTM.toUpperCase()));
                vo.setLIMIT(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.LIMIT.toUpperCase())));
                /** 2016/02/18 HDX対応 HLC K.Soga DEL Start */
                //vo.setSYATAN(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.SYATAN.toUpperCase())));
                /** 2016/02/18 HDX対応 HLC K.Soga DEL End */
                vo.setBIKO(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.BIKO.toUpperCase())));
                vo.setCRTDATE(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.CRTDATE.toUpperCase())));
                vo.setCRTNM(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.CRTNM.toUpperCase())));
                vo.setCRTAPL(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.CRTAPL.toUpperCase())));
                vo.setCRTID(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.CRTID.toUpperCase())));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.UPDDATE.toUpperCase())));
                vo.setUPDNM(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.UPDNM.toUpperCase())));
                vo.setUPDAPL(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.UPDAPL.toUpperCase())));
                vo.setUPDID(StringUtil.trim((String)result.get(Tbj20SozaiKanriList.UPDID.toUpperCase())));
                vo.setPrevDCarCd(StringUtil.trim((String)result.get("PREVDCARCD")));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if ((getModel() instanceof Tbj20SozaiKanriListVO)) {
            list = new ArrayList<Tbj20SozaiKanriListVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                Tbj20SozaiKanriListVO vo = new Tbj20SozaiKanriListVO();
                vo.setUPDDATE(DateUtil.toDateForNull(result.get(Tbj20SozaiKanriList.UPDDATE.toUpperCase())));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if (getModel() instanceof Mbj20CarCategoryVO) {
            list = new ArrayList<Mbj20CarCategoryVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                Mbj20CarCategoryVO vo = new Mbj20CarCategoryVO();

                vo.setPHASE((BigDecimal)result.get(Mbj20CarCategory.PHASE.toUpperCase()));
                vo.setCATEGORYNO((BigDecimal)result.get(Mbj20CarCategory.CATEGORYNO.toUpperCase()));
                vo.setCATEGORYNM((String)result.get(Mbj20CarCategory.CATEGORYNM.toUpperCase()));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }

        } else if ((getModel() instanceof MaterialCarMstVO)) {
            list = new ArrayList<MaterialCarMstVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                MaterialCarMstVO vo = new MaterialCarMstVO();
                vo.setDCARCD(StringUtil.trim((String)result.get(Mbj05Car.DCARCD.toUpperCase())));
                vo.setCARNM(StringUtil.trim((String)result.get(Mbj05Car.CARNM.toUpperCase())));
                vo.setPHASE((BigDecimal)result.get("PHASE"));
                vo.setCATEGORYNO((BigDecimal)result.get("CATEGORYNO"));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if ((getModel() instanceof LogMaterialListVO)) {
            list = new ArrayList<LogMaterialListVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                LogMaterialListVO vo = new LogMaterialListVO();
                vo.setHISTORYNM(StringUtil.trim(result.get("HISTORYNM").toString()));
                vo.setCATEGORYNM(StringUtil.trim(result.get(Mbj20CarCategory.CATEGORYNM.toUpperCase()).toString()));
                vo.setCARNM(StringUtil.trim(result.get(Mbj05Car.CARNM.toUpperCase()).toString()));
                vo.setCMCD(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.CMCD.toUpperCase()).toString()));
                /** 2015/10/14 JASRAC対応 HLC K.Soga ADD Start */
                vo.setTEMPCMCD(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.TEMPCMCD.toUpperCase()).toString()));
                /** 2015/10/14 JASRAC対応 HLC K.Soga ADD End */
                /** 2016/02/25 HDX対応 HLC K.Soga ADD Start */
                vo.setOPENFLG(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.OPENFLG.toUpperCase()).toString()));
                vo.setNEWDISPFLG(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.NEWDISPFLG.toUpperCase()).toString()));
                vo.setDATEFROM_ATTR(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.DATEFROM_ATTR.toUpperCase()).toString()));
                vo.setDATETO_ATTR(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.DATETO_ATTR.toUpperCase()).toString()));
                vo.setHCSYATAN(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.HCSYATAN.toUpperCase()).toString()));
                vo.setHMSYATAN(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.HMSYATAN.toUpperCase()).toString()));
                vo.setALIASTITLE(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.ALIASTITLE.toUpperCase()).toString()));
                vo.setENDTITLE(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.ENDTITLE.toUpperCase()).toString()));
                vo.setHDXTIMEUSE(StringUtil.trim(result.get("HDXTIMEUSE").toString()));
                vo.setBSCSUSE(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.BSCSUSE.toUpperCase()).toString()));
                vo.setHDXSPOTUSE(StringUtil.trim(result.get("HDXSPOTUSE").toString()));
                vo.setSPOTFROM(DateUtil.toDateForNull(result.get(Tbj44LogSozaiKanriListCmn.SPOTFROM.toUpperCase())));
                vo.setSPOTTO(DateUtil.toDateForNull(result.get(Tbj44LogSozaiKanriListCmn.SPOTTO.toUpperCase())));
                vo.setHMORDER(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.HMORDER.toUpperCase()).toString()));
                vo.setLAYOUTORDER(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.LAYOUTORDER.toUpperCase()).toString()));
                vo.setOANGSPAN(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OANGSPAN.toUpperCase()).toString()));
                vo.setTARGET(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.TARGET.toUpperCase()).toString()));
                vo.setCARNEWS(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.CARNEWS.toUpperCase()).toString()));
                vo.setNEXTCARNEWS(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.NEXTCARNEWS.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_MVCHL(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MVCHL.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_YOUTUBE(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_YOUTUBE.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_MXTV(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_MXTV.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_KYOSERADM(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_KYOSERADM.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_CIRCUITVS(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_CIRCUITVS.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_FMJPN(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_FMJPN.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_WTCC(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_WTCC.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_OTHER1(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER1.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_OTHER2(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER2.toUpperCase()).toString()));
                vo.setOTHERMEDIAUSE_OTHER3(StringUtil.trim(result.get(Tbj44LogSozaiKanriListCmn.OTHERMEDIAUSE_OTHER3.toUpperCase()).toString()));
                vo.setOADATETERM(StringUtil.trim(result.get(Tbj45LogSozaiKanriListCmnOA.OADATETERM.toUpperCase()).toString()));
                /** 2016/02/25 HDX対応 HLC K.Soga ADD End */
                vo.setSECOND(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.SECOND.toUpperCase()).toString()));
                vo.setRCODE(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.RCODE.toUpperCase()).toString()));
                vo.setNEWFLG(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.NEWFLG.toUpperCase()).toString()));
                vo.setTITLE(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.TITLE.toUpperCase()).toString()));
                vo.setTIMEUSE(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.TIMEUSE.toUpperCase()).toString()));
                vo.setSPOTUSE(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.SPOTUSE.toUpperCase()).toString()));
                vo.setSPOTCTRT(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.SPOTCTRT.toUpperCase()).toString()));
                vo.setSPOTSPAN(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.SPOTSPAN.toUpperCase()).toString()));
                vo.setSPOTESTM((BigDecimal)result.get(Tbj26LogSozaiKanriList.SPOTESTM.toUpperCase()));
                vo.setLIMIT(DateUtil.toDateForNull(result.get(Tbj26LogSozaiKanriList.LIMIT.toUpperCase())));
                vo.setBIKO(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.BIKO.toUpperCase()).toString()));
                vo.setSYATAN(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.SYATAN.toUpperCase()).toString()));
                vo.setESTIMATE((BigDecimal)result.get(Tbj26LogSozaiKanriList.ESTIMATE.toUpperCase()));
                vo.setDATEFROM(DateUtil.toDateForNull(result.get(Tbj26LogSozaiKanriList.DATEFROM.toUpperCase())));
                vo.setDATETO(DateUtil.toDateForNull(result.get(Tbj26LogSozaiKanriList.DATETO.toUpperCase())));
                vo.setCRTDATE(DateUtil.toDateForNull(result.get(Tbj26LogSozaiKanriList.CRTDATE.toUpperCase())));
                vo.setCRTNM(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.CRTNM.toUpperCase()).toString()));
                vo.setCRTAPL(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.CRTAPL.toUpperCase()).toString()));
                vo.setCRTID(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.CRTID.toUpperCase()).toString()));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get(Tbj26LogSozaiKanriList.UPDDATE.toUpperCase())));
                vo.setUPDNM(StringUtil.trim(result.get(Tbj26LogSozaiKanriList.UPDNM.toUpperCase()).toString()));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if ((getModel() instanceof HCHMSecGrpUserVO)) {
            list = new ArrayList<HCHMSecGrpUserVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                HCHMSecGrpUserVO vo = new HCHMSecGrpUserVO();
                vo.setTRANSACTIONNO(StringUtil.trim(result.get(T_TransactionSecurity.TRANSACTIONNO.toUpperCase()).toString()));
                vo.setUSERNAME(StringUtil.trim(result.get(T_UserInfo.USERNAME.toUpperCase()).toString()));
                vo.setSECURITYGROUPCODE(StringUtil.trim(result.get(T_SecurityGroup.SECURITYGROUPCODE.toUpperCase()).toString()));
                vo.setCARNM(StringUtil.trim(result.get(Mbj05Car.CARNM.toUpperCase()).toString()));
                vo.setCODENAME(StringUtil.trim(result.get(Mbj12Code.CODENAME.toUpperCase()).toString()));
                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        }
        return list;
    }

    private String ConvertToDBNullString(Object value) {
        return value == null ? "''" : getDBModelInterface().ConvertToDBString(value);
    }

    /**
     * 素材一覧ログ用VOを取得します
     * @param vo
     * @param actionName
     * @return
     */
    public Tbj26LogSozaiKanriListVO getMaterialListLogVo(Tbj20SozaiKanriListVO vo, String actionName) {
        Tbj26LogSozaiKanriListVO ret = new Tbj26LogSozaiKanriListVO();
        ret.setDCARCD(vo.getDCARCD());
        ret.setSOZAIYM(vo.getSOZAIYM());
        ret.setRECKBN(vo.getRECKBN());
        ret.setRECNO(vo.getRECNO());
        ret.setHISTORYKBN(actionName);

        return ret;
    }
}