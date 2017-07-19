package jp.co.isid.ham.production.model;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Map;

import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

import jp.co.isid.ham.common.model.Mbj38CarConvertVO;
import jp.co.isid.ham.common.model.Tbj18SozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj20SozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj25LogSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj26LogSozaiKanriListVO;
import jp.co.isid.ham.common.model.Tbj36TempSozaiKanriDataVO;
import jp.co.isid.ham.common.model.Tbj41LogTempSozaiKanriDataVO;
import jp.co.isid.ham.integ.tbl.Mbj05Car;
import jp.co.isid.ham.integ.tbl.Mbj12Code;
import jp.co.isid.ham.integ.tbl.Mbj38CarConvert;
import jp.co.isid.ham.integ.tbl.Mbj51Natural;
import jp.co.isid.ham.integ.tbl.T_SecurityGroup;
import jp.co.isid.ham.integ.tbl.T_TransactionSecurity;
import jp.co.isid.ham.integ.tbl.T_UserInfo;
import jp.co.isid.ham.integ.tbl.Tbj16ContractInfo;
import jp.co.isid.ham.integ.tbl.Tbj17Content;
import jp.co.isid.ham.integ.tbl.Tbj18SozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj20SozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj25LogSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj26LogSozaiKanriList;
import jp.co.isid.ham.integ.tbl.Tbj36TempSozaiKanriData;
import jp.co.isid.ham.integ.tbl.Tbj38RdProgramMaterial;
import jp.co.isid.ham.integ.tbl.Tbj40TempSozaiContent;
import jp.co.isid.ham.integ.tbl.Tbj41LogTempSozaiKanriData;
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
* 素材登録DAO<P>
* <B>修正履歴</B><BR>
* ・新規作成 HAMメンバー<BR>
* ・マスタ追加対応(2014/10/30 HLC K.Soga)<BR>
* ・素材登録不具合対応(2015/2/17 HLC K.Soga)<BR>
* ・JASRAC対応(2015/11/19 HLC K.Soga)<BR>
* ・HDX対応(2016/02/17 HLC K.Soga)<BR>
* </P>
* @author
*/
@XmlRootElement(namespace = "http://model.production.ham.isid.co.jp/")
@XmlType(namespace = "http://model.production.ham.isid.co.jp/")
public class MaterialRegisterDAO extends AbstractRdbDao {

    /** 検索用条件 */
    private MaterialRegisterCondition _cond = null;

    /** 検索用条件(エンコード表用) */
    private MaterialEncodeListCondition _encCond = null;

    /** 更新用VO(Tbj18) */
    private Tbj18SozaiKanriDataVO _transMateVo = null;

    /** 2015/11/16 JASRAC対応 HLC K.Soga ADD Start */
    /** 本素材・仮素材フラグ */
    private String _materialType = null;

    /** 削除用VO(Tbj36) */
    private Tbj36TempSozaiKanriDataVO _transTempMaterialVo = null;

    /** 更新用VO(Tbj38) */
    private UsedRdProgramMaterialVO _rdProgramMaterial = null;
    /** 2015/11/16 JASRAC対応 HLC K.Soga ADD End */

    /** 更新用VO(Tbj20) */
    private Tbj20SozaiKanriListVO _transMateListVo = null;

    /** SELECT-SQLモード */
    private enum SelSqlMode {
        ContentCntrct,
        Material,
        MaterialAdminList,
        LogMaterialRegister,
        CmCodeIssueDocs,
        MaterialEncodeList,
        UsedTempMaterial,
        /** 2016/02/29 HDX対応 HLC K.Soga ADD Start */
        SecGrpUser
        /** 2016/02/29 HDX対応 HLC K.Soga ADD End */
    };

    /** EXEC-SQLモード */
    private enum ExcSqlMode {
        UpdateDelMaterialList,
        UpdateMaterialList,
        DeleteContentAll,
        InsertMaterialRegisterLog,
        InsertMaterialListLog,
        /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD Start */
        InsertCarConvert,
        /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD End */
        /** 2015/11/16 JASRAC対応 HLC K.Soga ADD Start */
        DeleteTempMaterialContentAll,
        InsertTempMaterialRegisterLog,
        DeleteMaterialListAll,
        DeleteMaterialListLog,
        UpdateTempMaterial
        /** 2015/11/16 JASRAC対応 HLC K.Soga ADD End */
    };

    /** 選択SQLモード変数 */
    private SelSqlMode _SelSqlMode = null;

    /** トランザクションSQLモード変数 */
    private ExcSqlMode _ExcSqlMode = null;

    /** デフォルトコンストラクタ */
    public MaterialRegisterDAO() {
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
        } else if (_SelSqlMode.equals(SelSqlMode.Material)) {
            sql = getSelectSQLForMaterial();
        } else if (_SelSqlMode.equals(SelSqlMode.MaterialAdminList)) {
            sql = getSelectSQLForMaterialAdminList();
        } else if (_SelSqlMode.equals(SelSqlMode.LogMaterialRegister)) {
            sql = getSelectSQLForLogMaterialList();
        } else if (_SelSqlMode.equals(SelSqlMode.CmCodeIssueDocs)) {
            sql = getSelectSQLForIssueDocsList();
        } else if (_SelSqlMode.equals(SelSqlMode.MaterialEncodeList)) {
            sql = getSelectSQLForMaterialEncodeList();
        } else if (_SelSqlMode.equals(SelSqlMode.UsedTempMaterial)) {
            sql = getSelectSQLFindUsedRdProgramTempMaterial();
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
        if (_ExcSqlMode.equals(ExcSqlMode.UpdateDelMaterialList)) {
            sql = getExecSQLForUpdateDelMaterialList();
        } else if (_ExcSqlMode.equals(ExcSqlMode.DeleteContentAll)) {
            sql = getExecSQLForTargetContentAllDelete();
        } else if (_ExcSqlMode.equals(ExcSqlMode.UpdateMaterialList)) {
            sql = getExecSQLForUpdateMaterialList();
        } else if (_ExcSqlMode.equals(ExcSqlMode.InsertMaterialRegisterLog)) {
            sql = getExecSQLForInsertMaterialRegisterLog();
        } else if (_ExcSqlMode.equals(ExcSqlMode.InsertMaterialListLog)) {
            sql = getExecSQLForInsertMaterialListLog();
        /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD Start */
        } else if (_ExcSqlMode.equals(ExcSqlMode.InsertCarConvert)) {
            sql = getExecSQLForInsertCarConvert();
        /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD End */
        /** 2015/11/16 JASRAC対応 HLC K.Soga ADD Start */
        } else if (_ExcSqlMode.equals(ExcSqlMode.DeleteTempMaterialContentAll)){
            sql = getExecSQLForTempMaterialContentAllDelete();
        } else if (_ExcSqlMode.equals(ExcSqlMode.InsertTempMaterialRegisterLog)) {
            sql = getExecSQLForInsertTempMaterialRegisterLog();
        } else if (_ExcSqlMode.equals(ExcSqlMode.DeleteMaterialListAll)) {
            sql = getExecSQLForMaterialListAllDelete();
        } else if (_ExcSqlMode.equals(ExcSqlMode.DeleteMaterialListLog)) {
            sql = getExecSQLForDeleteMaterialListLog();
        } else if (_ExcSqlMode.equals(ExcSqlMode.UpdateTempMaterial)) {
            sql = getUpdSQLUsedRdProgramTempMaterial();
        }
        /** 2015/11/16 JASRAC対応 HLC K.Soga ADD End */

        return sql;
    }

    /**
     * コンテンツに紐付く契約情報取得SQL
     * @return
     */
    private String getSelectSQLForContentCntrct() {

        StringBuffer sql = new StringBuffer();
        StringBuffer where = new StringBuffer();

        List<String> cmCdList = _cond.getCmCdList();
        if (cmCdList != null) {
            for (int i = 0;i < cmCdList.size(); i++) {
                where.append(Tbj17Content.CMCD + " = '" + cmCdList.get(i) + "'");
                if (i < cmCdList.size() -1) {
                    where.append(" OR ");
                }
            }
        }

        /** 2015/11/6 JASRAC対応 HLC K.Soga MOD Start */
//        sql.append("SELECT ");
//        sql.append("  " + Tbj17Content.CMCD + " ");
//        sql.append(" ," + Tbj16ContractInfo.CTRTKBN + " ");
//        sql.append(" ," + Tbj16ContractInfo.CTRTNO + " ");
//        sql.append(" ," + Mbj12Code.CODENAME + " AS CTRTKBNNAME");
//        sql.append(" ," + Tbj16ContractInfo.NAMES + " ");
//        sql.append(" ," + Tbj16ContractInfo.DATEFROM + " ");
//        sql.append(" ," + Tbj16ContractInfo.DATETO + " ");
//        sql.append(" ," + Tbj16ContractInfo.MUSIC + " ");
//        sql.append(" ," + Tbj16ContractInfo.SALEFLG + " ");
//        sql.append(" ," + Tbj16ContractInfo.BIKO + " ");
//        sql.append(" ," + Tbj16ContractInfo.HISTORYKEY + " ");
//        sql.append(" ," + Tbj16ContractInfo.DCARCD + " ");
//        sql.append(" ," + Tbj16ContractInfo.CATEGORY + " ");
//        sql.append(" ," + Tbj16ContractInfo.JASRACFLG  + " ");
//        sql.append(" ," + Tbj16ContractInfo.CRTDATE + " ");
//        sql.append(" ," + Tbj16ContractInfo.CRTNM + " ");
//        sql.append(" ," + Tbj16ContractInfo.CRTAPL + " ");
//        sql.append(" ," + Tbj16ContractInfo.CRTID + " ");
//        sql.append(" ," + Tbj16ContractInfo.UPDDATE + " ");
//        sql.append(" ," + Tbj16ContractInfo.UPDNM + " ");
//        sql.append(" ," + Tbj16ContractInfo.UPDID + " ");
//        sql.append(" ," + Tbj17Content.CRTDATE + " ");
//        sql.append(" ," + Tbj17Content.UPDDATE + " ");
//        sql.append(" FROM ");
//        sql.append("  " + Tbj17Content.TBNAME + " ");
//        sql.append("  ," + Tbj16ContractInfo.TBNAME + " ");
//        sql.append("  ," + Mbj12Code.TBNAME + " ");
//        sql.append(" WHERE ");
//        sql.append("  " + Tbj16ContractInfo.CTRTKBN +  " = " + Tbj17Content.CTRTKBN);
//        sql.append(" AND " + Tbj16ContractInfo.CTRTNO +  " = " + Tbj17Content.CTRTNO);
//        sql.append(" AND " + Tbj16ContractInfo.DELFLG + " != 'D'");
//        sql.append(" AND " + Mbj12Code.CODETYPE + "(+)" + " = '16'" );
//        sql.append(" AND " + Tbj16ContractInfo.CTRTKBN + " = " + Mbj12Code.KEYCODE + "(+)" );
//        //10桁CMコードが指定されていた場合、条件にセットする(INだと件数に制限があるため、ORを使用)
//        if (where.length() > 0) {
//            sql.append(" AND ( ");
//            sql.append(where.toString());
//            sql.append(" )");
//        }
//        sql.append("  ORDER BY ");
//        sql.append(Tbj17Content.CMCD + ", ");
//        sql.append(Tbj17Content.CTRTKBN + ", ");
//        sql.append(Tbj17Content.CTRTNO + ", ");
//        sql.append(Tbj16ContractInfo.DATETO );

        sql.append("SELECT");
        sql.append(" " + Tbj17Content.CMCD + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Mbj12Code.CODENAME +" AS CTRTKBNNAME,");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.SALEFLG + ",");
        sql.append(" " + Tbj16ContractInfo.BIKO + ",");
        sql.append(" " + Tbj16ContractInfo.HISTORYKEY + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.JASRACFLG+ ",");
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
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + "=" + Tbj17Content.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + "=" + Tbj17Content.CTRTNO + " AND");
        sql.append(" " + Tbj16ContractInfo.DELFLG + "!= '" + HAMConstants.CONTRACT_REGISTER_DELFLG_DELETE + "' AND");
        sql.append(" " + Mbj12Code.CODETYPE + "= " + HAMConstants.CODETYPE_CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + "=" + Mbj12Code.KEYCODE);

        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Mbj12Code.CODENAME + " AS CTRTKBNNAME,");
        sql.append(" " + Tbj16ContractInfo.NAMES + ",");
        sql.append(" " + Tbj16ContractInfo.DATEFROM + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO + ",");
        sql.append(" " + Tbj16ContractInfo.MUSIC + ",");
        sql.append(" " + Tbj16ContractInfo.SALEFLG + ",");
        sql.append(" " + Tbj16ContractInfo.BIKO + ",");
        sql.append(" " + Tbj16ContractInfo.HISTORYKEY + ",");
        sql.append(" " + Tbj16ContractInfo.DCARCD + ",");
        sql.append(" " + Tbj16ContractInfo.CATEGORY + ",");
        sql.append(" " + Tbj16ContractInfo.JASRACFLG + ",");
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
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME + ",");
        sql.append(" " + Tbj16ContractInfo.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL AND");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + "=" + Tbj36TempSozaiKanriData.TEMPCMCD + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + "=" + Tbj40TempSozaiContent.CTRTKBN + " AND");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + "=" + Tbj40TempSozaiContent.CTRTNO + " AND");
        sql.append(" " + Tbj16ContractInfo.DELFLG + "!= '" + HAMConstants.CONTRACT_REGISTER_DELFLG_DELETE + "' AND");
        sql.append(" " + Mbj12Code.CODETYPE + "= '" + HAMConstants.CODETYPE_CTRTKBN + "' AND");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + "=" + Mbj12Code.KEYCODE);

        sql.append(" ORDER BY");
        sql.append(" " + Tbj17Content.CMCD + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTKBN + ",");
        sql.append(" " + Tbj16ContractInfo.CTRTNO + ",");
        sql.append(" " + Tbj16ContractInfo.DATETO);
        /** 2015/11/6 JASRAC対応 HLC K.Soga MOD End */

        return sql.toString();
    }

    /**
     * 素材情報取得SQL
     * @return
     */
    private String getSelectSQLForMaterial() {

        StringBuffer sql = new StringBuffer();

        /** 2015/11/6 JASRAC対応 HLC K.Soga MOD Start */
//        sql.append("SELECT ");
//        sql.append("  " + Tbj18SozaiKanriData.NOKBN + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CMCD + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.STATUS + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.DCARCD + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CATEGORY + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.TITLE + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.SECOND + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.SYATAN + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.NOHIN + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.PRODUCT + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.DATEFROM + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.DATETO + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.MLIMIT + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.KLIMIT + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.DATERECOG + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.DATEPRT + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.BIKO + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CRTDATE + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CRTNM + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CRTAPL + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.CRTID + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.UPDDATE + " ");
//        sql.append("  ," + Tbj18SozaiKanriData.UPDNM + " ");
//        sql.append(" FROM ");
//        sql.append("  " + Tbj18SozaiKanriData.TBNAME + " ");
//        sql.append("  ORDER BY ");
//        sql.append(Tbj18SozaiKanriData.CRTDATE + ", ");
//        sql.append(Tbj18SozaiKanriData.CMCD);
        sql.append("SELECT");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
        sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
        sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj18SozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj18SozaiKanriData.ENDTITLE + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
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
        sql.append(" " + Tbj18SozaiKanriData.UPDNM);

        sql.append(" FROM");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME);

        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.STATUS + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj36TempSozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.ENDTITLE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
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
        sql.append(" " + Tbj36TempSozaiKanriData.UPDNM);

        sql.append(" FROM");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + " IS NULL");

        sql.append(" ORDER BY");
        sql.append(" " + Tbj18SozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD);
        /** 2015/11/6 JASRAC対応 HLC K.Soga MOD End */

        return sql.toString();
    }

    /**
     * 素材一覧取得SQL
     * @return
     */
    private String getSelectSQLForMaterialAdminList() {

        StringBuffer sql = new StringBuffer();

        sql.append(" SELECT");
        sql.append(" " + Tbj20SozaiKanriList.CMCD + ",");
        /** 2015/12/04 JASRAC対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + ",");
        /** 2015/12/04 JASRAC対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RECNO + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        /** 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDNM + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDID + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL);
        /** 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */

        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);

        sql.append(" WHERE");

        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD Start */
        //sql.append(" " + Tbj20SozaiKanriList.CMCD + " = '" + _cond.getCmCd()  + "'");
        if (_materialType.equals(HAMConstants.MATERIAL_KBN_ACTUAL)) {
            //本素材
            sql.append(" " + Tbj20SozaiKanriList.CMCD + " = '" + _cond.getCmCd()  + "'");
        } else {
            //仮素材
            sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " = '" + _cond.getTempCmCd()  + "'");
        }
        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD End */

        sql.append(" ORDER BY");
        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD Start */
        if (_materialType.endsWith(HAMConstants.MATERIAL_KBN_ACTUAL)) {
            sql.append(" " + Tbj20SozaiKanriList.CMCD);
        } else {
            sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD);
        }
        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD End */

        return sql.toString();
    }

    /**
     * 履歴画面用のデータ取得SQL
     * @return
     */
    private String getSelectSQLForLogMaterialList() {

        StringBuffer sql = new StringBuffer();

        sql.append("SELECT");
        sql.append(" " + Mbj12Code.CODENAME + " AS " + Tbj25LogSozaiKanriData.HISTORYKBN + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.HISTORYNO + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CMCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.TITLE + ",");
        /** 2016/02/18 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj25LogSozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.ENDTITLE + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/18 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj25LogSozaiKanriData.SECOND + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.SYATAN + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.PRODUCT + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATEFROM + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATETO + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.MLIMIT + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.KLIMIT + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATERECOG + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.BIKO + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTNM + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTAPL + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTID + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.UPDNM + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.UPDDATE);
        sql.append(" FROM");
        sql.append(" " + Tbj25LogSozaiKanriData.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj25LogSozaiKanriData.NOKBN + " = " + this.ConvertToDBNullString(_cond.getNoKbn()) + " AND");
        sql.append(" " + Tbj25LogSozaiKanriData.CMCD + " = " + this.ConvertToDBNullString(_cond.getCmCd()) + " AND");
        sql.append(" " + Tbj25LogSozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Mbj12Code.CODETYPE + "(+) = '" + HAMConstants.CODETYPE_HISTORYNM + "' AND");
        sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj25LogSozaiKanriData.HISTORYKBN);
        sql.append(" UNION ALL");
        sql.append(" SELECT");
        sql.append(" " + Mbj12Code.CODENAME + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.HISTORYNO + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.TEMPCMCD + ",");
        sql.append(" " + Mbj05Car.CARNM + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.TITLE + ",");
        /** 2016/02/18 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj41LogTempSozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.ENDTITLE + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/18 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj41LogTempSozaiKanriData.SECOND + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.SYATAN + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.PRODUCT + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATEFROM + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATETO + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.MLIMIT + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.KLIMIT + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATERECOG + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.BIKO + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CRTNM + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CRTAPL + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CRTID + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.UPDNM + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.UPDDATE);
        sql.append(" FROM");
        sql.append(" " + Tbj41LogTempSozaiKanriData.TBNAME + ",");
        sql.append(" " + Mbj05Car.TBNAME + ",");
        sql.append(" " + Mbj12Code.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj41LogTempSozaiKanriData.NOKBN + " = " + this.ConvertToDBNullString(_cond.getNoKbn()) + " AND");
        sql.append(" " + Tbj41LogTempSozaiKanriData.TEMPCMCD + " = " + this.ConvertToDBNullString(_cond.getTempCmCd()) + " AND");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CMCD + " IS NULL AND");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD + "(+) AND");
        sql.append(" " + Mbj12Code.CODETYPE + "(+) = '" + HAMConstants.CODETYPE_HISTORYNM + "' AND");
        sql.append(" " + Mbj12Code.KEYCODE + "(+) = " + Tbj41LogTempSozaiKanriData.HISTORYKBN);
        sql.append(" ORDER BY");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.HISTORYNO);

        return sql.toString();
    }

    /**
     * CMコード発行書データ取得SQL
     * @return
     */
    private String getSelectSQLForIssueDocsList() {

        StringBuffer sql = new StringBuffer();
        StringBuffer where = new StringBuffer();

        List<String> cmCdList = _cond.getCmCdList();
        if (cmCdList != null) {
            for (int i = 0;i < cmCdList.size(); i++) {
                where.append(Tbj18SozaiKanriData.CMCD + " = '" + cmCdList.get(i) + "'");
                if (i < cmCdList.size() -1) {
                    where.append(" OR ");
                }
            }
        }

        sql.append("SELECT ");
        sql.append("  " + Tbj18SozaiKanriData.CMCD + " ");
        sql.append("  ," + Tbj18SozaiKanriData.CATEGORY + " ");
        sql.append("  ," + Tbj18SozaiKanriData.TITLE + " ");
        sql.append("  ," + Tbj18SozaiKanriData.SECOND + " ");
        sql.append("  ," + Tbj18SozaiKanriData.SYATAN + " ");
        sql.append("  ," + Tbj18SozaiKanriData.CRTNM + " ");
        sql.append("  ," + Tbj18SozaiKanriData.CRTAPL + " ");
        sql.append("  ," + Tbj18SozaiKanriData.CRTID + " ");
        sql.append(" FROM ");
        sql.append("  " + Tbj18SozaiKanriData.TBNAME + " ");
        if (where.length() > 0) {
            sql.append("  WHERE ( ");
            sql.append(where.toString());
            sql.append(" )");
        }
        sql.append("  ORDER BY ");
        sql.append(Tbj18SozaiKanriData.CRTDATE + ", ");
        sql.append(Tbj18SozaiKanriData.CMCD);

        return sql.toString();
    }

    /**
     * フィルタ条件に空白などが含まれているか確認
     * @param cond フィルタ条件
     * @return whereの一部
     */
    private String checkBlank(String cond, boolean nullFlg,boolean toDate) {
        String ret;
        if (cond.equals("(Blanks)")) {
            if (nullFlg) {
                ret = " = ' ' ";
            } else {
                ret = " is null ";
            }
        }
        else if (cond.equals("(NonBlanks)")) {
            if (nullFlg) {
                ret = " <> ' ' ";
            } else {
                ret = " is not null ";
            }
        } else {
            if (!toDate) {
                ret = " = '" + cond + "' ";
            } else {
                ret = " = TO_DATE('" + cond + "', 'YYYY-MM-DD HH24:MI:SS')";
            }
        }

        return ret;
    }

    /**
     * 素材エンコード表データ取得SQL
     * @return
     */
    private String getSelectSQLForMaterialEncodeList() {

        StringBuffer sql = new StringBuffer();
        StringBuffer where = new StringBuffer();

        where.append(Tbj18SozaiKanriData.STATUS + " <> '" + HAMConstants.MATERIAL_REGISTER_DELFLG_IGNORE + "' ");

        //系統区分の件数分だけ、条件に付加させる
        if (_encCond.getNoKbnList() != null && _encCond.getNoKbnList().size() > 0) {
            StringBuffer noKnbList = new StringBuffer();

            for (int i = 0; i < _encCond.getNoKbnList().size(); i++) {
                noKnbList.append("'" + _encCond.getNoKbnList().get(i) + "'");
                if (i < _encCond.getNoKbnList().size() - 1) {
                    noKnbList.append(",");
                }
            }

            if (noKnbList.length() > 0) {
                if (where.length() > 0) {
                    where.append(" AND ");
                }
                where.append(Tbj18SozaiKanriData.NOKBN + " IN (");
                where.append(noKnbList.toString());
                where.append(") ");
            }
        }

        //CMコードの件数分だけ、条件に付加させる
        if (_encCond.getCmCdList() != null) {

            StringBuffer sbTmp = new StringBuffer();
            for (String cmCdList : _encCond.getCmCdList()) {
                String[] cmCds = cmCdList.split(",");
                if (sbTmp.length() > 0) {
                    sbTmp.append(" OR ");
                }
                sbTmp.append(" (");
                sbTmp.append(Tbj18SozaiKanriData.CMCD + " >= '" + cmCds[0] + "'");
                sbTmp.append(" AND ");
                sbTmp.append(Tbj18SozaiKanriData.CMCD + " <= '" + cmCds[1] + "'");
                sbTmp.append(") ");
            }

            if (sbTmp.length() > 0) {
                if (where.length() > 0) {
                    where.append(" AND ");
                }
                where.append("(");
                where.append(sbTmp.toString());
                where.append(") ");
            }
        }

        //承認に対し入力がある場合
        if (_encCond.getInputApproveFlg()) {

            if (where.length() > 0) {
                where.append(" AND ");
            }

            if (_encCond.getApproveFlg()) {
                //承認済みの場合、日付のFROMとTOを条件にセット
                String[] dateRecog = _encCond.getDateRecog().split(",");
                where.append(" (");
                where.append(Tbj18SozaiKanriData.DATERECOG + " >= '" + dateRecog[0] + "'");
                where.append(" AND ");
                where.append(Tbj18SozaiKanriData.DATERECOG + " <= '" + dateRecog[1] + "'");
                where.append(") ");
            } else {
                //未承認の場合、日付がNULLの条件をセット
                where.append(Tbj18SozaiKanriData.DATERECOG + " IS NULL");
            }
        }

        //素材エンコード表フィルタ反映 2013/11/11 HLC H.Watabe add start
        if (_encCond.getCMCd() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getCMCd(), true, false);
            where.append(Tbj18SozaiKanriData.CMCD + fil );
        }
        if (_encCond.getDCarNm() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getDCarNm(), true, false);
            where.append(Mbj05Car.CARNM + fil );
        }
        if (_encCond.getCategory() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getCategory(), true, false);
            where.append(Tbj18SozaiKanriData.CATEGORY + fil);
        }
        if (_encCond.getTitle() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getTitle(), true, false);
            where.append(Tbj18SozaiKanriData.TITLE + fil);
        }
        if (_encCond.getSeccond() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getSeccond(),true,false);
            where.append(Tbj18SozaiKanriData.SECOND + fil);
        }
        if (_encCond.getProduct() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getProduct(), false, false);
            where.append(Tbj18SozaiKanriData.PRODUCT + fil);
        }
        if (_encCond.getAssign() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getAssign(), false, false);
            where.append(Tbj18SozaiKanriData.SYATAN + fil);
        }
        if (_encCond.getDateFrom() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getDateFrom(), false, false);
            where.append(Tbj18SozaiKanriData.DATEFROM + fil);
        }
        if (_encCond.getDateTo() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getDateTo(), false, false);
            where.append(Tbj18SozaiKanriData.DATETO + fil);
        }
        if (_encCond.getMediaLimit() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getMediaLimit(), false, false);
            where.append(Tbj18SozaiKanriData.MLIMIT + fil);
        }
        if (_encCond.getRightLimit() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getRightLimit(), false, false);
            where.append(Tbj18SozaiKanriData.KLIMIT + fil);
        }
        if (_encCond.getApprovedDate() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getApprovedDate(), false, false);
            where.append(Tbj18SozaiKanriData.DATERECOG + fil);
        }
        if (_encCond.getRemark() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getRemark(), false, false);
            where.append(Tbj18SozaiKanriData.BIKO + fil);
        }
        if (_encCond.getCreatedName() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getCreatedName(), true, false);
            where.append(Tbj18SozaiKanriData.CRTNM + fil);
        }
        if (_encCond.getCreatedDate() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getCreatedDate(), false, true);
            where.append(Tbj18SozaiKanriData.CRTDATE + fil);
        }
        if (_encCond.getUpdatedName() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getUpdatedName(), true, false);
            where.append(Tbj18SozaiKanriData.UPDNM + fil);
        }
        if (_encCond.getUpdatedDate() != null) {
            if (where.length() > 0) {
                where.append(" AND ");
            }
            String fil = checkBlank(_encCond.getUpdatedDate(), false, true);
            where.append(Tbj18SozaiKanriData.UPDDATE + fil);
        }
        //素材エンコード表フィルタ反映 2013/11/11 HLC H.Watabe add end

        sql.append("SELECT ");
        sql.append("  " + Tbj18SozaiKanriData.STATUS + " ");
        sql.append("  ," + Tbj18SozaiKanriData.DATERECOG + " ");
        sql.append("  ," + Tbj18SozaiKanriData.CMCD + " ");
        sql.append("  ," + Tbj18SozaiKanriData.CATEGORY + " ");
        sql.append("  ," + Tbj18SozaiKanriData.SECOND + " ");
        sql.append("  ," + Tbj18SozaiKanriData.TITLE + " ");
        sql.append("  ," + Tbj18SozaiKanriData.SYATAN + " ");
        sql.append("  ," + Tbj18SozaiKanriData.PRODUCT + " ");
        sql.append("  ," + Tbj18SozaiKanriData.DATEFROM + " ");
        sql.append("  ," + Tbj18SozaiKanriData.BIKO + " ");
        sql.append(" FROM ");
        sql.append("  " + Tbj18SozaiKanriData.TBNAME + " ");
        sql.append("  ," + Mbj05Car.TBNAME + " ");
        sql.append(" WHERE " + Tbj18SozaiKanriData.DCARCD + " = " + Mbj05Car.DCARCD);
        if (where.length() > 0) {
            sql.append(" AND ");
            sql.append(where.toString());
        }
        sql.append("  ORDER BY ");
        sql.append(Tbj18SozaiKanriData.CRTDATE + ", ");
        sql.append(Tbj18SozaiKanriData.CMCD);

        return sql.toString();
    }

    /**
     * 素材一覧更新(削除用)SQLを取得します
     * @return
     */
    private String getExecSQLForUpdateDelMaterialList() {

        StringBuffer sql = new StringBuffer();

        sql.append("UPDATE " + Tbj20SozaiKanriList.TBNAME);
        sql.append("   SET " + Tbj20SozaiKanriList.DELFLG + " = '" + HAMConstants.MATERIAL_REGISTER_DELFLG_DELETE + "'");
        sql.append("      ," + Tbj20SozaiKanriList.DCARCD + " = '" + _transMateVo.getDCARCD() + "'");
        sql.append("      ," + Tbj20SozaiKanriList.TITLE + " = '" + _transMateVo.getTITLE() + "'");
        sql.append("      ," + Tbj20SozaiKanriList.SECOND + " = '" + _transMateVo.getSECOND() + "'");
        sql.append("      ," + Tbj20SozaiKanriList.LIMIT + " = " + ConvertToDBNullString(_transMateVo.getMLIMIT()));
        /** 2016/03/25 HDX対応 HLC K.Soga DEL Start */
        //sql.append("      ," + Tbj20SozaiKanriList.SYATAN + " = '" + _transMateVo.getSYATAN() + "'");
        /** 2016/03/25 HDX対応 HLC K.Soga DEL End */
        sql.append("      ," + Tbj20SozaiKanriList.UPDDATE + " = " + ConvertToDBNullString(_transMateVo.getUPDDATE()));
        sql.append("      ," + Tbj20SozaiKanriList.UPDAPL + " = '" + _transMateVo.getUPDAPL() + "'");
        sql.append("      ," + Tbj20SozaiKanriList.UPDID + " = '" + _transMateVo.getUPDID() + "'");
        sql.append(" WHERE " + Tbj20SozaiKanriList.RECKBN + " = '" + HAMConstants.RECKBN_SYSTEM + "'");
        sql.append("   AND " + Tbj20SozaiKanriList.CMCD + " = '" + _transMateVo.getCMCD() + "'");

        return sql.toString();
    }

    /**
     * 特定のCMコードに紐付くコンテンツを削除するSQLを取得します
     * @return
     */
    private String getExecSQLForTargetContentAllDelete() {

        StringBuffer sql = new StringBuffer();

        sql.append(" DELETE");
        sql.append(" FROM " + Tbj17Content.TBNAME);
        sql.append(" WHERE " + Tbj17Content.CMCD + " = '" + _transMateVo.getCMCD() + "'");

        return sql.toString();
    }

    /** 2015/11/24 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 特定のCMコードに紐付く仮素材コンテンツを削除するSQLを取得します
     * @return
     */
    private String getExecSQLForTempMaterialContentAllDelete() {

        StringBuffer sql = new StringBuffer();

        sql.append("DELETE");
        sql.append(" FROM");
        sql.append(" " + Tbj40TempSozaiContent.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj40TempSozaiContent.TEMPCMCD + " = '" + _transTempMaterialVo.getTEMPCMCD() + "'");

        return sql.toString();
    }

    /**
     * 特定のCMコードに紐付く仮素材用コンテンツを削除するSQLを取得します
     * @return
     */
    private String getExecSQLForMaterialListAllDelete() {

        StringBuffer sql = new StringBuffer();

        sql.append("DELETE");
        sql.append(" FROM");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.TEMPCMCD + " = '" + _transMateListVo.getTEMPCMCD() + "'");

        return sql.toString();
    }
    /** 2015/11/24 JASRAC対応 HLC K.Soga ADD End */

    /**
     * 素材一覧を更新します
     * @return
     */
    private String getExecSQLForUpdateMaterialList() {

        StringBuffer sql = new StringBuffer();

        sql.append("UPDATE");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);
        sql.append(" SET");
        sql.append(" " + Tbj20SozaiKanriList.DELFLG + " = '" + (_transMateListVo.getDELFLG().equals("") ? (" ") : _transMateListVo.getDELFLG()) + "'");

        //車種を変更した場合
        if (!StringUtil.isBlank(_transMateListVo.getRECNO()) && !StringUtil.isBlank(_transMateListVo.getDCARCD())) {

            StringBuffer subSql = new StringBuffer();

            subSql.append("(");
            subSql.append("SELECT");
            subSql.append(" TO_CHAR(NVL(MAX(" + Tbj20SozaiKanriList.RECNO + "),0) + 1,'FM0000') NEWNO");
            subSql.append(" FROM");
            subSql.append(" " + Tbj20SozaiKanriList.TBNAME);
            subSql.append(" WHERE");
            subSql.append(" " + Tbj20SozaiKanriList.DCARCD + " = '" + _transMateListVo.getDCARCD() + "' AND");
            subSql.append(" " + Tbj20SozaiKanriList.SOZAIYM + " = '" + DateUtil.toStringGeneral(_transMateListVo.getSOZAIYM(), "yyyy/MM/dd") + "' AND");
            subSql.append(" " + Tbj20SozaiKanriList.RECKBN + " = '" + HAMConstants.RECKBN_SYSTEM + "'");
            subSql.append(")");

            sql.append(" ," + Tbj20SozaiKanriList.RECNO + " = " + subSql.toString() + ",");
            sql.append(" " + Tbj20SozaiKanriList.DCARCD + " = '" + _transMateListVo.getDCARCD() + "'");
        }

        /** 2015/12/03 JASRAC対応 HLC K.Soga ADD Start */
        sql.append(" ," + Tbj20SozaiKanriList.CMCD + " = '" + _transMateListVo.getCMCD() + "',");
        /** 2015/12/03 JASRAC対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.TITLE + " = '" + _transMateListVo.getTITLE() + "',");
        sql.append(" " + Tbj20SozaiKanriList.SECOND + " = '" + _transMateListVo.getSECOND() + "',");
        sql.append(" " + Tbj20SozaiKanriList.LIMIT + " = " + ConvertToDBNullString(_transMateListVo.getLIMIT()) + ",");
        /** 2016/03/10 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj20SozaiKanriList.SYATAN + " = '" + _transMateListVo.getSYATAN() + "',");
        /** 2016/03/10 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj20SozaiKanriList.UPDDATE + " = " + getDBModelInterface().getSystemDateString() + ",");
        sql.append(" " + Tbj20SozaiKanriList.UPDAPL + " = '" + _transMateListVo.getUPDAPL() + "',");
        sql.append(" " + Tbj20SozaiKanriList.UPDID + " = '" + _transMateListVo.getUPDID() + "'");
        sql.append(" WHERE");
        sql.append(" " + Tbj20SozaiKanriList.RECKBN + " = '0'");

        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD Start */
        //sql.append("   AND " + Tbj20SozaiKanriList.CMCD + " = '" + _transMateListVo.getCMCD() + "'");
        if (_materialType.equals(HAMConstants.MATERIAL_KBN_ACTUAL)) {
            //本素材
            sql.append(" AND " + Tbj20SozaiKanriList.CMCD + " = '" + _transMateListVo.getCMCD() + "'");
        } else {
            //仮素材
            sql.append(" AND " + Tbj20SozaiKanriList.TEMPCMCD + " = '" + _transMateListVo.getTEMPCMCD() + "'");
        }
        /** 2015/12/03 JASRAC対応 HLC S.Fujimoto MOD End */

        if (_transMateListVo.getSOZAIYM() != null) {
            sql.append(" AND " + Tbj20SozaiKanriList.SOZAIYM + " = '" + DateUtil.toStringGeneral(_transMateListVo.getSOZAIYM(), "yyyy/MM/dd") + "'");
        }

        return sql.toString();
    }

    /**
     * 素材登録ログを作成するSQLを取得
     * @return
     */
    private String getExecSQLForInsertMaterialRegisterLog() {

        Tbj25LogSozaiKanriDataVO vo = (Tbj25LogSozaiKanriDataVO)super.getModel();
        StringBuffer sql = new StringBuffer();

        sql.append("INSERT");
        sql.append(" INTO");
        sql.append(" " + Tbj25LogSozaiKanriData.TBNAME);
        sql.append(" (");
        sql.append(" " + Tbj25LogSozaiKanriData.NOKBN + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.HISTORYNO + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.HISTORYKBN + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DELFLG + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DCARCD + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.TITLE + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj25LogSozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.ENDTITLE + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj25LogSozaiKanriData.SECOND + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj25LogSozaiKanriData.SYATAN + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga DEL End */
        sql.append(" " + Tbj25LogSozaiKanriData.NOHIN + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.PRODUCT + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATEFROM + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATETO + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.MLIMIT + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.KLIMIT + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATERECOG + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.DATEPRT + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.BIKO + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTNM + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTAPL + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.CRTID + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.UPDDATE + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.UPDNM + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.UPDAPL + ",");
        sql.append(" " + Tbj25LogSozaiKanriData.UPDID);
        sql.append(" )");
        sql.append(" SELECT");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + ",");
        sql.append(" (SELECT");
        sql.append(" NVL(MAX(" + Tbj25LogSozaiKanriData.HISTORYNO + "), 0) + 1");
        sql.append(" FROM");
        sql.append(" " + Tbj25LogSozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj25LogSozaiKanriData.NOKBN + " = " + ConvertToDBNullString(vo.getNOKBN()) + " AND");
        sql.append(" " + Tbj25LogSozaiKanriData.CMCD + " = " + ConvertToDBNullString(vo.getCMCD()));
        sql.append(" ),");
        sql.append(" '" + vo.getHISTORYKBN() + "',");
        sql.append(" " + Tbj18SozaiKanriData.STATUS + ",");
        sql.append(" " + Tbj18SozaiKanriData.DCARCD + ",");
        sql.append(" " + Tbj18SozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj18SozaiKanriData.TITLE + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj18SozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj18SozaiKanriData.ENDTITLE + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj18SozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj18SozaiKanriData.SECOND + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj18SozaiKanriData.SYATAN + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga DEL End */
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
        sql.append(" " + Tbj18SozaiKanriData.UPDID);
        sql.append(" FROM");
        sql.append(" " + Tbj18SozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.NOKBN + " = " + ConvertToDBNullString(vo.getNOKBN()) + " AND");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = " + ConvertToDBNullString(vo.getCMCD()));

        return sql.toString();
    }

    /** 2015/11/16 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 仮素材登録ログを作成するSQLを取得
     * @return
     */
    private String getExecSQLForInsertTempMaterialRegisterLog() {

        Tbj41LogTempSozaiKanriDataVO vo = (Tbj41LogTempSozaiKanriDataVO)super.getModel();
        StringBuffer sql = new StringBuffer();

        sql.append("INSERT");
        sql.append(" INTO " + Tbj41LogTempSozaiKanriData.TBNAME);
        sql.append(" (");
        sql.append(" " + Tbj41LogTempSozaiKanriData.NOKBN + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.TEMPCMCD + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CMCD + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.HISTORYNO + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.HISTORYKBN + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DELFLG + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DCARCD + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.TITLE + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj41LogTempSozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.ENDTITLE + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj41LogTempSozaiKanriData.SECOND + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj41LogTempSozaiKanriData.SYATAN + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga DEL End */
        sql.append(" " + Tbj41LogTempSozaiKanriData.NOHIN + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.PRODUCT + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATEFROM + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATETO + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.MLIMIT + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.KLIMIT + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATERECOG + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.DATEPRT + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.BIKO + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CRTDATE + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CRTNM + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CRTAPL + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.CRTID + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.UPDDATE + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.UPDNM + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.UPDAPL + ",");
        sql.append(" " + Tbj41LogTempSozaiKanriData.UPDID);
        sql.append(" )");
        sql.append(" SELECT");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.CMCD + ",");
        sql.append(" (SELECT NVL(MAX(" + Tbj41LogTempSozaiKanriData.HISTORYNO + "),0) + 1");

        sql.append(" FROM");
        sql.append(" " + Tbj41LogTempSozaiKanriData.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj41LogTempSozaiKanriData.NOKBN + " = " + this.ConvertToDBNullString(vo.getNOKBN()) + " AND");
        sql.append(" " + Tbj41LogTempSozaiKanriData.TEMPCMCD + " = " + this.ConvertToDBNullString(vo.getTEMPCMCD()));
        sql.append(" ),");
        sql.append(" '" + vo.getHISTORYKBN() + "',");
        sql.append(" " + Tbj36TempSozaiKanriData.STATUS + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DCARCD + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.CATEGORY + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.TITLE + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
        sql.append(" " + Tbj36TempSozaiKanriData.ALIASTITLE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.ENDTITLE + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DATEFROM_ATTR + ",");
        sql.append(" " + Tbj36TempSozaiKanriData.DATETO_ATTR + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
        sql.append(" " + Tbj36TempSozaiKanriData.SECOND + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj36TempSozaiKanriData.SYATAN + ",");
        /** 2016/02/17 HDX対応 HLC K.Soga DEL End */
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
        sql.append(" " + Tbj36TempSozaiKanriData.UPDID);
        sql.append(" FROM");
        sql.append(" " + Tbj36TempSozaiKanriData.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj36TempSozaiKanriData.NOKBN + " = " + this.ConvertToDBNullString(vo.getNOKBN()) + " AND");
        sql.append(" " + Tbj36TempSozaiKanriData.TEMPCMCD + " = " + this.ConvertToDBNullString(vo.getTEMPCMCD()));

        return sql.toString();
    }

    /**
     * 素材登録画面ラジオ番組使用素材検索SQLを作成する
     * @return String 素材登録画面ラジオ番組使用仮素材検索SQL文
     */
    private String getSelectSQLFindUsedRdProgramTempMaterial() {

        StringBuilder sql = new StringBuilder();

        sql.append("SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD);

        sql.append(" FROM");
        sql.append(" (");

        sql.append(" SELECT");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" CASE " + Mbj51Natural.NO);
        sql.append(" WHEN 1 THEN " + Tbj38RdProgramMaterial.DAY01);
        sql.append(" WHEN 2 THEN " + Tbj38RdProgramMaterial.DAY02);
        sql.append(" WHEN 3 THEN " + Tbj38RdProgramMaterial.DAY03);
        sql.append(" WHEN 4 THEN " + Tbj38RdProgramMaterial.DAY04);
        sql.append(" WHEN 5 THEN " + Tbj38RdProgramMaterial.DAY05);
        sql.append(" WHEN 6 THEN " + Tbj38RdProgramMaterial.DAY06);
        sql.append(" WHEN 7 THEN " + Tbj38RdProgramMaterial.DAY07);
        sql.append(" WHEN 8 THEN " + Tbj38RdProgramMaterial.DAY08);
        sql.append(" WHEN 9 THEN " + Tbj38RdProgramMaterial.DAY09);
        sql.append(" WHEN 10 THEN " + Tbj38RdProgramMaterial.DAY10);
        sql.append(" WHEN 11 THEN " + Tbj38RdProgramMaterial.DAY11);
        sql.append(" WHEN 12 THEN " + Tbj38RdProgramMaterial.DAY12);
        sql.append(" WHEN 13 THEN " + Tbj38RdProgramMaterial.DAY13);
        sql.append(" WHEN 14 THEN " + Tbj38RdProgramMaterial.DAY14);
        sql.append(" WHEN 15 THEN " + Tbj38RdProgramMaterial.DAY15);
        sql.append(" WHEN 16 THEN " + Tbj38RdProgramMaterial.DAY16);
        sql.append(" WHEN 17 THEN " + Tbj38RdProgramMaterial.DAY17);
        sql.append(" WHEN 18 THEN " + Tbj38RdProgramMaterial.DAY18);
        sql.append(" WHEN 19 THEN " + Tbj38RdProgramMaterial.DAY19);
        sql.append(" WHEN 20 THEN " + Tbj38RdProgramMaterial.DAY20);
        sql.append(" WHEN 21 THEN " + Tbj38RdProgramMaterial.DAY21);
        sql.append(" WHEN 22 THEN " + Tbj38RdProgramMaterial.DAY22);
        sql.append(" WHEN 23 THEN " + Tbj38RdProgramMaterial.DAY23);
        sql.append(" WHEN 24 THEN " + Tbj38RdProgramMaterial.DAY24);
        sql.append(" WHEN 25 THEN " + Tbj38RdProgramMaterial.DAY25);
        sql.append(" WHEN 26 THEN " + Tbj38RdProgramMaterial.DAY26);
        sql.append(" WHEN 27 THEN " + Tbj38RdProgramMaterial.DAY27);
        sql.append(" WHEN 28 THEN " + Tbj38RdProgramMaterial.DAY28);
        sql.append(" WHEN 29 THEN " + Tbj38RdProgramMaterial.DAY29);
        sql.append(" WHEN 30 THEN " + Tbj38RdProgramMaterial.DAY30);
        sql.append(" WHEN 31 THEN " + Tbj38RdProgramMaterial.DAY31);
        sql.append(" END " + Tbj18SozaiKanriData.CMCD);

        sql.append(" FROM");
        sql.append(" " + Tbj38RdProgramMaterial.TBNAME);
        sql.append(" CROSS JOIN");
        sql.append(" " + Mbj51Natural.TBNAME);
        sql.append(" ),");
        sql.append(" " + Tbj20SozaiKanriList.TBNAME);

        sql.append(" WHERE");
        sql.append(" " + Tbj18SozaiKanriData.CMCD + " = '" +  _cond.getTempCmCd() + "'");

        sql.append(" GROUP BY");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + ",");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + ",");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + ",");
        sql.append(" " + Mbj51Natural.NO + ",");
        sql.append(" " + Tbj18SozaiKanriData.CMCD);

        return sql.toString();
    };

    /**
     * 割付済仮素材更新SQLを作成する
     * @return String 割付済仮素材更新SQL文
     */
    private String getUpdSQLUsedRdProgramTempMaterial() {

        StringBuilder sql = new StringBuilder();

        sql.append("UPDATE");
        sql.append(" " + Tbj38RdProgramMaterial.TBNAME);
        sql.append(" SET");
        sql.append(" TBJ38_DAY" + String.format("%02d", _rdProgramMaterial.getNO().intValue()) + " = '" + _rdProgramMaterial.getCMCD() + "'");
        sql.append(" WHERE");
        sql.append(" " + Tbj38RdProgramMaterial.RDSEQNO + " = " + _rdProgramMaterial.getRDSEQNO() + " AND");
        sql.append(" " + Tbj38RdProgramMaterial.YEARMONTH + " = " + _rdProgramMaterial.getYEARMONTH() + " AND");
        sql.append(" " + Tbj38RdProgramMaterial.WAKUSEQ + " = " + _rdProgramMaterial.getWAKUSEQNO());

        return sql.toString();
    };
    /** 2015/11/16 JASRAC対応 HLC K.Soga ADD End */

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
        /** 2016/02/23 HDX対応 HLC K.Soga ADD Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.SYATAN + ",");
        /** 2016/02/23 HDX対応 HLC K.Soga ADD End */
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
        sql.append(" WHERE");
        /** 2016/03/10 HDX対応 HLC K.Soga DEL Start */
        //sql.append(" " + Tbj26LogSozaiKanriList.DCARCD + " = " + Tbj20SozaiKanriList.DCARCD + " AND");
        //sql.append(" " + Tbj26LogSozaiKanriList.RECNO + " = " + Tbj20SozaiKanriList.RECNO + "AND");
        /** 2016/03/10 HDX対応 HLC K.Soga DEL End */
        sql.append(" " + Tbj26LogSozaiKanriList.SOZAIYM + " = " + Tbj20SozaiKanriList.SOZAIYM + " AND");
        sql.append(" " + Tbj26LogSozaiKanriList.RECKBN + " = " + Tbj20SozaiKanriList.RECKBN);
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
                sbWhere.append(" AND ");
            sbWhere.append(Tbj20SozaiKanriList.SOZAIYM + " = " + ConvertToDBNullString(vo.getSOZAIYM()));
        }
        if (vo.getRECKBN() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND ");
            sbWhere.append(Tbj20SozaiKanriList.RECKBN + " = " + ConvertToDBNullString(vo.getRECKBN()));
        }
        if (vo.getRECNO() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND ");
            sbWhere.append(Tbj20SozaiKanriList.RECNO + " = " + ConvertToDBNullString(vo.getRECNO()));
        }

        /** 2014/10/30 マスタ追加対応 HLC K.Soga ADD Start */
        if (vo.getCMCD() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND ");
            sbWhere.append(Tbj20SozaiKanriList.CMCD + " = " + ConvertToDBNullString(vo.getCMCD()));
        }
        /** 2014/10/30 マスタ追加対応 HLC K.Soga ADD End */
        /** 2015/12/8 JASRAC対応 HLC K.Soga ADD Start */
        if (vo.getTEMPCMCD() != null) {
            if (sbWhere.length() > 0)
                sbWhere.append(" AND ");
            sbWhere.append(Tbj20SozaiKanriList.TEMPCMCD + " = " + ConvertToDBNullString(vo.getTEMPCMCD()));
        }
        /** 2015/12/8 JASRAC対応 HLC K.Soga ADD End */

        if (sbWhere.length() > 0) {
            sql.append(" WHERE ");
            sql.append(sbWhere.toString());
        }

        return sql.toString();
    }

    /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD Start */
    /**
     * 素材登録ログを作成するSQLを取得
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
        sql.append(" " + vo.getPHASE() + ",");
        sql.append(" " + Tbj20SozaiKanriList.SOZAIYM + ",");
        sql.append(" " + Tbj20SozaiKanriList.RCODE + ",");
        sql.append(" " + Tbj20SozaiKanriList.DCARCD + ",");
        sql.append(" SYSDATE,");
        sql.append(" '" + vo.getUPDNM() + "',");
        sql.append(" '" + vo.getUPDAPL() + "',");
        sql.append(" '" + vo.getUPDID() + "'");

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
     * 素材一覧ログを削除するSQLを取得
     * @return
     */
    private String getExecSQLForDeleteMaterialListLog() {

        Tbj26LogSozaiKanriListVO vo = (Tbj26LogSozaiKanriListVO)super.getModel();
        StringBuffer sql = new StringBuffer();

        sql.append("DELETE");
        sql.append(" FROM");
        sql.append(" " + Tbj26LogSozaiKanriList.TBNAME);
        sql.append(" WHERE");
        sql.append(" " + Tbj26LogSozaiKanriList.TEMPCMCD + " = '" + vo.getTEMPCMCD() + "'");

        return sql.toString();
    }
    /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD End */

    /** 2016/02/29 HDX対応 HLC K.Soga ADD Start */
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
    /** 2016/02/29 HDX対応 HLC K.Soga ADD End */

    /**
     * 素材登録画面用の契約情報の検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MaterialRegisterCntrctVO> findMaterialListForCntrctByCondition(MaterialRegisterCondition cond) throws HAMException {

        super.setModel(new MaterialRegisterCntrctVO());
        try {
            _SelSqlMode = SelSqlMode.ContentCntrct;
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
    public List<Tbj18SozaiKanriDataVO> findMaterialListByCondition(MaterialRegisterCondition cond) throws HAMException {

        super.setModel(new Tbj18SozaiKanriDataVO());
        try {
            _SelSqlMode = SelSqlMode.Material;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材管理一覧テーブルの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<Tbj20SozaiKanriListVO> findMaterialAdminListByCondition(MaterialRegisterCondition cond, String materialType) throws HAMException {

        super.setModel(new Tbj20SozaiKanriListVO());
        try {
            _SelSqlMode = SelSqlMode.MaterialAdminList;
            _materialType = materialType;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材登録ログテーブルの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<LogMaterialRegisterVO> findLogMaterialRegisterByCondition(MaterialRegisterCondition cond) throws HAMException {

        super.setModel(new LogMaterialRegisterVO());
        try {
            _SelSqlMode = SelSqlMode.LogMaterialRegister;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * CMコード発行書データの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<CmCodeIssueDocsVO> findCmCodeIssueDocsListByCondition(MaterialRegisterCondition cond) throws HAMException {

        super.setModel(new CmCodeIssueDocsVO());
        try {
            _SelSqlMode = SelSqlMode.CmCodeIssueDocs;
            _cond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材エンコード表データの検索を行います
     *
     * @return 汎用テーブルマスタVOリスト
     * @throws UserException データアクセス中にエラーが発生した場合
     */
    @SuppressWarnings("unchecked")
    public List<MaterialEncodeListVO> findMaterialEncodeListByCondition(MaterialEncodeListCondition cond) throws HAMException {

        super.setModel(new MaterialEncodeListVO());
        try {
            _SelSqlMode = SelSqlMode.MaterialEncodeList;
            _encCond = cond;
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 素材一覧テーブルを更新します
     * @param vo
     * @throws HAMException
     */
    public void updateDelMaterialList(Tbj18SozaiKanriDataVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("削除エラー", "BJ-E0008");

        try {
            _transMateVo = vo;
            _ExcSqlMode = ExcSqlMode.UpdateDelMaterialList;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * 素材一覧テーブルを更新します
     * @param vo
     * @throws HAMException
     */
    public void updateMaterialList(Tbj20SozaiKanriListVO vo, String materialType) throws HAMException {
        if (vo == null)
            throw new HAMException("更新エラー", "BJ-E0008");

        try {
            _transMateListVo = vo;
            _ExcSqlMode = ExcSqlMode.UpdateMaterialList;
            _materialType = materialType;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }

    /**
     * 特定のコンテンツテーブルを削除します
     * @param vo
     * @throws HAMException
     */
    public void deleteTaregetContentAll(Tbj18SozaiKanriDataVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("更新エラー", "BJ-E0008");

        try {
            _transMateVo = vo;
            _ExcSqlMode = ExcSqlMode.DeleteContentAll;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /** 2015/11/16 JASRAC対応 HLC K.Soga ADD Start */
    /**
     * 特定の仮素材コンテンツテーブルを削除します
     * @param vo
     * @throws HAMException
     */
    public void deleteTempMaterialContentAll(Tbj36TempSozaiKanriDataVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("更新エラー", "BJ-E0008");

        try {
            _transTempMaterialVo = vo;
            _ExcSqlMode = ExcSqlMode.DeleteTempMaterialContentAll;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * 仮素材登録ログテーブルに追加します
     * @param vo
     * @throws HAMException
     */
    public void insertTempMaterialRegisterLog(Tbj41LogTempSozaiKanriDataVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("登録エラー", "BJ-E0008");

        super.setModel(vo);
        try {
            _ExcSqlMode = ExcSqlMode.InsertTempMaterialRegisterLog;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
        }
    }

    /**
     * 特定の素材一覧テーブルを削除します
     * @param vo
     * @throws HAMException
     */
    public void deleteMaterialListAll(Tbj20SozaiKanriListVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("更新エラー", "BJ-E0008");

        try {
            _transMateListVo = vo;
            _ExcSqlMode = ExcSqlMode.DeleteMaterialListAll;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * 素材一覧ログテーブルを削除します
     * @param vo
     * @throws HAMException
     */
    public void deleteMaterialListLog(Tbj26LogSozaiKanriListVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("登録エラー", "BJ-E0008");

        super.setModel(vo);
        try {
            _ExcSqlMode = ExcSqlMode.DeleteMaterialListLog;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0004");
        }
    }

    /**
     * 素材登録画面ラジオ番組使用仮素材検索
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<UsedRdProgramMaterialVO> findUsedRdProgramTempMaterial( MaterialRegisterCondition condition) throws HAMException {

        // パラメータチェック
        if (condition == null) {
            throw new HAMException("検索エラー", "BJ-E0001");
        }

        super.setModel(new UsedRdProgramMaterialVO());
        _SelSqlMode = SelSqlMode.UsedTempMaterial;
        _cond = condition;

        try {
            return super.find();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0001");
        }
    }

    /**
     * 割付済仮素材更新
     * @param vo 更新VO
     * @throws HAMException
     */
    public void updateSQLUsedRdProgramTempMaterial(UsedRdProgramMaterialVO vo) throws HAMException {

        //パラメータチェック
        if (vo == null) {
            throw new HAMException("更新エラー", "BJ-E0003");
        }

        try {
            _rdProgramMaterial = vo;
            _ExcSqlMode = ExcSqlMode.UpdateTempMaterial;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0003");
        }
    }
    /** 2015/11/16 JASRAC対応 HLC K.Soga ADD End */

    /**
     * 素材登録ログテーブルに追加します
     * @param vo
     * @throws HAMException
     */
    public void insertMaterialRegisterLog(Tbj25LogSozaiKanriDataVO vo) throws HAMException {
        if (vo == null)
            throw new HAMException("登録エラー", "BJ-E0008");

        super.setModel(vo);
        try {
            _ExcSqlMode = ExcSqlMode.InsertMaterialRegisterLog;
            super.exec();
        } catch (UserException e) {
            throw new HAMException(e.getMessage(), "BJ-E0002");
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

    /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD Start */
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
    /** 2015/2/17 素材登録不具合対応 HLC K.Soga ADD End */

    /** 2016/02/29 HDX対応 HLC K.Soga ADD Start */
    /**
     * HC/HM担当者検索
     * @param condition 検索条件
     * @return 検索結果
     * @throws HAMException
     */
    @SuppressWarnings("unchecked")
    public List<HCHMSecGrpUserVO> findHCHMSecGrpUser( MaterialRegisterCondition condition) throws HAMException {

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
    /** 2016/02/29 HDX対応 HLC K.Soga ADD End */

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
        if (getModel() instanceof MaterialRegisterCntrctVO) {
            list = new ArrayList<MaterialRegisterCntrctVO>();

            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                MaterialRegisterCntrctVO vo = new MaterialRegisterCntrctVO();
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
                vo.setHISTORYKEY((BigDecimal)result.get(Tbj16ContractInfo.HISTORYKEY.toUpperCase()));
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
        } else if ((getModel() instanceof Tbj18SozaiKanriDataVO)) {
            list = new ArrayList<Tbj18SozaiKanriDataVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                Tbj18SozaiKanriDataVO vo = new Tbj18SozaiKanriDataVO();
                vo.setNOKBN(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.NOKBN.toUpperCase())));
                vo.setCMCD(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CMCD.toUpperCase())));
                vo.setSTATUS(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.STATUS.toUpperCase())));
                vo.setDCARCD(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.DCARCD.toUpperCase())));
                vo.setCATEGORY(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CATEGORY.toUpperCase())));
                vo.setTITLE(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.TITLE.toUpperCase())));
                /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
                vo.setALIASTITLE(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.ALIASTITLE.toUpperCase())));
                vo.setENDTITLE(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.ENDTITLE.toUpperCase())));
                vo.setDATEFROM_ATTR(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.DATEFROM_ATTR.toUpperCase())));
                vo.setDATETO_ATTR(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.DATETO_ATTR.toUpperCase())));
                /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
                vo.setSECOND(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.SECOND.toUpperCase())));
                vo.setSYATAN(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.SYATAN.toUpperCase())));
                vo.setNOHIN(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.NOHIN.toUpperCase())));
                vo.setPRODUCT(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.PRODUCT.toUpperCase())));
                vo.setDATEFROM(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.DATEFROM.toUpperCase())));
                vo.setDATETO(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.DATETO.toUpperCase())));
                vo.setMLIMIT(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.MLIMIT.toUpperCase())));
                vo.setKLIMIT(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.KLIMIT.toUpperCase())));
                vo.setDATERECOG(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.DATERECOG.toUpperCase())));
                vo.setDATEPRT(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.DATEPRT.toUpperCase())));
                vo.setBIKO(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.BIKO.toUpperCase())));
                vo.setCRTDATE(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.CRTDATE.toUpperCase())));
                vo.setCRTNM(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CRTNM.toUpperCase())));
                vo.setCRTAPL(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CRTAPL.toUpperCase())));
                vo.setCRTID(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CRTID.toUpperCase())));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.UPDDATE.toUpperCase())));
                vo.setUPDNM(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.UPDNM.toUpperCase())));
                vo.setUPDAPL(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.UPDAPL.toUpperCase())));
                vo.setUPDID(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.UPDID.toUpperCase())));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if (super.getModel() instanceof Tbj20SozaiKanriListVO) {

            list = new ArrayList<Tbj20SozaiKanriListVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                Tbj20SozaiKanriListVO vo = new Tbj20SozaiKanriListVO();
                vo.setCMCD(StringUtil.trim(result.get(Tbj20SozaiKanriList.CMCD.toUpperCase()).toString()));
                vo.setDELFLG(StringUtil.trim(result.get(Tbj20SozaiKanriList.DELFLG.toUpperCase()).toString()));
                vo.setSOZAIYM((Date)result.get(Tbj20SozaiKanriList.SOZAIYM.toUpperCase()));
                vo.setRECNO(StringUtil.trim(result.get(Tbj20SozaiKanriList.RECNO.toUpperCase()).toString()));
                vo.setRCODE(StringUtil.trim(result.get(Tbj20SozaiKanriList.RCODE.toUpperCase()).toString()));
                vo.setDCARCD(StringUtil.trim(result.get(Tbj20SozaiKanriList.DCARCD.toUpperCase()).toString()));
                /** 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD Start */
                vo.setTEMPCMCD(StringUtil.trim(result.get(Tbj20SozaiKanriList.TEMPCMCD.toUpperCase()).toString()));
                vo.setUPDDATE((Date)result.get(Tbj20SozaiKanriList.UPDDATE.toUpperCase()));
                vo.setUPDNM(StringUtil.trim(result.get(Tbj20SozaiKanriList.UPDNM.toUpperCase()).toString()));
                vo.setUPDID(StringUtil.trim(result.get(Tbj20SozaiKanriList.UPDID.toUpperCase()).toString()));
                vo.setUPDAPL(StringUtil.trim(result.get(Tbj20SozaiKanriList.UPDAPL.toUpperCase()).toString()));
                /** 2015/12/04 JASRAC対応 HLC S.Fujimoto ADD End */

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if (super.getModel() instanceof CmCodeIssueDocsVO) {

            list = new ArrayList<CmCodeIssueDocsVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                CmCodeIssueDocsVO vo = new CmCodeIssueDocsVO();
                vo.setCMCD(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CMCD.toUpperCase())));
                vo.setCATEGORY(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CATEGORY.toUpperCase())));
                vo.setTITLE(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.TITLE.toUpperCase())));
                vo.setSECOND(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.SECOND.toUpperCase())));
                vo.setSYATAN(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.SYATAN.toUpperCase())));
                vo.setCRTNM(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CRTNM.toUpperCase())));
                vo.setCRTAPL(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CRTAPL.toUpperCase())));
                vo.setCRTID(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CRTID.toUpperCase())));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if (super.getModel() instanceof MaterialEncodeListVO) {

            list = new ArrayList<MaterialEncodeListVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                MaterialEncodeListVO vo = new MaterialEncodeListVO();
                vo.setSTATUS(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.STATUS.toUpperCase())));
                vo.setDATERECOG(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.DATERECOG.toUpperCase())));
                vo.setCMCD(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CMCD.toUpperCase())));
                vo.setCATEGORY(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.CATEGORY.toUpperCase())));
                vo.setSECOND(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.SECOND.toUpperCase())));
                vo.setTITLE(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.TITLE.toUpperCase())));
                vo.setSYATAN(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.SYATAN.toUpperCase())));
                vo.setPRODUCT(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.PRODUCT.toUpperCase())));
                vo.setDATEFROM(DateUtil.toDateForNull(result.get(Tbj18SozaiKanriData.DATEFROM.toUpperCase())));
                vo.setBIKO(StringUtil.trim((String)result.get(Tbj18SozaiKanriData.BIKO.toUpperCase())));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        } else if (super.getModel() instanceof LogMaterialRegisterVO) {

            list = new ArrayList<LogMaterialRegisterVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map)hashList.get(i);
                LogMaterialRegisterVO vo = new LogMaterialRegisterVO();
                vo.setHISTORYKBN((String)result.get(Tbj25LogSozaiKanriData.HISTORYKBN.toUpperCase()));
                vo.setCMCD((String)result.get(Tbj25LogSozaiKanriData.CMCD.toUpperCase()));
                vo.setCARNM((String)result.get(Mbj05Car.CARNM.toUpperCase()));
                vo.setCATEGORY((String)result.get(Tbj25LogSozaiKanriData.CATEGORY.toUpperCase()));
                vo.setTITLE((String)result.get(Tbj25LogSozaiKanriData.TITLE.toUpperCase()));
                /** 2016/02/17 HDX対応 HLC K.Soga ADD Start */
                vo.setALIASTITLE(StringUtil.trim((String)result.get(Tbj25LogSozaiKanriData.ALIASTITLE.toUpperCase())));
                vo.setENDTITLE(StringUtil.trim((String)result.get(Tbj25LogSozaiKanriData.ENDTITLE.toUpperCase())));
                vo.setDATEFROM_ATTR(StringUtil.trim((String)result.get(Tbj25LogSozaiKanriData.DATEFROM_ATTR.toUpperCase())));
                vo.setDATETO_ATTR(StringUtil.trim((String)result.get(Tbj25LogSozaiKanriData.DATETO_ATTR.toUpperCase())));
                /** 2016/02/17 HDX対応 HLC K.Soga ADD End */
                vo.setSECOND((String)result.get(Tbj25LogSozaiKanriData.SECOND.toUpperCase()));
                vo.setSYATAN((String)result.get(Tbj25LogSozaiKanriData.SYATAN.toUpperCase()));
                vo.setPRODUCT((String)result.get(Tbj25LogSozaiKanriData.PRODUCT.toUpperCase()));
                vo.setDATEFROM(DateUtil.toDateForNull(result.get(Tbj25LogSozaiKanriData.DATEFROM.toUpperCase())));
                vo.setDATETO(DateUtil.toDateForNull(result.get(Tbj25LogSozaiKanriData.DATETO.toUpperCase())));
                vo.setMLIMIT(DateUtil.toDateForNull(result.get(Tbj25LogSozaiKanriData.MLIMIT.toUpperCase())));
                vo.setKLIMIT((String)result.get(Tbj25LogSozaiKanriData.KLIMIT.toUpperCase()));
                vo.setDATERECOG(DateUtil.toDateForNull(result.get(Tbj25LogSozaiKanriData.DATERECOG.toUpperCase())));
                vo.setBIKO((String)result.get(Tbj25LogSozaiKanriData.BIKO.toUpperCase()));
                vo.setCRTNM((String)result.get(Tbj25LogSozaiKanriData.CRTNM.toUpperCase()));
                vo.setCRTAPL((String)result.get(Tbj25LogSozaiKanriData.CRTAPL.toUpperCase()));
                vo.setCRTID((String)result.get(Tbj25LogSozaiKanriData.CRTID.toUpperCase()));
                vo.setCRTDATE(DateUtil.toDateForNull(result.get(Tbj25LogSozaiKanriData.CRTDATE.toUpperCase())));
                vo.setUPDNM((String)result.get(Tbj25LogSozaiKanriData.UPDNM.toUpperCase()));
                vo.setUPDDATE(DateUtil.toDateForNull(result.get(Tbj25LogSozaiKanriData.UPDDATE.toUpperCase())));

                //検索結果直後の状態にする
                ModelUtils.copyMemberSearchAfterInstace(vo);
                list.add(vo);
            }
        //割付済仮素材検索
        } else if ((getModel() instanceof UsedRdProgramMaterialVO)) {
            list = new ArrayList<UsedRdProgramMaterialVO>();
            for (int i = 0; i < hashList.size(); i++) {
                Map result = (Map) hashList.get(i);
                UsedRdProgramMaterialVO vo = new UsedRdProgramMaterialVO();
                vo.setRDSEQNO((BigDecimal)result.get(Tbj38RdProgramMaterial.RDSEQNO.toUpperCase()));
                vo.setYEARMONTH((String)result.get(Tbj38RdProgramMaterial.YEARMONTH.toUpperCase()));
                vo.setWAKUSEQNO((BigDecimal)result.get(Tbj38RdProgramMaterial.WAKUSEQ.toUpperCase()));
                vo.setNO((BigDecimal)result.get(Mbj51Natural.NO.toUpperCase()));
                vo.setCMCD((String)result.get(Tbj18SozaiKanriData.CMCD.toUpperCase()));

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
}